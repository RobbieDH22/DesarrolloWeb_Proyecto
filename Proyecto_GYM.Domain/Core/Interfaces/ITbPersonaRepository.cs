using Proyecto_GYM.Domain.Core.Entities;

namespace Proyecto_GYM.Domain.Infrastructure.Repositories
{
    public interface ITbPersonaRepository
    {
        Task<IEnumerable<TbPersona>> GetAll();
    }
}