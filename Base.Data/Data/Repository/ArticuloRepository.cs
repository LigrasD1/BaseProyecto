using Base.Data.Data.Repository.IRepository;
using Base.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Data.Data.Repository
{
    public class ArticuloRepository : Repository<Articulo>, IArticuloRepository
    {
        private readonly ApplicationDbContext _context;
        public ArticuloRepository(ApplicationDbContext context) : base (context)
        {
            _context = context;
        }

        public void Update(Articulo articulo)
        {
            Articulo objbaseDatos =  _context.Articulo.FirstOrDefault(x => x.Id == articulo.Id);
            objbaseDatos.Nombre = articulo.Nombre;
            objbaseDatos.habilitado = articulo.habilitado;
            objbaseDatos.precio = articulo.precio;
            objbaseDatos.cantidad = articulo.cantidad;
            if(articulo.Imagen!=null && articulo.Imagen.Length>0)objbaseDatos.Imagen = articulo.Imagen;

            objbaseDatos.CategoriaId = articulo.CategoriaId;


            _context.SaveChanges();
        }
    }
}
