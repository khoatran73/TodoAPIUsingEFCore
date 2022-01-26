using EFCore.Catalog.AccountCatalog;
using EFCore.Catalog.TodoCatalog;
using EFCore.EF;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "allow cors";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        builder =>
        {
            builder.WithOrigins("http://localhost:3000")
             .AllowAnyMethod()
             .AllowAnyHeader()
             .AllowCredentials();
        });
});

builder.Services.AddDbContext<TodoDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnectionString"));
});

builder.Services.AddTransient<IAccountManagement, AccountManagement>();
builder.Services.AddTransient<ITodoManagement, TodoManagement>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(MyAllowSpecificOrigins);

app.Run();
