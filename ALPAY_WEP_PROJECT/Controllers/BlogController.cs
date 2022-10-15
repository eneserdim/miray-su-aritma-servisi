using ALPAY_WEP_PROJECT.Models.Siniflar;
using Microsoft.Web.Helpers;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ALPAY_WEP_PROJECT.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        Context c = new Context();

        [Route("~/BlogDetay/{BlogID}/{BlogBaslik}")]
        public ActionResult BlogListesi(int? SayfaNo)
        {
            int _sayfaNo = SayfaNo ?? 1;
            var BlogListesi = c.Blogs.OrderByDescending(m => m.BlogID).Where(x=>x.IsActive==true).ToPagedList<Blog>(_sayfaNo, 6);
            return View(BlogListesi);
        }

        public ActionResult BlogDetay(int id)
        {
            
            var degerler = c.Blogs.Where(x => x.BlogID == id).ToList();
            return View(degerler);
        }

        [Route("~/BlogDetay/{BlogID}/{BlogBaslik}")]
        public PartialViewResult BlogPartial2(int sayfa = 1)
        {
            var listele = c.Blogs.OrderBy(m => m.BlogID).Where(x => x.IsActive == true).ToPagedList(sayfa, 3);
            return PartialView(listele);
        }

    }
}