using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportDao.Model
{
    [Table("RigUse")]
    public class RigUse
    {
        [Key]
        public int RigUseId { get; set; }
        
        public int RigId { get; set; }
        public int RigTimeId { get; set; }
    }
}
