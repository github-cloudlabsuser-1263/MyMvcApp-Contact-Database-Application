using Microsoft.AspNetCore.Mvc;
using System.Linq;
using MyMvcApp.Models;

namespace MyMvcApp.Controllers;

public class UserController : Controller
{
    public static System.Collections.Generic.List<User> userlist = new System.Collections.Generic.List<User>();

        // GET: User
        public ActionResult Index(string searchString)
        {
            var users = userlist;

            if (!string.IsNullOrEmpty(searchString))
            {
            users = userlist
                .Where(u => 
                (!string.IsNullOrEmpty(u.Name) && u.Name.Contains(searchString, System.StringComparison.OrdinalIgnoreCase)) ||
                (!string.IsNullOrEmpty(u.Email) && u.Email.Contains(searchString, System.StringComparison.OrdinalIgnoreCase))
                )
                .ToList();
            }

            ViewBag.SearchString = searchString;
            return View(users);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            // Implement the details method here
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            //Implement the Create method here
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            // Implement the Create method (POST) here
            if (ModelState.IsValid)
            {
                userlist.Add(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            // This method is responsible for displaying the view to edit an existing user with the specified ID.
            // It retrieves the user from the userlist based on the provided ID and passes it to the Edit view.
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            // This method is responsible for handling the HTTP POST request to update an existing user with the specified ID.
            // It receives user input from the form submission and updates the corresponding user's information in the userlist.
            // If successful, it redirects to the Index action to display the updated list of users.
            // If no user is found with the provided ID, it returns a HttpNotFoundResult.
            // If an error occurs during the process, it returns the Edit view to display any validation errors.
            if (ModelState.IsValid)
            {
                var existingUser = userlist.FirstOrDefault(u => u.Id == id);
                if (existingUser == null)
                {
                    return NotFound();
                }
                existingUser.Name = user.Name;
                existingUser.Email = user.Email;
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            // This method is responsible for displaying the view to confirm the deletion of a user with the specified ID.
            // It retrieves the user from the userlist based on the provided ID and passes it to the Delete view.
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Microsoft.AspNetCore.Http.IFormCollection collection)
        {
            // This method is responsible for handling the HTTP POST request to delete a user with the specified ID.
            // It receives the form data from the Delete view and removes the corresponding user from the userlist.
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            userlist.Remove(user);
            return RedirectToAction("Index");
        }
}