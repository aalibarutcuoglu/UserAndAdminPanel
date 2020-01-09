using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TelefonRehberi.Models.Entities;

namespace TelefonRehberi.Models
{
    public class Calisan : Base
    {
        [Required(ErrorMessage = "Ad Boş Bırakılamaz")]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Soyad Boş Bırakılamaz")]
        public string Soyad { get; set; }

        [Required(ErrorMessage = "Telefon Boş Bırakılamaz")]
        public string Telefon { get; set; }       

        public Gorev Gorev { get; set; }
        
        public Departman Departman { get; set; }
        
        public Calisan Yonetici { get; set; }
}
}