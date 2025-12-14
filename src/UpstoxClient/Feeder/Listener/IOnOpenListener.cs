using System.Threading.Tasks;

namespace UpstoxClient.Feeder.Listener
{
    public interface IOnOpenListener
    {
        Task OnOpenAsync();
    }
}
