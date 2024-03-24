using Newtonsoft.Json;

namespace Common.Utils
{
    public static class HttpUtils
    {
        public static async Task<T> GetAsync<T>(HttpClient httpClient, string requestUri)
        {
            var result = await httpClient.GetAsync(requestUri);
            string response = await result.Content.ReadAsStringAsync();
            T obj = JsonConvert.DeserializeObject<T>(response);
            return obj;
        }

        public static async Task<string> GetAsyncString(HttpClient httpClient, string requestUri)
        {
            var result = await httpClient.GetAsync(requestUri);
            string response = await result.Content.ReadAsStringAsync();
            return response;
        }
    }
}
