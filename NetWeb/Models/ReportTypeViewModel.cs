using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetWeb.Models
{
    public class ReportTypeViewModel
    {
        [Display(Name = "RapportTyp")]
        public int ReportTypeId { get; set; }
        public string SelectedReportTypeText { get; set; }
        public IEnumerable<SelectListItem> ListOfReportTypes { get; set; }
    }
}