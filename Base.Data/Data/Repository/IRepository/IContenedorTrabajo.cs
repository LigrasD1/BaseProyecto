using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Data.Data.Repository.IRepository
{
    public interface IContenedorTrabajo : IDisposable
    {
       public IUsuarioRepository Usuario { get; }
       public ICategoriaRepository Categoria { get; }
       public IArticuloRepository Articulo { get; }
       public ICarritoRepository Carrito { get; }
       public ICarritoArticuloRepository CarritoArticulo { get; }
        void Save();
    }
}
