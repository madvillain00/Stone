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
    public class Provider_DeliveryController : Controller
    {
        private StoreEntities db = new StoreEntities();

        // GET: Provider_Delivery
        public ActionResult Index()
        {
            var provider_Delivery = db.Provider_Delivery.Include(p => p.Delivery).Include(p => p.Provider);
            return View(provider_Delivery.ToList());
        }

        // GET: Provider_Delivery/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provider_Delivery provider_Delivery = db.Provider_Delivery.Find(id);
            if (provider_Delivery == null)
            {
                return HttpNotFound();
            }
            return View(provider_Delivery);
        }

        // GET: Provider_Delivery/Create
        public ActionResult Create()
        {
            ViewBag.DeliveryID = new SelectList(db.Delivery, "DeliveryID", "Data");
            ViewBag.ProviderID = new SelectList(db.Provider, "ProviderID", "NameOfOrganization");
            return View();
        }

        // POST: Provider_Delivery/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Provider_DeliveryID,DeliveryID,ProviderID")] Provider_Delivery provider_Delivery)
        {
            if (ModelState.IsValid)
            {
                db.Provider_Delivery.Add(provider_Delivery);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DeliveryID = new SelectList(db.Delivery, "DeliveryID", "Data", provider_Delivery.DeliveryID);
            ViewBag.ProviderID = new SelectList(db.Provider, "ProviderID", "NameOfOrganization", provider_Delivery.ProviderID);
            return View(provider_Delivery);
        }

        // GET: Provider_Delivery/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provider_Delivery provider_Delivery = db.Provider_Delivery.Find(id);
            if (provider_Delivery == null)
            {
                return HttpNotFound();
            }
            ViewBag.DeliveryID = new SelectList(db.Delivery, "DeliveryID", "Data", provider_Delivery.DeliveryID);
            ViewBag.ProviderID = new SelectList(db.Provider, "ProviderID", "NameOfOrganization", provider_Delivery.ProviderID);
            return View(provider_Delivery);
        }

        // POST: Provider_Delivery/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Provider_DeliveryID,DeliveryID,ProviderID")] Provider_Delivery provider_Delivery)
        {
            if (ModelState.IsValid)
            {
                db.Entry(provider_Delivery).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DeliveryID = new SelectList(db.Delivery, "DeliveryID", "Data", provider_Delivery.DeliveryID);
            ViewBag.ProviderID = new SelectList(db.Provider, "ProviderID", "NameOfOrganization", provider_Delivery.ProviderID);
            return View(provider_Delivery);
        }

        // GET: Provider_Delivery/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provider_Delivery provider_Delivery = db.Provider_Delivery.Find(id);
            if (provider_Delivery == null)
            {
                return HttpNotFound();
            }
            return View(provider_Delivery);
        }

        // POST: Provider_Delivery/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Provider_Delivery provider_Delivery = db.Provider_Delivery.Find(id);
            db.Provider_Delivery.Remove(provider_Delivery);
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
