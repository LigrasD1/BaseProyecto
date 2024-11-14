using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Models
{
    public class Usuario : IdentityUser
    {
        public string? Nombre { get; set; }
        public int Edad { get; set; }
        public string? EstadoCivil { get; set; }

    }
}
