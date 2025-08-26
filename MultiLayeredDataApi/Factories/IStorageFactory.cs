using MultiLayeredDataApi.Storage;

namespace MultiLayeredDataApi.Factories
{
    public interface IStorageFactory
    {
        ICompositeStorage CreateCompositeStorage();
    }
}
