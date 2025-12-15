using System.Threading.Tasks;
using UpstoxClient.Feeder.Model;

namespace UpstoxClient.Feeder.Listener
{
    public interface IOnPositionUpdateListener
    {
        Task OnUpdateAsync(PositionUpdate positionUpdate);
    }
}
