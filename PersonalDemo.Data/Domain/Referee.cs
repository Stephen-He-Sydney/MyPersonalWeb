using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PersonalDemo.Data.Domain
{
    public class Referee
    {
        [Key]
        public int RefereeID { get; set; }
        public string Comment { get; set; }
        public string RefereeName { get; set; }
    }
}
