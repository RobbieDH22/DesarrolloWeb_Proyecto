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
    public class TbAsistenciaController : ControllerBase
    {
        private readonly GYMContext _context;

        public TbAsistenciaController(GYMContext context)
        {
            _context = context;
        }

        // GET: api/TbAsistencia
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbAsistencia>>> GetTbAsistencia()
        {
          if (_context.TbAsistencia == null)
          {
              return NotFound();
          }
            return await _context.TbAsistencia.ToListAsync();
        }

        // GET: api/TbAsistencia/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbAsistencia>> GetTbAsistencia(int id)
        {
          if (_context.TbAsistencia == null)
          {
              return NotFound();
          }
            var tbAsistencia = await _context.TbAsistencia.FindAsync(id);

            if (tbAsistencia == null)
            {
                return NotFound();
            }

            return tbAsistencia;
        }

        // PUT: api/TbAsistencia/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbAsistencia(int id, TbAsistencia tbAsistencia)
        {
            if (id != tbAsistencia.CodigoAsistencia)
            {
                return BadRequest();
            }

            _context.Entry(tbAsistencia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbAsistenciaExists(id))
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

        // POST: api/TbAsistencia
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbAsistencia>> PostTbAsistencia(TbAsistencia tbAsistencia)
        {
          if (_context.TbAsistencia == null)
          {
              return Problem("Entity set 'GYMContext.TbAsistencia'  is null.");
          }
            _context.TbAsistencia.Add(tbAsistencia);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbAsistenciaExists(tbAsistencia.CodigoAsistencia))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbAsistencia", new { id = tbAsistencia.CodigoAsistencia }, tbAsistencia);
        }

        // DELETE: api/TbAsistencia/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbAsistencia(int id)
        {
            if (_context.TbAsistencia == null)
            {
                return NotFound();
            }
            var tbAsistencia = await _context.TbAsistencia.FindAsync(id);
            if (tbAsistencia == null)
            {
                return NotFound();
            }

            _context.TbAsistencia.Remove(tbAsistencia);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbAsistenciaExists(int id)
        {
            return (_context.TbAsistencia?.Any(e => e.CodigoAsistencia == id)).GetValueOrDefault();
        }
    }
}
