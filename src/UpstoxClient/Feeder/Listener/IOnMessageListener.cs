using System.Threading.Tasks;
using UpstoxClient.Feeder.Model;

namespace UpstoxClient.Feeder.Listener
{
    public interface IOnMessageListener
    {
        Task OnMessageAsync(MarketUpdateV3 update);
    }
}
