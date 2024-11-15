using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Base.Models;
using Microsoft.AspNetCore.Identity;

namespace Base.Data
{
	public class ApplicationDbContext : IdentityDbContext<IdentityUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
		public DbSet<Usuario> Usuarios { get; set; }
		public DbSet<Categoria>Categoria {  get; set; }
		public DbSet<Articulo> Articulo { get; set; }
		public DbSet<Carrito> Carrito { get; set; }
		public DbSet<CarritoArticulo> carritoArticulos { get; set; }		
	}
}
