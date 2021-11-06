using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vallezweb.Source.DB;
using vallezweb.Source.Entidades;
namespace vallezweb.Controllers
{
    public class AgendamentoController: Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
