/* 
 * OpenAPI definition
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: v0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using RestSharp;
using UpstoxClient.Client;
using UpstoxClient.Model;

namespace UpstoxClient.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
        public interface IUserApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Get profile
        /// </summary>
        /// <remarks>
        /// This API allows to fetch the complete information of the user who is logged in including the products, order types and exchanges enabled for the user
        /// </remarks>
        /// <exception cref="UpstoxClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apiVersion">API Version Header</param>
        /// <returns>GetProfileResponse</returns>
        GetProfileResponse GetProfile (string apiVersion);

        /// <summary>
        /// Get profile
        /// </summary>
        /// <remarks>
        /// This API allows to fetch the complete information of the user who is logged in including the products, order types and exchanges enabled for the user
        /// </remarks>
        /// <exception cref="UpstoxClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apiVersion">API Version Header</param>
        /// <returns>ApiResponse of GetProfileResponse</returns>
        ApiResponse<GetProfileResponse> GetProfileWithHttpInfo (string apiVersion);
        /// <summary>
        /// Get User Fund And Margin
        /// </summary>
        /// <remarks>
        /// Shows the balance of the user in equity and commodity market.
        /// </remarks>
        /// <exception cref="UpstoxClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apiVersion">API Version Header</param>
        /// <param name="segment"> (optional)</param>
        /// <returns>GetUserFundMarginResponse</returns>
        GetUserFundMarginResponse GetUserFundMargin (string apiVersion, string segment = null);

        /// <summary>
        /// Get User Fund And Margin
        /// </summary>
        /// <remarks>
        /// Shows the balance of the user in equity and commodity market.
        /// </remarks>
        /// <exception cref="UpstoxClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apiVersion">API Version Header</param>
        /// <param name="segment"> (optional)</param>
        /// <returns>ApiResponse of GetUserFundMarginResponse</returns>
        ApiResponse<GetUserFundMarginResponse> GetUserFundMarginWithHttpInfo (string apiVersion, string segment = null);
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// Get profile
        /// </summary>
        /// <remarks>
        /// This API allows to fetch the complete information of the user who is logged in including the products, order types and exchanges enabled for the user
        /// </remarks>
        /// <exception cref="UpstoxClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apiVersion">API Version Header</param>
        /// <returns>Task of GetProfileResponse</returns>
        System.Threading.Tasks.Task<GetProfileResponse> GetProfileAsync (string apiVersion);

        /// <summary>
        /// Get profile
        /// </summary>
        /// <remarks>
        /// This API allows to fetch the complete information of the user who is logged in including the products, order types and exchanges enabled for the user
        /// </remarks>
        /// <exception cref="UpstoxClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apiVersion">API Version Header</param>
        /// <returns>Task of ApiResponse (GetProfileResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<GetProfileResponse>> GetProfileAsyncWithHttpInfo (string apiVersion);
        /// <summary>
        /// Get User Fund And Margin
        /// </summary>
        /// <remarks>
        /// Shows the balance of the user in equity and commodity market.
        /// </remarks>
        /// <exception cref="UpstoxClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apiVersion">API Version Header</param>
        /// <param name="segment"> (optional)</param>
        /// <returns>Task of GetUserFundMarginResponse</returns>
        System.Threading.Tasks.Task<GetUserFundMarginResponse> GetUserFundMarginAsync (string apiVersion, string segment = null);

        /// <summary>
        /// Get User Fund And Margin
        /// </summary>
        /// <remarks>
        /// Shows the balance of the user in equity and commodity market.
        /// </remarks>
        /// <exception cref="UpstoxClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apiVersion">API Version Header</param>
        /// <param name="segment"> (optional)</param>
        /// <returns>Task of ApiResponse (GetUserFundMarginResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<GetUserFundMarginResponse>> GetUserFundMarginAsyncWithHttpInfo (string apiVersion, string segment = null);
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
        public partial class UserApi : IUserApi
    {
        private UpstoxClient.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserApi"/> class.
        /// </summary>
        /// <returns></returns>
        public UserApi(String basePath)
        {
            this.Configuration = new UpstoxClient.Client.Configuration { BasePath = basePath };

            ExceptionFactory = UpstoxClient.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserApi"/> class
        /// </summary>
        /// <returns></returns>
        public UserApi()
        {
            this.Configuration = UpstoxClient.Client.Configuration.Default;

            ExceptionFactory = UpstoxClient.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public UserApi(UpstoxClient.Client.Configuration configuration = null)
        {
            if (configuration == null) // use the default one in Configuration
                this.Configuration = UpstoxClient.Client.Configuration.Default;
            else
                this.Configuration = configuration;

            ExceptionFactory = UpstoxClient.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public String GetBasePath()
        {
            return this.Configuration.ApiClient.RestClient.BaseUrl.ToString();
        }

        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        [Obsolete("SetBasePath is deprecated, please do 'Configuration.ApiClient = new ApiClient(\"http://new-path\")' instead.")]
        public void SetBasePath(String basePath)
        {
            // do nothing
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public UpstoxClient.Client.Configuration Configuration {get; set;}

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public UpstoxClient.Client.ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        /// <summary>
        /// Gets the default header.
        /// </summary>
        /// <returns>Dictionary of HTTP header</returns>
        [Obsolete("DefaultHeader is deprecated, please use Configuration.DefaultHeader instead.")]
        public IDictionary<String, String> DefaultHeader()
        {
            return new ReadOnlyDictionary<string, string>(this.Configuration.DefaultHeader);
        }

        /// <summary>
        /// Add default header.
        /// </summary>
        /// <param name="key">Header field name.</param>
        /// <param name="value">Header field value.</param>
        /// <returns></returns>
        [Obsolete("AddDefaultHeader is deprecated, please use Configuration.AddDefaultHeader instead.")]
        public void AddDefaultHeader(string key, string value)
        {
            this.Configuration.AddDefaultHeader(key, value);
        }

        /// <summary>
        /// Get profile This API allows to fetch the complete information of the user who is logged in including the products, order types and exchanges enabled for the user
        /// </summary>
        /// <exception cref="UpstoxClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apiVersion">API Version Header</param>
        /// <returns>GetProfileResponse</returns>
        public GetProfileResponse GetProfile (string apiVersion)
        {
             ApiResponse<GetProfileResponse> localVarResponse = GetProfileWithHttpInfo(apiVersion);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get profile This API allows to fetch the complete information of the user who is logged in including the products, order types and exchanges enabled for the user
        /// </summary>
        /// <exception cref="UpstoxClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apiVersion">API Version Header</param>
        /// <returns>ApiResponse of GetProfileResponse</returns>
        public ApiResponse< GetProfileResponse > GetProfileWithHttpInfo (string apiVersion)
        {
            // verify the required parameter 'apiVersion' is set
            if (apiVersion == null)
                throw new ApiException(400, "Missing required parameter 'apiVersion' when calling UserApi->GetProfile");

            var localVarPath = "/user/profile";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "*/*",
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (apiVersion != null) localVarHeaderParams.Add("Api-Version", this.Configuration.ApiClient.ParameterToString(apiVersion)); // header parameter
            // authentication (OAUTH2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["Authorization"] = "Bearer " + this.Configuration.AccessToken;
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetProfile", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<GetProfileResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (GetProfileResponse) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(GetProfileResponse)));
        }

        /// <summary>
        /// Get profile This API allows to fetch the complete information of the user who is logged in including the products, order types and exchanges enabled for the user
        /// </summary>
        /// <exception cref="UpstoxClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apiVersion">API Version Header</param>
        /// <returns>Task of GetProfileResponse</returns>
        public async System.Threading.Tasks.Task<GetProfileResponse> GetProfileAsync (string apiVersion)
        {
             ApiResponse<GetProfileResponse> localVarResponse = await GetProfileAsyncWithHttpInfo(apiVersion);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Get profile This API allows to fetch the complete information of the user who is logged in including the products, order types and exchanges enabled for the user
        /// </summary>
        /// <exception cref="UpstoxClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apiVersion">API Version Header</param>
        /// <returns>Task of ApiResponse (GetProfileResponse)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<GetProfileResponse>> GetProfileAsyncWithHttpInfo (string apiVersion)
        {
            // verify the required parameter 'apiVersion' is set
            if (apiVersion == null)
                throw new ApiException(400, "Missing required parameter 'apiVersion' when calling UserApi->GetProfile");

            var localVarPath = "/user/profile";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "*/*",
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (apiVersion != null) localVarHeaderParams.Add("Api-Version", this.Configuration.ApiClient.ParameterToString(apiVersion)); // header parameter
            // authentication (OAUTH2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["Authorization"] = "Bearer " + this.Configuration.AccessToken;
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetProfile", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<GetProfileResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (GetProfileResponse) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(GetProfileResponse)));
        }

        /// <summary>
        /// Get User Fund And Margin Shows the balance of the user in equity and commodity market.
        /// </summary>
        /// <exception cref="UpstoxClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apiVersion">API Version Header</param>
        /// <param name="segment"> (optional)</param>
        /// <returns>GetUserFundMarginResponse</returns>
        public GetUserFundMarginResponse GetUserFundMargin (string apiVersion, string segment = null)
        {
             ApiResponse<GetUserFundMarginResponse> localVarResponse = GetUserFundMarginWithHttpInfo(apiVersion, segment);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get User Fund And Margin Shows the balance of the user in equity and commodity market.
        /// </summary>
        /// <exception cref="UpstoxClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apiVersion">API Version Header</param>
        /// <param name="segment"> (optional)</param>
        /// <returns>ApiResponse of GetUserFundMarginResponse</returns>
        public ApiResponse< GetUserFundMarginResponse > GetUserFundMarginWithHttpInfo (string apiVersion, string segment = null)
        {
            // verify the required parameter 'apiVersion' is set
            if (apiVersion == null)
                throw new ApiException(400, "Missing required parameter 'apiVersion' when calling UserApi->GetUserFundMargin");

            var localVarPath = "/user/get-funds-and-margin";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json",
                "*/*"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (segment != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "segment", segment)); // query parameter
            if (apiVersion != null) localVarHeaderParams.Add("Api-Version", this.Configuration.ApiClient.ParameterToString(apiVersion)); // header parameter
            // authentication (OAUTH2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["Authorization"] = "Bearer " + this.Configuration.AccessToken;
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetUserFundMargin", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<GetUserFundMarginResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (GetUserFundMarginResponse) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(GetUserFundMarginResponse)));
        }

        /// <summary>
        /// Get User Fund And Margin Shows the balance of the user in equity and commodity market.
        /// </summary>
        /// <exception cref="UpstoxClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apiVersion">API Version Header</param>
        /// <param name="segment"> (optional)</param>
        /// <returns>Task of GetUserFundMarginResponse</returns>
        public async System.Threading.Tasks.Task<GetUserFundMarginResponse> GetUserFundMarginAsync (string apiVersion, string segment = null)
        {
             ApiResponse<GetUserFundMarginResponse> localVarResponse = await GetUserFundMarginAsyncWithHttpInfo(apiVersion, segment);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Get User Fund And Margin Shows the balance of the user in equity and commodity market.
        /// </summary>
        /// <exception cref="UpstoxClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apiVersion">API Version Header</param>
        /// <param name="segment"> (optional)</param>
        /// <returns>Task of ApiResponse (GetUserFundMarginResponse)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<GetUserFundMarginResponse>> GetUserFundMarginAsyncWithHttpInfo (string apiVersion, string segment = null)
        {
            // verify the required parameter 'apiVersion' is set
            if (apiVersion == null)
                throw new ApiException(400, "Missing required parameter 'apiVersion' when calling UserApi->GetUserFundMargin");

            var localVarPath = "/user/get-funds-and-margin";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json",
                "*/*"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (segment != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "segment", segment)); // query parameter
            if (apiVersion != null) localVarHeaderParams.Add("Api-Version", this.Configuration.ApiClient.ParameterToString(apiVersion)); // header parameter
            // authentication (OAUTH2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["Authorization"] = "Bearer " + this.Configuration.AccessToken;
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetUserFundMargin", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<GetUserFundMarginResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (GetUserFundMarginResponse) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(GetUserFundMarginResponse)));
        }

    }
}
