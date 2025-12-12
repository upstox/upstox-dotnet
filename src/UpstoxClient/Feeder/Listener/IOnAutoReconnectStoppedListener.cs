using System.Threading.Tasks;

namespace UpstoxClient.Feeder.Listener
{
    public interface IOnAutoReconnectStoppedListener
    {
        Task OnHaultAsync(string message);
    }
}
