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
    public class TbBienesGimnasioController : ControllerBase
    {
        private readonly GYMContext _context;

        public TbBienesGimnasioController(GYMContext context)
        {
            _context = context;
        }

        // GET: api/TbBienesGimnasio
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbBienesGimnasio>>> GetTbBienesGimnasio()
        {
          if (_context.TbBienesGimnasio == null)
          {
              return NotFound();
          }
            return await _context.TbBienesGimnasio.ToListAsync();
        }

        // GET: api/TbBienesGimnasio/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbBienesGimnasio>> GetTbBienesGimnasio(int id)
        {
          if (_context.TbBienesGimnasio == null)
          {
              return NotFound();
          }
            var tbBienesGimnasio = await _context.TbBienesGimnasio.FindAsync(id);

            if (tbBienesGimnasio == null)
            {
                return NotFound();
            }

            return tbBienesGimnasio;
        }

        // PUT: api/TbBienesGimnasio/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbBienesGimnasio(int id, TbBienesGimnasio tbBienesGimnasio)
        {
            if (id != tbBienesGimnasio.CodigoBien)
            {
                return BadRequest();
            }

            _context.Entry(tbBienesGimnasio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbBienesGimnasioExists(id))
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

        // POST: api/TbBienesGimnasio
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbBienesGimnasio>> PostTbBienesGimnasio(TbBienesGimnasio tbBienesGimnasio)
        {
          if (_context.TbBienesGimnasio == null)
          {
              return Problem("Entity set 'GYMContext.TbBienesGimnasio'  is null.");
          }
            _context.TbBienesGimnasio.Add(tbBienesGimnasio);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbBienesGimnasioExists(tbBienesGimnasio.CodigoBien))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbBienesGimnasio", new { id = tbBienesGimnasio.CodigoBien }, tbBienesGimnasio);
        }

        // DELETE: api/TbBienesGimnasio/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbBienesGimnasio(int id)
        {
            if (_context.TbBienesGimnasio == null)
            {
                return NotFound();
            }
            var tbBienesGimnasio = await _context.TbBienesGimnasio.FindAsync(id);
            if (tbBienesGimnasio == null)
            {
                return NotFound();
            }

            _context.TbBienesGimnasio.Remove(tbBienesGimnasio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbBienesGimnasioExists(int id)
        {
            return (_context.TbBienesGimnasio?.Any(e => e.CodigoBien == id)).GetValueOrDefault();
        }
    }
}
