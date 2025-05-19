using Microsoft.AspNetCore.Mvc;
using MiniBanque.Models;
using MiniBanque.Services;

namespace MiniBanque.Controllers
{

    public class CompteController: ControllerBase
    {
        private readonly BanqueServices _service = new();

        [HttpGet]
        public IActionResult GetComptes([FromQuery] int id)
        {
            _service.RechercherCompte(id);
            return Ok();
        }

        [HttpPost]
        public IActionResult AddCompte([FromBody] Compte compte)
        {
            _service.AjouterCompte(compte);
            return Ok();
        }

        [HttpPost("virement")]
        public IActionResult Virement([FromQuery] int sourceId, [FromQuery] int destinationId,
            [FromQuery] decimal montant)
        {
            if (_service.Virement(sourceId, destinationId, montant))
            {
                return Ok("Virement reussi");
            }

            return BadRequest("Echec du virement");
        }

        [HttpDelete("{id}")]
        public IActionResult SupprimerCompte(int id)
        {
            var Compte = _service.RechercherCompte(id);
            if (Compte == null)
            {
                return NotFound($"Aucun compte trouve avec l ID {id}");

            }
            else
            {
                _service.SupprimerCompte(id);
                return NoContent();
            }
        }
    }
}
