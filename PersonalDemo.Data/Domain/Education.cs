using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PersonalDemo.Data.Domain
{
    public class Education
    {
        [Key]
        public int EducationID { get; set; }
        public string CollegeName { get; set; }
        public string Degree { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
    }
}
