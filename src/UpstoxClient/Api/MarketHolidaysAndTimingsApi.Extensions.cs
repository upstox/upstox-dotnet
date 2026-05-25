/*
 * Upstox .NET SDK — MarketHolidaysAndTimingsApi extension
 * Adds /market endpoints introduced in the 2025 API revision.
 * Implemented as a partial class to avoid modifying the existing MarketHolidaysAndTimingsApi.cs.
 */

#nullable enable

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using UpstoxClient.Client;
using UpstoxClient.Model;
using System.Diagnostics.CodeAnalysis;

namespace UpstoxClient.Api
{
    // ── Response interfaces ────────────────────────────────────────────────────

    /// <summary>
    /// The <see cref="IGetChangeOiDataApiResponse"/>
    /// </summary>
    public interface IGetChangeOiDataApiResponse : UpstoxClient.Client.IApiResponse, IMethodNotAllowed<UpstoxClient.Model.ApiGatewayErrorResponse?>, IBadRequest<UpstoxClient.Model.ApiGatewayErrorResponse?>, IInternalServerError<UpstoxClient.Model.ApiGatewayErrorResponse?>, ILocked<UpstoxClient.Model.ApiGatewayErrorResponse?>, IUnprocessableContent<UpstoxClient.Model.ApiGatewayErrorResponse?>, ITooManyRequests<UpstoxClient.Model.ApiGatewayErrorResponse?>, IOk<UpstoxClient.Model.AnalyticsResponse?>, IUnauthorized<UpstoxClient.Model.ApiGatewayErrorResponse?>
    {
        /// <summary>
        /// Returns true if the response is 405 MethodNotAllowed
        /// </summary>
        /// <returns></returns>
        bool IsMethodNotAllowed { get; }

        /// <summary>
        /// Returns true if the response is 400 BadRequest
        /// </summary>
        /// <returns></returns>
        bool IsBadRequest { get; }

        /// <summary>
        /// Returns true if the response is 500 InternalServerError
        /// </summary>
        /// <returns></returns>
        bool IsInternalServerError { get; }

        /// <summary>
        /// Returns true if the response is 423 Locked
        /// </summary>
        /// <returns></returns>
        bool IsLocked { get; }

        /// <summary>
        /// Returns true if the response is 422 UnprocessableContent
        /// </summary>
        /// <returns></returns>
        bool IsUnprocessableContent { get; }

        /// <summary>
        /// Returns true if the response is 429 TooManyRequests
        /// </summary>
        /// <returns></returns>
        bool IsTooManyRequests { get; }

        /// <summary>
        /// Returns true if the response is 200 Ok
        /// </summary>
        /// <returns></returns>
        bool IsOk { get; }

        /// <summary>
        /// Returns true if the response is 401 Unauthorized
        /// </summary>
        /// <returns></returns>
        bool IsUnauthorized { get; }
    }

    /// <summary>
    /// The <see cref="IGetDiiDataApiResponse"/>
    /// </summary>
    public interface IGetDiiDataApiResponse : UpstoxClient.Client.IApiResponse, IMethodNotAllowed<UpstoxClient.Model.ApiGatewayErrorResponse?>, IBadRequest<UpstoxClient.Model.ApiGatewayErrorResponse?>, IInternalServerError<UpstoxClient.Model.ApiGatewayErrorResponse?>, ILocked<UpstoxClient.Model.ApiGatewayErrorResponse?>, IUnprocessableContent<UpstoxClient.Model.ApiGatewayErrorResponse?>, ITooManyRequests<UpstoxClient.Model.ApiGatewayErrorResponse?>, IOk<UpstoxClient.Model.AnalyticsResponse?>, IUnauthorized<UpstoxClient.Model.ApiGatewayErrorResponse?>
    {
        /// <summary>
        /// Returns true if the response is 405 MethodNotAllowed
        /// </summary>
        /// <returns></returns>
        bool IsMethodNotAllowed { get; }

        /// <summary>
        /// Returns true if the response is 400 BadRequest
        /// </summary>
        /// <returns></returns>
        bool IsBadRequest { get; }

        /// <summary>
        /// Returns true if the response is 500 InternalServerError
        /// </summary>
        /// <returns></returns>
        bool IsInternalServerError { get; }

        /// <summary>
        /// Returns true if the response is 423 Locked
        /// </summary>
        /// <returns></returns>
        bool IsLocked { get; }

        /// <summary>
        /// Returns true if the response is 422 UnprocessableContent
        /// </summary>
        /// <returns></returns>
        bool IsUnprocessableContent { get; }

        /// <summary>
        /// Returns true if the response is 429 TooManyRequests
        /// </summary>
        /// <returns></returns>
        bool IsTooManyRequests { get; }

        /// <summary>
        /// Returns true if the response is 200 Ok
        /// </summary>
        /// <returns></returns>
        bool IsOk { get; }

        /// <summary>
        /// Returns true if the response is 401 Unauthorized
        /// </summary>
        /// <returns></returns>
        bool IsUnauthorized { get; }
    }

    /// <summary>
    /// The <see cref="IGetFiiDataApiResponse"/>
    /// </summary>
    public interface IGetFiiDataApiResponse : UpstoxClient.Client.IApiResponse, IMethodNotAllowed<UpstoxClient.Model.ApiGatewayErrorResponse?>, IBadRequest<UpstoxClient.Model.ApiGatewayErrorResponse?>, IInternalServerError<UpstoxClient.Model.ApiGatewayErrorResponse?>, ILocked<UpstoxClient.Model.ApiGatewayErrorResponse?>, IUnprocessableContent<UpstoxClient.Model.ApiGatewayErrorResponse?>, ITooManyRequests<UpstoxClient.Model.ApiGatewayErrorResponse?>, IOk<UpstoxClient.Model.AnalyticsResponse?>, IUnauthorized<UpstoxClient.Model.ApiGatewayErrorResponse?>
    {
        /// <summary>
        /// Returns true if the response is 405 MethodNotAllowed
        /// </summary>
        /// <returns></returns>
        bool IsMethodNotAllowed { get; }

        /// <summary>
        /// Returns true if the response is 400 BadRequest
        /// </summary>
        /// <returns></returns>
        bool IsBadRequest { get; }

        /// <summary>
        /// Returns true if the response is 500 InternalServerError
        /// </summary>
        /// <returns></returns>
        bool IsInternalServerError { get; }

        /// <summary>
        /// Returns true if the response is 423 Locked
        /// </summary>
        /// <returns></returns>
        bool IsLocked { get; }

        /// <summary>
        /// Returns true if the response is 422 UnprocessableContent
        /// </summary>
        /// <returns></returns>
        bool IsUnprocessableContent { get; }

        /// <summary>
        /// Returns true if the response is 429 TooManyRequests
        /// </summary>
        /// <returns></returns>
        bool IsTooManyRequests { get; }

        /// <summary>
        /// Returns true if the response is 200 Ok
        /// </summary>
        /// <returns></returns>
        bool IsOk { get; }

        /// <summary>
        /// Returns true if the response is 401 Unauthorized
        /// </summary>
        /// <returns></returns>
        bool IsUnauthorized { get; }
    }

    /// <summary>
    /// The <see cref="IGetMaxPainDataApiResponse"/>
    /// </summary>
    public interface IGetMaxPainDataApiResponse : UpstoxClient.Client.IApiResponse, IMethodNotAllowed<UpstoxClient.Model.ApiGatewayErrorResponse?>, IBadRequest<UpstoxClient.Model.ApiGatewayErrorResponse?>, IInternalServerError<UpstoxClient.Model.ApiGatewayErrorResponse?>, ILocked<UpstoxClient.Model.ApiGatewayErrorResponse?>, IUnprocessableContent<UpstoxClient.Model.ApiGatewayErrorResponse?>, ITooManyRequests<UpstoxClient.Model.ApiGatewayErrorResponse?>, IOk<UpstoxClient.Model.AnalyticsResponse?>, IUnauthorized<UpstoxClient.Model.ApiGatewayErrorResponse?>
    {
        /// <summary>
        /// Returns true if the response is 405 MethodNotAllowed
        /// </summary>
        /// <returns></returns>
        bool IsMethodNotAllowed { get; }

        /// <summary>
        /// Returns true if the response is 400 BadRequest
        /// </summary>
        /// <returns></returns>
        bool IsBadRequest { get; }

        /// <summary>
        /// Returns true if the response is 500 InternalServerError
        /// </summary>
        /// <returns></returns>
        bool IsInternalServerError { get; }

        /// <summary>
        /// Returns true if the response is 423 Locked
        /// </summary>
        /// <returns></returns>
        bool IsLocked { get; }

        /// <summary>
        /// Returns true if the response is 422 UnprocessableContent
        /// </summary>
        /// <returns></returns>
        bool IsUnprocessableContent { get; }

        /// <summary>
        /// Returns true if the response is 429 TooManyRequests
        /// </summary>
        /// <returns></returns>
        bool IsTooManyRequests { get; }

        /// <summary>
        /// Returns true if the response is 200 Ok
        /// </summary>
        /// <returns></returns>
        bool IsOk { get; }

        /// <summary>
        /// Returns true if the response is 401 Unauthorized
        /// </summary>
        /// <returns></returns>
        bool IsUnauthorized { get; }
    }

    /// <summary>
    /// The <see cref="IGetOiDataApiResponse"/>
    /// </summary>
    public interface IGetOiDataApiResponse : UpstoxClient.Client.IApiResponse, IMethodNotAllowed<UpstoxClient.Model.ApiGatewayErrorResponse?>, IBadRequest<UpstoxClient.Model.ApiGatewayErrorResponse?>, IInternalServerError<UpstoxClient.Model.ApiGatewayErrorResponse?>, ILocked<UpstoxClient.Model.ApiGatewayErrorResponse?>, IUnprocessableContent<UpstoxClient.Model.ApiGatewayErrorResponse?>, ITooManyRequests<UpstoxClient.Model.ApiGatewayErrorResponse?>, IOk<UpstoxClient.Model.AnalyticsResponse?>, IUnauthorized<UpstoxClient.Model.ApiGatewayErrorResponse?>
    {
        /// <summary>
        /// Returns true if the response is 405 MethodNotAllowed
        /// </summary>
        /// <returns></returns>
        bool IsMethodNotAllowed { get; }

        /// <summary>
        /// Returns true if the response is 400 BadRequest
        /// </summary>
        /// <returns></returns>
        bool IsBadRequest { get; }

        /// <summary>
        /// Returns true if the response is 500 InternalServerError
        /// </summary>
        /// <returns></returns>
        bool IsInternalServerError { get; }

        /// <summary>
        /// Returns true if the response is 423 Locked
        /// </summary>
        /// <returns></returns>
        bool IsLocked { get; }

        /// <summary>
        /// Returns true if the response is 422 UnprocessableContent
        /// </summary>
        /// <returns></returns>
        bool IsUnprocessableContent { get; }

        /// <summary>
        /// Returns true if the response is 429 TooManyRequests
        /// </summary>
        /// <returns></returns>
        bool IsTooManyRequests { get; }

        /// <summary>
        /// Returns true if the response is 200 Ok
        /// </summary>
        /// <returns></returns>
        bool IsOk { get; }

        /// <summary>
        /// Returns true if the response is 401 Unauthorized
        /// </summary>
        /// <returns></returns>
        bool IsUnauthorized { get; }
    }

    /// <summary>
    /// The <see cref="IGetPcrDataApiResponse"/>
    /// </summary>
    public interface IGetPcrDataApiResponse : UpstoxClient.Client.IApiResponse, IMethodNotAllowed<UpstoxClient.Model.ApiGatewayErrorResponse?>, IBadRequest<UpstoxClient.Model.ApiGatewayErrorResponse?>, IInternalServerError<UpstoxClient.Model.ApiGatewayErrorResponse?>, ILocked<UpstoxClient.Model.ApiGatewayErrorResponse?>, IUnprocessableContent<UpstoxClient.Model.ApiGatewayErrorResponse?>, ITooManyRequests<UpstoxClient.Model.ApiGatewayErrorResponse?>, IOk<UpstoxClient.Model.AnalyticsResponse?>, IUnauthorized<UpstoxClient.Model.ApiGatewayErrorResponse?>
    {
        /// <summary>
        /// Returns true if the response is 405 MethodNotAllowed
        /// </summary>
        /// <returns></returns>
        bool IsMethodNotAllowed { get; }

        /// <summary>
        /// Returns true if the response is 400 BadRequest
        /// </summary>
        /// <returns></returns>
        bool IsBadRequest { get; }

        /// <summary>
        /// Returns true if the response is 500 InternalServerError
        /// </summary>
        /// <returns></returns>
        bool IsInternalServerError { get; }

        /// <summary>
        /// Returns true if the response is 423 Locked
        /// </summary>
        /// <returns></returns>
        bool IsLocked { get; }

        /// <summary>
        /// Returns true if the response is 422 UnprocessableContent
        /// </summary>
        /// <returns></returns>
        bool IsUnprocessableContent { get; }

        /// <summary>
        /// Returns true if the response is 429 TooManyRequests
        /// </summary>
        /// <returns></returns>
        bool IsTooManyRequests { get; }

        /// <summary>
        /// Returns true if the response is 200 Ok
        /// </summary>
        /// <returns></returns>
        bool IsOk { get; }

        /// <summary>
        /// Returns true if the response is 401 Unauthorized
        /// </summary>
        /// <returns></returns>
        bool IsUnauthorized { get; }
    }

    // ── Partial class extension ────────────────────────────────────────────────
    public sealed partial class MarketHolidaysAndTimingsApi
    {
        // ── GetChangeOiData ───────────────────────────────────────────────────

        partial void FormatGetChangeOiData(ref string? instrumentKey, ref string? expiry, ref string? date, ref int? interval);

        /// <summary>
        /// Processes the server response
        /// </summary>
        /// <param name="apiResponseLocalVar"></param>
        /// <param name="instrumentKey"></param>
        /// <param name="expiry"></param>
        /// <param name="date"></param>
        /// <param name="interval"></param>
        private void AfterGetChangeOiDataDefaultImplementation(IGetChangeOiDataApiResponse apiResponseLocalVar, string? instrumentKey, string? expiry, string? date, int? interval)
        {
            bool suppressDefaultLog = false;
            AfterGetChangeOiData(ref suppressDefaultLog, apiResponseLocalVar, instrumentKey, expiry, date, interval);
            if (!suppressDefaultLog)
                Logger.LogInformation("{0,-9} | {1} | {2}", (apiResponseLocalVar.DownloadedAt - apiResponseLocalVar.RequestedAt).TotalSeconds, apiResponseLocalVar.StatusCode, apiResponseLocalVar.Path);
        }

        /// <summary>
        /// Processes the server response
        /// </summary>
        /// <param name="suppressDefaultLog"></param>
        /// <param name="apiResponseLocalVar"></param>
        /// <param name="instrumentKey"></param>
        /// <param name="expiry"></param>
        /// <param name="date"></param>
        /// <param name="interval"></param>
        partial void AfterGetChangeOiData(ref bool suppressDefaultLog, IGetChangeOiDataApiResponse apiResponseLocalVar, string? instrumentKey, string? expiry, string? date, int? interval);

        /// <summary>
        /// Logs exceptions that occur while retrieving the server response
        /// </summary>
        /// <param name="exceptionLocalVar"></param>
        /// <param name="pathFormatLocalVar"></param>
        /// <param name="pathLocalVar"></param>
        /// <param name="instrumentKey"></param>
        /// <param name="expiry"></param>
        /// <param name="date"></param>
        /// <param name="interval"></param>
        private void OnErrorGetChangeOiDataDefaultImplementation(Exception exceptionLocalVar, string pathFormatLocalVar, string pathLocalVar, string? instrumentKey, string? expiry, string? date, int? interval)
        {
            bool suppressDefaultLogLocalVar = false;
            OnErrorGetChangeOiData(ref suppressDefaultLogLocalVar, exceptionLocalVar, pathFormatLocalVar, pathLocalVar, instrumentKey, expiry, date, interval);
            if (!suppressDefaultLogLocalVar)
                Logger.LogError(exceptionLocalVar, "An error occurred while sending the request to the server.");
        }

        /// <summary>
        /// A partial method that gives developers a way to provide customized exception handling
        /// </summary>
        /// <param name="suppressDefaultLogLocalVar"></param>
        /// <param name="exceptionLocalVar"></param>
        /// <param name="pathFormatLocalVar"></param>
        /// <param name="pathLocalVar"></param>
        /// <param name="instrumentKey"></param>
        /// <param name="expiry"></param>
        /// <param name="date"></param>
        /// <param name="interval"></param>
        partial void OnErrorGetChangeOiData(ref bool suppressDefaultLogLocalVar, Exception exceptionLocalVar, string pathFormatLocalVar, string pathLocalVar, string? instrumentKey, string? expiry, string? date, int? interval);

        /// <summary>
        /// Get Change in OI Data Fetches change in OI data for the given instrument key, expiry, date and interval.
        /// </summary>
        /// <param name="instrumentKey">Underlying asset instrument key</param>
        /// <param name="expiry">Expiry date in YYYY-MM-DD format</param>
        /// <param name="date">Date in YYYY-MM-DD format for which change OI data is required</param>
        /// <param name="interval">Number of days for which difference in OI is required</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns><see cref="Task"/>&lt;<see cref="IGetChangeOiDataApiResponse"/>&gt;</returns>
        public async Task<IGetChangeOiDataApiResponse?> GetChangeOiDataOrDefaultAsync(string? instrumentKey = default, string? expiry = default, string? date = default, int? interval = default, System.Threading.CancellationToken cancellationToken = default)
        {
            try
            {
                return await GetChangeOiDataAsync(instrumentKey, expiry, date, interval, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Get Change in OI Data Fetches change in OI data for the given instrument key, expiry, date and interval.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="instrumentKey">Underlying asset instrument key</param>
        /// <param name="expiry">Expiry date in YYYY-MM-DD format</param>
        /// <param name="date">Date in YYYY-MM-DD format for which change OI data is required</param>
        /// <param name="interval">Number of days for which difference in OI is required</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns><see cref="Task"/>&lt;<see cref="IGetChangeOiDataApiResponse"/>&gt;</returns>
        public async Task<IGetChangeOiDataApiResponse> GetChangeOiDataAsync(string? instrumentKey = default, string? expiry = default, string? date = default, int? interval = default, System.Threading.CancellationToken cancellationToken = default)
        {
            UriBuilder uriBuilderLocalVar = new UriBuilder();

            try
            {
                FormatGetChangeOiData(ref instrumentKey, ref expiry, ref date, ref interval);

                using (HttpRequestMessage httpRequestMessageLocalVar = new HttpRequestMessage())
                {
                    uriBuilderLocalVar.Host = HttpClient.BaseAddress!.Host;
                    uriBuilderLocalVar.Port = HttpClient.BaseAddress.Port;
                    uriBuilderLocalVar.Scheme = HttpClient.BaseAddress.Scheme;
                    uriBuilderLocalVar.Path = HttpClient.BaseAddress.AbsolutePath == "/"
                        ? "/v2/market/change-oi"
                        : string.Concat(HttpClient.BaseAddress.AbsolutePath.TrimEnd('/'), "/v2/market/change-oi");

                    System.Collections.Specialized.NameValueCollection parseQueryStringLocalVar = System.Web.HttpUtility.ParseQueryString(string.Empty);

                    parseQueryStringLocalVar["instrument_key"] = ClientUtils.ParameterToString(instrumentKey);
                    parseQueryStringLocalVar["expiry"] = ClientUtils.ParameterToString(expiry);
                    parseQueryStringLocalVar["date"] = ClientUtils.ParameterToString(date);
                    parseQueryStringLocalVar["interval"] = ClientUtils.ParameterToString(interval);

                    uriBuilderLocalVar.Query = parseQueryStringLocalVar.ToString();

                    List<TokenBase> tokenBaseLocalVars = new List<TokenBase>();
                    httpRequestMessageLocalVar.RequestUri = uriBuilderLocalVar.Uri;

                    OAuthToken oauthTokenLocalVar1 = (OAuthToken) await OauthTokenProvider.GetAsync(cancellation: cancellationToken).ConfigureAwait(false);

                    tokenBaseLocalVars.Add(oauthTokenLocalVar1);

                    oauthTokenLocalVar1.UseInHeader(httpRequestMessageLocalVar, "");

                    string[] acceptLocalVars = new string[] {
                        "*/*",
                        "application/json"
                    };

                    IEnumerable<MediaTypeWithQualityHeaderValue> acceptHeaderValuesLocalVar = ClientUtils.SelectHeaderAcceptArray(acceptLocalVars);

                    foreach (var acceptLocalVar in acceptHeaderValuesLocalVar)
                        httpRequestMessageLocalVar.Headers.Accept.Add(acceptLocalVar);

                    httpRequestMessageLocalVar.Method = HttpMethod.Get;

                    DateTime requestedAtLocalVar = DateTime.UtcNow;

                    using (HttpResponseMessage httpResponseMessageLocalVar = await HttpClient.SendAsync(httpRequestMessageLocalVar, cancellationToken).ConfigureAwait(false))
                    {
                        ILogger<GetChangeOiDataApiResponse> apiResponseLoggerLocalVar = LoggerFactory.CreateLogger<GetChangeOiDataApiResponse>();
                        GetChangeOiDataApiResponse apiResponseLocalVar;

                        switch ((int)httpResponseMessageLocalVar.StatusCode) {
                            default: {
                                string responseContentLocalVar = await httpResponseMessageLocalVar.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                                apiResponseLocalVar = new(apiResponseLoggerLocalVar, httpRequestMessageLocalVar, httpResponseMessageLocalVar, responseContentLocalVar, "/v2/market/change-oi", requestedAtLocalVar, _jsonSerializerOptions);

                                break;
                            }
                        }

                        AfterGetChangeOiDataDefaultImplementation(apiResponseLocalVar, instrumentKey, expiry, date, interval);

                        if (apiResponseLocalVar.StatusCode == (HttpStatusCode) 429)
                            foreach(TokenBase tokenBaseLocalVar in tokenBaseLocalVars)
                                tokenBaseLocalVar.BeginRateLimit();

                        return apiResponseLocalVar;
                    }
                }
            }
            catch(Exception e)
            {
                OnErrorGetChangeOiDataDefaultImplementation(e, "/v2/market/change-oi", uriBuilderLocalVar.Path, instrumentKey, expiry, date, interval);
                throw;
            }
        }

        /// <summary>
        /// The <see cref="GetChangeOiDataApiResponse"/>
        /// </summary>
        public partial class GetChangeOiDataApiResponse : UpstoxClient.Client.ApiResponse, IGetChangeOiDataApiResponse
        {
            /// <summary>
            /// The logger
            /// </summary>
            public ILogger<GetChangeOiDataApiResponse> Logger { get; }

            /// <summary>
            /// The <see cref="GetChangeOiDataApiResponse"/>
            /// </summary>
            /// <param name="logger"></param>
            /// <param name="httpRequestMessage"></param>
            /// <param name="httpResponseMessage"></param>
            /// <param name="rawContent"></param>
            /// <param name="path"></param>
            /// <param name="requestedAt"></param>
            /// <param name="jsonSerializerOptions"></param>
            public GetChangeOiDataApiResponse(ILogger<GetChangeOiDataApiResponse> logger, System.Net.Http.HttpRequestMessage httpRequestMessage, System.Net.Http.HttpResponseMessage httpResponseMessage, string rawContent, string path, DateTime requestedAt, System.Text.Json.JsonSerializerOptions jsonSerializerOptions) : base(httpRequestMessage, httpResponseMessage, rawContent, path, requestedAt, jsonSerializerOptions)
            {
                Logger = logger;
                OnCreated(httpRequestMessage, httpResponseMessage);
            }

            /// <summary>
            /// The <see cref="GetChangeOiDataApiResponse"/>
            /// </summary>
            /// <param name="logger"></param>
            /// <param name="httpRequestMessage"></param>
            /// <param name="httpResponseMessage"></param>
            /// <param name="contentStream"></param>
            /// <param name="path"></param>
            /// <param name="requestedAt"></param>
            /// <param name="jsonSerializerOptions"></param>
            public GetChangeOiDataApiResponse(ILogger<GetChangeOiDataApiResponse> logger, System.Net.Http.HttpRequestMessage httpRequestMessage, System.Net.Http.HttpResponseMessage httpResponseMessage, System.IO.Stream contentStream, string path, DateTime requestedAt, System.Text.Json.JsonSerializerOptions jsonSerializerOptions) : base(httpRequestMessage, httpResponseMessage, contentStream, path, requestedAt, jsonSerializerOptions)
            {
                Logger = logger;
                OnCreated(httpRequestMessage, httpResponseMessage);
            }

            partial void OnCreated(global::System.Net.Http.HttpRequestMessage httpRequestMessage, System.Net.Http.HttpResponseMessage httpResponseMessage);

            /// <summary>
            /// Returns true if the response is 405 MethodNotAllowed
            /// </summary>
            /// <returns></returns>
            public bool IsMethodNotAllowed => 405 == (int)StatusCode;

            /// <summary>
            /// Deserializes the response if the response is 405 MethodNotAllowed
            /// </summary>
            /// <returns></returns>
            public UpstoxClient.Model.ApiGatewayErrorResponse? MethodNotAllowed()
            {
                // This logic may be modified with the AsModel.mustache template
                return IsMethodNotAllowed
                    ? System.Text.Json.JsonSerializer.Deserialize<UpstoxClient.Model.ApiGatewayErrorResponse>(RawContent, _jsonSerializerOptions)
                    : null;
            }

            /// <summary>
            /// Returns true if the response is 405 MethodNotAllowed and the deserialized response is not null
            /// </summary>
            /// <param name="result"></param>
            /// <returns></returns>
            public bool TryMethodNotAllowed([NotNullWhen(true)]out UpstoxClient.Model.ApiGatewayErrorResponse? result)
            {
                result = null;

                try
                {
                    result = MethodNotAllowed();
                } catch (Exception e)
                {
                    OnDeserializationErrorDefaultImplementation(e, (HttpStatusCode)405);
                }

                return result != null;
            }

            /// <summary>
            /// Returns true if the response is 400 BadRequest
            /// </summary>
            /// <returns></returns>
            public bool IsBadRequest => 400 == (int)StatusCode;

            /// <summary>
            /// Deserializes the response if the response is 400 BadRequest
            /// </summary>
            /// <returns></returns>
            public UpstoxClient.Model.ApiGatewayErrorResponse? BadRequest()
            {
                // This logic may be modified with the AsModel.mustache template
                return IsBadRequest
                    ? System.Text.Json.JsonSerializer.Deserialize<UpstoxClient.Model.ApiGatewayErrorResponse>(RawContent, _jsonSerializerOptions)
                    : null;
            }

            /// <summary>
            /// Returns true if the response is 400 BadRequest and the deserialized response is not null
            /// </summary>
            /// <param name="result"></param>
            /// <returns></returns>
            public bool TryBadRequest([NotNullWhen(true)]out UpstoxClient.Model.ApiGatewayErrorResponse? result)
            {
                result = null;

                try
                {
                    result = BadRequest();
                } catch (Exception e)
                {
                    OnDeserializationErrorDefaultImplementation(e, (HttpStatusCode)400);
                }

                return result != null;
            }

            /// <summary>
            /// Returns true if the response is 500 InternalServerError
            /// </summary>
            /// <returns></returns>
            public bool IsInternalServerError => 500 == (int)StatusCode;

            /// <summary>
            /// Deserializes the response if the response is 500 InternalServerError
            /// </summary>
            /// <returns></returns>
            public UpstoxClient.Model.ApiGatewayErrorResponse? InternalServerError()
            {
                // This logic may be modified with the AsModel.mustache template
                return IsInternalServerError
                    ? System.Text.Json.JsonSerializer.Deserialize<UpstoxClient.Model.ApiGatewayErrorResponse>(RawContent, _jsonSerializerOptions)
                    : null;
            }

            /// <summary>
            /// Returns true if the response is 500 InternalServerError and the deserialized response is not null
            /// </summary>
            /// <param name="result"></param>
            /// <returns></returns>
            public bool TryInternalServerError([NotNullWhen(true)]out UpstoxClient.Model.ApiGatewayErrorResponse? result)
            {
                result = null;

                try
                {
                    result = InternalServerError();
                } catch (Exception e)
                {
                    OnDeserializationErrorDefaultImplementation(e, (HttpStatusCode)500);
                }

                return result != null;
            }

            /// <summary>
            /// Returns true if the response is 423 Locked
            /// </summary>
            /// <returns></returns>
            public bool IsLocked => 423 == (int)StatusCode;

            /// <summary>
            /// Deserializes the response if the response is 423 Locked
            /// </summary>
            /// <returns></returns>
            public UpstoxClient.Model.ApiGatewayErrorResponse? Locked()
            {
                // This logic may be modified with the AsModel.mustache template
                return IsLocked
                    ? System.Text.Json.JsonSerializer.Deserialize<UpstoxClient.Model.ApiGatewayErrorResponse>(RawContent, _jsonSerializerOptions)
                    : null;
            }

            /// <summary>
            /// Returns true if the response is 423 Locked and the deserialized response is not null
            /// </summary>
            /// <param name="result"></param>
            /// <returns></returns>
            public bool TryLocked([NotNullWhen(true)]out UpstoxClient.Model.ApiGatewayErrorResponse? result)
            {
                result = null;

                try
                {
                    result = Locked();
                } catch (Exception e)
                {
                    OnDeserializationErrorDefaultImplementation(e, (HttpStatusCode)423);
                }

                return result != null;
            }

            /// <summary>
            /// Returns true if the response is 422 UnprocessableContent
            /// </summary>
            /// <returns></returns>
            public bool IsUnprocessableContent => 422 == (int)StatusCode;

            /// <summary>
            /// Deserializes the response if the response is 422 UnprocessableContent
            /// </summary>
            /// <returns></returns>
            public UpstoxClient.Model.ApiGatewayErrorResponse? UnprocessableContent()
            {
                // This logic may be modified with the AsModel.mustache template
                return IsUnprocessableContent
                    ? System.Text.Json.JsonSerializer.Deserialize<UpstoxClient.Model.ApiGatewayErrorResponse>(RawContent, _jsonSerializerOptions)
                    : null;
            }

            /// <summary>
            /// Returns true if the response is 422 UnprocessableContent and the deserialized response is not null
            /// </summary>
            /// <param name="result"></param>
            /// <returns></returns>
            public bool TryUnprocessableContent([NotNullWhen(true)]out UpstoxClient.Model.ApiGatewayErrorResponse? result)
            {
                result = null;

                try
                {
                    result = UnprocessableContent();
                } catch (Exception e)
                {
                    OnDeserializationErrorDefaultImplementation(e, (HttpStatusCode)422);
                }

                return result != null;
            }

            /// <summary>
            /// Returns true if the response is 429 TooManyRequests
            /// </summary>
            /// <returns></returns>
            public bool IsTooManyRequests => 429 == (int)StatusCode;

            /// <summary>
            /// Deserializes the response if the response is 429 TooManyRequests
            /// </summary>
            /// <returns></returns>
            public UpstoxClient.Model.ApiGatewayErrorResponse? TooManyRequests()
            {
                // This logic may be modified with the AsModel.mustache template
                return IsTooManyRequests
                    ? System.Text.Json.JsonSerializer.Deserialize<UpstoxClient.Model.ApiGatewayErrorResponse>(RawContent, _jsonSerializerOptions)
                    : null;
            }

            /// <summary>
            /// Returns true if the response is 429 TooManyRequests and the deserialized response is not null
            /// </summary>
            /// <param name="result"></param>
            /// <returns></returns>
            public bool TryTooManyRequests([NotNullWhen(true)]out UpstoxClient.Model.ApiGatewayErrorResponse? result)
            {
                result = null;

                try
                {
                    result = TooManyRequests();
                } catch (Exception e)
                {
                    OnDeserializationErrorDefaultImplementation(e, (HttpStatusCode)429);
                }

                return result != null;
            }

            /// <summary>
            /// Returns true if the response is 200 Ok
            /// </summary>
            /// <returns></returns>
            public bool IsOk => 200 == (int)StatusCode;

            /// <summary>
            /// Deserializes the response if the response is 200 Ok
            /// </summary>
            /// <returns></returns>
            public UpstoxClient.Model.AnalyticsResponse? Ok()
            {
                // This logic may be modified with the AsModel.mustache template
                return IsOk
                    ? System.Text.Json.JsonSerializer.Deserialize<UpstoxClient.Model.AnalyticsResponse>(RawContent, _jsonSerializerOptions)
                    : null;
            }

            /// <summary>
            /// Returns true if the response is 200 Ok and the deserialized response is not null
            /// </summary>
            /// <param name="result"></param>
            /// <returns></returns>
            public bool TryOk([NotNullWhen(true)]out UpstoxClient.Model.AnalyticsResponse? result)
            {
                result = null;

                try
                {
                    result = Ok();
                } catch (Exception e)
                {
                    OnDeserializationErrorDefaultImplementation(e, (HttpStatusCode)200);
                }

                return result != null;
            }

            /// <summary>
            /// Returns true if the response is 401 Unauthorized
            /// </summary>
            /// <returns></returns>
            public bool IsUnauthorized => 401 == (int)StatusCode;

            /// <summary>
            /// Deserializes the response if the response is 401 Unauthorized
            /// </summary>
            /// <returns></returns>
            public UpstoxClient.Model.ApiGatewayErrorResponse? Unauthorized()
            {
                // This logic may be modified with the AsModel.mustache template
                return IsUnauthorized
                    ? System.Text.Json.JsonSerializer.Deserialize<UpstoxClient.Model.ApiGatewayErrorResponse>(RawContent, _jsonSerializerOptions)
                    : null;
            }

            /// <summary>
            /// Returns true if the response is 401 Unauthorized and the deserialized response is not null
            /// </summary>
            /// <param name="result"></param>
            /// <returns></returns>
            public bool TryUnauthorized([NotNullWhen(true)]out UpstoxClient.Model.ApiGatewayErrorResponse? result)
            {
                result = null;

                try
                {
                    result = Unauthorized();
                } catch (Exception e)
                {
                    OnDeserializationErrorDefaultImplementation(e, (HttpStatusCode)401);
                }

                return result != null;
            }

            private void OnDeserializationErrorDefaultImplementation(Exception exception, HttpStatusCode httpStatusCode)
            {
                bool suppressDefaultLog = false;
                OnDeserializationError(ref suppressDefaultLog, exception, httpStatusCode);
                if (!suppressDefaultLog)
                    Logger.LogError(exception, "An error occurred while deserializing the {code} response.", httpStatusCode);
            }

            partial void OnDeserializationError(ref bool suppressDefaultLog, Exception exception, HttpStatusCode httpStatusCode);
        }

        // ── GetDiiData ────────────────────────────────────────────────────────

        partial void FormatGetDiiData(ref string? dataType, ref string? interval, ref Option<string?> from);

        /// <summary>
        /// Processes the server response
        /// </summary>
        /// <param name="apiResponseLocalVar"></param>
        /// <param name="dataType"></param>
        /// <param name="interval"></param>
        /// <param name="from"></param>
        private void AfterGetDiiDataDefaultImplementation(IGetDiiDataApiResponse apiResponseLocalVar, string? dataType, string? interval, Option<string?> from)
        {
            bool suppressDefaultLog = false;
            AfterGetDiiData(ref suppressDefaultLog, apiResponseLocalVar, dataType, interval, from);
            if (!suppressDefaultLog)
                Logger.LogInformation("{0,-9} | {1} | {2}", (apiResponseLocalVar.DownloadedAt - apiResponseLocalVar.RequestedAt).TotalSeconds, apiResponseLocalVar.StatusCode, apiResponseLocalVar.Path);
        }

        /// <summary>
        /// Processes the server response
        /// </summary>
        /// <param name="suppressDefaultLog"></param>
        /// <param name="apiResponseLocalVar"></param>
        /// <param name="dataType"></param>
        /// <param name="interval"></param>
        /// <param name="from"></param>
        partial void AfterGetDiiData(ref bool suppressDefaultLog, IGetDiiDataApiResponse apiResponseLocalVar, string? dataType, string? interval, Option<string?> from);

        /// <summary>
        /// Logs exceptions that occur while retrieving the server response
        /// </summary>
        /// <param name="exceptionLocalVar"></param>
        /// <param name="pathFormatLocalVar"></param>
        /// <param name="pathLocalVar"></param>
        /// <param name="dataType"></param>
        /// <param name="interval"></param>
        /// <param name="from"></param>
        private void OnErrorGetDiiDataDefaultImplementation(Exception exceptionLocalVar, string pathFormatLocalVar, string pathLocalVar, string? dataType, string? interval, Option<string?> from)
        {
            bool suppressDefaultLogLocalVar = false;
            OnErrorGetDiiData(ref suppressDefaultLogLocalVar, exceptionLocalVar, pathFormatLocalVar, pathLocalVar, dataType, interval, from);
            if (!suppressDefaultLogLocalVar)
                Logger.LogError(exceptionLocalVar, "An error occurred while sending the request to the server.");
        }

        /// <summary>
        /// A partial method that gives developers a way to provide customized exception handling
        /// </summary>
        /// <param name="suppressDefaultLogLocalVar"></param>
        /// <param name="exceptionLocalVar"></param>
        /// <param name="pathFormatLocalVar"></param>
        /// <param name="pathLocalVar"></param>
        /// <param name="dataType"></param>
        /// <param name="interval"></param>
        /// <param name="from"></param>
        partial void OnErrorGetDiiData(ref bool suppressDefaultLogLocalVar, Exception exceptionLocalVar, string pathFormatLocalVar, string pathLocalVar, string? dataType, string? interval, Option<string?> from);

        /// <summary>
        /// Get DII Data Fetches DII activity data for the given interval.
        /// </summary>
        /// <param name="dataType">Data type. Allowed value: NSE_EQ|CASH</param>
        /// <param name="interval">Interval. Allowed values: 1D, 1M</param>
        /// <param name="from">Start date in YYYY-MM-DD format (optional) (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns><see cref="Task"/>&lt;<see cref="IGetDiiDataApiResponse"/>&gt;</returns>
        public async Task<IGetDiiDataApiResponse?> GetDiiDataOrDefaultAsync(string? dataType = default, string? interval = default, Option<string?> from = default, System.Threading.CancellationToken cancellationToken = default)
        {
            try
            {
                return await GetDiiDataAsync(dataType, interval, from, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Get DII Data Fetches DII activity data for the given interval.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="dataType">Data type. Allowed value: NSE_EQ|CASH</param>
        /// <param name="interval">Interval. Allowed values: 1D, 1M</param>
        /// <param name="from">Start date in YYYY-MM-DD format (optional) (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns><see cref="Task"/>&lt;<see cref="IGetDiiDataApiResponse"/>&gt;</returns>
        public async Task<IGetDiiDataApiResponse> GetDiiDataAsync(string? dataType = default, string? interval = default, Option<string?> from = default, System.Threading.CancellationToken cancellationToken = default)
        {
            UriBuilder uriBuilderLocalVar = new UriBuilder();

            try
            {
                FormatGetDiiData(ref dataType, ref interval, ref from);

                using (HttpRequestMessage httpRequestMessageLocalVar = new HttpRequestMessage())
                {
                    uriBuilderLocalVar.Host = HttpClient.BaseAddress!.Host;
                    uriBuilderLocalVar.Port = HttpClient.BaseAddress.Port;
                    uriBuilderLocalVar.Scheme = HttpClient.BaseAddress.Scheme;
                    uriBuilderLocalVar.Path = HttpClient.BaseAddress.AbsolutePath == "/"
                        ? "/v2/market/dii"
                        : string.Concat(HttpClient.BaseAddress.AbsolutePath.TrimEnd('/'), "/v2/market/dii");

                    System.Collections.Specialized.NameValueCollection parseQueryStringLocalVar = System.Web.HttpUtility.ParseQueryString(string.Empty);

                    parseQueryStringLocalVar["data_type"] = ClientUtils.ParameterToString(dataType);
                    parseQueryStringLocalVar["interval"] = ClientUtils.ParameterToString(interval);

                    if (from.IsSet)
                        parseQueryStringLocalVar["from"] = ClientUtils.ParameterToString(from.Value);

                    uriBuilderLocalVar.Query = parseQueryStringLocalVar.ToString();

                    List<TokenBase> tokenBaseLocalVars = new List<TokenBase>();
                    httpRequestMessageLocalVar.RequestUri = uriBuilderLocalVar.Uri;

                    OAuthToken oauthTokenLocalVar1 = (OAuthToken) await OauthTokenProvider.GetAsync(cancellation: cancellationToken).ConfigureAwait(false);

                    tokenBaseLocalVars.Add(oauthTokenLocalVar1);

                    oauthTokenLocalVar1.UseInHeader(httpRequestMessageLocalVar, "");

                    string[] acceptLocalVars = new string[] {
                        "*/*",
                        "application/json"
                    };

                    IEnumerable<MediaTypeWithQualityHeaderValue> acceptHeaderValuesLocalVar = ClientUtils.SelectHeaderAcceptArray(acceptLocalVars);

                    foreach (var acceptLocalVar in acceptHeaderValuesLocalVar)
                        httpRequestMessageLocalVar.Headers.Accept.Add(acceptLocalVar);

                    httpRequestMessageLocalVar.Method = HttpMethod.Get;

                    DateTime requestedAtLocalVar = DateTime.UtcNow;

                    using (HttpResponseMessage httpResponseMessageLocalVar = await HttpClient.SendAsync(httpRequestMessageLocalVar, cancellationToken).ConfigureAwait(false))
                    {
                        ILogger<GetDiiDataApiResponse> apiResponseLoggerLocalVar = LoggerFactory.CreateLogger<GetDiiDataApiResponse>();
                        GetDiiDataApiResponse apiResponseLocalVar;

                        switch ((int)httpResponseMessageLocalVar.StatusCode) {
                            default: {
                                string responseContentLocalVar = await httpResponseMessageLocalVar.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                                apiResponseLocalVar = new(apiResponseLoggerLocalVar, httpRequestMessageLocalVar, httpResponseMessageLocalVar, responseContentLocalVar, "/v2/market/dii", requestedAtLocalVar, _jsonSerializerOptions);

                                break;
                            }
                        }

                        AfterGetDiiDataDefaultImplementation(apiResponseLocalVar, dataType, interval, from);

                        if (apiResponseLocalVar.StatusCode == (HttpStatusCode) 429)
                            foreach(TokenBase tokenBaseLocalVar in tokenBaseLocalVars)
                                tokenBaseLocalVar.BeginRateLimit();

                        return apiResponseLocalVar;
                    }
                }
            }
            catch(Exception e)
            {
                OnErrorGetDiiDataDefaultImplementation(e, "/v2/market/dii", uriBuilderLocalVar.Path, dataType, interval, from);
                throw;
            }
        }

        /// <summary>
        /// The <see cref="GetDiiDataApiResponse"/>
        /// </summary>
        public partial class GetDiiDataApiResponse : UpstoxClient.Client.ApiResponse, IGetDiiDataApiResponse
        {
            /// <summary>
            /// The logger
            /// </summary>
            public ILogger<GetDiiDataApiResponse> Logger { get; }

            /// <summary>
            /// The <see cref="GetDiiDataApiResponse"/>
            /// </summary>
            /// <param name="logger"></param>
            /// <param name="httpRequestMessage"></param>
            /// <param name="httpResponseMessage"></param>
            /// <param name="rawContent"></param>
            /// <param name="path"></param>
            /// <param name="requestedAt"></param>
            /// <param name="jsonSerializerOptions"></param>
            public GetDiiDataApiResponse(ILogger<GetDiiDataApiResponse> logger, System.Net.Http.HttpRequestMessage httpRequestMessage, System.Net.Http.HttpResponseMessage httpResponseMessage, string rawContent, string path, DateTime requestedAt, System.Text.Json.JsonSerializerOptions jsonSerializerOptions) : base(httpRequestMessage, httpResponseMessage, rawContent, path, requestedAt, jsonSerializerOptions)
            {
                Logger = logger;
                OnCreated(httpRequestMessage, httpResponseMessage);
            }

            /// <summary>
            /// The <see cref="GetDiiDataApiResponse"/>
            /// </summary>
            /// <param name="logger"></param>
            /// <param name="httpRequestMessage"></param>
            /// <param name="httpResponseMessage"></param>
            /// <param name="contentStream"></param>
            /// <param name="path"></param>
            /// <param name="requestedAt"></param>
            /// <param name="jsonSerializerOptions"></param>
            public GetDiiDataApiResponse(ILogger<GetDiiDataApiResponse> logger, System.Net.Http.HttpRequestMessage httpRequestMessage, System.Net.Http.HttpResponseMessage httpResponseMessage, System.IO.Stream contentStream, string path, DateTime requestedAt, System.Text.Json.JsonSerializerOptions jsonSerializerOptions) : base(httpRequestMessage, httpResponseMessage, contentStream, path, requestedAt, jsonSerializerOptions)
            {
                Logger = logger;
                OnCreated(httpRequestMessage, httpResponseMessage);
            }

            partial void OnCreated(global::System.Net.Http.HttpRequestMessage httpRequestMessage, System.Net.Http.HttpResponseMessage httpResponseMessage);

            /// <summary>Returns true if the response is 405 MethodNotAllowed</summary>
            public bool IsMethodNotAllowed => 405 == (int)StatusCode;

            /// <summary>Deserializes the response if the response is 405 MethodNotAllowed</summary>
            public UpstoxClient.Model.ApiGatewayErrorResponse? MethodNotAllowed()
            {
                return IsMethodNotAllowed ? System.Text.Json.JsonSerializer.Deserialize<UpstoxClient.Model.ApiGatewayErrorResponse>(RawContent, _jsonSerializerOptions) : null;
            }

            /// <summary>Returns true if the response is 405 MethodNotAllowed and the deserialized response is not null</summary>
            public bool TryMethodNotAllowed([NotNullWhen(true)]out UpstoxClient.Model.ApiGatewayErrorResponse? result)
            {
                result = null;
                try { result = MethodNotAllowed(); } catch (Exception e) { OnDeserializationErrorDefaultImplementation(e, (HttpStatusCode)405); }
                return result != null;
            }

            /// <summary>Returns true if the response is 400 BadRequest</summary>
            public bool IsBadRequest => 400 == (int)StatusCode;

            /// <summary>Deserializes the response if the response is 400 BadRequest</summary>
            public UpstoxClient.Model.ApiGatewayErrorResponse? BadRequest()
            {
                return IsBadRequest ? System.Text.Json.JsonSerializer.Deserialize<UpstoxClient.Model.ApiGatewayErrorResponse>(RawContent, _jsonSerializerOptions) : null;
            }

            /// <summary>Returns true if the response is 400 BadRequest and the deserialized response is not null</summary>
            public bool TryBadRequest([NotNullWhen(true)]out UpstoxClient.Model.ApiGatewayErrorResponse? result)
            {
                result = null;
                try { result = BadRequest(); } catch (Exception e) { OnDeserializationErrorDefaultImplementation(e, (HttpStatusCode)400); }
                return result != null;
            }

            /// <summary>Returns true if the response is 500 InternalServerError</summary>
            public bool IsInternalServerError => 500 == (int)StatusCode;

            /// <summary>Deserializes the response if the response is 500 InternalServerError</summary>
            public UpstoxClient.Model.ApiGatewayErrorResponse? InternalServerError()
            {
                return IsInternalServerError ? System.Text.Json.JsonSerializer.Deserialize<UpstoxClient.Model.ApiGatewayErrorResponse>(RawContent, _jsonSerializerOptions) : null;
            }

            /// <summary>Returns true if the response is 500 InternalServerError and the deserialized response is not null</summary>
            public bool TryInternalServerError([NotNullWhen(true)]out UpstoxClient.Model.ApiGatewayErrorResponse? result)
            {
                result = null;
                try { result = InternalServerError(); } catch (Exception e) { OnDeserializationErrorDefaultImplementation(e, (HttpStatusCode)500); }
                return result != null;
            }

            /// <summary>Returns true if the response is 423 Locked</summary>
            public bool IsLocked => 423 == (int)StatusCode;

            /// <summary>Deserializes the response if the response is 423 Locked</summary>
            public UpstoxClient.Model.ApiGatewayErrorResponse? Locked()
            {
                return IsLocked ? System.Text.Json.JsonSerializer.Deserialize<UpstoxClient.Model.ApiGatewayErrorResponse>(RawContent, _jsonSerializerOptions) : null;
            }

            /// <summary>Returns true if the response is 423 Locked and the deserialized response is not null</summary>
            public bool TryLocked([NotNullWhen(true)]out UpstoxClient.Model.ApiGatewayErrorResponse? result)
            {
                result = null;
                try { result = Locked(); } catch (Exception e) { OnDeserializationErrorDefaultImplementation(e, (HttpStatusCode)423); }
                return result != null;
            }

            /// <summary>Returns true if the response is 422 UnprocessableContent</summary>
            public bool IsUnprocessableContent => 422 == (int)StatusCode;

            /// <summary>Deserializes the response if the response is 422 UnprocessableContent</summary>
            public UpstoxClient.Model.ApiGatewayErrorResponse? UnprocessableContent()
            {
                return IsUnprocessableContent ? System.Text.Json.JsonSerializer.Deserialize<UpstoxClient.Model.ApiGatewayErrorResponse>(RawContent, _jsonSerializerOptions) : null;
            }

            /// <summary>Returns true if the response is 422 UnprocessableContent and the deserialized response is not null</summary>
            public bool TryUnprocessableContent([NotNullWhen(true)]out UpstoxClient.Model.ApiGatewayErrorResponse? result)
            {
                result = null;
                try { result = UnprocessableContent(); } catch (Exception e) { OnDeserializationErrorDefaultImplementation(e, (HttpStatusCode)422); }
                return result != null;
            }

            /// <summary>Returns true if the response is 429 TooManyRequests</summary>
            public bool IsTooManyRequests => 429 == (int)StatusCode;

            /// <summary>Deserializes the response if the response is 429 TooManyRequests</summary>
            public UpstoxClient.Model.ApiGatewayErrorResponse? TooManyRequests()
            {
                return IsTooManyRequests ? System.Text.Json.JsonSerializer.Deserialize<UpstoxClient.Model.ApiGatewayErrorResponse>(RawContent, _jsonSerializerOptions) : null;
            }

            /// <summary>Returns true if the response is 429 TooManyRequests and the deserialized response is not null</summary>
            public bool TryTooManyRequests([NotNullWhen(true)]out UpstoxClient.Model.ApiGatewayErrorResponse? result)
            {
                result = null;
                try { result = TooManyRequests(); } catch (Exception e) { OnDeserializationErrorDefaultImplementation(e, (HttpStatusCode)429); }
                return result != null;
            }

            /// <summary>Returns true if the response is 200 Ok</summary>
            public bool IsOk => 200 == (int)StatusCode;

            /// <summary>Deserializes the response if the response is 200 Ok</summary>
            public UpstoxClient.Model.AnalyticsResponse? Ok()
            {
                return IsOk ? System.Text.Json.JsonSerializer.Deserialize<UpstoxClient.Model.AnalyticsResponse>(RawContent, _jsonSerializerOptions) : null;
            }

            /// <summary>Returns true if the response is 200 Ok and the deserialized response is not null</summary>
            public bool TryOk([NotNullWhen(true)]out UpstoxClient.Model.AnalyticsResponse? result)
            {
                result = null;
                try { result = Ok(); } catch (Exception e) { OnDeserializationErrorDefaultImplementation(e, (HttpStatusCode)200); }
                return result != null;
            }

            /// <summary>Returns true if the response is 401 Unauthorized</summary>
            public bool IsUnauthorized => 401 == (int)StatusCode;

            /// <summary>Deserializes the response if the response is 401 Unauthorized</summary>
            public UpstoxClient.Model.ApiGatewayErrorResponse? Unauthorized()
            {
                return IsUnauthorized ? System.Text.Json.JsonSerializer.Deserialize<UpstoxClient.Model.ApiGatewayErrorResponse>(RawContent, _jsonSerializerOptions) : null;
            }

            /// <summary>Returns true if the response is 401 Unauthorized and the deserialized response is not null</summary>
            public bool TryUnauthorized([NotNullWhen(true)]out UpstoxClient.Model.ApiGatewayErrorResponse? result)
            {
                result = null;
                try { result = Unauthorized(); } catch (Exception e) { OnDeserializationErrorDefaultImplementation(e, (HttpStatusCode)401); }
                return result != null;
            }

            private void OnDeserializationErrorDefaultImplementation(Exception exception, HttpStatusCode httpStatusCode)
            {
                bool suppressDefaultLog = false;
                OnDeserializationError(ref suppressDefaultLog, exception, httpStatusCode);
                if (!suppressDefaultLog)
                    Logger.LogError(exception, "An error occurred while deserializing the {code} response.", httpStatusCode);
            }

            partial void OnDeserializationError(ref bool suppressDefaultLog, Exception exception, HttpStatusCode httpStatusCode);
        }

        // ── GetFiiData ────────────────────────────────────────────────────────

        partial void FormatGetFiiData(ref string? dataType, ref string? interval, ref Option<string?> from);

        private void AfterGetFiiDataDefaultImplementation(IGetFiiDataApiResponse apiResponseLocalVar, string? dataType, string? interval, Option<string?> from)
        {
            bool suppressDefaultLog = false;
            AfterGetFiiData(ref suppressDefaultLog, apiResponseLocalVar, dataType, interval, from);
            if (!suppressDefaultLog)
                Logger.LogInformation("{0,-9} | {1} | {2}", (apiResponseLocalVar.DownloadedAt - apiResponseLocalVar.RequestedAt).TotalSeconds, apiResponseLocalVar.StatusCode, apiResponseLocalVar.Path);
        }

        partial void AfterGetFiiData(ref bool suppressDefaultLog, IGetFiiDataApiResponse apiResponseLocalVar, string? dataType, string? interval, Option<string?> from);

        private void OnErrorGetFiiDataDefaultImplementation(Exception exceptionLocalVar, string pathFormatLocalVar, string pathLocalVar, string? dataType, string? interval, Option<string?> from)
        {
            bool suppressDefaultLogLocalVar = false;
            OnErrorGetFiiData(ref suppressDefaultLogLocalVar, exceptionLocalVar, pathFormatLocalVar, pathLocalVar, dataType, interval, from);
            if (!suppressDefaultLogLocalVar)
                Logger.LogError(exceptionLocalVar, "An error occurred while sending the request to the server.");
        }

        partial void OnErrorGetFiiData(ref bool suppressDefaultLogLocalVar, Exception exceptionLocalVar, string pathFormatLocalVar, string pathLocalVar, string? dataType, string? interval, Option<string?> from);

        /// <summary>
        /// Get FII Data Fetches FII activity data for the given data type and interval.
        /// </summary>
        /// <param name="dataType">Data type. Allowed values: NSE_FO|INDEX_FUTURES, NSE_FO|STOCK_FUTURES, NSE_FO|INDEX_OPTIONS, NSE_FO|STOCK_OPTIONS, NSE_EQ|CASH</param>
        /// <param name="interval">Interval. Allowed values: 1D, 1M</param>
        /// <param name="from">Start date in YYYY-MM-DD format (optional) (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns><see cref="Task"/>&lt;<see cref="IGetFiiDataApiResponse"/>&gt;</returns>
        public async Task<IGetFiiDataApiResponse?> GetFiiDataOrDefaultAsync(string? dataType = default, string? interval = default, Option<string?> from = default, System.Threading.CancellationToken cancellationToken = default)
        {
            try
            {
                return await GetFiiDataAsync(dataType, interval, from, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Get FII Data Fetches FII activity data for the given data type and interval.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="dataType">Data type.</param>
        /// <param name="interval">Interval. Allowed values: 1D, 1M</param>
        /// <param name="from">Start date in YYYY-MM-DD format (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns><see cref="Task"/>&lt;<see cref="IGetFiiDataApiResponse"/>&gt;</returns>
        public async Task<IGetFiiDataApiResponse> GetFiiDataAsync(string? dataType = default, string? interval = default, Option<string?> from = default, System.Threading.CancellationToken cancellationToken = default)
        {
            UriBuilder uriBuilderLocalVar = new UriBuilder();

            try
            {
                FormatGetFiiData(ref dataType, ref interval, ref from);

                using (HttpRequestMessage httpRequestMessageLocalVar = new HttpRequestMessage())
                {
                    uriBuilderLocalVar.Host = HttpClient.BaseAddress!.Host;
                    uriBuilderLocalVar.Port = HttpClient.BaseAddress.Port;
                    uriBuilderLocalVar.Scheme = HttpClient.BaseAddress.Scheme;
                    uriBuilderLocalVar.Path = HttpClient.BaseAddress.AbsolutePath == "/"
                        ? "/v2/market/fii"
                        : string.Concat(HttpClient.BaseAddress.AbsolutePath.TrimEnd('/'), "/v2/market/fii");

                    System.Collections.Specialized.NameValueCollection parseQueryStringLocalVar = System.Web.HttpUtility.ParseQueryString(string.Empty);

                    parseQueryStringLocalVar["data_type"] = ClientUtils.ParameterToString(dataType);
                    parseQueryStringLocalVar["interval"] = ClientUtils.ParameterToString(interval);

                    if (from.IsSet)
                        parseQueryStringLocalVar["from"] = ClientUtils.ParameterToString(from.Value);

                    uriBuilderLocalVar.Query = parseQueryStringLocalVar.ToString();

                    List<TokenBase> tokenBaseLocalVars = new List<TokenBase>();
                    httpRequestMessageLocalVar.RequestUri = uriBuilderLocalVar.Uri;

                    OAuthToken oauthTokenLocalVar1 = (OAuthToken) await OauthTokenProvider.GetAsync(cancellation: cancellationToken).ConfigureAwait(false);

                    tokenBaseLocalVars.Add(oauthTokenLocalVar1);

                    oauthTokenLocalVar1.UseInHeader(httpRequestMessageLocalVar, "");

                    string[] acceptLocalVars = new string[] {
                        "*/*",
                        "application/json"
                    };

                    IEnumerable<MediaTypeWithQualityHeaderValue> acceptHeaderValuesLocalVar = ClientUtils.SelectHeaderAcceptArray(acceptLocalVars);

                    foreach (var acceptLocalVar in acceptHeaderValuesLocalVar)
                        httpRequestMessageLocalVar.Headers.Accept.Add(acceptLocalVar);

                    httpRequestMessageLocalVar.Method = HttpMethod.Get;

                    DateTime requestedAtLocalVar = DateTime.UtcNow;

                    using (HttpResponseMessage httpResponseMessageLocalVar = await HttpClient.SendAsync(httpRequestMessageLocalVar, cancellationToken).ConfigureAwait(false))
                    {
                        ILogger<GetFiiDataApiResponse> apiResponseLoggerLocalVar = LoggerFactory.CreateLogger<GetFiiDataApiResponse>();
                        GetFiiDataApiResponse apiResponseLocalVar;

                        switch ((int)httpResponseMessageLocalVar.StatusCode) {
                            default: {
                                string responseContentLocalVar = await httpResponseMessageLocalVar.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                                apiResponseLocalVar = new(apiResponseLoggerLocalVar, httpRequestMessageLocalVar, httpResponseMessageLocalVar, responseContentLocalVar, "/v2/market/fii", requestedAtLocalVar, _jsonSerializerOptions);

                                break;
                            }
                        }

                        AfterGetFiiDataDefaultImplementation(apiResponseLocalVar, dataType, interval, from);

                        if (apiResponseLocalVar.StatusCode == (HttpStatusCode) 429)
                            foreach(TokenBase tokenBaseLocalVar in tokenBaseLocalVars)
                                tokenBaseLocalVar.BeginRateLimit();

                        return apiResponseLocalVar;
                    }
                }
            }
            catch(Exception e)
            {
                OnErrorGetFiiDataDefaultImplementation(e, "/v2/market/fii", uriBuilderLocalVar.Path, dataType, interval, from);
                throw;
            }
        }

        /// <summary>
        /// The <see cref="GetFiiDataApiResponse"/>
        /// </summary>
        public partial class GetFiiDataApiResponse : UpstoxClient.Client.ApiResponse, IGetFiiDataApiResponse
        {
            /// <summary>The logger</summary>
            public ILogger<GetFiiDataApiResponse> Logger { get; }

            public GetFiiDataApiResponse(ILogger<GetFiiDataApiResponse> logger, System.Net.Http.HttpRequestMessage httpRequestMessage, System.Net.Http.HttpResponseMessage httpResponseMessage, string rawContent, string path, DateTime requestedAt, System.Text.Json.JsonSerializerOptions jsonSerializerOptions) : base(httpRequestMessage, httpResponseMessage, rawContent, path, requestedAt, jsonSerializerOptions)
            {
                Logger = logger;
                OnCreated(httpRequestMessage, httpResponseMessage);
            }

            public GetFiiDataApiResponse(ILogger<GetFiiDataApiResponse> logger, System.Net.Http.HttpRequestMessage httpRequestMessage, System.Net.Http.HttpResponseMessage httpResponseMessage, System.IO.Stream contentStream, string path, DateTime requestedAt, System.Text.Json.JsonSerializerOptions jsonSerializerOptions) : base(httpRequestMessage, httpResponseMessage, contentStream, path, requestedAt, jsonSerializerOptions)
            {
                Logger = logger;
                OnCreated(httpRequestMessage, httpResponseMessage);
            }

            partial void OnCreated(global::System.Net.Http.HttpRequestMessage httpRequestMessage, System.Net.Http.HttpResponseMessage httpResponseMessage);

            public bool IsMethodNotAllowed => 405 == (int)StatusCode;
            public UpstoxClient.Model.ApiGatewayErrorResponse? MethodNotAllowed() => IsMethodNotAllowed ? System.Text.Json.JsonSerializer.Deserialize<UpstoxClient.Model.ApiGatewayErrorResponse>(RawContent, _jsonSerializerOptions) : null;
            public bool TryMethodNotAllowed([NotNullWhen(true)]out UpstoxClient.Model.ApiGatewayErrorResponse? result) { result = null; try { result = MethodNotAllowed(); } catch (Exception e) { OnDeserializationErrorDefaultImplementation(e, (HttpStatusCode)405); } return result != null; }

            public bool IsBadRequest => 400 == (int)StatusCode;
            public UpstoxClient.Model.ApiGatewayErrorResponse? BadRequest() => IsBadRequest ? System.Text.Json.JsonSerializer.Deserialize<UpstoxClient.Model.ApiGatewayErrorResponse>(RawContent, _jsonSerializerOptions) : null;
            public bool TryBadRequest([NotNullWhen(true)]out UpstoxClient.Model.ApiGatewayErrorResponse? result) { result = null; try { result = BadRequest(); } catch (Exception e) { OnDeserializationErrorDefaultImplementation(e, (HttpStatusCode)400); } return result != null; }

            public bool IsInternalServerError => 500 == (int)StatusCode;
            public UpstoxClient.Model.ApiGatewayErrorResponse? InternalServerError() => IsInternalServerError ? System.Text.Json.JsonSerializer.Deserialize<UpstoxClient.Model.ApiGatewayErrorResponse>(RawContent, _jsonSerializerOptions) : null;
            public bool TryInternalServerError([NotNullWhen(true)]out UpstoxClient.Model.ApiGatewayErrorResponse? result) { result = null; try { result = InternalServerError(); } catch (Exception e) { OnDeserializationErrorDefaultImplementation(e, (HttpStatusCode)500); } return result != null; }

            public bool IsLocked => 423 == (int)StatusCode;
            public UpstoxClient.Model.ApiGatewayErrorResponse? Locked() => IsLocked ? System.Text.Json.JsonSerializer.Deserialize<UpstoxClient.Model.ApiGatewayErrorResponse>(RawContent, _jsonSerializerOptions) : null;
            public bool TryLocked([NotNullWhen(true)]out UpstoxClient.Model.ApiGatewayErrorResponse? result) { result = null; try { result = Locked(); } catch (Exception e) { OnDeserializationErrorDefaultImplementation(e, (HttpStatusCode)423); } return result != null; }

            public bool IsUnprocessableContent => 422 == (int)StatusCode;
            public UpstoxClient.Model.ApiGatewayErrorResponse? UnprocessableContent() => IsUnprocessableContent ? System.Text.Json.JsonSerializer.Deserialize<UpstoxClient.Model.ApiGatewayErrorResponse>(RawContent, _jsonSerializerOptions) : null;
            public bool TryUnprocessableContent([NotNullWhen(true)]out UpstoxClient.Model.ApiGatewayErrorResponse? result) { result = null; try { result = UnprocessableContent(); } catch (Exception e) { OnDeserializationErrorDefaultImplementation(e, (HttpStatusCode)422); } return result != null; }

            public bool IsTooManyRequests => 429 == (int)StatusCode;
            public UpstoxClient.Model.ApiGatewayErrorResponse? TooManyRequests() => IsTooManyRequests ? System.Text.Json.JsonSerializer.Deserialize<UpstoxClient.Model.ApiGatewayErrorResponse>(RawContent, _jsonSerializerOptions) : null;
            public bool TryTooManyRequests([NotNullWhen(true)]out UpstoxClient.Model.ApiGatewayErrorResponse? result) { result = null; try { result = TooManyRequests(); } catch (Exception e) { OnDeserializationErrorDefaultImplementation(e, (HttpStatusCode)429); } return result != null; }

            public bool IsOk => 200 == (int)StatusCode;
            public UpstoxClient.Model.AnalyticsResponse? Ok() => IsOk ? System.Text.Json.JsonSerializer.Deserialize<UpstoxClient.Model.AnalyticsResponse>(RawContent, _jsonSerializerOptions) : null;
            public bool TryOk([NotNullWhen(true)]out UpstoxClient.Model.AnalyticsResponse? result) { result = null; try { result = Ok(); } catch (Exception e) { OnDeserializationErrorDefaultImplementation(e, (HttpStatusCode)200); } return result != null; }

            public bool IsUnauthorized => 401 == (int)StatusCode;
            public UpstoxClient.Model.ApiGatewayErrorResponse? Unauthorized() => IsUnauthorized ? System.Text.Json.JsonSerializer.Deserialize<UpstoxClient.Model.ApiGatewayErrorResponse>(RawContent, _jsonSerializerOptions) : null;
            public bool TryUnauthorized([NotNullWhen(true)]out UpstoxClient.Model.ApiGatewayErrorResponse? result) { result = null; try { result = Unauthorized(); } catch (Exception e) { OnDeserializationErrorDefaultImplementation(e, (HttpStatusCode)401); } return result != null; }

            private void OnDeserializationErrorDefaultImplementation(Exception exception, HttpStatusCode httpStatusCode)
            {
                bool suppressDefaultLog = false;
                OnDeserializationError(ref suppressDefaultLog, exception, httpStatusCode);
                if (!suppressDefaultLog)
                    Logger.LogError(exception, "An error occurred while deserializing the {code} response.", httpStatusCode);
            }

            partial void OnDeserializationError(ref bool suppressDefaultLog, Exception exception, HttpStatusCode httpStatusCode);
        }

        // ── GetMaxPainData ────────────────────────────────────────────────────

        partial void FormatGetMaxPainData(ref string? instrumentKey, ref string? expiry, ref string? date, ref int? bucketInterval);

        private void AfterGetMaxPainDataDefaultImplementation(IGetMaxPainDataApiResponse apiResponseLocalVar, string? instrumentKey, string? expiry, string? date, int? bucketInterval)
        {
            bool suppressDefaultLog = false;
            AfterGetMaxPainData(ref suppressDefaultLog, apiResponseLocalVar, instrumentKey, expiry, date, bucketInterval);
            if (!suppressDefaultLog)
                Logger.LogInformation("{0,-9} | {1} | {2}", (apiResponseLocalVar.DownloadedAt - apiResponseLocalVar.RequestedAt).TotalSeconds, apiResponseLocalVar.StatusCode, apiResponseLocalVar.Path);
        }

        partial void AfterGetMaxPainData(ref bool suppressDefaultLog, IGetMaxPainDataApiResponse apiResponseLocalVar, string? instrumentKey, string? expiry, string? date, int? bucketInterval);

        private void OnErrorGetMaxPainDataDefaultImplementation(Exception exceptionLocalVar, string pathFormatLocalVar, string pathLocalVar, string? instrumentKey, string? expiry, string? date, int? bucketInterval)
        {
            bool suppressDefaultLogLocalVar = false;
            OnErrorGetMaxPainData(ref suppressDefaultLogLocalVar, exceptionLocalVar, pathFormatLocalVar, pathLocalVar, instrumentKey, expiry, date, bucketInterval);
            if (!suppressDefaultLogLocalVar)
                Logger.LogError(exceptionLocalVar, "An error occurred while sending the request to the server.");
        }

        partial void OnErrorGetMaxPainData(ref bool suppressDefaultLogLocalVar, Exception exceptionLocalVar, string pathFormatLocalVar, string pathLocalVar, string? instrumentKey, string? expiry, string? date, int? bucketInterval);

        /// <summary>
        /// Get Max Pain Data Fetches Max Pain data for the given instrument key, expiry, date and bucket interval.
        /// </summary>
        /// <param name="instrumentKey">Underlying asset instrument key</param>
        /// <param name="expiry">Expiry date in YYYY-MM-DD format</param>
        /// <param name="date">Date in YYYY-MM-DD format for which Max Pain data is required</param>
        /// <param name="bucketInterval">Bucket interval in minutes for the insights list</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns><see cref="Task"/>&lt;<see cref="IGetMaxPainDataApiResponse"/>&gt;</returns>
        public async Task<IGetMaxPainDataApiResponse?> GetMaxPainDataOrDefaultAsync(string? instrumentKey = default, string? expiry = default, string? date = default, int? bucketInterval = default, System.Threading.CancellationToken cancellationToken = default)
        {
            try
            {
                return await GetMaxPainDataAsync(instrumentKey, expiry, date, bucketInterval, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Get Max Pain Data Fetches Max Pain data for the given instrument key, expiry, date and bucket interval.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="instrumentKey">Underlying asset instrument key</param>
        /// <param name="expiry">Expiry date in YYYY-MM-DD format</param>
        /// <param name="date">Date in YYYY-MM-DD format for which Max Pain data is required</param>
        /// <param name="bucketInterval">Bucket interval in minutes for the insights list</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns><see cref="Task"/>&lt;<see cref="IGetMaxPainDataApiResponse"/>&gt;</returns>
        public async Task<IGetMaxPainDataApiResponse> GetMaxPainDataAsync(string? instrumentKey = default, string? expiry = default, string? date = default, int? bucketInterval = default, System.Threading.CancellationToken cancellationToken = default)
        {
            UriBuilder uriBuilderLocalVar = new UriBuilder();

            try
            {
                FormatGetMaxPainData(ref instrumentKey, ref expiry, ref date, ref bucketInterval);

                using (HttpRequestMessage httpRequestMessageLocalVar = new HttpRequestMessage())
                {
                    uriBuilderLocalVar.Host = HttpClient.BaseAddress!.Host;
                    uriBuilderLocalVar.Port = HttpClient.BaseAddress.Port;
                    uriBuilderLocalVar.Scheme = HttpClient.BaseAddress.Scheme;
                    uriBuilderLocalVar.Path = HttpClient.BaseAddress.AbsolutePath == "/"
                        ? "/v2/market/max-pain"
                        : string.Concat(HttpClient.BaseAddress.AbsolutePath.TrimEnd('/'), "/v2/market/max-pain");

                    System.Collections.Specialized.NameValueCollection parseQueryStringLocalVar = System.Web.HttpUtility.ParseQueryString(string.Empty);

                    parseQueryStringLocalVar["instrument_key"] = ClientUtils.ParameterToString(instrumentKey);
                    parseQueryStringLocalVar["expiry"] = ClientUtils.ParameterToString(expiry);
                    parseQueryStringLocalVar["date"] = ClientUtils.ParameterToString(date);
                    parseQueryStringLocalVar["bucket_interval"] = ClientUtils.ParameterToString(bucketInterval);

                    uriBuilderLocalVar.Query = parseQueryStringLocalVar.ToString();

                    List<TokenBase> tokenBaseLocalVars = new List<TokenBase>();
                    httpRequestMessageLocalVar.RequestUri = uriBuilderLocalVar.Uri;

                    OAuthToken oauthTokenLocalVar1 = (OAuthToken) await OauthTokenProvider.GetAsync(cancellation: cancellationToken).ConfigureAwait(false);

                    tokenBaseLocalVars.Add(oauthTokenLocalVar1);

                    oauthTokenLocalVar1.UseInHeader(httpRequestMessageLocalVar, "");

                    string[] acceptLocalVars = new string[] {
                        "*/*",
                        "application/json"
                    };

                    IEnumerable<MediaTypeWithQualityHeaderValue> acceptHeaderValuesLocalVar = ClientUtils.SelectHeaderAcceptArray(acceptLocalVars);

                    foreach (var acceptLocalVar in acceptHeaderValuesLocalVar)
                        httpRequestMessageLocalVar.Headers.Accept.Add(acceptLocalVar);

                    httpRequestMessageLocalVar.Method = HttpMethod.Get;

                    DateTime requestedAtLocalVar = DateTime.UtcNow;

                    using (HttpResponseMessage httpResponseMessageLocalVar = await HttpClient.SendAsync(httpRequestMessageLocalVar, cancellationToken).ConfigureAwait(false))
                    {
                        ILogger<GetMaxPainDataApiResponse> apiResponseLoggerLocalVar = LoggerFactory.CreateLogger<GetMaxPainDataApiResponse>();
                        GetMaxPainDataApiResponse apiResponseLocalVar;

                        switch ((int)httpResponseMessageLocalVar.StatusCode) {
                            default: {
                                string responseContentLocalVar = await httpResponseMessageLocalVar.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                                apiResponseLocalVar = new(apiResponseLoggerLocalVar, httpRequestMessageLocalVar, httpResponseMessageLocalVar, responseContentLocalVar, "/v2/market/max-pain", requestedAtLocalVar, _jsonSerializerOptions);

                                break;
                            }
                        }

                        AfterGetMaxPainDataDefaultImplementation(apiResponseLocalVar, instrumentKey, expiry, date, bucketInterval);

                        if (apiResponseLocalVar.StatusCode == (HttpStatusCode) 429)
                            foreach(TokenBase tokenBaseLocalVar in tokenBaseLocalVars)
                                tokenBaseLocalVar.BeginRateLimit();

                        return apiResponseLocalVar;
                    }
                }
            }
            catch(Exception e)
            {
                OnErrorGetMaxPainDataDefaultImplementation(e, "/v2/market/max-pain", uriBuilderLocalVar.Path, instrumentKey, expiry, date, bucketInterval);
                throw;
            }
        }

        /// <summary>
        /// The <see cref="GetMaxPainDataApiResponse"/>
        /// </summary>
        public partial class GetMaxPainDataApiResponse : UpstoxClient.Client.ApiResponse, IGetMaxPainDataApiResponse
        {
            /// <summary>The logger</summary>
            public ILogger<GetMaxPainDataApiResponse> Logger { get; }

            public GetMaxPainDataApiResponse(ILogger<GetMaxPainDataApiResponse> logger, System.Net.Http.HttpRequestMessage httpRequestMessage, System.Net.Http.HttpResponseMessage httpResponseMessage, string rawContent, string path, DateTime requestedAt, System.Text.Json.JsonSerializerOptions jsonSerializerOptions) : base(httpRequestMessage, httpResponseMessage, rawContent, path, requestedAt, jsonSerializerOptions)
            {
                Logger = logger;
                OnCreated(httpRequestMessage, httpResponseMessage);
            }

            public GetMaxPainDataApiResponse(ILogger<GetMaxPainDataApiResponse> logger, System.Net.Http.HttpRequestMessage httpRequestMessage, System.Net.Http.HttpResponseMessage httpResponseMessage, System.IO.Stream contentStream, string path, DateTime requestedAt, System.Text.Json.JsonSerializerOptions jsonSerializerOptions) : base(httpRequestMessage, httpResponseMessage, contentStream, path, requestedAt, jsonSerializerOptions)
            {
                Logger = logger;
                OnCreated(httpRequestMessage, httpResponseMessage);
            }

            partial void OnCreated(global::System.Net.Http.HttpRequestMessage httpRequestMessage, System.Net.Http.HttpResponseMessage httpResponseMessage);

            public bool IsMethodNotAllowed => 405 == (int)StatusCode;
            public UpstoxClient.Model.ApiGatewayErrorResponse? MethodNotAllowed() => IsMethodNotAllowed ? System.Text.Json.JsonSerializer.Deserialize<UpstoxClient.Model.ApiGatewayErrorResponse>(RawContent, _jsonSerializerOptions) : null;
            public bool TryMethodNotAllowed([NotNullWhen(true)]out UpstoxClient.Model.ApiGatewayErrorResponse? result) { result = null; try { result = MethodNotAllowed(); } catch (Exception e) { OnDeserializationErrorDefaultImplementation(e, (HttpStatusCode)405); } return result != null; }

            public bool IsBadRequest => 400 == (int)StatusCode;
            public UpstoxClient.Model.ApiGatewayErrorResponse? BadRequest() => IsBadRequest ? System.Text.Json.JsonSerializer.Deserialize<UpstoxClient.Model.ApiGatewayErrorResponse>(RawContent, _jsonSerializerOptions) : null;
            public bool TryBadRequest([NotNullWhen(true)]out UpstoxClient.Model.ApiGatewayErrorResponse? result) { result = null; try { result = BadRequest(); } catch (Exception e) { OnDeserializationErrorDefaultImplementation(e, (HttpStatusCode)400); } return result != null; }

            public bool IsInternalServerError => 500 == (int)StatusCode;
            public UpstoxClient.Model.ApiGatewayErrorResponse? InternalServerError() => IsInternalServerError ? System.Text.Json.JsonSerializer.Deserialize<UpstoxClient.Model.ApiGatewayErrorResponse>(RawContent, _jsonSerializerOptions) : null;
            public bool TryInternalServerError([NotNullWhen(true)]out UpstoxClient.Model.ApiGatewayErrorResponse? result) { result = null; try { result = InternalServerError(); } catch (Exception e) { OnDeserializationErrorDefaultImplementation(e, (HttpStatusCode)500); } return result != null; }

            public bool IsLocked => 423 == (int)StatusCode;
            public UpstoxClient.Model.ApiGatewayErrorResponse? Locked() => IsLocked ? System.Text.Json.JsonSerializer.Deserialize<UpstoxClient.Model.ApiGatewayErrorResponse>(RawContent, _jsonSerializerOptions) : null;
            public bool TryLocked([NotNullWhen(true)]out UpstoxClient.Model.ApiGatewayErrorResponse? result) { result = null; try { result = Locked(); } catch (Exception e) { OnDeserializationErrorDefaultImplementation(e, (HttpStatusCode)423); } return result != null; }

            public bool IsUnprocessableContent => 422 == (int)StatusCode;
            public UpstoxClient.Model.ApiGatewayErrorResponse? UnprocessableContent() => IsUnprocessableContent ? System.Text.Json.JsonSerializer.Deserialize<UpstoxClient.Model.ApiGatewayErrorResponse>(RawContent, _jsonSerializerOptions) : null;
            public bool TryUnprocessableContent([NotNullWhen(true)]out UpstoxClient.Model.ApiGatewayErrorResponse? result) { result = null; try { result = UnprocessableContent(); } catch (Exception e) { OnDeserializationErrorDefaultImplementation(e, (HttpStatusCode)422); } return result != null; }

            public bool IsTooManyRequests => 429 == (int)StatusCode;
            public UpstoxClient.Model.ApiGatewayErrorResponse? TooManyRequests() => IsTooManyRequests ? System.Text.Json.JsonSerializer.Deserialize<UpstoxClient.Model.ApiGatewayErrorResponse>(RawContent, _jsonSerializerOptions) : null;
            public bool TryTooManyRequests([NotNullWhen(true)]out UpstoxClient.Model.ApiGatewayErrorResponse? result) { result = null; try { result = TooManyRequests(); } catch (Exception e) { OnDeserializationErrorDefaultImplementation(e, (HttpStatusCode)429); } return result != null; }

            public bool IsOk => 200 == (int)StatusCode;
            public UpstoxClient.Model.AnalyticsResponse? Ok() => IsOk ? System.Text.Json.JsonSerializer.Deserialize<UpstoxClient.Model.AnalyticsResponse>(RawContent, _jsonSerializerOptions) : null;
            public bool TryOk([NotNullWhen(true)]out UpstoxClient.Model.AnalyticsResponse? result) { result = null; try { result = Ok(); } catch (Exception e) { OnDeserializationErrorDefaultImplementation(e, (HttpStatusCode)200); } return result != null; }

            public bool IsUnauthorized => 401 == (int)StatusCode;
            public UpstoxClient.Model.ApiGatewayErrorResponse? Unauthorized() => IsUnauthorized ? System.Text.Json.JsonSerializer.Deserialize<UpstoxClient.Model.ApiGatewayErrorResponse>(RawContent, _jsonSerializerOptions) : null;
            public bool TryUnauthorized([NotNullWhen(true)]out UpstoxClient.Model.ApiGatewayErrorResponse? result) { result = null; try { result = Unauthorized(); } catch (Exception e) { OnDeserializationErrorDefaultImplementation(e, (HttpStatusCode)401); } return result != null; }

            private void OnDeserializationErrorDefaultImplementation(Exception exception, HttpStatusCode httpStatusCode)
            {
                bool suppressDefaultLog = false;
                OnDeserializationError(ref suppressDefaultLog, exception, httpStatusCode);
                if (!suppressDefaultLog)
                    Logger.LogError(exception, "An error occurred while deserializing the {code} response.", httpStatusCode);
            }

            partial void OnDeserializationError(ref bool suppressDefaultLog, Exception exception, HttpStatusCode httpStatusCode);
        }

        // ── GetOiData ─────────────────────────────────────────────────────────

        partial void FormatGetOiData(ref string? instrumentKey, ref string? expiry, ref string? date);

        private void AfterGetOiDataDefaultImplementation(IGetOiDataApiResponse apiResponseLocalVar, string? instrumentKey, string? expiry, string? date)
        {
            bool suppressDefaultLog = false;
            AfterGetOiData(ref suppressDefaultLog, apiResponseLocalVar, instrumentKey, expiry, date);
            if (!suppressDefaultLog)
                Logger.LogInformation("{0,-9} | {1} | {2}", (apiResponseLocalVar.DownloadedAt - apiResponseLocalVar.RequestedAt).TotalSeconds, apiResponseLocalVar.StatusCode, apiResponseLocalVar.Path);
        }

        partial void AfterGetOiData(ref bool suppressDefaultLog, IGetOiDataApiResponse apiResponseLocalVar, string? instrumentKey, string? expiry, string? date);

        private void OnErrorGetOiDataDefaultImplementation(Exception exceptionLocalVar, string pathFormatLocalVar, string pathLocalVar, string? instrumentKey, string? expiry, string? date)
        {
            bool suppressDefaultLogLocalVar = false;
            OnErrorGetOiData(ref suppressDefaultLogLocalVar, exceptionLocalVar, pathFormatLocalVar, pathLocalVar, instrumentKey, expiry, date);
            if (!suppressDefaultLogLocalVar)
                Logger.LogError(exceptionLocalVar, "An error occurred while sending the request to the server.");
        }

        partial void OnErrorGetOiData(ref bool suppressDefaultLogLocalVar, Exception exceptionLocalVar, string pathFormatLocalVar, string pathLocalVar, string? instrumentKey, string? expiry, string? date);

        /// <summary>
        /// Get OI Data Fetches OI data for the given instrument key, expiry and date.
        /// </summary>
        /// <param name="instrumentKey">Underlying asset instrument key</param>
        /// <param name="expiry">Expiry date in YYYY-MM-DD format</param>
        /// <param name="date">Date in YYYY-MM-DD format for which OI data is required</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns><see cref="Task"/>&lt;<see cref="IGetOiDataApiResponse"/>&gt;</returns>
        public async Task<IGetOiDataApiResponse?> GetOiDataOrDefaultAsync(string? instrumentKey = default, string? expiry = default, string? date = default, System.Threading.CancellationToken cancellationToken = default)
        {
            try
            {
                return await GetOiDataAsync(instrumentKey, expiry, date, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Get OI Data Fetches OI data for the given instrument key, expiry and date.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="instrumentKey">Underlying asset instrument key</param>
        /// <param name="expiry">Expiry date in YYYY-MM-DD format</param>
        /// <param name="date">Date in YYYY-MM-DD format for which OI data is required</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns><see cref="Task"/>&lt;<see cref="IGetOiDataApiResponse"/>&gt;</returns>
        public async Task<IGetOiDataApiResponse> GetOiDataAsync(string? instrumentKey = default, string? expiry = default, string? date = default, System.Threading.CancellationToken cancellationToken = default)
        {
            UriBuilder uriBuilderLocalVar = new UriBuilder();

            try
            {
                FormatGetOiData(ref instrumentKey, ref expiry, ref date);

                using (HttpRequestMessage httpRequestMessageLocalVar = new HttpRequestMessage())
                {
                    uriBuilderLocalVar.Host = HttpClient.BaseAddress!.Host;
                    uriBuilderLocalVar.Port = HttpClient.BaseAddress.Port;
                    uriBuilderLocalVar.Scheme = HttpClient.BaseAddress.Scheme;
                    uriBuilderLocalVar.Path = HttpClient.BaseAddress.AbsolutePath == "/"
                        ? "/v2/market/oi"
                        : string.Concat(HttpClient.BaseAddress.AbsolutePath.TrimEnd('/'), "/v2/market/oi");

                    System.Collections.Specialized.NameValueCollection parseQueryStringLocalVar = System.Web.HttpUtility.ParseQueryString(string.Empty);

                    parseQueryStringLocalVar["instrument_key"] = ClientUtils.ParameterToString(instrumentKey);
                    parseQueryStringLocalVar["expiry"] = ClientUtils.ParameterToString(expiry);
                    parseQueryStringLocalVar["date"] = ClientUtils.ParameterToString(date);

                    uriBuilderLocalVar.Query = parseQueryStringLocalVar.ToString();

                    List<TokenBase> tokenBaseLocalVars = new List<TokenBase>();
                    httpRequestMessageLocalVar.RequestUri = uriBuilderLocalVar.Uri;

                    OAuthToken oauthTokenLocalVar1 = (OAuthToken) await OauthTokenProvider.GetAsync(cancellation: cancellationToken).ConfigureAwait(false);

                    tokenBaseLocalVars.Add(oauthTokenLocalVar1);

                    oauthTokenLocalVar1.UseInHeader(httpRequestMessageLocalVar, "");

                    string[] acceptLocalVars = new string[] {
                        "*/*",
                        "application/json"
                    };

                    IEnumerable<MediaTypeWithQualityHeaderValue> acceptHeaderValuesLocalVar = ClientUtils.SelectHeaderAcceptArray(acceptLocalVars);

                    foreach (var acceptLocalVar in acceptHeaderValuesLocalVar)
                        httpRequestMessageLocalVar.Headers.Accept.Add(acceptLocalVar);

                    httpRequestMessageLocalVar.Method = HttpMethod.Get;

                    DateTime requestedAtLocalVar = DateTime.UtcNow;

                    using (HttpResponseMessage httpResponseMessageLocalVar = await HttpClient.SendAsync(httpRequestMessageLocalVar, cancellationToken).ConfigureAwait(false))
                    {
                        ILogger<GetOiDataApiResponse> apiResponseLoggerLocalVar = LoggerFactory.CreateLogger<GetOiDataApiResponse>();
                        GetOiDataApiResponse apiResponseLocalVar;

                        switch ((int)httpResponseMessageLocalVar.StatusCode) {
                            default: {
                                string responseContentLocalVar = await httpResponseMessageLocalVar.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                                apiResponseLocalVar = new(apiResponseLoggerLocalVar, httpRequestMessageLocalVar, httpResponseMessageLocalVar, responseContentLocalVar, "/v2/market/oi", requestedAtLocalVar, _jsonSerializerOptions);

                                break;
                            }
                        }

                        AfterGetOiDataDefaultImplementation(apiResponseLocalVar, instrumentKey, expiry, date);

                        if (apiResponseLocalVar.StatusCode == (HttpStatusCode) 429)
                            foreach(TokenBase tokenBaseLocalVar in tokenBaseLocalVars)
                                tokenBaseLocalVar.BeginRateLimit();

                        return apiResponseLocalVar;
                    }
                }
            }
            catch(Exception e)
            {
                OnErrorGetOiDataDefaultImplementation(e, "/v2/market/oi", uriBuilderLocalVar.Path, instrumentKey, expiry, date);
                throw;
            }
        }

        /// <summary>
        /// The <see cref="GetOiDataApiResponse"/>
        /// </summary>
        public partial class GetOiDataApiResponse : UpstoxClient.Client.ApiResponse, IGetOiDataApiResponse
        {
            /// <summary>The logger</summary>
            public ILogger<GetOiDataApiResponse> Logger { get; }

            public GetOiDataApiResponse(ILogger<GetOiDataApiResponse> logger, System.Net.Http.HttpRequestMessage httpRequestMessage, System.Net.Http.HttpResponseMessage httpResponseMessage, string rawContent, string path, DateTime requestedAt, System.Text.Json.JsonSerializerOptions jsonSerializerOptions) : base(httpRequestMessage, httpResponseMessage, rawContent, path, requestedAt, jsonSerializerOptions)
            {
                Logger = logger;
                OnCreated(httpRequestMessage, httpResponseMessage);
            }

            public GetOiDataApiResponse(ILogger<GetOiDataApiResponse> logger, System.Net.Http.HttpRequestMessage httpRequestMessage, System.Net.Http.HttpResponseMessage httpResponseMessage, System.IO.Stream contentStream, string path, DateTime requestedAt, System.Text.Json.JsonSerializerOptions jsonSerializerOptions) : base(httpRequestMessage, httpResponseMessage, contentStream, path, requestedAt, jsonSerializerOptions)
            {
                Logger = logger;
                OnCreated(httpRequestMessage, httpResponseMessage);
            }

            partial void OnCreated(global::System.Net.Http.HttpRequestMessage httpRequestMessage, System.Net.Http.HttpResponseMessage httpResponseMessage);

            public bool IsMethodNotAllowed => 405 == (int)StatusCode;
            public UpstoxClient.Model.ApiGatewayErrorResponse? MethodNotAllowed() => IsMethodNotAllowed ? System.Text.Json.JsonSerializer.Deserialize<UpstoxClient.Model.ApiGatewayErrorResponse>(RawContent, _jsonSerializerOptions) : null;
            public bool TryMethodNotAllowed([NotNullWhen(true)]out UpstoxClient.Model.ApiGatewayErrorResponse? result) { result = null; try { result = MethodNotAllowed(); } catch (Exception e) { OnDeserializationErrorDefaultImplementation(e, (HttpStatusCode)405); } return result != null; }

            public bool IsBadRequest => 400 == (int)StatusCode;
            public UpstoxClient.Model.ApiGatewayErrorResponse? BadRequest() => IsBadRequest ? System.Text.Json.JsonSerializer.Deserialize<UpstoxClient.Model.ApiGatewayErrorResponse>(RawContent, _jsonSerializerOptions) : null;
            public bool TryBadRequest([NotNullWhen(true)]out UpstoxClient.Model.ApiGatewayErrorResponse? result) { result = null; try { result = BadRequest(); } catch (Exception e) { OnDeserializationErrorDefaultImplementation(e, (HttpStatusCode)400); } return result != null; }

            public bool IsInternalServerError => 500 == (int)StatusCode;
            public UpstoxClient.Model.ApiGatewayErrorResponse? InternalServerError() => IsInternalServerError ? System.Text.Json.JsonSerializer.Deserialize<UpstoxClient.Model.ApiGatewayErrorResponse>(RawContent, _jsonSerializerOptions) : null;
            public bool TryInternalServerError([NotNullWhen(true)]out UpstoxClient.Model.ApiGatewayErrorResponse? result) { result = null; try { result = InternalServerError(); } catch (Exception e) { OnDeserializationErrorDefaultImplementation(e, (HttpStatusCode)500); } return result != null; }

            public bool IsLocked => 423 == (int)StatusCode;
            public UpstoxClient.Model.ApiGatewayErrorResponse? Locked() => IsLocked ? System.Text.Json.JsonSerializer.Deserialize<UpstoxClient.Model.ApiGatewayErrorResponse>(RawContent, _jsonSerializerOptions) : null;
            public bool TryLocked([NotNullWhen(true)]out UpstoxClient.Model.ApiGatewayErrorResponse? result) { result = null; try { result = Locked(); } catch (Exception e) { OnDeserializationErrorDefaultImplementation(e, (HttpStatusCode)423); } return result != null; }

            public bool IsUnprocessableContent => 422 == (int)StatusCode;
            public UpstoxClient.Model.ApiGatewayErrorResponse? UnprocessableContent() => IsUnprocessableContent ? System.Text.Json.JsonSerializer.Deserialize<UpstoxClient.Model.ApiGatewayErrorResponse>(RawContent, _jsonSerializerOptions) : null;
            public bool TryUnprocessableContent([NotNullWhen(true)]out UpstoxClient.Model.ApiGatewayErrorResponse? result) { result = null; try { result = UnprocessableContent(); } catch (Exception e) { OnDeserializationErrorDefaultImplementation(e, (HttpStatusCode)422); } return result != null; }

            public bool IsTooManyRequests => 429 == (int)StatusCode;
            public UpstoxClient.Model.ApiGatewayErrorResponse? TooManyRequests() => IsTooManyRequests ? System.Text.Json.JsonSerializer.Deserialize<UpstoxClient.Model.ApiGatewayErrorResponse>(RawContent, _jsonSerializerOptions) : null;
            public bool TryTooManyRequests([NotNullWhen(true)]out UpstoxClient.Model.ApiGatewayErrorResponse? result) { result = null; try { result = TooManyRequests(); } catch (Exception e) { OnDeserializationErrorDefaultImplementation(e, (HttpStatusCode)429); } return result != null; }

            public bool IsOk => 200 == (int)StatusCode;
            public UpstoxClient.Model.AnalyticsResponse? Ok() => IsOk ? System.Text.Json.JsonSerializer.Deserialize<UpstoxClient.Model.AnalyticsResponse>(RawContent, _jsonSerializerOptions) : null;
            public bool TryOk([NotNullWhen(true)]out UpstoxClient.Model.AnalyticsResponse? result) { result = null; try { result = Ok(); } catch (Exception e) { OnDeserializationErrorDefaultImplementation(e, (HttpStatusCode)200); } return result != null; }

            public bool IsUnauthorized => 401 == (int)StatusCode;
            public UpstoxClient.Model.ApiGatewayErrorResponse? Unauthorized() => IsUnauthorized ? System.Text.Json.JsonSerializer.Deserialize<UpstoxClient.Model.ApiGatewayErrorResponse>(RawContent, _jsonSerializerOptions) : null;
            public bool TryUnauthorized([NotNullWhen(true)]out UpstoxClient.Model.ApiGatewayErrorResponse? result) { result = null; try { result = Unauthorized(); } catch (Exception e) { OnDeserializationErrorDefaultImplementation(e, (HttpStatusCode)401); } return result != null; }

            private void OnDeserializationErrorDefaultImplementation(Exception exception, HttpStatusCode httpStatusCode)
            {
                bool suppressDefaultLog = false;
                OnDeserializationError(ref suppressDefaultLog, exception, httpStatusCode);
                if (!suppressDefaultLog)
                    Logger.LogError(exception, "An error occurred while deserializing the {code} response.", httpStatusCode);
            }

            partial void OnDeserializationError(ref bool suppressDefaultLog, Exception exception, HttpStatusCode httpStatusCode);
        }

        // ── GetPcrData ────────────────────────────────────────────────────────

        partial void FormatGetPcrData(ref string? instrumentKey, ref string? expiry, ref string? date, ref int? bucketInterval);

        private void AfterGetPcrDataDefaultImplementation(IGetPcrDataApiResponse apiResponseLocalVar, string? instrumentKey, string? expiry, string? date, int? bucketInterval)
        {
            bool suppressDefaultLog = false;
            AfterGetPcrData(ref suppressDefaultLog, apiResponseLocalVar, instrumentKey, expiry, date, bucketInterval);
            if (!suppressDefaultLog)
                Logger.LogInformation("{0,-9} | {1} | {2}", (apiResponseLocalVar.DownloadedAt - apiResponseLocalVar.RequestedAt).TotalSeconds, apiResponseLocalVar.StatusCode, apiResponseLocalVar.Path);
        }

        partial void AfterGetPcrData(ref bool suppressDefaultLog, IGetPcrDataApiResponse apiResponseLocalVar, string? instrumentKey, string? expiry, string? date, int? bucketInterval);

        private void OnErrorGetPcrDataDefaultImplementation(Exception exceptionLocalVar, string pathFormatLocalVar, string pathLocalVar, string? instrumentKey, string? expiry, string? date, int? bucketInterval)
        {
            bool suppressDefaultLogLocalVar = false;
            OnErrorGetPcrData(ref suppressDefaultLogLocalVar, exceptionLocalVar, pathFormatLocalVar, pathLocalVar, instrumentKey, expiry, date, bucketInterval);
            if (!suppressDefaultLogLocalVar)
                Logger.LogError(exceptionLocalVar, "An error occurred while sending the request to the server.");
        }

        partial void OnErrorGetPcrData(ref bool suppressDefaultLogLocalVar, Exception exceptionLocalVar, string pathFormatLocalVar, string pathLocalVar, string? instrumentKey, string? expiry, string? date, int? bucketInterval);

        /// <summary>
        /// Get PCR Data Fetches PCR (Put-Call Ratio) data for the given instrument key, expiry, date and bucket interval.
        /// </summary>
        /// <param name="instrumentKey">Underlying asset instrument key</param>
        /// <param name="expiry">Expiry date in YYYY-MM-DD format</param>
        /// <param name="date">Date in YYYY-MM-DD format for which PCR data is required</param>
        /// <param name="bucketInterval">Bucket interval in minutes for the insights list</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns><see cref="Task"/>&lt;<see cref="IGetPcrDataApiResponse"/>&gt;</returns>
        public async Task<IGetPcrDataApiResponse?> GetPcrDataOrDefaultAsync(string? instrumentKey = default, string? expiry = default, string? date = default, int? bucketInterval = default, System.Threading.CancellationToken cancellationToken = default)
        {
            try
            {
                return await GetPcrDataAsync(instrumentKey, expiry, date, bucketInterval, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Get PCR Data Fetches PCR (Put-Call Ratio) data for the given instrument key, expiry, date and bucket interval.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="instrumentKey">Underlying asset instrument key</param>
        /// <param name="expiry">Expiry date in YYYY-MM-DD format</param>
        /// <param name="date">Date in YYYY-MM-DD format for which PCR data is required</param>
        /// <param name="bucketInterval">Bucket interval in minutes for the insights list</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns><see cref="Task"/>&lt;<see cref="IGetPcrDataApiResponse"/>&gt;</returns>
        public async Task<IGetPcrDataApiResponse> GetPcrDataAsync(string? instrumentKey = default, string? expiry = default, string? date = default, int? bucketInterval = default, System.Threading.CancellationToken cancellationToken = default)
        {
            UriBuilder uriBuilderLocalVar = new UriBuilder();

            try
            {
                FormatGetPcrData(ref instrumentKey, ref expiry, ref date, ref bucketInterval);

                using (HttpRequestMessage httpRequestMessageLocalVar = new HttpRequestMessage())
                {
                    uriBuilderLocalVar.Host = HttpClient.BaseAddress!.Host;
                    uriBuilderLocalVar.Port = HttpClient.BaseAddress.Port;
                    uriBuilderLocalVar.Scheme = HttpClient.BaseAddress.Scheme;
                    uriBuilderLocalVar.Path = HttpClient.BaseAddress.AbsolutePath == "/"
                        ? "/v2/market/pcr"
                        : string.Concat(HttpClient.BaseAddress.AbsolutePath.TrimEnd('/'), "/v2/market/pcr");

                    System.Collections.Specialized.NameValueCollection parseQueryStringLocalVar = System.Web.HttpUtility.ParseQueryString(string.Empty);

                    parseQueryStringLocalVar["instrument_key"] = ClientUtils.ParameterToString(instrumentKey);
                    parseQueryStringLocalVar["expiry"] = ClientUtils.ParameterToString(expiry);
                    parseQueryStringLocalVar["date"] = ClientUtils.ParameterToString(date);
                    parseQueryStringLocalVar["bucket_interval"] = ClientUtils.ParameterToString(bucketInterval);

                    uriBuilderLocalVar.Query = parseQueryStringLocalVar.ToString();

                    List<TokenBase> tokenBaseLocalVars = new List<TokenBase>();
                    httpRequestMessageLocalVar.RequestUri = uriBuilderLocalVar.Uri;

                    OAuthToken oauthTokenLocalVar1 = (OAuthToken) await OauthTokenProvider.GetAsync(cancellation: cancellationToken).ConfigureAwait(false);

                    tokenBaseLocalVars.Add(oauthTokenLocalVar1);

                    oauthTokenLocalVar1.UseInHeader(httpRequestMessageLocalVar, "");

                    string[] acceptLocalVars = new string[] {
                        "*/*",
                        "application/json"
                    };

                    IEnumerable<MediaTypeWithQualityHeaderValue> acceptHeaderValuesLocalVar = ClientUtils.SelectHeaderAcceptArray(acceptLocalVars);

                    foreach (var acceptLocalVar in acceptHeaderValuesLocalVar)
                        httpRequestMessageLocalVar.Headers.Accept.Add(acceptLocalVar);

                    httpRequestMessageLocalVar.Method = HttpMethod.Get;

                    DateTime requestedAtLocalVar = DateTime.UtcNow;

                    using (HttpResponseMessage httpResponseMessageLocalVar = await HttpClient.SendAsync(httpRequestMessageLocalVar, cancellationToken).ConfigureAwait(false))
                    {
                        ILogger<GetPcrDataApiResponse> apiResponseLoggerLocalVar = LoggerFactory.CreateLogger<GetPcrDataApiResponse>();
                        GetPcrDataApiResponse apiResponseLocalVar;

                        switch ((int)httpResponseMessageLocalVar.StatusCode) {
                            default: {
                                string responseContentLocalVar = await httpResponseMessageLocalVar.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                                apiResponseLocalVar = new(apiResponseLoggerLocalVar, httpRequestMessageLocalVar, httpResponseMessageLocalVar, responseContentLocalVar, "/v2/market/pcr", requestedAtLocalVar, _jsonSerializerOptions);

                                break;
                            }
                        }

                        AfterGetPcrDataDefaultImplementation(apiResponseLocalVar, instrumentKey, expiry, date, bucketInterval);

                        if (apiResponseLocalVar.StatusCode == (HttpStatusCode) 429)
                            foreach(TokenBase tokenBaseLocalVar in tokenBaseLocalVars)
                                tokenBaseLocalVar.BeginRateLimit();

                        return apiResponseLocalVar;
                    }
                }
            }
            catch(Exception e)
            {
                OnErrorGetPcrDataDefaultImplementation(e, "/v2/market/pcr", uriBuilderLocalVar.Path, instrumentKey, expiry, date, bucketInterval);
                throw;
            }
        }

        /// <summary>
        /// The <see cref="GetPcrDataApiResponse"/>
        /// </summary>
        public partial class GetPcrDataApiResponse : UpstoxClient.Client.ApiResponse, IGetPcrDataApiResponse
        {
            /// <summary>The logger</summary>
            public ILogger<GetPcrDataApiResponse> Logger { get; }

            public GetPcrDataApiResponse(ILogger<GetPcrDataApiResponse> logger, System.Net.Http.HttpRequestMessage httpRequestMessage, System.Net.Http.HttpResponseMessage httpResponseMessage, string rawContent, string path, DateTime requestedAt, System.Text.Json.JsonSerializerOptions jsonSerializerOptions) : base(httpRequestMessage, httpResponseMessage, rawContent, path, requestedAt, jsonSerializerOptions)
            {
                Logger = logger;
                OnCreated(httpRequestMessage, httpResponseMessage);
            }

            public GetPcrDataApiResponse(ILogger<GetPcrDataApiResponse> logger, System.Net.Http.HttpRequestMessage httpRequestMessage, System.Net.Http.HttpResponseMessage httpResponseMessage, System.IO.Stream contentStream, string path, DateTime requestedAt, System.Text.Json.JsonSerializerOptions jsonSerializerOptions) : base(httpRequestMessage, httpResponseMessage, contentStream, path, requestedAt, jsonSerializerOptions)
            {
                Logger = logger;
                OnCreated(httpRequestMessage, httpResponseMessage);
            }

            partial void OnCreated(global::System.Net.Http.HttpRequestMessage httpRequestMessage, System.Net.Http.HttpResponseMessage httpResponseMessage);

            public bool IsMethodNotAllowed => 405 == (int)StatusCode;
            public UpstoxClient.Model.ApiGatewayErrorResponse? MethodNotAllowed() => IsMethodNotAllowed ? System.Text.Json.JsonSerializer.Deserialize<UpstoxClient.Model.ApiGatewayErrorResponse>(RawContent, _jsonSerializerOptions) : null;
            public bool TryMethodNotAllowed([NotNullWhen(true)]out UpstoxClient.Model.ApiGatewayErrorResponse? result) { result = null; try { result = MethodNotAllowed(); } catch (Exception e) { OnDeserializationErrorDefaultImplementation(e, (HttpStatusCode)405); } return result != null; }

            public bool IsBadRequest => 400 == (int)StatusCode;
            public UpstoxClient.Model.ApiGatewayErrorResponse? BadRequest() => IsBadRequest ? System.Text.Json.JsonSerializer.Deserialize<UpstoxClient.Model.ApiGatewayErrorResponse>(RawContent, _jsonSerializerOptions) : null;
            public bool TryBadRequest([NotNullWhen(true)]out UpstoxClient.Model.ApiGatewayErrorResponse? result) { result = null; try { result = BadRequest(); } catch (Exception e) { OnDeserializationErrorDefaultImplementation(e, (HttpStatusCode)400); } return result != null; }

            public bool IsInternalServerError => 500 == (int)StatusCode;
            public UpstoxClient.Model.ApiGatewayErrorResponse? InternalServerError() => IsInternalServerError ? System.Text.Json.JsonSerializer.Deserialize<UpstoxClient.Model.ApiGatewayErrorResponse>(RawContent, _jsonSerializerOptions) : null;
            public bool TryInternalServerError([NotNullWhen(true)]out UpstoxClient.Model.ApiGatewayErrorResponse? result) { result = null; try { result = InternalServerError(); } catch (Exception e) { OnDeserializationErrorDefaultImplementation(e, (HttpStatusCode)500); } return result != null; }

            public bool IsLocked => 423 == (int)StatusCode;
            public UpstoxClient.Model.ApiGatewayErrorResponse? Locked() => IsLocked ? System.Text.Json.JsonSerializer.Deserialize<UpstoxClient.Model.ApiGatewayErrorResponse>(RawContent, _jsonSerializerOptions) : null;
            public bool TryLocked([NotNullWhen(true)]out UpstoxClient.Model.ApiGatewayErrorResponse? result) { result = null; try { result = Locked(); } catch (Exception e) { OnDeserializationErrorDefaultImplementation(e, (HttpStatusCode)423); } return result != null; }

            public bool IsUnprocessableContent => 422 == (int)StatusCode;
            public UpstoxClient.Model.ApiGatewayErrorResponse? UnprocessableContent() => IsUnprocessableContent ? System.Text.Json.JsonSerializer.Deserialize<UpstoxClient.Model.ApiGatewayErrorResponse>(RawContent, _jsonSerializerOptions) : null;
            public bool TryUnprocessableContent([NotNullWhen(true)]out UpstoxClient.Model.ApiGatewayErrorResponse? result) { result = null; try { result = UnprocessableContent(); } catch (Exception e) { OnDeserializationErrorDefaultImplementation(e, (HttpStatusCode)422); } return result != null; }

            public bool IsTooManyRequests => 429 == (int)StatusCode;
            public UpstoxClient.Model.ApiGatewayErrorResponse? TooManyRequests() => IsTooManyRequests ? System.Text.Json.JsonSerializer.Deserialize<UpstoxClient.Model.ApiGatewayErrorResponse>(RawContent, _jsonSerializerOptions) : null;
            public bool TryTooManyRequests([NotNullWhen(true)]out UpstoxClient.Model.ApiGatewayErrorResponse? result) { result = null; try { result = TooManyRequests(); } catch (Exception e) { OnDeserializationErrorDefaultImplementation(e, (HttpStatusCode)429); } return result != null; }

            public bool IsOk => 200 == (int)StatusCode;
            public UpstoxClient.Model.AnalyticsResponse? Ok() => IsOk ? System.Text.Json.JsonSerializer.Deserialize<UpstoxClient.Model.AnalyticsResponse>(RawContent, _jsonSerializerOptions) : null;
            public bool TryOk([NotNullWhen(true)]out UpstoxClient.Model.AnalyticsResponse? result) { result = null; try { result = Ok(); } catch (Exception e) { OnDeserializationErrorDefaultImplementation(e, (HttpStatusCode)200); } return result != null; }

            public bool IsUnauthorized => 401 == (int)StatusCode;
            public UpstoxClient.Model.ApiGatewayErrorResponse? Unauthorized() => IsUnauthorized ? System.Text.Json.JsonSerializer.Deserialize<UpstoxClient.Model.ApiGatewayErrorResponse>(RawContent, _jsonSerializerOptions) : null;
            public bool TryUnauthorized([NotNullWhen(true)]out UpstoxClient.Model.ApiGatewayErrorResponse? result) { result = null; try { result = Unauthorized(); } catch (Exception e) { OnDeserializationErrorDefaultImplementation(e, (HttpStatusCode)401); } return result != null; }

            private void OnDeserializationErrorDefaultImplementation(Exception exception, HttpStatusCode httpStatusCode)
            {
                bool suppressDefaultLog = false;
                OnDeserializationError(ref suppressDefaultLog, exception, httpStatusCode);
                if (!suppressDefaultLog)
                    Logger.LogError(exception, "An error occurred while deserializing the {code} response.", httpStatusCode);
            }

            partial void OnDeserializationError(ref bool suppressDefaultLog, Exception exception, HttpStatusCode httpStatusCode);
        }
    }
}
