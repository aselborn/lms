﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using WCFReportLib.Mock;
using System.IO;
using ReportDao;
using System.Data;
using ReportDao.Entity;
using ReportDao.Model;
using static ReportDao.Model.Bridge;
using WCFReportLib.Model;

namespace WCFReportLib
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    // Lägg till /client:"WcfTestClient.exe" i command-startup
    public class ReportService : IReportService
    {

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/mock")]
        public RigObject GetRigobject()
        {
            return new RigObject();
        }

        [WebInvoke(Method = "GET",
           ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "version/")]
        public ReplyMessage Version()
        {
            return new ReplyMessage { id = 210, Reply = "Server OK." };
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/data")]
        public Stream GetDB()
        {
            ReportDaoManager daoManager = new ReportDaoManager();
            //var entities  = daoManager.GetEntities;
            return null;
            //return daoManager.GetRigRecords;

        }

        public Dictionary<DateTime, int> EventLogForRig(Bridge.EventType eventType, FilterParameters filterParameters)
        {
            ReportDaoManager daoManager = new ReportDaoManager();   
            Dictionary<DateTime, int> result = daoManager.GetEventLogByEvent(eventType, filterParameters);

            Console.WriteLine($"Accessing EventLogforRig: {result.Count.ToString()} records returned.");
            Console.WriteLine($"FilterParams: startDate ={filterParameters.StartDate} stopDate={filterParameters.StopDate} groupby={filterParameters.WithGrouping.ToString()}");

            return result;
        }


        public List<SimpleResultObject>EventLogDummy(Bridge.EventType eventType, FilterParameters filterParameters)
        {
            var lstModel = new List<SimpleResultObject>();
            Random rnd = new Random();

            lstModel.Add(new SimpleResultObject
            {
                text = "Technology",
                myValue = rnd.Next(10)

            });

            lstModel.Add(new SimpleResultObject
            {
                text = "Sales",
                myValue = rnd.Next(10)
            });
            lstModel.Add(new SimpleResultObject
            {
                text = "Marketing",
                myValue = rnd.Next(10)
            });
            lstModel.Add(new SimpleResultObject
            {
                text = "Human Resource",
                myValue = rnd.Next(10)
            });
            lstModel.Add(new SimpleResultObject
            {
                text = "Research and Development",
                myValue = rnd.Next(10)
            });
            lstModel.Add(new SimpleResultObject
            {
                text = "Acconting",
                myValue = rnd.Next(10)
            });
            lstModel.Add(new SimpleResultObject
            {
                text = "Support",
                myValue = rnd.Next(10)
            });
            lstModel.Add(new SimpleResultObject
            {
                text = "Logistics",
                myValue = rnd.Next(10)
            });

            return lstModel;
        }

        public DataSet GetDs()
        {
            ReportDaoManager daoManager = new ReportDaoManager();
            var p = daoManager.GetRigRecords;
            return null;
        }

        public List<Bridge.EventType> GetEventTypes()
        {
            ReportDaoManager daoManager = new ReportDaoManager();
            var result = daoManager.GetEventType();

            List<Bridge.EventType> list = new List<Bridge.EventType>();
            foreach(var v in result)
            {
                list.Add(new Bridge.EventType { EventTypeDescription = v.EventTypeDescription.Trim(), EventTypeId = v.EventTypeId, EventTypeSubId = v.EventTypeSubId });
            }

            
            return list;
        }

        public string GetDummy()
        {
            ReportDaoManager daoManager = new ReportDaoManager();
            var result = daoManager.GetEventType();
            string res = result[0].EventTypeDescription;
            return res;
        }

        public List<int> GetEventTypeInts()
        {
            ReportDaoManager daoManager = new ReportDaoManager();
            var result = daoManager.GetEventTypeInts();
            return result;
        }

       

        public List<Bridge.TestBed> GetTestBeds()
        {
            ReportDaoManager daoManager = new ReportDaoManager();
            return daoManager.GetTestBeds();
        }

        public List<Person> GetPerson()
        {
            Person p = new Person();
            p.Age = 45;
            p.Name = "Anders";

            List<Person> personList = new List<Person>();
            personList.Add(p);

            return personList;
            //return new List<Person>({ new Person() { Name = "Anders", Age = 45 } });
        }

        public List< Bridge.ResultObject > EventlogObjectForRig(Bridge.EventType eventType, FilterParameters filterParameters)
        {
            ReportDaoManager daoManager = new ReportDaoManager();
            List< Bridge.ResultObject > result = daoManager.EventlogObjectForRig(eventType, filterParameters);

            return result;
        }

        public bool AddNewTestbed(Bridge.TestBed newTestBed)
        {
            ReportDaoManager daoManager = new ReportDaoManager();
            return daoManager.AddNewTestbed(newTestBed);
        }

        public bool SaveDevice(Bridge.Device device)
        {
            ReportDaoManager daoManager = new ReportDaoManager();
            return daoManager.SaveDevice(device);
        }

        public List<Bridge.Device> GetDevices()
        {
            return new ReportDaoManager().GetDevices();
        }

        public bool SaveEventType(Bridge.EventType eventType)
        {
            return new ReportDaoManager().SaveEventType(eventType);
        }

        public bool SaveTestBed(Bridge.TestBed currentTestbed)
        {
            return new ReportDaoManager().SaveTestBed(currentTestbed);
            
        }
    }
}
