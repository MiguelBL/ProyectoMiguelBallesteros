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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Npgsql;

namespace Proyecto_Miguel_Ballesteros_2023
{
    
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool exito = false;
        private ScreenInicio s1;
        private string email;
        private string nombre;
        private string rol;
        private string connectionString = "Server=localhost;Database=Proyecto Miguel Ballesteros 2023;User Id=miguel;Password=miguel;";

        public MainWindow()
        {
            InitializeComponent();
        }


        private void btAcceder_Click(object sender, RoutedEventArgs e)
        {
            s1 = new ScreenInicio();
            Thread t1 = new Thread(login);
            t1.Start();

        }

        private void saveMov()
        {
            string nombre1 = string.Empty;
            Dispatcher.Invoke(() =>
            {
                nombre1 = TxtUsuario.Text;
            });

            string operacion = "INSERT INTO movimientos (emailusuario, tipomovimiento, fecha) VALUES (@email, 'Inicio de sesión', CURRENT_DATE)";
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    using (NpgsqlCommand command = new NpgsqlCommand(operacion, connection))
                    {
                        command.Parameters.AddWithValue("@email", nombre1);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            
        }
        private void login()
        {
            //ScreenInicio screeninicio = new ScreenInicio();
            string usuario = string.Empty;
            string password = string.Empty;
            Dispatcher.Invoke(() =>
            {
                usuario = TxtUsuario.Text;
                password = TxtPassword.Password;


            });
            string consulta = "SELECT email ,nombre, rol FROM usuarios  WHERE email = @usuario AND password = @password";
            try
            {
                NpgsqlConnection conexion = new NpgsqlConnection(connectionString);
                NpgsqlCommand comando = new NpgsqlCommand(consulta, conexion);
                conexion.Open();
                comando.Parameters.AddWithValue("@usuario", usuario);
                comando.Parameters.AddWithValue("@password", password);
                NpgsqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    email= reader.GetString(0);
                    nombre = reader.GetString(1);
                    rol = reader.GetString(2);
                    //System.Windows.MessageBox.Show("Inicio de sesión correcto");
                    exito = true;
                    

                    conexion.Close();
                    Thread t2 = new Thread(saveMov);
                    t2.Start();
                }
                else
                {
                    exito = false;
                    System.Windows.MessageBox.Show("Credenciales erroneas");
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            Dispatcher.Invoke(() =>
            {
                s1.LblRol.Content = rol;
                s1.LabelNombre.Content="Usuario: " + nombre + "  ---  Rol: " + rol;
                s1.LabelUserInicio.Content = TxtUsuario.Text;
                if (rol == "Administrador" || rol == "Responsable")
                {
                    s1.BtUsers.Visibility = Visibility.Visible;
                }
                else
                {
                    s1.BtUsers.Visibility = Visibility.Hidden;


                }
                if (exito == true)
                {
                    this.Close();
                    s1.Show();
                }
            });
            
        }

        private void btRegistro_Click(object sender, RoutedEventArgs e)
        {
            Registro registro = new Registro();
            registro.Show();
            this.Close();
        }

    }
}

