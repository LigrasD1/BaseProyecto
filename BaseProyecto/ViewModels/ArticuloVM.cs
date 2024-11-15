using Base.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BaseProyecto.ViewModels
{
    public class ArticuloVM
    {
        public Articulo Articulo { get; set; }
        public IEnumerable<SelectListItem>? ListaCategoria { get; set; }
        public IEnumerable<SelectListItem>? ListaCarritoArticulo { get; set; }
    }
}
