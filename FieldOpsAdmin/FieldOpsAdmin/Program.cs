using FieldOpsAdmin.ApiServices;
using FieldOpsAdmin.Components;
using MudBlazor.Services;
using Blazored.SessionStorage;
using static FieldOpsAdmin.ApiServices.ApiService;
using FieldOpsAdmin.Services;
using Blazored.LocalStorage;
using FieldOpsAdmin.Service;

string credentionalPath = @"C:\Users\manoj\source\repos\FieldOpsAdmin\fildops-dab4d-firebase-adminsdk-m4pii-7d8aa1bf5b.json";
Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credentionalPath);
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMudServices();
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//Add services
builder.Services.AddBlazoredSessionStorage();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<ApiService>();
builder.Services.AddScoped<GlobalServices>();
builder.Services.AddScoped<CustomerEventService>();

//builder.Services.AddScoped<BaseService>();
builder.Services.AddTransient<TaskService>();
builder.Services.AddTransient<UserService>();
builder.Services.AddTransient<AdminService>();
builder.Services.AddTransient<AuthenticateService>();

builder.Services.AddHttpClient();
builder.Services.AddHttpClient<ApiService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
