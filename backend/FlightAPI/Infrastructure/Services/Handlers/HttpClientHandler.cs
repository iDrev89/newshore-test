using Application.Common.Interfaces;
using Application.Common.Models;
using Domain.Enums;
using System.Net.Http.Json;

namespace Infrastructure.Services.Handlers
{
    public class HttpClientHandler: IHttpClientHandler
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HttpClientHandler(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ServiceResult<TResult>> GenericRequest<TResult>(string clientApi, string url, CancellationToken cancellationToken,
         MethodType method = MethodType.Get)
         where TResult : class 
        {
            var httpClient = _httpClientFactory.CreateClient(clientApi);

            try
            {

                var response = await httpClient.GetAsync(url, cancellationToken);

                if (response != null && response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadFromJsonAsync<TResult>(cancellationToken: cancellationToken);
                    return ServiceResult.Success(data);
                }

                if (response == null)
                    return ServiceResult.Failed<TResult>(ServiceError.ServiceProvider);

                var message = await response.Content.ReadAsStringAsync(cancellationToken);

                var error = new ServiceError(message, (int)response.StatusCode);

                return ServiceResult.Failed<TResult>(error);
            }
            catch (Exception ex)
            {
                return ServiceResult.Failed<TResult>(ServiceError.CustomMessage(ex.ToString()));
            }
        }
    }
}
