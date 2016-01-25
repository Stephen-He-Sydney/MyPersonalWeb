using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PersonalDemo.Data.EnumTypes
{
    public enum ProjectType
    {
        [Display(Name = "Backend & frontend Web–data-processing")]
        Web_dataProcessing = 1,

        [Display(Name = "Backend & frontend Web–e-commerce online transaction")]
        Web_ecommerce = 2,

        [Display(Name = "Backend & frontend Web–Backend & frontend Web–admin")]
        Web_admin = 3,

        [Display(Name = "Backend & frontend Web–social networking")]
        Web_socialNetworking = 4,

        [Display(Name = "iOS mobile based e-commerce platform")]
        iOS_ecommerce = 5
    }
}
