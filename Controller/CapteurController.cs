using lampadaire.Interface;
using lampadaire.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lampadaire.Controller
{
    [Route("api/[controller]")]
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCapteurById(string id)
        {
            var capteur = await _capteurService.GetCapteurByIdAsync(id);
            if (capteur == null)
            {
                return NotFound();
            }
            return Ok(capteur);
        }

        [HttpPost]
        public async Task<IActionResult> PostCapteur([FromBody] Capteur capteur)
        {
            if (capteur == null)
            {
                return BadRequest("Capteur is null.");
            }

            var createdCapteur = await _capteurService.CreateCapteurAsync(capteur);
            return CreatedAtAction(nameof(GetCapteurById), new { id = createdCapteur.Id }, createdCapteur);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCapteur(string id, [FromBody] Capteur capteur)
        {
            if (capteur == null || id != capteur.Id)
            {
                return BadRequest("Capteur ID mismatch.");
            }

            var updated = await _capteurService.UpdateCapteurAsync(id, capteur);
            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var deleted = await _capteurService.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
