using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoV2.Models
{
    public class Yapilacaklar
    {
        public int Id { get; set; }
        public string Yapilacak { get; set; }
        public string ekrangoruntusu { get; set; }
        public bool IsDone { get; set; }
        public DateTime EklenmeTarihi { get; set; }
        public string IsDetayi { get; set; }

        public int CategoryId { get; set; }
        public Kategori Kategori { get; set; }


    }
}