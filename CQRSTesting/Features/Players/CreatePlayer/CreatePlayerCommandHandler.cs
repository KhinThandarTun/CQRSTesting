using CQRSTesting.Models;
using MediatR;
using System.Numerics;

namespace CQRSTesting.Features.Players.CreatePlayer
{
    public class CreatePlayerCommandHandler : IRequestHandler<CreatePlayerCommand, int>
    {
        private readonly AppDbContext _context;

        public CreatePlayerCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
        {
            var player = new Player { Id = request.Id, Name = request.Name, Level = request.Level};
            _context.Players.Add(player);
            await _context.SaveChangesAsync();

            return player.Id;
        }
    }
}
