using Blazored.SessionStorage;
using FieldOpsAdmin.Models.Dto;
using FieldOpsAdmin.Services;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text;
using FieldOpsAdmin.Models;

namespace FieldOpsAdmin.Service
{
    public class UserService : BaseService
    {
        public int domainId = 0;
        private readonly ISessionStorageService _sessionStorageService;
        private readonly GlobalServices _globalServices;
        public UserService(ISessionStorageService sessionStorageService, GlobalServices globalServices, IConfiguration configuration) : base(sessionStorageService, configuration)
        {
            _globalServices = globalServices;
        }
        internal async Task<ResponseDto> GetUserDetailsByUserId(int userId)
        {
            client = new HttpClient();
            message = new HttpRequestMessage();
            message.RequestUri = new Uri($"{baseUrl}User/GetUserByUserId/{userId}?domainId={_globalServices.domainId}");
            message.Method = HttpMethod.Get;
            return await SendAsync();
        }
        internal async Task<ResponseDto> UpdateUser(Dictionary<string, string> data)
        {
            data.Add("DomainId", _globalServices.domainId.ToString());
            client = new HttpClient();
            message = new HttpRequestMessage();
            message.Content = new FormUrlEncodedContent(data);
            //message.Content = new StringContent(JsonConvert.SerializeObject(updateUserDetails), Encoding.UTF8, "application/json");
            message.RequestUri = new Uri($"{baseUrl}User/UpdateUserDetails?domainId={_globalServices.domainId}");
            message.Method = HttpMethod.Post;
            return await SendAsync();
        }

        internal async Task<ResponseDto> GetUsersByRole(int role)
        {
            client = new HttpClient();
            message = new HttpRequestMessage();
            message.RequestUri = new Uri($"{baseUrl}User/GetUsersByRole/{role}?domainId={_globalServices.domainId}");
            message.Method = HttpMethod.Get;
            return await SendAsync();
        }
        internal async Task<ResponseDto> DeleteUserAccount(int userId)
        {
            client = new HttpClient();
            message = new HttpRequestMessage();
            message.RequestUri = new Uri($"{baseUrl}User/DeleteUser/{userId}");
            message.Method = HttpMethod.Delete;
            return await SendAsync();
        }

    }
}
