namespace ASP.net_MVC_3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class T_Students
    {
        #region Anno
        [Display(Name = "آیدی")]
        [Required(ErrorMessage = " فیلد {0} نمیتواند خالی باشد")] 
        #endregion
        public int Id { get; set; }
        #region Anno
        [Display(Name = "نام")]
        [Required(ErrorMessage = " فیلد {0} نمیتواند خالی باشد")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "لطفا {0} را به صورت صحیح وارد کنید (حداقل 2 و حداکثر 20 کاراکتر)")] 
        #endregion
        public string Name { get; set; }
        #region Anno
        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = " فیلد {0} نمیتواند خالی باشد")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "لطفا {0} را به صورت صحیح وارد کنید (حداقل 2 و حداکثر 20 کاراکتر)")] 
        #endregion
        public string Family { get; set; }
        #region Anno
        [Display(Name = "سن")]
        [Required(ErrorMessage = " فیلد {0} نمیتواند خالی باشد")] 
        #endregion
        public int Age { get; set; }
        #region Anno
        [Display(Name = "موبایل")]
        [Required(ErrorMessage = " فیلد {0} نمیتواند خالی باشد")]
        [RegularExpression("(09)[0-9]{9}", ErrorMessage = "لطفا {0} را به صورت صحیح وارد کنید")] 
        #endregion
        public string Phone { get; set; }
        #region Anno
        [Display(Name = "ایمیل")]
        [EmailAddress(ErrorMessage = "لطفا {0} را به صورت صحیح وارد کنید")] 
        #endregion
        public string Email { get; set; }
        #region Anno
        [Display(Name = "تاریخ عضویت")]
        [Required(ErrorMessage = " فیلد {0} نمیتواند خالی باشد")] 
        #endregion
        public System.DateTime RegisterDate { get; set; }
        #region Anno

        [Display(Name = "وضعیت")]
        [Required(ErrorMessage = " فیلد {0} نمیتواند خالی باشد")] 
        #endregion
        public bool IsActive { get; set; }
        #region Anno
        [Display(Name = "جنسیت")]
        [Required(ErrorMessage = " فیلد {0} نمیتواند خالی باشد")] 
        #endregion
        public Nullable<bool> Gender { get; set; }
        #region Anno
        [Display(Name = "تصویر")] 
        #endregion
        public string Image { get; set; }
        #region Anno
        [Display(Name = "رمز ورود")]
        [Required(ErrorMessage = " فیلد {0} نمیتواند خالی باشد")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "لطفا {0} را به صورت صحیح وارد کنید (حداقل 8 و حداکثر 20 کاراکتر)")] 
        #endregion
        public string Password { get; set; }
        #region Anno
        [Display(Name = "کد ملی")]
        [RegularExpression("[0-9]{10}", ErrorMessage = "لطفا {0} را به صورت صحیح وارد کنید")] 
        #endregion
        public string NationalCode { get; set; }
    }
}