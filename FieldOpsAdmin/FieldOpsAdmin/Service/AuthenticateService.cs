using Blazored.SessionStorage;
using FieldOpsAdmin.Components.Pages;
using FieldOpsAdmin.Models.Dto;
using Newtonsoft.Json;
using System.Text;
using static FieldOpsAdmin.Components.Pages.AddEmployee;

namespace FieldOpsAdmin.Service
{
    public class AuthenticateService : BaseService
    {
        public AuthenticateService(ISessionStorageService sessionStorageService, IConfiguration configuration) : base(sessionStorageService, configuration)
        {

        }
        internal async Task<ResponseDto> Login(string userName, string password)
        {
            client = new HttpClient();
            message = new HttpRequestMessage();

            var data = new
            {
                UserName = userName,
                Password = password
            };
            message.Content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            message.RequestUri = new Uri($"{baseUrl}Authenticate/login");
            message.Method = HttpMethod.Post;
            return await SendAsync();
        }

        internal async Task<ResponseDto> Register(Dictionary<string, string> data)
        {
            client = new HttpClient();
            message = new HttpRequestMessage();
            //var data = new
            //{
            //    FirstName = employee.FirstName,
            //    MiddleName = employee.MiddleName,
            //    LastName = employee.LastName,
            //    Email = employee.Email,
            //    PhoneNumber = employee.PhoneNumber,
            //    RoleId = 2,
            //    YearOfExperience = employee.WorkExperience,
            //    Address = employee.Address,
            //    Password = employee.Password,
            //    ConfirmPassword = employee.ConfirmPassword,
            //    ServiceCategoryId = 15,
            //    DomainId = 123,
            //};

            message.Content = new FormUrlEncodedContent(data);
            //message.Content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            message.RequestUri = new Uri($"{baseUrl}Authenticate/register");
            message.Method = HttpMethod.Post;
            return await SendAsync();
        }


    }
}
