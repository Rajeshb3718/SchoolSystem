using Microsoft.EntityFrameworkCore;
using SchoolSystem.Data.Contract;
using SchoolSystem.Data.Repos;
using SchoolSystem.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IDbClassRepository, DbClassRepository>();
builder.Services.AddTransient<IDbStudentRepository, DbStudentRepository>();

builder.Services.AddDbContext<SchoolSystemDBContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("apicon")));
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

app.Run();
