using System.Threading.Tasks;

namespace UpstoxClient.Feeder.Listener
{
    public interface IOnReconnectingListener
    {
        Task OnReconnectingAsync(string message);
    }
}
