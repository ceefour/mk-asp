using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mk_asp.Models;

namespace mk_asp.Controllers
{
    public class RestaurantModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RestaurantModels
        public ActionResult Index()
        {
            return View(db.RestaurantModels.ToList());
        }

        // GET: RestaurantModels/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestaurantModel restaurantModel = db.RestaurantModels.Find(id);
            if (restaurantModel == null)
            {
                return HttpNotFound();
            }
            return View(restaurantModel);
        }

        // GET: RestaurantModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RestaurantModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Address")] RestaurantModel restaurantModel)
        {
            if (ModelState.IsValid)
            {
                db.RestaurantModels.Add(restaurantModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(restaurantModel);
        }

        // GET: RestaurantModels/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestaurantModel restaurantModel = db.RestaurantModels.Find(id);
            if (restaurantModel == null)
            {
                return HttpNotFound();
            }
            return View(restaurantModel);
        }

        // POST: RestaurantModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Address")] RestaurantModel restaurantModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restaurantModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restaurantModel);
        }

        // GET: RestaurantModels/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestaurantModel restaurantModel = db.RestaurantModels.Find(id);
            if (restaurantModel == null)
            {
                return HttpNotFound();
            }
            return View(restaurantModel);
        }

        // POST: RestaurantModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            RestaurantModel restaurantModel = db.RestaurantModels.Find(id);
            db.RestaurantModels.Remove(restaurantModel);
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
