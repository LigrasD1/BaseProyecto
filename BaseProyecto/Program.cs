using Base.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Base.Data.Data.Repository.IRepository;
using Base.Data.Data.Repository;
using Base.Models;

namespace BaseProyecto
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Cadena de conexión a la base de datos
            var connectionString = builder.Configuration.GetConnectionString("Conexion")
                                   ?? throw new InvalidOperationException("Connection string 'Conexion' not found.");

            // Agregar DbContext
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Agregar servicios de Identity
            //builder.Services.AddDefaultIdentity<IdentityUser>(options =>
            //{
            //    options.SignIn.RequireConfirmedAccount = false;
            //})
            //.AddEntityFrameworkStores<ApplicationDbContext>(); // Esto usa el DbContext que acabas de configurar

            // Agregar repositorios personalizados
            builder.Services.AddScoped<IContenedorTrabajo, ContenedorTrabajo>();
            builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            builder.Services.AddScoped<IArticuloRepository, ArticuloRepository>();
            builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultUI();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LogoutPath = "/Cliente/Articulo";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.Events.OnRedirectToLogout = context =>
                {
                    context.Response.Redirect("/Home/Index"); // Ruta de redirección predeterminada después de logout
                    return Task.CompletedTask;
                };
            });

            // Configurar controladores y vistas
            builder.Services.AddControllersWithViews();

            // Configurar logging (opcional)
            builder.Logging.AddConsole();
            builder.Logging.AddDebug();

            var app = builder.Build();
                
            // Configurar middleware y pipeline de la aplicación
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{area=Cliente}/{controller=Articulo}/{action=Index}/{id?}");

            app.MapRazorPages();

            app.Run();
        }
    }
}
