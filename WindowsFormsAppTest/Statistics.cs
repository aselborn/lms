using ReportDao.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using WCFReportLib;

namespace WindowsFormsAppTest
{
    public partial class Statistics : Form
    {
       
        public Statistics()
        {
            InitializeComponent();

            InitControls();

            this.chart1.Series.Clear();
            this.chart1.Palette = ChartColorPalette.Berry;

            chart1.Titles.Add("Stat sample");
            SetChartAreaStyle();

            chart1.MouseMove += Chart1_MouseMove;
        }
        void InitControls()
        {
            this.comboBoxChartType.DataSource = Enum.GetValues(typeof(SeriesChartType));
            this.comboBoxDateTimeIntervalType.DataSource = Enum.GetValues(typeof(DateTimeIntervalType));
        }

        void SetChartAreaStyle()
        {
            chart1.ChartAreas[0].BackColor = Color.White;
            chart1.ChartAreas[0].BackSecondaryColor = Color.LightSteelBlue;
            chart1.ChartAreas[0].BackGradientStyle = GradientStyle.DiagonalRight;
            //chart1.ChartAreas[0].BackHatchStyle = ChartHatchStyle.DarkHorizontal;
           
            // Set automatic zooming
            chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart1.ChartAreas[0].AxisY.ScaleView.Zoomable = true;

            // Set automatic scrolling 
            chart1.ChartAreas[0].CursorX.AutoScroll = true;
            chart1.ChartAreas[0].CursorY.AutoScroll = true;

            // Allow user selection for Zoom
            chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chart1.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;

        }

        private void Chart1_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePoint = new Point(e.X, e.Y);

            chart1.ChartAreas[0].CursorX.Interval = 0;
            chart1.ChartAreas[0].CursorY.Interval = 0;

            chart1.ChartAreas[0].CursorX.SetCursorPixelPosition(mousePoint, true);
            chart1.ChartAreas[0].CursorY.SetCursorPixelPosition(mousePoint, true);

            HitTestResult result = chart1.HitTest(e.X, e.Y);

            if (chart1.Series.Count > 0 )
            {                
                labelPixelX.Text = $"Cursor pos X: " + DateTime.FromOADate(chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.X)).ToLongDateString();
                labelPixelY.Text = $"Cursor pos Y: " + chart1.ChartAreas[0].AxisY.PixelPositionToValue(e.Y).ToString();

                if (result.PointIndex > -1 && result.ChartArea != null)
                {
                    labelXValue.Text = "X-Value: " + DateTime.FromOADate(result.Series.Points[result.PointIndex].XValue).ToString("yyMMdd");
                    labelYValue.Text = "Y-Value:" + result.Series.Points[result.PointIndex].YValues[0].ToString();
                }
            }
        }

        public void AddSerie(Chart chart, string name, object source, SeriesChartType chartType )
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
                chart.ChartAreas[0].AxisX.IntervalType = (DateTimeIntervalType)comboBoxDateTimeIntervalType.SelectedValue;//DateTimeIntervalType.Days;
                //chart.ChartAreas[0].AxisX.IntervalOffset = 1;

                if(chartType == SeriesChartType.Line)
                    chart.Series[name].BorderWidth = 3;

                chart.Series[name].ToolTip = "Name #SERIESNAME : X: #VALX{yyMMdd-HH:mm:ss} , Y: #VALY{F2}";
                chart.Series[name].Points.DataBind(source as System.Collections.IEnumerable, "X", "Y", "");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {            
            this.chart1.Series.Clear();
            SeriesChartType chartType = (SeriesChartType)comboBoxChartType.SelectedValue;
            AddSerie(this.chart1, $"{DateTime.Now.Ticks}-{chartType}", StatisticsQuerys.GetSample2(), chartType);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            SeriesChartType chartType = (SeriesChartType)comboBoxChartType.SelectedValue;
            AddSerie(this.chart1, $"{DateTime.Now.Ticks}-{chartType}", StatisticsQuerys.GetSample2(), chartType);
        }

        private void buttonAddTrend_Click(object sender, EventArgs e)
        {
            AddTrendLine();
        }

        void AddTrendLine()
        {
            if (chart1.Series.Count > 0)
            {
                Series serie = chart1.Series.Last();

                string trendSerieName = $"{serie.Name} - trend";

                Series trend = chart1.Series.Add(trendSerieName);
                trend.ChartType = SeriesChartType.Line;
                trend.BorderWidth = 3;
                trend.Color = Color.Red;

                // Line of best fit is linear
                string typeRegression = "Linear";//"Exponential";//
                                                 // The number of days for Forecasting
                string forecasting = "1";
                // Show Error as a range chart.
                string error = "false";
                // Show Forecasting Error as a range chart.
                string forecastingError = "false";
                // Formula parameters
                string parameters = typeRegression + ',' + forecasting + ',' + error + ',' + forecastingError;
                chart1.Series[0].Sort(PointSortOrder.Ascending, "X");
                // Create Forecasting Series.
                chart1.DataManipulator.FinancialFormula(FinancialFormula.Forecasting, parameters, serie, trend);
            }
        }

        private void btnWcf_Click(object sender, EventArgs e)
        {
            WcfStatistics stat = new WcfStatistics();
            stat.GetData();

            SeriesChartType chartType = (SeriesChartType)comboBoxChartType.SelectedValue;
            AddSerie(this.chart1, $"{DateTime.Now.Ticks}-{chartType}", stat.GetData(), chartType);
        }
    }

    #region Helpers

    public class StatResultItem
    {
        public int Y { get; set; }
        public object X { get; set; }
    }

    public class StatisticsQuerys
    {
        public static List<StatResultItem> GetSample2()
        {
            var result = new List<StatResultItem>();
            
            DateTime d = DateTime.Now;

            Random r = new Random();

            for (int n = 1; n < 100; n++)
            {
                int y = r.Next(5, 30);
                result.Add(new StatResultItem() { Y = y, X = d.AddDays(n) });
            }

            return result;
        }
    }

    public class WcfStatistics
    {

        private ChannelFactory<IReportService> channelFactory = null;
        private EndpointAddress endpointAddress = null;
        private string epAddr = "net.tcp://localhost:7778/";
        //private string epAddr = "net.tcp://10.8.227.128:7779/";
        private IReportService _iReportService;

        public WcfStatistics()
        {
            SetupConnection();
        }

        private void SetupConnection()
        {
            NetTcpBinding tcpBinding = new NetTcpBinding();
            channelFactory = new ChannelFactory<IReportService>(tcpBinding);
            endpointAddress = new EndpointAddress(epAddr);
            _iReportService = channelFactory.CreateChannel(endpointAddress);
        }

        public List<StatResultItem> GetData()
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
    }


    #endregion


}
