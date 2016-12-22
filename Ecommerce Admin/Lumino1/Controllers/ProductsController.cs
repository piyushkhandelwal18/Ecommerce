using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CommonComponent.Models;
using DataLayer.DatabaseOperations;
using Controllers;

namespace CommonComponent.Controllers
{
    public class ProductsController : BaseController
    {
        private DatabaseConnector db = new DatabaseConnector();

        // GET: Products
        public ActionResult Index(string searchString)
        {
            List<Product> productList = db.GetProduct(searchString);
            if(productList == null || productList.Count == 0)
            {

            }
            else
            {
                
            }
            return View(productList);
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,ProductPrize,ProductImage")] Product product)
        {
            int ProductId = -1;
            if (ModelState.IsValid)
            {
                ProductId = db.SaveProduct(product);
                if(ProductId < 0)
                {

                }
                else
                {
                    return RedirectToAction("Index");
                }
                
                
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,ProductName,ProductPrize,ProductImage")] Product product)
        {
            int Id = -1;
            if (ModelState.IsValid)
            {
                Id = db.EditProduct(product);
                if(Id < 0)
                {

                }
                else
                {
                    return RedirectToAction("Index");
                }
               
                
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if(db.DeleteProduct(id))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
            
            
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
