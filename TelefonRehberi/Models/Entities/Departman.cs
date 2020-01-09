using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelefonRehberi.Models
{
    public class Departman : Base
    {
        public string DepartmanAdi{ get; set; }

        public List<Calisan> Calisan { get; set; }
    }
}