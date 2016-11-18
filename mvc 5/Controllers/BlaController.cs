using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mvc_5.Models;

namespace mvc_5.Controllers
{
    public class BlaController : Controller
    {
        private BlaContext db = new BlaContext();

        // GET: /Bla/
        public ActionResult Index()
        {
            return View(db.TestModels.ToList());
        }

        // GET: /Bla/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestModel testmodel = db.TestModels.Find(id);
            if (testmodel == null)
            {
                return HttpNotFound();
            }
            return View(testmodel);
        }

        // GET: /Bla/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Bla/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Name")] TestModel testmodel)
        {
            if (ModelState.IsValid)
            {
                db.TestModels.Add(testmodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(testmodel);
        }

        // GET: /Bla/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestModel testmodel = db.TestModels.Find(id);
            if (testmodel == null)
            {
                return HttpNotFound();
            }
            return View(testmodel);
        }

        // POST: /Bla/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Name")] TestModel testmodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testmodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(testmodel);
        }

        // GET: /Bla/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestModel testmodel = db.TestModels.Find(id);
            if (testmodel == null)
            {
                return HttpNotFound();
            }
            return View(testmodel);
        }

        // POST: /Bla/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TestModel testmodel = db.TestModels.Find(id);
            db.TestModels.Remove(testmodel);
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
