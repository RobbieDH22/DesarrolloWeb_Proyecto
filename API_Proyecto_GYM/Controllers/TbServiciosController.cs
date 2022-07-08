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
    public class TbServiciosController : ControllerBase
    {
        private readonly GYMContext _context;

        public TbServiciosController(GYMContext context)
        {
            _context = context;
        }

        // GET: api/TbServicios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbServicios>>> GetTbServicios()
        {
          if (_context.TbServicios == null)
          {
              return NotFound();
          }
            return await _context.TbServicios.ToListAsync();
        }

        // GET: api/TbServicios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbServicios>> GetTbServicios(int id)
        {
          if (_context.TbServicios == null)
          {
              return NotFound();
          }
            var tbServicios = await _context.TbServicios.FindAsync(id);

            if (tbServicios == null)
            {
                return NotFound();
            }

            return tbServicios;
        }

        // PUT: api/TbServicios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbServicios(int id, TbServicios tbServicios)
        {
            if (id != tbServicios.CodigoServicio)
            {
                return BadRequest();
            }

            _context.Entry(tbServicios).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbServiciosExists(id))
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

        // POST: api/TbServicios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbServicios>> PostTbServicios(TbServicios tbServicios)
        {
          if (_context.TbServicios == null)
          {
              return Problem("Entity set 'GYMContext.TbServicios'  is null.");
          }
            _context.TbServicios.Add(tbServicios);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbServiciosExists(tbServicios.CodigoServicio))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbServicios", new { id = tbServicios.CodigoServicio }, tbServicios);
        }

        // DELETE: api/TbServicios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbServicios(int id)
        {
            if (_context.TbServicios == null)
            {
                return NotFound();
            }
            var tbServicios = await _context.TbServicios.FindAsync(id);
            if (tbServicios == null)
            {
                return NotFound();
            }

            _context.TbServicios.Remove(tbServicios);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbServiciosExists(int id)
        {
            return (_context.TbServicios?.Any(e => e.CodigoServicio == id)).GetValueOrDefault();
        }
    }
}
