using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TelefonRehberi.Models;
using TelefonRehberi.Models.Context;

namespace TelefonRehberi.Controllers
{
    public class PublicUIController : Controller
    {
        private TelefonRehberiDbContext db = new TelefonRehberiDbContext();
       
        public ActionResult Index()
        {
            return View(db.Calisanlar.ToList());
        }
       
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calisan calisan = db.Calisanlar.Find(id);
            if (calisan == null)
            {
                return HttpNotFound();
            }
            return View(calisan);
        }

       
    }
}
