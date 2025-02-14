using Eokulwebapi.Context;
using Eokulwebapi.Entities;
using Eokulwebapi.Service.Ders;
using Eokulwebapi.Service.DersProgram�;
using Eokulwebapi.Service.Devams�zl�k;
using Eokulwebapi.Service.�li�kisiKesilen;
using Eokulwebapi.Service.Not;
using Eokulwebapi.Service.��renci;
using Eokulwebapi.Service.��retmen;
using Eokulwebapi.Service.�nKay�t��renci;
using Eokulwebapi.Service.S�n�f;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<OkulContext>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<OkulContext>();
builder.Services.AddScoped<I�nKay�t��renciService,�nKay�t��renciService>();
builder.Services.AddScoped<I��renciService,��renciService>();
builder.Services.AddScoped<IS�n�fService,S�n�fService>();
builder.Services.AddScoped<IDersProgram�Service,DersProgram�Service>();
builder.Services.AddScoped<INotService,NotService>();
builder.Services.AddScoped<IDevams�zl�kService,Devams�zl�kService>();
builder.Services.AddScoped<I�li�kisiKesilenService,�li�kisiKesilenService>();
builder.Services.AddScoped<IDersService,DersService>();
builder.Services.AddScoped<I��retmenService,��retmenService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



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
