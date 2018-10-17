﻿using ReportDao.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ReportDao.Entity;
using System.Configuration;

namespace ReportDao
{
    public class ReportDaoManager
    {
        private ContextManager m_contextManager;
        private LMSContext m_LmsContext;

        private List<Model.Rig> m_GetRig { get; }

        public List<Model.Rig> GetRig => m_contextManager.Rig.ToList();
        public List<Model.Category> GetCategories => m_contextManager.Category.ToList();

        public List<RigRecord> GetRigRecords => m_contextManager.RigRecord.ToList();

        public List<EventLog> GetEventLog() => m_LmsContext.DbEventLog.ToList();
        public List<EventType> GetEventType() => m_LmsContext.DbEventType.ToList();

        private class MonthReply
        {
            public DateTime Month { get; set; }
            public int Quantity { get; set; }
        }

        public List<Bridge.ResultObject> EventlogObjectForRig(Bridge.EventType eventType, Bridge.FilterParameters filterParameters)
        {
            List<Bridge.ResultObject> result = new List<Bridge.ResultObject>();
            
            //DateTime.Now.ToString("MMMM", CultureInfo.InvariantCulture);
            switch (filterParameters.WithGrouping)
            {
                case Bridge.FilterParameters.GroupByOperator.Month:
                    var data = m_LmsContext.DbEventLog.GroupBy(p => p.EventLogTime.Month).ToList();

                    string qry = "P_EventCountByMonth @start";
                    SqlParameter[] sqls = new SqlParameter[]
                    {
                        new SqlParameter { ParameterName="@start", Value=DateTime.Now.AddDays(-2000), Direction= System.Data.ParameterDirection.Input}
                    };

                    List<MonthReply> replys = m_LmsContext.Database.SqlQuery<MonthReply>(qry, sqls).ToList();
                    foreach(MonthReply reply in replys)
                    {
                        result.Add(new Bridge.ResultObject { myValue = reply.Quantity, Text = reply.Month.ToString("MMMM") });
                    }

                    break;

                default:
                    break;
            }

            
            return result;
        }
        public Dictionary<DateTime, int> GetEventLogByEvent(Bridge.EventType eventType, Bridge.FilterParameters filterParamteters)
        {
            Dictionary<DateTime, int> result = new Dictionary<DateTime, int>();

            switch (filterParamteters.WithGrouping)
            {

                case Bridge.FilterParameters.GroupByOperator.Date:
                    var data = m_LmsContext.DbEventLog
                        .Where(p => p.EventTypeId.Equals(eventType.EventTypeId))
                        .Where(u => u.EventLogTime >= filterParamteters.StartDate && u.EventLogTime <= filterParamteters.StopDate)
                        .ToList()
                        .OrderBy(c => c.EventLogTime)
                        .GroupBy(o => o.EventLogTime.Date)
                        .ToList();


                    foreach (var v in data)
                    {
                        result.Add(v.Select(p => p.EventLogTime).First(), v.Select(p => p.EventLogTime).Count());
                    }
                    break;

                case Bridge.FilterParameters.GroupByOperator.Day:
                    var data2 = m_LmsContext.DbEventLog
                        .Where(p => p.EventTypeId.Equals(eventType.EventTypeId))
                        .Where(u => u.EventLogTime >= filterParamteters.StartDate && u.EventLogTime <= filterParamteters.StopDate)
                        .ToList()
                        .GroupBy(o => o.EventLogTime.Day)
                        .ToList();

                    foreach (var v in data2)
                    {
                        result.Add(v.Select(p => p.EventLogTime).First(), v.Select(p => p.EventLogTime).Count());
                    }
                    break;

                case Bridge.FilterParameters.GroupByOperator.Month:
                    var data3 = m_LmsContext.DbEventLog
                        .Where(p => p.EventTypeId.Equals(eventType.EventTypeId))
                        .Where(u => u.EventLogTime >= filterParamteters.StartDate && u.EventLogTime <= filterParamteters.StopDate)
                        .ToList()
                        .GroupBy(o => o.EventLogTime.Month)
                        .ToList();

                    foreach (var v in data3)
                    {
                        result.Add(v.Select(p => p.EventLogTime).First(), v.Select(p => p.EventLogTime).Count());
                    }
                    break;

                case Bridge.FilterParameters.GroupByOperator.Year:
                    var data4 = m_LmsContext.DbEventLog
                        .Where(p => p.EventTypeId.Equals(eventType.EventTypeId))
                        .Where(u => u.EventLogTime >= filterParamteters.StartDate && u.EventLogTime <= filterParamteters.StopDate)
                        .ToList()
                        .GroupBy(o => o.EventLogTime.Year)
                        .ToList();

                    foreach (var v in data4)
                    {
                        result.Add(v.Select(p => p.EventLogTime).First(), v.Select(p => p.EventLogTime).Count());
                    }
                    break;


                case Bridge.FilterParameters.GroupByOperator.Week:
                    break;


            }






            return result;
        }



        public ReportDaoManager()
        {
            m_LmsContext = new LMSContext();
        }

        #region MOCK
        private void BuildTableMock()
        {
            using (ContextManager ctx = new ContextManager())
            {
                Model.Category category1 = new Model.Category { CategoryName = "Givare" };
                Model.Category category1b = new Model.Category { CategoryName = "Tempgivare", CategorySubId = 1 };
                Model.Category category1c = new Model.Category { CategoryName = "Tryckgivare", CategorySubId = 1 };

                Model.Category category2 = new Model.Category { CategoryName = "Mjukvara" };
                Model.Category category2b = new Model.Category { CategoryName = "ComTest", CategorySubId = 2 };
                Model.Category category2c = new Model.Category { CategoryName = "Windows-bugg", CategorySubId = 2 };


                ctx.Category.Add(category1);
                ctx.Category.Add(category1b);
                ctx.Category.Add(category1c);

                ctx.Category.Add(category2);
                ctx.Category.Add(category2b);
                ctx.Category.Add(category2c);

                //ctx.SaveChanges();

                List<Model.RigRecord> records = new List<Model.RigRecord>();

                Model.RigRecord r1 = new Model.RigRecord { CategoryId = 1, EventName = "Hårdvarufel", EventTime = DateTime.Now };

                RigRecord r2 = new Model.RigRecord { CategoryId = 2, EventName = "ComTest-bug", EventTime = DateTime.Now };

                records.Add(r1);
                records.Add(r2);

                Model.Rig rigObject = new Model.Rig() { RigName = "Rig 1", RigRecordCollection = records };
                //Rig rigObject2 = new Rig() { RigName = "Rig 2", RigRecordCollection = records };
                //Rig rigObject3 = new Rig() { RigName = "Rig 3", RigRecordCollection = records };
                //Rig rigObject4 = new Rig() { RigName = "Rig 4", RigRecordCollection = records };

                ctx.Rig.Add(rigObject);
                //ctx.Rig.Add(rigObject2);
                //ctx.Rig.Add(rigObject3);
                //ctx.Rig.Add(rigObject4);

                ctx.SaveChanges();
            }
        }

        public bool SaveTestBed(Bridge.TestBed currentTestbed)
        {
            m_LmsContext.DbTestBed.SingleOrDefault(h => h.TestBedId.Equals(currentTestbed.TestBedId)).TestBedName = currentTestbed.TestBedName;
            int p = m_LmsContext.SaveChanges();


            return p > 0;
        }

        public bool SaveEventType(Bridge.EventType eventType)
        {
            m_LmsContext.DbEventType.Add(
                new EventType
                {
                    EventTypeDescription = eventType.EventTypeDescription,
                    EventTypeSubId = eventType.EventTypeSubId,
                });

            int p = m_LmsContext.SaveChanges();
            return p > 0;
        }

        public bool SaveEventLog(Bridge.EventLog eventLog)
        {
            if (eventLog.EventLogId == 0)
            {
                m_LmsContext.DbEventLog.Add(
                    new EventLog
                    {
                        EventLogTime = DateTime.Now,
                        EventLogUserId = Environment.UserName,
                        EventTypeId = eventLog.EventTypeId,
                        EventLogManualTime = eventLog.EventLogManualTime,
                        TestBedId = eventLog.TestBedId,
                        TestId = eventLog.TestId,
                        EventValue = eventLog.EventValue,
                        Deleted = eventLog.Deleted
                    });

                int p = m_LmsContext.SaveChanges();
                return p > 0;
            }
            else
            {
                m_LmsContext.DbEventLog.SingleOrDefault(l => l.EventLogId.Equals(eventLog.EventLogId)).EventLogUserId = Environment.UserName;
                m_LmsContext.DbEventLog.SingleOrDefault(l => l.EventLogId.Equals(eventLog.EventLogId)).EventValue = eventLog.EventValue;
                m_LmsContext.DbEventLog.SingleOrDefault(l => l.EventLogId.Equals(eventLog.EventLogId)).Deleted = eventLog.Deleted;

                int p = m_LmsContext.SaveChanges();
                return p > 0;
            }
        }

        public bool SaveEventLog2(Bridge.EventLog eventLog)
        {
            int result = 0;
            string connectionString = ConfigurationManager.ConnectionStrings["LMS"].ToString();
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            if (connection.State == System.Data.ConnectionState.Open)
            {
                string sqlCommand = "";

                if (eventLog.EventLogId == 0)
                {
                    sqlCommand = $"INSERT INTO EVENTLOG VALUES()";
                }
                else
                {
                    short deleted = eventLog.Deleted? (short)1 : (short)0;
                    sqlCommand = $"UPDATE EVENTLOG SET EventLogUserId='{Environment.UserName}', EventValue ={eventLog.EventValue}, Deleted={deleted} WHERE EventLogId={eventLog.EventLogId}";
                }

                SqlCommand sql = new SqlCommand(sqlCommand, connection);
                result = sql.ExecuteNonQuery();
            }

            connection.Close();

            return result > 0;
        }


        public List<Bridge.Device> GetDevices()
        {
            List<Bridge.Device> result = new List<Bridge.Device>();
            var data = m_LmsContext.DbDevice.ToList();
            foreach (var item in data)
                result.Add(new Bridge.Device { DeviceName = item.DeviceName, DeviceId = item.DeviceId });
            return result;
        }

        public bool SaveDevice(Bridge.Device device)
        {
            m_LmsContext.DbDevice.Add(new Device { DeviceName = device.DeviceName });
            int p = m_LmsContext.SaveChanges();
            return p > 0;
        }
        #endregion
        public List<Bridge.Test> GetTests()
        {
            List<Bridge.Test> result = new List<Bridge.Test>();

            var data = m_LmsContext.DbTest.ToList();
            foreach (Test t in data)
            {
                result.Add(new Bridge.Test { TestId = t.TestId, TestName = t.TestName.Trim(), TestObjectId = t.TestObjectId?? 0, TestBedId = t.TestBedId, TestModuleId = t.TestModuleId?? 0});
            }

            return result;
        }
        public List<Bridge.TestBed> GetTestBeds()
        {
            List<Bridge.TestBed> result = new List<Bridge.TestBed>();

            var data = m_LmsContext.DbTestBed.ToList();
            foreach (TestBed t in data)
            {
                result.Add(new Bridge.TestBed { TestBedId = t.TestBedId, TestBedName = t.TestBedName.Trim() });
            }

            return result;
        }
        public List<Bridge.EventLog> GetEventLogs()
        {
            List<Bridge.EventLog> result = new List<Bridge.EventLog>();

            var data = m_LmsContext.DbEventLog.ToList();
            foreach (EventLog t in data.Where(t => t.EventType.EventTypeSubId.HasValue &&
                                                    (t.EventType.EventTypeSubId == (int)Bridge.eEventType.FpActivity || 
                                                    t.EventType.EventTypeSubId == (int)Bridge.eEventType.LpActivity ||
                                                    t.EventType.EventTypeSubId == (int)Bridge.eEventType.RigStop ||
                                                    t.EventType.EventTypeSubId == (int)Bridge.eEventType.PlannedMaintenance ||
                                                    t.EventType.EventTypeSubId == (int)Bridge.eEventType.NoActivity)))
            {
                result.Add(new Bridge.EventLog { EventLogId = t.EventLogId,
                                                EventTypeDescription = t.EventType.EventTypeDescription.Trim(),
                                                EventLogTime = t.EventLogTime,
                                                EventLogUserId = t.EventLogUserId,
                                                EventTypeId = t.EventTypeId,
                                                EventTypeSubId = t.EventType.EventTypeSubId ?? 0,
                                                EventLogManualTime = t.EventLogManualTime,
                                                CustomerId = t.CustomerId,
                                                TestBedId = t.TestBedId,
                                                TestId = t.TestId,
                                                TestObjectId = t.TestObjectId,
                                                DeviceId = t.DeviceId,
                                                UserObjectId = t.UserObjectId,
                                                ItemId = t.ItemId,
                                                EventValue = t.EventValue,
                                                Deleted = t.Deleted?? false });
            }

            return result;
        }

        public List<object> GetEventTypeObjects()
        {
            List<Object> result = new List<object>();
            foreach (var v in m_LmsContext.DbEventType)
            {
                result.Add(v);
            }

            return result;
        }


        public List<int> GetEventTypeInts()
        {
            List<int> result = new List<int>();
            foreach (var v in m_LmsContext.DbEventType.ToList())
            {
                result.Add(v.EventTypeId);
            }

            return result;
        }

        public bool AddNewTestbed(Bridge.TestBed testBed)
        {
            m_LmsContext.DbTestBed.Add(new TestBed { TestBedName = testBed.TestBedName });
            int p = m_LmsContext.SaveChanges();

            return p > +0;
        }
    }
}
