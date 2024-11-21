using Blazored.SessionStorage;
using FieldOpsAdmin.Components.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using static MudBlazor.CategoryTypes;
using Blazored.SessionStorage;
using Microsoft.JSInterop;
using System.Threading.Tasks;
using FieldOpsAdmin.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using static FieldOpsAdmin.Components.Pages.UserReviews;
using System.Data;
using System.Xml.Linq;
namespace FieldOpsAdmin.ApiServices
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl;
        private readonly ILogger<ApiService> _logger;
        private readonly ISessionStorageService _sessionStorage;
        private readonly GlobalServices _globalservice;
        public ApiService(HttpClient httpClient, IConfiguration configuration, ILogger<ApiService> logger, ISessionStorageService sessionStorage, GlobalServices globalservice)
        {
            _httpClient = httpClient;
            _apiBaseUrl = configuration["ApiBaseUrl"];
            _logger = logger;
            _globalservice = globalservice;
            _sessionStorage = sessionStorage;
        }

        public async Task<T> MakeHttpGetRequest<T>(string endpoint)
        {
            var token = await _sessionStorage.GetItemAsync<string>("authToken");

            if (string.IsNullOrEmpty(token))
            {
                _logger.LogWarning("No token found in session storage.");
            }
            else
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            string url = _apiBaseUrl + endpoint;
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseData = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrWhiteSpace(responseData))
                {
                    _logger.LogWarning("Received empty response from {Url}", url);
                    return default;
                }

                ApiResponse<T> apiResponse = JsonConvert.DeserializeObject<ApiResponse<T>>(responseData);

                if (apiResponse != null && apiResponse.IsSuccess)
                {
                    return apiResponse.Result;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error making HTTP request to {Url}", url);
                throw;
            }
            return default;
        }
        public async Task<T> MakeHttpGetRequestB<T>(string endpoint)
        {
            var token = await _sessionStorage.GetItemAsync<string>("authToken");

            if (string.IsNullOrEmpty(token))
            {
                _logger.LogWarning("No token found in session storage.");
            }
            else
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            string url = _apiBaseUrl + endpoint;
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseData = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrWhiteSpace(responseData))
                {
                    _logger.LogWarning("Received empty response from {Url}", url);
                    return default;
                }

                // Deserialize the response data to the expected ApiResponse<T> type
                var apiResponse = JsonConvert.DeserializeObject<ApiResponseBank<T>>(responseData);

                if (apiResponse != null && apiResponse.IsSuccess)
                {
                    return apiResponse.Result.First();  // Ensure that Result is of type T (List<T>)
                }
                else
                {
                    _logger.LogWarning("API response was not successful or is null. Response: {Response}", responseData);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error making HTTP request to {Url}", url);
                throw;
            }
            return default;
        }

        public async Task<bool> MakeHttpPostRequest<T>(string endpoint, object data)
        {
            var token = await _sessionStorage.GetItemAsync<string>("authToken");
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            string url = _apiBaseUrl + endpoint;
            string jsonData = JsonConvert.SerializeObject(data);
            HttpContent content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            try
            {
                HttpResponseMessage response = await _httpClient.PostAsync(url, content);
                response.EnsureSuccessStatusCode();
                string responseData = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse<T>>(responseData);
                bool isSuccess = apiResponse.IsSuccess;
                return isSuccess;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> MakeLoginHttpPostRequest<T>(string endpoint, object data)
        {
            string url = _apiBaseUrl + endpoint;
            string jsonData = JsonConvert.SerializeObject(data);
            HttpContent content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            try
            {
                HttpResponseMessage response = await _httpClient.PostAsync(url, content);
                response.EnsureSuccessStatusCode();
                string responseData = await response.Content.ReadAsStringAsync();
                ResponseDto apiResponse = JsonConvert.DeserializeObject<ResponseDto>(responseData);
                if (apiResponse.IsSuccess)
                {
                    var userDto = apiResponse.Result.User;
                    LoggedInUserDto user = new LoggedInUserDto
                    {
                        Id = userDto.Id,
                        Name = userDto.Name,
                        FirstName = userDto.FirstName,
                        LastName = userDto.LastName,
                        Email = userDto.Email,
                        PhoneNumber = userDto.PhoneNumber,
                        Role = userDto.Role,
                        CreatedAt = userDto.CreatedAt,
                        LastUpdatedAt = userDto.LastUpdatedAt,
                        YearOfExperience = userDto.YearOfExperience,
                        Rating = userDto.Rating,
                        ProfileUrl = userDto.ProfileUrl,
                        TotalMoneySpent = userDto.TotalMoneySpent,
                        ServicesRequested = userDto.ServicesRequested,
                        TotalServiceDelivered = userDto.TotalServiceDelivered,
                        DomainId = userDto.DomainId,
                        PaymentMethod = userDto.PaymentMethod,
                        IsOnline = userDto.IsOnline,
                        Reviews = userDto.Reviews
                    };
                    _globalservice.loggedInUserData = user;
                    string token = apiResponse.Result.Token;
                    SetToken(token);
                    bool isSuccess = apiResponse.IsSuccess;
                    return isSuccess;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public async Task SetToken(string token)
        {
            await _sessionStorage.SetItemAsync("authToken", token);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            _logger.LogInformation("Token set in HttpClient headers.");
        }

        public async Task<bool> MakeHttpPutRequest<T>(string endpoint, object data)
        {
            var token = await _sessionStorage.GetItemAsync<string>("authToken");
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            string url = _apiBaseUrl + endpoint;
            string jsonData = JsonConvert.SerializeObject(data);
            HttpContent content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PutAsync(url, content);
            response.EnsureSuccessStatusCode();
            string responseData = await response.Content.ReadAsStringAsync();
            ResponseDto apiResponse = JsonConvert.DeserializeObject<ResponseDto>(responseData);
            return apiResponse.IsSuccess;
        }

        public async Task<bool> MakeHttpDeleteRequest<T>(string endpoint)
        {
            var token = await _sessionStorage.GetItemAsync<string>("authToken");
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            string url = _apiBaseUrl + endpoint;
            try
            {
                HttpResponseMessage response = await _httpClient.DeleteAsync(url);
                response.EnsureSuccessStatusCode();
                string responseData = await response.Content.ReadAsStringAsync();
                ResponseDto apiResponse = JsonConvert.DeserializeObject<ResponseDto>(responseData);
                bool isSuccess = apiResponse.IsSuccess;
                return isSuccess;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public async Task<FileUploadRes> MakeHttpPostUploadPicRequest<FileUploadRes>(string endpoint, HttpContent content)
        {
            var token = await _sessionStorage.GetItemAsync<string>("authToken");
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            string url = _apiBaseUrl + endpoint;
            HttpResponseMessage response = await _httpClient.PostAsync(url, content);
            response.EnsureSuccessStatusCode();
            string responseData = await response.Content.ReadAsStringAsync();
            FileUploadRes apiResponse = JsonConvert.DeserializeObject<FileUploadRes>(responseData);
            return apiResponse;
        }
    }
}
