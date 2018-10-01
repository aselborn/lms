using FusionCharts.Charts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FusionExample
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Chart newChart = new Chart("column2d", "simplechart", "600", "400", "jsonurl", "data.json");
            
            chart.Text = newChart.Render();
        }
    }
}