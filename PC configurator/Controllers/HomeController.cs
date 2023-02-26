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

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                SystemUnit systemUnit = new SystemUnit { Id = id.Value };
                db.Entry(systemUnit).State = EntityState.Deleted;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                SystemUnit? systemUnit = await db.SystemUnits.FirstOrDefaultAsync(p => p.Id == id);
                if (systemUnit != null) return View(systemUnit);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(SystemUnit systemUnit)
        {
            db.SystemUnits.Update(systemUnit);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
