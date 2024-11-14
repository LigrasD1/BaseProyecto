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
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;
        public UsuarioRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public void Update(Usuario usuario)
        {
            var objbaseDatos = _context.Usuarios.FirstOrDefault(x => x.Id == usuario.Id);
            objbaseDatos.Nombre = usuario.Nombre;
            objbaseDatos.EstadoCivil = usuario.EstadoCivil;
            objbaseDatos.Edad = usuario.Edad;
            objbaseDatos.Email = usuario.Email;
            objbaseDatos.LockoutEnabled = usuario.LockoutEnabled;

            //objbaseDatos.Email = usuario.Email;
            //objbaseDatos.PasswordHash = usuario.PasswordHash;
            _context.SaveChanges();
        }
    }
}
