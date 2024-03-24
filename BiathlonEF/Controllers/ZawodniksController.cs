using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BiathlonEF.Models;

namespace BiathlonEF.Controllers
{
    public class ZawodniksController : Controller
    {
        private BiathlonDBEntities db = new BiathlonDBEntities();

        // GET: Zawodniks
        public ActionResult Index()
        {
            return View(db.Zawodnik.ToList());
        }

        // GET: Zawodniks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zawodnik zawodnik = db.Zawodnik.Find(id);
            if (zawodnik == null)
            {
                return HttpNotFound();
            }
            return View(zawodnik);
        }

        // GET: Zawodniks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Zawodniks/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NrZawodnika,Nazwa,Kraj")] Zawodnik zawodnik)
        {
            if (ModelState.IsValid)
            {
                db.Zawodnik.Add(zawodnik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(zawodnik);
        }

        // GET: Zawodniks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zawodnik zawodnik = db.Zawodnik.Find(id);
            if (zawodnik == null)
            {
                return HttpNotFound();
            }
            return View(zawodnik);
        }

        // POST: Zawodniks/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NrZawodnika,Nazwa,Kraj")] Zawodnik zawodnik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zawodnik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(zawodnik);
        }

        // GET: Zawodniks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zawodnik zawodnik = db.Zawodnik.Find(id);
            if (zawodnik == null)
            {
                return HttpNotFound();
            }
            return View(zawodnik);
        }

        // POST: Zawodniks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Zawodnik zawodnik = db.Zawodnik.Find(id);
            db.Zawodnik.Remove(zawodnik);
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
