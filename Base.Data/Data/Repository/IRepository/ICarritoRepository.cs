using Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Data.Data.Repository.IRepository
{
	public interface ICarritoRepository : IRepository<Carrito>
	{
		void Update(Carrito carrito);
	}
}
