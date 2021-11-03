using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoV2.Models
{
    public class Kategori
    {
        public int Id { get; set; }
        public string KategoriAdi { get; set; }
        
        public List<Yapilacaklar> Yapilacak { get; set; }
    }
}