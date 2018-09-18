using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportDao.Model
{
    [Table("Rig")]
    public class Rig
    {
        [Key]
        public int RigId { get; set; }
        public string RigName { get; set; }

        //public virtual RigRecord RigRecord { get; set; }
        public ICollection<RigRecord> RigRecordCollection { get; set; }

    }
}
