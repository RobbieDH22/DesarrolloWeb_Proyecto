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
    public class TbPlanesController : ControllerBase
    {
        private readonly GYMContext _context;

        public TbPlanesController(GYMContext context)
        {
            _context = context;
        }

        // GET: api/TbPlanes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbPlanes>>> GetTbPlanes()
        {
          if (_context.TbPlanes == null)
          {
              return NotFound();
          }
            return await _context.TbPlanes.ToListAsync();
        }

        // GET: api/TbPlanes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbPlanes>> GetTbPlanes(int id)
        {
          if (_context.TbPlanes == null)
          {
              return NotFound();
          }
            var tbPlanes = await _context.TbPlanes.FindAsync(id);

            if (tbPlanes == null)
            {
                return NotFound();
            }

            return tbPlanes;
        }

        // PUT: api/TbPlanes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbPlanes(int id, TbPlanes tbPlanes)
        {
            if (id != tbPlanes.CodigoPlan)
            {
                return BadRequest();
            }

            _context.Entry(tbPlanes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbPlanesExists(id))
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

        // POST: api/TbPlanes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbPlanes>> PostTbPlanes(TbPlanes tbPlanes)
        {
          if (_context.TbPlanes == null)
          {
              return Problem("Entity set 'GYMContext.TbPlanes'  is null.");
          }
            _context.TbPlanes.Add(tbPlanes);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbPlanesExists(tbPlanes.CodigoPlan))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbPlanes", new { id = tbPlanes.CodigoPlan }, tbPlanes);
        }

        // DELETE: api/TbPlanes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbPlanes(int id)
        {
            if (_context.TbPlanes == null)
            {
                return NotFound();
            }
            var tbPlanes = await _context.TbPlanes.FindAsync(id);
            if (tbPlanes == null)
            {
                return NotFound();
            }

            _context.TbPlanes.Remove(tbPlanes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbPlanesExists(int id)
        {
            return (_context.TbPlanes?.Any(e => e.CodigoPlan == id)).GetValueOrDefault();
        }
    }
}
