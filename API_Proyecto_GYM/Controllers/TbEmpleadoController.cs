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
    public class TbEmpleadoController : ControllerBase
    {
        private readonly GYMContext _context;

        public TbEmpleadoController(GYMContext context)
        {
            _context = context;
        }

        // GET: api/TbEmpleado
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbEmpleado>>> GetTbEmpleado()
        {
          if (_context.TbEmpleado == null)
          {
              return NotFound();
          }
            return await _context.TbEmpleado.ToListAsync();
        }

        // GET: api/TbEmpleado/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbEmpleado>> GetTbEmpleado(int id)
        {
          if (_context.TbEmpleado == null)
          {
              return NotFound();
          }
            var tbEmpleado = await _context.TbEmpleado.FindAsync(id);

            if (tbEmpleado == null)
            {
                return NotFound();
            }

            return tbEmpleado;
        }

        // PUT: api/TbEmpleado/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbEmpleado(int id, TbEmpleado tbEmpleado)
        {
            if (id != tbEmpleado.CodigoEmp)
            {
                return BadRequest();
            }

            _context.Entry(tbEmpleado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbEmpleadoExists(id))
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

        // POST: api/TbEmpleado
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbEmpleado>> PostTbEmpleado(TbEmpleado tbEmpleado)
        {
          if (_context.TbEmpleado == null)
          {
              return Problem("Entity set 'GYMContext.TbEmpleado'  is null.");
          }
            _context.TbEmpleado.Add(tbEmpleado);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbEmpleadoExists(tbEmpleado.CodigoEmp))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbEmpleado", new { id = tbEmpleado.CodigoEmp }, tbEmpleado);
        }

        // DELETE: api/TbEmpleado/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbEmpleado(int id)
        {
            if (_context.TbEmpleado == null)
            {
                return NotFound();
            }
            var tbEmpleado = await _context.TbEmpleado.FindAsync(id);
            if (tbEmpleado == null)
            {
                return NotFound();
            }

            _context.TbEmpleado.Remove(tbEmpleado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbEmpleadoExists(int id)
        {
            return (_context.TbEmpleado?.Any(e => e.CodigoEmp == id)).GetValueOrDefault();
        }
    }
}
