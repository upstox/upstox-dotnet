namespace UpstoxClient.Feeder.Constants
{
    /// <summary>
    /// Methods used in subscription requests.
    /// </summary>
    public enum Method
    {
        SUBSCRIBE,
        CHANGE_METHOD,
        UNSUBSCRIBE
    }

    internal static class MethodExtensions
    {
        public static string GetValue(this Method method)
        {
            return method switch
            {
                Method.SUBSCRIBE => "sub",
                Method.CHANGE_METHOD => "change_mode",
                Method.UNSUBSCRIBE => "unsub",
                _ => "sub"
            };
        }
    }
}
