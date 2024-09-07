using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Data.Data.Repository.IRepository
{
    public interface IContenedorTrabajo : IDisposable
    {

       public ICategoriaRepository Categoria { get; }
       public IArticuloRepository Articulo { get; }
        void Save();
    }
}
