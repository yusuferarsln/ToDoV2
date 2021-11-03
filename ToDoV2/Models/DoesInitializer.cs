using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ToDoV2.Models
{
    public class DoesInitializer: DropCreateDatabaseIfModelChanges<DoesContext>
    {
        protected override void Seed(DoesContext context)
        {
            List<Kategori> kategoriler = new List<Kategori>()
            {
                new Kategori() {KategoriAdi="Postman"},
                new Kategori() {KategoriAdi="MVC"},
            };
            foreach (var item in kategoriler)
            {
                context.Kategoriler.Add(item);
            
            }
            context.SaveChanges();

            List<Yapilacaklar> yapilacaklars = new List<Yapilacaklar>()
            {
                new Yapilacaklar() {Yapilacak="şu",IsDetayi="blbablalbalblabl",EklenmeTarihi=DateTime.Now.AddDays(-10), ekrangoruntusu="1.jpg",IsDone=true,CategoryId=1},
                new Yapilacaklar() {Yapilacak="bu",IsDetayi="blbablalbalblabsdasdasdasl",EklenmeTarihi=DateTime.Now.AddDays(-1), ekrangoruntusu="2.jpg",IsDone=false,CategoryId=1},
                new Yapilacaklar() {Yapilacak="cu",IsDetayi="blbablalbalblablsdasda",EklenmeTarihi=DateTime.Now.AddDays(-3), ekrangoruntusu="3.jpg",IsDone=false,CategoryId=2},
                new Yapilacaklar() {Yapilacak="şu",IsDetayi="blbablalbaasdadalblabl",EklenmeTarihi=DateTime.Now.AddDays(-10), ekrangoruntusu="1.jpg",IsDone=true,CategoryId=2},

            };
            foreach (var item in yapilacaklars)
            {
                context.Yapilacaklars.Add(item);
            }
            context.SaveChanges();


            base.Seed(context);
        }
    }
}