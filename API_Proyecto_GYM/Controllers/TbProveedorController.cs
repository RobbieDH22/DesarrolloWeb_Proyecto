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
    public class TbProveedorController : ControllerBase
    {
        private readonly GYMContext _context;

        public TbProveedorController(GYMContext context)
        {
            _context = context;
        }

        // GET: api/TbProveedor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbProveedor>>> GetTbProveedor()
        {
          if (_context.TbProveedor == null)
          {
              return NotFound();
          }
            return await _context.TbProveedor.ToListAsync();
        }

        // GET: api/TbProveedor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbProveedor>> GetTbProveedor(int id)
        {
          if (_context.TbProveedor == null)
          {
              return NotFound();
          }
            var tbProveedor = await _context.TbProveedor.FindAsync(id);

            if (tbProveedor == null)
            {
                return NotFound();
            }

            return tbProveedor;
        }

        // PUT: api/TbProveedor/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbProveedor(int id, TbProveedor tbProveedor)
        {
            if (id != tbProveedor.CodigoProv)
            {
                return BadRequest();
            }

            _context.Entry(tbProveedor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbProveedorExists(id))
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

        // POST: api/TbProveedor
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbProveedor>> PostTbProveedor(TbProveedor tbProveedor)
        {
          if (_context.TbProveedor == null)
          {
              return Problem("Entity set 'GYMContext.TbProveedor'  is null.");
          }
            _context.TbProveedor.Add(tbProveedor);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbProveedorExists(tbProveedor.CodigoProv))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbProveedor", new { id = tbProveedor.CodigoProv }, tbProveedor);
        }

        // DELETE: api/TbProveedor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbProveedor(int id)
        {
            if (_context.TbProveedor == null)
            {
                return NotFound();
            }
            var tbProveedor = await _context.TbProveedor.FindAsync(id);
            if (tbProveedor == null)
            {
                return NotFound();
            }

            _context.TbProveedor.Remove(tbProveedor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbProveedorExists(int id)
        {
            return (_context.TbProveedor?.Any(e => e.CodigoProv == id)).GetValueOrDefault();
        }
    }
}
