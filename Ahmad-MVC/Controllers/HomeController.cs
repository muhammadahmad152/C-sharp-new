
using Ahmad_MVC.Data;
using Ahmad_MVC.Models;
using Ahmad_MVC.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ahmad_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(
            ILogger<HomeController> logger,
            ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // INDEX - Display all users
        public IActionResult Index()
        {
            var users = _context.users.ToList();

            return View(users);
        }

        // CREATE - Open create page
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // CREATE - Save new user
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User U)
        {
            if (!ModelState.IsValid)
            {
                return View(U);
            }

            _context.users.Add(U);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // DETAILS - Display single user
        [HttpGet]
        public IActionResult Details(int id)
        {
            var finduser = _context.users.Find(id);

            if (finduser == null)
            {
                return NotFound();
            }

            return View(finduser);
        }

        // EDIT - Open edit page
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var finduser = _context.users.Find(id);

            if (finduser == null)
            {
                return NotFound();
            }

            return View(finduser);
        }

        // EDIT - Update user
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, User U)
        {
            if (id != U.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(U);
            }

            var finduser = _context.users.Find(id);

            if (finduser == null)
            {
                return NotFound();
            }

            finduser.Username = U.Username;
            finduser.Email = U.Email;
            finduser.Userrole = U.Userrole;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // DELETE - Delete user
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var finduser = _context.users.Find(id);

            if (finduser == null)
            {
                return NotFound();
            }

            _context.users.Remove(finduser);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // PRIVACY
        public IActionResult Privacy()
        {
            return View();
        }

        // ERROR
        [ResponseCache(
            Duration = 0,
            Location = ResponseCacheLocation.None,
            NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id
                    ?? HttpContext.TraceIdentifier
            });
        }
    }
}
