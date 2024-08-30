using lampadaire.Interface;
using lampadaire.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace lampadaire.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoraireController : ControllerBase
    {
        private readonly IHoraireService _horaireService;

        public HoraireController(IHoraireService horaireService)
        {
            _horaireService = horaireService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var horaires = await _horaireService.GetAllAsync();
            return Ok(horaires);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var horaire = await _horaireService.GetByIdAsync(id);
            if (horaire == null)
            {
                return NotFound();
            }
            return Ok(horaire);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Horaire horaire)
        {
            if (horaire == null)
            {
                return BadRequest("Horaire is null.");
            }

            var createdHoraire = await _horaireService.CreateAsync(horaire);
            return CreatedAtAction(nameof(GetById), new { id = createdHoraire.Id }, createdHoraire);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Horaire horaire)
        {
            if (horaire == null || id != horaire.Id)
            {
                return BadRequest("Horaire ID mismatch.");
            }

            var updated = await _horaireService.UpdateAsync(id, horaire);
            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var deleted = await _horaireService.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
