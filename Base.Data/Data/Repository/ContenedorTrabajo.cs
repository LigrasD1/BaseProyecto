using Base.Data.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Data.Data.Repository
{
    public class ContenedorTrabajo : IContenedorTrabajo
    {
        private readonly ApplicationDbContext _context;
        public ICategoriaRepository Categoria { get; private set; }
        public IArticuloRepository Articulo { get; private set; }
        public IUsuarioRepository Usuario { get; private set; }
        public ICarritoArticuloRepository CarritoArticulo { get; private set; }
        public ICarritoRepository Carrito { get; private set; }
        public ContenedorTrabajo(ApplicationDbContext context, ICategoriaRepository categoriaRepository, IArticuloRepository articuloRepository, IUsuarioRepository usuarioRepository)
        {
            _context = context; 
            Categoria=new CategoriaRepository(_context);
            Articulo=new ArticuloRepository(_context);
            Usuario=new UsuarioRepository(_context);
			CarritoArticulo = new CarritoArticuloRepository(_context);
            Carrito = new CarritoRepository(_context);
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
