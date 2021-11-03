using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ToDoV2.Models
{
    public class DoesContext:DbContext
    {
        public DoesContext():base("doDb")
        {
            Database.SetInitializer(new DoesInitializer());
        }

        public DbSet<Yapilacaklar> Yapilacaklars { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
    }
}