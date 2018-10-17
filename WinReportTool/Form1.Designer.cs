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
            this.dataGridViewEventLogs = new System.Windows.Forms.DataGridView();
            this.eventLogBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxTestBed = new System.Windows.Forms.ComboBox();
            this.btnSaveEvent = new System.Windows.Forms.Button();
            this.btnFindEvent = new System.Windows.Forms.Button();
            this.dateTimePickerEventDate = new System.Windows.Forms.DateTimePicker();
            this.buttonAddNoActivityEvent = new System.Windows.Forms.Button();
            this.buttonAddPlannedMaintEvent = new System.Windows.Forms.Button();
            this.buttonAddRigStopEvent = new System.Windows.Forms.Button();
            this.buttonAddLPEvent = new System.Windows.Forms.Button();
            this.buttonAddFPEvent = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxFpActivity = new System.Windows.Forms.ComboBox();
            this.comboBoxLpActivity = new System.Windows.Forms.ComboBox();
            this.comboBoxRigStop = new System.Windows.Forms.ComboBox();
            this.comboBoxPlannedMaintenance = new System.Windows.Forms.ComboBox();
            this.comboBoxNoActivity = new System.Windows.Forms.ComboBox();
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
            this.tbTestBed.SuspendLayout();
            this.testBedTB.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEventLogs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventLogBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            this.tabPage3.Controls.Add(this.btnSaveEvent);
            this.tabPage3.Controls.Add(this.btnFindEvent);
            this.tabPage3.Controls.Add(this.dateTimePickerEventDate);
            this.tabPage3.Controls.Add(this.buttonAddNoActivityEvent);
            this.tabPage3.Controls.Add(this.buttonAddPlannedMaintEvent);
            this.tabPage3.Controls.Add(this.buttonAddRigStopEvent);
            this.tabPage3.Controls.Add(this.buttonAddLPEvent);
            this.tabPage3.Controls.Add(this.buttonAddFPEvent);
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(836, 511);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "Register events";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridViewEventLogs
            // 
            this.dataGridViewEventLogs.AllowUserToAddRows = false;
            this.dataGridViewEventLogs.AutoGenerateColumns = false;
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
            this.dataGridViewEventLogs.Location = new System.Drawing.Point(253, 83);
            this.dataGridViewEventLogs.Name = "dataGridViewEventLogs";
            this.dataGridViewEventLogs.Size = new System.Drawing.Size(558, 291);
            this.dataGridViewEventLogs.TabIndex = 15;
            this.dataGridViewEventLogs.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewEventLogs_CellContentClick);
            // 
            // eventLogBindingSource
            // 
            this.eventLogBindingSource.DataSource = typeof(ReportDao.Model.Bridge.EventLog);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "TestBed";
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
            // btnSaveEvent
            // 
            this.btnSaveEvent.Location = new System.Drawing.Point(736, 392);
            this.btnSaveEvent.Name = "btnSaveEvent";
            this.btnSaveEvent.Size = new System.Drawing.Size(75, 23);
            this.btnSaveEvent.TabIndex = 11;
            this.btnSaveEvent.Text = "Save";
            this.btnSaveEvent.UseVisualStyleBackColor = true;
            this.btnSaveEvent.Click += new System.EventHandler(this.btnSaveEvent_Click);
            // 
            // btnFindEvent
            // 
            this.btnFindEvent.Location = new System.Drawing.Point(294, 35);
            this.btnFindEvent.Name = "btnFindEvent";
            this.btnFindEvent.Size = new System.Drawing.Size(75, 23);
            this.btnFindEvent.TabIndex = 11;
            this.btnFindEvent.Text = "Find";
            this.btnFindEvent.UseVisualStyleBackColor = true;
            this.btnFindEvent.Click += new System.EventHandler(this.btnFindEvent_Click);
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
            // buttonAddNoActivityEvent
            // 
            this.buttonAddNoActivityEvent.BackColor = System.Drawing.Color.Yellow;
            this.buttonAddNoActivityEvent.Location = new System.Drawing.Point(37, 301);
            this.buttonAddNoActivityEvent.Name = "buttonAddNoActivityEvent";
            this.buttonAddNoActivityEvent.Size = new System.Drawing.Size(93, 40);
            this.buttonAddNoActivityEvent.TabIndex = 4;
            this.buttonAddNoActivityEvent.Text = "NO ACTIVITY";
            this.buttonAddNoActivityEvent.UseVisualStyleBackColor = false;
            this.buttonAddNoActivityEvent.Click += new System.EventHandler(this.buttonAddNoActivityEvent_Click);
            // 
            // buttonAddPlannedMaintEvent
            // 
            this.buttonAddPlannedMaintEvent.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonAddPlannedMaintEvent.Location = new System.Drawing.Point(37, 255);
            this.buttonAddPlannedMaintEvent.Name = "buttonAddPlannedMaintEvent";
            this.buttonAddPlannedMaintEvent.Size = new System.Drawing.Size(93, 40);
            this.buttonAddPlannedMaintEvent.TabIndex = 3;
            this.buttonAddPlannedMaintEvent.Text = "PLANNED MAINTENANCE";
            this.buttonAddPlannedMaintEvent.UseVisualStyleBackColor = false;
            this.buttonAddPlannedMaintEvent.Click += new System.EventHandler(this.buttonAddPlannedMaintEvent_Click);
            // 
            // buttonAddRigStopEvent
            // 
            this.buttonAddRigStopEvent.BackColor = System.Drawing.Color.Red;
            this.buttonAddRigStopEvent.Location = new System.Drawing.Point(37, 209);
            this.buttonAddRigStopEvent.Name = "buttonAddRigStopEvent";
            this.buttonAddRigStopEvent.Size = new System.Drawing.Size(93, 40);
            this.buttonAddRigStopEvent.TabIndex = 2;
            this.buttonAddRigStopEvent.Text = "RIG STOP";
            this.buttonAddRigStopEvent.UseVisualStyleBackColor = false;
            this.buttonAddRigStopEvent.Click += new System.EventHandler(this.buttonAddRigStopEvent_Click);
            // 
            // buttonAddLPEvent
            // 
            this.buttonAddLPEvent.BackColor = System.Drawing.Color.ForestGreen;
            this.buttonAddLPEvent.Location = new System.Drawing.Point(38, 163);
            this.buttonAddLPEvent.Name = "buttonAddLPEvent";
            this.buttonAddLPEvent.Size = new System.Drawing.Size(93, 40);
            this.buttonAddLPEvent.TabIndex = 1;
            this.buttonAddLPEvent.Text = "LP ACTIVITY";
            this.buttonAddLPEvent.UseVisualStyleBackColor = false;
            this.buttonAddLPEvent.Click += new System.EventHandler(this.buttonAddLPEvent_Click);
            // 
            // buttonAddFPEvent
            // 
            this.buttonAddFPEvent.BackColor = System.Drawing.Color.ForestGreen;
            this.buttonAddFPEvent.Location = new System.Drawing.Point(38, 117);
            this.buttonAddFPEvent.Name = "buttonAddFPEvent";
            this.buttonAddFPEvent.Size = new System.Drawing.Size(93, 40);
            this.buttonAddFPEvent.TabIndex = 0;
            this.buttonAddFPEvent.Text = "FP ACTIVITY";
            this.buttonAddFPEvent.UseVisualStyleBackColor = false;
            this.buttonAddFPEvent.Click += new System.EventHandler(this.buttonAddFPEvent_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxNoActivity);
            this.groupBox1.Controls.Add(this.comboBoxPlannedMaintenance);
            this.groupBox1.Controls.Add(this.comboBoxRigStop);
            this.groupBox1.Controls.Add(this.comboBoxLpActivity);
            this.groupBox1.Controls.Add(this.comboBoxFpActivity);
            this.groupBox1.Location = new System.Drawing.Point(23, 78);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(222, 296);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add event";
            // 
            // comboBoxFpActivity
            // 
            this.comboBoxFpActivity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFpActivity.FormattingEnabled = true;
            this.comboBoxFpActivity.Location = new System.Drawing.Point(113, 50);
            this.comboBoxFpActivity.Name = "comboBoxFpActivity";
            this.comboBoxFpActivity.Size = new System.Drawing.Size(102, 21);
            this.comboBoxFpActivity.TabIndex = 17;
            // 
            // comboBoxLpActivity
            // 
            this.comboBoxLpActivity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLpActivity.FormattingEnabled = true;
            this.comboBoxLpActivity.Location = new System.Drawing.Point(114, 96);
            this.comboBoxLpActivity.Name = "comboBoxLpActivity";
            this.comboBoxLpActivity.Size = new System.Drawing.Size(102, 21);
            this.comboBoxLpActivity.TabIndex = 18;
            // 
            // comboBoxRigStop
            // 
            this.comboBoxRigStop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRigStop.FormattingEnabled = true;
            this.comboBoxRigStop.Location = new System.Drawing.Point(113, 142);
            this.comboBoxRigStop.Name = "comboBoxRigStop";
            this.comboBoxRigStop.Size = new System.Drawing.Size(102, 21);
            this.comboBoxRigStop.TabIndex = 18;
            // 
            // comboBoxPlannedMaintenance
            // 
            this.comboBoxPlannedMaintenance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlannedMaintenance.FormattingEnabled = true;
            this.comboBoxPlannedMaintenance.Location = new System.Drawing.Point(113, 188);
            this.comboBoxPlannedMaintenance.Name = "comboBoxPlannedMaintenance";
            this.comboBoxPlannedMaintenance.Size = new System.Drawing.Size(102, 21);
            this.comboBoxPlannedMaintenance.TabIndex = 18;
            // 
            // comboBoxNoActivity
            // 
            this.comboBoxNoActivity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNoActivity.FormattingEnabled = true;
            this.comboBoxNoActivity.Location = new System.Drawing.Point(113, 234);
            this.comboBoxNoActivity.Name = "comboBoxNoActivity";
            this.comboBoxNoActivity.Size = new System.Drawing.Size(102, 21);
            this.comboBoxNoActivity.TabIndex = 18;
            // 
            // EventTypeSubDescription
            // 
            this.EventTypeSubDescription.DataPropertyName = "EventTypeSubDescription";
            this.EventTypeSubDescription.HeaderText = "Event";
            this.EventTypeSubDescription.Name = "EventTypeSubDescription";
            this.EventTypeSubDescription.Width = 120;
            // 
            // EventTypeDescription
            // 
            this.EventTypeDescription.DataPropertyName = "EventTypeDescription";
            this.EventTypeDescription.HeaderText = "Reason";
            this.EventTypeDescription.Name = "EventTypeDescription";
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
            this.comboTestId.HeaderText = "TestId";
            this.comboTestId.Name = "comboTestId";
            this.comboTestId.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.comboTestId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.comboTestId.Width = 120;
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
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.EventValue.DefaultCellStyle = dataGridViewCellStyle1;
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
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 559);
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
            this.groupBox1.ResumeLayout(false);
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
        private System.Windows.Forms.Button buttonAddNoActivityEvent;
        private System.Windows.Forms.Button buttonAddPlannedMaintEvent;
        private System.Windows.Forms.Button buttonAddRigStopEvent;
        private System.Windows.Forms.Button buttonAddLPEvent;
        private System.Windows.Forms.Button buttonAddFPEvent;
        private System.Windows.Forms.Button btnRename;
        private System.Windows.Forms.Button btnFindEvent;
        private System.Windows.Forms.DateTimePicker dateTimePickerEventDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxTestBed;
        private System.Windows.Forms.Button btnSaveEvent;
        private System.Windows.Forms.DataGridView dataGridViewEventLogs;
        private System.Windows.Forms.BindingSource eventLogBindingSource;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
        private System.Windows.Forms.ComboBox comboBoxNoActivity;
        private System.Windows.Forms.ComboBox comboBoxPlannedMaintenance;
        private System.Windows.Forms.ComboBox comboBoxRigStop;
        private System.Windows.Forms.ComboBox comboBoxLpActivity;
        private System.Windows.Forms.ComboBox comboBoxFpActivity;
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
    }
}

