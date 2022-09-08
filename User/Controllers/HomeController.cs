using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using User.Models;

namespace User.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<User> objUserList = _context.Users;
            return View(objUserList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User obj)
        {          
            if (ModelState.IsValid)
            {
                _context.Users.Add(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null|| id == 0)
            {
                return NotFound();
            }
            var userFromDb = _context.Users.Find(id);

            if (userFromDb == null)
            {
                return NotFound();
            }

            return View(userFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(User obj)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Update(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _context.Users.Find(id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _context.Users.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _context.Users.Remove(obj);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}