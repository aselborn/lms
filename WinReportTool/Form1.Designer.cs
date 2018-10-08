namespace WinReportTool
{
    partial class frmMain
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
            this.lstTestBed = new System.Windows.Forms.ListBox();
            this.btnAddTestbed = new System.Windows.Forms.Button();
            this.txtTestBed = new System.Windows.Forms.TextBox();
            this.tbTestBed = new System.Windows.Forms.TabControl();
            this.testBedTB = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnAddDevice = new System.Windows.Forms.Button();
            this.txtDevice = new System.Windows.Forms.TextBox();
            this.lstDevice = new System.Windows.Forms.ListBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnAddEventType = new System.Windows.Forms.Button();
            this.txtEventType = new System.Windows.Forms.TextBox();
            this.trEventTypes = new System.Windows.Forms.TreeView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.btnRename = new System.Windows.Forms.Button();
            this.tbTestBed.SuspendLayout();
            this.testBedTB.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstTestBed
            // 
            this.lstTestBed.FormattingEnabled = true;
            this.lstTestBed.Location = new System.Drawing.Point(6, 6);
            this.lstTestBed.Name = "lstTestBed";
            this.lstTestBed.Size = new System.Drawing.Size(360, 303);
            this.lstTestBed.TabIndex = 1;
            this.lstTestBed.Click += new System.EventHandler(this.lstTestBed_Click);
            this.lstTestBed.SelectedIndexChanged += new System.EventHandler(this.lstTestBed_SelectedIndexChanged);
            // 
            // btnAddTestbed
            // 
            this.btnAddTestbed.Location = new System.Drawing.Point(372, 32);
            this.btnAddTestbed.Name = "btnAddTestbed";
            this.btnAddTestbed.Size = new System.Drawing.Size(85, 20);
            this.btnAddTestbed.TabIndex = 2;
            this.btnAddTestbed.Text = "Add";
            this.btnAddTestbed.UseVisualStyleBackColor = true;
            this.btnAddTestbed.Click += new System.EventHandler(this.btnAddTestbed_Click);
            // 
            // txtTestBed
            // 
            this.txtTestBed.Location = new System.Drawing.Point(372, 6);
            this.txtTestBed.Name = "txtTestBed";
            this.txtTestBed.Size = new System.Drawing.Size(223, 20);
            this.txtTestBed.TabIndex = 4;
            // 
            // tbTestBed
            // 
            this.tbTestBed.Controls.Add(this.testBedTB);
            this.tbTestBed.Controls.Add(this.tabPage2);
            this.tbTestBed.Controls.Add(this.tabPage1);
            this.tbTestBed.Controls.Add(this.tabPage3);
            this.tbTestBed.Location = new System.Drawing.Point(12, 12);
            this.tbTestBed.Name = "tbTestBed";
            this.tbTestBed.SelectedIndex = 0;
            this.tbTestBed.Size = new System.Drawing.Size(687, 527);
            this.tbTestBed.TabIndex = 8;
            // 
            // testBedTB
            // 
            this.testBedTB.Controls.Add(this.btnRename);
            this.testBedTB.Controls.Add(this.lstTestBed);
            this.testBedTB.Controls.Add(this.txtTestBed);
            this.testBedTB.Controls.Add(this.btnAddTestbed);
            this.testBedTB.Location = new System.Drawing.Point(4, 22);
            this.testBedTB.Name = "testBedTB";
            this.testBedTB.Padding = new System.Windows.Forms.Padding(3);
            this.testBedTB.Size = new System.Drawing.Size(679, 501);
            this.testBedTB.TabIndex = 0;
            this.testBedTB.Text = "Test bed objects";
            this.testBedTB.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnAddDevice);
            this.tabPage2.Controls.Add(this.txtDevice);
            this.tabPage2.Controls.Add(this.lstDevice);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(679, 501);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Devices";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnAddDevice
            // 
            this.btnAddDevice.Location = new System.Drawing.Point(576, 32);
            this.btnAddDevice.Name = "btnAddDevice";
            this.btnAddDevice.Size = new System.Drawing.Size(85, 20);
            this.btnAddDevice.TabIndex = 10;
            this.btnAddDevice.Text = "Add";
            this.btnAddDevice.UseVisualStyleBackColor = true;
            // 
            // txtDevice
            // 
            this.txtDevice.Location = new System.Drawing.Point(438, 6);
            this.txtDevice.Name = "txtDevice";
            this.txtDevice.Size = new System.Drawing.Size(223, 20);
            this.txtDevice.TabIndex = 9;
            // 
            // lstDevice
            // 
            this.lstDevice.FormattingEnabled = true;
            this.lstDevice.Location = new System.Drawing.Point(6, 6);
            this.lstDevice.Name = "lstDevice";
            this.lstDevice.Size = new System.Drawing.Size(426, 238);
            this.lstDevice.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnAddEventType);
            this.tabPage1.Controls.Add(this.txtEventType);
            this.tabPage1.Controls.Add(this.trEventTypes);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(679, 501);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "EventType";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnAddEventType
            // 
            this.btnAddEventType.Location = new System.Drawing.Point(506, 14);
            this.btnAddEventType.Name = "btnAddEventType";
            this.btnAddEventType.Size = new System.Drawing.Size(108, 23);
            this.btnAddEventType.TabIndex = 2;
            this.btnAddEventType.Text = "Add EventType";
            this.btnAddEventType.UseVisualStyleBackColor = true;
            this.btnAddEventType.Click += new System.EventHandler(this.btnAddEventType_Click);
            // 
            // txtEventType
            // 
            this.txtEventType.Location = new System.Drawing.Point(234, 14);
            this.txtEventType.Name = "txtEventType";
            this.txtEventType.Size = new System.Drawing.Size(266, 20);
            this.txtEventType.TabIndex = 1;
            // 
            // trEventTypes
            // 
            this.trEventTypes.Location = new System.Drawing.Point(16, 14);
            this.trEventTypes.Name = "trEventTypes";
            this.trEventTypes.Size = new System.Drawing.Size(212, 470);
            this.trEventTypes.TabIndex = 0;
            this.trEventTypes.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trEventTypes_AfterSelect);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button5);
            this.tabPage3.Controls.Add(this.button4);
            this.tabPage3.Controls.Add(this.button3);
            this.tabPage3.Controls.Add(this.button2);
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(679, 501);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "Register events";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.ForestGreen;
            this.button1.Location = new System.Drawing.Point(13, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(155, 40);
            this.button1.TabIndex = 0;
            this.button1.Text = "FP ACTIVITY";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.ForestGreen;
            this.button2.Location = new System.Drawing.Point(13, 56);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(155, 40);
            this.button2.TabIndex = 1;
            this.button2.Text = "LP ACTIVITY";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Red;
            this.button3.Location = new System.Drawing.Point(13, 102);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(155, 40);
            this.button3.TabIndex = 2;
            this.button3.Text = "RIG STOP";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.DodgerBlue;
            this.button4.Location = new System.Drawing.Point(13, 148);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(155, 40);
            this.button4.TabIndex = 3;
            this.button4.Text = "PLANNED MAINT";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Yellow;
            this.button5.Location = new System.Drawing.Point(13, 194);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(155, 40);
            this.button5.TabIndex = 4;
            this.button5.Text = "NO ACTIVITY";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // btnRename
            // 
            this.btnRename.Location = new System.Drawing.Point(510, 32);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(85, 20);
            this.btnRename.TabIndex = 5;
            this.btnRename.Text = "Rename";
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 551);
            this.Controls.Add(this.tbTestBed);
            this.Name = "frmMain";
            this.Text = "Report Admin";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tbTestBed.ResumeLayout(false);
            this.testBedTB.ResumeLayout(false);
            this.testBedTB.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox lstTestBed;
        private System.Windows.Forms.Button btnAddTestbed;
        private System.Windows.Forms.TextBox txtTestBed;
        private System.Windows.Forms.TabControl tbTestBed;
        private System.Windows.Forms.TabPage testBedTB;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnAddDevice;
        private System.Windows.Forms.TextBox txtDevice;
        private System.Windows.Forms.ListBox lstDevice;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TreeView trEventTypes;
        private System.Windows.Forms.Button btnAddEventType;
        private System.Windows.Forms.TextBox txtEventType;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnRename;
    }
}

