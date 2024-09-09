using CQRSTesting.Models;
using MediatR;

namespace CQRSTesting.Features.Players.GetPlayerById
{
    public class GetPlayerByIdQueryHandler : IRequestHandler<GetPlayerByIdQuery, Player?>
    {
        private readonly AppDbContext _context;

        public GetPlayerByIdQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Player?> Handle(GetPlayerByIdQuery request, CancellationToken cancellationToken)
        {
            var player = await _context.Players.FindAsync(request.Id);
            return player;
        }
    }
}
