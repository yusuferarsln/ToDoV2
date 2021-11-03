using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoV2.Models
{
    public class yapilacakmodel
    {
        public int Id { get; set; }
        public string Yapilacak { get; set; }
        public string ekrangoruntusu { get; set; }
        public bool IsDone { get; set; }
        public DateTime EklenmeTarihi { get; set; }
       
        public int CategoryId { get; set; }
    }
}