using Microsoft.EntityFrameworkCore;
using minirestuarent.Data;
using MySql.Data.MySqlClient;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'defaultconnection' not found. ");
builder.Services.AddDbContextPool<ApplicationDBContext>(options =>
     options.UseMySql(ConnectionString, ServerVersion.AutoDetect(ConnectionString)));

// builder.services.AddTransient<MySqlConnection>(_ =>
//     new MySqlConnection(builder.Configuration.GetConnectionString["server=localhost;port=8889;database=AspApp;user=root;password=root;"]));
// builder.Services
//     .AddMySqlDataSource(builder.Configuration.GetConnectionString("mysql")) // using the MySqlConnector.DependencyInjection package
//     .AddHealthChecks().AddMySql();
    
// var mysql = builder.AddMySql("mysql")
//                    .WithPhpMyAdmin();

// var mysqldb = mysql.AddDatabase("mysqldb");

// var myService = builder.AddProject<Projects.ExampleProject>()
//                        .WithReference(mysqldb)
//                        .WaitFor(mysqldb);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
