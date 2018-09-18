using WPFReportViewer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFReportViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _isReportViewerLoaded;
        public MainWindow()
        {
            InitializeComponent();
            //_reportViewer.Load += _reportViewer_Load;
            this.DataContext = new ReportViewerVM();

        }

        private void _reportViewer_Load(object sender, EventArgs e)
        {
            //if (!_isReportViewerLoaded)
            //{
            //    Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            //    AdventureWorks2016CTP3DataSet dataset = new AdventureWorks2016CTP3DataSet();
                
            //    dataset.BeginInit();

            //    reportDataSource1.Name = "dsSalesOrdersAdventures"; //Name of the report dataset in our .RDLC file
            //    reportDataSource1.Value = dataset.SalesOrderDetail;
            //    this._reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            //    //this._reportViewer.LocalReport.ReportEmbeddedResource = "<VSProjectName>.Report1.rdlc";
            //    this._reportViewer.LocalReport.ReportEmbeddedResource = "ReportViewer.Report1.rdlc";

            //    dataset.EndInit();

            //    //fill data into adventureWorksDataSet
            //    AdventureWorks2016CTP3DataSetTableAdapters.SalesOrderDetailTableAdapter salesOrderDetailTableAdapter = new AdventureWorks2016CTP3DataSetTableAdapters.SalesOrderDetailTableAdapter();
            //    salesOrderDetailTableAdapter.ClearBeforeFill = true;
            //    salesOrderDetailTableAdapter.Fill(dataset.SalesOrderDetail);

                

            //    _reportViewer.RefreshReport();

            //    _isReportViewerLoaded = true;
            //}
        }
    }
}
