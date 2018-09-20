using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace WcfContracts
{
    [ServiceContract]
    public interface IServiceTestCellController
    {
        TestCellStatus GetTestCellStatus(uint testCellNo);
    }

    public class TestCellStatus
    {
        public ComTestStatus ComTestStatus { get; set; }
    }

    public class ComTestStatus
    {
        public string Information { get; set; }
    }

    public class ServiceTestCellController : IServiceTestCellController
    {
        public TestCellStatus GetTestCellStatus(uint testCellNo)
        {
            return new TestCellStatus() { ComTestStatus = new ComTestStatus() };
        }
    }


    public interface IStatistics
    {
        void GetStatistics();
    }
    public interface ISupervision
    {
        void GetAlarms();
    }


    public class StatisticsService : IStatistics
    {
        public void GetStatistics()
        {
            throw new NotImplementedException();
        }
    }

    public class SupervisionService : ISupervision
    {
        public void GetAlarms()
        {
            throw new NotImplementedException();
        }
    }
}
