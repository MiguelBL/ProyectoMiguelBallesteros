using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Miguel_Ballesteros_2023
{
    class DetallesVenta
    {
        public int ventaid { get; set; }
        public string medicamentoid { get; set; }
        public int cantidad { get; set; }

        public DetallesVenta(int ventaid1, string medicamentoid1, int cantidad1)
        {
            ventaid = ventaid1;
            medicamentoid = medicamentoid1;
            cantidad = cantidad1;
        }
    }
}
