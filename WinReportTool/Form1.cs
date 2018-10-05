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
                var subCategories = eventTypes.Where(p => p.EventTypeSubId.Equals(cat.EventTypeId));
                foreach(var sub in subCategories)
                {
                    node.Nodes.Add(sub.EventTypeId.ToString(), sub.EventTypeDescription);
                }
            }


        }
        private void LoadTestBed()
        {
            lstTestBed.Items.Clear();
            List<Bridge.TestBed> testBeds = WcfConnector.GetReportService.GetTestBeds();
            foreach (Bridge.TestBed item in testBeds)
            {
                lstTestBed.Items.Add(item.TestBedName);
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
                if (WcfConnector.GetReportService.SaveTestbed(new Bridge.TestBed { TestBedName = txtTestBed.Text }))
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
            if (txtEventType.Text.Length > 0 && _selectedTreeNode != null)
            {
                if (WcfConnector.GetReportService.SaveEventType(
                    new Bridge.EventType
                    {
                        EventTypeDescription = txtEventType.Text,
                        EventTypeSubId = null
                    }))
                {
                    LoadEventType();
                }
            }
        }
    }
}
