using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ALPAY_WEP_PROJECT.Models.Siniflar
{
    public class About
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Images { get; set; }

        [AllowHtml]
        public string Description { get; set; }
    }
}