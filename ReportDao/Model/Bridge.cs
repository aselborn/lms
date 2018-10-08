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
        public class FilterParameters
        {
            public enum GroupByOperator
            {
                Year = 1,
                Month = 2,
                Week = 3,
                Day = 4,
                Date=5,
            }
            public DateTime StartDate { get; set; }
            public DateTime StopDate { get; set; }

            public GroupByOperator WithGrouping { get; set; }
            //public List<EventType> EventTypeList { get; set; }
        }
     
        public class ResultObject
        {
            public string Text { get; set; }
            public int myValue { get; set; }
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
        public class Device
        {
            [DataMember]
            public int DeviceId { get; set; }
            [DataMember]
            public string DeviceName { get; set; }
        }
    }
}
