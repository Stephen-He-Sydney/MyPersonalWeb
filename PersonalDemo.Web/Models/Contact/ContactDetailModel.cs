using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalDemo.Web.Models.Contact
{
    public class ContactDetailModel
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Street { get; set; }
        public string Suburb { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}