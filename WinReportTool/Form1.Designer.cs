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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.lstTestBed = new System.Windows.Forms.ListBox();
            this.btnAddTestbed = new System.Windows.Forms.Button();
            this.txtTestBed = new System.Windows.Forms.TextBox();
            this.tbTestBed = new System.Windows.Forms.TabControl();
            this.tabPageRegisterEvent = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxTotalTime = new System.Windows.Forms.TextBox();
            this.dataGridViewEventLogs = new System.Windows.Forms.DataGridView();
            this.EventTypeSubDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EventTypeDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventLogIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventLogTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventLogUserIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventTypeIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventLogManualTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.testBedIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboTestId = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.deviceIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EventValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Deleted = new System.Windows.Forms.DataGridViewButtonColumn();
            this.eventLogBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxTestBed = new System.Windows.Forms.ComboBox();
            this.buttonRegisterEvent = new System.Windows.Forms.Button();
            this.buttonFindEvent = new System.Windows.Forms.Button();
            this.dateTimePickerEventDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonAddEvent = new System.Windows.Forms.Button();
            this.treeViewAddEventToLog = new System.Windows.Forms.TreeView();
            this.tabPageTestBed = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.btnDeleteTestBed = new System.Windows.Forms.Button();
            this.tabPageDevice = new System.Windows.Forms.TabPage();
            this.buttonDeleteDevice = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAddDevice = new System.Windows.Forms.Button();
            this.txtDevice = new System.Windows.Forms.TextBox();
            this.lstDevice = new System.Windows.Forms.ListBox();
            this.tabPageEventType = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonDeleteEventType = new System.Windows.Forms.Button();
            this.btnAddEventType = new System.Windows.Forms.Button();
            this.txtEventType = new System.Windows.Forms.TextBox();
            this.trEventTypes = new System.Windows.Forms.TreeView();
            this.tabPageTest = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxTestBedTests = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonDeleteTest = new System.Windows.Forms.Button();
            this.listBoxTest = new System.Windows.Forms.ListBox();
            this.textBoxTestName = new System.Windows.Forms.TextBox();
            this.buttonAddTest = new System.Windows.Forms.Button();
            this.tabPageTestObject = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.buttonDeleteTestObject = new System.Windows.Forms.Button();
            this.listBoxTestObject = new System.Windows.Forms.ListBox();
            this.textBoxTestObjectName = new System.Windows.Forms.TextBox();
            this.buttonAddTestObject = new System.Windows.Forms.Button();
            this.tbTestBed.SuspendLayout();
            this.tabPageRegisterEvent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEventLogs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventLogBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPageTestBed.SuspendLayout();
            this.tabPageDevice.SuspendLayout();
            this.tabPageEventType.SuspendLayout();
            this.tabPageTest.SuspendLayout();
            this.tabPageTestObject.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstTestBed
            // 
            this.lstTestBed.FormattingEnabled = true;
            this.lstTestBed.Location = new System.Drawing.Point(20, 41);
            this.lstTestBed.Name = "lstTestBed";
            this.lstTestBed.Size = new System.Drawing.Size(265, 407);
            this.lstTestBed.TabIndex = 1;
            this.lstTestBed.Click += new System.EventHandler(this.lstTestBed_Click);
            // 
            // btnAddTestbed
            // 
            this.btnAddTestbed.Location = new System.Drawing.Point(291, 12);
            this.btnAddTestbed.Name = "btnAddTestbed";
            this.btnAddTestbed.Size = new System.Drawing.Size(80, 23);
            this.btnAddTestbed.TabIndex = 2;
            this.btnAddTestbed.Text = "Add";
            this.btnAddTestbed.UseVisualStyleBackColor = true;
            this.btnAddTestbed.Click += new System.EventHandler(this.btnAddTestbed_Click);
            // 
            // txtTestBed
            // 
            this.txtTestBed.Location = new System.Drawing.Point(117, 14);
            this.txtTestBed.Name = "txtTestBed";
            this.txtTestBed.Size = new System.Drawing.Size(168, 20);
            this.txtTestBed.TabIndex = 4;
            // 
            // tbTestBed
            // 
            this.tbTestBed.Controls.Add(this.tabPageRegisterEvent);
            this.tbTestBed.Controls.Add(this.tabPageTestBed);
            this.tbTestBed.Controls.Add(this.tabPageTest);
            this.tbTestBed.Controls.Add(this.tabPageTestObject);
            this.tbTestBed.Controls.Add(this.tabPageDevice);
            this.tbTestBed.Controls.Add(this.tabPageEventType);
            this.tbTestBed.Location = new System.Drawing.Point(12, 12);
            this.tbTestBed.Name = "tbTestBed";
            this.tbTestBed.SelectedIndex = 0;
            this.tbTestBed.Size = new System.Drawing.Size(844, 537);
            this.tbTestBed.TabIndex = 8;
            // 
            // tabPageRegisterEvent
            // 
            this.tabPageRegisterEvent.Controls.Add(this.label3);
            this.tabPageRegisterEvent.Controls.Add(this.textBoxTotalTime);
            this.tabPageRegisterEvent.Controls.Add(this.dataGridViewEventLogs);
            this.tabPageRegisterEvent.Controls.Add(this.label2);
            this.tabPageRegisterEvent.Controls.Add(this.label1);
            this.tabPageRegisterEvent.Controls.Add(this.comboBoxTestBed);
            this.tabPageRegisterEvent.Controls.Add(this.buttonRegisterEvent);
            this.tabPageRegisterEvent.Controls.Add(this.buttonFindEvent);
            this.tabPageRegisterEvent.Controls.Add(this.dateTimePickerEventDate);
            this.tabPageRegisterEvent.Controls.Add(this.groupBox1);
            this.tabPageRegisterEvent.Location = new System.Drawing.Point(4, 22);
            this.tabPageRegisterEvent.Name = "tabPageRegisterEvent";
            this.tabPageRegisterEvent.Size = new System.Drawing.Size(836, 511);
            this.tabPageRegisterEvent.TabIndex = 3;
            this.tabPageRegisterEvent.Text = "Register events";
            this.tabPageRegisterEvent.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(555, 459);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Total Time (min):";
            // 
            // textBoxTotalTime
            // 
            this.textBoxTotalTime.Location = new System.Drawing.Point(653, 456);
            this.textBoxTotalTime.Name = "textBoxTotalTime";
            this.textBoxTotalTime.ReadOnly = true;
            this.textBoxTotalTime.Size = new System.Drawing.Size(68, 20);
            this.textBoxTotalTime.TabIndex = 17;
            this.textBoxTotalTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxTotalTime.TextChanged += new System.EventHandler(this.textBoxTotalTime_TextChanged);
            // 
            // dataGridViewEventLogs
            // 
            this.dataGridViewEventLogs.AllowUserToAddRows = false;
            this.dataGridViewEventLogs.AutoGenerateColumns = false;
            this.dataGridViewEventLogs.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewEventLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEventLogs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EventTypeSubDescription,
            this.EventTypeDescription,
            this.eventLogIdDataGridViewTextBoxColumn,
            this.eventLogTimeDataGridViewTextBoxColumn,
            this.eventLogUserIdDataGridViewTextBoxColumn,
            this.eventTypeIdDataGridViewTextBoxColumn,
            this.eventLogManualTimeDataGridViewTextBoxColumn,
            this.testBedIdDataGridViewTextBoxColumn,
            this.comboTestId,
            this.deviceIdDataGridViewTextBoxColumn,
            this.EventValue,
            this.Deleted});
            this.dataGridViewEventLogs.DataSource = this.eventLogBindingSource;
            this.dataGridViewEventLogs.Location = new System.Drawing.Point(253, 93);
            this.dataGridViewEventLogs.Name = "dataGridViewEventLogs";
            this.dataGridViewEventLogs.Size = new System.Drawing.Size(558, 352);
            this.dataGridViewEventLogs.TabIndex = 15;
            this.dataGridViewEventLogs.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewEventLogs_CellContentClick);
            this.dataGridViewEventLogs.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewEventLogs_CellValidated);
            this.dataGridViewEventLogs.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewEventLogs_DataError);
            // 
            // EventTypeSubDescription
            // 
            this.EventTypeSubDescription.DataPropertyName = "EventTypeSubDescription";
            this.EventTypeSubDescription.HeaderText = "Event";
            this.EventTypeSubDescription.Name = "EventTypeSubDescription";
            this.EventTypeSubDescription.ReadOnly = true;
            this.EventTypeSubDescription.Width = 120;
            // 
            // EventTypeDescription
            // 
            this.EventTypeDescription.DataPropertyName = "EventTypeDescription";
            this.EventTypeDescription.HeaderText = "Reason";
            this.EventTypeDescription.Name = "EventTypeDescription";
            this.EventTypeDescription.ReadOnly = true;
            this.EventTypeDescription.Width = 120;
            // 
            // eventLogIdDataGridViewTextBoxColumn
            // 
            this.eventLogIdDataGridViewTextBoxColumn.DataPropertyName = "EventLogId";
            this.eventLogIdDataGridViewTextBoxColumn.HeaderText = "EventLogId";
            this.eventLogIdDataGridViewTextBoxColumn.Name = "eventLogIdDataGridViewTextBoxColumn";
            this.eventLogIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // eventLogTimeDataGridViewTextBoxColumn
            // 
            this.eventLogTimeDataGridViewTextBoxColumn.DataPropertyName = "EventLogTime";
            this.eventLogTimeDataGridViewTextBoxColumn.HeaderText = "EventLogTime";
            this.eventLogTimeDataGridViewTextBoxColumn.Name = "eventLogTimeDataGridViewTextBoxColumn";
            this.eventLogTimeDataGridViewTextBoxColumn.Visible = false;
            // 
            // eventLogUserIdDataGridViewTextBoxColumn
            // 
            this.eventLogUserIdDataGridViewTextBoxColumn.DataPropertyName = "EventLogUserId";
            this.eventLogUserIdDataGridViewTextBoxColumn.HeaderText = "EventLogUserId";
            this.eventLogUserIdDataGridViewTextBoxColumn.Name = "eventLogUserIdDataGridViewTextBoxColumn";
            this.eventLogUserIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // eventTypeIdDataGridViewTextBoxColumn
            // 
            this.eventTypeIdDataGridViewTextBoxColumn.DataPropertyName = "EventTypeId";
            this.eventTypeIdDataGridViewTextBoxColumn.HeaderText = "EventTypeId";
            this.eventTypeIdDataGridViewTextBoxColumn.Name = "eventTypeIdDataGridViewTextBoxColumn";
            this.eventTypeIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // eventLogManualTimeDataGridViewTextBoxColumn
            // 
            this.eventLogManualTimeDataGridViewTextBoxColumn.DataPropertyName = "EventLogManualTime";
            this.eventLogManualTimeDataGridViewTextBoxColumn.HeaderText = "EventLogManualTime";
            this.eventLogManualTimeDataGridViewTextBoxColumn.Name = "eventLogManualTimeDataGridViewTextBoxColumn";
            this.eventLogManualTimeDataGridViewTextBoxColumn.Visible = false;
            // 
            // testBedIdDataGridViewTextBoxColumn
            // 
            this.testBedIdDataGridViewTextBoxColumn.DataPropertyName = "TestBedId";
            this.testBedIdDataGridViewTextBoxColumn.HeaderText = "TestBedId";
            this.testBedIdDataGridViewTextBoxColumn.Name = "testBedIdDataGridViewTextBoxColumn";
            this.testBedIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // comboTestId
            // 
            this.comboTestId.DataPropertyName = "TestId";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboTestId.DefaultCellStyle = dataGridViewCellStyle1;
            this.comboTestId.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboTestId.HeaderText = "Test";
            this.comboTestId.Name = "comboTestId";
            this.comboTestId.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.comboTestId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.comboTestId.Width = 130;
            // 
            // deviceIdDataGridViewTextBoxColumn
            // 
            this.deviceIdDataGridViewTextBoxColumn.DataPropertyName = "DeviceId";
            this.deviceIdDataGridViewTextBoxColumn.HeaderText = "DeviceId";
            this.deviceIdDataGridViewTextBoxColumn.Name = "deviceIdDataGridViewTextBoxColumn";
            this.deviceIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // EventValue
            // 
            this.EventValue.DataPropertyName = "EventValue";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.EventValue.DefaultCellStyle = dataGridViewCellStyle2;
            this.EventValue.HeaderText = "Time (min)";
            this.EventValue.MaxInputLength = 5;
            this.EventValue.Name = "EventValue";
            this.EventValue.Width = 80;
            // 
            // Deleted
            // 
            this.Deleted.DataPropertyName = "Deleted";
            this.Deleted.FillWeight = 90F;
            this.Deleted.HeaderText = "Delete";
            this.Deleted.Name = "Deleted";
            this.Deleted.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Deleted.Text = "Delete";
            this.Deleted.ToolTipText = "Delete event";
            this.Deleted.UseColumnTextForButtonValue = true;
            this.Deleted.Width = 45;
            // 
            // eventLogBindingSource
            // 
            this.eventLogBindingSource.DataSource = typeof(ReportDao.Model.Bridge.EventLog);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "EventDate";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "TestBed";
            // 
            // comboBoxTestBed
            // 
            this.comboBoxTestBed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTestBed.FormattingEnabled = true;
            this.comboBoxTestBed.Location = new System.Drawing.Point(83, 12);
            this.comboBoxTestBed.Name = "comboBoxTestBed";
            this.comboBoxTestBed.Size = new System.Drawing.Size(155, 21);
            this.comboBoxTestBed.TabIndex = 12;
            this.comboBoxTestBed.SelectedIndexChanged += new System.EventHandler(this.comboBoxTestBed_SelectedIndexChanged);
            // 
            // buttonRegisterEvent
            // 
            this.buttonRegisterEvent.Location = new System.Drawing.Point(727, 454);
            this.buttonRegisterEvent.Name = "buttonRegisterEvent";
            this.buttonRegisterEvent.Size = new System.Drawing.Size(85, 23);
            this.buttonRegisterEvent.TabIndex = 11;
            this.buttonRegisterEvent.Text = "Save";
            this.buttonRegisterEvent.UseVisualStyleBackColor = true;
            this.buttonRegisterEvent.Click += new System.EventHandler(this.buttonRegisterEvent_Click);
            // 
            // buttonFindEvent
            // 
            this.buttonFindEvent.Location = new System.Drawing.Point(294, 35);
            this.buttonFindEvent.Name = "buttonFindEvent";
            this.buttonFindEvent.Size = new System.Drawing.Size(80, 23);
            this.buttonFindEvent.TabIndex = 11;
            this.buttonFindEvent.Text = "Find";
            this.buttonFindEvent.UseVisualStyleBackColor = true;
            this.buttonFindEvent.Visible = false;
            this.buttonFindEvent.Click += new System.EventHandler(this.buttonFindEvent_Click);
            // 
            // dateTimePickerEventDate
            // 
            this.dateTimePickerEventDate.CustomFormat = "";
            this.dateTimePickerEventDate.Location = new System.Drawing.Point(83, 38);
            this.dateTimePickerEventDate.Name = "dateTimePickerEventDate";
            this.dateTimePickerEventDate.Size = new System.Drawing.Size(155, 20);
            this.dateTimePickerEventDate.TabIndex = 10;
            this.dateTimePickerEventDate.Value = new System.DateTime(2018, 10, 11, 0, 0, 0, 0);
            this.dateTimePickerEventDate.ValueChanged += new System.EventHandler(this.dateTimePickerEventDate_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonAddEvent);
            this.groupBox1.Controls.Add(this.treeViewAddEventToLog);
            this.groupBox1.Location = new System.Drawing.Point(3, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(242, 413);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add event to log";
            // 
            // buttonAddEvent
            // 
            this.buttonAddEvent.Enabled = false;
            this.buttonAddEvent.Location = new System.Drawing.Point(140, 379);
            this.buttonAddEvent.Name = "buttonAddEvent";
            this.buttonAddEvent.Size = new System.Drawing.Size(85, 23);
            this.buttonAddEvent.TabIndex = 19;
            this.buttonAddEvent.Text = "Add";
            this.buttonAddEvent.UseVisualStyleBackColor = true;
            this.buttonAddEvent.Click += new System.EventHandler(this.buttonAddEvent_Click);
            // 
            // treeViewAddEventToLog
            // 
            this.treeViewAddEventToLog.BackColor = System.Drawing.SystemColors.Window;
            this.treeViewAddEventToLog.Location = new System.Drawing.Point(20, 19);
            this.treeViewAddEventToLog.Name = "treeViewAddEventToLog";
            this.treeViewAddEventToLog.Size = new System.Drawing.Size(204, 352);
            this.treeViewAddEventToLog.TabIndex = 19;
            this.treeViewAddEventToLog.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeViewAddEventToLog_BeforeSelect);
            this.treeViewAddEventToLog.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewAddEventToLog_AfterSelect);
            // 
            // tabPageTestBed
            // 
            this.tabPageTestBed.Controls.Add(this.label6);
            this.tabPageTestBed.Controls.Add(this.btnDeleteTestBed);
            this.tabPageTestBed.Controls.Add(this.lstTestBed);
            this.tabPageTestBed.Controls.Add(this.txtTestBed);
            this.tabPageTestBed.Controls.Add(this.btnAddTestbed);
            this.tabPageTestBed.Location = new System.Drawing.Point(4, 22);
            this.tabPageTestBed.Name = "tabPageTestBed";
            this.tabPageTestBed.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTestBed.Size = new System.Drawing.Size(836, 511);
            this.tabPageTestBed.TabIndex = 0;
            this.tabPageTestBed.Text = "TestBeds";
            this.tabPageTestBed.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "TestBed name:";
            // 
            // btnDeleteTestBed
            // 
            this.btnDeleteTestBed.Location = new System.Drawing.Point(205, 454);
            this.btnDeleteTestBed.Name = "btnDeleteTestBed";
            this.btnDeleteTestBed.Size = new System.Drawing.Size(80, 23);
            this.btnDeleteTestBed.TabIndex = 5;
            this.btnDeleteTestBed.Text = "Delete";
            this.btnDeleteTestBed.UseVisualStyleBackColor = true;
            this.btnDeleteTestBed.Click += new System.EventHandler(this.btnDeleteTestBed_Click);
            // 
            // tabPageDevice
            // 
            this.tabPageDevice.Controls.Add(this.buttonDeleteDevice);
            this.tabPageDevice.Controls.Add(this.label5);
            this.tabPageDevice.Controls.Add(this.btnAddDevice);
            this.tabPageDevice.Controls.Add(this.txtDevice);
            this.tabPageDevice.Controls.Add(this.lstDevice);
            this.tabPageDevice.Location = new System.Drawing.Point(4, 22);
            this.tabPageDevice.Name = "tabPageDevice";
            this.tabPageDevice.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDevice.Size = new System.Drawing.Size(836, 511);
            this.tabPageDevice.TabIndex = 1;
            this.tabPageDevice.Text = "Devices";
            this.tabPageDevice.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteDevice
            // 
            this.buttonDeleteDevice.Location = new System.Drawing.Point(205, 454);
            this.buttonDeleteDevice.Name = "buttonDeleteDevice";
            this.buttonDeleteDevice.Size = new System.Drawing.Size(80, 23);
            this.buttonDeleteDevice.TabIndex = 12;
            this.buttonDeleteDevice.Text = "Delete";
            this.buttonDeleteDevice.UseVisualStyleBackColor = true;
            this.buttonDeleteDevice.Click += new System.EventHandler(this.buttonDeleteDevice_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Device name:";
            // 
            // btnAddDevice
            // 
            this.btnAddDevice.Location = new System.Drawing.Point(291, 12);
            this.btnAddDevice.Name = "btnAddDevice";
            this.btnAddDevice.Size = new System.Drawing.Size(80, 23);
            this.btnAddDevice.TabIndex = 10;
            this.btnAddDevice.Text = "Add";
            this.btnAddDevice.UseVisualStyleBackColor = true;
            this.btnAddDevice.Click += new System.EventHandler(this.btnAddDevice_Click);
            // 
            // txtDevice
            // 
            this.txtDevice.Location = new System.Drawing.Point(117, 14);
            this.txtDevice.Name = "txtDevice";
            this.txtDevice.Size = new System.Drawing.Size(168, 20);
            this.txtDevice.TabIndex = 9;
            // 
            // lstDevice
            // 
            this.lstDevice.FormattingEnabled = true;
            this.lstDevice.Location = new System.Drawing.Point(20, 41);
            this.lstDevice.Name = "lstDevice";
            this.lstDevice.Size = new System.Drawing.Size(265, 407);
            this.lstDevice.TabIndex = 8;
            this.lstDevice.Click += new System.EventHandler(this.lstDevice_Click);
            // 
            // tabPageEventType
            // 
            this.tabPageEventType.Controls.Add(this.label4);
            this.tabPageEventType.Controls.Add(this.buttonDeleteEventType);
            this.tabPageEventType.Controls.Add(this.btnAddEventType);
            this.tabPageEventType.Controls.Add(this.txtEventType);
            this.tabPageEventType.Controls.Add(this.trEventTypes);
            this.tabPageEventType.Location = new System.Drawing.Point(4, 22);
            this.tabPageEventType.Name = "tabPageEventType";
            this.tabPageEventType.Size = new System.Drawing.Size(836, 511);
            this.tabPageEventType.TabIndex = 2;
            this.tabPageEventType.Text = "EventTypes";
            this.tabPageEventType.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "EventType name:";
            // 
            // buttonDeleteEventType
            // 
            this.buttonDeleteEventType.Location = new System.Drawing.Point(206, 461);
            this.buttonDeleteEventType.Name = "buttonDeleteEventType";
            this.buttonDeleteEventType.Size = new System.Drawing.Size(80, 23);
            this.buttonDeleteEventType.TabIndex = 3;
            this.buttonDeleteEventType.Text = "Delete";
            this.buttonDeleteEventType.UseVisualStyleBackColor = true;
            this.buttonDeleteEventType.Click += new System.EventHandler(this.buttonDeleteEventType_Click);
            // 
            // btnAddEventType
            // 
            this.btnAddEventType.Location = new System.Drawing.Point(292, 12);
            this.btnAddEventType.Name = "btnAddEventType";
            this.btnAddEventType.Size = new System.Drawing.Size(80, 23);
            this.btnAddEventType.TabIndex = 2;
            this.btnAddEventType.Text = "Add";
            this.btnAddEventType.UseVisualStyleBackColor = true;
            this.btnAddEventType.Click += new System.EventHandler(this.btnAddEventType_Click);
            // 
            // txtEventType
            // 
            this.txtEventType.Location = new System.Drawing.Point(118, 14);
            this.txtEventType.Name = "txtEventType";
            this.txtEventType.Size = new System.Drawing.Size(168, 20);
            this.txtEventType.TabIndex = 1;
            // 
            // trEventTypes
            // 
            this.trEventTypes.BackColor = System.Drawing.SystemColors.Window;
            this.trEventTypes.Location = new System.Drawing.Point(20, 41);
            this.trEventTypes.Name = "trEventTypes";
            this.trEventTypes.Size = new System.Drawing.Size(265, 415);
            this.trEventTypes.TabIndex = 0;
            this.trEventTypes.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.trEventTypes_BeforeSelect);
            this.trEventTypes.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trEventTypes_AfterSelect);
            this.trEventTypes.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trEventTypes_MouseDown);
            // 
            // tabPageTest
            // 
            this.tabPageTest.Controls.Add(this.label8);
            this.tabPageTest.Controls.Add(this.buttonDeleteTest);
            this.tabPageTest.Controls.Add(this.listBoxTest);
            this.tabPageTest.Controls.Add(this.textBoxTestName);
            this.tabPageTest.Controls.Add(this.buttonAddTest);
            this.tabPageTest.Controls.Add(this.label7);
            this.tabPageTest.Controls.Add(this.comboBoxTestBedTests);
            this.tabPageTest.Location = new System.Drawing.Point(4, 22);
            this.tabPageTest.Name = "tabPageTest";
            this.tabPageTest.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTest.Size = new System.Drawing.Size(836, 511);
            this.tabPageTest.TabIndex = 4;
            this.tabPageTest.Text = "Tests";
            this.tabPageTest.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "TestBed";
            // 
            // comboBoxTestBedTests
            // 
            this.comboBoxTestBedTests.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTestBedTests.FormattingEnabled = true;
            this.comboBoxTestBedTests.Location = new System.Drawing.Point(117, 15);
            this.comboBoxTestBedTests.Name = "comboBoxTestBedTests";
            this.comboBoxTestBedTests.Size = new System.Drawing.Size(168, 21);
            this.comboBoxTestBedTests.TabIndex = 14;
            this.comboBoxTestBedTests.SelectedIndexChanged += new System.EventHandler(this.comboBoxTestBedTests_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Test name:";
            // 
            // buttonDeleteTest
            // 
            this.buttonDeleteTest.Location = new System.Drawing.Point(205, 454);
            this.buttonDeleteTest.Name = "buttonDeleteTest";
            this.buttonDeleteTest.Size = new System.Drawing.Size(80, 23);
            this.buttonDeleteTest.TabIndex = 19;
            this.buttonDeleteTest.Text = "Delete";
            this.buttonDeleteTest.UseVisualStyleBackColor = true;
            this.buttonDeleteTest.Click += new System.EventHandler(this.buttonDeleteTest_Click);
            // 
            // listBoxTest
            // 
            this.listBoxTest.FormattingEnabled = true;
            this.listBoxTest.Location = new System.Drawing.Point(20, 67);
            this.listBoxTest.Name = "listBoxTest";
            this.listBoxTest.Size = new System.Drawing.Size(265, 381);
            this.listBoxTest.TabIndex = 16;
            this.listBoxTest.Click += new System.EventHandler(this.listBoxTest_Click);
            // 
            // textBoxTestName
            // 
            this.textBoxTestName.Location = new System.Drawing.Point(117, 42);
            this.textBoxTestName.Name = "textBoxTestName";
            this.textBoxTestName.Size = new System.Drawing.Size(168, 20);
            this.textBoxTestName.TabIndex = 18;
            // 
            // buttonAddTest
            // 
            this.buttonAddTest.Location = new System.Drawing.Point(291, 40);
            this.buttonAddTest.Name = "buttonAddTest";
            this.buttonAddTest.Size = new System.Drawing.Size(80, 23);
            this.buttonAddTest.TabIndex = 17;
            this.buttonAddTest.Text = "Add";
            this.buttonAddTest.UseVisualStyleBackColor = true;
            this.buttonAddTest.Click += new System.EventHandler(this.buttonAddTest_Click);
            // 
            // tabPageTestObject
            // 
            this.tabPageTestObject.Controls.Add(this.label9);
            this.tabPageTestObject.Controls.Add(this.buttonDeleteTestObject);
            this.tabPageTestObject.Controls.Add(this.listBoxTestObject);
            this.tabPageTestObject.Controls.Add(this.textBoxTestObjectName);
            this.tabPageTestObject.Controls.Add(this.buttonAddTestObject);
            this.tabPageTestObject.Location = new System.Drawing.Point(4, 22);
            this.tabPageTestObject.Name = "tabPageTestObject";
            this.tabPageTestObject.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTestObject.Size = new System.Drawing.Size(836, 511);
            this.tabPageTestObject.TabIndex = 5;
            this.tabPageTestObject.Text = "TestObjects";
            this.tabPageTestObject.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "TestObject name:";
            // 
            // buttonDeleteTestObject
            // 
            this.buttonDeleteTestObject.Location = new System.Drawing.Point(205, 454);
            this.buttonDeleteTestObject.Name = "buttonDeleteTestObject";
            this.buttonDeleteTestObject.Size = new System.Drawing.Size(80, 23);
            this.buttonDeleteTestObject.TabIndex = 16;
            this.buttonDeleteTestObject.Text = "Delete";
            this.buttonDeleteTestObject.UseVisualStyleBackColor = true;
            this.buttonDeleteTestObject.Click += new System.EventHandler(this.buttonDeleteTestObject_Click);
            // 
            // listBoxTestObject
            // 
            this.listBoxTestObject.FormattingEnabled = true;
            this.listBoxTestObject.Location = new System.Drawing.Point(20, 41);
            this.listBoxTestObject.Name = "listBoxTestObject";
            this.listBoxTestObject.Size = new System.Drawing.Size(265, 407);
            this.listBoxTestObject.TabIndex = 13;
            this.listBoxTestObject.Click += new System.EventHandler(this.listBoxTestObject_Click);
            // 
            // textBoxTestObjectName
            // 
            this.textBoxTestObjectName.Location = new System.Drawing.Point(117, 14);
            this.textBoxTestObjectName.Name = "textBoxTestObjectName";
            this.textBoxTestObjectName.Size = new System.Drawing.Size(168, 20);
            this.textBoxTestObjectName.TabIndex = 15;
            // 
            // buttonAddTestObject
            // 
            this.buttonAddTestObject.Location = new System.Drawing.Point(291, 12);
            this.buttonAddTestObject.Name = "buttonAddTestObject";
            this.buttonAddTestObject.Size = new System.Drawing.Size(80, 23);
            this.buttonAddTestObject.TabIndex = 14;
            this.buttonAddTestObject.Text = "Add";
            this.buttonAddTestObject.UseVisualStyleBackColor = true;
            this.buttonAddTestObject.Click += new System.EventHandler(this.buttonAddTestObject_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 559);
            this.Controls.Add(this.tbTestBed);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "Report Tool";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tbTestBed.ResumeLayout(false);
            this.tabPageRegisterEvent.ResumeLayout(false);
            this.tabPageRegisterEvent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEventLogs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventLogBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tabPageTestBed.ResumeLayout(false);
            this.tabPageTestBed.PerformLayout();
            this.tabPageDevice.ResumeLayout(false);
            this.tabPageDevice.PerformLayout();
            this.tabPageEventType.ResumeLayout(false);
            this.tabPageEventType.PerformLayout();
            this.tabPageTest.ResumeLayout(false);
            this.tabPageTest.PerformLayout();
            this.tabPageTestObject.ResumeLayout(false);
            this.tabPageTestObject.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox lstTestBed;
        private System.Windows.Forms.Button btnAddTestbed;
        private System.Windows.Forms.TextBox txtTestBed;
        private System.Windows.Forms.TabControl tbTestBed;
        private System.Windows.Forms.TabPage tabPageTestBed;
        private System.Windows.Forms.TabPage tabPageDevice;
        private System.Windows.Forms.Button btnAddDevice;
        private System.Windows.Forms.TextBox txtDevice;
        private System.Windows.Forms.ListBox lstDevice;
        private System.Windows.Forms.TabPage tabPageEventType;
        private System.Windows.Forms.TreeView trEventTypes;
        private System.Windows.Forms.Button btnAddEventType;
        private System.Windows.Forms.TextBox txtEventType;
        private System.Windows.Forms.TabPage tabPageRegisterEvent;
        private System.Windows.Forms.Button btnDeleteTestBed;
        private System.Windows.Forms.Button buttonFindEvent;
        private System.Windows.Forms.DateTimePicker dateTimePickerEventDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxTestBed;
        private System.Windows.Forms.Button buttonRegisterEvent;
        private System.Windows.Forms.DataGridView dataGridViewEventLogs;
        private System.Windows.Forms.BindingSource eventLogBindingSource;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxTotalTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonDeleteDevice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonDeleteEventType;
        private System.Windows.Forms.DataGridViewTextBoxColumn EventTypeSubDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn EventTypeDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventLogIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventLogTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventLogUserIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventTypeIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventLogManualTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn testBedIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn comboTestId;
        private System.Windows.Forms.DataGridViewTextBoxColumn deviceIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EventValue;
        private System.Windows.Forms.DataGridViewButtonColumn Deleted;
        private System.Windows.Forms.TreeView treeViewAddEventToLog;
        private System.Windows.Forms.Button buttonAddEvent;
        private System.Windows.Forms.TabPage tabPageTest;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonDeleteTest;
        private System.Windows.Forms.ListBox listBoxTest;
        private System.Windows.Forms.TextBox textBoxTestName;
        private System.Windows.Forms.Button buttonAddTest;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxTestBedTests;
        private System.Windows.Forms.TabPage tabPageTestObject;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buttonDeleteTestObject;
        private System.Windows.Forms.ListBox listBoxTestObject;
        private System.Windows.Forms.TextBox textBoxTestObjectName;
        private System.Windows.Forms.Button buttonAddTestObject;
    }
}

