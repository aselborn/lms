using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPFReportViewer.ViewModel;

namespace WPFReportViewer.View
{
    /// <summary>
    /// Interaction logic for ChartingWindow.xaml
    /// </summary>
    public partial class ChartingWindow : Window
    {
        
        

        public ChartingWindow()
        {
            InitializeComponent();
            this.DataContext = new ChartingWindowVM(MyWinFormChart);
        }
    }
}
