using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace ThienThai.Controllers
{
    public class ManagementController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ManagementController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Idols
        public async Task<IActionResult> Index()
        {
            dynamic model = new ExpandoObject();
            model.Idols = await _context.Idols.ToListAsync();
            model.Comments = await _context.Comments.ToListAsync();
            return View(model);
        }

        // GET: Idols/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (!IdolExists(id))
            {
                return NotFound();
            }
            dynamic model = new ExpandoObject();
            model.Idols = await _context.Idols
                .FirstOrDefaultAsync(m => m.ID == id);
            model.Comments = await _context.Comments.ToListAsync();
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        // GET: Idols/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var idol = await _context.Idols.FindAsync(id);
            if (idol == null)
            {
                return NotFound();
            }
            return View(idol);
        }

        // GET: Idols/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var idol = await _context.Idols
                .FirstOrDefaultAsync(m => m.ID == id);
            if (idol == null)
            {
                return NotFound();
            }

            return View(idol);
        }

        // POST: Idols/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var idol = await _context.Idols.FindAsync(id);
            _context.Idols.Remove(idol);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IdolExists(int id)
        {
            return _context.Idols.Any(e => e.ID == id);
        }
        private bool IdolEmailExists(string email)
        {
            return _context.Idols.Any(e => e.Email == email);
        }
    }
}
