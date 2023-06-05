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
    /// Lógica de interacción para AddMedicamento.xaml
    /// </summary>
    public partial class AddMedicamento : Window
    {
        private string connectionString = "Server=localhost;Database=Proyecto Miguel Ballesteros 2023;User Id=miguel;Password=miguel;";

        public AddMedicamento()
        {
            InitializeComponent();
        }

        private void BTCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BTGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (TxtNombre.Text == "" || TxtPrecio.Text == "" || TxtStock.Text == "")
            {
                MessageBox.Show("Los campos Nombre, Precio y Stock son obligatorios.");
            }
            else {
                Thread t1 = new Thread(addMed);
                t1.Start();
            }
            
        }

        private void addMed()
        {
            string nombre = string.Empty;
            string descripcion = string.Empty;
            int stock = 0;
            double precio = 0;
            Dispatcher.Invoke(() =>
            {
                nombre = TxtNombre.Text;
                descripcion = TxtDescripción.Text;
                stock = Int32.Parse(TxtStock.Text);
                precio = Double.Parse(TxtPrecio.Text);
            });
            
                string operacion = "INSERT INTO medicamentos (nombre, descripcion, precio, stock) VALUES (@Nombre, @Descripcion, @Precio, @Stock)";
                try
                {
                    using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                    {
                        using (NpgsqlCommand command = new NpgsqlCommand(operacion, connection))
                        {
                            command.Parameters.AddWithValue("@Nombre", nombre);
                            command.Parameters.AddWithValue("@Descripcion", descripcion);
                            command.Parameters.AddWithValue("@Stock", stock);
                            command.Parameters.AddWithValue("@Precio", precio);
                            connection.Open();
                            command.ExecuteNonQuery();
                            connection.Close();
                            MessageBox.Show("Medicamento añadido correctamente");
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
        private void saveMov()
        {
            string nombre1 = string.Empty;
            Dispatcher.Invoke(() =>
            {
                nombre1 = LblEmail.Content.ToString();
            });

            string operacion = "INSERT INTO movimientos (emailusuario, tipomovimiento, fecha) VALUES (@email, 'Crear nuevo medicamento', CURRENT_DATE)";
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

        private void TxtStock_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool entero = EsEntero(TxtStock.Text);
            if (entero == false)
            {
                MessageBox.Show("El campo stock tiene que ser un número entero.");
                TxtStock.Text = "";
            }
        }

        private void TxtPrecio_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool esdouble = EsDouble(TxtPrecio.Text);
            if (esdouble == false)
            {
                MessageBox.Show("El campo precio tiene que ser un double.");
                TxtPrecio.Text = "";
            }
        }
        private bool EsEntero(string texto)
        {
            int numero;
            return int.TryParse(texto, out numero);
        }
        private bool EsDouble(string texto)
        {
            double numero;
            return double.TryParse(texto, out numero);
        }
    }
}
