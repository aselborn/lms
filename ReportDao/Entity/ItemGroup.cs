namespace ReportDao.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ItemGroup")]
    public partial class ItemGroup
    {
        public int ItemGroupId { get; set; }

        public int? ItemId { get; set; }
    }
}
