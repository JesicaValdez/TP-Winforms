using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Articulo
    {
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set;}
        public Marca marca { get; set; }
        public Categoria categoria { get; set; }
        public float precio { get; set; }
        public string imagenurl { get; set; }

    }
}
