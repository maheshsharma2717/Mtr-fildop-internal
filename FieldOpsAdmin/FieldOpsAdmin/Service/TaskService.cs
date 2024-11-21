using Blazored.SessionStorage;
using FieldOpsAdmin.Models.Dto;
using FieldOpsAdmin.Services;

namespace FieldOpsAdmin.Service
{
    public class TaskService : BaseService
    {
        private readonly GlobalServices _globalServices;
        public TaskService(ISessionStorageService sessionStorageService, IConfiguration configuration, GlobalServices globalServices) : base(sessionStorageService, configuration)
        {
            _globalServices = globalServices;
        }
        internal async Task<ResponseDto> AssignTaskToUser(int taskId, int userId)
        {
            client = new HttpClient();
            message = new HttpRequestMessage();
            message.RequestUri = new Uri($"{baseUrl}Task/AssignTask?taskId={taskId}&assignTo={userId}");
            message.Method = HttpMethod.Post;
            return await SendAsync();
        }
        internal async Task<ResponseDto> GetAllTasks(int statusId)
        {
            client = new HttpClient();
            message = new HttpRequestMessage();
            message.RequestUri = new Uri($"{baseUrl}Task/GetAllTask?tasksStatus={statusId}&domainId={_globalServices.domainId}");
            message.Method = HttpMethod.Get;
            return await SendAsync();
        }
        internal async Task<ResponseDto> GetTaskDetailsByTaskId(int taskId)
        {
            client = new HttpClient();
            message = new HttpRequestMessage();
            message.RequestUri = new Uri($"{baseUrl}Task/GetTaskById/{taskId}");
            message.Method = HttpMethod.Get;
            return await SendAsync();
        }
    }

}
