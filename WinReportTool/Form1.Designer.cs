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
            this.components = new System.ComponentModel.Container();
            this.lstTestBed = new System.Windows.Forms.ListBox();
            this.btnAddTestbed = new System.Windows.Forms.Button();
            this.txtTestBed = new System.Windows.Forms.TextBox();
            this.tbTestBed = new System.Windows.Forms.TabControl();
            this.testBedTB = new System.Windows.Forms.TabPage();
            this.btnRename = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnAddDevice = new System.Windows.Forms.Button();
            this.txtDevice = new System.Windows.Forms.TextBox();
            this.lstDevice = new System.Windows.Forms.ListBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnAddEventType = new System.Windows.Forms.Button();
            this.txtEventType = new System.Windows.Forms.TextBox();
            this.trEventTypes = new System.Windows.Forms.TreeView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lstEventLog = new System.Windows.Forms.ListBox();
            this.dateTimePickerEventDate = new System.Windows.Forms.DateTimePicker();
            this.btnFindEvent = new System.Windows.Forms.Button();
            this.comboBoxTestBed = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRegisterEvent = new System.Windows.Forms.Button();
            this.dataGridViewEventLogs = new System.Windows.Forms.DataGridView();
            this.eventLogBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.eventTypeDescriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EventTypeReason = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.valueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventLogIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventLogTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventLogUserIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventTypeIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventLogManualTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.testBedIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.testIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.testObjectIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deviceIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userObjectIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbTestBed.SuspendLayout();
            this.testBedTB.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEventLogs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventLogBindingSource)).BeginInit();
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
            this.tbTestBed.Size = new System.Drawing.Size(844, 537);
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
            this.testBedTB.Size = new System.Drawing.Size(836, 511);
            this.testBedTB.TabIndex = 0;
            this.testBedTB.Text = "Test bed objects";
            this.testBedTB.UseVisualStyleBackColor = true;
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
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnAddDevice);
            this.tabPage2.Controls.Add(this.txtDevice);
            this.tabPage2.Controls.Add(this.lstDevice);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(836, 511);
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
            this.tabPage1.Size = new System.Drawing.Size(836, 511);
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
            this.tabPage3.Controls.Add(this.dataGridViewEventLogs);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.comboBoxTestBed);
            this.tabPage3.Controls.Add(this.btnRegisterEvent);
            this.tabPage3.Controls.Add(this.btnFindEvent);
            this.tabPage3.Controls.Add(this.dateTimePickerEventDate);
            this.tabPage3.Controls.Add(this.lstEventLog);
            this.tabPage3.Controls.Add(this.button5);
            this.tabPage3.Controls.Add(this.button4);
            this.tabPage3.Controls.Add(this.button3);
            this.tabPage3.Controls.Add(this.button2);
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(836, 511);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "Register events";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Yellow;
            this.button5.Location = new System.Drawing.Point(17, 259);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(155, 40);
            this.button5.TabIndex = 4;
            this.button5.Text = "NO ACTIVITY";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.DodgerBlue;
            this.button4.Location = new System.Drawing.Point(17, 213);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(155, 40);
            this.button4.TabIndex = 3;
            this.button4.Text = "PLANNED MAINT";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Red;
            this.button3.Location = new System.Drawing.Point(17, 167);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(155, 40);
            this.button3.TabIndex = 2;
            this.button3.Text = "RIG STOP";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.ForestGreen;
            this.button2.Location = new System.Drawing.Point(17, 121);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(155, 40);
            this.button2.TabIndex = 1;
            this.button2.Text = "LP ACTIVITY";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.ForestGreen;
            this.button1.Location = new System.Drawing.Point(17, 75);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(155, 40);
            this.button1.TabIndex = 0;
            this.button1.Text = "FP ACTIVITY";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // lstEventLog
            // 
            this.lstEventLog.FormattingEnabled = true;
            this.lstEventLog.Location = new System.Drawing.Point(219, 75);
            this.lstEventLog.Name = "lstEventLog";
            this.lstEventLog.Size = new System.Drawing.Size(562, 95);
            this.lstEventLog.TabIndex = 9;
            // 
            // dateTimePickerEventDate
            // 
            this.dateTimePickerEventDate.CustomFormat = "";
            this.dateTimePickerEventDate.Location = new System.Drawing.Point(90, 38);
            this.dateTimePickerEventDate.Name = "dateTimePickerEventDate";
            this.dateTimePickerEventDate.Size = new System.Drawing.Size(155, 20);
            this.dateTimePickerEventDate.TabIndex = 10;
            this.dateTimePickerEventDate.Value = new System.DateTime(2018, 10, 11, 0, 0, 0, 0);
            this.dateTimePickerEventDate.ValueChanged += new System.EventHandler(this.dateTimePickerEventDate_ValueChanged);
            // 
            // btnFindEvent
            // 
            this.btnFindEvent.Location = new System.Drawing.Point(706, 41);
            this.btnFindEvent.Name = "btnFindEvent";
            this.btnFindEvent.Size = new System.Drawing.Size(75, 23);
            this.btnFindEvent.TabIndex = 11;
            this.btnFindEvent.Text = "Find";
            this.btnFindEvent.UseVisualStyleBackColor = true;
            this.btnFindEvent.Click += new System.EventHandler(this.btnFindEvent_Click);
            // 
            // comboBoxTestBed
            // 
            this.comboBoxTestBed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTestBed.FormattingEnabled = true;
            this.comboBoxTestBed.Location = new System.Drawing.Point(90, 12);
            this.comboBoxTestBed.Name = "comboBoxTestBed";
            this.comboBoxTestBed.Size = new System.Drawing.Size(155, 21);
            this.comboBoxTestBed.TabIndex = 12;
            this.comboBoxTestBed.SelectedIndexChanged += new System.EventHandler(this.comboBoxTestBed_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "TestBed";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "EventDate";
            // 
            // btnRegisterEvent
            // 
            this.btnRegisterEvent.Location = new System.Drawing.Point(706, 424);
            this.btnRegisterEvent.Name = "btnRegisterEvent";
            this.btnRegisterEvent.Size = new System.Drawing.Size(75, 23);
            this.btnRegisterEvent.TabIndex = 11;
            this.btnRegisterEvent.Text = "Register";
            this.btnRegisterEvent.UseVisualStyleBackColor = true;
            this.btnRegisterEvent.Click += new System.EventHandler(this.btnFindEvent_Click);
            // 
            // dataGridViewEventLogs
            // 
            this.dataGridViewEventLogs.AutoGenerateColumns = false;
            this.dataGridViewEventLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEventLogs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.eventTypeDescriptionDataGridViewTextBoxColumn,
            this.EventTypeReason,
            this.valueDataGridViewTextBoxColumn,
            this.eventLogIdDataGridViewTextBoxColumn,
            this.eventLogTimeDataGridViewTextBoxColumn,
            this.eventLogUserIdDataGridViewTextBoxColumn,
            this.eventTypeIdDataGridViewTextBoxColumn,
            this.eventLogManualTimeDataGridViewTextBoxColumn,
            this.customerIdDataGridViewTextBoxColumn,
            this.testBedIdDataGridViewTextBoxColumn,
            this.testIdDataGridViewTextBoxColumn,
            this.testObjectIdDataGridViewTextBoxColumn,
            this.deviceIdDataGridViewTextBoxColumn,
            this.userObjectIdDataGridViewTextBoxColumn,
            this.itemIdDataGridViewTextBoxColumn});
            this.dataGridViewEventLogs.DataSource = this.eventLogBindingSource;
            this.dataGridViewEventLogs.Location = new System.Drawing.Point(219, 187);
            this.dataGridViewEventLogs.Name = "dataGridViewEventLogs";
            this.dataGridViewEventLogs.Size = new System.Drawing.Size(562, 231);
            this.dataGridViewEventLogs.TabIndex = 15;
            this.dataGridViewEventLogs.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewEventLogs_CellContentClick);
            this.dataGridViewEventLogs.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataGridViewEventLogs_RowPrePaint);
            // 
            // eventLogBindingSource
            // 
            this.eventLogBindingSource.DataSource = typeof(ReportDao.Model.Bridge.EventLog);
            // 
            // eventTypeDescriptionDataGridViewTextBoxColumn
            // 
            this.eventTypeDescriptionDataGridViewTextBoxColumn.DataPropertyName = "EventTypeDescription";
            this.eventTypeDescriptionDataGridViewTextBoxColumn.HeaderText = "Event Type";
            this.eventTypeDescriptionDataGridViewTextBoxColumn.Name = "eventTypeDescriptionDataGridViewTextBoxColumn";
            this.eventTypeDescriptionDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // EventTypeReason
            // 
            this.EventTypeReason.HeaderText = "Reason";
            this.EventTypeReason.Name = "EventTypeReason";
            // 
            // valueDataGridViewTextBoxColumn
            // 
            this.valueDataGridViewTextBoxColumn.DataPropertyName = "Value";
            this.valueDataGridViewTextBoxColumn.HeaderText = "Time (min)";
            this.valueDataGridViewTextBoxColumn.Name = "valueDataGridViewTextBoxColumn";
            // 
            // eventLogIdDataGridViewTextBoxColumn
            // 
            this.eventLogIdDataGridViewTextBoxColumn.DataPropertyName = "EventLogId";
            this.eventLogIdDataGridViewTextBoxColumn.HeaderText = "EventLogId";
            this.eventLogIdDataGridViewTextBoxColumn.Name = "eventLogIdDataGridViewTextBoxColumn";
            // 
            // eventLogTimeDataGridViewTextBoxColumn
            // 
            this.eventLogTimeDataGridViewTextBoxColumn.DataPropertyName = "EventLogTime";
            this.eventLogTimeDataGridViewTextBoxColumn.HeaderText = "EventLogTime";
            this.eventLogTimeDataGridViewTextBoxColumn.Name = "eventLogTimeDataGridViewTextBoxColumn";
            // 
            // eventLogUserIdDataGridViewTextBoxColumn
            // 
            this.eventLogUserIdDataGridViewTextBoxColumn.DataPropertyName = "EventLogUserId";
            this.eventLogUserIdDataGridViewTextBoxColumn.HeaderText = "EventLogUserId";
            this.eventLogUserIdDataGridViewTextBoxColumn.Name = "eventLogUserIdDataGridViewTextBoxColumn";
            // 
            // eventTypeIdDataGridViewTextBoxColumn
            // 
            this.eventTypeIdDataGridViewTextBoxColumn.DataPropertyName = "EventTypeId";
            this.eventTypeIdDataGridViewTextBoxColumn.HeaderText = "EventTypeId";
            this.eventTypeIdDataGridViewTextBoxColumn.Name = "eventTypeIdDataGridViewTextBoxColumn";
            // 
            // eventLogManualTimeDataGridViewTextBoxColumn
            // 
            this.eventLogManualTimeDataGridViewTextBoxColumn.DataPropertyName = "EventLogManualTime";
            this.eventLogManualTimeDataGridViewTextBoxColumn.HeaderText = "EventLogManualTime";
            this.eventLogManualTimeDataGridViewTextBoxColumn.Name = "eventLogManualTimeDataGridViewTextBoxColumn";
            // 
            // customerIdDataGridViewTextBoxColumn
            // 
            this.customerIdDataGridViewTextBoxColumn.DataPropertyName = "CustomerId";
            this.customerIdDataGridViewTextBoxColumn.HeaderText = "CustomerId";
            this.customerIdDataGridViewTextBoxColumn.Name = "customerIdDataGridViewTextBoxColumn";
            // 
            // testBedIdDataGridViewTextBoxColumn
            // 
            this.testBedIdDataGridViewTextBoxColumn.DataPropertyName = "TestBedId";
            this.testBedIdDataGridViewTextBoxColumn.HeaderText = "TestBedId";
            this.testBedIdDataGridViewTextBoxColumn.Name = "testBedIdDataGridViewTextBoxColumn";
            // 
            // testIdDataGridViewTextBoxColumn
            // 
            this.testIdDataGridViewTextBoxColumn.DataPropertyName = "TestId";
            this.testIdDataGridViewTextBoxColumn.HeaderText = "TestId";
            this.testIdDataGridViewTextBoxColumn.Name = "testIdDataGridViewTextBoxColumn";
            // 
            // testObjectIdDataGridViewTextBoxColumn
            // 
            this.testObjectIdDataGridViewTextBoxColumn.DataPropertyName = "TestObjectId";
            this.testObjectIdDataGridViewTextBoxColumn.HeaderText = "TestObjectId";
            this.testObjectIdDataGridViewTextBoxColumn.Name = "testObjectIdDataGridViewTextBoxColumn";
            // 
            // deviceIdDataGridViewTextBoxColumn
            // 
            this.deviceIdDataGridViewTextBoxColumn.DataPropertyName = "DeviceId";
            this.deviceIdDataGridViewTextBoxColumn.HeaderText = "DeviceId";
            this.deviceIdDataGridViewTextBoxColumn.Name = "deviceIdDataGridViewTextBoxColumn";
            // 
            // userObjectIdDataGridViewTextBoxColumn
            // 
            this.userObjectIdDataGridViewTextBoxColumn.DataPropertyName = "UserObjectId";
            this.userObjectIdDataGridViewTextBoxColumn.HeaderText = "UserObjectId";
            this.userObjectIdDataGridViewTextBoxColumn.Name = "userObjectIdDataGridViewTextBoxColumn";
            // 
            // itemIdDataGridViewTextBoxColumn
            // 
            this.itemIdDataGridViewTextBoxColumn.DataPropertyName = "ItemId";
            this.itemIdDataGridViewTextBoxColumn.HeaderText = "ItemId";
            this.itemIdDataGridViewTextBoxColumn.Name = "itemIdDataGridViewTextBoxColumn";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 551);
            this.Controls.Add(this.tbTestBed);
            this.Name = "frmMain";
            this.Text = "Report Tool";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tbTestBed.ResumeLayout(false);
            this.testBedTB.ResumeLayout(false);
            this.testBedTB.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEventLogs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventLogBindingSource)).EndInit();
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
        private System.Windows.Forms.ListBox lstEventLog;
        private System.Windows.Forms.Button btnFindEvent;
        private System.Windows.Forms.DateTimePicker dateTimePickerEventDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxTestBed;
        private System.Windows.Forms.Button btnRegisterEvent;
        private System.Windows.Forms.DataGridView dataGridViewEventLogs;
        private System.Windows.Forms.BindingSource eventLogBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventTypeDescriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn EventTypeReason;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventLogIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventLogTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventLogUserIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventTypeIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventLogManualTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn testBedIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn testIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn testObjectIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deviceIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userObjectIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemIdDataGridViewTextBoxColumn;
    }
}

