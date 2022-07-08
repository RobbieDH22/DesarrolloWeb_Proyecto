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
    public class TbCompraController : ControllerBase
    {
        private readonly GYMContext _context;

        public TbCompraController(GYMContext context)
        {
            _context = context;
        }

        // GET: api/TbCompra
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbCompra>>> GetTbCompra()
        {
          if (_context.TbCompra == null)
          {
              return NotFound();
          }
            return await _context.TbCompra.ToListAsync();
        }

        // GET: api/TbCompra/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbCompra>> GetTbCompra(int id)
        {
          if (_context.TbCompra == null)
          {
              return NotFound();
          }
            var tbCompra = await _context.TbCompra.FindAsync(id);

            if (tbCompra == null)
            {
                return NotFound();
            }

            return tbCompra;
        }

        // PUT: api/TbCompra/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbCompra(int id, TbCompra tbCompra)
        {
            if (id != tbCompra.CodigoCompra)
            {
                return BadRequest();
            }

            _context.Entry(tbCompra).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbCompraExists(id))
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

        // POST: api/TbCompra
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbCompra>> PostTbCompra(TbCompra tbCompra)
        {
          if (_context.TbCompra == null)
          {
              return Problem("Entity set 'GYMContext.TbCompra'  is null.");
          }
            _context.TbCompra.Add(tbCompra);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbCompraExists(tbCompra.CodigoCompra))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbCompra", new { id = tbCompra.CodigoCompra }, tbCompra);
        }

        // DELETE: api/TbCompra/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbCompra(int id)
        {
            if (_context.TbCompra == null)
            {
                return NotFound();
            }
            var tbCompra = await _context.TbCompra.FindAsync(id);
            if (tbCompra == null)
            {
                return NotFound();
            }

            _context.TbCompra.Remove(tbCompra);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbCompraExists(int id)
        {
            return (_context.TbCompra?.Any(e => e.CodigoCompra == id)).GetValueOrDefault();
        }
    }
}
