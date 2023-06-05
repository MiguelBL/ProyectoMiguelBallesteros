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
    /// Lógica de interacción para ScreenInicio.xaml
    /// </summary>
    public partial class ScreenInicio : Window
    {
        private GestionUsers gu;
        private Compras comp;
        private Ventas vent;
        private string connectionString = "Server=localhost;Database=Proyecto Miguel Ballesteros 2023;User Id=miguel;Password=miguel;";
       

        public ScreenInicio()
        {
            InitializeComponent();
       
        }

        private void BtUsers_Click(object sender, RoutedEventArgs e)
        {
            gu = new GestionUsers();
            Thread t2 = new Thread(datosLVUsers);
            t2.Start();
            
        }

        private void BTCompras_Click(object sender, RoutedEventArgs e)
        {
            Thread t3 = new Thread(datosLVCompras);
            t3.Start();
        }

        private void BTVentas_Click(object sender, RoutedEventArgs e)
        {
            Thread t4 = new Thread(datosLVVentas);
            t4.Start();

        }

        private void BtMedicamentos_Click(object sender, RoutedEventArgs e)
        {
            Medicamentos medicamentos = new Medicamentos();
            medicamentos.TxtUser.Content = LabelNombre.Content;
            medicamentos.LabelEmailMed.Content = LabelUserInicio.Content;

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
        private void datosLVUsers()
        {
            string rol2 = string.Empty;
            Dispatcher.Invoke(() =>
            {
                rol2 = LblRol.Content.ToString();
                
                gu.LblUser.Content = LabelNombre.Content;
                gu.LblRol.Content = LblRol.Content;
                gu.LblEmail.Content = LabelUserInicio.Content;
            });
            
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string sql = "SELECT nombre, adress, phone, rol, email FROM usuarios";

                try
                {
                    using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                    {
                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string nombre = reader.GetString(0);
                                string direccion = reader.GetString(1);
                                string telefono = reader.GetString(2);
                                string rol = reader.GetString(3);
                                string email = reader.GetString(4);

                                Usuario u = new Usuario(nombre, rol, direccion, telefono, email);
                                Dispatcher.Invoke(() =>
                                {
                                    gu.LVUsuarios.Items.Add(u);
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
                Dispatcher.Invoke(() =>
                {
                    gu.Show();
                });
            }

        }

        private void datosLVCompras()
        {

            Dispatcher.Invoke(() =>
            {
                comp = new Compras();
                comp.LblEmail.Content = LabelUserInicio.Content;
            });
           
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT id, fecha, proveedorId, total, username FROM compras";

                try
                {
                    using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                    {
                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int idC = reader.GetInt32(0);
                                string fechaC = reader.GetDateTime(1).ToString();
                                string proveedorIdC = reader.GetString(2);
                                int totalC = reader.GetInt32(3);
                                string usernameC = reader.GetString(4);

                                Compra c = new Compra(idC, fechaC, proveedorIdC, totalC, usernameC);

                                Dispatcher.Invoke(() =>
                                {
                                    comp.LVCompras.Items.Add(c);
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
                
       
                Dispatcher.Invoke(() =>
                {
                    comp.Show();
                    comp = null;
                });
            }
        }

        
        private void datosLVVentas()
        {
            Dispatcher.Invoke(() =>
            {
                vent = new Ventas();
                vent.LblEmail.Content = LabelUserInicio.Content;
            });

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT id, fecha, clienteId, total, username FROM ventas";

                try
                {
                    using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                    {
                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int idV = reader.GetInt32(0);
                                string fechaV = reader.GetDateTime(1).ToString();
                                string clienteIdV = reader.GetString(2);
                                int totalV = reader.GetInt32(3);
                                string usernameV = reader.GetString(4);

                                Venta v = new Venta(idV, fechaV, clienteIdV, totalV, usernameV);

                                Dispatcher.Invoke(() =>
                                {
                                    vent.LVVentas.Items.Add(v);
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

 
                Dispatcher.Invoke(() =>
                {
                    vent.Show();
                    vent = null;
                });
            }
        }
    }
}
