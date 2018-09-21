namespace WindowsFormsAppTest
{
    partial class Statistics
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonAddTrend = new System.Windows.Forms.Button();
            this.comboBoxDateTimeIntervalType = new System.Windows.Forms.ComboBox();
            this.labelDateTimeIntervalType = new System.Windows.Forms.Label();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonShow = new System.Windows.Forms.Button();
            this.comboBoxChartType = new System.Windows.Forms.ComboBox();
            this.labelChartType = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labelPixelX = new System.Windows.Forms.Label();
            this.labelPixelY = new System.Windows.Forms.Label();
            this.labelXValue = new System.Windows.Forms.Label();
            this.labelYValue = new System.Windows.Forms.Label();
            this.btnWcf = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.btnWcf);
            this.panel1.Controls.Add(this.buttonAddTrend);
            this.panel1.Controls.Add(this.comboBoxDateTimeIntervalType);
            this.panel1.Controls.Add(this.labelDateTimeIntervalType);
            this.panel1.Controls.Add(this.buttonAdd);
            this.panel1.Controls.Add(this.buttonShow);
            this.panel1.Controls.Add(this.comboBoxChartType);
            this.panel1.Controls.Add(this.labelChartType);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(688, 122);
            this.panel1.TabIndex = 0;
            // 
            // buttonAddTrend
            // 
            this.buttonAddTrend.Location = new System.Drawing.Point(571, 98);
            this.buttonAddTrend.Name = "buttonAddTrend";
            this.buttonAddTrend.Size = new System.Drawing.Size(75, 23);
            this.buttonAddTrend.TabIndex = 6;
            this.buttonAddTrend.Text = "Add trend";
            this.buttonAddTrend.UseVisualStyleBackColor = true;
            this.buttonAddTrend.Click += new System.EventHandler(this.buttonAddTrend_Click);
            // 
            // comboBoxDateTimeIntervalType
            // 
            this.comboBoxDateTimeIntervalType.FormattingEnabled = true;
            this.comboBoxDateTimeIntervalType.Location = new System.Drawing.Point(97, 53);
            this.comboBoxDateTimeIntervalType.Name = "comboBoxDateTimeIntervalType";
            this.comboBoxDateTimeIntervalType.Size = new System.Drawing.Size(146, 21);
            this.comboBoxDateTimeIntervalType.TabIndex = 5;
            // 
            // labelDateTimeIntervalType
            // 
            this.labelDateTimeIntervalType.AutoSize = true;
            this.labelDateTimeIntervalType.Location = new System.Drawing.Point(22, 53);
            this.labelDateTimeIntervalType.Name = "labelDateTimeIntervalType";
            this.labelDateTimeIntervalType.Size = new System.Drawing.Size(68, 13);
            this.labelDateTimeIntervalType.TabIndex = 4;
            this.labelDateTimeIntervalType.Text = "Interval type:";
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(571, 69);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 3;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonShow
            // 
            this.buttonShow.Location = new System.Drawing.Point(571, 14);
            this.buttonShow.Name = "buttonShow";
            this.buttonShow.Size = new System.Drawing.Size(75, 23);
            this.buttonShow.TabIndex = 2;
            this.buttonShow.Text = "Show";
            this.buttonShow.UseVisualStyleBackColor = true;
            this.buttonShow.Click += new System.EventHandler(this.buttonShow_Click);
            // 
            // comboBoxChartType
            // 
            this.comboBoxChartType.FormattingEnabled = true;
            this.comboBoxChartType.Location = new System.Drawing.Point(97, 17);
            this.comboBoxChartType.Name = "comboBoxChartType";
            this.comboBoxChartType.Size = new System.Drawing.Size(146, 21);
            this.comboBoxChartType.TabIndex = 1;
            // 
            // labelChartType
            // 
            this.labelChartType.AutoSize = true;
            this.labelChartType.Location = new System.Drawing.Point(22, 19);
            this.labelChartType.Name = "labelChartType";
            this.labelChartType.Size = new System.Drawing.Size(58, 13);
            this.labelChartType.TabIndex = 0;
            this.labelChartType.Text = "Chart type:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.Controls.Add(this.chart1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 164);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1208, 513);
            this.panel2.TabIndex = 1;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1208, 513);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // labelPixelX
            // 
            this.labelPixelX.AutoSize = true;
            this.labelPixelX.Location = new System.Drawing.Point(741, 120);
            this.labelPixelX.Name = "labelPixelX";
            this.labelPixelX.Size = new System.Drawing.Size(35, 13);
            this.labelPixelX.TabIndex = 2;
            this.labelPixelX.Text = "label1";
            // 
            // labelPixelY
            // 
            this.labelPixelY.AutoSize = true;
            this.labelPixelY.Location = new System.Drawing.Point(741, 95);
            this.labelPixelY.Name = "labelPixelY";
            this.labelPixelY.Size = new System.Drawing.Size(35, 13);
            this.labelPixelY.TabIndex = 3;
            this.labelPixelY.Text = "label1";
            // 
            // labelXValue
            // 
            this.labelXValue.AutoSize = true;
            this.labelXValue.Location = new System.Drawing.Point(741, 37);
            this.labelXValue.Name = "labelXValue";
            this.labelXValue.Size = new System.Drawing.Size(35, 13);
            this.labelXValue.TabIndex = 4;
            this.labelXValue.Text = "label1";
            // 
            // labelYValue
            // 
            this.labelYValue.AutoSize = true;
            this.labelYValue.Location = new System.Drawing.Point(741, 65);
            this.labelYValue.Name = "labelYValue";
            this.labelYValue.Size = new System.Drawing.Size(35, 13);
            this.labelYValue.TabIndex = 5;
            this.labelYValue.Text = "label2";
            // 
            // btnWcf
            // 
            this.btnWcf.Location = new System.Drawing.Point(571, 40);
            this.btnWcf.Name = "btnWcf";
            this.btnWcf.Size = new System.Drawing.Size(75, 23);
            this.btnWcf.TabIndex = 7;
            this.btnWcf.Text = "WCF Show";
            this.btnWcf.UseVisualStyleBackColor = true;
            this.btnWcf.Click += new System.EventHandler(this.btnWcf_Click);
            // 
            // Statistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 677);
            this.Controls.Add(this.labelYValue);
            this.Controls.Add(this.labelXValue);
            this.Controls.Add(this.labelPixelY);
            this.Controls.Add(this.labelPixelX);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Statistics";
            this.Text = "Statistics";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ComboBox comboBoxChartType;
        private System.Windows.Forms.Label labelChartType;
        private System.Windows.Forms.Button buttonShow;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.ComboBox comboBoxDateTimeIntervalType;
        private System.Windows.Forms.Label labelDateTimeIntervalType;
        private System.Windows.Forms.Label labelPixelX;
        private System.Windows.Forms.Label labelPixelY;
        private System.Windows.Forms.Label labelXValue;
        private System.Windows.Forms.Label labelYValue;
        private System.Windows.Forms.Button buttonAddTrend;
        private System.Windows.Forms.Button btnWcf;
    }
}