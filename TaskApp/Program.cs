using TaskApp.Data;
using TaskApp.Repository;
using TaskApp.Repository.MsSQL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// configure asp.net the ef library to connect for a db
builder.Services.AddDbContext<TaskDbContext>();

//builder.Services.AddSingleton<ITodoRepository, TodoInMemoryRepository>();
builder.Services.AddSingleton<ITaskRepository, TaskRestRepository>();

// DI object is configured by a constructor inject the object defined here 
builder.Services.AddScoped<TaskDbContext, TaskDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
