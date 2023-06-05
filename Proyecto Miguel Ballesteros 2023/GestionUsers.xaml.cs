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
    /// Lógica de interacción para GestionUsers.xaml
    /// </summary>
    public partial class GestionUsers : Window
    {
        private NewUsuario nu;
        private string connectionString = "Server=localhost;Database=Proyecto Miguel Ballesteros 2023;User Id=miguel;Password=miguel;";
        private bool exito = false;
        public GestionUsers()
        {
            InitializeComponent();
            /*if (LblRol.Content.ToString() == "Responsable" || LblRol.Content.ToString() == "Usuario")
            {
                BTNewUser.Visibility = Visibility.Hidden;
            }
            else
            {
                //MessageBox.Show(LblRol.Content.ToString());
                BTNewUser.Visibility = Visibility.Visible;
            }*/
            CBRol.Items.Add("Administrador");
            CBRol.Items.Add("Responsable");
            CBRol.Items.Add("Usuario");
        }

        private void BTSave_Click(object sender, RoutedEventArgs e)
        {
            if (LVUsuarios.SelectedItem != null)
            {
                Thread t1 = new Thread(saveUser);
                t1.Start();
            }
        }

        private void LVUsuarios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LVUsuarios.SelectedItem != null)
            {
                Usuario uS = (Usuario)LVUsuarios.SelectedItem;
                TxtNombre.Text = uS.nombre;
                TxtDireccion.Text = uS.adress;
                TxtTelefono.Text = uS.phone;
                TxtEmail.Text = uS.email;
                if (uS.rol == "Administrador")
                {
                    CBRol.SelectedIndex = 0;
                }
                else if (uS.rol == "Responsable")
                {
                    CBRol.SelectedIndex = 1;
                }
                else
                {
                    CBRol.SelectedIndex = 2;
                }
            }
        }

        private void saveUser()
        {
            string nombre = string.Empty;
            string direccion = string.Empty;
            string telefono = string.Empty;
            string rol = string.Empty;
            string email = string.Empty;

            Dispatcher.Invoke(() =>
            {
                direccion = TxtDireccion.Text;
                telefono = TxtTelefono.Text;
                rol = CBRol.SelectedItem.ToString();
                nombre = TxtNombre.Text;
                email = TxtEmail.Text;
            });


            string operacion = "UPDATE usuarios SET nombre = @Nombre, adress = @Adress, phone = @Phone, rol = @Rol WHERE  email = @Email";
            NpgsqlConnection conexion = new NpgsqlConnection(connectionString);
            NpgsqlCommand comando = new NpgsqlCommand(operacion, conexion);
            comando.Parameters.AddWithValue("@Nombre", nombre);
            comando.Parameters.AddWithValue("@Adress", direccion);
            comando.Parameters.AddWithValue("@Phone", telefono);
            comando.Parameters.AddWithValue("@Rol", rol);
            comando.Parameters.AddWithValue("@Email", email);
            conexion.Open();
            int n = comando.ExecuteNonQuery();
            if (n > 0)
            {
                MessageBox.Show("Actualizado con exito");
                exito = true;

            };
            conexion.Close();

            Dispatcher.Invoke(() =>
            {
                if (exito == true)
                {
                    Thread t2 = new Thread(saveMovEdit);
                    t2.Start();
                    TxtDireccion.Text = "";
                    TxtEmail.Text = "";
                    TxtNombre.Text = "";
                    TxtTelefono.Text = "";
                    CBRol.SelectedIndex=-1;
                    LVUsuarios.SelectedItem = null;
                    this.LVUsuarios.Items.Clear();
                    Thread t6 = new Thread(actualizarDatos);
                    t6.Start();
                }
            });
        }

        private void actualizarDatos()
        {
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
                                    this.LVUsuarios.Items.Add(u);
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
        private void saveMovEdit()
        {
            string email = string.Empty;

            Dispatcher.Invoke(() =>
            {
                email = LblEmail.Content.ToString();
            });
            string operacion = "INSERT INTO movimientos (emailusuario, tipomovimiento, fecha) VALUES (@email, 'Edit Usuario', CURRENT_DATE)";
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

        private void BTNewUser_Click(object sender, RoutedEventArgs e)
        {
            nu= new NewUsuario();
            nu.LblUser.Content = LblUser.Content;
            nu.LblEmail.Content = LblEmail.Content;
            nu.Show();
            nu = null;
        }

        private void BTRefresh_Click(object sender, RoutedEventArgs e)
        {
            this.LVUsuarios.Items.Clear();
            Thread t3 = new Thread(actualizarLista);
            t3.Start();
        }

        private void actualizarLista()
        {
            

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                // Consulta SQL para seleccionar los datos de la tabla "medicamentos"
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
                                    this.LVUsuarios.Items.Add(u);
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
