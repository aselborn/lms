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
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            //testbeds
            LoadTestBed();
            LoadDevice();
            LoadEventType();
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
    }
}
