using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ALPAY_WEP_PROJECT.Models.Siniflar
{
    public class Blog
    {
        [Key]
        public int BlogID { get; set; }
        public string BlogBaslik { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateTime { get; set; }

        [AllowHtml]
        public string BlogAciklama { get; set; }
        public string BlogFotograf { get; set; }
        public bool IsActive { get; set; }
    }
}