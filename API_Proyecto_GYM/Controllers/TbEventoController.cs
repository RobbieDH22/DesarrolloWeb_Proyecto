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
    public class TbEventoController : ControllerBase
    {
        private readonly GYMContext _context;

        public TbEventoController(GYMContext context)
        {
            _context = context;
        }

        // GET: api/TbEvento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbEvento>>> GetTbEvento()
        {
          if (_context.TbEvento == null)
          {
              return NotFound();
          }
            return await _context.TbEvento.ToListAsync();
        }

        // GET: api/TbEvento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbEvento>> GetTbEvento(int id)
        {
          if (_context.TbEvento == null)
          {
              return NotFound();
          }
            var tbEvento = await _context.TbEvento.FindAsync(id);

            if (tbEvento == null)
            {
                return NotFound();
            }

            return tbEvento;
        }

        // PUT: api/TbEvento/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbEvento(int id, TbEvento tbEvento)
        {
            if (id != tbEvento.CodigoEvento)
            {
                return BadRequest();
            }

            _context.Entry(tbEvento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbEventoExists(id))
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

        // POST: api/TbEvento
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbEvento>> PostTbEvento(TbEvento tbEvento)
        {
          if (_context.TbEvento == null)
          {
              return Problem("Entity set 'GYMContext.TbEvento'  is null.");
          }
            _context.TbEvento.Add(tbEvento);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbEventoExists(tbEvento.CodigoEvento))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbEvento", new { id = tbEvento.CodigoEvento }, tbEvento);
        }

        // DELETE: api/TbEvento/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbEvento(int id)
        {
            if (_context.TbEvento == null)
            {
                return NotFound();
            }
            var tbEvento = await _context.TbEvento.FindAsync(id);
            if (tbEvento == null)
            {
                return NotFound();
            }

            _context.TbEvento.Remove(tbEvento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbEventoExists(int id)
        {
            return (_context.TbEvento?.Any(e => e.CodigoEvento == id)).GetValueOrDefault();
        }
    }
}
