using System.Net;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Web;
using KometSales.Common.Exceptions;

namespace KometSales.Common.Utils
{
    public class HttpUtil
    {
        public static async Task<TOutput?> SendAsync<TInput, TOutput>(string authToken, string url, HttpMethod httpMethod, Dictionary<string, string> queryString = null, TInput? body = default(TInput))
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);

                    if (queryString != null && queryString.Count > 0)
                    {
                        var builder = new UriBuilder(url);
                        var query = HttpUtility.ParseQueryString(builder.Query);

                        foreach (var item in queryString)
                        {
                            query[item.Key] = item.Value;
                        }

                        builder.Query = query.ToString();

                        url = builder.ToString();
                    }

                    var request = new HttpRequestMessage
                    {
                        Method = httpMethod,
                        RequestUri = new Uri(url),
                        Content = body != null ? new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json") : null
                    };

                    var response = await httpClient.SendAsync(request);

                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        throw new AppException(response.StatusCode, "Unauthorized");
                    }

                    if (!response.IsSuccessStatusCode)
                    {
                        throw new AppException(response.StatusCode, await response.Content.ReadAsStringAsync());
                    }

                    var responseContent = await response.Content.ReadAsStringAsync();

                    if (typeof(TOutput) == typeof(string))
                    {
                        return (TOutput)(object)responseContent;
                    }

                    return JsonConvert.DeserializeObject<TOutput>(responseContent);
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("An error occurred while making the HTTP request: " + ex.Message, ex);
            }
            catch (JsonException ex)
            {
                throw new Exception("An error occurred while deserializing the response: " + ex.Message, ex);
            }
        }

        public static TOutput? Send<TInput, TOutput>(string authToken, string url, HttpMethod httpMethod, Dictionary<string, string> queryString = null, TInput? body = default(TInput))
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);

                    if (queryString != null && queryString.Count > 0)
                    {
                        var builder = new UriBuilder(url);
                        var query = HttpUtility.ParseQueryString(builder.Query);

                        foreach (var item in queryString)
                        {
                            query[item.Key] = item.Value;
                        }

                        builder.Query = query.ToString();

                        url = builder.ToString();
                    }

                    var request = new HttpRequestMessage
                    {
                        Method = httpMethod,
                        RequestUri = new Uri(url),
                        Content = body != null ? new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json") : null
                    };

                    var response = httpClient.SendAsync(request).Result;

                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        throw new AppException(response.StatusCode, "Unauthorized");
                    }

                    if (!response.IsSuccessStatusCode)
                    {
                        throw new AppException(response.StatusCode, response.Content.ReadAsStringAsync().Result);
                    }

                    var responseContent = response.Content.ReadAsStringAsync().Result;

                    if (typeof(TOutput) == typeof(string))
                    {
                        return (TOutput)(object)responseContent;
                    }

                    return JsonConvert.DeserializeObject<TOutput>(responseContent);
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("An error occurred while making the HTTP request: " + ex.Message, ex);
            }
            catch (JsonException ex)
            {
                throw new Exception("An error occurred while deserializing the response: " + ex.Message, ex);
            }
        }
    }
}
