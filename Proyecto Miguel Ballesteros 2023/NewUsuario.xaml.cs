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
    /// Lógica de interacción para NewUsuario.xaml
    /// </summary>
    public partial class NewUsuario : Window
    {
        private string connectionString = "Server=localhost;Database=Proyecto Miguel Ballesteros 2023;User Id=miguel;Password=miguel;";

        public NewUsuario()
        {
            InitializeComponent();
            CBRol.Items.Add("Administrador");
            CBRol.Items.Add("Responsable");
            CBRol.Items.Add("Usuario");
        }

        private void BTGuardar_Click(object sender, RoutedEventArgs e)
        {
            Thread t1 = new Thread(saveUser);
            t1.Start();
        }

        private void BTCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
        private void saveUser()
        {
            string nombre = string.Empty;
            string password = string.Empty;
            string telefono = string.Empty;
            string direccion = string.Empty;
            string rol = string.Empty;
            string email = string.Empty;
            Dispatcher.Invoke(() =>
            {
                nombre = TxtNombre.Text;
                password = TxtPassword.Text;
                telefono = TxtTelefono.Text;
                direccion = TxtDireccion.Text;
                rol = CBRol.Text;
                email = TxtEmail.Text;
            });
            if(email=="" || password == "" || rol == "")
            {
                MessageBox.Show("Los campos email, contraseña y rol son obligatorios");
            }
            else
            {
                string operacion = "INSERT INTO usuarios (nombre, password, rol, email, adress, phone) VALUES (@Nombre, @Password, @Rol, @Email, @Adress, @Phone)";
                try
                {
                    using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                    {
                        using (NpgsqlCommand command = new NpgsqlCommand(operacion, connection))
                        {
                            command.Parameters.AddWithValue("@Nombre", nombre);
                            command.Parameters.AddWithValue("@Password", password);
                            command.Parameters.AddWithValue("@Rol", rol);
                            command.Parameters.AddWithValue("@Email", email);
                            command.Parameters.AddWithValue("@Adress", direccion);
                            command.Parameters.AddWithValue("@Phone", telefono);
                            connection.Open();
                            command.ExecuteNonQuery();
                            connection.Close();
                            MessageBox.Show("Usuario creado correctamente");
                            Thread t2 = new Thread(saveMov);
                            t2.Start();
                            Dispatcher.Invoke(() =>
                            {
                                this.Close();
                            });
                            
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message);
                }
            }
            
        }

        private void saveMov()
        {
            string email = string.Empty;

            Dispatcher.Invoke(() =>
            {
                email = LblEmail.Content.ToString();
            });
            string operacion = "INSERT INTO movimientos (emailusuario, tipomovimiento, fecha) VALUES (@email, 'Crear Usuario', CURRENT_DATE)";
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    using (NpgsqlCommand command = new NpgsqlCommand(operacion, connection))
                    {
                        command.Parameters.AddWithValue("@email", email);
                        connection.Open();
                        //MessageBox.Show(email);
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
    }
}
