using RestSharp;
using System.Threading.Tasks;

namespace SimplyRestSharpClient
{
    public class RestSharpClient
    {
        private string baseUrl;

        public RestSharpClient(string _baseUrl)
        {
            this.baseUrl = _baseUrl;
        }

        public async Task<IRestResponse<T>> RestExecuteAsync<T>(string resource, object param, Method method) where T : new()
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest(resource, method);
            request.AddObject(param);
            var asyncHandler = await client.ExecuteTaskAsync<T>(request);

            return asyncHandler;
        }

        public async Task<IRestResponse<T>> RestPostAsync<T>(string resource, object param) where T : new()
        {
            return await RestExecuteAsync<T>(resource, param, Method.POST);
        }

        public async Task<IRestResponse<T>> RestGetAsync<T>(string resource, object param) where T : new()
        {
            return await RestExecuteAsync<T>(resource, param, Method.GET);
        }

        public async Task<IRestResponse<T>> RestPutAsync<T>(string resource, object param) where T : new()
        {
            return await RestExecuteAsync<T>(resource, param, Method.PUT);
        }

        public async Task<IRestResponse<T>> RestDeleteAsync<T>(string resource, object param) where T : new()
        {
            return await RestExecuteAsync<T>(resource, param, Method.DELETE);
        }

        public async Task<IRestResponse> RestExecuteAsync(string resource, object param, Method method)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest(resource, method);
            request.AddObject(param);
            var asyncHandler = await client.ExecuteTaskAsync(request);

            return asyncHandler;
        }

        public async Task<IRestResponse> RestPostAsync(string resource, object param)
        {
            return await RestExecuteAsync(resource, param, Method.POST);
        }

    }
}
