using Microsoft.EntityFrameworkCore;
using WebAPITestBE.DBContext;
using WebAPITestBE.IRepositories;
using WebAPITestBE.IServices;
using WebAPITestBE.Repositories;
using WebAPITestBE.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//config
builder.Services.AddDbContext<ApplicationDBContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
    );

//build service
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IMovieServices, MovieServices>();
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
