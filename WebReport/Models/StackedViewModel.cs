﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebReport.Models
{
    public class StackedViewModel
    {
        public string StackedDimensionOne { get; set; }
        public List<SimpleReportViewModel> LstData { get; set; }
    }
}
