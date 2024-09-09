using MediatR;

namespace CQRSTesting.Features.Players.CreatePlayer
{
    public record CreatePlayerCommand(int Id, string Name, string Level) : IRequest<int>;
   
}
