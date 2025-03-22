using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ItemsController : Controller
    {
        /*
        public IActionResult Overview()
        {
            var item = new Item() { Name = "Item1" };
            return View(item);
        }

        public IActionResult Edit(int id) 
        { 
            return Content("id= "+ id);
        }
        */

        private readonly WebAppContext _context;
        public ItemsController(WebAppContext context) 
        {  
            _context = context; 
        }

        public async Task<IActionResult> Index() 
        {
            var item = await _context.Items.Include(s=> s.SerialNumber)
                .Include(c=> c.Category)
                .Include(ic => ic.ItemClients)
                .ThenInclude(c => c.Client)
                .ToListAsync();
            return View(item);
        }

        public IActionResult Create() 
        {
            ViewData["Categories"] = new SelectList(_context.Category, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,CategoryId")] Item item) 
        {
            if (ModelState.IsValid) 
            {
                _context.Items.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(item);
        }

        public async Task<IActionResult> Edit(int id) 
        {
            ViewData["Categories"] = new SelectList(_context.Category, "Id", "Name");
            var item = await _context.Items.FirstOrDefaultAsync(x => x.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,CategoryId")] Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Items.Update(item);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(item);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.Items.FirstOrDefaultAsync(x => x.Id == id);
            return View(item);
        }

        [HttpPost ,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id) 
        {
            var item = await _context.Items.FindAsync(id);
            if (item != null) 
            { 
                 _context.Items.Remove(item);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");

        }
    }
}
