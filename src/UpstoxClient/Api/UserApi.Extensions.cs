/*
 * Upstox .NET SDK — UserApi extension
 * Adds /user endpoints introduced in the 2025 API revision.
 * Implemented as a partial class to avoid modifying the existing UserApi.cs.
 */

#nullable enable

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using UpstoxClient.Client;
using UpstoxClient.Model;
using System.Diagnostics.CodeAnalysis;

namespace UpstoxClient.Api
{
    // ── Response interfaces ────────────────────────────────────────────────────

    /// <summary>
    /// The <see cref="IGetKillSwitchApiResponse"/>
    /// </summary>
    public interface IGetKillSwitchApiResponse : UpstoxClient.Client.IApiResponse, IMethodNotAllowed<UpstoxClient.Model.ApiGatewayErrorResponse?>, IBadRequest<UpstoxClient.Model.ApiGatewayErrorResponse?>, IInternalServerError<UpstoxClient.Model.ApiGatewayErrorResponse?>, ILocked<UpstoxClient.Model.ApiGatewayErrorResponse?>, IUnprocessableContent<UpstoxClient.Model.ApiGatewayErrorResponse?>, ITooManyRequests<UpstoxClient.Model.ApiGatewayErrorResponse?>, IOk<UpstoxClient.Model.KillSwitchResponse?>
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
    }

    /// <summary>
    /// The <see cref="IGetPayinHistoryApiResponse"/>
    /// </summary>
    public interface IGetPayinHistoryApiResponse : UpstoxClient.Client.IApiResponse, IMethodNotAllowed<UpstoxClient.Model.ApiGatewayErrorResponse?>, IBadRequest<UpstoxClient.Model.ApiGatewayErrorResponse?>, IInternalServerError<UpstoxClient.Model.ApiGatewayErrorResponse?>, ILocked<UpstoxClient.Model.ApiGatewayErrorResponse?>, IUnprocessableContent<UpstoxClient.Model.ApiGatewayErrorResponse?>, ITooManyRequests<UpstoxClient.Model.ApiGatewayErrorResponse?>, IOk<UpstoxClient.Model.PaymentHistoryResponse?>
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
    }

    /// <summary>
    /// The <see cref="IGetPayoutHistoryApiResponse"/>
    /// </summary>
    public interface IGetPayoutHistoryApiResponse : UpstoxClient.Client.IApiResponse, IMethodNotAllowed<UpstoxClient.Model.ApiGatewayErrorResponse?>, IBadRequest<UpstoxClient.Model.ApiGatewayErrorResponse?>, IInternalServerError<UpstoxClient.Model.ApiGatewayErrorResponse?>, ILocked<UpstoxClient.Model.ApiGatewayErrorResponse?>, IUnprocessableContent<UpstoxClient.Model.ApiGatewayErrorResponse?>, ITooManyRequests<UpstoxClient.Model.ApiGatewayErrorResponse?>, IOk<UpstoxClient.Model.PaymentHistoryResponse?>
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
    }

    /// <summary>
    /// The <see cref="IGetUserFundMarginV3ApiResponse"/>
    /// </summary>
    public interface IGetUserFundMarginV3ApiResponse : UpstoxClient.Client.IApiResponse, IMethodNotAllowed<UpstoxClient.Model.ApiGatewayErrorResponse?>, IBadRequest<UpstoxClient.Model.ApiGatewayErrorResponse?>, IInternalServerError<UpstoxClient.Model.ApiGatewayErrorResponse?>, ILocked<UpstoxClient.Model.ApiGatewayErrorResponse?>, IUnprocessableContent<UpstoxClient.Model.ApiGatewayErrorResponse?>, ITooManyRequests<UpstoxClient.Model.ApiGatewayErrorResponse?>, IOk<UpstoxClient.Model.GetUserFundMarginV3Response?>
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
    }

    /// <summary>
    /// The <see cref="IGetUserIpsApiResponse"/>
    /// </summary>
    public interface IGetUserIpsApiResponse : UpstoxClient.Client.IApiResponse, IMethodNotAllowed<UpstoxClient.Model.ApiGatewayErrorResponse?>, IBadRequest<UpstoxClient.Model.ApiGatewayErrorResponse?>, IInternalServerError<UpstoxClient.Model.ApiGatewayErrorResponse?>, ILocked<UpstoxClient.Model.ApiGatewayErrorResponse?>, IUnprocessableContent<UpstoxClient.Model.ApiGatewayErrorResponse?>, ITooManyRequests<UpstoxClient.Model.ApiGatewayErrorResponse?>, IOk<UpstoxClient.Model.UserIpResponse?>
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
    }

    /// <summary>
    /// The <see cref="IUpdateKillSwitchApiResponse"/>
    /// </summary>
    public interface IUpdateKillSwitchApiResponse : UpstoxClient.Client.IApiResponse, IMethodNotAllowed<UpstoxClient.Model.ApiGatewayErrorResponse?>, IBadRequest<UpstoxClient.Model.ApiGatewayErrorResponse?>, IInternalServerError<UpstoxClient.Model.ApiGatewayErrorResponse?>, ILocked<UpstoxClient.Model.ApiGatewayErrorResponse?>, IUnprocessableContent<UpstoxClient.Model.ApiGatewayErrorResponse?>, ITooManyRequests<UpstoxClient.Model.ApiGatewayErrorResponse?>, IOk<UpstoxClient.Model.KillSwitchResponse?>
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
    }

    /// <summary>
    /// The <see cref="IUpdateUserIpApiResponse"/>
    /// </summary>
    public interface IUpdateUserIpApiResponse : UpstoxClient.Client.IApiResponse, IMethodNotAllowed<UpstoxClient.Model.ApiGatewayErrorResponse?>, IBadRequest<UpstoxClient.Model.ApiGatewayErrorResponse?>, IInternalServerError<UpstoxClient.Model.ApiGatewayErrorResponse?>, ILocked<UpstoxClient.Model.ApiGatewayErrorResponse?>, IUnprocessableContent<UpstoxClient.Model.ApiGatewayErrorResponse?>, ITooManyRequests<UpstoxClient.Model.ApiGatewayErrorResponse?>, IOk<UpstoxClient.Model.UserIpResponse?>
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
    }

    // ── Partial class extension ────────────────────────────────────────────────
    public sealed partial class UserApi
    {
        // ── GetKillSwitch ──────────────────────────────────────────────────────

        /// <summary>
        /// Processes the server response
        /// </summary>
        /// <param name="apiResponseLocalVar"></param>
        private void AfterGetKillSwitchDefaultImplementation(IGetKillSwitchApiResponse apiResponseLocalVar)
        {
            bool suppressDefaultLog = false;
            AfterGetKillSwitch(ref suppressDefaultLog, apiResponseLocalVar);
            if (!suppressDefaultLog)
                Logger.LogInformation("{0,-9} | {1} | {2}", (apiResponseLocalVar.DownloadedAt - apiResponseLocalVar.RequestedAt).TotalSeconds, apiResponseLocalVar.StatusCode, apiResponseLocalVar.Path);
        }

        /// <summary>
        /// Processes the server response
        /// </summary>
        /// <param name="suppressDefaultLog"></param>
        /// <param name="apiResponseLocalVar"></param>
        partial void AfterGetKillSwitch(ref bool suppressDefaultLog, IGetKillSwitchApiResponse apiResponseLocalVar);

        /// <summary>
        /// Logs exceptions that occur while retrieving the server response
        /// </summary>
        /// <param name="exceptionLocalVar"></param>
        /// <param name="pathFormatLocalVar"></param>
        /// <param name="pathLocalVar"></param>
        private void OnErrorGetKillSwitchDefaultImplementation(Exception exceptionLocalVar, string pathFormatLocalVar, string pathLocalVar)
        {
            bool suppressDefaultLogLocalVar = false;
            OnErrorGetKillSwitch(ref suppressDefaultLogLocalVar, exceptionLocalVar, pathFormatLocalVar, pathLocalVar);
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
        partial void OnErrorGetKillSwitch(ref bool suppressDefaultLogLocalVar, Exception exceptionLocalVar, string pathFormatLocalVar, string pathLocalVar);

        /// <summary>
        /// Get kill switch status Returns the disable/enable status of all trading segments for the user.
        /// </summary>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns><see cref="Task"/>&lt;<see cref="IGetKillSwitchApiResponse"/>&gt;</returns>
        public async Task<IGetKillSwitchApiResponse?> GetKillSwitchOrDefaultAsync(System.Threading.CancellationToken cancellationToken = default)
        {
            try
            {
                return await GetKillSwitchAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Get kill switch status Returns the disable/enable status of all trading segments for the user.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns><see cref="Task"/>&lt;<see cref="IGetKillSwitchApiResponse"/>&gt;</returns>
        public async Task<IGetKillSwitchApiResponse> GetKillSwitchAsync(System.Threading.CancellationToken cancellationToken = default)
        {
            UriBuilder uriBuilderLocalVar = new UriBuilder();

            try
            {
                using (HttpRequestMessage httpRequestMessageLocalVar = new HttpRequestMessage())
                {
                    uriBuilderLocalVar.Host = HttpClient.BaseAddress!.Host;
                    uriBuilderLocalVar.Port = HttpClient.BaseAddress.Port;
                    uriBuilderLocalVar.Scheme = HttpClient.BaseAddress.Scheme;
                    uriBuilderLocalVar.Path = HttpClient.BaseAddress.AbsolutePath == "/"
                        ? "/v2/user/kill-switch"
                        : string.Concat(HttpClient.BaseAddress.AbsolutePath.TrimEnd('/'), "/v2/user/kill-switch");

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
                        ILogger<GetKillSwitchApiResponse> apiResponseLoggerLocalVar = LoggerFactory.CreateLogger<GetKillSwitchApiResponse>();
                        GetKillSwitchApiResponse apiResponseLocalVar;

                        switch ((int)httpResponseMessageLocalVar.StatusCode) {
                            default: {
                                string responseContentLocalVar = await httpResponseMessageLocalVar.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                                apiResponseLocalVar = new(apiResponseLoggerLocalVar, httpRequestMessageLocalVar, httpResponseMessageLocalVar, responseContentLocalVar, "/v2/user/kill-switch", requestedAtLocalVar, _jsonSerializerOptions);

                                break;
                            }
                        }

                        AfterGetKillSwitchDefaultImplementation(apiResponseLocalVar);

                        if (apiResponseLocalVar.StatusCode == (HttpStatusCode) 429)
                            foreach(TokenBase tokenBaseLocalVar in tokenBaseLocalVars)
                                tokenBaseLocalVar.BeginRateLimit();

                        return apiResponseLocalVar;
                    }
                }
            }
            catch(Exception e)
            {
                OnErrorGetKillSwitchDefaultImplementation(e, "/v2/user/kill-switch", uriBuilderLocalVar.Path);
                throw;
            }
        }

        /// <summary>
        /// The <see cref="GetKillSwitchApiResponse"/>
        /// </summary>
        public partial class GetKillSwitchApiResponse : UpstoxClient.Client.ApiResponse, IGetKillSwitchApiResponse
        {
            /// <summary>
            /// The logger
            /// </summary>
            public ILogger<GetKillSwitchApiResponse> Logger { get; }

            /// <summary>
            /// The <see cref="GetKillSwitchApiResponse"/>
            /// </summary>
            /// <param name="logger"></param>
            /// <param name="httpRequestMessage"></param>
            /// <param name="httpResponseMessage"></param>
            /// <param name="rawContent"></param>
            /// <param name="path"></param>
            /// <param name="requestedAt"></param>
            /// <param name="jsonSerializerOptions"></param>
            public GetKillSwitchApiResponse(ILogger<GetKillSwitchApiResponse> logger, System.Net.Http.HttpRequestMessage httpRequestMessage, System.Net.Http.HttpResponseMessage httpResponseMessage, string rawContent, string path, DateTime requestedAt, System.Text.Json.JsonSerializerOptions jsonSerializerOptions) : base(httpRequestMessage, httpResponseMessage, rawContent, path, requestedAt, jsonSerializerOptions)
            {
                Logger = logger;
                OnCreated(httpRequestMessage, httpResponseMessage);
            }

            /// <summary>
            /// The <see cref="GetKillSwitchApiResponse"/>
            /// </summary>
            /// <param name="logger"></param>
            /// <param name="httpRequestMessage"></param>
            /// <param name="httpResponseMessage"></param>
            /// <param name="contentStream"></param>
            /// <param name="path"></param>
            /// <param name="requestedAt"></param>
            /// <param name="jsonSerializerOptions"></param>
            public GetKillSwitchApiResponse(ILogger<GetKillSwitchApiResponse> logger, System.Net.Http.HttpRequestMessage httpRequestMessage, System.Net.Http.HttpResponseMessage httpResponseMessage, System.IO.Stream contentStream, string path, DateTime requestedAt, System.Text.Json.JsonSerializerOptions jsonSerializerOptions) : base(httpRequestMessage, httpResponseMessage, contentStream, path, requestedAt, jsonSerializerOptions)
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
                try { result = MethodNotAllowed(); } catch (Exception e) { OnDeserializationErrorDefaultImplementation(e, (HttpStatusCode)405); }
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
                try { result = BadRequest(); } catch (Exception e) { OnDeserializationErrorDefaultImplementation(e, (HttpStatusCode)400); }
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
                try { result = InternalServerError(); } catch (Exception e) { OnDeserializationErrorDefaultImplementation(e, (HttpStatusCode)500); }
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
                try { result = Locked(); } catch (Exception e) { OnDeserializationErrorDefaultImplementation(e, (HttpStatusCode)423); }
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
                try { result = UnprocessableContent(); } catch (Exception e) { OnDeserializationErrorDefaultImplementation(e, (HttpStatusCode)422); }
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
                try { result = TooManyRequests(); } catch (Exception e) { OnDeserializationErrorDefaultImplementation(e, (HttpStatusCode)429); }
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
            public UpstoxClient.Model.KillSwitchResponse? Ok()
            {
                return IsOk
                    ? System.Text.Json.JsonSerializer.Deserialize<UpstoxClient.Model.KillSwitchResponse>(RawContent, _jsonSerializerOptions)
                    : null;
            }

            /// <summary>
            /// Returns true if the response is 200 Ok and the deserialized response is not null
            /// </summary>
            /// <param name="result"></param>
            /// <returns></returns>
            public bool TryOk([NotNullWhen(true)]out UpstoxClient.Model.KillSwitchResponse? result)
            {
                result = null;
                try { result = Ok(); } catch (Exception e) { OnDeserializationErrorDefaultImplementation(e, (HttpStatusCode)200); }
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

        // ── GetPayinHistory ────────────────────────────────────────────────────

        /// <summary>
        /// Processes the server response
        /// </summary>
        /// <param name="apiResponseLocalVar"></param>
        private void AfterGetPayinHistoryDefaultImplementation(IGetPayinHistoryApiResponse apiResponseLocalVar)
        {
            bool suppressDefaultLog = false;
            AfterGetPayinHistory(ref suppressDefaultLog, apiResponseLocalVar);
            if (!suppressDefaultLog)
                Logger.LogInformation("{0,-9} | {1} | {2}", (apiResponseLocalVar.DownloadedAt - apiResponseLocalVar.RequestedAt).TotalSeconds, apiResponseLocalVar.StatusCode, apiResponseLocalVar.Path);
        }

        partial void AfterGetPayinHistory(ref bool suppressDefaultLog, IGetPayinHistoryApiResponse apiResponseLocalVar);

        private void OnErrorGetPayinHistoryDefaultImplementation(Exception exceptionLocalVar, string pathFormatLocalVar, string pathLocalVar)
        {
            bool suppressDefaultLogLocalVar = false;
            OnErrorGetPayinHistory(ref suppressDefaultLogLocalVar, exceptionLocalVar, pathFormatLocalVar, pathLocalVar);
            if (!suppressDefaultLogLocalVar)
                Logger.LogError(exceptionLocalVar, "An error occurred while sending the request to the server.");
        }

        partial void OnErrorGetPayinHistory(ref bool suppressDefaultLogLocalVar, Exception exceptionLocalVar, string pathFormatLocalVar, string pathLocalVar);

        /// <summary>
        ///
        /// </summary>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns><see cref="Task"/>&lt;<see cref="IGetPayinHistoryApiResponse"/>&gt;</returns>
        public async Task<IGetPayinHistoryApiResponse?> GetPayinHistoryOrDefaultAsync(System.Threading.CancellationToken cancellationToken = default)
        {
            try
            {
                return await GetPayinHistoryAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns><see cref="Task"/>&lt;<see cref="IGetPayinHistoryApiResponse"/>&gt;</returns>
        public async Task<IGetPayinHistoryApiResponse> GetPayinHistoryAsync(System.Threading.CancellationToken cancellationToken = default)
        {
            UriBuilder uriBuilderLocalVar = new UriBuilder();

            try
            {
                using (HttpRequestMessage httpRequestMessageLocalVar = new HttpRequestMessage())
                {
                    uriBuilderLocalVar.Host = HttpClient.BaseAddress!.Host;
                    uriBuilderLocalVar.Port = HttpClient.BaseAddress.Port;
                    uriBuilderLocalVar.Scheme = HttpClient.BaseAddress.Scheme;
                    uriBuilderLocalVar.Path = HttpClient.BaseAddress.AbsolutePath == "/"
                        ? "/v2/user/payments/payin"
                        : string.Concat(HttpClient.BaseAddress.AbsolutePath.TrimEnd('/'), "/v2/user/payments/payin");

                    List<TokenBase> tokenBaseLocalVars = new List<TokenBase>();
                    httpRequestMessageLocalVar.RequestUri = uriBuilderLocalVar.Uri;

                    OAuthToken oauthTokenLocalVar1 = (OAuthToken) await OauthTokenProvider.GetAsync(cancellation: cancellationToken).ConfigureAwait(false);

                    tokenBaseLocalVars.Add(oauthTokenLocalVar1);

                    oauthTokenLocalVar1.UseInHeader(httpRequestMessageLocalVar, "");

                    string[] acceptLocalVars = new string[] {
                        "*/*"
                    };

                    IEnumerable<MediaTypeWithQualityHeaderValue> acceptHeaderValuesLocalVar = ClientUtils.SelectHeaderAcceptArray(acceptLocalVars);

                    foreach (var acceptLocalVar in acceptHeaderValuesLocalVar)
                        httpRequestMessageLocalVar.Headers.Accept.Add(acceptLocalVar);

                    httpRequestMessageLocalVar.Method = HttpMethod.Get;

                    DateTime requestedAtLocalVar = DateTime.UtcNow;

                    using (HttpResponseMessage httpResponseMessageLocalVar = await HttpClient.SendAsync(httpRequestMessageLocalVar, cancellationToken).ConfigureAwait(false))
                    {
                        ILogger<GetPayinHistoryApiResponse> apiResponseLoggerLocalVar = LoggerFactory.CreateLogger<GetPayinHistoryApiResponse>();
                        GetPayinHistoryApiResponse apiResponseLocalVar;

                        switch ((int)httpResponseMessageLocalVar.StatusCode) {
                            default: {
                                string responseContentLocalVar = await httpResponseMessageLocalVar.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                                apiResponseLocalVar = new(apiResponseLoggerLocalVar, httpRequestMessageLocalVar, httpResponseMessageLocalVar, responseContentLocalVar, "/v2/user/payments/payin", requestedAtLocalVar, _jsonSerializerOptions);

                                break;
                            }
                        }

                        AfterGetPayinHistoryDefaultImplementation(apiResponseLocalVar);

                        if (apiResponseLocalVar.StatusCode == (HttpStatusCode) 429)
                            foreach(TokenBase tokenBaseLocalVar in tokenBaseLocalVars)
                                tokenBaseLocalVar.BeginRateLimit();

                        return apiResponseLocalVar;
                    }
                }
            }
            catch(Exception e)
            {
                OnErrorGetPayinHistoryDefaultImplementation(e, "/v2/user/payments/payin", uriBuilderLocalVar.Path);
                throw;
            }
        }

        /// <summary>
        /// The <see cref="GetPayinHistoryApiResponse"/>
        /// </summary>
        public partial class GetPayinHistoryApiResponse : UpstoxClient.Client.ApiResponse, IGetPayinHistoryApiResponse
        {
            /// <summary>
            /// The logger
            /// </summary>
            public ILogger<GetPayinHistoryApiResponse> Logger { get; }

            public GetPayinHistoryApiResponse(ILogger<GetPayinHistoryApiResponse> logger, System.Net.Http.HttpRequestMessage httpRequestMessage, System.Net.Http.HttpResponseMessage httpResponseMessage, string rawContent, string path, DateTime requestedAt, System.Text.Json.JsonSerializerOptions jsonSerializerOptions) : base(httpRequestMessage, httpResponseMessage, rawContent, path, requestedAt, jsonSerializerOptions)
            {
                Logger = logger;
                OnCreated(httpRequestMessage, httpResponseMessage);
            }

            public GetPayinHistoryApiResponse(ILogger<GetPayinHistoryApiResponse> logger, System.Net.Http.HttpRequestMessage httpRequestMessage, System.Net.Http.HttpResponseMessage httpResponseMessage, System.IO.Stream contentStream, string path, DateTime requestedAt, System.Text.Json.JsonSerializerOptions jsonSerializerOptions) : base(httpRequestMessage, httpResponseMessage, contentStream, path, requestedAt, jsonSerializerOptions)
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
            public UpstoxClient.Model.PaymentHistoryResponse? Ok() => IsOk ? System.Text.Json.JsonSerializer.Deserialize<UpstoxClient.Model.PaymentHistoryResponse>(RawContent, _jsonSerializerOptions) : null;
            public bool TryOk([NotNullWhen(true)]out UpstoxClient.Model.PaymentHistoryResponse? result) { result = null; try { result = Ok(); } catch (Exception e) { OnDeserializationErrorDefaultImplementation(e, (HttpStatusCode)200); } return result != null; }

            private void OnDeserializationErrorDefaultImplementation(Exception exception, HttpStatusCode httpStatusCode)
            {
                bool suppressDefaultLog = false;
                OnDeserializationError(ref suppressDefaultLog, exception, httpStatusCode);
                if (!suppressDefaultLog)
                    Logger.LogError(exception, "An error occurred while deserializing the {code} response.", httpStatusCode);
            }

            partial void OnDeserializationError(ref bool suppressDefaultLog, Exception exception, HttpStatusCode httpStatusCode);
        }

        // ── GetPayoutHistory ───────────────────────────────────────────────────

        private void AfterGetPayoutHistoryDefaultImplementation(IGetPayoutHistoryApiResponse apiResponseLocalVar)
        {
            bool suppressDefaultLog = false;
            AfterGetPayoutHistory(ref suppressDefaultLog, apiResponseLocalVar);
            if (!suppressDefaultLog)
                Logger.LogInformation("{0,-9} | {1} | {2}", (apiResponseLocalVar.DownloadedAt - apiResponseLocalVar.RequestedAt).TotalSeconds, apiResponseLocalVar.StatusCode, apiResponseLocalVar.Path);
        }

        partial void AfterGetPayoutHistory(ref bool suppressDefaultLog, IGetPayoutHistoryApiResponse apiResponseLocalVar);

        private void OnErrorGetPayoutHistoryDefaultImplementation(Exception exceptionLocalVar, string pathFormatLocalVar, string pathLocalVar)
        {
            bool suppressDefaultLogLocalVar = false;
            OnErrorGetPayoutHistory(ref suppressDefaultLogLocalVar, exceptionLocalVar, pathFormatLocalVar, pathLocalVar);
            if (!suppressDefaultLogLocalVar)
                Logger.LogError(exceptionLocalVar, "An error occurred while sending the request to the server.");
        }

        partial void OnErrorGetPayoutHistory(ref bool suppressDefaultLogLocalVar, Exception exceptionLocalVar, string pathFormatLocalVar, string pathLocalVar);

        public async Task<IGetPayoutHistoryApiResponse?> GetPayoutHistoryOrDefaultAsync(System.Threading.CancellationToken cancellationToken = default)
        {
            try { return await GetPayoutHistoryAsync(cancellationToken).ConfigureAwait(false); }
            catch (Exception) { return null; }
        }

        public async Task<IGetPayoutHistoryApiResponse> GetPayoutHistoryAsync(System.Threading.CancellationToken cancellationToken = default)
        {
            UriBuilder uriBuilderLocalVar = new UriBuilder();

            try
            {
                using (HttpRequestMessage httpRequestMessageLocalVar = new HttpRequestMessage())
                {
                    uriBuilderLocalVar.Host = HttpClient.BaseAddress!.Host;
                    uriBuilderLocalVar.Port = HttpClient.BaseAddress.Port;
                    uriBuilderLocalVar.Scheme = HttpClient.BaseAddress.Scheme;
                    uriBuilderLocalVar.Path = HttpClient.BaseAddress.AbsolutePath == "/"
                        ? "/v2/user/payments/payout"
                        : string.Concat(HttpClient.BaseAddress.AbsolutePath.TrimEnd('/'), "/v2/user/payments/payout");

                    List<TokenBase> tokenBaseLocalVars = new List<TokenBase>();
                    httpRequestMessageLocalVar.RequestUri = uriBuilderLocalVar.Uri;

                    OAuthToken oauthTokenLocalVar1 = (OAuthToken) await OauthTokenProvider.GetAsync(cancellation: cancellationToken).ConfigureAwait(false);
                    tokenBaseLocalVars.Add(oauthTokenLocalVar1);
                    oauthTokenLocalVar1.UseInHeader(httpRequestMessageLocalVar, "");

                    string[] acceptLocalVars = new string[] { "*/*" };
                    IEnumerable<MediaTypeWithQualityHeaderValue> acceptHeaderValuesLocalVar = ClientUtils.SelectHeaderAcceptArray(acceptLocalVars);
                    foreach (var acceptLocalVar in acceptHeaderValuesLocalVar)
                        httpRequestMessageLocalVar.Headers.Accept.Add(acceptLocalVar);

                    httpRequestMessageLocalVar.Method = HttpMethod.Get;
                    DateTime requestedAtLocalVar = DateTime.UtcNow;

                    using (HttpResponseMessage httpResponseMessageLocalVar = await HttpClient.SendAsync(httpRequestMessageLocalVar, cancellationToken).ConfigureAwait(false))
                    {
                        ILogger<GetPayoutHistoryApiResponse> apiResponseLoggerLocalVar = LoggerFactory.CreateLogger<GetPayoutHistoryApiResponse>();
                        GetPayoutHistoryApiResponse apiResponseLocalVar;

                        switch ((int)httpResponseMessageLocalVar.StatusCode) {
                            default: {
                                string responseContentLocalVar = await httpResponseMessageLocalVar.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                                apiResponseLocalVar = new(apiResponseLoggerLocalVar, httpRequestMessageLocalVar, httpResponseMessageLocalVar, responseContentLocalVar, "/v2/user/payments/payout", requestedAtLocalVar, _jsonSerializerOptions);
                                break;
                            }
                        }

                        AfterGetPayoutHistoryDefaultImplementation(apiResponseLocalVar);

                        if (apiResponseLocalVar.StatusCode == (HttpStatusCode) 429)
                            foreach(TokenBase tokenBaseLocalVar in tokenBaseLocalVars)
                                tokenBaseLocalVar.BeginRateLimit();

                        return apiResponseLocalVar;
                    }
                }
            }
            catch(Exception e)
            {
                OnErrorGetPayoutHistoryDefaultImplementation(e, "/v2/user/payments/payout", uriBuilderLocalVar.Path);
                throw;
            }
        }

        public partial class GetPayoutHistoryApiResponse : UpstoxClient.Client.ApiResponse, IGetPayoutHistoryApiResponse
        {
            public ILogger<GetPayoutHistoryApiResponse> Logger { get; }

            public GetPayoutHistoryApiResponse(ILogger<GetPayoutHistoryApiResponse> logger, System.Net.Http.HttpRequestMessage httpRequestMessage, System.Net.Http.HttpResponseMessage httpResponseMessage, string rawContent, string path, DateTime requestedAt, System.Text.Json.JsonSerializerOptions jsonSerializerOptions) : base(httpRequestMessage, httpResponseMessage, rawContent, path, requestedAt, jsonSerializerOptions)
            {
                Logger = logger;
                OnCreated(httpRequestMessage, httpResponseMessage);
            }

            public GetPayoutHistoryApiResponse(ILogger<GetPayoutHistoryApiResponse> logger, System.Net.Http.HttpRequestMessage httpRequestMessage, System.Net.Http.HttpResponseMessage httpResponseMessage, System.IO.Stream contentStream, string path, DateTime requestedAt, System.Text.Json.JsonSerializerOptions jsonSerializerOptions) : base(httpRequestMessage, httpResponseMessage, contentStream, path, requestedAt, jsonSerializerOptions)
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
            public UpstoxClient.Model.PaymentHistoryResponse? Ok() => IsOk ? System.Text.Json.JsonSerializer.Deserialize<UpstoxClient.Model.PaymentHistoryResponse>(RawContent, _jsonSerializerOptions) : null;
            public bool TryOk([NotNullWhen(true)]out UpstoxClient.Model.PaymentHistoryResponse? result) { result = null; try { result = Ok(); } catch (Exception e) { OnDeserializationErrorDefaultImplementation(e, (HttpStatusCode)200); } return result != null; }

            private void OnDeserializationErrorDefaultImplementation(Exception exception, HttpStatusCode httpStatusCode)
            {
                bool suppressDefaultLog = false;
                OnDeserializationError(ref suppressDefaultLog, exception, httpStatusCode);
                if (!suppressDefaultLog)
                    Logger.LogError(exception, "An error occurred while deserializing the {code} response.", httpStatusCode);
            }

            partial void OnDeserializationError(ref bool suppressDefaultLog, Exception exception, HttpStatusCode httpStatusCode);
        }

        // ── GetUserFundMarginV3 ────────────────────────────────────────────────

        private void AfterGetUserFundMarginV3DefaultImplementation(IGetUserFundMarginV3ApiResponse apiResponseLocalVar)
        {
            bool suppressDefaultLog = false;
            AfterGetUserFundMarginV3(ref suppressDefaultLog, apiResponseLocalVar);
            if (!suppressDefaultLog)
                Logger.LogInformation("{0,-9} | {1} | {2}", (apiResponseLocalVar.DownloadedAt - apiResponseLocalVar.RequestedAt).TotalSeconds, apiResponseLocalVar.StatusCode, apiResponseLocalVar.Path);
        }

        partial void AfterGetUserFundMarginV3(ref bool suppressDefaultLog, IGetUserFundMarginV3ApiResponse apiResponseLocalVar);

        private void OnErrorGetUserFundMarginV3DefaultImplementation(Exception exceptionLocalVar, string pathFormatLocalVar, string pathLocalVar)
        {
            bool suppressDefaultLogLocalVar = false;
            OnErrorGetUserFundMarginV3(ref suppressDefaultLogLocalVar, exceptionLocalVar, pathFormatLocalVar, pathLocalVar);
            if (!suppressDefaultLogLocalVar)
                Logger.LogError(exceptionLocalVar, "An error occurred while sending the request to the server.");
        }

        partial void OnErrorGetUserFundMarginV3(ref bool suppressDefaultLogLocalVar, Exception exceptionLocalVar, string pathFormatLocalVar, string pathLocalVar);

        public async Task<IGetUserFundMarginV3ApiResponse?> GetUserFundMarginV3OrDefaultAsync(System.Threading.CancellationToken cancellationToken = default)
        {
            try { return await GetUserFundMarginV3Async(cancellationToken).ConfigureAwait(false); }
            catch (Exception) { return null; }
        }

        public async Task<IGetUserFundMarginV3ApiResponse> GetUserFundMarginV3Async(System.Threading.CancellationToken cancellationToken = default)
        {
            UriBuilder uriBuilderLocalVar = new UriBuilder();

            try
            {
                using (HttpRequestMessage httpRequestMessageLocalVar = new HttpRequestMessage())
                {
                    uriBuilderLocalVar.Host = HttpClient.BaseAddress!.Host;
                    uriBuilderLocalVar.Port = HttpClient.BaseAddress.Port;
                    uriBuilderLocalVar.Scheme = HttpClient.BaseAddress.Scheme;
                    uriBuilderLocalVar.Path = HttpClient.BaseAddress.AbsolutePath == "/"
                        ? "/v3/user/get-funds-and-margin"
                        : string.Concat(HttpClient.BaseAddress.AbsolutePath.TrimEnd('/'), "/v3/user/get-funds-and-margin");

                    List<TokenBase> tokenBaseLocalVars = new List<TokenBase>();
                    httpRequestMessageLocalVar.RequestUri = uriBuilderLocalVar.Uri;

                    OAuthToken oauthTokenLocalVar1 = (OAuthToken) await OauthTokenProvider.GetAsync(cancellation: cancellationToken).ConfigureAwait(false);
                    tokenBaseLocalVars.Add(oauthTokenLocalVar1);
                    oauthTokenLocalVar1.UseInHeader(httpRequestMessageLocalVar, "");

                    string[] acceptLocalVars = new string[] { "*/*", "application/json" };
                    IEnumerable<MediaTypeWithQualityHeaderValue> acceptHeaderValuesLocalVar = ClientUtils.SelectHeaderAcceptArray(acceptLocalVars);
                    foreach (var acceptLocalVar in acceptHeaderValuesLocalVar)
                        httpRequestMessageLocalVar.Headers.Accept.Add(acceptLocalVar);

                    httpRequestMessageLocalVar.Method = HttpMethod.Get;
                    DateTime requestedAtLocalVar = DateTime.UtcNow;

                    using (HttpResponseMessage httpResponseMessageLocalVar = await HttpClient.SendAsync(httpRequestMessageLocalVar, cancellationToken).ConfigureAwait(false))
                    {
                        ILogger<GetUserFundMarginV3ApiResponse> apiResponseLoggerLocalVar = LoggerFactory.CreateLogger<GetUserFundMarginV3ApiResponse>();
                        GetUserFundMarginV3ApiResponse apiResponseLocalVar;

                        switch ((int)httpResponseMessageLocalVar.StatusCode) {
                            default: {
                                string responseContentLocalVar = await httpResponseMessageLocalVar.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                                apiResponseLocalVar = new(apiResponseLoggerLocalVar, httpRequestMessageLocalVar, httpResponseMessageLocalVar, responseContentLocalVar, "/v3/user/get-funds-and-margin", requestedAtLocalVar, _jsonSerializerOptions);
                                break;
                            }
                        }

                        AfterGetUserFundMarginV3DefaultImplementation(apiResponseLocalVar);

                        if (apiResponseLocalVar.StatusCode == (HttpStatusCode) 429)
                            foreach(TokenBase tokenBaseLocalVar in tokenBaseLocalVars)
                                tokenBaseLocalVar.BeginRateLimit();

                        return apiResponseLocalVar;
                    }
                }
            }
            catch(Exception e)
            {
                OnErrorGetUserFundMarginV3DefaultImplementation(e, "/v3/user/get-funds-and-margin", uriBuilderLocalVar.Path);
                throw;
            }
        }

        public partial class GetUserFundMarginV3ApiResponse : UpstoxClient.Client.ApiResponse, IGetUserFundMarginV3ApiResponse
        {
            public ILogger<GetUserFundMarginV3ApiResponse> Logger { get; }

            public GetUserFundMarginV3ApiResponse(ILogger<GetUserFundMarginV3ApiResponse> logger, System.Net.Http.HttpRequestMessage httpRequestMessage, System.Net.Http.HttpResponseMessage httpResponseMessage, string rawContent, string path, DateTime requestedAt, System.Text.Json.JsonSerializerOptions jsonSerializerOptions) : base(httpRequestMessage, httpResponseMessage, rawContent, path, requestedAt, jsonSerializerOptions)
            {
                Logger = logger;
                OnCreated(httpRequestMessage, httpResponseMessage);
            }

            public GetUserFundMarginV3ApiResponse(ILogger<GetUserFundMarginV3ApiResponse> logger, System.Net.Http.HttpRequestMessage httpRequestMessage, System.Net.Http.HttpResponseMessage httpResponseMessage, System.IO.Stream contentStream, string path, DateTime requestedAt, System.Text.Json.JsonSerializerOptions jsonSerializerOptions) : base(httpRequestMessage, httpResponseMessage, contentStream, path, requestedAt, jsonSerializerOptions)
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
            public UpstoxClient.Model.GetUserFundMarginV3Response? Ok() => IsOk ? System.Text.Json.JsonSerializer.Deserialize<UpstoxClient.Model.GetUserFundMarginV3Response>(RawContent, _jsonSerializerOptions) : null;
            public bool TryOk([NotNullWhen(true)]out UpstoxClient.Model.GetUserFundMarginV3Response? result) { result = null; try { result = Ok(); } catch (Exception e) { OnDeserializationErrorDefaultImplementation(e, (HttpStatusCode)200); } return result != null; }

            private void OnDeserializationErrorDefaultImplementation(Exception exception, HttpStatusCode httpStatusCode)
            {
                bool suppressDefaultLog = false;
                OnDeserializationError(ref suppressDefaultLog, exception, httpStatusCode);
                if (!suppressDefaultLog)
                    Logger.LogError(exception, "An error occurred while deserializing the {code} response.", httpStatusCode);
            }

            partial void OnDeserializationError(ref bool suppressDefaultLog, Exception exception, HttpStatusCode httpStatusCode);
        }

        // ── GetUserIps ─────────────────────────────────────────────────────────

        private void AfterGetUserIpsDefaultImplementation(IGetUserIpsApiResponse apiResponseLocalVar)
        {
            bool suppressDefaultLog = false;
            AfterGetUserIps(ref suppressDefaultLog, apiResponseLocalVar);
            if (!suppressDefaultLog)
                Logger.LogInformation("{0,-9} | {1} | {2}", (apiResponseLocalVar.DownloadedAt - apiResponseLocalVar.RequestedAt).TotalSeconds, apiResponseLocalVar.StatusCode, apiResponseLocalVar.Path);
        }

        partial void AfterGetUserIps(ref bool suppressDefaultLog, IGetUserIpsApiResponse apiResponseLocalVar);

        private void OnErrorGetUserIpsDefaultImplementation(Exception exceptionLocalVar, string pathFormatLocalVar, string pathLocalVar)
        {
            bool suppressDefaultLogLocalVar = false;
            OnErrorGetUserIps(ref suppressDefaultLogLocalVar, exceptionLocalVar, pathFormatLocalVar, pathLocalVar);
            if (!suppressDefaultLogLocalVar)
                Logger.LogError(exceptionLocalVar, "An error occurred while sending the request to the server.");
        }

        partial void OnErrorGetUserIps(ref bool suppressDefaultLogLocalVar, Exception exceptionLocalVar, string pathFormatLocalVar, string pathLocalVar);

        public async Task<IGetUserIpsApiResponse?> GetUserIpsOrDefaultAsync(System.Threading.CancellationToken cancellationToken = default)
        {
            try { return await GetUserIpsAsync(cancellationToken).ConfigureAwait(false); }
            catch (Exception) { return null; }
        }

        public async Task<IGetUserIpsApiResponse> GetUserIpsAsync(System.Threading.CancellationToken cancellationToken = default)
        {
            UriBuilder uriBuilderLocalVar = new UriBuilder();

            try
            {
                using (HttpRequestMessage httpRequestMessageLocalVar = new HttpRequestMessage())
                {
                    uriBuilderLocalVar.Host = HttpClient.BaseAddress!.Host;
                    uriBuilderLocalVar.Port = HttpClient.BaseAddress.Port;
                    uriBuilderLocalVar.Scheme = HttpClient.BaseAddress.Scheme;
                    uriBuilderLocalVar.Path = HttpClient.BaseAddress.AbsolutePath == "/"
                        ? "/v2/user/ip"
                        : string.Concat(HttpClient.BaseAddress.AbsolutePath.TrimEnd('/'), "/v2/user/ip");

                    List<TokenBase> tokenBaseLocalVars = new List<TokenBase>();
                    httpRequestMessageLocalVar.RequestUri = uriBuilderLocalVar.Uri;

                    OAuthToken oauthTokenLocalVar1 = (OAuthToken) await OauthTokenProvider.GetAsync(cancellation: cancellationToken).ConfigureAwait(false);
                    tokenBaseLocalVars.Add(oauthTokenLocalVar1);
                    oauthTokenLocalVar1.UseInHeader(httpRequestMessageLocalVar, "");

                    string[] acceptLocalVars = new string[] { "*/*" };
                    IEnumerable<MediaTypeWithQualityHeaderValue> acceptHeaderValuesLocalVar = ClientUtils.SelectHeaderAcceptArray(acceptLocalVars);
                    foreach (var acceptLocalVar in acceptHeaderValuesLocalVar)
                        httpRequestMessageLocalVar.Headers.Accept.Add(acceptLocalVar);

                    httpRequestMessageLocalVar.Method = HttpMethod.Get;
                    DateTime requestedAtLocalVar = DateTime.UtcNow;

                    using (HttpResponseMessage httpResponseMessageLocalVar = await HttpClient.SendAsync(httpRequestMessageLocalVar, cancellationToken).ConfigureAwait(false))
                    {
                        ILogger<GetUserIpsApiResponse> apiResponseLoggerLocalVar = LoggerFactory.CreateLogger<GetUserIpsApiResponse>();
                        GetUserIpsApiResponse apiResponseLocalVar;

                        switch ((int)httpResponseMessageLocalVar.StatusCode) {
                            default: {
                                string responseContentLocalVar = await httpResponseMessageLocalVar.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                                apiResponseLocalVar = new(apiResponseLoggerLocalVar, httpRequestMessageLocalVar, httpResponseMessageLocalVar, responseContentLocalVar, "/v2/user/ip", requestedAtLocalVar, _jsonSerializerOptions);
                                break;
                            }
                        }

                        AfterGetUserIpsDefaultImplementation(apiResponseLocalVar);

                        if (apiResponseLocalVar.StatusCode == (HttpStatusCode) 429)
                            foreach(TokenBase tokenBaseLocalVar in tokenBaseLocalVars)
                                tokenBaseLocalVar.BeginRateLimit();

                        return apiResponseLocalVar;
                    }
                }
            }
            catch(Exception e)
            {
                OnErrorGetUserIpsDefaultImplementation(e, "/v2/user/ip", uriBuilderLocalVar.Path);
                throw;
            }
        }

        public partial class GetUserIpsApiResponse : UpstoxClient.Client.ApiResponse, IGetUserIpsApiResponse
        {
            public ILogger<GetUserIpsApiResponse> Logger { get; }

            public GetUserIpsApiResponse(ILogger<GetUserIpsApiResponse> logger, System.Net.Http.HttpRequestMessage httpRequestMessage, System.Net.Http.HttpResponseMessage httpResponseMessage, string rawContent, string path, DateTime requestedAt, System.Text.Json.JsonSerializerOptions jsonSerializerOptions) : base(httpRequestMessage, httpResponseMessage, rawContent, path, requestedAt, jsonSerializerOptions)
            {
                Logger = logger;
                OnCreated(httpRequestMessage, httpResponseMessage);
            }

            public GetUserIpsApiResponse(ILogger<GetUserIpsApiResponse> logger, System.Net.Http.HttpRequestMessage httpRequestMessage, System.Net.Http.HttpResponseMessage httpResponseMessage, System.IO.Stream contentStream, string path, DateTime requestedAt, System.Text.Json.JsonSerializerOptions jsonSerializerOptions) : base(httpRequestMessage, httpResponseMessage, contentStream, path, requestedAt, jsonSerializerOptions)
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
            public UpstoxClient.Model.UserIpResponse? Ok() => IsOk ? System.Text.Json.JsonSerializer.Deserialize<UpstoxClient.Model.UserIpResponse>(RawContent, _jsonSerializerOptions) : null;
            public bool TryOk([NotNullWhen(true)]out UpstoxClient.Model.UserIpResponse? result) { result = null; try { result = Ok(); } catch (Exception e) { OnDeserializationErrorDefaultImplementation(e, (HttpStatusCode)200); } return result != null; }

            private void OnDeserializationErrorDefaultImplementation(Exception exception, HttpStatusCode httpStatusCode)
            {
                bool suppressDefaultLog = false;
                OnDeserializationError(ref suppressDefaultLog, exception, httpStatusCode);
                if (!suppressDefaultLog)
                    Logger.LogError(exception, "An error occurred while deserializing the {code} response.", httpStatusCode);
            }

            partial void OnDeserializationError(ref bool suppressDefaultLog, Exception exception, HttpStatusCode httpStatusCode);
        }

        // ── UpdateKillSwitch ───────────────────────────────────────────────────

        partial void FormatUpdateKillSwitch(List<KillSwitchSegmentUpdateRequest> killSwitchSegmentUpdateRequest);

        private void ValidateUpdateKillSwitch(List<KillSwitchSegmentUpdateRequest> killSwitchSegmentUpdateRequest)
        {
            if (killSwitchSegmentUpdateRequest == null)
                throw new ArgumentNullException(nameof(killSwitchSegmentUpdateRequest));
        }

        private void AfterUpdateKillSwitchDefaultImplementation(IUpdateKillSwitchApiResponse apiResponseLocalVar, List<KillSwitchSegmentUpdateRequest> killSwitchSegmentUpdateRequest)
        {
            bool suppressDefaultLog = false;
            AfterUpdateKillSwitch(ref suppressDefaultLog, apiResponseLocalVar, killSwitchSegmentUpdateRequest);
            if (!suppressDefaultLog)
                Logger.LogInformation("{0,-9} | {1} | {2}", (apiResponseLocalVar.DownloadedAt - apiResponseLocalVar.RequestedAt).TotalSeconds, apiResponseLocalVar.StatusCode, apiResponseLocalVar.Path);
        }

        partial void AfterUpdateKillSwitch(ref bool suppressDefaultLog, IUpdateKillSwitchApiResponse apiResponseLocalVar, List<KillSwitchSegmentUpdateRequest> killSwitchSegmentUpdateRequest);

        private void OnErrorUpdateKillSwitchDefaultImplementation(Exception exceptionLocalVar, string pathFormatLocalVar, string pathLocalVar, List<KillSwitchSegmentUpdateRequest> killSwitchSegmentUpdateRequest)
        {
            bool suppressDefaultLogLocalVar = false;
            OnErrorUpdateKillSwitch(ref suppressDefaultLogLocalVar, exceptionLocalVar, pathFormatLocalVar, pathLocalVar, killSwitchSegmentUpdateRequest);
            if (!suppressDefaultLogLocalVar)
                Logger.LogError(exceptionLocalVar, "An error occurred while sending the request to the server.");
        }

        partial void OnErrorUpdateKillSwitch(ref bool suppressDefaultLogLocalVar, Exception exceptionLocalVar, string pathFormatLocalVar, string pathLocalVar, List<KillSwitchSegmentUpdateRequest> killSwitchSegmentUpdateRequest);

        public async Task<IUpdateKillSwitchApiResponse?> UpdateKillSwitchOrDefaultAsync(List<KillSwitchSegmentUpdateRequest> killSwitchSegmentUpdateRequest, System.Threading.CancellationToken cancellationToken = default)
        {
            try { return await UpdateKillSwitchAsync(killSwitchSegmentUpdateRequest, cancellationToken).ConfigureAwait(false); }
            catch (Exception) { return null; }
        }

        public async Task<IUpdateKillSwitchApiResponse> UpdateKillSwitchAsync(List<KillSwitchSegmentUpdateRequest> killSwitchSegmentUpdateRequest, System.Threading.CancellationToken cancellationToken = default)
        {
            UriBuilder uriBuilderLocalVar = new UriBuilder();

            try
            {
                ValidateUpdateKillSwitch(killSwitchSegmentUpdateRequest);
                FormatUpdateKillSwitch(killSwitchSegmentUpdateRequest);

                using (HttpRequestMessage httpRequestMessageLocalVar = new HttpRequestMessage())
                {
                    uriBuilderLocalVar.Host = HttpClient.BaseAddress!.Host;
                    uriBuilderLocalVar.Port = HttpClient.BaseAddress.Port;
                    uriBuilderLocalVar.Scheme = HttpClient.BaseAddress.Scheme;
                    uriBuilderLocalVar.Path = HttpClient.BaseAddress.AbsolutePath == "/"
                        ? "/v2/user/kill-switch"
                        : string.Concat(HttpClient.BaseAddress.AbsolutePath.TrimEnd('/'), "/v2/user/kill-switch");

                    httpRequestMessageLocalVar.Content = (killSwitchSegmentUpdateRequest as object) is System.IO.Stream stream
                        ? httpRequestMessageLocalVar.Content = new StreamContent(stream)
                        : httpRequestMessageLocalVar.Content = new StringContent(JsonSerializer.Serialize(killSwitchSegmentUpdateRequest, _jsonSerializerOptions));

                    List<TokenBase> tokenBaseLocalVars = new List<TokenBase>();
                    httpRequestMessageLocalVar.RequestUri = uriBuilderLocalVar.Uri;

                    OAuthToken oauthTokenLocalVar1 = (OAuthToken) await OauthTokenProvider.GetAsync(cancellation: cancellationToken).ConfigureAwait(false);
                    tokenBaseLocalVars.Add(oauthTokenLocalVar1);
                    oauthTokenLocalVar1.UseInHeader(httpRequestMessageLocalVar, "");

                    string[] contentTypes = new string[] { "application/json" };
                    string? contentTypeLocalVar = ClientUtils.SelectHeaderContentType(contentTypes);
                    if (contentTypeLocalVar != null && httpRequestMessageLocalVar.Content != null)
                        httpRequestMessageLocalVar.Content.Headers.ContentType = new MediaTypeHeaderValue(contentTypeLocalVar);

                    string[] acceptLocalVars = new string[] { "*/*", "application/json" };
                    IEnumerable<MediaTypeWithQualityHeaderValue> acceptHeaderValuesLocalVar = ClientUtils.SelectHeaderAcceptArray(acceptLocalVars);
                    foreach (var acceptLocalVar in acceptHeaderValuesLocalVar)
                        httpRequestMessageLocalVar.Headers.Accept.Add(acceptLocalVar);

                    httpRequestMessageLocalVar.Method = HttpMethod.Post;
                    DateTime requestedAtLocalVar = DateTime.UtcNow;

                    using (HttpResponseMessage httpResponseMessageLocalVar = await HttpClient.SendAsync(httpRequestMessageLocalVar, cancellationToken).ConfigureAwait(false))
                    {
                        ILogger<UpdateKillSwitchApiResponse> apiResponseLoggerLocalVar = LoggerFactory.CreateLogger<UpdateKillSwitchApiResponse>();
                        UpdateKillSwitchApiResponse apiResponseLocalVar;

                        switch ((int)httpResponseMessageLocalVar.StatusCode) {
                            default: {
                                string responseContentLocalVar = await httpResponseMessageLocalVar.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                                apiResponseLocalVar = new(apiResponseLoggerLocalVar, httpRequestMessageLocalVar, httpResponseMessageLocalVar, responseContentLocalVar, "/v2/user/kill-switch", requestedAtLocalVar, _jsonSerializerOptions);
                                break;
                            }
                        }

                        AfterUpdateKillSwitchDefaultImplementation(apiResponseLocalVar, killSwitchSegmentUpdateRequest);

                        if (apiResponseLocalVar.StatusCode == (HttpStatusCode) 429)
                            foreach(TokenBase tokenBaseLocalVar in tokenBaseLocalVars)
                                tokenBaseLocalVar.BeginRateLimit();

                        return apiResponseLocalVar;
                    }
                }
            }
            catch(Exception e)
            {
                OnErrorUpdateKillSwitchDefaultImplementation(e, "/v2/user/kill-switch", uriBuilderLocalVar.Path, killSwitchSegmentUpdateRequest);
                throw;
            }
        }

        public partial class UpdateKillSwitchApiResponse : UpstoxClient.Client.ApiResponse, IUpdateKillSwitchApiResponse
        {
            public ILogger<UpdateKillSwitchApiResponse> Logger { get; }

            public UpdateKillSwitchApiResponse(ILogger<UpdateKillSwitchApiResponse> logger, System.Net.Http.HttpRequestMessage httpRequestMessage, System.Net.Http.HttpResponseMessage httpResponseMessage, string rawContent, string path, DateTime requestedAt, System.Text.Json.JsonSerializerOptions jsonSerializerOptions) : base(httpRequestMessage, httpResponseMessage, rawContent, path, requestedAt, jsonSerializerOptions)
            {
                Logger = logger;
                OnCreated(httpRequestMessage, httpResponseMessage);
            }

            public UpdateKillSwitchApiResponse(ILogger<UpdateKillSwitchApiResponse> logger, System.Net.Http.HttpRequestMessage httpRequestMessage, System.Net.Http.HttpResponseMessage httpResponseMessage, System.IO.Stream contentStream, string path, DateTime requestedAt, System.Text.Json.JsonSerializerOptions jsonSerializerOptions) : base(httpRequestMessage, httpResponseMessage, contentStream, path, requestedAt, jsonSerializerOptions)
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
            public UpstoxClient.Model.KillSwitchResponse? Ok() => IsOk ? System.Text.Json.JsonSerializer.Deserialize<UpstoxClient.Model.KillSwitchResponse>(RawContent, _jsonSerializerOptions) : null;
            public bool TryOk([NotNullWhen(true)]out UpstoxClient.Model.KillSwitchResponse? result) { result = null; try { result = Ok(); } catch (Exception e) { OnDeserializationErrorDefaultImplementation(e, (HttpStatusCode)200); } return result != null; }

            private void OnDeserializationErrorDefaultImplementation(Exception exception, HttpStatusCode httpStatusCode)
            {
                bool suppressDefaultLog = false;
                OnDeserializationError(ref suppressDefaultLog, exception, httpStatusCode);
                if (!suppressDefaultLog)
                    Logger.LogError(exception, "An error occurred while deserializing the {code} response.", httpStatusCode);
            }

            partial void OnDeserializationError(ref bool suppressDefaultLog, Exception exception, HttpStatusCode httpStatusCode);
        }

        // ── UpdateUserIp ───────────────────────────────────────────────────────

        partial void FormatUpdateUserIp(UpdateUserIpRequest updateUserIpRequest);

        private void ValidateUpdateUserIp(UpdateUserIpRequest updateUserIpRequest)
        {
            if (updateUserIpRequest == null)
                throw new ArgumentNullException(nameof(updateUserIpRequest));
        }

        private void AfterUpdateUserIpDefaultImplementation(IUpdateUserIpApiResponse apiResponseLocalVar, UpdateUserIpRequest updateUserIpRequest)
        {
            bool suppressDefaultLog = false;
            AfterUpdateUserIp(ref suppressDefaultLog, apiResponseLocalVar, updateUserIpRequest);
            if (!suppressDefaultLog)
                Logger.LogInformation("{0,-9} | {1} | {2}", (apiResponseLocalVar.DownloadedAt - apiResponseLocalVar.RequestedAt).TotalSeconds, apiResponseLocalVar.StatusCode, apiResponseLocalVar.Path);
        }

        partial void AfterUpdateUserIp(ref bool suppressDefaultLog, IUpdateUserIpApiResponse apiResponseLocalVar, UpdateUserIpRequest updateUserIpRequest);

        private void OnErrorUpdateUserIpDefaultImplementation(Exception exceptionLocalVar, string pathFormatLocalVar, string pathLocalVar, UpdateUserIpRequest updateUserIpRequest)
        {
            bool suppressDefaultLogLocalVar = false;
            OnErrorUpdateUserIp(ref suppressDefaultLogLocalVar, exceptionLocalVar, pathFormatLocalVar, pathLocalVar, updateUserIpRequest);
            if (!suppressDefaultLogLocalVar)
                Logger.LogError(exceptionLocalVar, "An error occurred while sending the request to the server.");
        }

        partial void OnErrorUpdateUserIp(ref bool suppressDefaultLogLocalVar, Exception exceptionLocalVar, string pathFormatLocalVar, string pathLocalVar, UpdateUserIpRequest updateUserIpRequest);

        public async Task<IUpdateUserIpApiResponse?> UpdateUserIpOrDefaultAsync(UpdateUserIpRequest updateUserIpRequest, System.Threading.CancellationToken cancellationToken = default)
        {
            try { return await UpdateUserIpAsync(updateUserIpRequest, cancellationToken).ConfigureAwait(false); }
            catch (Exception) { return null; }
        }

        public async Task<IUpdateUserIpApiResponse> UpdateUserIpAsync(UpdateUserIpRequest updateUserIpRequest, System.Threading.CancellationToken cancellationToken = default)
        {
            UriBuilder uriBuilderLocalVar = new UriBuilder();

            try
            {
                ValidateUpdateUserIp(updateUserIpRequest);
                FormatUpdateUserIp(updateUserIpRequest);

                using (HttpRequestMessage httpRequestMessageLocalVar = new HttpRequestMessage())
                {
                    uriBuilderLocalVar.Host = HttpClient.BaseAddress!.Host;
                    uriBuilderLocalVar.Port = HttpClient.BaseAddress.Port;
                    uriBuilderLocalVar.Scheme = HttpClient.BaseAddress.Scheme;
                    uriBuilderLocalVar.Path = HttpClient.BaseAddress.AbsolutePath == "/"
                        ? "/v2/user/ip"
                        : string.Concat(HttpClient.BaseAddress.AbsolutePath.TrimEnd('/'), "/v2/user/ip");

                    httpRequestMessageLocalVar.Content = (updateUserIpRequest as object) is System.IO.Stream stream
                        ? httpRequestMessageLocalVar.Content = new StreamContent(stream)
                        : httpRequestMessageLocalVar.Content = new StringContent(JsonSerializer.Serialize(updateUserIpRequest, _jsonSerializerOptions));

                    List<TokenBase> tokenBaseLocalVars = new List<TokenBase>();
                    httpRequestMessageLocalVar.RequestUri = uriBuilderLocalVar.Uri;

                    OAuthToken oauthTokenLocalVar1 = (OAuthToken) await OauthTokenProvider.GetAsync(cancellation: cancellationToken).ConfigureAwait(false);
                    tokenBaseLocalVars.Add(oauthTokenLocalVar1);
                    oauthTokenLocalVar1.UseInHeader(httpRequestMessageLocalVar, "");

                    string[] contentTypes = new string[] { "application/json" };
                    string? contentTypeLocalVar = ClientUtils.SelectHeaderContentType(contentTypes);
                    if (contentTypeLocalVar != null && httpRequestMessageLocalVar.Content != null)
                        httpRequestMessageLocalVar.Content.Headers.ContentType = new MediaTypeHeaderValue(contentTypeLocalVar);

                    string[] acceptLocalVars = new string[] { "*/*" };
                    IEnumerable<MediaTypeWithQualityHeaderValue> acceptHeaderValuesLocalVar = ClientUtils.SelectHeaderAcceptArray(acceptLocalVars);
                    foreach (var acceptLocalVar in acceptHeaderValuesLocalVar)
                        httpRequestMessageLocalVar.Headers.Accept.Add(acceptLocalVar);

                    httpRequestMessageLocalVar.Method = HttpMethod.Put;
                    DateTime requestedAtLocalVar = DateTime.UtcNow;

                    using (HttpResponseMessage httpResponseMessageLocalVar = await HttpClient.SendAsync(httpRequestMessageLocalVar, cancellationToken).ConfigureAwait(false))
                    {
                        ILogger<UpdateUserIpApiResponse> apiResponseLoggerLocalVar = LoggerFactory.CreateLogger<UpdateUserIpApiResponse>();
                        UpdateUserIpApiResponse apiResponseLocalVar;

                        switch ((int)httpResponseMessageLocalVar.StatusCode) {
                            default: {
                                string responseContentLocalVar = await httpResponseMessageLocalVar.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                                apiResponseLocalVar = new(apiResponseLoggerLocalVar, httpRequestMessageLocalVar, httpResponseMessageLocalVar, responseContentLocalVar, "/v2/user/ip", requestedAtLocalVar, _jsonSerializerOptions);
                                break;
                            }
                        }

                        AfterUpdateUserIpDefaultImplementation(apiResponseLocalVar, updateUserIpRequest);

                        if (apiResponseLocalVar.StatusCode == (HttpStatusCode) 429)
                            foreach(TokenBase tokenBaseLocalVar in tokenBaseLocalVars)
                                tokenBaseLocalVar.BeginRateLimit();

                        return apiResponseLocalVar;
                    }
                }
            }
            catch(Exception e)
            {
                OnErrorUpdateUserIpDefaultImplementation(e, "/v2/user/ip", uriBuilderLocalVar.Path, updateUserIpRequest);
                throw;
            }
        }

        public partial class UpdateUserIpApiResponse : UpstoxClient.Client.ApiResponse, IUpdateUserIpApiResponse
        {
            public ILogger<UpdateUserIpApiResponse> Logger { get; }

            public UpdateUserIpApiResponse(ILogger<UpdateUserIpApiResponse> logger, System.Net.Http.HttpRequestMessage httpRequestMessage, System.Net.Http.HttpResponseMessage httpResponseMessage, string rawContent, string path, DateTime requestedAt, System.Text.Json.JsonSerializerOptions jsonSerializerOptions) : base(httpRequestMessage, httpResponseMessage, rawContent, path, requestedAt, jsonSerializerOptions)
            {
                Logger = logger;
                OnCreated(httpRequestMessage, httpResponseMessage);
            }

            public UpdateUserIpApiResponse(ILogger<UpdateUserIpApiResponse> logger, System.Net.Http.HttpRequestMessage httpRequestMessage, System.Net.Http.HttpResponseMessage httpResponseMessage, System.IO.Stream contentStream, string path, DateTime requestedAt, System.Text.Json.JsonSerializerOptions jsonSerializerOptions) : base(httpRequestMessage, httpResponseMessage, contentStream, path, requestedAt, jsonSerializerOptions)
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
            public UpstoxClient.Model.UserIpResponse? Ok() => IsOk ? System.Text.Json.JsonSerializer.Deserialize<UpstoxClient.Model.UserIpResponse>(RawContent, _jsonSerializerOptions) : null;
            public bool TryOk([NotNullWhen(true)]out UpstoxClient.Model.UserIpResponse? result) { result = null; try { result = Ok(); } catch (Exception e) { OnDeserializationErrorDefaultImplementation(e, (HttpStatusCode)200); } return result != null; }

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
