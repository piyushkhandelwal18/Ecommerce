using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CommonComponent.Models;
using System.IO;
using DataLayer.DatabaseOperations;
using Controllers;
using PagedList;

namespace CommonComponent.Controllers
{
    public class CategoriesController : BaseController
    {
        private DatabaseConnector db = new DatabaseConnector();

        // GET: Categories
        public ActionResult Index(string searchString)
        {
            List<Category> categoryList = db.GetCategory(searchString);

            if (categoryList == null || categoryList.Count == 0)
            {
                
            }
            else
            {
                
            }
            return View(categoryList);
        }
        /*public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }*/
        public ActionResult FileUpload(HttpPostedFileBase file)
        {
            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/Content/images"), pic);
                // file is uploaded
                file.SaveAs(path);

                // save the image path path to the database or you can send image
                // directly to database
                // in-case if you want to store byte[] ie. for DB
                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }

            }
            // after successfully uploading redirect the user
            return RedirectToAction("actionname", "controller name");
        }
        // GET: Categories/Details/5
        public ActionResult Details(int? id)
        {
            ViewResult result = null;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return result;
        }
        

        // GET: Categories/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(Category category, HttpPostedFileBase file)
        {
             file = Request.Files[0];
            byte[] data;
            using (Stream inputStream = file.InputStream)
            {
                MemoryStream memoryStream = inputStream as MemoryStream;
                if (memoryStream == null)
                {
                    memoryStream = new MemoryStream();
                    inputStream.CopyTo(memoryStream);
                }
                data = memoryStream.ToArray();
            }

            int CategoryId = -1;
            if (ModelState.IsValid)
               {
                CategoryId = db.SaveCategory(category);
                if(CategoryId < 0)
                {
                    ViewBag.CreateId = "Data is not created";
                }
                else
                {
                    return RedirectToAction("Index");
                }
                                              
            }

            return View(category);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryId,CategoryName,Description,Image,Published,DisplayOrder")] Category category)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            int Id = -1;
            if (ModelState.IsValid)
            {
                Id = db.EditCategory(category);
                if(Id < 0)
                {
                    ViewBag.EditId = "Category Id id not found";
                }
                else
                {
                    return RedirectToAction("Index");
                }
               
              
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
           
            if (category == null)
            {
                return HttpNotFound();
            }
            else
            {
                db.Categories.Remove(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if(db.DeleteCategory(id))
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
