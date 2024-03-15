namespace ASP.net_MVC_3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class T_Students
    {
        [Display(Name = "آیدی")]
        [Required(ErrorMessage = " فیلد {0} نمیتواند خالی باشد")]
        public int Id { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = " فیلد {0} نمیتواند خالی باشد")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "لطفا {0} را به صورت صحیح وارد کنید (حداقل 2 و حداکثر 20 کاراکتر)")]
        public string Name { get; set; }

        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = " فیلد {0} نمیتواند خالی باشد")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "لطفا {0} را به صورت صحیح وارد کنید (حداقل 2 و حداکثر 20 کاراکتر)")]
        public string Family { get; set; }

        [Display(Name = "سن")]
        [Required(ErrorMessage = " فیلد {0} نمیتواند خالی باشد")]
        public int Age { get; set; }

        [Display(Name = "موبایل")]
        [Required(ErrorMessage = " فیلد {0} نمیتواند خالی باشد")]
        [RegularExpression("(09)[0-9]{9}", ErrorMessage = "لطفا {0} را به صورت صحیح وارد کنید")]
        public string Phone { get; set; }

        [Display(Name = "ایمیل")]
        [EmailAddress(ErrorMessage = "لطفا {0} را به صورت صحیح وارد کنید")]
        public string Email { get; set; }

        [Display(Name = "تاریخ عضویت")]
        [Required(ErrorMessage = " فیلد {0} نمیتواند خالی باشد")]
        public System.DateTime RegisterDate { get; set; }

        [Display(Name = "وضعیت")]
        [Required(ErrorMessage = " فیلد {0} نمیتواند خالی باشد")]
        public bool IsActive { get; set; }

        [Display(Name = "جنسیت")]
        public Nullable<bool> Gender { get; set; }

        [Display(Name = "عکس")]
        public string Image { get; set; }

        [Display(Name = "رمز ورود")]
        [Required(ErrorMessage = " فیلد {0} نمیتواند خالی باشد")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "کد ملی")]
        [RegularExpression("[0-9]{10}", ErrorMessage = "لطفا {0} را به صورت صحیح وارد کنید")]
        public string NationalCode { get; set; }
    }
}