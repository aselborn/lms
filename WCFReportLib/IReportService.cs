﻿
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

        [WebInvokeAttribute(BodyStyle = WebMessageBodyStyle.Wrapped)]
        [OperationContract]
        Dictionary<DateTime, int> EventLogForRig(Bridge.EventType eventType, FilterParameters filterParameters);

        [WebInvokeAttribute(BodyStyle = WebMessageBodyStyle.Wrapped)]
        [OperationContract]
        List<SimpleResultObject> EventLogDummy(Bridge.EventType eventType, FilterParameters filterParameters);

        [OperationContract]
        List<Bridge.TestBed> GetTestBeds();

        [OperationContract]
        List<Bridge.EventType> GetEventTypes();

        [OperationContract]
        string GetDummy();

        [OperationContract]
        List<Person> GetPerson();


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
