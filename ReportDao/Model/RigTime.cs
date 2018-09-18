using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportDao.Model
{
    [Table("RigTime")]
    public class RigTime
    {
        [Key]
        public int RigTimeId { get; set; }
        
        public int RigId { get; set; }
        public string RigTimeDescription { get; set; }

    }
}
