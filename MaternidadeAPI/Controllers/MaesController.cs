using MaternidadeAPI.Servicos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaternidadeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaesController : ControllerBase
    {
        private readonly IMaeServico _maeServico;

        public MaesController(IMaeServico maeServico)
        {
            _maeServico = maeServico;
        }






    }
}
