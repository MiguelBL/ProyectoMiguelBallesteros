using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Miguel_Ballesteros_2023
{
    class Venta
    {
        public int id { get; set; }
        public string fecha { get; set; }
        public string clienteId { get; set; }
        public int total { get; set; }
        public string username { get; set; }

        public Venta(int id1, string fecha1, string clienteId1, int total1, string username1)
        {
            id = id1;
            fecha = fecha1;
            clienteId = clienteId1;
            total = total1;
            username = username1;
        }
        public Venta()
        {

        }
    }
}
