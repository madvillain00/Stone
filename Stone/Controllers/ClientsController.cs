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
    public class ClientsController : Controller
    {
        private StoreEntities db = new StoreEntities();

        // GET: Clients
        public ActionResult Index(string sortOrder, string searchString)
        {

            var clients = from s in db.Client
                          select s;


            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";
            ViewBag.AddressSortParm = sortOrder == "Address" ? "Address_desc" : "Address";
            ViewBag.PhoneSortParm = sortOrder == "Phone" ? "Phone_desc" : "Phone";
            ViewBag.EmailSortParm = sortOrder == "Email" ? "Email_desc" : "Email";

           

            if (!String.IsNullOrEmpty(searchString))
            {
                clients = clients.Where(s => s.Name.Contains(searchString) || s.Address.Contains(searchString) || s.Phone.Contains(searchString) || s.Email.Contains(searchString));

            }

            
            switch (sortOrder)
            {
                case "Name_desc":
                    clients = clients.OrderByDescending(s => s.Name);
                    break;
                case "Address":
                    clients = clients.OrderBy(s => s.Address);
                    break;
                case "Address_desc":
                    clients = clients.OrderByDescending(s => s.Address);
                    break;
                case "Phone":
                    clients = clients.OrderBy(s => s.Phone);
                    break;
                case "Phone_desc":
                    clients = clients.OrderByDescending(s => s.Phone);
                    break;
                case "Email":
                    clients = clients.OrderBy(s => s.Email);
                    break;
                case "Email_desc":
                    clients = clients.OrderByDescending(s => s.Email);
                    break;
                default:
                    clients = clients.OrderBy(s => s.Name);
                    break;
            }



            return View(clients.ToList());
        }

        // GET: Clients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Client.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClientID,Name,Address,Phone,Email")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Client.Add(client);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(client);
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Client.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClientID,Name,Address,Phone,Email")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(client);
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Client.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = db.Client.Find(id);
            db.Client.Remove(client);
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
