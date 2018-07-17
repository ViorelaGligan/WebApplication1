using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BankAccountsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BankAccounts
        public ActionResult Index(string sortOrder, string option, string search, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.IBANSortParm = String.IsNullOrEmpty(sortOrder) ? "iban" : "";
            ViewBag.AliasSortParm = String.IsNullOrEmpty(sortOrder) ? "alias" : "";
            

            IEnumerable<BankAccount> bankAccounts = db.BankAccounts.ToList(); //from s in db.BankAccounts select s;
            if (!string.IsNullOrEmpty(search))
            {
                switch (option)
                {
                    case "IBAN":
                        bankAccounts = bankAccounts.Where(s => s.IBAN == search);
                        break;

                    case "Alias":
                        bankAccounts = bankAccounts.Where(s => s.Alias.Contains(search));
                        break; 
                }
            }

            if (!string.IsNullOrEmpty(sortOrder))
            {
                switch (sortOrder)
                {
                    case "iban":
                        bankAccounts = bankAccounts.OrderBy(s => s.IBAN);
                        break;

                    case "alias":
                        bankAccounts = bankAccounts.OrderBy(s => s.Alias);
                        break;
                }
            }

            int pageSize = 3;
            int pageNumber = page ?? 1;
            return View(bankAccounts.ToPagedList(pageNumber, pageSize));
        }

        // GET: BankAccounts/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankAccount bankAccount = db.BankAccounts.Find(id);
            if (bankAccount == null)
            {
                return HttpNotFound();
            }
            return View(bankAccount);
        }

        // GET: BankAccounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BankAccounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IBAN,Curency,Alias,PersoanaJuridica,CIF")] BankAccount bankAccount)
        {
            if (ModelState.IsValid && ValidationHelpers.ValidateIban(bankAccount.IBAN))
            {
                db.BankAccounts.Add(bankAccount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bankAccount);
        }

        // GET: BankAccounts/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankAccount bankAccount = db.BankAccounts.Find(id);
            if (bankAccount == null)
            {
                return HttpNotFound();
            }
            return View(bankAccount);
        }

        // POST: BankAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IBAN,Curency,Alias,PersoanaJuridica,CIF")] BankAccount bankAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bankAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bankAccount);
        }

        // GET: BankAccounts/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankAccount bankAccount = db.BankAccounts.Find(id);
            if (bankAccount == null)
            {
                return HttpNotFound();
            }
            return View(bankAccount);
        }

        // POST: BankAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            BankAccount bankAccount = db.BankAccounts.Find(id);
            db.BankAccounts.Remove(bankAccount);
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