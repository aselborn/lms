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
     


        [DataContract]
        public class EventType
        {
            
            [DataMember]
            public int EventTypeId { get; set; }
            [DataMember]
            public int? EventTypeSubId { get; set; }
            [DataMember]
            public string EventTypeDescription { get; set; }

        }

        [DataContract]
        public class TestBed
        {
            [DataMember]
            public int TestBedId { get; set; }
            [DataMember]
            public string TestBedName { get; set; }
        }
    }
}
