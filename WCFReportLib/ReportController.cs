using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace WCFReportLib
{
    public class ReportController
    {
        private ServiceHost _serviceHost;
        private Uri _baseAddress = new Uri("http://localhost:8081/ReportService/");
        public ReportController()
        {
            _serviceHost = new ServiceHost(typeof(ReportService));
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
            smb.HttpGetEnabled = true;

            _serviceHost.Description.Behaviors.Add(smb);

            
        }

        public void Stop()
        {
            _serviceHost.Close();
        }
    }
}
