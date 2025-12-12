using System;
using System.Threading.Tasks;

namespace UpstoxClient.Feeder.Listener
{
    public interface IOnErrorListener
    {
        Task OnErrorAsync(System.Exception error);
    }
}
