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
    }
}
