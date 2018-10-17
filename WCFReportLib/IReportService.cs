
using ReportDao.Entity;
using ReportDao.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCFReportLib.Mock;
using WCFReportLib.Model;
using static ReportDao.Model.Bridge;

namespace WCFReportLib
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IReportService
    {
        [OperationContract]
        string GetData(int value);


        [OperationContract]
        ReplyMessage Version();


        [OperationContract]
        RigObject GetRigobject();

        [OperationContract]
        DataSet GetDs();

        [Obsolete]
        [WebInvokeAttribute(BodyStyle = WebMessageBodyStyle.Wrapped)]
        [OperationContract]
        Dictionary<DateTime, int> EventLogForRig(Bridge.EventType eventType, FilterParameters filterParameters);

        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        [OperationContract]
        List< Bridge.ResultObject > EventlogObjectForRig(Bridge.EventType eventType, FilterParameters filterParameters);

        [WebInvokeAttribute(BodyStyle = WebMessageBodyStyle.Wrapped)]
        [OperationContract]
        List<SimpleResultObject> EventLogDummy(Bridge.EventType eventType, FilterParameters filterParameters);

        [OperationContract]
        List<Bridge.Test> GetTests();

        [OperationContract]
        List<Bridge.TestBed> GetTestBeds();

        [OperationContract]
        List<Bridge.EventType> GetEventTypes();

        [OperationContract]
        List<Bridge.EventLog> GetEventLogs(FilterParameters filterParameters);

        [OperationContract]
        List<Bridge.Device> GetDevices();

        [OperationContract]
        string GetDummy();

        [OperationContract]
        List<Person> GetPerson();

        [OperationContract]
        bool AddNewTestbed(Bridge.TestBed newTestBed);

        [OperationContract]
        bool SaveTestBed(Bridge.TestBed currentTestbed);

        [OperationContract]
        bool SaveDevice(Bridge.Device device);

        [OperationContract]
        bool SaveEventType(Bridge.EventType eventType);

        [OperationContract]
        bool SaveEventLog(Bridge.EventLog eventLog);
    }

    [DataContract]
  public class Person
    {
        [DataMember]
        public String Name { get; set; }
        [DataMember]
        public int Age { get; set; }
    }
}
