using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PC_configurator.Models;

namespace PC_configurator.Controllers
{
    public class HomeController : Controller
    {
        ApplicationContext db;
        public HomeController(ApplicationContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await db.SystemUnits.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SystemUnit systemUnit)
        {
            db.SystemUnits.Add(systemUnit);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
