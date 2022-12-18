using Microsoft.EntityFrameworkCore;
using ProductWebAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

/* Db Connection */

//var dbHost = "localhost";
//var dbName = "dms_customer";
//var dbPassword = "P@ssw0rd123#";

var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbPassword = Environment.GetEnvironmentVariable("DB_ROOT_PASSWORD");

var connectionString = $"server={dbHost};port=3306;database={dbName};user=root;Password={dbPassword};allowPublicKeyRetrieval=true";

//builder.Services.AddDbContext<ProductDBContext>(options => options.UseMySQL("Server=(localdb)\\mssqllocaldb;Database=dms_customer;Trusted_Connection=True;MultipleActiveResultSets=true"));
builder.Services.AddDbContext<ProductDBContext>(options => options.UseMySQL(connectionString));

/* Db Connection */

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
