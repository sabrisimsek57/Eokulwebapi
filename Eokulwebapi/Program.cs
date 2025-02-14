using Eokulwebapi.Context;
using Eokulwebapi.Entities;
using Eokulwebapi.Service.Ders;
using Eokulwebapi.Service.DersProgramý;
using Eokulwebapi.Service.Devamsýzlýk;
using Eokulwebapi.Service.ÝliþkisiKesilen;
using Eokulwebapi.Service.Not;
using Eokulwebapi.Service.Öðrenci;
using Eokulwebapi.Service.Öðretmen;
using Eokulwebapi.Service.ÖnKayýtÖðrenci;
using Eokulwebapi.Service.Sýnýf;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<OkulContext>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<OkulContext>();
builder.Services.AddScoped<IÖnKayýtÖðrenciService,ÖnKayýtÖðrenciService>();
builder.Services.AddScoped<IÖðrenciService,ÖðrenciService>();
builder.Services.AddScoped<ISýnýfService,SýnýfService>();
builder.Services.AddScoped<IDersProgramýService,DersProgramýService>();
builder.Services.AddScoped<INotService,NotService>();
builder.Services.AddScoped<IDevamsýzlýkService,DevamsýzlýkService>();
builder.Services.AddScoped<IÝliþkisiKesilenService,ÝliþkisiKesilenService>();
builder.Services.AddScoped<IDersService,DersService>();
builder.Services.AddScoped<IÖðretmenService,ÖðretmenService>();

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
