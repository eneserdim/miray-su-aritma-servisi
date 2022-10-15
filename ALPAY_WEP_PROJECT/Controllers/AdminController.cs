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
    [Authorize]
    public class AdminController : Controller
    {
        // GET: Admin
        Context c = new Context();
        public ActionResult hizlimenu()
        {
            ViewBag.v1 = c.Products.Count();
            ViewBag.v2 = c.Blogs.Count();
            ViewBag.v3 = c.ServiceAreas.Count();
            var liste = new ListViewModel();
            liste.Blogs = c.Blogs.ToList();
            liste.Products = c.Products.ToList();
            return View(liste);
        }

        public PartialViewResult urunpartial(int sayfa = 1)
        {
            var listele = c.Products.OrderByDescending(m => m.ID).Where(x => x.IsActive == true).ToPagedList(sayfa, 5);
            return PartialView(listele);
        }
        public PartialViewResult bolgepartial(int sayfa = 1)
        {
            var listele = c.ServiceAreas.OrderByDescending(m => m.ID).Where(x => x.IsActive == true).ToPagedList(sayfa, 5);
            return PartialView(listele);
        }

        public PartialViewResult blogpartial(int sayfa = 1)
        {
            var listele = c.Blogs.OrderByDescending(m => m.BlogID).Where(x => x.IsActive == true).ToPagedList(sayfa, 5);
            return PartialView(listele);
        }

        public ActionResult HakkimizdaGetir(int id)
        {
            var deger = c.Abouts.Find(id);
            return View("HakkimizdaGetir",deger);
        }

        public ActionResult HakkimizdaGuncelle(About about, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                var uyg = c.Abouts.Find(about.ID);
                if (file != null && !string.IsNullOrEmpty(file.FileName))
                {
                    string path = Path.Combine(Server.MapPath("../Content/Images/"), Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    uyg.Images = "../Content/Images/" + file.FileName;
                }
                uyg.Title = about.Title;
                uyg.Description = about.Description;

            }
            c.SaveChanges();
            return RedirectToAction("hizlimenu");
        }

        public ActionResult hizmetlistele(int sayfa = 1)
        {
            var listele = c.Services.OrderBy(m => m.ID).Where(x => x.IsActive==true).ToPagedList(sayfa, 9);
            return View(listele);
        }

        public ActionResult hizmetdetay(int id)
        {
            var degerler = c.Services.Where(x => x.ID == id).ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult hizmetekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult hizmetekle(Service service, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Server.MapPath("~/Content/Images/"), Path.GetFileName(file.FileName));
                file.SaveAs(path);
                c.Services.Add(new Service
                {
                    ID = service.ID,
                    Tittle = service.Tittle,
                    Description = service.Description,
                    Images = "~/Content/Images/" + file.FileName,
                    IsActive = true

                });

            }
            c.SaveChanges();
            return RedirectToAction("hizmetlistele");
        }

        public ActionResult hizmetgetir(int id)
        {

            var hizmetler = c.Services.Find(id);
            return View("hizmetgetir", hizmetler);
        }
        public ActionResult hizmetguncelle(Service service, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                var uyg = c.Services.Find(service.ID);
                if (file != null && !string.IsNullOrEmpty(file.FileName))
                {
                    string path = Path.Combine(Server.MapPath("../Content/Images/"), Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    uyg.Images = "../Content/Images/" + file.FileName;
                }
                uyg.Tittle = service.Tittle;
                uyg.Description = service.Description;
                uyg.IsActive = true;
            }
            c.SaveChanges();
            return RedirectToAction("hizmetlistele");
        }
        public ActionResult hizmetsil(int id)
        {
            var deger = c.Services.Find(id);
            deger.IsActive = false;
            c.SaveChanges();
            return RedirectToAction("hizmetlistele");
        }

        public ActionResult urunlistele(int sayfa = 1) 
        {
            var listele = c.Products.OrderBy(m => m.ID).Where(x => x.IsActive == true).ToPagedList(sayfa, 9);
            return View(listele);
        }

        [HttpGet]
        public ActionResult yeniurun()
        {
            return View();
        }
        [HttpPost]
        public ActionResult yeniurun(Product product, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Server.MapPath("~/Content/Images/"), Path.GetFileName(file.FileName));
                file.SaveAs(path);
                c.Products.Add(new Product
                {
                    ID = product.ID,
                    Tittle = product.Tittle,
                    Description = product.Description,
                    Images = "~/Content/Images/" + file.FileName,
                    IsActive = true

                });

            }
            c.SaveChanges();
            return RedirectToAction("urunlistele");
        }

        public ActionResult urundetay(int id)
        {
            var degerler = c.Products.Where(x => x.ID == id).ToList();
            return View(degerler);
        }

        public ActionResult urungetir(int id)
        {

            var urunler = c.Products.Find(id);
            return View("urungetir", urunler);
        }
        public ActionResult urunguncelle(Product product, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                var uyg = c.Products.Find(product.ID);
                if (file != null && !string.IsNullOrEmpty(file.FileName))
                {
                    string path = Path.Combine(Server.MapPath("../Content/Images/"), Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    uyg.Images = "../Content/Images/" + file.FileName;
                }
                uyg.Tittle = product.Tittle;
                uyg.Description = product.Description;
                uyg.IsActive = true;
            }
            c.SaveChanges();
            return RedirectToAction("urunlistele");
        }

        public ActionResult urunsil(int id)
        {
            var deger = c.Products.Find(id);
            deger.IsActive = false;
            c.SaveChanges();
            return RedirectToAction("urunlistele");
        }


        public ActionResult bloglistele(int sayfa = 1)
        {
            ViewBag.v1 = c.Blogs.Count(); //Tüm Mesajlar
            ViewBag.v2 = c.Blogs.Where(x => x.IsActive == true).Count(); //Okunmuş Mesajlar
            ViewBag.v3 = c.Blogs.Where(x => x.IsActive == false).Count(); //Okunmamış Mesajlar
            var listele = c.Blogs.OrderBy(m => m.BlogID).Where(x => x.IsActive == true).ToPagedList(sayfa, 15);
            return View(listele);
        }

        [HttpGet]
        public ActionResult yeniblog()
        {
            return View();
        }
        [HttpPost]
        public ActionResult yeniblog(Blog blog, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Server.MapPath("~/Content/Images/"), Path.GetFileName(file.FileName));
                file.SaveAs(path);
                c.Blogs.Add(new Blog
                {
                    BlogID = blog.BlogID,
                    BlogBaslik = blog.BlogBaslik,
                    BlogAciklama = blog.BlogAciklama,
                    DateTime = DateTime.Parse(DateTime.Now.ToLongTimeString()),
                    IsActive = true,
                    BlogFotograf = "~/Content/Images/" + file.FileName,
                });

            }
            c.SaveChanges();
            return RedirectToAction("bloglistele");
        }

        //DELETE
        public ActionResult blogsil(int id)
        {
            var deger = c.Blogs.Find(id);
            deger.IsActive = false;
            c.SaveChanges();
            return RedirectToAction("bloglistele");
        }

        //UPDATE
        public ActionResult bloggetir(int id)
        {
            var uygulamadeger = c.Blogs.Find(id);
            return View("bloggetir", uygulamadeger);
        }
        [HttpPost]
        public ActionResult blogguncelle(Blog blog, HttpPostedFileBase dosya)
        {
            if (ModelState.IsValid)
            {
                var uyg = c.Blogs.Find(blog.BlogID);
                if (dosya != null && !string.IsNullOrEmpty(dosya.FileName))
                {
                    string path = Path.Combine(Server.MapPath("~/Content/Images/"), Path.GetFileName(dosya.FileName));
                    dosya.SaveAs(path);
                    uyg.BlogFotograf = "~/Content/Images/" + dosya.FileName;
                }
                uyg.BlogBaslik = blog.BlogBaslik;
                uyg.BlogAciklama = blog.BlogAciklama;
                uyg.IsActive = true;
                uyg.DateTime = DateTime.Parse(DateTime.Now.ToLongTimeString());
            }
            c.SaveChanges();
            return RedirectToAction("bloglistele");
        }


        public ActionResult bolgelistele(int sayfa = 1)
        {
            var listele = c.ServiceAreas.OrderBy(m => m.ID).Where(x => x.IsActive == true).ToPagedList(sayfa, 9);
            return View(listele);
        }

        public ActionResult bolgedetay(int id)
        {
            var degerler = c.ServiceAreas.Where(x => x.ID == id).ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult bolgeekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult bolgeekle(ServiceArea serviceArea, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Server.MapPath("~/Content/Images/"), Path.GetFileName(file.FileName));
                file.SaveAs(path);
                c.ServiceAreas.Add(new ServiceArea
                {
                    ID = serviceArea.ID,
                    Tittle = serviceArea.Tittle,
                    Description = serviceArea.Description,
                    Images = "~/Content/Images/" + file.FileName,
                    IsActive = true

                });

            }
            c.SaveChanges();
            return RedirectToAction("bolgelistele");
        }

        public ActionResult bolgegetir(int id)
        {

            var bolgeler = c.ServiceAreas.Find(id);
            return View("bolgegetir", bolgeler);
        }
        public ActionResult bolgeguncelle(ServiceArea serviceArea, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                var uyg = c.ServiceAreas.Find(serviceArea.ID);
                if (file != null && !string.IsNullOrEmpty(file.FileName))
                {
                    string path = Path.Combine(Server.MapPath("../Content/Images/"), Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    uyg.Images = "../Content/Images/" + file.FileName;
                }
                uyg.Tittle = serviceArea.Tittle;
                uyg.Description = serviceArea.Description;
                uyg.IsActive = true;
            }
            c.SaveChanges();
            return RedirectToAction("bolgelistele");
        }
        public ActionResult bolsil(int id)
        {
            var deger = c.ServiceAreas.Find(id);
            deger.IsActive = false;
            c.SaveChanges();
            return RedirectToAction("bolgelistele");
        }

        public ActionResult kullanicilistele()
        {
            var listele = c.Users.Where(x => x.IsActive == true).ToList();
            return View(listele);
        }
    }

}
