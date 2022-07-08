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
    public class TbSedeController : ControllerBase
    {
        private readonly GYMContext _context;

        public TbSedeController(GYMContext context)
        {
            _context = context;
        }

        // GET: api/TbSede
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbSede>>> GetTbSede()
        {
          if (_context.TbSede == null)
          {
              return NotFound();
          }
            return await _context.TbSede.ToListAsync();
        }

        // GET: api/TbSede/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbSede>> GetTbSede(int id)
        {
          if (_context.TbSede == null)
          {
              return NotFound();
          }
            var tbSede = await _context.TbSede.FindAsync(id);

            if (tbSede == null)
            {
                return NotFound();
            }

            return tbSede;
        }

        // PUT: api/TbSede/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbSede(int id, TbSede tbSede)
        {
            if (id != tbSede.CodigoSede)
            {
                return BadRequest();
            }

            _context.Entry(tbSede).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbSedeExists(id))
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

        // POST: api/TbSede
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbSede>> PostTbSede(TbSede tbSede)
        {
          if (_context.TbSede == null)
          {
              return Problem("Entity set 'GYMContext.TbSede'  is null.");
          }
            _context.TbSede.Add(tbSede);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbSedeExists(tbSede.CodigoSede))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbSede", new { id = tbSede.CodigoSede }, tbSede);
        }

        // DELETE: api/TbSede/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbSede(int id)
        {
            if (_context.TbSede == null)
            {
                return NotFound();
            }
            var tbSede = await _context.TbSede.FindAsync(id);
            if (tbSede == null)
            {
                return NotFound();
            }

            _context.TbSede.Remove(tbSede);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbSedeExists(int id)
        {
            return (_context.TbSede?.Any(e => e.CodigoSede == id)).GetValueOrDefault();
        }
    }
}
