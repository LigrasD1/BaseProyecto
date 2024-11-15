using Base.Data.Data.Repository.IRepository;
using Base.Data.Migrations;
using Base.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Data.Data.Repository
{
	public class CarritoArticuloRepository : Repository<CarritoArticulo>, ICarritoArticuloRepository
	{
		private readonly ApplicationDbContext _context;

		public CarritoArticuloRepository(ApplicationDbContext context) : base(context)
		{
			_context = context;
		}
        public IEnumerable<SelectListItem> GetListaCarritoArticulo()
        {
            return _context.carritoArticulos.Select(i => new SelectListItem()
            {
                Text = i.Cantidad.ToString(),
                Value = i.Id.ToString()
            });
        }
        public void Update(CarritoArticulo carritoArticulo)
		{
			CarritoArticulo objbaseDatos = _context.carritoArticulos.FirstOrDefault(x => x.Id == carritoArticulo.Id);
			objbaseDatos.Cantidad= carritoArticulo.Cantidad;
			_context.SaveChanges();
		}
	}
}
