using hospital_backend.Models;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<ModelContext, ModelContext>();
builder.Services.AddSwaggerGen();
// 设置允许跨域访问该服务
builder.Services.AddCors(options =>
{
    options.AddPolicy
        (name: "myCors",
            builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
            }
        );
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("myCors");
// 设置允许跨域访问该服务
app.UseAuthorization();

app.MapControllers();

app.Run();
