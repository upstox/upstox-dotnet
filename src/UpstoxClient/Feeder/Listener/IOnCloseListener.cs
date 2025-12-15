using System.Threading.Tasks;

namespace UpstoxClient.Feeder.Listener
{
    public interface IOnCloseListener
    {
        Task OnCloseAsync(int statusCode, string reason);
    }
}
