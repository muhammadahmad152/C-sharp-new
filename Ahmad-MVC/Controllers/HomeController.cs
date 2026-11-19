using Ahmad_MVC.Data;using Ahmad_MVC.Models;using Ahmad_MVC.Models.Entity;using Microsoft.AspNetCore.Mvc;using Microsoft.EntityFrameworkCore;using System.Diagnostics;namespace Ahmad_MVC.Controllers{    public class HomeController : Controller    {        private readonly ILogger<HomeController> _logger;        private readonly ApplicationDbContext _context;        public HomeController(            ILogger<HomeController> logger,            ApplicationDbContext context)        {            _logger = logger;            _context = context;        }        public IActionResult Index()        {            var User = _context.users.ToList();            return View(User);        }        public IActionResult Create()        {            return View();        }        [HttpPost]        public IActionResult Create(User U)        {            _context.users.Add(U);            _context.SaveChanges();            return RedirectToAction("Index");        }        public IActionResult Details(int id)
        {
            var user = _context.users.Find(id);

            if(user == null)
            {
                return NotFound();
            }

            return View(user);
        }        public IActionResult Delete(int id)
        {
            var user = _context.users.Find(id);

            if (user == null)
            {
                return NotFound();
            }

            _context.users.Remove(user);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }        public IActionResult Privacy()        {            return View();        }        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]        public IActionResult Error()        {            return View(new ErrorViewModel            {                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier            });        }    }}