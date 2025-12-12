using System;

namespace UpstoxClient.Feeder.Exception
{
    /// <summary>
    /// Represents errors that occur during feeder or streamer operations.
    /// </summary>
    public class StreamerException : System.Exception
    {
        public StreamerException(string message) : base(message)
        {
        }

        public StreamerException(string message, System.Exception innerException) : base(message, innerException)
        {
        }
    }
}
