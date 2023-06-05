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
    /// Lógica de interacción para Registro.xaml
    /// </summary>
    public partial class Registro : Window
    {
        private string connectionString = "Server=localhost;Database=Proyecto Miguel Ballesteros 2023;User Id=miguel;Password=miguel;";

        public Registro()
        {
            InitializeComponent();
        }


        private void BTCancelar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void BTRegistrar_Click(object sender, RoutedEventArgs e)
        {
            Thread t1 = new Thread(insertUser);
            t1.Start();
        }
        private void insertUser()
        {
            
            string nombre = string.Empty;
            string telefono = string.Empty;
            string email = string.Empty;
            string password = string.Empty;
            string direcion = string.Empty;

            Dispatcher.Invoke(() =>
            {
                nombre = TxtNombre.Text;
                telefono = TxtTelefono.Text;
                email = TxtEmail.Text;
                password = TxtPassword.Text;
                direcion = TxtDireccion.Text;
            });
            string operacion = "INSERT INTO usuarios (email, nombre, password, rol, adress, phone) VALUES (@email, @nombre, @password, 'Usuario', @adress, @phone)";
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    using (NpgsqlCommand command = new NpgsqlCommand(operacion, connection))
                    {
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@nombre", nombre);
                        command.Parameters.AddWithValue("@password", password);
                        command.Parameters.AddWithValue("@adress", direcion);
                        command.Parameters.AddWithValue("@phone", telefono);
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Insertado correctamente");
                        Thread t2 = new Thread(saveInsertUser);
                        t2.Start();
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Dispatcher.Invoke(() =>
            {
                ScreenInicio s1 = new ScreenInicio();
                s1.LabelNombre.Content = "Usuaio: " + nombre;
                s1.LabelUserInicio.Content = email;
                s1.BtUsers.Visibility = Visibility.Hidden;
                s1.Show();
                this.Close();
            });
        }

        private void saveInsertUser()
        {
            string email1 = string.Empty;

            Dispatcher.Invoke(() =>
            {
                email1 = TxtEmail.Text;
            });
            string operacion = "INSERT INTO movimientos (emailusuario, tipomovimiento, fecha) VALUES (@email, 'Creación usuaio', CURRENT_DATE)";
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    using (NpgsqlCommand command = new NpgsqlCommand(operacion, connection))
                    {
                        command.Parameters.AddWithValue("@email", email1);
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
    }
}
