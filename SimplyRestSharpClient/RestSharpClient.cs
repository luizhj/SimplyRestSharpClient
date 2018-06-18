using RestSharp;
using System;
using System.Threading.Tasks;

namespace SimplyRestSharpClient
{
	public class RestSharpClient:IDisposable
    {
        private string baseUrl;

        public RestSharpClient(string _baseUrl)
        {
            this.baseUrl = _baseUrl;
        }

		public async Task<IRestResponse<T>> PostAsync<T>(string resource, object param = null) where T : new()
        {
            return await RestExecuteAsync<T>(resource, param, Method.POST);
        }

		public async Task<IRestResponse<T>> GetAsync<T>(string resource, object param = null) where T : new()
        {
			
            return await RestExecuteAsync<T>(resource, param, Method.GET);
        }

		public async Task<IRestResponse<T>> PutAsync<T>(string resource, object param = null) where T : new()
        {
            return await RestExecuteAsync<T>(resource, param, Method.PUT);
        }

		public async Task<IRestResponse<T>> DeleteAsync<T>(string resource, object param = null) where T : new()
        {
            return await RestExecuteAsync<T>(resource, param, Method.DELETE);
        }

		public async Task<IRestResponse<T>> RestExecuteAsync<T>(string resource, object param, Method method) where T : new()
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest(resource, method);
            if (param != null)
                request.AddObject(param);
            var asyncHandler = await client.ExecuteTaskAsync<T>(request);

            return asyncHandler;
        }

        public async Task<IRestResponse> RestExecuteAsync(string resource, object param, Method method)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest(resource, method);
			if (param != null)
                request.AddObject(param);
            var asyncHandler = await client.ExecuteTaskAsync(request);

            return asyncHandler;
        }

    		public async Task<IRestResponse> PostAsync(string resource, object param = null)
        {
            return await RestExecuteAsync(resource, param, Method.POST);
        }
        


		#region IDisposable

		// Flag: Has Dispose already been called?
        bool disposed = false;

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here.
                //


            }

            // Free any unmanaged objects here.
            //


            disposed = true;
        }

		~RestSharpClient()
        {
            Dispose(false);
        }

		#endregion IDisposable

        public async Task<IRestResponse> GetAsync(string resource, object param) 
        {
            return await RestExecuteAsync(resource, param, Method.GET);
        }

        public async Task<IRestResponse> PutAsync(string resource, object param) 
        {
            return await RestExecuteAsync(resource, param, Method.PUT);
        }

        public async Task<IRestResponse> DeleteAsync(string resource, object param) 
        {
            return await RestExecuteAsync(resource, param, Method.DELETE);
        }

    }

}
