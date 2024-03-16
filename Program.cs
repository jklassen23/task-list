using task_api.Migrations;
using task_api.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddSqlite<TaskDbContext>("Data Source=task_api.db");
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder => builder
    .WithOrigins("http://localhost:8100", "http://localhost:3000")
    .AllowAnyHeader()
    .AllowAnyMethod());

app.UseHttpsRedirection();
app.MapControllers();
app.Run();

