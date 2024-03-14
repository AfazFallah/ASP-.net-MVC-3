namespace ASP.net_MVC_3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class T_Students
    {
        [Display(Name = "آیدی")]
        public int id { get; set; }

        [Display(Name = "نام")]
        public string name { get; set; }

        [Display(Name = "نام خانوادگی")]
        public string family { get; set; }

        [Display(Name = "سن")]
        public int age { get; set; }

        [Display(Name = "موبایل")]
        public string phone { get; set; }

        [Display(Name = "ایمیل")]
        public string email { get; set; }

        [Display(Name = "تاریخ عضویت")]
        public System.DateTime registerDate { get; set; }

        [Display(Name = "وضعیت")]
        public bool IsActive { get; set; }

        [Display(Name = "جنسیت")]
        public Nullable<bool> gender { get; set; }
    }
}