using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vallezweb.Source.DB;


namespace vallezweb.Controllers.V1
{


    [ApiController]
    [Route("v1/[controller]")]
    public class LocacaoController : ControllerBase
    {

        private readonly VallezContext _vallezContext;

        public LocacaoController(
            VallezContext vallezContext    
        )
        {
            this._vallezContext = vallezContext;
        }

        public IActionResult Index()
        {

            return Ok("Ok");
        }
    }
}
