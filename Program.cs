using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Agregar servicios MVC
        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        // Configuración de entorno
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        // Rutas MVC
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Objetivos}/{action=Index}/{id?}");

        app.Run();
    }
}