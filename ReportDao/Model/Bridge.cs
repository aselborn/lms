using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ReportDao.Model
{
    public class Bridge
    {
        public enum eEventType
        {
            FpActivity = 1,
            LpActivity = 2,
            RigStop = 3,
            PlannedMaintenance = 8,
            NoActivity = 9
        }

        public class FilterParameters 
        {
            public enum GroupByOperator
            {
                none = 0,
                Year = 1,
                Month = 2,
                Week = 3,
                Day = 4,
                Date=5,
            }

            public enum ReportType
            {
                none=0,
                numberofevents = 1,
                utilization = 2
            }

            public DateTime StartDate { get; set; }
            public DateTime StopDate { get; set; }
            public DateTime SearchDate { get; set; }
            public int TestBedId { get; set; }
            public int EventTypeId { get; set; }
            public bool AllSubEvents { get; set; }
            public bool AllEvents { get; set; }
            public bool AllTestBeds { get; set; }
            public GroupByOperator WithGrouping { get; set; }
            public ReportType WithReporting { get; set; }
            
        }
     
        public abstract class ResultInfo
        {
            public string info { get; set; }
        }
        public class ResultObject : ResultInfo
        {
            public string Text { get; set; }
            public int myValue { get; set; }
        }

        public class ResultUtilizationObject : ResultInfo
        {
            public string Text { get; set; }
            public decimal myValue { get; set; }
        }

        public class DayDistributeReply
        {
            public string EventTime { get; set; }
            public string EventTypeDescription { get; set; }
            public int Number { get; set; }
        }

        public class MonthReply
        {
            public string Month { get; set; }
            public int Quantity { get; set; }
        }

        [DataContract]
        public class EventType
        {
            
            [DataMember]
            public int EventTypeId { get; set; }
            [DataMember]
            public int? EventTypeSubId { get; set; }
            [DataMember]
            public string EventTypeDescription { get; set; }

            public override string ToString()
            {
                return EventTypeDescription;
            }
        }

        [DataContract]
        public class EventLog
        {

            [DataMember]
            public int EventLogId { get; set; }
            [DataMember]
            public DateTime EventLogTime { get; set; }
            [DataMember]
            public string EventLogUserId { get; set; }
            [DataMember]
            public int EventTypeId { get; set; }
            [DataMember]
            public string EventTypeDescription { get; set; }
            [DataMember]
            public int EventTypeSubId { get; set; }
            [DataMember]
            public string EventTypeSubDescription { get; set; }
            [DataMember]
            public DateTime? EventLogManualTime { get; set; }
            [DataMember]
            public int? CustomerId { get; set; }
            [DataMember]
            public int? TestBedId { get; set; }
            [DataMember]
            public int? TestId { get; set; }
            [DataMember]
            public int? TestObjectId { get; set; }
            [DataMember]
            public int? DeviceId { get; set; }
            [DataMember]
            public int? UserObjectId { get; set; }
            [DataMember]
            public int? ItemGroupId { get; set; }
            [DataMember]
            public int? EventValue { get; set; }
            [DataMember]
            public bool Deleted { get; set; }

            public override string ToString()
            {
                return EventTypeDescription;
            }
        }

        [DataContract]
        public class Test
        {
            [DataMember]
            public int TestId { get; set; }
            [DataMember]
            public string TestName { get; set; }
            [DataMember]
            public int TestObjectId { get; set; }
            [DataMember]
            public int TestBedId { get; set; }
            [DataMember]
            public int TestModuleId { get; set; }

            public override string ToString()
            {
                return TestName;
            }
        }

        [DataContract]
        public class TestBed
        {
            [DataMember]
            public int TestBedId { get; set; }
            [DataMember]
            public string TestBedName { get; set; }

            public override string ToString()
            {
                return TestBedName;
            }
        }

        [DataContract]
        public class TestObject
        {
            [DataMember]
            public int TestObjectId { get; set; }
            [DataMember]
            public string TestObjectName { get; set; }

            public override string ToString()
            {
                return TestObjectName;
            }
        }

        [DataContract]
        public class Device
        {
            [DataMember]
            public int DeviceId { get; set; }
            [DataMember]
            public string DeviceName { get; set; }

            public override string ToString()
            {
                return DeviceName;
            }
        }

        [DataContract]
        public class ReportType
        {
            [DataMember]
            public int ReportTypeId { get; set; }
            [DataMember]
            public string ReportTypeText { get; set; }
        }

        [DataContract]
        public class UserObject
        {
            [DataMember]
            public int UserObjectId { get; set; }
            [DataMember]
            public string UserObjectName { get; set; }
            [DataMember]
            public string UserObjectPassword { get; set; }
            [DataMember]
            public DateTime? LastLoginTime { get; set; }
            [DataMember]
            public bool Locked { get; set; }

            public override string ToString()
            {
                return UserObjectName;
            }
        }

    }
}
