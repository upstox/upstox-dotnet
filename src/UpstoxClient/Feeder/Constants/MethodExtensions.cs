using System;

namespace UpstoxClient.Feeder.Constants
{
    public static class MethodExtensions
    {
        public static string GetValue(this Method method)
        {
            switch (method)
            {
                case Method.Subscribe:
                    return "sub";
                case Method.ChangeMode:
                    return "change_mode";
                case Method.Unsubscribe:
                    return "unsub";
                default:
                    throw new ArgumentOutOfRangeException("method", method, null);
            }
        }
    }
}
