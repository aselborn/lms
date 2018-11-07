using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LMSWeb.Models
{
    public class DateSelectModel
    {
        [DataType(DataType.Date)]
        [Display(Name ="From Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FromDate { get; set; }

        [Display(Name ="Tom Date")]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}", ApplyFormatInEditMode =true)]
        [DataType(DataType.Date)]
        public DateTime TomDate { get; set; }
    }
}