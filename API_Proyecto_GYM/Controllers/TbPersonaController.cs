using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Proyecto_GYM.Models;
using Proyecto_GYM.Domain.Core.DTOs;
using Proyecto_GYM.Domain.Infrastructure.Repositories;
using Proyecto_GYM.Domain.Core.Entities;

namespace API_Proyecto_GYM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TbPersonaController : ControllerBase
    {
        private readonly ITbPersonaRepository _TbPersonaRepository;

        public TbPersonaController(ITbPersonaRepository TbPersonaRepository)
        {
            _TbPersonaRepository = TbPersonaRepository;
        }

        // GET: api/TbPersona
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
          var personas = await _TbPersonaRepository.GetAll();
          var personaList = new List<DTO_tbpersona>();
        foreach (var persona in personas)
          {
            personaList.Add(new DTO_tbpersona
            {
                Dni = persona.Dni,
                Nombre = persona.Nombre,
                Apellidos = persona.Apellidos,
                Direccion = persona.Direccion,
                Correo = persona.Correo,
                Contrasena = persona.Contrasena,
                FechaNacimiento = persona.FechaNacimiento,
                Sexo = persona.Sexo
           });
           }
            return Ok(personaList);
        }

    // GET: api/TbPersona/5
    //[httpget("{id}")]
    //    public async task<actionresult<tbpersona>> gettbpersona(int id)
    //    {
    //      if (_tbpersonarepository.tbpersona == null)
    //      {
    //          return notfound();
    //      }
    //        var tbpersona = await _tbpersonarepository.tbpersona.findasync(id);

    //        if (tbpersona == null)
    //        {
    //            return notfound();
    //        }

    //        return tbpersona;
    //    }

    //    // put: api/tbpersona/5
    //    // to protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    //    [httpput("{id}")]
    //    public async task<iactionresult> puttbpersona(int id, tbpersona tbpersona)
    //    {
    //        if (id != tbpersona.dni)
    //        {
    //            return badrequest();
    //        }

    //        _tbpersonarepository.entry(tbpersona).state = entitystate.modified;

    //        try
    //        {
    //            await _tbpersonarepository.savechangesasync();
    //        }
    //        catch (dbupdateconcurrencyexception)
    //        {
    //            if (!tbpersonaexists(id))
    //            {
    //                return notfound();
    //            }
    //            else
    //            {
    //                throw;
    //            }
    //        }

    //        return nocontent();
    //    }

    //    // post: api/tbpersona
    //    // to protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    //    [httppost]
    //    public async task<actionresult<tbpersona>> posttbpersona(tbpersona tbpersona)
    //    {
    //      if (_tbpersonarepository.tbpersona == null)
    //      {
    //          return problem("entity set 'gymcontext.tbpersona'  is null.");
    //      }
    //        _tbpersonarepository.tbpersona.add(tbpersona);
    //        try
    //        {
    //            await _tbpersonarepository.savechangesasync();
    //        }
    //        catch (dbupdateexception)
    //        {
    //            if (tbpersonaexists(tbpersona.dni))
    //            {
    //                return conflict();
    //            }
    //            else
    //            {
    //                throw;
    //            }
    //        }

    //        return createdataction("gettbpersona", new { id = tbpersona.dni }, tbpersona);
    //    }

    //    // delete: api/tbpersona/5
    //    [httpdelete("{id}")]
    //    public async task<iactionresult> deletetbpersona(int id)
    //    {
    //        if (_tbpersonarepository.tbpersona == null)
    //        {
    //            return notfound();
    //        }
    //        var tbpersona = await _tbpersonarepository.tbpersona.findasync(id);
    //        if (tbpersona == null)
    //        {
    //            return notfound();
    //        }

    //        _tbpersonarepository.tbpersona.remove(tbpersona);
    //        await _tbpersonarepository.savechangesasync();

    //        return nocontent();
    //    }

    //    private bool tbpersonaexists(int id)
    //    {
    //        return (_tbpersonarepository.tbpersona?.any(e => e.dni == id)).getvalueordefault();
    //    }
    }
}
