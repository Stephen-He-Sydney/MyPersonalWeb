using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PersonalDemo.Data.Domain
{
    public class Profile
    {
        [Key]
        public int ProfileID { get; set; }
        public string Name { get; set; }
        public string Degree { get; set; }
        public System.DateTime Birth { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string CareerObjective { get; set; }
        public string VisaStatus { get; set; }
        public string Occupation { get; set; }
        public string EnglishLevel { get; set; }
        public string Certificate { get; set; }
        public string Street { get; set; }
        public string Suburb { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
