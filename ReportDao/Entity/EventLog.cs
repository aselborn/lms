namespace ReportDao.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EventLog")]
    public partial class EventLog
    {
        public int EventLogId { get; set; }

        public DateTime EventLogTime { get; set; }

        [StringLength(50)]
        public string EventLogUserId { get; set; }

        public int EventTypeId { get; set; }

        public DateTime? EventLogManualTime { get; set; }

        public int? CustomerId { get; set; }

        public int? TestBedId { get; set; }

        public int? TestId { get; set; }

        public int? TestObjectId { get; set; }

        public int? DeviceId { get; set; }

        public int? UserObjectId { get; set; }

        public int? ItemGroupId { get; set; }

        public int? EventValue { get; set; }

        public bool? Deleted { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Device Device { get; set; }

        public virtual EventType EventType { get; set; }

        public virtual ItemGroup ItemGroup { get; set; }

        public virtual Test Test { get; set; }

        public virtual TestBed TestBed { get; set; }

        public virtual TestObject TestObject { get; set; }

        public virtual UserObject UserObject { get; set; }
    }
}
