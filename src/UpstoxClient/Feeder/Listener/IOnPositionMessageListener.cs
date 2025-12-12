using System.Threading.Tasks;
using UpstoxClient.Feeder.Model;

namespace UpstoxClient.Feeder.Listener
{
    public interface IOnPositionMessageListener
    {
        Task OnMessageAsync(PositionUpdate update);
    }
}
