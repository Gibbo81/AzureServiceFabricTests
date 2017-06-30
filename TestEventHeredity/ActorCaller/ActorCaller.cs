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

namespace ActorCaller
{
    /// <summary>
    /// An instance of this class is created for each service replica by the Service Fabric runtime.
    /// </summary>
    internal sealed class ActorCaller : StatefulService
    {
        public ActorCaller(StatefulServiceContext context)
            : base(context)
        { }

        /// <summary>
        /// Optional override to create listeners (e.g., HTTP, Service Remoting, WCF, etc.) for this service replica to handle client or user requests.
        /// </summary>
        /// <remarks>
        /// For more information on service communication, see https://aka.ms/servicefabricservicecommunication
        /// </remarks>
        /// <returns>A collection of listeners.</returns>
        protected override IEnumerable<ServiceReplicaListener> CreateServiceReplicaListeners()
        {
            return new ServiceReplicaListener[0];
        }

        /// <summary>
        /// This is the main entry point for your service replica.
        /// This method executes when this replica of your service becomes primary and has write status.
        /// </summary>
        /// <param name="cancellationToken">Canceled when Service Fabric needs to shut down this service replica.</param>
        protected override async Task RunAsync(CancellationToken cancellationToken)
        {
            ServiceEventSource.Current.ServiceMessage(Context, "Ask fot a happy day");
            var myactor = ActorProxy.Create<IMyActor>(ActorId.CreateRandom());
            ServiceEventSource.Current.ServiceMessage(Context, 
                                                      "Create actor proxy {0}",
                                                      myactor.GetActorId().ToString());

            var x = await myactor.HelloWord();
            ServiceEventSource.Current.ServiceMessage(Context, x);

            //Call event generating actor
            var newproxy = ActorProxy.Create<IActorEventInterface>(ActorId.CreateRandom());
            var b = await newproxy.UpdateGameStatus(new Guid(), "ten");
            ServiceEventSource.Current.ServiceMessage(Context,
                                                      "Called actor event generator with result {0}",
                                                      b);
        }
    }
}