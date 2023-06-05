using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Miguel_Ballesteros_2023
{
    class Medicamento
    {
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public double precio { get; set; }
        public int stock { get; set; }

        public Medicamento(string nombre1, string descripcion1, double precio1, int stock1)
        {
            nombre = nombre1;
            descripcion = descripcion1;
            precio = precio1;
            stock = stock1;
        }
    }


}

