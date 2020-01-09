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
    public class DepartmanController : Controller
    {
        private TelefonRehberiDbContext db = new TelefonRehberiDbContext();
        
        public ActionResult Index()
        {           
            return View(db.Departmanlar.ToList());
        }
       
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departman departman = db.Departmanlar.Find(id);
            if (departman == null)
            {
                return HttpNotFound();
            }
            return View(departman);
        }
       
        public ActionResult Create()
        {
            return View();
        }
               
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DepartmanAdi")] Departman departman)
        {
            if (ModelState.IsValid)
            {
                db.Departmanlar.Add(departman);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(departman);
        }
       
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departman departman = db.Departmanlar.Find(id);
            if (departman == null)
            {
                return HttpNotFound();
            }
            return View(departman);
        }
               
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DepartmanAdi")] Departman departman)
        {
            if (ModelState.IsValid)
            {
                db.Entry(departman).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(departman);
        }
       
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departman departman = db.Departmanlar.Find(id);
            if (departman == null)
            {
                return HttpNotFound();
            }

            var calisanCount = db.Calisanlar.Where(c => c.Departman.Id == departman.Id).Count();

            if (calisanCount > 0)
            {
                return HttpNotFound();
            }

            return View(departman);
        }
       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Departman departman = db.Departmanlar.Find(id);
            db.Departmanlar.Remove(departman);
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
