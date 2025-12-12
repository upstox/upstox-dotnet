using System.Threading.Tasks;
using UpstoxClient.Feeder.Model;

namespace UpstoxClient.Feeder.Listener
{
    public interface IOnHoldingUpdateListener
    {
        Task OnUpdateAsync(HoldingUpdate holdingUpdate);
    }
}
