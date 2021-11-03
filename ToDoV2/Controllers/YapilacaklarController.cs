using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ToDoV2.Models;

namespace ToDoV2.Controllers
{
    public class YapilacaklarController : Controller
    {
        private DoesContext db = new DoesContext();

        public ActionResult List(int? id)
        {
            var yapilacaklar = db.Yapilacaklars
                .Where(i => i.IsDone == true)
                .Select(i => new yapilacakmodel()
                {
                    Id = i.Id,
                    IsDone = i.IsDone,
                    EklenmeTarihi = i.EklenmeTarihi,
                    Yapilacak = i.Yapilacak.Length > 30 ? i.Yapilacak.Substring(0, 100) + "..." : i.Yapilacak,
                    CategoryId = i.CategoryId
                }).AsQueryable();


            if (id!=null)
            {
                yapilacaklar = yapilacaklar.Where(i => i.CategoryId == id);
            }


            return View(yapilacaklar.ToList());
        }



        // GET: Yapilacaklar
        public ActionResult Index()
        {
            var yapilacaklar = db.Yapilacaklars.Include(b => b.Kategori).OrderByDescending(i => i.EklenmeTarihi);
            return View(yapilacaklar.ToList());
        }

        // GET: Yapilacaklar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yapilacaklar yapilacaklar = db.Yapilacaklars.Find(id);
            if (yapilacaklar == null)
            {
                return HttpNotFound();
            }
            return View(yapilacaklar);
        }

        // GET: Yapilacaklar/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Kategoriler, "Id", "KategoriAdi");
            return View();
        }

        // POST: Yapilacaklar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Yapilacak,ekrangoruntusu,IsDetayi,IsDone,CategoryId")] Yapilacaklar yapilacaklar)
        {
            if (ModelState.IsValid)
            {
                yapilacaklar.EklenmeTarihi = DateTime.Now;
                db.Yapilacaklars.Add(yapilacaklar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(yapilacaklar);
        }

        // GET: Yapilacaklar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yapilacaklar yapilacaklar = db.Yapilacaklars.Find(id);
            if (yapilacaklar == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Kategoriler, "Id", "KategoriAdi", yapilacaklar.CategoryId);
            return View(yapilacaklar);
        }

        // POST: Yapilacaklar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Yapilacak,ekrangoruntusu,IsDone,CategoryId,IsDetayi")] Yapilacaklar yapilacaklar)
        {
            if (ModelState.IsValid)
            {
                var entity = db.Yapilacaklars.Find(yapilacaklar.Id);
                if (entity != null)
                {
                    entity.Yapilacak = yapilacaklar.Yapilacak;
                    entity.ekrangoruntusu = yapilacaklar.ekrangoruntusu;
                    entity.Kategori = yapilacaklar.Kategori;
                    entity.IsDone = yapilacaklar.IsDone;
                    entity.CategoryId = yapilacaklar.CategoryId;
                    db.SaveChanges();

                    TempData["yapilacaklar"] = entity;

                    return RedirectToAction("Index");
                }

            }
            ViewBag.CategoryId = new SelectList(db.Kategoriler, "Id", "KategoriAdi",yapilacaklar.CategoryId);
            return View(yapilacaklar);
        }

        // GET: Yapilacaklar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yapilacaklar yapilacaklar = db.Yapilacaklars.Find(id);
            if (yapilacaklar == null)
            {
                return HttpNotFound();
            }
            return View(yapilacaklar);
        }

        // POST: Yapilacaklar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Yapilacaklar yapilacaklar = db.Yapilacaklars.Find(id);
            db.Yapilacaklars.Remove(yapilacaklar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
