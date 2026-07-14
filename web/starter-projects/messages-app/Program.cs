using api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Database>(dbContextOptionsBuilder => {
    dbContextOptionsBuilder.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
//"Data Source=localhost\\SQLEXPRESS;Initial Catalog=messages;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles(); // for static file serving
app.MapFallbackToFile("index.html"); // for static file serving

app.MapControllers();

app.Run();
