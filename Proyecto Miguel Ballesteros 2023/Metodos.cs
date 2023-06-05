using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Proyecto_Miguel_Ballesteros_2023
{
    class Metodos
    {
        public string connectionString = "Server=localhost;Database=Proyecto Miguel Ballesteros 2023;User Id=miguel;Password=miguel;";

        public void adafs()
        {
            Medicamentos medicamentos = new Medicamentos();

            
            // Establecer la conexión con la base de datos
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                // Consulta SQL para seleccionar los datos de la tabla "medicamentos"
                string sql = "SELECT nombre, descripcion, precio, stock FROM medicamentos";

                try
                {
                    using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                    {
                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Obtener los valores de cada columna
                                string nombre = reader.GetString(0);
                                string descripcion = reader.GetString(1);
                                int precio = reader.GetInt32(2);
                                int stock = reader.GetInt32(3);

                                // Crear un nuevo objeto Medicamento con los valores obtenidos
                                Medicamento medicamento1 = new Medicamento(nombre, descripcion, precio, stock);

                                // Agregar el objeto Medicamento al ListView
                                //medicamentosListView.Dispatcher.Invoke(() => medicamentosListView.Items.Add(medicamento));
                                medicamentos.LVMedicamentos.Items.Add(medicamento1);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message);
                }
                

                connection.Close();
                medicamentos.Show();
            }
        }
    }
}
