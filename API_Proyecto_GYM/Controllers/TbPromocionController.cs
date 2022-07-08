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
    public class TbPromocionController : ControllerBase
    {
        private readonly GYMContext _context;

        public TbPromocionController(GYMContext context)
        {
            _context = context;
        }

        // GET: api/TbPromocion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbPromocion>>> GetTbPromocion()
        {
          if (_context.TbPromocion == null)
          {
              return NotFound();
          }
            return await _context.TbPromocion.ToListAsync();
        }

        // GET: api/TbPromocion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbPromocion>> GetTbPromocion(int id)
        {
          if (_context.TbPromocion == null)
          {
              return NotFound();
          }
            var tbPromocion = await _context.TbPromocion.FindAsync(id);

            if (tbPromocion == null)
            {
                return NotFound();
            }

            return tbPromocion;
        }

        // PUT: api/TbPromocion/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbPromocion(int id, TbPromocion tbPromocion)
        {
            if (id != tbPromocion.CodigoProm)
            {
                return BadRequest();
            }

            _context.Entry(tbPromocion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbPromocionExists(id))
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

        // POST: api/TbPromocion
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbPromocion>> PostTbPromocion(TbPromocion tbPromocion)
        {
          if (_context.TbPromocion == null)
          {
              return Problem("Entity set 'GYMContext.TbPromocion'  is null.");
          }
            _context.TbPromocion.Add(tbPromocion);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbPromocionExists(tbPromocion.CodigoProm))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbPromocion", new { id = tbPromocion.CodigoProm }, tbPromocion);
        }

        // DELETE: api/TbPromocion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbPromocion(int id)
        {
            if (_context.TbPromocion == null)
            {
                return NotFound();
            }
            var tbPromocion = await _context.TbPromocion.FindAsync(id);
            if (tbPromocion == null)
            {
                return NotFound();
            }

            _context.TbPromocion.Remove(tbPromocion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbPromocionExists(int id)
        {
            return (_context.TbPromocion?.Any(e => e.CodigoProm == id)).GetValueOrDefault();
        }
    }
}
