using Base.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Data.Data.Repository.IRepository
{
	public interface ICarritoArticuloRepository :IRepository<CarritoArticulo>
	{
		void Update(CarritoArticulo carritoArticulo);
		IEnumerable<SelectListItem>? GetListaCarritoArticulo();



    }
}
