using lampadaire.Interface;
using lampadaire.Models;
using lampadaire.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lampadaire.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LampadaireController : ControllerBase
    {
        private readonly ILampadaireService _lampadaireService;

        public LampadaireController(ILampadaireService lampadaireService)
        {
            _lampadaireService = lampadaireService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLampadaires()
        {
            var lampadaires = await _lampadaireService.GetAllLampadairesAsync();
            return Ok(lampadaires);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLampadaireById(string id)
        {
            var lampadaire = await _lampadaireService.GetLampadaireByIdAsync(id);
            if (lampadaire == null)
            {
                return NotFound();
            }
            return Ok(lampadaire);
        }

        [HttpPost]
        public async Task<IActionResult> PostLampadaire([FromBody] Lampadaire lampadaire)
        {
            if (lampadaire == null)
            {
                return BadRequest("Lampadaire est null.");
            }

            var createdLampadaire = await _lampadaireService.CreateLampadaireAsync(lampadaire);
            return CreatedAtAction(nameof(GetLampadaireById), new { id = createdLampadaire.Id }, createdLampadaire);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutLampadaire(string id, [FromBody] Lampadaire lampadaire)
        {
            if (lampadaire == null || id != lampadaire.Id)
            {
                return BadRequest("Lampadaire id non valid");
            }

            var updated = await _lampadaireService.UpdateLampadaireAsync(id, lampadaire);
            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
