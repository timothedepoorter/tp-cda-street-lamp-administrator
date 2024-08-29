using lampadaire.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lampadaire.Controller
{[Route("api/[controller]")]
    [ApiController]
    public class CapteurController : ControllerBase
    {
        private readonly ICapteurService _capteurService;

        public CapteurController(ICapteurService capteurService)
        {
            _capteurService = capteurService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCapteurs()
        {
            var capteurs = await _capteurService.GetAllCapteursAsync();
            return Ok(capteurs);
        }

        // [HttpGet("{id}")]
        // public async Task<IActionResult> GetCapteurById(string id)
        // {
        //     var capteur = await _capteurService.GetCapteurByIdAsync(id);
        //     if (capteur == null)
        //     {
        //         return NotFound();
        //     }
        //     return Ok(capteur);
        // }
    }
}
