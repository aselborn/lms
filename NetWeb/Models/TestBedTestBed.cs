using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetWeb.Models
{
    public partial class TestBedTestBed
    {
        public int TestBedid { get; set; }
        public string TestBedDescription { get; set; }
    }

    public partial class TestbedSubTestbed
    {
        public int TestBedid { get; set; }
        public string TestBedDescription { get; set; }
    }
}