using System.Threading.Tasks;

namespace PlasticuerRestAPI.DataProviders
{
    public interface IStockDataProvider
    {
        Task<int> GetStock(int idArticulo);
    }
}
