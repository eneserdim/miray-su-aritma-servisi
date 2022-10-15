using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ALPAY_WEP_PROJECT.Models.Siniflar
{
    public class ServiceArea
    {
        [Key]
        public int ID { get; set; }
        public string Tittle { get; set; }
        public string Images { get; set; }

        [AllowHtml]
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}