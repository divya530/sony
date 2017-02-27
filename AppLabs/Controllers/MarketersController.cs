using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppLabs.Models;

namespace AppLabs.Controllers
{
    [Authorize]
    public class MarketersController : Controller
    {
        private DBContext1 db = new DBContext1();

        // GET: Marketers
        public ActionResult Index()
        {
            return View(db.Marketers.ToList());
        }

        // GET: Marketers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marketer marketer = db.Marketers.Find(id);
            if (marketer == null)
            {
                return HttpNotFound();
            }
            return View(marketer);
        }

        // GET: Marketers/Create
        public ActionResult Create()
        {
            IEnumerable<SelectListItem> items = (from m in db.tblEmployees where m.IsInternalEmployee == false select m).AsEnumerable().Select(m => new SelectListItem  //_context1.Employees.Select(c =>new SelectListItem

            {

                Value = m.FirstName,
                Text = m.FirstName

            });
            // ViewData["items"] = items;

            ViewBag.Sai = items;
            IEnumerable<SelectListItem> items1 = (from m in db.tblEmployees where m.IsInternalEmployee == true select m).AsEnumerable().Select(m => new SelectListItem   //_context1.Employees.Select(c =>new SelectListItem

            {

                Value = m.FirstName,
                Text = m.FirstName

            });

            ViewBag.Name = items1;




            return View();
        }

        // POST: Marketers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save([Bind(Include = "Id,EmployerName,MarketerName,StartDate,Status,Close")] Marketer marketer)
        {
            if (ModelState.IsValid)
            {
                db.Marketers.Add(marketer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(marketer);
        }

        // GET: Marketers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marketer marketer = db.Marketers.Find(id);
            if (marketer == null)
            {
                return HttpNotFound();
            }
            return View(marketer);
        }

        // POST: Marketers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EmployerName,MarketerName,StartDate,Status,Close")] Marketer marketer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(marketer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(marketer);
        }

        // GET: Marketers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marketer marketer = db.Marketers.Find(id);
            if (marketer == null)
            {
                return HttpNotFound();
            }
            return View(marketer);
        }

        // POST: Marketers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Marketer marketer = db.Marketers.Find(id);
            db.Marketers.Remove(marketer);
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
