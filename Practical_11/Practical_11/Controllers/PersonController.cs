using Practical_11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practical_11.Controllers
{
    public class PersonController : Controller
    {
        // This is a simple in-memory data store
        private static List<Person> users = new List<Person>
        {
            new Person { Id = Guid.NewGuid(), Name = "John Doe", Email = "john@doe.com", DateOfBirth = new DateTime(1990, 5, 15), Address = "123   Main  St, New York, NY" },
            new Person { Id = Guid.NewGuid(), Name = "Jane Doe", Email = "jane@doe.com", DateOfBirth = new DateTime(1992, 8, 22), Address = "456   Elm   St, Los Angeles, CA" },
            new Person { Id = Guid.NewGuid(), Name = "Joe Bloggs", Email = "joe@bloggs.com", DateOfBirth = new DateTime(1985, 12, 10), Address =   "789  Oak St, Chicago, IL" }
        };
        // GET: User
        public ActionResult Index()
        {
            return View(users);
        }

        // GET: User/Create
        // This method is used to display the form to create a new user
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // This method is used to handle the form submission and create a new user
        [HttpPost]
        public ActionResult Create(Person user)
        {
            if (ModelState.IsValid)
            {
                users.Add(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: User/Edit/{id}
        // This method is used to display the form to edit an existing user
        public ActionResult Edit(Guid id)
        {
            var user = users.FirstOrDefault(u => u.Id.Equals(id));
            return View(user);
        }

        // POST: 
        // This method is used to handle the form submission and update an existing user
        [HttpPost]
        public ActionResult Edit(Person user)
        {
            var existingUser = users.FirstOrDefault(u => u.Id.Equals(user.Id));
            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.Email = user.Email;
                existingUser.DateOfBirth = user.DateOfBirth;
                existingUser.Address = user.Address;
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: User/Details/{id}
        // This method is used to display the details of a user
        public ActionResult Details(Guid id)
        {
            var user = users.FirstOrDefault(u => u.Id.Equals(id));
            return View(user);
        }

        // GET: User/Delete/{id}
        // This method is used to display the confirmation page for deleting a user
        public ActionResult Delete(Guid id)
        {
            var user = users.FirstOrDefault(d => d.Id.Equals(id));

            return View(user);
        }

        // POST: 
        // This method is used to handle the form submission and delete a user
        [HttpPost]
        public ActionResult Delete(Person user)
        {
            var existingUser = users.FirstOrDefault(u => u.Id == user.Id);
            if (existingUser != null)
            {
                users.Remove(existingUser);
                return RedirectToAction("Index");
            }
            return Content("User not found");
        }
    
}
}