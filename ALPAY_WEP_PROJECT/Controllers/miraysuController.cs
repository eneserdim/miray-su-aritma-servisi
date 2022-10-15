using ALPAY_WEP_PROJECT.Models.Siniflar;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ALPAY_WEP_PROJECT.Controllers
{
    public class miraysuController : Controller
    {
        // GET: miraysu
        Context c = new Context();
        public ActionResult anasayfa()
        {
            return View();
        }
        public ActionResult hakkimizda()
        {
            var listele = c.Abouts.ToList(); 
            return View(listele);
        }
        public ActionResult iletisim()
        {
            return View();
        }
        public PartialViewResult anasayfaurunler(int sayfa = 1)
        {
            var listele = c.Services.OrderByDescending(m => m.ID).Where(x => x.IsActive == true).ToPagedList(sayfa, 3);
            return PartialView(listele);
        }

        public PartialViewResult anasayfahakkimizda()
        {
            var listele = c.Abouts.ToList();
            return PartialView(listele);
        }

        public ActionResult urunlerimiz(int sayfa = 1)
        {
            var listele = c.Products.OrderByDescending(m => m.ID).Where(x => x.IsActive == true).ToPagedList(sayfa, 9);
            return View(listele);
        }

        public ActionResult urundetay(string id, string ad)
        {
            int id2 = Convert.ToInt32(id);
            var degerler = c.Products.Where(x => x.ID == id2).ToList();
            return View(degerler);
        }

        public ActionResult hizmetbolgeleri(int id)
        {
            var degerler = c.ServiceAreas.Where(x => x.ID == id).ToList();
            return View(degerler);
        }
    }
}