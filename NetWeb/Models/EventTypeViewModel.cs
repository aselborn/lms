﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetWeb.Models
{
    public class EventTypeViewModel
    {
        [Display(Name = "EventTypes")]
        public int EventTypeId { get; set; }
        public IEnumerable<SelectListItem> ListofEventTypes { get; set; }
    }
}