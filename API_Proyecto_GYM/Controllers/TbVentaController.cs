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
    public class TbVentaController : ControllerBase
    {
        private readonly GYMContext _context;

        public TbVentaController(GYMContext context)
        {
            _context = context;
        }

        // GET: api/TbVenta
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbVenta>>> GetTbVenta()
        {
          if (_context.TbVenta == null)
          {
              return NotFound();
          }
            return await _context.TbVenta.ToListAsync();
        }

        // GET: api/TbVenta/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbVenta>> GetTbVenta(int id)
        {
          if (_context.TbVenta == null)
          {
              return NotFound();
          }
            var tbVenta = await _context.TbVenta.FindAsync(id);

            if (tbVenta == null)
            {
                return NotFound();
            }

            return tbVenta;
        }

        // PUT: api/TbVenta/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbVenta(int id, TbVenta tbVenta)
        {
            if (id != tbVenta.CodigoVenta)
            {
                return BadRequest();
            }

            _context.Entry(tbVenta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbVentaExists(id))
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

        // POST: api/TbVenta
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbVenta>> PostTbVenta(TbVenta tbVenta)
        {
          if (_context.TbVenta == null)
          {
              return Problem("Entity set 'GYMContext.TbVenta'  is null.");
          }
            _context.TbVenta.Add(tbVenta);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbVentaExists(tbVenta.CodigoVenta))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbVenta", new { id = tbVenta.CodigoVenta }, tbVenta);
        }

        // DELETE: api/TbVenta/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbVenta(int id)
        {
            if (_context.TbVenta == null)
            {
                return NotFound();
            }
            var tbVenta = await _context.TbVenta.FindAsync(id);
            if (tbVenta == null)
            {
                return NotFound();
            }

            _context.TbVenta.Remove(tbVenta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbVentaExists(int id)
        {
            return (_context.TbVenta?.Any(e => e.CodigoVenta == id)).GetValueOrDefault();
        }
    }
}
