using Microsoft.AspNetCore.Mvc;
using MiniBanque.Models;
using MiniBanque.Services;

namespace MiniBanque.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ClientController: ControllerBase
    {
        private readonly BanqueServices _service = new();


        [HttpGet]
        public IActionResult GetClients() => Ok(_service.RechercherClientParNom(""));

        [HttpPost]
        public IActionResult AddClient([FromBody] Client client)
        {
            _service.AjouterClient(client);
            return Ok();
        }


    }
}
