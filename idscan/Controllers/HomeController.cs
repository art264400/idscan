using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using idscan.Models;
using Microsoft.AspNetCore.Authorization;
namespace idscan.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private ContactContext db;
        public HomeController(ContactContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            
            //var user = new User
            //{
            //    Name = "Artur"
            //};
            //db.Users.Add(user);
            //db.SaveChanges();
            //var users = db.Users.First();
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
