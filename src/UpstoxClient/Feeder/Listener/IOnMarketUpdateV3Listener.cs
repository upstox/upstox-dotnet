using System.Threading.Tasks;
using UpstoxClient.Feeder.Model;

namespace UpstoxClient.Feeder.Listener
{
    public interface IOnMarketUpdateV3Listener
    {
        Task OnUpdateAsync(MarketUpdateV3 marketUpdate);
    }
}
