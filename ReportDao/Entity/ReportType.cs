namespace ReportDao.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ReportType")]
    public partial class ReportType
    {
        public int ReportTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string ReportTypeText { get; set; }
    }
}
