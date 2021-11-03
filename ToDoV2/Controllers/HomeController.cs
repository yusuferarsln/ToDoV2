using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoV2.Models;

namespace ToDoV2.Controllers
{
    public class HomeController : Controller
    {
        private DoesContext context = new DoesContext();


        [HttpGet]
        public ActionResult ResimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ResimEkle(Yapilacaklar p)
        {





            return View();
        }


        public ActionResult Index()
        {
            var yapilacaklar = context.Yapilacaklars
                .Select(i => new yapilacakmodel()
                {
                    Id = i.Id,
                    IsDone = i.IsDone,
                    EklenmeTarihi = i.EklenmeTarihi,
                    Yapilacak = i.Yapilacak.Length > 30 ? i.Yapilacak.Substring(0, 100) + "..." : i.Yapilacak,
                })
                .Where(i => i.IsDone == true);

            


            return View(yapilacaklar.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}