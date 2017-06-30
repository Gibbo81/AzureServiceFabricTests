using System;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors;

namespace MyActor.Interfaces
{
    public interface IActorEventInterface : IActor, IActorEventPublisher<IGameEvent>
    {
        Task<bool> UpdateGameStatus(Guid gameId, string currentScore);
    }
}