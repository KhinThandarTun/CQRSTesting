using CQRSTesting.Features.Players.CreatePlayer;
using CQRSTesting.Features.Players.GetPlayerById;
using CQRSTesting.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRSTesting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly ISender _sender;

        public PlayersController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlayer(CreatePlayerCommand command)
        {
            var playerId = await _sender.Send(command);
            return Ok(playerId);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlayerById(int id)
        {
            var player = await _sender.Send(new GetPlayerByIdQuery(id));
            if(player is null)
            {
                return NotFound();
            }

            return Ok(player);

        }
    }
}
