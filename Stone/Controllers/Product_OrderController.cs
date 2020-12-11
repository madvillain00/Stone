using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Stone.Models;

namespace Stone.Controllers
{
    public class Product_OrderController : Controller
    {
        private StoreEntities db = new StoreEntities();

        // GET: Product_Order
        public ActionResult Index()
        {
            var product_Order = db.Product_Order.Include(p => p.Order).Include(p => p.Product);
            return View(product_Order.ToList());
        }

        // GET: Product_Order/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Order product_Order = db.Product_Order.Find(id);
            if (product_Order == null)
            {
                return HttpNotFound();
            }
            return View(product_Order);
        }

        // GET: Product_Order/Create
        public ActionResult Create()
        {
            ViewBag.OrderID = new SelectList(db.Order, "OrderID", "Data");
            ViewBag.ProductID = new SelectList(db.Product, "ProductID", "Name");
            return View();
        }

        // POST: Product_Order/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Product_OrderID,OrderID,ProductID")] Product_Order product_Order)
        {
            if (ModelState.IsValid)
            {
                db.Product_Order.Add(product_Order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OrderID = new SelectList(db.Order, "OrderID", "Data", product_Order.OrderID);
            ViewBag.ProductID = new SelectList(db.Product, "ProductID", "Name", product_Order.ProductID);
            return View(product_Order);
        }

        // GET: Product_Order/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Order product_Order = db.Product_Order.Find(id);
            if (product_Order == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrderID = new SelectList(db.Order, "OrderID", "Data", product_Order.OrderID);
            ViewBag.ProductID = new SelectList(db.Product, "ProductID", "Name", product_Order.ProductID);
            return View(product_Order);
        }

        // POST: Product_Order/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Product_OrderID,OrderID,ProductID")] Product_Order product_Order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product_Order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrderID = new SelectList(db.Order, "OrderID", "Data", product_Order.OrderID);
            ViewBag.ProductID = new SelectList(db.Product, "ProductID", "Name", product_Order.ProductID);
            return View(product_Order);
        }

        // GET: Product_Order/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Order product_Order = db.Product_Order.Find(id);
            if (product_Order == null)
            {
                return HttpNotFound();
            }
            return View(product_Order);
        }

        // POST: Product_Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product_Order product_Order = db.Product_Order.Find(id);
            db.Product_Order.Remove(product_Order);
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
