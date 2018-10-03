using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace WebReport.Models
{
    public class BarController : Controller
    {
        private Random rnd = new Random();
        public IActionResult Index()
        {

            var lstModel = new List<SimpleReportViewModel>();
            lstModel.Add(new SimpleReportViewModel
            {
                DimensionOne = "Technology",
                Quantity = rnd.Next(10)

            });

            lstModel.Add(new SimpleReportViewModel
            {
                DimensionOne = "Sales",
                Quantity = rnd.Next(10)
            });
            lstModel.Add(new SimpleReportViewModel
            {
                DimensionOne = "Marketing",
                Quantity = rnd.Next(10)
            });
            lstModel.Add(new SimpleReportViewModel
            {
                DimensionOne = "Human Resource",
                Quantity = rnd.Next(10)
            });
            lstModel.Add(new SimpleReportViewModel
            {
                DimensionOne = "Research and Development",
                Quantity = rnd.Next(10)
            });
            lstModel.Add(new SimpleReportViewModel
            {
                DimensionOne = "Acconting",
                Quantity = rnd.Next(10)
            });
            lstModel.Add(new SimpleReportViewModel
            {
                DimensionOne = "Support",
                Quantity = rnd.Next(10)
            });
            lstModel.Add(new SimpleReportViewModel
            {
                DimensionOne = "Logistics",
                Quantity = rnd.Next(10)
            });

            return View(lstModel);
        }

        
        

        public async Task<IActionResult> Bar2()
        {
            var lstModel = new List<SimpleReportViewModel>();
            EndpointAddress endpointAddress = new EndpointAddress("net.tcp://localhost:7778/");
            NetHttpBinding binding = new NetHttpBinding();


            //WCFService.ReportServiceClient client = new WCFService.ReportServiceClient(binding, endpointAddress);
            WCFService.ReportServiceClient client = new WCFService.ReportServiceClient();
            var p = await client.GetDataAsync(1);
            

            //var test = await client.GetDataAsync(1);

            return View(lstModel);
        }
    }
}