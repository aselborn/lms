using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportDao.Model
{
    [Table("Rigrecord")]
    public class RigRecord
    {
        [Key]
        public int RigRecordId { get; set; }

        [ForeignKey("Rig")]
        public int RigId { get; set; }
        
        public int CategoryId { get; set; }
        public DateTime EventTime { get; set; }
        public string EventName { get; set; }
        public virtual Rig Rig { get; set; }
    }
}
