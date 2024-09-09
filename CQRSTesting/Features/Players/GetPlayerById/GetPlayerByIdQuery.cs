using CQRSTesting.Models;
using MediatR;

namespace CQRSTesting.Features.Players.GetPlayerById
{
    public record GetPlayerByIdQuery(int Id): IRequest<Player?>;
    
}
