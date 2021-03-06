using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Day_n_Night.Models;
using IdentitySample.Models;

namespace Day_n_Night.Controllers
{
    public class ResidencesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Residences
        public ActionResult Index()
        {
            var residences = db.Residences.Include(r => r.Room);
            return View(residences.ToList());
        }

        // GET: Residences/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Residence residence = db.Residences.Find(id);
            if (residence == null)
            {
                return HttpNotFound();
            }
            return View(residence);
        }

        // GET: Residences/Create
        public ActionResult Create()
        {
            ViewBag.RoomNum = new SelectList(db.Rooms, "RoomNum", "DefualtImage");
            return View();
        }

        // POST: Residences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ResID,DefualtImage,Image,ImageName,RoomNum,ResName,Open,Close")] Residence residence)
        {
            if (ModelState.IsValid)
            {
                db.Residences.Add(residence);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoomNum = new SelectList(db.Rooms, "RoomNum", "DefualtImage", residence.RoomNum);
            return View(residence);
        }

        // GET: Residences/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Residence residence = db.Residences.Find(id);
            if (residence == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoomNum = new SelectList(db.Rooms, "RoomNum", "DefualtImage", residence.RoomNum);
            return View(residence);
        }

        // POST: Residences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ResID,DefualtImage,Image,ImageName,RoomNum,ResName,Open,Close")] Residence residence)
        {
            if (ModelState.IsValid)
            {
                db.Entry(residence).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoomNum = new SelectList(db.Rooms, "RoomNum", "DefualtImage", residence.RoomNum);
            return View(residence);
        }

        // GET: Residences/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Residence residence = db.Residences.Find(id);
            if (residence == null)
            {
                return HttpNotFound();
            }
            return View(residence);
        }

        // POST: Residences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Residence residence = db.Residences.Find(id);
            db.Residences.Remove(residence);
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
