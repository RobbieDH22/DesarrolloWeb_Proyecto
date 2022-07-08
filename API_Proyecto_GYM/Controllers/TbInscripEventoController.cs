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
    public class TbInscripEventoController : ControllerBase
    {
        private readonly GYMContext _context;

        public TbInscripEventoController(GYMContext context)
        {
            _context = context;
        }

        // GET: api/TbInscripEvento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbInscripEvento>>> GetTbInscripEvento()
        {
          if (_context.TbInscripEvento == null)
          {
              return NotFound();
          }
            return await _context.TbInscripEvento.ToListAsync();
        }

        // GET: api/TbInscripEvento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbInscripEvento>> GetTbInscripEvento(int id)
        {
          if (_context.TbInscripEvento == null)
          {
              return NotFound();
          }
            var tbInscripEvento = await _context.TbInscripEvento.FindAsync(id);

            if (tbInscripEvento == null)
            {
                return NotFound();
            }

            return tbInscripEvento;
        }

        // PUT: api/TbInscripEvento/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbInscripEvento(int id, TbInscripEvento tbInscripEvento)
        {
            if (id != tbInscripEvento.CodigoInscripcion)
            {
                return BadRequest();
            }

            _context.Entry(tbInscripEvento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbInscripEventoExists(id))
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

        // POST: api/TbInscripEvento
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbInscripEvento>> PostTbInscripEvento(TbInscripEvento tbInscripEvento)
        {
          if (_context.TbInscripEvento == null)
          {
              return Problem("Entity set 'GYMContext.TbInscripEvento'  is null.");
          }
            _context.TbInscripEvento.Add(tbInscripEvento);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbInscripEventoExists(tbInscripEvento.CodigoInscripcion))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbInscripEvento", new { id = tbInscripEvento.CodigoInscripcion }, tbInscripEvento);
        }

        // DELETE: api/TbInscripEvento/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbInscripEvento(int id)
        {
            if (_context.TbInscripEvento == null)
            {
                return NotFound();
            }
            var tbInscripEvento = await _context.TbInscripEvento.FindAsync(id);
            if (tbInscripEvento == null)
            {
                return NotFound();
            }

            _context.TbInscripEvento.Remove(tbInscripEvento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbInscripEventoExists(int id)
        {
            return (_context.TbInscripEvento?.Any(e => e.CodigoInscripcion == id)).GetValueOrDefault();
        }
    }
}
