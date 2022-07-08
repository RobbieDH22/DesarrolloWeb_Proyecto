using Microsoft.EntityFrameworkCore;
using Proyecto_GYM.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_GYM.Domain.Infrastructure.Repositories
{
    public class TbPersonaRepository : ITbPersonaRepository
    {
        private readonly GYMContext _context;
        public TbPersonaRepository(GYMContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<TbPersona>> GetAll()
        {
            return await _context.TbPersona.ToListAsync();
        }
    }



}
