using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

namespace Tupa_Web.Common.Models
{
    public static class HttpRequestUrl
    {
        public static readonly string baseUrlTupa = "https://tupaserver.azurewebsites.net/";

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
            string mediaType = "application/json")
        {
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue(mediaType));

            var streamTask = client.GetStreamAsync(url);
            var objectResult = await JsonSerializer.DeserializeAsync<T>(await streamTask);

            return objectResult;
        }

        public static async Task<String> ProcessHttpClientGet(
            string url,
            string mediaType = "application/json")
        {
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue(mediaType));

            var streamTask = client.GetStringAsync(url);

            return await streamTask;
        }

        public static async Task<string> ProcessHttpClientPost(
            string url,
            JsonSerializerOptions options = null,
            string mediaType = "application/json")
        {
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue(mediaType));

            var content = new StringContent("", Encoding.UTF8, "text/json");

            var response = Task.Run(() => client.PostAsync(url, content));
            response.Wait();

            var streamTask = await response.Result.Content.ReadAsStringAsync();

            return streamTask;
        }
    }
}