using ReportDao.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Input;
using WCFReportLib;

namespace WPFReportViewer.ViewModel
{
    public class ChartingWindowVM : ViewModelBase
    {
        private Chart _myChart;
        public ICommand TestCommand => new RelayCommand(x => OnTestCommand(), x => true);
        public ICommand ChartingCommand => new RelayCommand(y => OnChartingCommand(), y => true);
        private ChannelFactory<IReportService> channelFactory = null;
        private EndpointAddress endpointAddress = null;
        private string epAddr = "net.tcp://localhost:7778/";
        //private string epAddr = "net.tcp://10.8.227.128:7779/";
        private IReportService _iReportService;
        private void SetupConnection()
        {
            NetTcpBinding tcpBinding = new NetTcpBinding();
            channelFactory = new ChannelFactory<IReportService>(tcpBinding);
            endpointAddress = new EndpointAddress(epAddr);
            _iReportService = channelFactory.CreateChannel(endpointAddress);
        }

        public ChartingWindowVM(Chart chart)
        {
            _myChart = chart;
            SetupConnection();


            _myChart.Series.Clear();
            _myChart.Palette = ChartColorPalette.Berry;

            _myChart.Titles.Add("Stat sample");
            SetChartAreaStyle();
        }

        private void OnTestCommand()
        {
            MessageBox.Show("Hello World.");
        }

        void SetChartAreaStyle()
        {
            _myChart.ChartAreas[0].BackColor = Color.White;
            _myChart.ChartAreas[0].BackSecondaryColor = Color.LightSteelBlue;
            _myChart.ChartAreas[0].BackGradientStyle = GradientStyle.DiagonalRight;
            //chart1.ChartAreas[0].BackHatchStyle = ChartHatchStyle.DarkHorizontal;

            // Set automatic zooming
            _myChart.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            _myChart.ChartAreas[0].AxisY.ScaleView.Zoomable = true;

            // Set automatic scrolling 
            _myChart.ChartAreas[0].CursorX.AutoScroll = true;
            _myChart.ChartAreas[0].CursorY.AutoScroll = true;

            // Allow user selection for Zoom
            _myChart.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            _myChart.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;

        }

        private void OnChartingCommand()
        {
           
            

            SeriesChartType chartType = SeriesChartType.Line;
            AddSerie(_myChart, $"{DateTime.Now.Ticks}-{chartType}",GetData(), chartType);

            //AddSerie(_myChart, "Test", values, SeriesChartType.FastLine);
        }

        private List<StatResultItem> GetData()
        {
            List<StatResultItem> result = new List<StatResultItem>();

            Bridge.FilterParameters prms = new Bridge.FilterParameters();
            prms.StartDate = DateTime.Parse("2017-08-01");
            prms.StopDate = DateTime.Now;
            prms.WithGrouping = Bridge.FilterParameters.GroupByOperator.Date;

            Dictionary<DateTime, int> times = _iReportService.EventLogForRig(new Bridge.EventType { EventTypeId = 9 }, prms);


            foreach (var v in times)
            {
                result.Add(new StatResultItem { X = v.Key, Y = v.Value });
            }

            return result;
        }
        public void AddSerie(Chart chart, string name, object source, SeriesChartType chartType)
        {
            try
            {
                chart.Series.Add(name);
                chart.Series[name].XValueMember = "X";
                chart.Series[name].YValueMembers = "Y";

                chart.Series[name].ChartType = chartType;
                chart.Series[name].XValueType = ChartValueType.DateTime;
                //chart.ChartAreas[0].AxisX.LabelStyle.Format = "yyyy-MM-dd";
                chart.ChartAreas[0].AxisX.Interval = 1;
                chart.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Days;
                // chart.ChartAreas[0].AxisX.IntervalType = (DateTimeIntervalType)comboBoxDateTimeIntervalType.SelectedValue;//DateTimeIntervalType.Days;
                //chart.ChartAreas[0].AxisX.IntervalOffset = 1;

                if (chartType == SeriesChartType.Line)
                    chart.Series[name].BorderWidth = 3;

                chart.Series[name].ToolTip = "Name #SERIESNAME : X: #VALX{yyMMdd-HH:mm:ss} , Y: #VALY{F2}";
                chart.Series[name].Points.DataBind(source as System.Collections.IEnumerable, "X", "Y", "");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

    internal class StatResultItem
    {
        public int Y { get; set; }
        public object X { get; set; }
    }
}
