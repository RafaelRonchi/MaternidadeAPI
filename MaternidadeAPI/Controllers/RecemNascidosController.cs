using MaternidadeAPI.Servicos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaternidadeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecemNascidosController : ControllerBase
    {
        private readonly IRecemNascidoServico _recemNascidoServico;

        public RecemNascidosController(IRecemNascidoServico recemNascidoServico)
        {
            _recemNascidoServico = recemNascidoServico;
        }




    }
}
