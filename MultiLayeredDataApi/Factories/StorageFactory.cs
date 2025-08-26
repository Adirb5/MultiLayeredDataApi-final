using Microsoft.Extensions.DependencyInjection;
using MultiLayeredDataApi.Storage;

namespace MultiLayeredDataApi.Factories
{
    public class StorageFactory : IStorageFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public StorageFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ICompositeStorage CreateCompositeStorage()
        {
            return _serviceProvider.GetRequiredService<ICompositeStorage>();
        }
    }
}
