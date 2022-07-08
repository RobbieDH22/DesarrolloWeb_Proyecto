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
    public class TbProductosController : ControllerBase
    {
        private readonly GYMContext _context;

        public TbProductosController(GYMContext context)
        {
            _context = context;
        }

        // GET: api/TbProductos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbProductos>>> GetTbProductos()
        {
          if (_context.TbProductos == null)
          {
              return NotFound();
          }
            return await _context.TbProductos.ToListAsync();
        }

        // GET: api/TbProductos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbProductos>> GetTbProductos(int id)
        {
          if (_context.TbProductos == null)
          {
              return NotFound();
          }
            var tbProductos = await _context.TbProductos.FindAsync(id);

            if (tbProductos == null)
            {
                return NotFound();
            }

            return tbProductos;
        }

        // PUT: api/TbProductos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbProductos(int id, TbProductos tbProductos)
        {
            if (id != tbProductos.CodigoProd)
            {
                return BadRequest();
            }

            _context.Entry(tbProductos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbProductosExists(id))
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

        // POST: api/TbProductos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbProductos>> PostTbProductos(TbProductos tbProductos)
        {
          if (_context.TbProductos == null)
          {
              return Problem("Entity set 'GYMContext.TbProductos'  is null.");
          }
            _context.TbProductos.Add(tbProductos);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbProductosExists(tbProductos.CodigoProd))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbProductos", new { id = tbProductos.CodigoProd }, tbProductos);
        }

        // DELETE: api/TbProductos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbProductos(int id)
        {
            if (_context.TbProductos == null)
            {
                return NotFound();
            }
            var tbProductos = await _context.TbProductos.FindAsync(id);
            if (tbProductos == null)
            {
                return NotFound();
            }

            _context.TbProductos.Remove(tbProductos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbProductosExists(int id)
        {
            return (_context.TbProductos?.Any(e => e.CodigoProd == id)).GetValueOrDefault();
        }
    }
}
