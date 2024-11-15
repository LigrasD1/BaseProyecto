using Base.Data.Data.Repository.IRepository;
using Base.Data.Migrations;
using Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Data.Data.Repository
{
	public class CarritoRepository : Repository<Carrito>, ICarritoRepository
	{
		private readonly ApplicationDbContext _context;

		public CarritoRepository(ApplicationDbContext context) : base(context)
		{
			_context = context;
        }
        public void Update(Carrito carrito)
		{
			Carrito objbaseDatos = _context.Carrito.FirstOrDefault(x => x.Id == carrito.Id);
			_context.SaveChanges();
		}
	}
}
