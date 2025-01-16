using ASP_CYBERSECU.BLL.Interfaces;
using ASP_CYBERSECU.BLL.Services;
using ASP_CYBERSECU.DAL.Interfaces;
using ASP_CYBERSECU.DAL.Respositories;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//builder.Services.AddSingleton(); > l'instance est créé et reste toujours la même 
//builder.Services.AddScoped(); > l'instance est conservée lors de requêtes depuis la même portée
//builder.Services.AddTransient(); > Une nouvelle instance est créé à chaque appel


builder.Services.AddScoped<SqlConnection>(c => new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUtilisateurRepository, UtilisateurRepository>();
builder.Services.AddScoped<IUtilisateurService, UtilisateurService>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
