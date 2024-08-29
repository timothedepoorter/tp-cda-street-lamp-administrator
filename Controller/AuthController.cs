using lampadaire.Models;
using lampadaire.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lampadaire.Controller
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest model)
        {
            var result = await _authService.RegisterAsync(model.Identifiant, model.MotDePasse);
            if (result == "Inscription réussie.")
            {
                return Ok(new { message = result });
            }
            return BadRequest(new { message = result });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest model)
        {
            var token = await _authService.LoginAsync(model.Identifiant, model.MotDePasse);
            if (token == null)
            {
                return Unauthorized(new { message = "Identifiant ou mot de passe incorrect." });
            }
            return Ok(new { token });
        }
    }

    


}
