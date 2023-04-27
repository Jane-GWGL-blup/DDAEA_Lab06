using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Producto
    {

        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Boolean Estado { get; set; }
    }
}
