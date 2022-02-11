using Microsoft.EntityFrameworkCore;
using SimpleApp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



// EFcore
// In Net 6, configuration is not injected into StartUp, rather it's accessed from builder
builder.Services.AddDbContext<CustomerContext>(options => options.UseSqlServer(
       builder.Configuration["ConnectionStrings:defaultConnection"]));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
