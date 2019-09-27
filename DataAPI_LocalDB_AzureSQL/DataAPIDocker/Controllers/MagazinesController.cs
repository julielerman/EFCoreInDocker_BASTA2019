using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAPIDocker;
using DataAPIDocker.Models;

namespace DataAPIDocker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MagazinesController : ControllerBase
    {
        private readonly MagContext _context;

        public MagazinesController(MagContext context)
        {
            _context = context;
        }

        // GET: api/Magazines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Magazine>>> GetMagazine()
        {
            return await _context.Magazine.ToListAsync();
        }

        // GET: api/Magazines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Magazine>> GetMagazine(int id)
        {
            var magazine = await _context.Magazine.FindAsync(id);

            if (magazine == null)
            {
                return NotFound();
            }

            return magazine;
        }

        // PUT: api/Magazines/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMagazine(int id, Magazine magazine)
        {
            if (id != magazine.MagazineId)
            {
                return BadRequest();
            }

            _context.Entry(magazine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MagazineExists(id))
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

        // POST: api/Magazines
        [HttpPost]
        public async Task<ActionResult<Magazine>> PostMagazine(Magazine magazine)
        {
            _context.Magazine.Add(magazine);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMagazine", new { id = magazine.MagazineId }, magazine);
        }

        // DELETE: api/Magazines/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Magazine>> DeleteMagazine(int id)
        {
            var magazine = await _context.Magazine.FindAsync(id);
            if (magazine == null)
            {
                return NotFound();
            }

            _context.Magazine.Remove(magazine);
            await _context.SaveChangesAsync();

            return magazine;
        }

        private bool MagazineExists(int id)
        {
            return _context.Magazine.Any(e => e.MagazineId == id);
        }
    }
}
