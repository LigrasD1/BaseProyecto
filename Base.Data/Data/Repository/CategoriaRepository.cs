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
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoriaRepository(ApplicationDbContext context) : base (context)
        {
           _context = context;
        }
        public void Update(Categoria categoria)
        {
            Categoria objbaseDatos = _context.Categoria.FirstOrDefault(x=>x.Id==categoria.Id);
            objbaseDatos.Nombre = categoria.Nombre;
            objbaseDatos.Habilitada = categoria.Habilitada;
            _context.SaveChanges();
        }

    }
}
