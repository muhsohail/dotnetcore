using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Models;
using Newtonsoft.Json;

namespace ERP.Infrastructure
{
    public class RequestHandler
    {
        public AccessToken AccessToken { get; set; }
        public string ApiBaseUrl { get { return ConfigurationManager.AppSettings["ApiBaseUrl"]; } }
        public RequestHandler(AccessToken token = null)
        {
            if (token != null)
                AccessToken = token;
        }

        public T Get<T>(string url, Dictionary<string, string> requestHeaders = null)
        {
            return SendRequest<T>(HttpMethod.Get, url, requestHeaders ?? new Dictionary<string, string>());
        }

        public T Post<T>(string url, HttpContent content, Dictionary<string, string> requestHeaders = null, bool isAuth = true)
        {
            return SendRequest<T>(HttpMethod.Post, url, requestHeaders ?? new Dictionary<string, string>(), content, isAuth);
        }

        public T SendRequest<T>(HttpMethod method, string url,
            Dictionary<string, string> requestHeaders, HttpContent content = null, bool isAuth = true)
        {
            try
            {
                //                if (!isAuth)
                //                {
                //                    HttpClient client = new HttpClient();
                //                    var values = new Dictionary<string, string>
                //{
                //   { "barcode", "035549974765" },
                //};

                //                }
                //                else
                {
                    using (HttpClient client = new HttpClient())
                    {
                        using (HttpRequestMessage request = new HttpRequestMessage())
                        {

                            request.Method = method;
                            request.RequestUri = new Uri(url);
                            if (isAuth)
                            {
                                if (AccessToken != null)
                                {
                                    request.Headers.Add("Authorization", "Bearer " + AccessToken.Token);
                                }

                            }
                            foreach (var requestHeader in requestHeaders)
                            {
                                request.Headers.Add(requestHeader.Key, requestHeader.Value);
                            }
                            if (content != null)
                                request.Content = content;

                            try
                            {
                                string Requeststr = request.Content.ReadAsStringAsync().Result;

                            }
                            catch (Exception ex)
                            {
                                //Console.WriteLine(ex.ToString());
                            }
                            var response = client.SendAsync(request).Result;
                            var responseString = response.Content.ReadAsStringAsync().Result;

                            if (typeof(T) == typeof(string))
                            {
                                return (T)Convert.ChangeType(responseString, typeof(string));
                            }
                            else
                            {
                                return JsonConvert.DeserializeObject<T>(responseString);

                            }
                        }
                    }

                }


            }
            catch (Exception ex)
            {
                return default(T);
            }
        }

        public AccessToken RefreshAccessToken(AccessToken accessToken)
        {
            var authBase = ApiBaseUrl.Replace("/api", string.Empty) + "account/token";

            var body = new Dictionary<string, string>
            {
                {"grant_type", "refresh_token"},
                {"refresh_token", accessToken.RefreshToken}
            };

            var content = new FormUrlEncodedContent(body);

            using (HttpClient client = new HttpClient())
            {
                var response = client.PostAsync(authBase, content).Result;
                var responseString = response.Content.ReadAsStringAsync().Result;

                var responseObject = JsonConvert.DeserializeObject<dynamic>(responseString);
                if (responseObject.error == null)
                {
                    var token = new AccessToken()
                    {
                        ExpiresIn = DateTime.Now.Add(TimeSpan.FromSeconds(responseObject.expires_in.Value)),
                        Token = responseObject.access_token.Value,
                        RefreshToken = responseObject.refresh_token.Value
                    };
                    return token;
                }
                else
                {
                    return null;
                }
            }
        }

        public AccessToken SendTokenRequest(string userName, string password)
        {
            var authBase = ApiBaseUrl.Replace("/api", string.Empty) + "account/token";

            var body = new Dictionary<string, string>
            {
                {"grant_type", "password"},
                {"userName", userName},
                {"password", password}
            };

            var content = new FormUrlEncodedContent(body);

            using (HttpClient client = new HttpClient())
            {
                var response = client.PostAsync(authBase, content).Result;
                var responseString = response.Content.ReadAsStringAsync().Result;

                var responseObject = JsonConvert.DeserializeObject<dynamic>(responseString);
                if (responseObject.error == null)
                {
                    var token = new AccessToken()
                    {
                        ExpiresIn = DateTime.Now.Add(TimeSpan.FromSeconds(responseObject.expires_in.Value)),
                        Token = responseObject.access_token.Value,
                        RefreshToken = responseObject.refresh_token.Value
                    };
                    return token;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
