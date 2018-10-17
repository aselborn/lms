using ReportDao.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinReportTool.Dao;

namespace WinReportTool
{
    public partial class frmMain : Form
    {

        private TreeNode _selectedTreeNode = null;
        private ListBox _selectedTestbed = null;

        //public List<Bridge.EventLog> _eventLogs;
        BindingSource bsEventLog = new BindingSource();
        BindingSource bsEventTypeReason = new BindingSource();
        List<Bridge.EventType> eventTypeReasons;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            LoadData();
            PrepareControls();

        }

        private void LoadData()
        {
            //testbeds
            LoadTestBed();
            LoadDevice();
            LoadEventType();

        }

        private void PrepareControls()
        {
            // Tab - Register events
            dateTimePickerEventDate.Value.ToShortDateString();
            comboBoxTestBed.Items.Clear();

            List<Bridge.TestBed> testBeds = WcfConnector.GetReportService.GetTestBeds().ToList();
            foreach (Bridge.TestBed item in testBeds)
            {
                comboBoxTestBed.Items.Add(item);
            }
            comboBoxTestBed.SelectedIndex = 0;

            foreach (Bridge.EventType item in eventTypeReasons.Where(p => p.EventTypeSubId == (int)Bridge.eEventType.FpActivity))
            {
                comboBoxFpActivity.Items.Add(item);
            }
            comboBoxFpActivity.SelectedIndex = 0;
            foreach (Bridge.EventType item in eventTypeReasons.Where(p => p.EventTypeSubId == (int)Bridge.eEventType.LpActivity))
            {
                comboBoxLpActivity.Items.Add(item);
            }
            comboBoxLpActivity.SelectedIndex = 0;
            foreach (Bridge.EventType item in eventTypeReasons.Where(p => p.EventTypeSubId == (int)Bridge.eEventType.RigStop))
            {
                comboBoxRigStop.Items.Add(item);
            }
            comboBoxRigStop.SelectedIndex = 0;
            foreach (Bridge.EventType item in eventTypeReasons.Where(p => p.EventTypeSubId == (int)Bridge.eEventType.PlannedMaintenance))
            {
                comboBoxPlannedMaintenance.Items.Add(item);
            }
            comboBoxPlannedMaintenance.SelectedIndex = 0;
            foreach (Bridge.EventType item in eventTypeReasons.Where(p => p.EventTypeSubId == (int)Bridge.eEventType.NoActivity))
            {
                comboBoxNoActivity.Items.Add(item);
            }
            comboBoxNoActivity.SelectedIndex = 0;


            //Bridge.TestBed selectedTestBed = (Bridge.TestBed)comboBoxTestBed.SelectedItem;
            //int testBedId = selectedTestBed != null ? selectedTestBed.TestBedId : 0;

            //DataGridViewComboBoxColumn comboTestId = (DataGridViewComboBoxColumn)dataGridViewEventLogs.Columns["comboTestId"];

            //comboTestId.DataSource = WcfConnector.GetReportService.GetTests().Where(t => t.TestBedId == testBedId).ToList();
            //comboTestId.DisplayMember = "TestName";
            //comboTestId.ValueMember = "TestId";

            dataGridViewEventLogs.DataSource = bsEventLog;

            PrepareGridComboBox();
        }

        private void PrepareGridComboBox()
        {
            Bridge.TestBed selectedTestBed = (Bridge.TestBed)comboBoxTestBed.SelectedItem;
            int testBedId = selectedTestBed != null ? selectedTestBed.TestBedId : 0;
            DataGridViewComboBoxColumn comboTestId = (DataGridViewComboBoxColumn)dataGridViewEventLogs.Columns["comboTestId"];
            comboTestId.DataSource = WcfConnector.GetReportService.GetTests().Where(t => t.TestBedId == testBedId).ToList();
            comboTestId.DisplayMember = "TestName";
            comboTestId.ValueMember = "TestId";

        }

        private void LoadEventType()
        {
            trEventTypes.Nodes.Clear();

            List<Bridge.EventType> eventTypes = WcfConnector.GetReportService.GetEventTypes();

            var categories = eventTypes.Where(p => p.EventTypeSubId is null);
            foreach(var cat in categories)
            {
                
                TreeNode node = trEventTypes.Nodes.Add(cat.EventTypeId.ToString(), cat.EventTypeDescription);
                node.Tag = cat.EventTypeSubId.ToString();

                var subCategories = eventTypes.Where(p => p.EventTypeSubId.Equals(cat.EventTypeId));
                foreach(var sub in subCategories)
                {
                    node.Nodes.Add(sub.EventTypeId.ToString(), sub.EventTypeDescription);
                    node.Tag = sub.EventTypeSubId.ToString();
                }
            }

            trEventTypes.ExpandAll();

            // Register event reason:s
            eventTypeReasons = eventTypes.Where(p => (p.EventTypeSubId == (int)Bridge.eEventType.FpActivity 
                                                        || p.EventTypeSubId == (int)Bridge.eEventType.LpActivity
                                                        || p.EventTypeSubId == (int)Bridge.eEventType.RigStop
                                                        || p.EventTypeSubId == (int)Bridge.eEventType.PlannedMaintenance
                                                        || p.EventTypeSubId == (int)Bridge.eEventType.NoActivity
                                                        || p.EventTypeId == (int)Bridge.eEventType.FpActivity
                                                        || p.EventTypeId == (int)Bridge.eEventType.LpActivity
                                                        || p.EventTypeId == (int)Bridge.eEventType.RigStop
                                                        || p.EventTypeId == (int)Bridge.eEventType.PlannedMaintenance
                                                        || p.EventTypeId == (int)Bridge.eEventType.NoActivity)).ToList();
        }
        private void LoadEventLog()
        {
            Bridge.FilterParameters searchParams = new Bridge.FilterParameters
            {
                SearchDate = dateTimePickerEventDate.Value.Date
            };
            Bridge.TestBed selectedTestBed = (Bridge.TestBed)comboBoxTestBed.SelectedItem;
            searchParams.TestBedId = selectedTestBed != null ? selectedTestBed.TestBedId : 0;

            ClearGridEventLog();

            bsEventLog.DataSource = WcfConnector.GetReportService.GetEventLogs(searchParams).ToList();

            GridRePaint();
        }

        private void ClearGridEventLog()
        {
            bsEventLog.DataSource = null;
        }


        private void LoadTestBed()
        {
            lstTestBed.Items.Clear();
            List<Bridge.TestBed> testBeds = WcfConnector.GetReportService.GetTestBeds();
            foreach (Bridge.TestBed item in testBeds)
            {
                lstTestBed.Items.Add(item);
            }
        }

        private void LoadDevice()
        {
            lstDevice.Items.Clear();
            List<Bridge.Device> devices = WcfConnector.GetReportService.GetDevices();
            foreach(Bridge.Device device in devices)
            {
                lstDevice.Items.Add(device.DeviceName);
            }
        }
        private void btnAddTestbed_Click(object sender, EventArgs e)
        {
            if (txtTestBed.Text.Length > 0)
            {
                if (lstTestBed.Items.Contains(txtTestBed.Text))
                {
                    MessageBox.Show($"Testbed item {txtTestBed.Text} already exists");
                    return;
                }
                if (WcfConnector.GetReportService.AddNewTestbed(new Bridge.TestBed { TestBedName = txtTestBed.Text }))
                {
                    txtTestBed.Text = "";
                    LoadTestBed();
                }
            }
        }

        private void btnAddDevice_Click(object sender, EventArgs e)
        {
            if (txtDevice.Text.Length > 0)
            {
                if (WcfConnector.GetReportService.SaveDevice(new Bridge.Device { DeviceName = txtDevice.Text }))
                {
                    txtDevice.Text = "";
                    LoadDevice();
                }
            }
        }

        private void trEventTypes_AfterSelect(object sender, TreeViewEventArgs e)
        {
            _selectedTreeNode = e.Node;
        }

        private void btnAddEventType_Click(object sender, EventArgs e)
        {
            int? eventTypeID = null;
            if (_selectedTreeNode != null)
            {
                if (_selectedTreeNode.FullPath.Contains("\\"))
                    eventTypeID = Convert.ToInt32(_selectedTreeNode.Tag);
                else
                    eventTypeID = null;
            }

            if (txtEventType.Text.Length > 0)
            {
                if (WcfConnector.GetReportService.SaveEventType(
                    new Bridge.EventType
                    {
                        EventTypeDescription = txtEventType.Text,
                        EventTypeSubId= eventTypeID
                    }))
                {
                    LoadEventType();
                }
            }
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            if (txtTestBed.Text.Length == 0)
                return;

            Bridge.TestBed testBed = (Bridge.TestBed)_selectedTestbed.SelectedItem;
            testBed.TestBedName = txtTestBed.Text;

            if (WcfConnector.GetReportService.SaveTestBed(testBed))
            {
                LoadTestBed();
            }
           
        }

        private void lstTestBed_Click(object sender, EventArgs e)
        {
            _selectedTestbed = (ListBox)sender;
            txtTestBed.Text = _selectedTestbed.Text;
        }

        private void lstTestBed_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnFindEvent_Click(object sender, EventArgs e)
        {
            LoadEventLog();
        }

        private void dateTimePickerEventDate_ValueChanged(object sender, EventArgs e)
        {
            ClearGridEventLog();
        }

        private void comboBoxTestBed_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearGridEventLog();
            PrepareGridComboBox();
        }

        private void GridRePaint()
        {
            for(int index = 0; index < dataGridViewEventLogs.Rows.Count; index++)
            {  
                Bridge.EventLog selectedRowItem = this.dataGridViewEventLogs.Rows[index].DataBoundItem as Bridge.EventLog;
                if (selectedRowItem != null)
                {
                    Bridge.EventType eventTypeSub = eventTypeReasons.Where(t => t.EventTypeId == selectedRowItem.EventTypeSubId).FirstOrDefault();
                    selectedRowItem.EventTypeSubDescription = eventTypeSub.EventTypeDescription;
                    if (selectedRowItem.Deleted)
                    {
                        dataGridViewEventLogs.Rows[index].DefaultCellStyle.BackColor = Color.LightGray;
                    }
                    else
                    {
                        if (selectedRowItem.EventTypeSubId == (int)Bridge.eEventType.FpActivity)
                            dataGridViewEventLogs.Rows[index].DefaultCellStyle.BackColor = Color.Green;
                        else if (selectedRowItem.EventTypeSubId == (int)Bridge.eEventType.LpActivity)
                            dataGridViewEventLogs.Rows[index].DefaultCellStyle.BackColor = Color.Green;
                        else if (selectedRowItem.EventTypeSubId == (int)Bridge.eEventType.RigStop)
                            dataGridViewEventLogs.Rows[index].DefaultCellStyle.BackColor = Color.Red;
                        else if (selectedRowItem.EventTypeSubId == (int)Bridge.eEventType.PlannedMaintenance)
                            dataGridViewEventLogs.Rows[index].DefaultCellStyle.BackColor = Color.Blue;
                        else if (selectedRowItem.EventTypeSubId == (int)Bridge.eEventType.NoActivity)
                            dataGridViewEventLogs.Rows[index].DefaultCellStyle.BackColor = Color.Yellow;
                    }
                }
            }
        }

        private void dataGridViewEventLogs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                if (dataGridViewEventLogs.Rows[e.RowIndex].DataBoundItem is Bridge.EventLog selectedRowItem)
                {
                    selectedRowItem.Deleted = !selectedRowItem.Deleted;
                    if (selectedRowItem.EventLogId == 0)
                    {
                        // Not in db - remove!
                        bsEventLog.Remove(selectedRowItem);
                    }
                }
            }
            //if (senderGrid.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn &&
            //    e.RowIndex >= 0)
            //{
            //    DataGridViewComboBoxCell comboEventTypeReason = (DataGridViewComboBoxCell)(dataGridViewEventLogs.Rows[e.RowIndex].Cells["comboEventTypeReason"]);
            //    if (comboEventTypeReason != null)
            //    {
            //        if (dataGridViewEventLogs.Rows[e.RowIndex].DataBoundItem is Bridge.EventLog selectedRowItem)
            //        {
            //            selectedRowItem.EventTypeId = comboEventTypeReason.RowIndex;
            //        }
            //    }
            //}

            GridRePaint();
        }

        private void buttonAddFPEvent_Click(object sender, EventArgs e)
        {
            Bridge.EventType reason = (Bridge.EventType)comboBoxFpActivity.SelectedItem;
            if (reason != null)
                AddEvent(Bridge.eEventType.FpActivity, reason);
        }

        private void buttonAddLPEvent_Click(object sender, EventArgs e)
        {
            Bridge.EventType reason = (Bridge.EventType)comboBoxLpActivity.SelectedItem;
            if (reason != null)
                AddEvent(Bridge.eEventType.LpActivity, reason);
        }

        private void buttonAddRigStopEvent_Click(object sender, EventArgs e)
        {
            Bridge.EventType reason = (Bridge.EventType)comboBoxRigStop.SelectedItem;
            if (reason != null)
                AddEvent(Bridge.eEventType.RigStop, reason);
        }

        private void buttonAddPlannedMaintEvent_Click(object sender, EventArgs e)
        {
            Bridge.EventType reason = (Bridge.EventType)comboBoxPlannedMaintenance.SelectedItem;
            if (reason != null)
                AddEvent(Bridge.eEventType.PlannedMaintenance, reason);
        }

        private void buttonAddNoActivityEvent_Click(object sender, EventArgs e)
        {
            Bridge.EventType reason = (Bridge.EventType)comboBoxNoActivity.SelectedItem;
            if (reason != null)
                AddEvent(Bridge.eEventType.NoActivity, reason);
        }

        private void AddEvent(Bridge.eEventType eventType, Bridge.EventType reason)
        {
            //DialogResult dialogResult = MessageBox.Show($"Do you want to add new event '{eventType.ToString()} / {reason.EventTypeDescription}' to list?", "Add event", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            //if (dialogResult == DialogResult.Cancel)
            //{
            //    return;
            //}

            Bridge.TestBed selectedTestBed = (Bridge.TestBed)comboBoxTestBed.SelectedItem;
            Bridge.EventLog newItem = new Bridge.EventLog
            {
                TestBedId = selectedTestBed.TestBedId,
                EventLogManualTime = dateTimePickerEventDate.Value.Date,

                EventTypeSubId = (int)eventType,
                EventTypeSubDescription = eventType.ToString(),
                EventTypeId = reason.EventTypeId,
                EventTypeDescription = reason.EventTypeDescription,
                EventValue = 0
            };
            bsEventLog.Add(newItem);

            GridRePaint();
        }
        
        private void btnSaveEvent_Click(object sender, EventArgs e)
        {
            try
            {
                for (int index = 0; index < dataGridViewEventLogs.Rows.Count; index++)
                {
                    if (dataGridViewEventLogs.Rows[index].DataBoundItem is Bridge.EventLog selectedRowItem)
                    {
                        WcfConnector.GetReportService.SaveEventLog(selectedRowItem);
                    }
                }
                LoadEventLog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
