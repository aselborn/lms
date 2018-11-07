namespace ReportDao.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Item")]
    public partial class Item
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ItemId { get; set; }

        public int? ItemGroupId { get; set; }

        [Required]
        [StringLength(50)]
        public string ItemName { get; set; }

        public virtual ItemGroup ItemGroup { get; set; }
    }
}
