using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Proyecto_GYM.Models;

namespace API_Proyecto_GYM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TbInscripcionMembresiaController : ControllerBase
    {
        private readonly GYMContext _context;

        public TbInscripcionMembresiaController(GYMContext context)
        {
            _context = context;
        }

        // GET: api/TbInscripcionMembresia
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbInscripcionMembresia>>> GetTbInscripcionMembresia()
        {
          if (_context.TbInscripcionMembresia == null)
          {
              return NotFound();
          }
            return await _context.TbInscripcionMembresia.ToListAsync();
        }

        // GET: api/TbInscripcionMembresia/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbInscripcionMembresia>> GetTbInscripcionMembresia(int id)
        {
          if (_context.TbInscripcionMembresia == null)
          {
              return NotFound();
          }
            var tbInscripcionMembresia = await _context.TbInscripcionMembresia.FindAsync(id);

            if (tbInscripcionMembresia == null)
            {
                return NotFound();
            }

            return tbInscripcionMembresia;
        }

        // PUT: api/TbInscripcionMembresia/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbInscripcionMembresia(int id, TbInscripcionMembresia tbInscripcionMembresia)
        {
            if (id != tbInscripcionMembresia.CodigoMembresia)
            {
                return BadRequest();
            }

            _context.Entry(tbInscripcionMembresia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbInscripcionMembresiaExists(id))
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

        // POST: api/TbInscripcionMembresia
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbInscripcionMembresia>> PostTbInscripcionMembresia(TbInscripcionMembresia tbInscripcionMembresia)
        {
          if (_context.TbInscripcionMembresia == null)
          {
              return Problem("Entity set 'GYMContext.TbInscripcionMembresia'  is null.");
          }
            _context.TbInscripcionMembresia.Add(tbInscripcionMembresia);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbInscripcionMembresiaExists(tbInscripcionMembresia.CodigoMembresia))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbInscripcionMembresia", new { id = tbInscripcionMembresia.CodigoMembresia }, tbInscripcionMembresia);
        }

        // DELETE: api/TbInscripcionMembresia/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbInscripcionMembresia(int id)
        {
            if (_context.TbInscripcionMembresia == null)
            {
                return NotFound();
            }
            var tbInscripcionMembresia = await _context.TbInscripcionMembresia.FindAsync(id);
            if (tbInscripcionMembresia == null)
            {
                return NotFound();
            }

            _context.TbInscripcionMembresia.Remove(tbInscripcionMembresia);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbInscripcionMembresiaExists(int id)
        {
            return (_context.TbInscripcionMembresia?.Any(e => e.CodigoMembresia == id)).GetValueOrDefault();
        }
    }
}
