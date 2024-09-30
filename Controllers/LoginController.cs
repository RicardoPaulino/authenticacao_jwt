using authenticacao_jwt.Repositories;
using authenticacao_jwt.Services;
using authentication_jwt.Models;
using Microsoft.AspNetCore.Mvc;

namespace authenticacao_jwt.Controllers
{
    [ApiController]
    [Route("v1")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> AuthenticateAsync([FromBody] User model)
        {
            var user = UserRepository.Get(model.UserName, model.Password);
            if(user == null)
            return BadRequest(new { message = "Usuário ou Senha inválidos" });

            var token = TokenService.GenerateToken(user);
            user.Password = "";

            return new {
                user = user,
                token = token
            };

        }
    }
}