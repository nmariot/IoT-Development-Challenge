using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using RestSharp;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace IO.Swagger.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IDefaultApi
    {
        #region Synchronous Operations
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Service d&#39;acquisition de messages provenant d&#39;objets connect\u00E9s
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="message">Message transmis par l&#39;objet connect\u00E9. (optional)</param>
        /// <returns></returns>
        void MessagesPost (Message message = null);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Service d&#39;acquisition de messages provenant d&#39;objets connect\u00E9s
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="message">Message transmis par l&#39;objet connect\u00E9. (optional)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> MessagesPostWithHttpInfo (Message message = null);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Service fournissant une synth\u00E8se des donn\u00E9es sur les 60 derni\u00E8res minutes, minute en cours incluse. L&#39;objet \&quot;synthesis\&quot; retourn\u00E9 doit \u00EAtre unique par type de capteur.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>List&lt;Synthesis&gt;</returns>
        List<Synthesis> MessagesSynthesisGet ();

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Service fournissant une synth\u00E8se des donn\u00E9es sur les 60 derni\u00E8res minutes, minute en cours incluse. L&#39;objet \&quot;synthesis\&quot; retourn\u00E9 doit \u00EAtre unique par type de capteur.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of List&lt;Synthesis&gt;</returns>
        ApiResponse<List<Synthesis>> MessagesSynthesisGetWithHttpInfo ();
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Service d&#39;acquisition de messages provenant d&#39;objets connect\u00E9s
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="message">Message transmis par l&#39;objet connect\u00E9. (optional)</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task MessagesPostAsync (Message message = null);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Service d&#39;acquisition de messages provenant d&#39;objets connect\u00E9s
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="message">Message transmis par l&#39;objet connect\u00E9. (optional)</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> MessagesPostAsyncWithHttpInfo (Message message = null);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Service fournissant une synth\u00E8se des donn\u00E9es sur les 60 derni\u00E8res minutes, minute en cours incluse. L&#39;objet \&quot;synthesis\&quot; retourn\u00E9 doit \u00EAtre unique par type de capteur.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of List&lt;Synthesis&gt;</returns>
        System.Threading.Tasks.Task<List<Synthesis>> MessagesSynthesisGetAsync ();

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Service fournissant une synth\u00E8se des donn\u00E9es sur les 60 derni\u00E8res minutes, minute en cours incluse. L&#39;objet \&quot;synthesis\&quot; retourn\u00E9 doit \u00EAtre unique par type de capteur.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (List&lt;Synthesis&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<Synthesis>>> MessagesSynthesisGetAsyncWithHttpInfo ();
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class DefaultApi : IDefaultApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultApi"/> class.
        /// </summary>
        /// <returns></returns>
        public DefaultApi(String basePath)
        {
            this.Configuration = new Configuration(new ApiClient(basePath));

            // ensure API client has configuration ready
            if (Configuration.ApiClient.Configuration == null)
            {
                this.Configuration.ApiClient.Configuration = this.Configuration;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public DefaultApi(Configuration configuration = null)
        {
            if (configuration == null) // use the default one in Configuration
                this.Configuration = Configuration.Default;
            else
                this.Configuration = configuration;

            // ensure API client has configuration ready
            if (Configuration.ApiClient.Configuration == null)
            {
                this.Configuration.ApiClient.Configuration = this.Configuration;
            }
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
        [Obsolete("SetBasePath is deprecated, please do 'Configuraiton.ApiClient = new ApiClient(\"http://new-path\")' instead.")]
        public void SetBasePath(String basePath)
        {
            // do nothing
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public Configuration Configuration {get; set;}

        /// <summary>
        /// Gets the default header.
        /// </summary>
        /// <returns>Dictionary of HTTP header</returns>
        [Obsolete("DefaultHeader is deprecated, please use Configuration.DefaultHeader instead.")]
        public Dictionary<String, String> DefaultHeader()
        {
            return this.Configuration.DefaultHeader;
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
        ///  Service d&#39;acquisition de messages provenant d&#39;objets connect\u00E9s
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="message">Message transmis par l&#39;objet connect\u00E9. (optional)</param>
        /// <returns></returns>
        public void MessagesPost (Message message = null)
        {
             MessagesPostWithHttpInfo(message);
        }

        /// <summary>
        ///  Service d&#39;acquisition de messages provenant d&#39;objets connect\u00E9s
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="message">Message transmis par l&#39;objet connect\u00E9. (optional)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> MessagesPostWithHttpInfo (Message message = null)
        {

            var localVarPath = "/messages";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (message.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(message); // http body (model) parameter
            }
            else
            {
                localVarPostBody = message; // byte array
            }


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling MessagesPost: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling MessagesPost: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        /// <summary>
        ///  Service d&#39;acquisition de messages provenant d&#39;objets connect\u00E9s
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="message">Message transmis par l&#39;objet connect\u00E9. (optional)</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task MessagesPostAsync (Message message = null)
        {
             await MessagesPostAsyncWithHttpInfo(message);

        }

        /// <summary>
        ///  Service d&#39;acquisition de messages provenant d&#39;objets connect\u00E9s
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="message">Message transmis par l&#39;objet connect\u00E9. (optional)</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Object>> MessagesPostAsyncWithHttpInfo (Message message = null)
        {

            var localVarPath = "/messages";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (message.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(message); // http body (model) parameter
            }
            else
            {
                localVarPostBody = message; // byte array
            }


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling MessagesPost: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling MessagesPost: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        /// <summary>
        ///  Service fournissant une synth\u00E8se des donn\u00E9es sur les 60 derni\u00E8res minutes, minute en cours incluse. L&#39;objet \&quot;synthesis\&quot; retourn\u00E9 doit \u00EAtre unique par type de capteur.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>List&lt;Synthesis&gt;</returns>
        public List<Synthesis> MessagesSynthesisGet ()
        {
             ApiResponse<List<Synthesis>> localVarResponse = MessagesSynthesisGetWithHttpInfo();
             return localVarResponse.Data;
        }

        /// <summary>
        ///  Service fournissant une synth\u00E8se des donn\u00E9es sur les 60 derni\u00E8res minutes, minute en cours incluse. L&#39;objet \&quot;synthesis\&quot; retourn\u00E9 doit \u00EAtre unique par type de capteur.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of List&lt;Synthesis&gt;</returns>
        public ApiResponse< List<Synthesis> > MessagesSynthesisGetWithHttpInfo ()
        {

            var localVarPath = "/messages/synthesis";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling MessagesSynthesisGet: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling MessagesSynthesisGet: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<List<Synthesis>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<Synthesis>) Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<Synthesis>)));
            
        }

        /// <summary>
        ///  Service fournissant une synth\u00E8se des donn\u00E9es sur les 60 derni\u00E8res minutes, minute en cours incluse. L&#39;objet \&quot;synthesis\&quot; retourn\u00E9 doit \u00EAtre unique par type de capteur.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of List&lt;Synthesis&gt;</returns>
        public async System.Threading.Tasks.Task<List<Synthesis>> MessagesSynthesisGetAsync ()
        {
             ApiResponse<List<Synthesis>> localVarResponse = await MessagesSynthesisGetAsyncWithHttpInfo();
             return localVarResponse.Data;

        }

        /// <summary>
        ///  Service fournissant une synth\u00E8se des donn\u00E9es sur les 60 derni\u00E8res minutes, minute en cours incluse. L&#39;objet \&quot;synthesis\&quot; retourn\u00E9 doit \u00EAtre unique par type de capteur.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (List&lt;Synthesis&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<Synthesis>>> MessagesSynthesisGetAsyncWithHttpInfo ()
        {

            var localVarPath = "/messages/synthesis";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling MessagesSynthesisGet: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling MessagesSynthesisGet: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<List<Synthesis>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<Synthesis>) Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<Synthesis>)));
            
        }

    }
}
