using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OstimTeknoparkApp.Data;
using OstimTeknoparkApp.Interfaces;
using OstimTeknoparkApp.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IToplant�SalonRepository, Toplant�SalonRespository>();
builder.Services.AddScoped<IHaberRepository, HaberRepository>();
builder.Services.AddScoped<IRezervasyonTalepRepository,RezervasyonTalepRepository>();
builder.Services.AddScoped<ITgbFirmaRepository, TgbFirmaRepository>();  
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

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
