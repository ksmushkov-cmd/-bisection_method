namespace Test_dihotomii_ {
  partial class Form1 {
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem menuCalc;
    private System.Windows.Forms.ToolStripMenuItem menuClear;
    private System.Windows.Forms.TextBox txtF;
    private System.Windows.Forms.TextBox txtA;
    private System.Windows.Forms.TextBox txtB;
    private System.Windows.Forms.TextBox txtE;
    private System.Windows.Forms.Button btnPlot;
    private System.Windows.Forms.Label lblF;
    private System.Windows.Forms.Label lblA;
    private System.Windows.Forms.Label lblB;
    private System.Windows.Forms.Label lblE;
    private System.Windows.Forms.Label lblResult;
    private System.Windows.Forms.Label lblStatus;
    private System.Windows.Forms.DataVisualization.Charting.Chart chart1;

    protected override void Dispose(bool disposing) {
      if (disposing && (components != null))
        components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent() {
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.menuCalc = new System.Windows.Forms.ToolStripMenuItem();
      this.menuClear = new System.Windows.Forms.ToolStripMenuItem();
      this.txtF = new System.Windows.Forms.TextBox();
      this.txtA = new System.Windows.Forms.TextBox();
      this.txtB = new System.Windows.Forms.TextBox();
      this.txtE = new System.Windows.Forms.TextBox();
      this.btnPlot = new System.Windows.Forms.Button();
      this.lblF = new System.Windows.Forms.Label();
      this.lblA = new System.Windows.Forms.Label();
      this.lblB = new System.Windows.Forms.Label();
      this.lblE = new System.Windows.Forms.Label();
      this.lblResult = new System.Windows.Forms.Label();
      this.lblStatus = new System.Windows.Forms.Label();
      this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
      this.menuStrip1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
      this.SuspendLayout();

     // menuStrip1
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        this.menuCalc, this.menuClear});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(950, 24);

      // menuCalc
      this.menuCalc.Name = "menuCalc";
      this.menuCalc.Text = "Рассчитать";
      this.menuCalc.Click += new System.EventHandler(this.menuCalc_Click);

      // menuClear
      this.menuClear.Name = "menuClear";
      this.menuClear.Text = "Очистить";
      this.menuClear.Click += new System.EventHandler(this.menuClear_Click);

      // labels
      this.lblF.AutoSize = true; this.lblF.Location = new System.Drawing.Point(12, 40); this.lblF.Text = "f(x) =";
      this.lblA.AutoSize = true; this.lblA.Location = new System.Drawing.Point(12, 72); this.lblA.Text = "a =";
      this.lblB.AutoSize = true; this.lblB.Location = new System.Drawing.Point(160, 72); this.lblB.Text = "b =";
      this.lblE.AutoSize = true; this.lblE.Location = new System.Drawing.Point(310, 72); this.lblE.Text = "ε =";

      // textboxes
      this.txtF.Location = new System.Drawing.Point(60, 37); this.txtF.Size = new System.Drawing.Size(320, 20);
      this.txtF.Text = "x*x - 4";
      this.txtA.Location = new System.Drawing.Point(45, 69); this.txtA.Size = new System.Drawing.Size(100, 20);
      this.txtA.Text = "0";
      this.txtB.Location = new System.Drawing.Point(193, 69); this.txtB.Size = new System.Drawing.Size(100, 20);
      this.txtB.Text = "5";
      this.txtE.Location = new System.Drawing.Point(343, 69); this.txtE.Size = new System.Drawing.Size(100, 20);
      this.txtE.Text = "0,000001";

      // btnPlot
      this.btnPlot.Location = new System.Drawing.Point(470, 35);
      this.btnPlot.Size = new System.Drawing.Size(160, 28);
      this.btnPlot.Text = "Построить график";
      this.btnPlot.UseVisualStyleBackColor = true;
      this.btnPlot.Click += new System.EventHandler(this.btnPlot_Click);

      // lblResult
      this.lblResult.Location = new System.Drawing.Point(12, 100);
      this.lblResult.Size = new System.Drawing.Size(920, 60);
      this.lblResult.Font = new System.Drawing.Font("Consolas", 9F);
      this.lblResult.Text = "";

      // lblStatus
      this.lblStatus.Location = new System.Drawing.Point(12, 160);
      this.lblStatus.Size = new System.Drawing.Size(920, 20);
      this.lblStatus.Text = "";

      // chart1
      this.chart1.Location = new System.Drawing.Point(12, 185);
      this.chart1.Size = new System.Drawing.Size(920, 420);
      this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)
        ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
        | System.Windows.Forms.AnchorStyles.Left)
        | System.Windows.Forms.AnchorStyles.Right)));

      // Form1
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(950, 620);
      this.Controls.Add(this.chart1);
      this.Controls.Add(this.lblStatus);
      this.Controls.Add(this.lblResult);
      this.Controls.Add(this.btnPlot);
      this.Controls.Add(this.txtE);
      this.Controls.Add(this.lblE);
      this.Controls.Add(this.txtB);
      this.Controls.Add(this.lblB);
      this.Controls.Add(this.txtA);
      this.Controls.Add(this.lblA);
      this.Controls.Add(this.txtF);
      this.Controls.Add(this.lblF);
      this.Controls.Add(this.menuStrip1);
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "Form1";
      this.Text = "Лабораторная №1. Метод дихотомии";
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}

