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
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddDbContext<OkulContext>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<OkulContext>();

builder.Services.AddScoped<I�nKay�t��renciService, �nKay�t��renciService>();
builder.Services.AddScoped<I��renciService, ��renciService>();
builder.Services.AddScoped<IS�n�fService, S�n�fService>();
builder.Services.AddScoped<IDersProgram�Service, DersProgram�Service>();
builder.Services.AddScoped<INotService, NotService>();
builder.Services.AddScoped<IDevams�zl�kService, Devams�zl�kService>();
builder.Services.AddScoped<I�li�kisiKesilenService, �li�kisiKesilenService>();
builder.Services.AddScoped<IDersService, DersService>();
builder.Services.AddScoped<I��retmenService, ��retmenService>();




builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login/Index"; // Giri� yap�lmam��sa y�nlendirilecek sayfa
        options.LogoutPath = "/Login/Logout"; // ��k�� yap�ld�ktan sonra y�nlendirilecek sayfa
        options.ExpireTimeSpan = TimeSpan.FromMinutes(5); // Cookie'nin ge�erlilik s�resi
        options.SlidingExpiration = false; // Cookie'nin ge�erlili�i s�resinin uzat�lmas�
    });
builder.Services.AddAuthorization();

builder.Services.AddHttpClient();
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Kimlik do�rulama middleware
app.UseAuthorization(); // Yetkilendirme middleware

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");



// Eri�im reddi y�nlendirmesi
app.MapControllerRoute(
    name: "accessdenied",
    pattern: "Account/AccessDenied",
    defaults: new { controller = "yetkisiz", action = "Index" });


app.Run();
