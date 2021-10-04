using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.WebPages;

namespace Tupa_Web.Common.Models
{
    public static class HttpRequestUrl
    {
        public static readonly string baseUrlTupa = WebConfigurationManager.AppSettings["base_url_server"];

        /// <summary>
        /// Define o endereço padrão.
        /// </summary>
        /// <param name="baseadress"></param>
        /// <returns></returns>
        public static string SetBaseAdress(this string url, string baseadress)
        {
            return baseadress;
        }

        /// <summary>
        /// Adiciona pastas a url
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string AddPath(this string url, string path)
        {
            return url + path;
        }

        /// <summary>
        /// Define as queries da url.
        /// </summary>
        /// <param name="baseadress"></param>
        /// <returns></returns>
        public static string SetQueryParams(this string url, Object queryParams)
        {
            url += "?";

            Type typeQueryParams = queryParams.GetType();
            PropertyInfo[] propsQueryParams = typeQueryParams.GetProperties();

            List<String> param = new List<String>();

            foreach (PropertyInfo propQueryParam in propsQueryParams)
            {
                if (propQueryParam.CanRead)
                {
                    param.Add(propQueryParam.GetValue(queryParams).ToString());

                    url += $"{ propQueryParam.Name }={ propQueryParam.GetValue(queryParams) }&";
                }
            }

            return url;
        }

        private static readonly HttpClient client = new HttpClient();

        public static async Task<T> ProcessHttpClientGet<T>(
            string url,
            JsonSerializerOptions options = null,
            string mediaType = "application/json",
            string bearerToken = "")
        {
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue(mediaType));

            if (!bearerToken.IsEmpty())
                client.DefaultRequestHeaders.Add(
                    "Authorization", String.Format("Bearer {0}", bearerToken));

            var streamTask = client.GetStreamAsync(url);
            var objectResult = await JsonSerializer.DeserializeAsync<T>(await streamTask);

            return objectResult;
        }

        public static async Task<String> ProcessHttpClientGet(
            string url,
            string mediaType = "application/json",
            string bearerToken = "")
        {
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue(mediaType));

            if (!bearerToken.IsEmpty())
                client.DefaultRequestHeaders.Add(
                    "Authorization", String.Format("Bearer {0}", bearerToken));

            var streamTask = await client.GetStringAsync(url);

            return streamTask;
        }

        public static async Task<String> ProcessHttpClientPut(
            string url,
            string mediaType = "application/json",
            string bearerToken = "")
        {
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue(mediaType));

            if (!bearerToken.IsEmpty())
                client.DefaultRequestHeaders.Add(
                    "Authorization", String.Format("Bearer {0}", bearerToken));

            var content = new StringContent("", Encoding.UTF8, "application/json");
            var response = await client.PutAsync(url, content);


            var streamTask = await response.Content.ReadAsStringAsync();

            return streamTask;
        }

        public static async Task<string> ProcessHttpClientPost(
            string url,
            JsonSerializerOptions options = null,
            string mediaType = "application/json",
            string bearerToken = "",
            HttpResponse responsePage = null)
        {
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Clear();

            if (!bearerToken.IsEmpty())
                client.DefaultRequestHeaders.Add(
                    "Authorization", String.Format("Bearer {0}", bearerToken));

            var content = new StringContent("", Encoding.UTF8, "text/json");

            var responseTask = Task.Run(() => client.PostAsync(url, content));
            responseTask.Wait();

            var response = responseTask.GetAwaiter().GetResult();

            fixCookies(response, responsePage);

            var streamTask = await response.Content.ReadAsStringAsync();

            return streamTask;
        }

        private static void fixCookies(HttpResponseMessage response, HttpResponse responsePage)
        {
            var headers = response.Headers.ToList();

            foreach (var header in headers)
            {
                if (header.Key == "Set-Cookie")
                {
                    Match match = Regex.Match(header.Value.FirstOrDefault(), "(.+?)=(.+?);");
                    if (match.Captures.Count > 0)
                    {
                        if (match.Groups[1].Value == "RefreshToken")
                        {
                            HttpCookie cookie = responsePage.Cookies.Get(match.Groups[1].Value);

                            if (cookie != null)
                            {
                                cookie = new HttpCookie(match.Groups[1].Value);
                                cookie.Value = HttpUtility.UrlDecode(match.Groups[2].Value);
                                responsePage.Cookies.Add(cookie);
                            }
                        }
                    }
                }
            }
        }
    }
}