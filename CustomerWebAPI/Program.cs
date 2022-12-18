using CustomerWebAPI;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

/* Db Connection */

//var dbHost = "localhost";
//var dbName = "dms_customer";
//var dbPassword = "P@ssw0rd123#";

var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");

var connectionString = $"Data Source={dbHost};Initial catalog={dbName};User ID=sa;Password={dbPassword}";

//builder.Services.AddDbContext<CustomerDBContext>(options => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=dms_customer;Trusted_Connection=True;MultipleActiveResultSets=true"));
builder.Services.AddDbContext<CustomerDBContext>(options => options.UseSqlServer(connectionString));

/* Db Connection */


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
