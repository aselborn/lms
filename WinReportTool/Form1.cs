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
        private TreeNode _selectedTreeNodeAddEventToLog = null;
        private ListBox _selectedTestbed = null;
        private ListBox _selectedDevice = null;

        BindingSource bsEventLog = new BindingSource();
        List<Bridge.EventType> _eventTypes;

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
            dataGridViewEventLogs.DataSource = bsEventLog;

            dateTimePickerEventDate.Value = DateTime.Today;
            comboBoxTestBed.Items.Clear();

            List<Bridge.TestBed> testBeds = WcfConnector.GetReportService.GetTestBeds().ToList();
            foreach (Bridge.TestBed item in testBeds)
            {
                comboBoxTestBed.Items.Add(item);
            }
            comboBoxTestBed.SelectedIndex = 0;

            PrepareGridComboBox();
        }

        private void PrepareGridComboBox()
        {
            try
            {
                Bridge.TestBed selectedTestBed = (Bridge.TestBed)comboBoxTestBed.SelectedItem;
                int testBedId = selectedTestBed != null ? selectedTestBed.TestBedId : 0;
                DataGridViewComboBoxColumn comboTestId = (DataGridViewComboBoxColumn)dataGridViewEventLogs.Columns["comboTestId"];
                comboTestId.DataSource = WcfConnector.GetReportService.GetTests().Where(t => t.TestBedId == testBedId).ToList();
                comboTestId.DisplayMember = "TestName";
                comboTestId.ValueMember = "TestId";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadEventType()
        {
            trEventTypes.Nodes.Clear();
            treeViewAddEventToLog.Nodes.Clear();

            _eventTypes = WcfConnector.GetReportService.GetEventTypes();

            var categories = _eventTypes.Where(p => p.EventTypeSubId is null);
            foreach(var cat in categories)
            {
                TreeNode node = trEventTypes.Nodes.Add(cat.EventTypeId.ToString(), cat.EventTypeDescription);
                node.Tag = cat.EventTypeSubId.ToString();
                TreeNode nodeAddEventToLog = treeViewAddEventToLog.Nodes.Add(cat.EventTypeId.ToString(), cat.EventTypeDescription);
                nodeAddEventToLog.Tag = cat.EventTypeSubId.ToString();

                var subCategories = _eventTypes.Where(p => p.EventTypeSubId.Equals(cat.EventTypeId));
                foreach(var sub in subCategories)
                {
                    node.Nodes.Add(sub.EventTypeId.ToString(), sub.EventTypeDescription);
                    node.Tag = sub.EventTypeSubId.ToString();
                    nodeAddEventToLog.Nodes.Add(sub.EventTypeId.ToString(), sub.EventTypeDescription);
                    nodeAddEventToLog.Tag = sub.EventTypeSubId.ToString();
                }
            }

            trEventTypes.ExpandAll();
            _selectedTreeNode = null;

            treeViewAddEventToLog.ExpandAll();
            _selectedTreeNodeAddEventToLog = null;
        }

        private void LoadEventLog()
        {
            try
            {
                Bridge.FilterParameters searchParams = new Bridge.FilterParameters
                {
                    SearchDate = dateTimePickerEventDate.Value.Date
                };
                Bridge.TestBed selectedTestBed = (Bridge.TestBed)comboBoxTestBed.SelectedItem;
                searchParams.TestBedId = selectedTestBed != null ? selectedTestBed.TestBedId : 0;

                ClearGridEventLog();

                bsEventLog.DataSource = WcfConnector.GetReportService.GetEventLogs(searchParams).Where(e => e.Deleted == false).ToList();

                GridRePaint();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
            foreach (Bridge.Device item in devices)
            {
                lstDevice.Items.Add(item);
            }
        }


        private void trEventTypes_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (trEventTypes.SelectedNode != null && trEventTypes.SelectedNode.IsSelected)
            {
                trEventTypes.SelectedNode.BackColor = System.Drawing.SystemColors.Window;
                trEventTypes.SelectedNode.ForeColor = System.Drawing.SystemColors.WindowText;
            }
        }

        private void trEventTypes_AfterSelect(object sender, TreeViewEventArgs e)
        {
            _selectedTreeNode = e.Node;

            trEventTypes.SelectedNode.BackColor = System.Drawing.SystemColors.Highlight;
            trEventTypes.SelectedNode.ForeColor = System.Drawing.SystemColors.HighlightText;

            txtEventType.Text = _selectedTreeNode.Text;
            btnAddEventType.Enabled = !string.IsNullOrEmpty(txtEventType.Text);
        }

        private void treeViewAddEventToLog_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (treeViewAddEventToLog.SelectedNode != null /*&& treeViewAddEventToLog.SelectedNode.IsSelected*/)
            {
                treeViewAddEventToLog.SelectedNode.BackColor = System.Drawing.SystemColors.Window;
                treeViewAddEventToLog.SelectedNode.ForeColor = System.Drawing.SystemColors.WindowText;
            }
        }

        private void treeViewAddEventToLog_AfterSelect(object sender, TreeViewEventArgs e)
        {
            _selectedTreeNodeAddEventToLog = e.Node;
          
            treeViewAddEventToLog.SelectedNode.BackColor = System.Drawing.SystemColors.Highlight;
            treeViewAddEventToLog.SelectedNode.ForeColor = System.Drawing.SystemColors.HighlightText;

            // Only possible to add event with reason
            buttonAddEvent.Enabled = _selectedTreeNodeAddEventToLog.FullPath.Contains("\\");
        }

        private void btnAddEventType_Click(object sender, EventArgs e)
        {
            try
            { 
                int? eventTypeID = null;
                if (_selectedTreeNode != null)
                {
                    // Check if parent exists
                    if (_selectedTreeNode.FullPath.Contains("\\"))
                        eventTypeID = Convert.ToInt32(_selectedTreeNode.Parent.Name);

                    if (txtEventType.Text.Length > 0)
                    {
                        if (WcfConnector.GetReportService.SaveEventType(
                            new Bridge.EventType
                            {
                                EventTypeDescription = txtEventType.Text,
                                EventTypeSubId = eventTypeID
                            }))
                        {
                            LoadEventType();
                        }
                        else
                        {
                            MessageBox.Show($"EventType '{_selectedTreeNode.Text}' already exists and can not be added!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonDeleteEventType_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedTreeNode != null)
                {
                    DialogResult dialogResult = MessageBox.Show($"Do you want delete EventType '{_selectedTreeNode.Text}'?", "Delete EventType", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Cancel)
                    {
                        return;
                    }

                    int eventTypeID = Convert.ToInt32(_selectedTreeNode.Name);

                    if (WcfConnector.GetReportService.DeleteEventType(
                    new Bridge.EventType
                    {
                        EventTypeDescription = txtEventType.Text,
                        EventTypeId = eventTypeID
                    }))
                    {
                        LoadEventType();
                    }
                    else
                    {
                        MessageBox.Show($"EventType '{_selectedTreeNode.Text}' is in use and can not be deleted!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    
        private void btnAddTestbed_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTestBed.Text.Length > 0)
                {
                    if (WcfConnector.GetReportService.AddNewTestbed(new Bridge.TestBed { TestBedName = txtTestBed.Text }))
                    {
                        txtTestBed.Text = "";
                        LoadTestBed();
                    }
                    else
                    {
                        MessageBox.Show($"Testbed '{txtTestBed.Text}' already exists and can not be added!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeleteTestBed_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedTestbed != null)
                {
                    Bridge.TestBed testBed = (Bridge.TestBed)_selectedTestbed.SelectedItem;
                    if (testBed != null)
                    {
                        DialogResult dialogResult = MessageBox.Show($"Do you want delete TestBed '{_selectedTestbed.Text}'?", "Delete TestBed", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Cancel)
                        {
                            return;
                        }

                        if (WcfConnector.GetReportService.DeleteTestBed(testBed))
                        {
                            LoadTestBed();
                        }
                        else
                        {
                            MessageBox.Show($"TestBed '{_selectedTestbed.Text}' is in use and can not be deleted!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddDevice_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDevice.Text.Length > 0)
                {
                    if (WcfConnector.GetReportService.SaveDevice(new Bridge.Device { DeviceName = txtDevice.Text }))
                    {
                        txtDevice.Text = "";
                        LoadDevice();
                    }
                    else
                    {
                        MessageBox.Show($"Device '{txtDevice.Text}' already exists and can not be added!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonDeleteDevice_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedDevice != null)
                {
                    Bridge.Device device = (Bridge.Device)_selectedDevice.SelectedItem;
                    if (device != null)
                    {
                        DialogResult dialogResult = MessageBox.Show($"Do you want delete TestBed '{_selectedDevice.Text}'?", "Delete Device", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Cancel)
                        {
                            return;
                        }

                        if (WcfConnector.GetReportService.DeleteDevice(device))
                        {
                            LoadTestBed();
                        }
                        else
                        {
                            MessageBox.Show($"Device '{_selectedDevice.Text}' is in use and can not be deleted!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        private void lstDevice_Click(object sender, EventArgs e)
        {
            _selectedDevice = (ListBox)sender;
            txtDevice.Text = _selectedDevice.Text;
        }

        private void dateTimePickerEventDate_ValueChanged(object sender, EventArgs e)
        {
            LoadEventLog();
        }

        private void comboBoxTestBed_SelectedIndexChanged(object sender, EventArgs e)
        {
            PrepareGridComboBox();
            LoadEventLog();
        }

        private void GridRePaint()
        {
            for(int index = 0; index < dataGridViewEventLogs.Rows.Count; index++)
            {  
                Bridge.EventLog selectedRowItem = this.dataGridViewEventLogs.Rows[index].DataBoundItem as Bridge.EventLog;
                if (selectedRowItem != null)
                {
                    Bridge.EventType eventTypeSub = _eventTypes.Where(t => t.EventTypeId == selectedRowItem.EventTypeSubId).FirstOrDefault();
                    selectedRowItem.EventTypeSubDescription = eventTypeSub.EventTypeDescription;
                    if (selectedRowItem.Deleted)
                    {
                        dataGridViewEventLogs.Rows[index].DefaultCellStyle.BackColor = Color.LightGray;
                    }
                    else
                    {
                        if (selectedRowItem.EventTypeSubId == (int)Bridge.eEventType.FpActivity)
                        {
                            dataGridViewEventLogs.Rows[index].DefaultCellStyle.BackColor = Color.SeaGreen;
                            dataGridViewEventLogs.Rows[index].Cells["comboTestId"].InheritedStyle.SelectionBackColor = Color.SeaGreen;

                        }
                        else if (selectedRowItem.EventTypeSubId == (int)Bridge.eEventType.LpActivity)
                            dataGridViewEventLogs.Rows[index].DefaultCellStyle.BackColor = Color.SeaGreen;
                        else if (selectedRowItem.EventTypeSubId == (int)Bridge.eEventType.RigStop)
                            dataGridViewEventLogs.Rows[index].DefaultCellStyle.BackColor = Color.OrangeRed;
                        else if (selectedRowItem.EventTypeSubId == (int)Bridge.eEventType.PlannedMaintenance)
                            dataGridViewEventLogs.Rows[index].DefaultCellStyle.BackColor = Color.DodgerBlue;
                        else if (selectedRowItem.EventTypeSubId == (int)Bridge.eEventType.NoActivity)
                            dataGridViewEventLogs.Rows[index].DefaultCellStyle.BackColor = Color.Gold;
                    }
                }
            }
            CalcTotalTime();
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
            GridRePaint();
        }

        private void dataGridViewEventLogs_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewTextBoxColumn &&
                e.RowIndex >= 0)
            {
                CalcTotalTime();
            }
        }
        private void dataGridViewEventLogs_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
        }

        private void textBoxTotalTime_TextChanged(object sender, EventArgs e)
        {
            //int totTime = Convert.ToInt32(textBoxTotalTime.Text);

            string remainingTime = textBoxTotalTime.Text.Split('/')[1];

            if (Convert.ToInt32(remainingTime) < 0)
            {
                DialogResult dialogResult = MessageBox.Show($"Total time must not exceed 1440 min (24h)!", "Total Time", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            buttonRegisterEvent.Enabled = Convert.ToInt32(remainingTime) >= 0 ? true : false;
        }

        private void CalcTotalTime()
        {
            int totTime = 0;
            for (int index = 0; index < dataGridViewEventLogs.Rows.Count; index++)
            {
                if (dataGridViewEventLogs.Rows[index].DataBoundItem is Bridge.EventLog eventLog)
                {
                    if (!eventLog.Deleted && (eventLog.EventTypeSubId == (int)Bridge.eEventType.FpActivity ||
                                                eventLog.EventTypeSubId == (int)Bridge.eEventType.LpActivity ||
                                                eventLog.EventTypeSubId == (int)Bridge.eEventType.NoActivity ||
                                                eventLog.EventTypeSubId == (int)Bridge.eEventType.PlannedMaintenance ||
                                                eventLog.EventTypeSubId == (int)Bridge.eEventType.RigStop))
                        totTime += eventLog.EventValue ?? 0;
                }
            }
            int remainingTime = 24 * 60 - totTime;
            textBoxTotalTime.Text = $"{totTime} / {remainingTime}";
        }

        private void buttonFindEvent_Click(object sender, EventArgs e)
        {
            LoadEventLog();
        }

        private void buttonAddEvent_Click(object sender, EventArgs e)
        {
            AddEvent( Convert.ToInt32(_selectedTreeNodeAddEventToLog.Parent.Name), 
                      Convert.ToInt32(_selectedTreeNodeAddEventToLog.Name), 
                      _selectedTreeNodeAddEventToLog.Text);
        }

        private void AddEvent(int eventTypeSubId, int reasonEventTypeId, string reasonDescription)
        {
            Bridge.TestBed selectedTestBed = (Bridge.TestBed)comboBoxTestBed.SelectedItem;
            Bridge.EventLog newItem = new Bridge.EventLog
            {
                TestBedId = selectedTestBed.TestBedId,
                EventLogManualTime = dateTimePickerEventDate.Value.Date,

                EventTypeSubId = eventTypeSubId,
                EventTypeSubDescription = "",
                EventTypeId = reasonEventTypeId,
                EventTypeDescription = reasonDescription,
                EventValue = 0
            };
            bsEventLog.Add(newItem);

            GridRePaint();
        }

        private void buttonRegisterEvent_Click(object sender, EventArgs e)
        {
            if (dataGridViewEventLogs.Rows.Count == 0)
                return;

            DialogResult dialogResult = MessageBox.Show($"Do you want register/update event(s)?", "Register events", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Cancel)
            {
                return;
            }
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

        private void trEventTypes_MouseDown(object sender, MouseEventArgs e)
        {
            // Make sure this is the right button.
            if (e.Button != MouseButtons.Right) return;

            // Select this node.
            TreeNode node_here = trEventTypes.GetNodeAt(e.X, e.Y);
            trEventTypes.SelectedNode = node_here;

            // See if we got a node.
            if (node_here == null) return;

            // See what kind of object this is and
            // display the appropriate popup menu.
            if (node_here.Tag is Bridge.EventType)
            {
                Bridge.EventType eventType = (Bridge.EventType)node_here.Tag;
               // AddEvent(Bridge.eEventType.FpActivity, eventType);

            }
        }
    }
}
