using Microsoft.Extensions.Logging;
using RestSharp;
using SER.EpaycoSdk.NewApi.Models.Response;
using SER.EpaycoSdk.Utils;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SER.EpaycoSdk.NewApi
{
    public class Consume
    {
        #region Atributes
        private const string _baseUrl = "https://apify.epayco.co/";
        private readonly ILogger _logger;
        private readonly RestClient _client;
        private string _auth = string.Empty;
        private string _accessToken = string.Empty;

        public string AccessToken { get => _accessToken; set => _accessToken = value; }
        #endregion

        public Consume(ILogger logger, string auth)
        {
            _auth = auth;
            _client = new RestClient(_baseUrl);
            _logger = logger;
        }

        public RestRequest MakeGetRequest(string endPoint = "", dynamic model = null)
        {
            var request = new RestRequest(endPoint, Method.GET)
            {
                RequestFormat = DataFormat.Json
            };

            if (model != null)
            {
                var jsonString = JsonSerializer.Serialize(model);
                var documentOptions = new JsonDocumentOptions
                {
                    CommentHandling = JsonCommentHandling.Skip
                };
                var document = JsonDocument.Parse(jsonString, documentOptions);

                foreach (JsonProperty property in document.RootElement.EnumerateObject())
                {
                    request.AddParameter(property.Name, property.Value, ParameterType.QueryString);
                }
            }
            return request;
        }

        public RestRequest MakePostRequest(string endPoint = "", dynamic model = null)
        {
            _logger.LogInformation($"------------------ ENDPOINT: {endPoint}");
            var request = new RestRequest(endPoint, Method.POST)
            {
                RequestFormat = DataFormat.Json
            };

            if (model != null)
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                };
                options.Converters.Add(new DecimalFormatConverter());

                string jsonString = JsonSerializer.Serialize(model, options);
                _logger.LogInformation($"Request:\n{jsonString}");
                request.AddJsonBody(jsonString);
            }

            return request;
        }

        public async Task<T> ExecuteAsync<T>(RestRequest request, bool isLogin = false) where T : class
        {
            // return null;

            if (!isLogin)
            {
                await VerifyTokenAsync();
                request.AddHeader("authorization", string.Format("Bearer {0}", _accessToken));
            }
            else
            {
                request.AddHeader("authorization", string.Format("Basic {0}", _auth));
            }
           
            var response = await _client.ExecuteAsync(request);
            try
            {
                //if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                //{
                //    await GetAccessToken();
                //    return await ExecuteAsync<T>(request);
                //}
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    _logger.LogInformation($"Response: {response.Content}");
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                        WriteIndented = true
                    };
                    options.Converters.Add(new AutoNumberToStringConverter());
                    options.Converters.Add(new DateTimeConverter());
                    return JsonSerializer.Deserialize<T>(response.Content, options);
                }
                return null;
            }
            catch (Exception e)
            {
                _logger.LogError($"Response: {response.Content}");
                _logger.LogError(e.ToString());
                throw;
            }
        }

        private async Task VerifyTokenAsync()
        {
            if (string.IsNullOrEmpty(_accessToken))
            {
                await GetAccessToken();
                return;
            }
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(_accessToken);
            var exp = token.ValidTo;
            if (DateTime.Now.ToEpochTime() > exp.ToEpochTime())
            {
                await GetAccessToken();
            }
        }

        private async Task GetAccessToken()
        {
            var getToken = await ExecuteAsync<Login>(MakePostRequest(endPoint: Constantes.LOGIN_ENDPOINT), isLogin: true);
            _accessToken = string.Empty;
            if (!string.IsNullOrEmpty(getToken.Token))
            {
                _accessToken = getToken.Token;
            }
        }


        public JsonElement ToJsonDocument(string response)
        {
            var documentOptions = new JsonDocumentOptions
            {
                CommentHandling = JsonCommentHandling.Skip
            };
            return JsonDocument.Parse(response, documentOptions).RootElement;
        }


    }
}
