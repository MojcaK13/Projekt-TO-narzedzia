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
    public class WynikisController : Controller
    {
        private BiathlonDBEntities db = new BiathlonDBEntities();

        // GET: Wynikis
        public ActionResult Index()
        {
            var wyniki = db.Wyniki.Include(w => w.TypStartu).Include(w => w.Zawodnik1);
            return View(wyniki.ToList());
        }

        // GET: Wynikis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wyniki wyniki = db.Wyniki.Find(id);
            if (wyniki == null)
            {
                return HttpNotFound();
            }
            return View(wyniki);
        }

        // GET: Wynikis/Create
        public ActionResult Create()
        {
            ViewBag.RodzajStartu = new SelectList(db.TypStartu, "NrTypu", "NazwaTypu");
            ViewBag.Zawodnik = new SelectList(db.Zawodnik, "NrZawodnika", "Nazwa");
            return View();
        }

        // POST: Wynikis/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NrWyniku,Data,MiejsceZawodow,RodzajStartu,MiejsceZajete,Zawodnik,IloscPudel,Czas,RangaZawodow")] Wyniki wyniki)
        {
            if (ModelState.IsValid)
            {
                db.Wyniki.Add(wyniki);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RodzajStartu = new SelectList(db.TypStartu, "NrTypu", "NazwaTypu", wyniki.RodzajStartu);
            ViewBag.Zawodnik = new SelectList(db.Zawodnik, "NrZawodnika", "Nazwa", wyniki.Zawodnik);
            return View(wyniki);
        }

        // GET: Wynikis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wyniki wyniki = db.Wyniki.Find(id);
            if (wyniki == null)
            {
                return HttpNotFound();
            }
            ViewBag.RodzajStartu = new SelectList(db.TypStartu, "NrTypu", "NazwaTypu", wyniki.RodzajStartu);
            ViewBag.Zawodnik = new SelectList(db.Zawodnik, "NrZawodnika", "Nazwa", wyniki.Zawodnik);
            return View(wyniki);
        }

        // POST: Wynikis/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NrWyniku,Data,MiejsceZawodow,RodzajStartu,MiejsceZajete,Zawodnik,IloscPudel,Czas,RangaZawodow")] Wyniki wyniki)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wyniki).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RodzajStartu = new SelectList(db.TypStartu, "NrTypu", "NazwaTypu", wyniki.RodzajStartu);
            ViewBag.Zawodnik = new SelectList(db.Zawodnik, "NrZawodnika", "Nazwa", wyniki.Zawodnik);
            return View(wyniki);
        }

        // GET: Wynikis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wyniki wyniki = db.Wyniki.Find(id);
            if (wyniki == null)
            {
                return HttpNotFound();
            }
            return View(wyniki);
        }

        // POST: Wynikis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Wyniki wyniki = db.Wyniki.Find(id);
            db.Wyniki.Remove(wyniki);
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
