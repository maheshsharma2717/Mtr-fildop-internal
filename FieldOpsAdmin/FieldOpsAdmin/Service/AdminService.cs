using Blazored.SessionStorage;
using FieldOpsAdmin.Models.Dto;
using FieldOpsAdmin.Services;
using Newtonsoft.Json;
using System.Text;

namespace FieldOpsAdmin.Service
{
    public class AdminService : BaseService
    {
        private readonly GlobalServices _globalServices;
        public AdminService(ISessionStorageService sessionStorageService, GlobalServices globalServices, IConfiguration configuration) : base(sessionStorageService, configuration)
        {
            _globalServices = globalServices;
        }
        public async Task<ResponseDto> GetDashboardData()
        {
            client = new HttpClient();
            message = new HttpRequestMessage();
            message.RequestUri = new Uri($"{baseUrl}Admin/GetDashboardDetails?domainId={_globalServices.domainId}");
            message.Method = HttpMethod.Get;
            return await SendAsync();
        }

        public async Task<ResponseDto> AddCategory(object data)
        {
            client = new HttpClient();
            message = new HttpRequestMessage();
            message.RequestUri = new Uri($"{this.baseUrl}Admin/addservicecategory");

            if (data != null)
            {
                message.Content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            }
            message.Method = HttpMethod.Post;
            return await SendAsync();
        }
        public async Task<ResponseDto> GetCategories()
        {
            client = new HttpClient();
            message = new HttpRequestMessage();
            message.RequestUri = new Uri($"{baseUrl}Admin/getallservicecategories?domainId={_globalServices.domainId}");
            message.Method = HttpMethod.Get;
            return await SendAsync();
        }
    }
}
