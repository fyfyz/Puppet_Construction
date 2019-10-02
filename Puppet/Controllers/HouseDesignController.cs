using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Puppet.Models;

namespace Puppet.Controllers
{
    public class HouseDesignController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: HouseDesign
        public ActionResult Index()
        {

            return View(db.HouseDesigns.ToList());

        }

        [HttpPost]
        public ActionResult Calculator(string width, string length, string floor)
        {
            int a = Convert.ToInt32(width);
            int b = Convert.ToInt32(length);
            int c = Convert.ToInt32(floor);
            double result = a * c * b * 1.35;
            int resultInt = (int)result;
            ViewBag.Result = resultInt;
            return View();

        }

        public ActionResult Calculator()
        {
            return View();

        }

        //public ActionResult CustomerView()
        //{
        //    return View(db.HouseDesigns.ToList());
        //}

        public ActionResult CustomerView(int? id)
        {
            // fetch image data from database
            var houseDesign = db.HouseDesigns.Include(s => s.Files).ToList();
            return View(houseDesign);
        }

        // GET: HouseDesign/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HouseDesign houseDesign = db.HouseDesigns.Include(s => s.Files).SingleOrDefault(s => s.ID == id);
            if (houseDesign == null)
            {
                return HttpNotFound();
            }
            return View(houseDesign);
        }

        // GET: HouseDesign/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HouseDesign/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,BuildingType,Dimension,Description,Price")] HouseDesign houseDesign, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    var avatar = new File
                    {
                        FileName = System.IO.Path.GetFileName(upload.FileName),
                        FileType = FileType.Avatar,
                        ContentType = upload.ContentType
                    };
                    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    {
                        avatar.Content = reader.ReadBytes(upload.ContentLength);
                    }
                    houseDesign.Files = new List<File> { avatar };
                }
                db.HouseDesigns.Add(houseDesign);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(houseDesign);
        }

        // GET: HouseDesign/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HouseDesign houseDesign = db.HouseDesigns.Find(id);
            if (houseDesign == null)
            {
                return HttpNotFound();
            }
            return View(houseDesign);
        }

        // POST: HouseDesign/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,BuildingType,Dimension,Description,Price")] HouseDesign houseDesign)
        {
            if (ModelState.IsValid)
            {
                db.Entry(houseDesign).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(houseDesign);
        }

        // GET: HouseDesign/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HouseDesign houseDesign = db.HouseDesigns.Find(id);
            if (houseDesign == null)
            {
                return HttpNotFound();
            }
            return View(houseDesign);
        }

        // POST: HouseDesign/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HouseDesign houseDesign = db.HouseDesigns.Find(id);
            db.HouseDesigns.Remove(houseDesign);
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
