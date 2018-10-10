using Microsoft.Reporting.WinForms;
using ReportDao.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows.Forms.Integration;
using System.Windows.Input;
using WCFReportLib;
using WPFReportViewer.Model;
using static ReportDao.Model.Bridge;

namespace WPFReportViewer.ViewModel
{
    public class ReportViewerVM : ViewModelBase
    {
        public ICommand AdventureCommand => new RelayCommand(p => OnAdventureCommand(), p => true);
        public ICommand CustomCommand => new RelayCommand(p => OnCustomCommand(), p => true);

        public ICommand WCFCommand => new RelayCommand(p => OnWCFCommand(), p => true);
        public ICommand WCFEntityFramework => new RelayCommand(p => OnWCFEntityFramework(), p => true);
        public ICommand WCFRemoteMachine => new RelayCommand(p => OnWCFRemoteMachine(), p => true);
        public ICommand GetFilteredData => new RelayCommand(p => OnGetFilteredData(), p => true);

        private Microsoft.Reporting.WinForms.ReportViewer _reportViewer;
      

        private ChannelFactory<IReportService> reportChannelFactory = null;
        private ChannelFactory<IServiceDummy> serviceChannelDummyFactory = null;
        
        private EndpointAddress endpointAddress = null;
        private EndpointAddress endpointAddressDummy = null;

        private string epAddr = "net.tcp://localhost:7778/";
        private string eprAddrDummy = "net.tcp://localhost:7779/";

        //private string epAddr = "net.tcp://10.8.227.128:7779/";
        private IReportService _iReportService;
        private IServiceDummy _iDummyService;

        private WindowsFormsHost _winFormViewer;

        public ObservableCollection<Bridge.EventType> EventTypeList { get; } = new ObservableCollection<Bridge.EventType>();
        public ObservableCollection<Bridge.EventType> EventTypeSublist { get; set; } = new ObservableCollection<Bridge.EventType>();

        public ObservableCollection<Bridge.TestBed> TestBedList { get;  } = new ObservableCollection<Bridge.TestBed>();

        
        public WindowsFormsHost WinFormViewer
        {
            get => _winFormViewer;
            set
            {
                NotifyPropertyChanged(nameof(WinFormViewer));
                _winFormViewer = value;
            }
        }

        public Bridge.EventType _selectedEventItem;
        public Bridge.EventType SelectedEventItem
        {
            get => _selectedEventItem;
            set
            {
                NotifyPropertyChanged(nameof(SelectedEventItem));
                _selectedEventItem = value;

                FilterSubItems();
            }
        }


        Bridge.TestBed _selectedTestBedItem;
        public Bridge.TestBed SelectedTestBedItem
        {
            get => _selectedTestBedItem;
            set
            {
                NotifyPropertyChanged(nameof(SelectedTestBedItem));
                _selectedTestBedItem = value;
            }
        }

        private DateTime _fromDateTime = DateTime.Now.AddMonths(-1);
        public DateTime FromDateTime
        {
            get => _fromDateTime;
            set
            {
                NotifyPropertyChanged(nameof(FromDateTime));
                _fromDateTime = value;
            }
        }

        private DateTime _tomDateTime = DateTime.Now;
        public DateTime TomDateTime
        {
            get => _tomDateTime;
            set
            {
                NotifyPropertyChanged(nameof(TomDateTime));
                _tomDateTime = value;

            }
        }

        public Bridge.EventType _selectedEventSubItem;
        public Bridge.EventType SelectedEventSubItem
        {
            get => _selectedEventSubItem;
            set
            {
                NotifyPropertyChanged(nameof(SelectedEventSubItem));
                _selectedEventSubItem = value;
            }
        }

        private bool _isYearChecked = true; //Default value
        public bool IsYearChecked
        {
            get => _isYearChecked;
            set
            {
                NotifyPropertyChanged(nameof(IsYearChecked));
                _isYearChecked = value;
            }
        }

        private bool _isMonthChecked = false;
        public bool IsMonthChecked
        {
            get => _isMonthChecked;
            set
            {
                _isMonthChecked = value;
                NotifyPropertyChanged(nameof(IsMonthChecked));
            }
        }

        private bool _isWeekChecked = false;
        public bool IsWeekChecked
        {
            get => _isWeekChecked;
            set
            {
                _isWeekChecked = value;
                NotifyPropertyChanged(nameof(IsWeekChecked));
            }
            
        }
        private bool _isDayChecked = false;
        public bool IsDayChecked
        {
            get => _isDayChecked;
            set
            {
                _isDayChecked = value;
                NotifyPropertyChanged(nameof(IsDayChecked));
            }

        }
        private void FilterSubItems()
        {
            EventTypeSublist.Clear();
            var filter = _iReportService.GetEventTypes().Where(p => p.EventTypeSubId == _selectedEventItem.EventTypeId).ToList();
            filter.ForEach(EventTypeSublist.Add);
        }

        /*
            Constructor!
        */
        public ReportViewerVM()
        {

            SetupConnection();
            /*
             * http://htmlpreview.github.io/?https://github.com/Microsoft/Reporting-Services/blob/master/Docs_14_0/Get-Started-With-RVC.html
             */


            _reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            _winFormViewer = new WindowsFormsHost();

            LoadTestBeds();
            LoadEventTypes();
            
            //m_client.Endpoint.Address = new EndpointAddress("net.tcp://10.8.227.128:7778");
            //var logs = _iReportService.EventLogForRig(new EventType { EventTypeId = 9 });
            //List<Object> eventTypes = _iReportService.GetEventTypeObjects();
            //var test = _iReportService.GetEventTypeInts();

            //string s = _wcfClient.GetDummy();

            //var testbeds = _iReportService.EventLogForRig(new EventType { EventTypeId = 9 });
            //var a = _iReportService.GetPerson();

            string s = ";";


        }

        private void LoadTestBeds()
        {
            TestBedList.Clear();
            _iReportService.GetTestBeds().ForEach(TestBedList.Add);
        }

        private void LoadEventTypes()
        {
            EventTypeList.Clear();
            List<Bridge.EventType> eventTypes = _iReportService.GetEventTypes().OrderBy(p => p.EventTypeId).Where(x => x.EventTypeSubId == null).ToList();
            eventTypes.ForEach(EventTypeList.Add);
        }

        private void SetupConnection()
        {
            NetTcpBinding tcpBinding = new NetTcpBinding();
            reportChannelFactory = new ChannelFactory<IReportService>(tcpBinding);
            serviceChannelDummyFactory = new ChannelFactory<IServiceDummy>(tcpBinding);

            endpointAddress = new EndpointAddress(epAddr);
            endpointAddressDummy = new EndpointAddress(eprAddrDummy);

            _iReportService = reportChannelFactory.CreateChannel(endpointAddress);
            _iDummyService = serviceChannelDummyFactory.CreateChannel(endpointAddressDummy);

            
        }

       
        private FilterParameters.GroupByOperator GetGroupByParam
        {
            get
            {
                if (_isYearChecked)
                    return FilterParameters.GroupByOperator.Year;
                if (_isMonthChecked)
                    return FilterParameters.GroupByOperator.Month;
                if (_isWeekChecked)
                    return FilterParameters.GroupByOperator.Week;
                if (_isDayChecked)
                    return FilterParameters.GroupByOperator.Day;

                return FilterParameters.GroupByOperator.Year;
            }
        }
        private void OnGetFilteredData()
        {

            FilterParameters filterParameters = new FilterParameters
            {
                StartDate = _fromDateTime,
                StopDate = _tomDateTime,
                WithGrouping = GetGroupByParam
            };

            

            Bridge.EventType eventType = new Bridge.EventType() { EventTypeId = _selectedEventItem.EventTypeId };
            Dictionary<DateTime, int> times = _iReportService.EventLogForRig(eventType, filterParameters);

            DSEventLog dsEventLog = new DSEventLog(times);

            _reportViewer.Clear();
            ReportDataSource reportSource = new ReportDataSource();

            reportSource.Name = "DsEventLogRecord";
            reportSource.Value = dsEventLog.GetLogRecord;

            _reportViewer.LocalReport.DataSources.Clear();
            _reportViewer.LocalReport.DataSources.Add(reportSource);
            _reportViewer.LocalReport.DisplayName = "Anders";
            _reportViewer.LocalReport.ReportEmbeddedResource = "WPFReportViewer.Reports.RigReport.rdlc";

            _reportViewer.RefreshReport();
            _winFormViewer.Child = _reportViewer;
        }


        private void OnAdventureCommand()
        {


            ////Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            //AdventureWorks2016CTP3DataSet dataset = new AdventureWorks2016CTP3DataSet();

            //dataset.BeginInit();

            ////reportDataSource1.Name = "dsSalesOrdersAdventures"; //Name of the report dataset in our .RDLC file
            ////reportDataSource1.Value = dataset.SalesOrderDetail;
            ////this._reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            ////this._reportViewer.LocalReport.ReportEmbeddedResource = "<VSProjectName>.Report1.rdlc";
            ////this._reportViewer.LocalReport.ReportEmbeddedResource = "ReportViewer.Report1.rdlc";

            //dataset.EndInit();

            ////fill data into adventureWorksDataSet
            //ReportViewer.AdventureWorks2016CTP3DataSetTableAdapters.SalesOrderDetailTableAdapter salesOrderDetailTableAdapter = new ReportViewer.AdventureWorks2016CTP3DataSetTableAdapters.SalesOrderDetailTableAdapter();
            //salesOrderDetailTableAdapter.ClearBeforeFill = true;
            //salesOrderDetailTableAdapter.Fill(dataset.SalesOrderDetail);

            ////_reportViewer.RefreshReport();
            //_winFormViewer.Child = _reportViewer;
        }


        private void OnCustomCommand()
        {
            _reportViewer.Clear();

            RigObject rigObject = new RigObject();

            ReportDataSource reportSource = new ReportDataSource();

            reportSource.Name = "MyRigObject";
            reportSource.Value = rigObject.RigData;

            _reportViewer.LocalReport.DataSources.Add(reportSource);
            _reportViewer.LocalReport.ReportEmbeddedResource = "WPFReportViewer.CustomReport.rdlc";

            _reportViewer.RefreshReport();
            _winFormViewer.Child = _reportViewer;
        }

        private void OnWCFCommand()
        {
            string s = "";
            WebClient webClient = new WebClient();
            webClient.Headers["Content-Type"] = "application/json";
            webClient.Encoding = Encoding.UTF8;

            RigObject rigObject = new RigObject();

            //DataContractJsonSerializer serializer =
            //    new DataContractJsonSerializer(typeof(RigObject));
            //MemoryStream memstream = new MemoryStream();
            //serializer.WriteObject(memstream, rigObject);

            string st = webClient.DownloadString("http://localhost:8081/ReportService/mock");

            JavaScriptSerializer serializer = new JavaScriptSerializer();

            RigObject data = serializer.Deserialize<RigObject>(st);

            ReportDataSource reportSource = new ReportDataSource();

            reportSource.Name = "MyRigObject";
            reportSource.Value = data.RigData;

            _reportViewer.LocalReport.DataSources.Add(reportSource);
            _reportViewer.LocalReport.ReportEmbeddedResource = "WPFReportViewer.CustomReport.rdlc";

            _reportViewer.RefreshReport();
            _winFormViewer.Child = _reportViewer;

        }


        private void OnWCFEntityFramework()
        {
            /*
            ReportDaoManager reportDaoManager = new ReportDaoManager();
            var rigs = reportDaoManager.GetRig;
            var rigRecords = reportDaoManager.GetRigRecords;
            var categories = reportDaoManager.GetCategories;
            */


            WebClient webClient = new WebClient();
            webClient.Headers["Content-Type"] = "application/json";
            webClient.Encoding = Encoding.UTF8;

            //string st = webClient.DownloadString("http://localhost:8081/ReportService/db");
            byte[] data = webClient.DownloadData("http://localhost:8081/ReportService/db");


            string s = ";";

        }


        private void OnWCFRemoteMachine()
        {
            //string s = "";
            //WebClient webClient = new WebClient();
            //webClient.Headers["Content-Type"] = "application/json";
            //webClient.Encoding = Encoding.UTF8;

            //RigObject rigObject = new RigObject();

            ////DataContractJsonSerializer serializer =
            ////    new DataContractJsonSerializer(typeof(RigObject));
            ////MemoryStream memstream = new MemoryStream();
            ////serializer.WriteObject(memstream, rigObject);

            //string st = webClient.DownloadString("http://10.8.227.128:8081/ReportService/mock");

            //JavaScriptSerializer serializer = new JavaScriptSerializer();

            //RigObject data = serializer.Deserialize<RigObject>(st);

            ReportDataSource reportSource = new ReportDataSource();

            //reportSource.Name = "MyRigObject";
            //reportSource.Value = data.RigData;

            //_reportViewer.LocalReport.DataSources.Add(reportSource);
            //_reportViewer.LocalReport.ReportEmbeddedResource = "WPFReportViewer.CustomReport.rdlc";

            //_reportViewer.RefreshReport();
            //_winFormViewer.Child = _reportViewer;


            //Bridge.EventType eventType = new Bridge.EventType { EventTypeId = 9 };
            //Dictionary<DateTime, int> times = _iReportService.EventLogForRig(eventType);

            //DSEventLog dsEventLog = new DSEventLog(times);

            //_reportViewer.Clear();

            //reportSource.Name = "DsEventLogRecord";
            //reportSource.Value = dsEventLog.GetLogRecord;

            //_reportViewer.LocalReport.DataSources.Add(reportSource);
            //_reportViewer.LocalReport.ReportEmbeddedResource = "WPFReportViewer.Reports.RigReport.rdlc";

            //_reportViewer.RefreshReport();
            //_winFormViewer.Child = _reportViewer;

            //ServiceReference1.ReportServiceClient client = new ServiceReference1.ReportServiceClient("NetTcpEndpoint");

            //Dictionary<int, EventLog> data = client.EventLogForRig(eventType);




        }
    }

}


