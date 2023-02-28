using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ssoapi.Data;
using ssoapi.Models;

namespace ssoapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HorseController : ControllerBase
    {
        private readonly SSOContext _context;

        public HorseController(SSOContext context)
        {
            _context = context;
        }

        // GET: api/Horse
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Horse>>> GetHorses()
        {
          if (_context.Horses == null)
          {
              return NotFound();
          }
            return await _context.Horses.ToListAsync();
        }

        // GET: api/Horse/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Horse>> GetHorse(int id)
        {
          if (_context.Horses == null)
          {
              return NotFound();
          }
            var horse = await _context.Horses.FindAsync(id);

            if (horse == null)
            {
                return NotFound();
            }

            return horse;
        }

        // PUT: api/Horse/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHorse(int id, Horse horse)
        {
            if (id != horse.HorseId)
            {
                return BadRequest();
            }

            _context.Entry(horse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HorseExists(id))
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

        // POST: api/Horse
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Horse>> PostHorse(Horse horse)
        {
          if (_context.Horses == null)
          {
              return Problem("Entity set 'SSOContext.Horses'  is null.");
          }
            _context.Horses.Add(horse);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHorse", new { id = horse.HorseId }, horse);
        }

        // DELETE: api/Horse/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHorse(int id)
        {
            if (_context.Horses == null)
            {
                return NotFound();
            }
            var horse = await _context.Horses.FindAsync(id);
            if (horse == null)
            {
                return NotFound();
            }

            _context.Horses.Remove(horse);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HorseExists(int id)
        {
            return (_context.Horses?.Any(e => e.HorseId == id)).GetValueOrDefault();
        }
    }
}
