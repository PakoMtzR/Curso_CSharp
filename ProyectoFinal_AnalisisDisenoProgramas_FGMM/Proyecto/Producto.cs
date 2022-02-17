using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVentasFerreteria
{
    class Producto
    {
        public int ID { get; set; }
        public string nombre { get; set; }
        public string marca { get; set; }
        public double precio { get; set; }
        public int stock { get; set; }
    }
}
