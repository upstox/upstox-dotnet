/*
 * Upstox .NET SDK — ClientUtils extension
 *
 * Adds SelectHeaderAcceptArray, used by API classes generated with openapi-generator-cli 7.x.
 * Defined as a separate partial to avoid modifying the existing ClientUtils.cs.
 */

using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace UpstoxClient.Client
{
    public static partial class ClientUtils
    {
        /// <summary>
        /// Converts an array of accept header strings into a collection of
        /// <see cref="MediaTypeWithQualityHeaderValue"/> objects suitable for
        /// setting on <c>HttpRequestMessage.Headers.Accept</c>.
        ///
        /// Mirrors the logic of <see cref="SelectHeaderAccept"/>: if
        /// <c>application/json</c> is present it is returned exclusively;
        /// otherwise every entry is returned.
        /// </summary>
        public static IEnumerable<MediaTypeWithQualityHeaderValue> SelectHeaderAcceptArray(string[] accepts)
        {
            if (accepts == null || accepts.Length == 0)
                return Enumerable.Empty<MediaTypeWithQualityHeaderValue>();

            if (accepts.Contains("application/json", System.StringComparer.OrdinalIgnoreCase))
                return new[] { new MediaTypeWithQualityHeaderValue("application/json") };

            return accepts.Select(a => new MediaTypeWithQualityHeaderValue(a));
        }
    }
}
