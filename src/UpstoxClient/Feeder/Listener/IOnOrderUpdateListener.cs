using System.Threading.Tasks;
using UpstoxClient.Feeder.Model;

namespace UpstoxClient.Feeder.Listener
{
    public interface IOnOrderUpdateListener
    {
        Task OnUpdateAsync(OrderUpdate orderUpdate);
    }
}
