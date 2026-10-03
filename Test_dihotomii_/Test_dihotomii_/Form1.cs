using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Test_dihotomii_ {
  public partial class Form1 : Form {
    private string _formula = "";

    public Form1() {
      InitializeComponent();
      SetupChart();
    }

    // ---------------------------------------------------------------
    // Настройка внешнего вида графика
    // ---------------------------------------------------------------
    private void SetupChart() {
      // Если у Chart ещё нет ни одной области — создаём её
      if (chart1.ChartAreas.Count == 0) {
        var area = new ChartArea("main");
        chart1.ChartAreas.Add(area);
      }

      chart1.Series.Clear();
      var s = new Series("f(x)") {
        ChartType = SeriesChartType.Line,
        BorderWidth = 2,
        Color = Color.SteelBlue,
        XValueType = ChartValueType.Double,
        YValueType = ChartValueType.Double
      };
      chart1.Series.Add(s);

      var ca = chart1.ChartAreas[0];
      ca.AxisX.Title = "x";
      ca.AxisY.Title = "f(x)";
      ca.AxisX.MajorGrid.LineColor = Color.LightGray;
      ca.AxisY.MajorGrid.LineColor = Color.LightGray;
      ca.AxisX.Crossing = 0;
      ca.AxisY.Crossing = 0;
    }

    // ---------------------------------------------------------------
    // Кнопка «Построить график»
    // ---------------------------------------------------------------
    private void btnPlot_Click(object sender, EventArgs e) {
      lblResult.Text = "";
      lblStatus.ForeColor = Color.Red;

      string formula = txtF.Text.Trim();
      if (string.IsNullOrWhiteSpace(formula)) {
        lblStatus.Text = "Введите формулу f(x).";
        return;
      }

      if (!TryParseDouble(txtA.Text, out double a)) {
        lblStatus.Text = "Параметр a задан некорректно.";
        return;
      }
      if (!TryParseDouble(txtB.Text, out double b)) {
        lblStatus.Text = "Параметр b задан некорректно.";
        return;
      }
      if (a >= b) {
        lblStatus.Text = "Требуется a < b.";
        return;
      }
      if (!TryParseDouble(txtE.Text, out double eps) || eps <= 0) {
        lblStatus.Text = "Погрешность ε должна быть положительным числом.";
        return;
      }

      try {
        double test = FormulaParser.Eval(formula, (a + b) / 2.0);
        if (double.IsNaN(test) || double.IsInfinity(test))
          throw new Exception();
      } catch {
        lblStatus.Text = "Не удалось вычислить f(x). Проверьте формулу.";
         return;
      }

      _formula = formula;
      lblStatus.ForeColor = Color.Green;
      lblStatus.Text = "График построен. Нажмите «Рассчитать» в меню.";

      DrawGraph(a, b);
    }

    // ---------------------------------------------------------------
    // Отрисовка графика f(x) на [a, b]
    // ---------------------------------------------------------------
    private void DrawGraph(double a, double b) {
      chart1.Series[0].Points.Clear();

      int N = 800;
      double step = (b - a) / N;
      double yMin = double.MaxValue, yMax = double.MinValue;

      for (int i = 0; i <= N; i++) {
        double x = a + i * step;
        double y;
        try { y = FormulaParser.Eval(_formula, x); }
        catch { y = double.NaN; }

        if (!double.IsNaN(y) && !double.IsInfinity(y) && Math.Abs(y) < 1e6) {
          if (y < yMin) yMin = y;
          if (y > yMax) yMax = y;
        }
      }

      double pad = (yMax - yMin) * 0.1;
      if (pad <= 0) pad = 1;
      yMin -= pad;
      yMax += pad;

      chart1.ChartAreas[0].AxisY.Minimum = yMin;
      chart1.ChartAreas[0].AxisY.Maximum = yMax;
      chart1.ChartAreas[0].AxisX.Minimum = a;
      chart1.ChartAreas[0].AxisX.Maximum = b;

      for (int i = 0; i <= N; ++i) {
        double x = a + i * step;
        double y;
        try { y = FormulaParser.Eval(_formula, x); }
        catch { continue; }

        if (double.IsNaN(y) || double.IsInfinity(y) || Math.Abs(y) > 1e6)
          continue;

        chart1.Series[0].Points.AddXY(x, y);
      }
    }

    // ---------------------------------------------------------------
    // Пункт меню «Рассчитать» — метод дихотомии
    // ---------------------------------------------------------------
    private void menuCalc_Click(object sender, EventArgs e) {
      lblResult.Text = "";
      lblStatus.ForeColor = Color.Red;

      if (string.IsNullOrWhiteSpace(_formula)) {
        lblStatus.Text = "Сначала постройте график (кнопка «Построить график»).";
        return;
      }

      if (!TryParseDouble(txtA.Text, out double a) ||
          !TryParseDouble(txtB.Text, out double b) ||
          !TryParseDouble(txtE.Text, out double eps) || eps <= 0) {
            lblStatus.Text = "Проверьте параметры a, b, ε.";
            return;
      }

      double fa, fb;
      try {
        fa = FormulaParser.Eval(_formula, a);
        fb = FormulaParser.Eval(_formula, b); 
      } catch {
        lblStatus.Text = "Ошибка вычисления f(x) на концах интервала.";
        return;
      }

      if (double.IsNaN(fa) || double.IsNaN(fb)) {
        lblStatus.Text = "f(a) или f(b) не определены.";
        return;
      }

      if (Math.Sign(fa) == Math.Sign(fb)) {
        lblStatus.Text = "На концах интервала функция имеет одинаковые знаки — корень не гарантирован. " +
                         "Сузьте интервал по графику.";
        return;
      }

      int iter = 0;
      const int maxIter = 10000;
      double c = a;
      while ((b - a) / 2.0 > eps && iter < maxIter) {
        c = (a + b) / 2.0;
        double fc = FormulaParser.Eval(_formula, c);

        if (double.IsNaN(fc)) {
          lblStatus.Text = "f(x) не определена в середине интервала.";
          return;
        }

        if (Math.Sign(fc) == Math.Sign(fa)) {
          a = c;
          fa = fc;
        } else {
          b = c;
          fb = fc;
        }
        ++iter;
      }

      double root = (a + b) / 2.0;
      double fRoot = FormulaParser.Eval(_formula, root);

      var marker = new Series("root") {
        ChartType = SeriesChartType.Point,
        MarkerStyle = MarkerStyle.Circle,
        MarkerSize = 10,
        MarkerColor = Color.Red,
        Color = Color.Red
      };
      chart1.Series.Remove(chart1.Series.FindByName("root"));
      chart1.Series.Add(marker);
      marker.Points.AddXY(root, fRoot);

      lblStatus.ForeColor = Color.Green;
      lblStatus.Text = "Корень найден.";
      lblResult.Text = $"x* = {root:F6}\n" +
                       $"f(x*) = {fRoot:E4}\n" +
                       $"Итераций: {iter}\n" +
                       $"Достигнутая точность: {(b - a) / 2.0:E4}";
    }

    // ---------------------------------------------------------------
    // Пункт меню «Очистить»
    // ---------------------------------------------------------------
    private void menuClear_Click(object sender, EventArgs e) {
      txtA.Text = "";
      txtB.Text = "";
      txtE.Text = "";
      txtF.Text = "";
      lblResult.Text = "";
      lblStatus.Text = "";
      _formula = "";
      chart1.Series[0].Points.Clear();
      chart1.Series.Remove(chart1.Series.FindByName("root"));
    }

    // ---------------------------------------------------------------
    // Хелпер: разбор числа (запятая или точка)
    // ---------------------------------------------------------------
    private bool TryParseDouble(string s, out double value) {
      s = s.Trim().Replace(',', '.');
      return double.TryParse(s, NumberStyles.Float,
                             CultureInfo.InvariantCulture, out value);
    }
  }
}
