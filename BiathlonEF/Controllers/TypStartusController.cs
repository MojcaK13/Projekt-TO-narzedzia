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
    public class TypStartusController : Controller
    {
        private BiathlonDBEntities db = new BiathlonDBEntities();

        // GET: TypStartus
        public ActionResult Index()
        {
            return View(db.TypStartu.ToList());
        }

        // GET: TypStartus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypStartu typStartu = db.TypStartu.Find(id);
            if (typStartu == null)
            {
                return HttpNotFound();
            }
            return View(typStartu);
        }

        // GET: TypStartus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TypStartus/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NrTypu,NazwaTypu,Dystans")] TypStartu typStartu)
        {
            if (ModelState.IsValid)
            {
                db.TypStartu.Add(typStartu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(typStartu);
        }

        // GET: TypStartus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypStartu typStartu = db.TypStartu.Find(id);
            if (typStartu == null)
            {
                return HttpNotFound();
            }
            return View(typStartu);
        }

        // POST: TypStartus/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NrTypu,NazwaTypu,Dystans")] TypStartu typStartu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typStartu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(typStartu);
        }

        // GET: TypStartus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypStartu typStartu = db.TypStartu.Find(id);
            if (typStartu == null)
            {
                return HttpNotFound();
            }
            return View(typStartu);
        }

        // POST: TypStartus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TypStartu typStartu = db.TypStartu.Find(id);
            db.TypStartu.Remove(typStartu);
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
