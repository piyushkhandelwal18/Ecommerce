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
    public class UsersController : BaseController
    {
        private DatabaseConnector db = new DatabaseConnector();

        // GET: Users
        public ActionResult Index(string searchString)
        {
            List<User> UserList = db.Getuser(searchString);
            ViewResult Result = null;
            if(UserList == null || UserList.Count == 0)
            {

            }
            else
            {
                Result = View(UserList);
            }
            return Result;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "UserEmailId,Password")] User user)
        {
            return RedirectToAction("Index","Home");
        }
        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,UserEmailId,Password,Gender,UserFirstName,UserLastName,Address,ZipPostalCode")] User user)
        {
            var allErrors = ModelState.Values.SelectMany(v => v.Errors);
            int Id = -1;
            if (ModelState.IsValid)
            {
                Id = db.Saveuser(user);
                if(Id < 0)
                {
                    ViewBag.CreateId = "Data is not created";
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                ViewBag.ModelState = "Model state is not valid";
            }
                

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,UserEmailId,Password,Gender,UserFirstName,UserLastName,Address,ZipPostalCode")] User user)
        {
            int Id = -1;
            if (ModelState.IsValid)
            {
                Id = db.EditUser(user);
                if(Id < 0)
                {

                }
                else
                {
                    return RedirectToAction("Index");
                }
             
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            else
            {
                db.Users.Remove(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }     
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if(db.DeleteUser(id))
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
