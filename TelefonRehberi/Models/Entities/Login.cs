using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TelefonRehberi.Models.Entities
{
    public class Login : Base
    {
        [Required(ErrorMessage = "E-Mail alanı boş geçilemez")]
        [EmailAddress(ErrorMessage = "EMail format hatası")]
        [Display(Name = "E-Posta")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Parola alanı boş geçilemez")]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Parola tekrar alanı boş geçilemez")]
        [Compare("Password", ErrorMessage = "Parolalar uyuşmuyor")]
        [Display(Name = "Şifre Tekrar")]
        [NotMapped]
        public string ConfrimPassword { get; set; }
    }
}