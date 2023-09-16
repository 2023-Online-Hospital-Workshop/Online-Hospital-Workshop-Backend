using hospital_backend.Models;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<ModelContext, ModelContext>();
builder.Services.AddSwaggerGen();
// �������������ʸ÷���
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
// �������������ʸ÷���
app.UseAuthorization();

app.MapControllers();

app.Run();
