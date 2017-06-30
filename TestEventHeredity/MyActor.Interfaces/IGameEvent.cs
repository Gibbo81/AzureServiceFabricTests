using System;
using Microsoft.ServiceFabric.Actors;

namespace MyActor.Interfaces
{
    public interface IGameEvent : IActorEvents
    {
        void GameScoreChanged(Guid gameId, string currentScore);
    }
}
