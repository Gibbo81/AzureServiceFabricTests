using System.Threading.Tasks;
using Father;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Interface
{
    public interface IConsume : IService
    {
        Task<string> ReadNameFromSource(DataOriginal date);
    }
}