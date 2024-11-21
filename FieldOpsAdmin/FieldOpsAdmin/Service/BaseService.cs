using Blazored.SessionStorage;
using FieldOpsAdmin.Models.Dto;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace FieldOpsAdmin.Service
{
    public abstract class BaseService
    {
        protected readonly string baseUrl;
        protected HttpClient client;
        private ResponseDto response;
        protected HttpRequestMessage message;
        ISessionStorageService _sessionStorageService;
        public BaseService(ISessionStorageService sessionStorageService, IConfiguration configuration)
        {
            _sessionStorageService = sessionStorageService;
            baseUrl = configuration["ApiBaseUrl"];
            response = new ResponseDto();
        }

        protected async Task<ResponseDto> SendAsync()
        {
            try
            {
                message.Headers.Add("Accept", "application/json");
                string jwtToken = await _sessionStorageService.GetItemAsync<string>("authToken");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
                HttpResponseMessage response = await client.SendAsync(message);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    this.response = JsonConvert.DeserializeObject<ResponseDto>(content);
                }
                return this.response;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }

}
