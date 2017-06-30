using System.Collections.Generic;
using System.Fabric;
using System.Threading.Tasks;
using Father;
using Interface;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;
using Microsoft.ServiceFabric.Services.Remoting.Runtime;


namespace Producer
{
    /// <summary>
    /// An instance of this class is created for each service replica by the Service Fabric runtime.
    /// </summary>
    internal sealed class Producer : StatefulService, IConsume
    {
        public Producer(StatefulServiceContext context)
            : base(context)
        { }

        protected override IEnumerable<ServiceReplicaListener> CreateServiceReplicaListeners()
        {
            return new[] { new ServiceReplicaListener(this.CreateServiceRemotingListener) };
        }

        public async Task<string> ReadNameFromSource(DataOriginal date)
        {
            return date.Name;
        }
    }
}