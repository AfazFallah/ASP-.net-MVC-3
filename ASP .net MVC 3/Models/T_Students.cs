namespace ASP.net_MVC_3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class T_Students
    {
        [Display(Name = "????")]
        public int id { get; set; }

        [Display(Name ="???")]
        public string name { get; set; }

        [Display(Name = "??? ????????")]
        public string family { get; set; }

        [Display(Name = "??")]
        public int age { get; set; }

        [Display(Name = "??????")]
        public string phone { get; set; }

        [Display(Name = "?????")]
        public string email { get; set; }

        [Display(Name = "????? ??? ???")]
        public System.DateTime registerDate { get; set; }

        [Display(Name = "?????")]
        public bool IsActive { get; set; }
    }
}
