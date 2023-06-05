using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Proyecto_Miguel_Ballesteros_2023
{

    /// <summary>
    /// Lógica de interacción para Medicamentos.xaml
    /// </summary>
    public partial class Medicamentos : Window
    {
        private string connectionString = "Server=localhost;Database=Proyecto Miguel Ballesteros 2023;User Id=miguel;Password=miguel;";
        private bool exito = false;
        Medicamentos medicamentos;
        AddMedicamento am;
        public Medicamentos()
        {
            InitializeComponent();
        }

        public void SetTxtUser(string text)
        {
            TxtUser.Content = "Usuario: " + text;
        }



        private void LVMedicamentos_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            
            if (LVMedicamentos.SelectedItem != null)
            {
                Medicamento medicamentoS = (Medicamento)LVMedicamentos.SelectedItem;
                TxtNombreMed.Content = medicamentoS.nombre;
                TxtDescripcionMed.Text = medicamentoS.descripcion;
                TxtPecioMed.Text = medicamentoS.precio.ToString();
                TxtSockMed.Text = medicamentoS.stock.ToString();
            }
        }

        private void BTSaveMed_Click(object sender, RoutedEventArgs e)
        {
            Metodos m = new Metodos();
            Thread t1 = new Thread(updateMed);
            t1.Start();
        }

       

        private void BTDeleteMed_Click(object sender, RoutedEventArgs e)
        {
            deleteMed();
        }

        private void deleteMed()
        {
            string operacion = "DELETE FROM medicamentos WHERE nombre = @nombre";
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand command = new NpgsqlCommand(operacion, connection);
            command.Parameters.AddWithValue("@nombre", TxtNombreMed.Content);
            connection.Open();
            int n = command.ExecuteNonQuery();
            if (n > 0)
            {
                Metodos m = new Metodos();
                MessageBox.Show("Eliminado con exito");
                m.adafs();
                Thread t1 = new Thread(saveMovDelete);
                t1.Start();
                this.Close();
            };
            connection.Close();
        }

        
        private void updateMed()
        {
            //Metodos m = new Metodos();
            string descripcion = string.Empty;
            string precio = string.Empty;
            string stock = string.Empty;
            string nombre = string.Empty;

            Dispatcher.Invoke(() =>
            {
                descripcion = TxtDescripcionMed.Text;
                precio = TxtPecioMed.Text;
                stock = TxtSockMed.Text;
                nombre = TxtNombreMed.Content.ToString();
            });
            if (IsNumeric(precio) && IsNumeric(stock))
            {
                string operacion = "UPDATE medicamentos SET descripcion = @Descripcion, precio = @Precio, stock = @Stock WHERE  nombre = @Nombre";
                NpgsqlConnection conexion = new NpgsqlConnection(connectionString);
                NpgsqlCommand comando = new NpgsqlCommand(operacion, conexion);
                comando.Parameters.AddWithValue("@Descripcion", descripcion);
                comando.Parameters.AddWithValue("@Precio", double.Parse(precio));
                comando.Parameters.AddWithValue("@Stock", int.Parse(stock));
                comando.Parameters.AddWithValue("@Nombre", nombre);
                conexion.Open();
                int n = comando.ExecuteNonQuery();
                if (n > 0)
                {
                    MessageBox.Show("Actualizado con exito");
                    exito = true;

                };
                conexion.Close();
            }
            else
            {
                MessageBox.Show("El precio y Stock tienen que ser números");

            }
            Dispatcher.Invoke(() =>
            {
                if (exito == true)
                {
                    Thread t2 = new Thread(saveMovEdit);
                    t2.Start();
                    LVMedicamentos.SelectedItem = null;
                    this.LVMedicamentos.Items.Clear();
                    Thread t6 = new Thread(actualizarDatos);
                    t6.Start();
                }
            });
            
        }
        private void saveMovEdit()
        {
            string email = string.Empty;

            Dispatcher.Invoke(() =>
            {
                email = LabelEmailMed.Content.ToString();
            });
            string operacion = "INSERT INTO movimientos (emailusuario, tipomovimiento, fecha) VALUES (@email, 'Edit Medicamento', CURRENT_DATE)";
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    using (NpgsqlCommand command = new NpgsqlCommand(operacion, connection))
                    {
                        command.Parameters.AddWithValue("@email", email);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void saveMovDelete()
        {
            string email = string.Empty;

            Dispatcher.Invoke(() =>
            {
                email = LabelEmailMed.Content.ToString();
            });
            string operacion = "INSERT INTO movimientos (emailusuario, tipomovimiento) VALUES (@email, 'Borrar Medicamento')";
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    using (NpgsqlCommand command = new NpgsqlCommand(operacion, connection))
                    {
                        command.Parameters.AddWithValue("@email", email);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool IsNumeric(string text)
        {
            return int.TryParse(text, out _);
        }

        public void actualizarDatos()
        {
           
            string emailmed = string.Empty;
            string userMed = string.Empty;
            Dispatcher.Invoke(() =>
            {
                medicamentos = new Medicamentos();
                userMed = TxtUser.Content.ToString();
                emailmed = LabelEmailMed.Content.ToString();
            });
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string sql = "SELECT nombre, descripcion, precio, stock FROM medicamentos";

                try
                {
                    using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                    {
                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string nombre = reader.GetString(0);
                                string descripcion = reader.GetString(1);
                                double precio = reader.GetDouble(2);
                                int stock = reader.GetInt32(3);

                                Medicamento medicamento1 = new Medicamento(nombre, descripcion, precio, stock);

                                Dispatcher.Invoke(() =>
                                {
                                    this.LVMedicamentos.Items.Add(medicamento1);
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message);
                }
                

                connection.Close();
                
            }
        }

        private void BTAddMed_Click(object sender, RoutedEventArgs e)
        {
            am = new AddMedicamento();
            am.LblArriba.Content = TxtUser.Content;
            am.LblEmail.Content = LabelEmailMed.Content;
            am.Show();
            am = null;
        }

        private void BTActLista_Click(object sender, RoutedEventArgs e)
        {
            Thread t3 = new Thread(actLista);
            t3.Start();
        }

        private void actLista()
        {

            Dispatcher.Invoke(() =>
            {
                LVMedicamentos.Items.Clear();
            });
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string sql = "SELECT nombre, descripcion, precio, stock FROM medicamentos";

                try
                {
                    using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                    {
                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string nombre = reader.GetString(0);
                                string descripcion = reader.GetString(1);
                                double precio = reader.GetDouble(2);
                                int stock = reader.GetInt32(3);

                                Medicamento medicamento1 = new Medicamento(nombre, descripcion, precio, stock);

                                Dispatcher.Invoke(() =>
                                {
                                    this.LVMedicamentos.Items.Add(medicamento1);
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message);
                }
                connection.Close();
                
                

            }
        }
    }
}
