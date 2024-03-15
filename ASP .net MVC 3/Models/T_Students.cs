namespace ASP.net_MVC_3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class T_Students
    {
        [Display(Name = "آیدی")]
        [Required(ErrorMessage =" فیلد {0} نمیتواند خالی باشد")]
        public int id { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = " فیلد {0} نمیتواند خالی باشد")]
        [StringLength(20,MinimumLength = 2,ErrorMessage ="لطفا {0} را به صورت صحیح وارد کنید (حداقل 2 و حداکثر 20 کاراکتر)")]
        public string name { get; set; }

        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = " فیلد {0} نمیتواند خالی باشد")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "لطفا {0} را به صورت صحیح وارد کنید (حداقل 2 و حداکثر 20 کاراکتر)")]
        public string family { get; set; }

        [Display(Name = "سن")]
        [Required(ErrorMessage = " فیلد {0} نمیتواند خالی باشد")]
        public int age { get; set; }

        [Display(Name = "موبایل")]
        [Required(ErrorMessage = " فیلد {0} نمیتواند خالی باشد")]
        [RegularExpression( "(09)[0-9]{9}" , ErrorMessage = "لطفا {0} را به صورت صحیح وارد کنید")]
        public string phone { get; set; }

        [Display(Name = "ایمیل")]
        [EmailAddress(ErrorMessage ="لطفا {0} را به صورت صحیح وارد کنید")]
        public string email { get; set; }

        [Display(Name = "تاریخ عضویت")]
        [Required(ErrorMessage = " فیلد {0} نمیتواند خالی باشد")]
        public System.DateTime registerDate { get; set; }

        [Display(Name = "وضعیت")]
        [Required(ErrorMessage = " فیلد {0} نمیتواند خالی باشد")]
        public bool IsActive { get; set; }

        [Display(Name = "جنسیت")]
        public Nullable<bool> gender { get; set; }
    }
}