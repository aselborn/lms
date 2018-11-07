using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LMSWeb.Models
{

    public class TestbedViewModel
    {
        [Display(Name = "TestBed")]
        public int TestBedId { get; set; }
        public IEnumerable<SelectListItem> ListofTestbeds { get; set; }
    }


}