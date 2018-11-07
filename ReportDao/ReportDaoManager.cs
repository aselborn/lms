using ReportDao.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ReportDao.Entity;
using System.Configuration;
using ReportDao.Util;
using System.Data.Entity.SqlServer;

namespace ReportDao
{
    public class ReportDaoManager
    {
        private ContextManager m_contextManager;
        private LMSContext m_LmsContext;

        private string _connectionString;
        private SqlConnection _connection;

        private List<Model.Rig> m_GetRig { get; }

        public List<Model.Rig> GetRig => m_contextManager.Rig.ToList();
        public List<Model.Category> GetCategories => m_contextManager.Category.ToList();

        public List<RigRecord> GetRigRecords => m_contextManager.RigRecord.ToList();

        public List<EventLog> GetEventLog() => m_LmsContext.DbEventLog.ToList();
        public List<EventType> GetEventType() => m_LmsContext.DbEventType.ToList();
        public List<Bridge.ReportType> GetReportTypes()
        {
            List<Bridge.ReportType> reportTypes = new List<Bridge.ReportType>();
            var reportT = m_LmsContext.DbReportType.ToList();
            foreach (ReportType report in reportT)
                reportTypes.Add(new Bridge.ReportType { ReportTypeId = report.ReportTypeId, ReportTypeText = report.ReportTypeText });
            return reportTypes;
        }

        private class MonthReply
        {
            public DateTime Month { get; set; }
            public int Quantity { get; set; }
        }

        private class WeekReply
        {
            public DateTime Week { get; set; }
            public int Quantity { get; set; }
        }

        private class DayReply
        {
            public DateTime Day { get; set; }
            public int Quantity { get; set; }
        }

        private SqlParameter[] createParameters(Bridge.FilterParameters filterParameters)
        {
            SqlParameter[] sqls = new SqlParameter[]
                    {
                        new SqlParameter
                        {
                            ParameterName ="@start",
                            Value =(DateTime)filterParameters.StartDate,
                            SqlDbType = System.Data.SqlDbType.DateTime,
                            Direction = System.Data.ParameterDirection.Input

                        },
                        new SqlParameter
                        {
                            ParameterName = "@stop",
                            Value =(DateTime)filterParameters.StopDate,
                            SqlDbType = System.Data.SqlDbType.DateTime,
                            Direction =System.Data.ParameterDirection.Input
                        },

                        new SqlParameter
                        {
                            ParameterName="@testBedId",
                            Value =filterParameters.TestBedId,
                            DbType = System.Data.DbType.Int32,
                            Direction =System.Data.ParameterDirection.Input
                        },
                        new SqlParameter
                        {
                            ParameterName="@eventTypeId",
                            Value =filterParameters.EventTypeId,
                            DbType = System.Data.DbType.Int32,
                            Direction =System.Data.ParameterDirection.Input
                        },
                        new SqlParameter
                        {
                            ParameterName="@grpBy",
                            Value =filterParameters.WithGrouping,
                            SqlDbType = System.Data.SqlDbType.VarChar,
                            Direction =System.Data.ParameterDirection.Input
                        }

                    };

            return sqls;
        }

        private string ProcedureToExecute(Bridge.FilterParameters filterParameters)
        {
            string qry = String.Empty;

            if (filterParameters.AllSubEvents)
            {
                qry = "p_EventCountByPeriodSubEvents @start, @stop, @testBedId, @eventTypeId, @grpBy";
            }
            else if (filterParameters.AllEvents)
            {
                qry = "p_EventCountByPeriodAllEvents @start, @stop, @testBedId, @eventTypeId, @grpBy";
            }
            else
            {
                qry = "p_EventCountByPeriod @start, @stop, @testBedId, @eventTypeId, @grpBy";
            }

            return qry;
        }

        public List<Bridge.ResultObject> EventlogObjectForRig(Bridge.FilterParameters filterParameters)
        {
            List<Bridge.ResultObject> result = new List<Bridge.ResultObject>();
            SqlParameter[] sqls = null;
            //DateTime.Now.ToString("MMMM", CultureInfo.InvariantCulture);

            sqls = createParameters(filterParameters);
            string qry = ProcedureToExecute(filterParameters);

            Console.WriteLine("#Printing some debug#");
            Console.WriteLine();
            Console.Write("p_EventCountByPeriod ");
            foreach (SqlParameter prm in sqls)
            {
                Console.Write(prm.Value.ToString() + " ");
            }

            Console.WriteLine();
            Console.WriteLine();

            switch (filterParameters.WithGrouping)
            {
                case Bridge.FilterParameters.GroupByOperator.Month:

                    List<MonthReply> replys = m_LmsContext.Database.SqlQuery<MonthReply>(qry, sqls).ToList();
                    foreach(MonthReply reply in replys)
                    {
                        result.Add(new Bridge.ResultObject { myValue = reply.Quantity, Text = reply.Month.ToString("MMMM") });
                    }

                    break;

                case Bridge.FilterParameters.GroupByOperator.Day:

                    List<DayReply> daysReply = m_LmsContext.Database.SqlQuery<DayReply>(qry, sqls).ToList();
                    foreach(DayReply reply in daysReply)
                    {
                        result.Add(new Bridge.ResultObject { myValue = reply.Quantity, Text = reply.Day.ToShortDateString() });
                    }
                    break;

                case Bridge.FilterParameters.GroupByOperator.Week:
                    
                    List<WeekReply> weekreplys = m_LmsContext.Database.SqlQuery<WeekReply>(qry, sqls).ToList();
                    foreach(WeekReply week in weekreplys)
                    {
                        result.Add(new Bridge.ResultObject { myValue = week.Quantity, Text = HelperUtil.GetIso8601WeekOfYear(week.Week).ToString() });
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

            _connectionString = "data source=D18SE-C0485NPQ\\SQLEXPRESS;initial catalog=LMS;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";// ConfigurationManager.ConnectionStrings["LMS"].ToString();
            _connection = new SqlConnection(_connectionString);
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

        public bool DeleteTestBed(Bridge.TestBed testBed)
        {
            int p = 0;
            var tbInUse = m_LmsContext.DbEventLog.FirstOrDefault(t => t.TestBedId == testBed.TestBedId);

            if (tbInUse == null)
            {
                var delItem = m_LmsContext.DbTestBed.FirstOrDefault(t => t.TestBedId == testBed.TestBedId);

                m_LmsContext.DbTestBed.Remove(delItem);
                p = m_LmsContext.SaveChanges();
            }

            return p > 0;
        }

        public bool DeleteTest(Bridge.Test test)
        {
            int p = 0;
            var tstInUse = m_LmsContext.DbEventLog.FirstOrDefault(t => t.TestId == test.TestId);

            if (tstInUse == null)
            {
                var delItem = m_LmsContext.DbTest.FirstOrDefault(t => t.TestId == test.TestId);

                m_LmsContext.DbTest.Remove(delItem);
                p = m_LmsContext.SaveChanges();
            }

            return p > 0;
        }

        public bool DeleteTestObject(Bridge.TestObject testObject)
        {
            int p = 0;
            var toInUse = m_LmsContext.DbEventLog.FirstOrDefault(t => t.TestObjectId == testObject.TestObjectId);

            if (toInUse == null)
            {
                var delItem = m_LmsContext.DbTestObject.FirstOrDefault(t => t.TestObjectId == testObject.TestObjectId);

                m_LmsContext.DbTestObject.Remove(delItem);
                p = m_LmsContext.SaveChanges();
            }

            return p > 0;
        }

        public bool SaveEventType(Bridge.EventType eventType)
        {
            int p = 0;
            var etExist = m_LmsContext.DbEventType.FirstOrDefault(e => e.EventTypeSubId == eventType.EventTypeSubId && e.EventTypeDescription == eventType.EventTypeDescription);

            if (etExist == null)
            {
                m_LmsContext.DbEventType.Add(
                new EventType
                {
                    EventTypeDescription = eventType.EventTypeDescription,
                    EventTypeSubId = eventType.EventTypeSubId,
                });

                p = m_LmsContext.SaveChanges();
            }
            return p > 0;
        }

        public bool DeleteEventType(Bridge.EventType eventType)
        {
            int p = 0;
            var etInUse = m_LmsContext.DbEventLog.FirstOrDefault(e => e.EventTypeId == eventType.EventTypeId);

            if (etInUse == null)
            {
                var delItem = m_LmsContext.DbEventType.FirstOrDefault(e => e.EventTypeId == eventType.EventTypeId);

                m_LmsContext.DbEventType.Remove(delItem);
                p = m_LmsContext.SaveChanges();
            }
            return p > 0;
        }

        public bool DeleteEventType_(Bridge.EventType eventType)
        {
            int result = 0;

            if (_connection.State != System.Data.ConnectionState.Open)
                _connection.Open();

            if (_connection.State == System.Data.ConnectionState.Open)
            {
                string sqlCommand = "";
                sqlCommand = $"Delete From EventType Where EventTypeId={eventType.EventTypeId}";

                if (!CheckIfEventTypeInUse(eventType))
                {
                    SqlCommand sql = new SqlCommand(sqlCommand, _connection);
                    result = sql.ExecuteNonQuery();
                }
            }

            //_connection.Close();

            return result > 0;
        }

        private bool CheckIfEventTypeInUse(Bridge.EventType eventType)
        {
            object result = 0;
            if (_connection.State != System.Data.ConnectionState.Open)
                _connection.Open();

            if (_connection.State == System.Data.ConnectionState.Open)
            {
                string sqlCommand = "";
                sqlCommand = $"Select count(*) From EventLog Where EventTypeId={eventType.EventTypeId}";

                SqlCommand sql = new SqlCommand(sqlCommand, _connection);
                result = sql.ExecuteScalar();
            }

            return (int)result > 0; 
        }

        public bool SaveEventLog(Bridge.EventLog eventLog)
        {
            int p = 0;
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

                p = m_LmsContext.SaveChanges();
            }
            else
            {
                m_LmsContext.DbEventLog.SingleOrDefault(l => l.EventLogId.Equals(eventLog.EventLogId)).EventLogUserId = Environment.UserName;
                m_LmsContext.DbEventLog.SingleOrDefault(l => l.EventLogId.Equals(eventLog.EventLogId)).EventValue = eventLog.EventValue;
                m_LmsContext.DbEventLog.SingleOrDefault(l => l.EventLogId.Equals(eventLog.EventLogId)).TestId = eventLog.TestId;
                m_LmsContext.DbEventLog.SingleOrDefault(l => l.EventLogId.Equals(eventLog.EventLogId)).Deleted = eventLog.Deleted;

                p = m_LmsContext.SaveChanges();
            }
            return p > 0;
        }

        public bool SaveEventLog2_(Bridge.EventLog eventLog)
        {
            int result = 0;

            if (_connection.State != System.Data.ConnectionState.Open)
                _connection.Open();

            if (_connection.State == System.Data.ConnectionState.Open)
            {
                string sqlCommand = "";

                if (eventLog.EventLogId == 0)
                {
                    sqlCommand = $"INSERT INTO EVENTLOG VALUES(...)";
                }
                else
                {
                    short deleted = eventLog.Deleted? (short)1 : (short)0;
                    sqlCommand = $"UPDATE EVENTLOG SET EventLogUserId='{Environment.UserName}', EventValue ={eventLog.EventValue}, Deleted={deleted} WHERE EventLogId={eventLog.EventLogId}";
                }

                SqlCommand sql = new SqlCommand(sqlCommand, _connection);
                result = sql.ExecuteNonQuery();
            }

            //_connection.Close();

            return result > 0;
        }


        public List<Bridge.Device> GetDevices()
        {
            List<Bridge.Device> result = new List<Bridge.Device>();
            var data = m_LmsContext.DbDevice.ToList();
            foreach (var item in data)
                result.Add(new Bridge.Device { DeviceName = item.DeviceName.Trim(), DeviceId = item.DeviceId });
            return result;
        }

        public bool SaveDevice(Bridge.Device device)
        {
            int p = 0;
            var dvExist = m_LmsContext.DbDevice.FirstOrDefault(d => d.DeviceName == device.DeviceName);

            if (dvExist == null)
            {
                m_LmsContext.DbDevice.Add(new Device { DeviceName = device.DeviceName });
                p = m_LmsContext.SaveChanges();
            }
            return p > 0;
        }

        public bool DeleteDevice(Bridge.Device device)
        {
            int p = 0;
            var dvInUse = m_LmsContext.DbEventLog.FirstOrDefault(t => t.DeviceId == device.DeviceId);

            if (dvInUse == null)
            {
                var delItem = m_LmsContext.DbDevice.FirstOrDefault(t => t.DeviceId == device.DeviceId);

                m_LmsContext.DbDevice.Remove(delItem);
                p = m_LmsContext.SaveChanges();
            }
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
        public List<Bridge.TestObject> GetTestObjects()
        {
            List<Bridge.TestObject> result = new List<Bridge.TestObject>();

            var data = m_LmsContext.DbTestObject.ToList();
            foreach (TestObject t in data)
            {
                result.Add(new Bridge.TestObject { TestObjectId = t.TestObjectId, TestObjectName = t.TestObjectIdName.Trim() });
            }
            return result;
        }
        public List<Bridge.UserObject> GetUserObjects()
        {
            List<Bridge.UserObject> result = new List<Bridge.UserObject>();

            var data = m_LmsContext.DbUserObject.ToList();
            foreach (UserObject u in data)
            {
                result.Add(new Bridge.UserObject { UserObjectId = u.UserObjectId, UserObjectName = u.UserObjectName.Trim(), UserObjectPassword = u.UserObjectPassword.Trim() });
            }
            return result;
        }
        public List<Bridge.EventLog> GetEventLogs()
        {
            List<Bridge.EventLog> result = new List<Bridge.EventLog>();

            var data = m_LmsContext.DbEventLog.ToList();

            foreach (EventLog t in data)
                //foreach (EventLog t in data.Where(t => t.EventType.EventTypeSubId.HasValue &&
                //                                    (t.EventType.EventTypeSubId == (int)Bridge.eEventType.FpActivity || 
                //                                    t.EventType.EventTypeSubId == (int)Bridge.eEventType.LpActivity ||
                //                                    t.EventType.EventTypeSubId == (int)Bridge.eEventType.RigStop ||
                //                                    t.EventType.EventTypeSubId == (int)Bridge.eEventType.PlannedMaintenance ||
                //                                    t.EventType.EventTypeSubId == (int)Bridge.eEventType.NoActivity)))
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
                                                ItemGroupId = t.ItemGroupId,
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
            int p = 0;
            var tbExist = m_LmsContext.DbTestBed.FirstOrDefault(e => e.TestBedName == testBed.TestBedName);

            if (tbExist == null)
            {
                m_LmsContext.DbTestBed.Add(new TestBed { TestBedName = testBed.TestBedName });
                p = m_LmsContext.SaveChanges();
            }
            return p > 0;
        }

        public bool AddNewTest(Bridge.Test test)
        {
            int p = 0;
            var tstExist = m_LmsContext.DbTest.FirstOrDefault(e => e.TestName == test.TestName && e.TestBedId == test.TestBedId);

            if (tstExist == null)
            {
                m_LmsContext.DbTest.Add(new Test { TestName = test.TestName, TestBedId = test.TestBedId });
                p = m_LmsContext.SaveChanges();
            }
            return p > 0;
        }

        public bool AddNewTestObject(Bridge.TestObject testObject)
        {
            int p = 0;
            var toExist = m_LmsContext.DbTestObject.FirstOrDefault(t => t.TestObjectIdName == testObject.TestObjectName);

            if (toExist == null)
            {
                m_LmsContext.DbTestObject.Add(new TestObject { TestObjectIdName = testObject.TestObjectName });
                p = m_LmsContext.SaveChanges();
            }
            return p > 0;
        }
    }
}
