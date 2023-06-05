using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Miguel_Ballesteros_2023
{
    class Usuario
    {
        public string nombre { get; set; }
        public string rol { get; set; }
        public string adress { get; set; }
        public string phone { get; set; }
        public string email { get; set; }

        public Usuario(string nombre1, string rol1, string direccion1, string telefono1, string email1)
        {
            nombre = nombre1;
            rol=rol1;
            adress=direccion1;
            phone=telefono1;
            email = email1;
        }
    }
}
