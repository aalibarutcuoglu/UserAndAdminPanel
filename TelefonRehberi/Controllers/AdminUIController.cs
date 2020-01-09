using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TelefonRehberi.Models;
using TelefonRehberi.Models.Context;
using TelefonRehberi.Models.Entities;

namespace TelefonRehberi.Controllers
{
    public class AdminUIController : Controller
    {
        private TelefonRehberiDbContext db = new TelefonRehberiDbContext();

        public ActionResult Home()
        {
            return View();
        }


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


        public ActionResult Create()
        {
            ViewBag.Departmanlar = db.Departmanlar.ToList();
            ViewBag.Yoneticiler = db.Calisanlar.Where(c => c.Gorev.GorevAdi == "Yonetici").Select(c => new { c.Id, Adi = c.Ad + " " + c.Soyad });

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Ad,Soyad,Telefon")] Calisan calisan)
        {
            if (ModelState.IsValid)
            {
                List<Departman> departman = new List<Departman>();
                foreach (var item in db.Departmanlar.ToList())
                {
                    departman.Add(new Departman { DepartmanAdi = item.DepartmanAdi, Id = item.Id });
                }

                ViewBag.Departman = departman;


                db.Calisanlar.Add(calisan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calisan calisan = db.Calisanlar.Find(id);
            if (calisan == null)
            {
                return HttpNotFound(); //Güncelleme işleminin gerçekleşmeyeceği durumda sayfayı 404'e düşürdüm.
            }
            return View(calisan);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Ad,Soyad,Telefon")] Calisan calisan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(calisan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(calisan);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calisan calisan = db.Calisanlar.Find(id);

            if (calisan == null)
            {
                return HttpNotFound();//Calisan id null olduğu takdirde 404'e sayfayı 404'e düşürdüm
            }

            var isYonetici = db.Calisanlar.Any(c => c.Yonetici.Id == id);

            if (isYonetici)
            {
                
                return HttpNotFound();//Silme işleminin gerçekleşmeyeceği durumda sayfayı 404'e düşürdüm
            }

            return View(calisan);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Calisan calisan = db.Calisanlar.Find(id);
            db.Calisanlar.Remove(calisan);
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
