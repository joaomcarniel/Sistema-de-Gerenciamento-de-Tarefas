using LabWareTempoEDinheroFrontEnd.Data;
using LabWareTempoEDinheroFrontEnd.Reports;
using LabWareTempoEDinheroFrontEnd.Reports.Interfaces;
using LabWareTempoEDinheroFrontEnd.Repository;
using LabWareTempoEDinheroFrontEnd.Repository.Interfaces;
using LabWareTempoEDinheroFrontEnd.Services;
using LabWareTempoEDinheroFrontEnd.Services.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IAgentService, AgentService>();
builder.Services.AddScoped<IAgentRepository, AgentRepository>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<IAgentProjectRepository, AgentProjectRepository>();
builder.Services.AddScoped<IAgentProjectService, AgentProjectService>();
builder.Services.AddScoped<IReportRepository, ReportRepository>();
builder.Services.AddScoped<IAgentProjectReportService, AgentProjectReportService>();
builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<ITaskProjectRepository, TaskProjectRepository>();
builder.Services.AddScoped<ITasksFromProjectsReportService, TasksFromProjectsReportService>();
builder.Services.AddScoped<ITimeControlTaskRepository, TimeControlTaskRepository>();
builder.Services.AddScoped<ITimeControlTaskService, TimeControlTaskService>();
var connectionString = "Server=localhost;Uid=root;Pwd=root;Database=labware";
var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
builder.Services.AddDbContext<labwareContext>(
    dbContextOptions => dbContextOptions
    .UseMySql(connectionString, serverVersion));
builder.Services.AddControllersWithViews();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Login}/{action=Index}/{id?}");
});

app.Run();
