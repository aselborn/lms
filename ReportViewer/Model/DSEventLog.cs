using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFReportViewer.Model
{
    public class DSEventLog
    {
        private List<EventLogRecord> m_logRecord = new List<EventLogRecord>();

        public class EventLogRecord
        {
            public int count { get; set; }
            public DateTime date { get; set; }
        }
        
        public DSEventLog(Dictionary<DateTime, int> dictionary)
        { 
            foreach(var v in dictionary)
            {
                m_logRecord.Add(new EventLogRecord { count = v.Value, date = v.Key});
            }
        }


        public List<EventLogRecord> GetLogRecord => m_logRecord;

    }
}
