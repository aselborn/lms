using ReportViewer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFReportViewer.Model
{
    public class RigObject
    {
        private List<Category> RigCategories = new List<Category>();
        private List<RigRecord> _rigRecords;
        public List<RigRecord> RigData
        {
            get
            {
                return BuildMockdata;
                //return GetRecords;
            }
        }
        
        private List<RigRecord> GetRecords
        {
            get
            {
                List<RigRecord> records = new List<RigRecord>();

                RigRecord record = new RigRecord();
                record.CategoryId = 5;
                record.EventName = "Driftstopp";
                record.EventTime = DateTime.Parse("2017-10-15 10:28:00");

                RigRecord record1 = new RigRecord();
                record1.CategoryId = 5;
                record1.EventName = "Service";
                record1.EventTime = DateTime.Parse("2017-10-16 12:30:00");


                RigRecord record2 = new RigRecord();
                record2.CategoryId = 5;
                record2.EventName = "Driftstopp";
                record2.EventTime = DateTime.Parse("2017-09-15 21:30:00");


                RigRecord record3 = new RigRecord();
                record3.CategoryId = 5;
                record3.EventName = "Bugg";
                record3.EventTime = DateTime.Parse("2017-01-23 13:44:00");

                records.Add(record);
                records.Add(record1);
                records.Add(record2);
                records.Add(record3);

                return records;
            }
        }

       
        private List<RigRecord> BuildMockdata
        {
            get
            {
                List<Category> lstCategory = new List<Category>();
                lstCategory.Add(new Category { CategoryId = 1, CategoryName = "DriftStopp" });
                lstCategory.Add(new Category { CategoryId = 2, CategoryName = "Strömavbrott" });
                lstCategory.Add(new Category { CategoryId = 3, CategoryName = "Bugg" });
                lstCategory.Add(new Category { CategoryId = 4, CategoryName = "Okänt" });
                lstCategory.Add(new Category { CategoryId = 5, CategoryName = "Handhavande" });

                List<RigRecord> records = new List<RigRecord>();

                
                for (int n = 1; n <= 200; n++)
                {

                    
                    RigRecord record = new RigRecord();

                    

                    record.CategoryId = RandomGenerator.GetRandom(1, lstCategory.Count); ;
                    record.EventName = lstCategory.First(p => p.CategoryId == record.CategoryId).CategoryName;
                    record.EventTime = RandomGenerator.GetRandomDate(DateTime.Now.AddDays(-40), DateTime.Now);

                    records.Add(record);

                    Console.WriteLine($"{record.CategoryId} - {record.EventTime}");
                }

                return records;
            }
            

        }

       

        
    }
}
