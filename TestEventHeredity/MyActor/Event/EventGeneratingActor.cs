using System;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Runtime;
using MyActor.Interfaces;

namespace MyActor.Event
{
    [StatePersistence(StatePersistence.Persisted)]
    class EventGeneratingActor : Actor, IActorEventInterface
    {
        public EventGeneratingActor(ActorService actorService, ActorId actorId) : base(actorService, actorId){}


        public Task<bool> UpdateGameStatus(Guid gameId, string currentScore)
        {
            var ev = GetEvent<IGameEvent>();
            ev.GameScoreChanged(gameId,currentScore);
            return Task.FromResult(true);
        }
    }
}