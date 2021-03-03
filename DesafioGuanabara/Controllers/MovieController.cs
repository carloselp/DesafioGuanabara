using DesafioGuanabara.Model;
using DesafioGuanabara.Repositories;
using DesafioGuanabara.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace DesafioGuanabara.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly Configuracao _config;

        public MovieController(IConfiguration config)
        {
            _config = new Configuracao();
            config.GetSection("MyConfig").Bind(_config);
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]

        public ActionResult<dynamic> Logar([FromBody] User login)
        {
            //User login = new User { Username = "marcio", Password = "desafio" };

            Model.User usuario = UserRepository.Get(login.Username, login.Password);

            if (usuario == null)
                return NotFound(new { message="Usuário ou senha inválido!"});

            string token = TokenService.GenerateToken(usuario, _config);
            usuario.Password = string.Empty;

            return new
            {
                usuario = usuario,
                token = token
            };
        }

        [HttpGet]
        [Authorize(Roles ="admin")]
        public async Task<string> Get()
        {
            Movie filme = new Movie(_config);

            return await filme.RetornarDesafio(649087);
        }
    }
}
