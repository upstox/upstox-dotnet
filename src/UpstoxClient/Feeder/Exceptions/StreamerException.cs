using System;

namespace UpstoxClient.Feeder.Exceptions
{
    public class StreamerException : Exception
    {
        // Default constructor
        public StreamerException() { }

        // Constructor that takes a message
        public StreamerException(string message)
            : base(message) { }

        // Constructor that takes a message and an inner exception
        // This is useful when you want to capture an exception that caused this exception to be thrown
        public StreamerException(string message, Exception inner)
            : base(message, inner) { }
    }
}
