using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data;
using Data.Entities;

namespace ThienThai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdolServicesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public IdolServicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/IdolServices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Idols>>> GetIdols()
        {
            return await _context.Idols.ToListAsync();
        }

        // GET: api/IdolServices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Idols>> GetIdols(int id)
        {
            var idols = await _context.Idols.FindAsync(id);

            if (idols == null)
            {
                return NotFound();
            }

            return idols;
        }

        // PUT: api/IdolServices/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIdols(int id, Idols idols)
        {
            if (id != idols.ID)
            {
                return BadRequest();
            }

            _context.Entry(idols).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IdolsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/IdolServices
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Idols>> PostIdols(Idols idols)
        {
            _context.Idols.Add(idols);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIdols", new { id = idols.ID }, idols);
        }

        // DELETE: api/IdolServices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Idols>> DeleteIdols(int id)
        {
            var idols = await _context.Idols.FindAsync(id);
            if (idols == null)
            {
                return NotFound();
            }

            _context.Idols.Remove(idols);
            await _context.SaveChangesAsync();

            return idols;
        }

        private bool IdolsExists(int id)
        {
            return _context.Idols.Any(e => e.ID == id);
        }
    }
}
