using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using vallezweb.Source.DB;
using vallezweb.Source.Entidades;
using vallezweb.Models.InputModels;

namespace vallezweb.Controllers.V1
{
    [ApiController]
    [Route("/api/v1/[controller]/")]
    public class AutenticaController : ControllerBase
    {

        private readonly VallezContext _context;

        public AutenticaController(VallezContext vallezContext)
        {
            _context = vallezContext;
        }

        [HttpPost]
        public IActionResult Index([FromBody] LoginIM user)
        {

            Usuario usuario = _context.Usuarios.FirstOrDefault(u => u.Username == user.Username && u.Senha == user.Password);
            
            if (usuario == null)
            {
                return NotFound();
            }

            Hospede hospede = _context.Hospedes.FirstOrDefault(h => h.IdUsuario == usuario.Id);


            return Ok(hospede);

        }

    }
}
