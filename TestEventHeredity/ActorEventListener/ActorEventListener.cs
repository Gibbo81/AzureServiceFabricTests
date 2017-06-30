using System;
using System.Collections.Generic;
using System.Fabric;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;
using MyActor.Interfaces;

namespace ActorEventListener
{
    public class ActorEventListener : StatefulService
    {
        public ActorEventListener(StatefulServiceContext serviceContext) : base(serviceContext) { }

        protected override IEnumerable<ServiceReplicaListener> CreateServiceReplicaListeners()
        {
            return new ServiceReplicaListener[0];
        }

        protected override async Task RunAsync(CancellationToken cancellationToken)
        {
            var proxy = ActorProxy.Create<IActorEventInterface>(ActorId.CreateRandom());
            await proxy.SubscribeAsync(new GameEventHandler(Context));
        }
    }

    public class GameEventHandler : IGameEvent
    {
        private readonly StatefulServiceContext _con;

        public GameEventHandler(StatefulServiceContext con)
        {
            _con = con;
        }

        public void GameScoreChanged(Guid gameId, string currentScore)
        {
            ServiceEventSource.Current.ServiceMessage(_con,
                "Received Event from Actor with {0}, {1}",
                gameId,
                currentScore);
        }
    }
}
