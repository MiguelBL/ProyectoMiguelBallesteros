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
    /// Lógica de interacción para NewVenta.xaml
    /// </summary>
    public partial class NewVenta : Window
    {
        private string connectionString = "Server=localhost;Database=Proyecto Miguel Ballesteros 2023;User Id=miguel;Password=miguel;";

        public NewVenta()
        {
            InitializeComponent();
            Thread t1 = new Thread(rellenarComboBox);
            t1.Start();
            Thread t2 = new Thread(rellenarCBClientes);
            t2.Start();
        }

        private void BTGuardar_Click(object sender, RoutedEventArgs e)
        {
            if ((CBMed1.SelectedIndex != -1 && TxtMed1.Text == "") || (CBMed2.SelectedIndex != -1 && TxtMed2.Text == "") || (CBMed3.SelectedIndex != -1 && TxtMed3.Text == "") || CBClientes.SelectedIndex == -1)
            {
                MessageBox.Show("Compruebe que ha introducido los registros, si ha seleccionado un medicamento está obligado a poner su cantidad");
            }
            else
            {
                Thread t1 = new Thread(insertarVenta);
                t1.Start();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BTGuardarCli_Click(object sender, RoutedEventArgs e)
        {
            if(TxtNombre.Text=="" || TxtDNI.Text == "" || TxtDireccion.Text == "" || TxtTelefono.Text == "")
            {
                MessageBox.Show("Tienes que rellenar todos los campos.");
            }
            else
            {
                Thread t4 = new Thread(saveCliente);
                t4.Start();
                //this.CBClientes.Items.Clear();
                //Thread t2 = new Thread(rellenarCBClientes);
                //t2.Start();
            }
            
        }

        private void rellenarComboBox()
        {

            string consulta = "SELECT nombre FROM medicamentos";
            try
            {
                NpgsqlConnection conexion = new NpgsqlConnection(connectionString);
                NpgsqlCommand comando = new NpgsqlCommand(consulta, conexion);
                conexion.Open();

                NpgsqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    string nobmre = reader.GetString(0);
                    Dispatcher.Invoke(() =>
                    {
                        this.CBMed1.Items.Add(nobmre);
                        this.CBMed2.Items.Add(nobmre);
                        this.CBMed3.Items.Add(nobmre);
                    });
                }

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }

        }

        private void rellenarCBClientes()
        {

            string consulta = "SELECT dni FROM clientes";
            try
            {
                NpgsqlConnection conexion = new NpgsqlConnection(connectionString);
                NpgsqlCommand comando = new NpgsqlCommand(consulta, conexion);
                conexion.Open();

                NpgsqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    string dni = reader.GetString(0);
                    Dispatcher.Invoke(() =>
                    {
                        this.CBClientes.Items.Add(dni);
                    });
                }

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }

        }

        private void TxtMed1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (CBMed1.SelectedIndex == -1)
            {
                TxtMed1.Text = "";
            }
            else
            {
                bool entero = EsEntero(TxtMed1.Text);
                if (entero == true)
                {
                    if (Int32.Parse(LblMaxMed1.Content.ToString()) < Int32.Parse(TxtMed1.Text) && CBMed1.SelectedIndex != -1)
                    {
                        MessageBox.Show("No puedes añadir más cantidad que la que hay en stock");
                        TxtMed1.Text = "";
                    }
                }
                else
                {
                    //MessageBox.Show("Tienes que poner una cantidad. No puedes escribir nada.");
                    TxtMed1.Text = "";
                }
            }
        }

        private void TxtMed2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (CBMed2.SelectedIndex == -1)
            {
                TxtMed2.Text = "";
            }
            else
            {
                bool entero = EsEntero(TxtMed2.Text);
                if (entero == true)
                {
                    if (Int32.Parse(LblMaxMed2.Content.ToString()) < Int32.Parse(TxtMed2.Text) && CBMed2.SelectedIndex != -1)
                    {
                        MessageBox.Show("No puedes añadir más cantidad que la que hay en stock");
                        TxtMed2.Text = "";
                    }
                }
                else
                {
                    //MessageBox.Show("Tienes que poner una cantidad. No puedes escribir nada.");
                    TxtMed2.Text = "";
                }
            }
        }

        private void TxtMed3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (CBMed3.SelectedIndex == -1)
            {
                TxtMed3.Text = "";
            }
            else
            {
                bool entero = EsEntero(TxtMed3.Text);
                if (entero == true)
                {
                    if (Int32.Parse(LblMaxMed3.Content.ToString()) < Int32.Parse(TxtMed3.Text) && CBMed3.SelectedIndex != -1)
                    {
                        MessageBox.Show("No puedes añadir más cantidad que la que hay en stock");
                        TxtMed3.Text = "";
                    }
                }
                else
                {
                    //MessageBox.Show("Tienes que poner una cantidad. No puedes escribir nada.");
                    TxtMed3.Text = "";
                }
            }
        }

        private void CBMed1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CBMed1.SelectedIndex == CBMed2.SelectedIndex && CBMed2.SelectedIndex != -1)
            {
                MessageBox.Show("No puedes seleccionar el mismo medicamento varias veces.");
                CBMed1.SelectedIndex = -1;
                TxtMed1.Text = "";
                LblMaxMed1.Content = "";
                LblPMed1.Content = "";
                
            }
            else if (CBMed1.SelectedIndex == CBMed3.SelectedIndex && CBMed3.SelectedIndex != -1)
            {
                MessageBox.Show("No puedes seleccionar el mismo medicamento varias veces.");
                CBMed1.SelectedIndex = -1;
                TxtMed1.Text = "";
                LblMaxMed1.Content = "";
                LblPMed1.Content = "";
            }
            else if (CBMed1.SelectedIndex !=-1)
            {
                Thread t2 = new Thread(rellenarDatosCB1);
                t2.Start();
            }
        }

        private void CBMed2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CBMed2.SelectedIndex == CBMed1.SelectedIndex && CBMed1.SelectedIndex != -1)
            {
                MessageBox.Show("No puedes seleccionar el mismo medicamento varias veces.");
                CBMed2.SelectedIndex = -1;
                TxtMed2.Text = "";
                LblMaxMed2.Content = "";
                LblPMed2.Content = "";
            }
            else if (CBMed2.SelectedIndex == CBMed3.SelectedIndex && CBMed3.SelectedIndex != -1)
            {
                MessageBox.Show("No puedes seleccionar el mismo medicamento varias veces.");
                CBMed2.SelectedIndex = -1;
                TxtMed2.Text = "";
                LblMaxMed2.Content = "";
                LblPMed2.Content = "";
            }else if (CBMed2.SelectedIndex != 1)
            {
                Thread t3 = new Thread(rellenarDatosCB2);
                t3.Start();
            }
        }

        private void CBMed3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CBMed3.SelectedIndex == CBMed1.SelectedIndex && CBMed1.SelectedIndex != -1)
            {
                MessageBox.Show("No puedes seleccionar el mismo medicamento varias veces.");
                CBMed3.SelectedIndex = -1;
                TxtMed3.Text = "";
                LblMaxMed3.Content = "";
                LblPMed3.Content = "";
            }
            else if (CBMed3.SelectedIndex == CBMed2.SelectedIndex && CBMed2.SelectedIndex != -1)
            {
                MessageBox.Show("No puedes seleccionar el mismo medicamento varias veces.");
                CBMed3.SelectedIndex = -1;
                TxtMed3.Text = "";
                LblMaxMed3.Content = "";
                LblPMed3.Content = "";
            }else if (CBMed3.SelectedIndex != 1)
            {
                Thread t4 = new Thread(rellenarDatosCB3);
                t4.Start();
            }
        }

        private void rellenarDatosCB1()
        {
            string medicamento = string.Empty;
            Dispatcher.Invoke(() =>
            {
                if(CBMed1.SelectedIndex != -1)
                {
                    medicamento = CBMed1.SelectedItem.ToString();
                }
            });
            string consulta = "SELECT precio, stock FROM medicamentos  WHERE nombre = @Nombre";
            try
            {
                NpgsqlConnection conexion = new NpgsqlConnection(connectionString);
                NpgsqlCommand comando = new NpgsqlCommand(consulta, conexion);
                conexion.Open();
                comando.Parameters.AddWithValue("@Nombre", medicamento);
                NpgsqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    double precio = reader.GetDouble(0);
                    int stock = reader.GetInt32(1);
                    Dispatcher.Invoke(() =>
                    {
                        LblMaxMed1.Content = stock;
                        LblPMed1.Content = precio;
                    });
                }
                conexion.Close();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }
        private void rellenarDatosCB2()
        {
            string medicamento = string.Empty;
            Dispatcher.Invoke(() =>
            {
                if (CBMed2.SelectedIndex != -1)
                {
                    medicamento = CBMed2.SelectedItem.ToString();
                }
            });
            string consulta = "SELECT precio, stock FROM medicamentos  WHERE nombre = @Nombre";
            try
            {
                NpgsqlConnection conexion = new NpgsqlConnection(connectionString);
                NpgsqlCommand comando = new NpgsqlCommand(consulta, conexion);
                conexion.Open();
                comando.Parameters.AddWithValue("@Nombre", medicamento);
                NpgsqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    double precio = reader.GetDouble(0);
                    int stock = reader.GetInt32(1);
                    Dispatcher.Invoke(() =>
                    {
                        LblMaxMed2.Content = stock;
                        LblPMed2.Content = precio;
                    });
                }
                conexion.Close();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        private void rellenarDatosCB3()
        {
            string medicamento = string.Empty;
            Dispatcher.Invoke(() =>
            {
                if (CBMed3.SelectedIndex != -1)
                {
                    medicamento = CBMed3.SelectedItem.ToString();
                }
            });
            string consulta = "SELECT precio, stock FROM medicamentos  WHERE nombre = @Nombre";
            try
            {
                NpgsqlConnection conexion = new NpgsqlConnection(connectionString);
                NpgsqlCommand comando = new NpgsqlCommand(consulta, conexion);
                conexion.Open();
                comando.Parameters.AddWithValue("@Nombre", medicamento);
                NpgsqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    double precio = reader.GetDouble(0);
                    int stock = reader.GetInt32(1);
                    Dispatcher.Invoke(() =>
                    {
                        LblMaxMed3.Content = stock;
                        LblPMed3.Content = precio;
                    });
                }
                conexion.Close();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        private void insertarVenta()
        {
            NpgsqlConnection conexion = new NpgsqlConnection(connectionString);
            string medicamento = string.Empty;
            int cantidad = 0;
            int idventa = 0;
            double total = 0;
            int total1 = 0;
            int total2 = 0;
            int stock = 0;
            int id;
            string Med1 = string.Empty;
            string Med2 = string.Empty;
            string Med3 = string.Empty;
            Venta ventaS = new Venta();
            
            Dispatcher.Invoke(() =>
            {
                if (CBMed1.SelectedIndex!=-1)
                {
                    total = total + (double.Parse(LblPMed1.Content.ToString()) * double.Parse(TxtMed1.Text));
                }
            });
            Dispatcher.Invoke(() =>
            {
                if (CBMed2.SelectedIndex != -1)
                {
                    total = total + (double.Parse(LblPMed2.Content.ToString()) * double.Parse(TxtMed2.Text));
                }
            });
            Dispatcher.Invoke(() =>
            {
                if (CBMed3.SelectedIndex != -1)
                {
                    total = total + (double.Parse(LblPMed3.Content.ToString()) * double.Parse(TxtMed3.Text));
                }
            });

            string email = string.Empty;
            string cliente = string.Empty;
            Dispatcher.Invoke(() =>
            {
                email = LblEmail.Content.ToString();
                cliente = CBClientes.SelectedItem.ToString();
            });
            try
            {
                string updateTotal = "INSERT INTO ventas (fecha, total, username, clienteid) VALUES (CURRENT_DATE, @Total, @Username, @ClienteId)";
                NpgsqlCommand commandTotal = new NpgsqlCommand(updateTotal, conexion);
                commandTotal.Parameters.AddWithValue("@Total", total);
                commandTotal.Parameters.AddWithValue("@Username", email);
                commandTotal.Parameters.AddWithValue("@ClienteId", cliente);
                conexion.Open();
                commandTotal.ExecuteNonQuery();
                conexion.Close();
                MessageBox.Show("Venta insertada.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conexion.Close();
            }

            try
            {
                string consulta = "SELECT id FROM ventas ORDER BY id DESC LIMIT 1;";
                NpgsqlCommand commandTotal = new NpgsqlCommand(consulta, conexion);
                conexion.Open();
                NpgsqlDataReader reader = commandTotal.ExecuteReader();
                while (reader.Read())
                {
                    idventa = reader.GetInt32(0);
                }

                conexion.Close();
                //MessageBox.Show("Compra acutualizada");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conexion.Close();
            }

            Dispatcher.Invoke(() =>
            {
                if (CBMed1.SelectedIndex!=-1)
                {

                    cantidad = Int32.Parse(TxtMed1.Text);
                    medicamento = CBMed1.SelectedItem.ToString();
                    stock = Int32.Parse(LblMaxMed1.Content.ToString()) - Int32.Parse(TxtMed1.Text);


                    try
                    {
                        string operacionMed = "UPDATE medicamentos SET stock = @Stock WHERE nombre = @Nombre";
                        string operacion = "INSERT INTO detallesventa (ventaid, medicamentoid, cantidad) VALUES (@VentaId, @Medicamento, @Cantidad)";

                        NpgsqlCommand comandUpdateMed1 = new NpgsqlCommand(operacion, conexion);
                        NpgsqlCommand comandUpdateMedStock = new NpgsqlCommand(operacionMed, conexion);
                        comandUpdateMed1.Parameters.AddWithValue("@Cantidad", cantidad);
                        comandUpdateMed1.Parameters.AddWithValue("@Medicamento", medicamento);
                        comandUpdateMed1.Parameters.AddWithValue("@VentaId", idventa);
                        comandUpdateMedStock.Parameters.AddWithValue("@Stock", stock);
                        comandUpdateMedStock.Parameters.AddWithValue("@Nombre", medicamento);

                        conexion.Open();
                        comandUpdateMed1.ExecuteNonQuery();
                        comandUpdateMedStock.ExecuteNonQuery();
                        conexion.Close();
                        MessageBox.Show("Medicamento 1 insertado");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            });
            Dispatcher.Invoke(() =>
            {
                if (CBMed2.SelectedIndex != -1)
                {

                    cantidad = int.Parse(TxtMed2.Text);
                    stock = int.Parse(LblMaxMed2.Content.ToString()) - int.Parse(TxtMed2.Text);
                    medicamento = CBMed2.SelectedItem.ToString();
                    //MessageBox.Show(medicamento + "---" + stock);


                    try
                    {
                        string operacion = "INSERT INTO detallesventa (ventaid, medicamentoid, cantidad) VALUES (@VentaId, @Medicamento, @Cantidad)";
                        string operacionMed = "UPDATE medicamentos SET stock = @Stock WHERE nombre = @Nombre";
                        NpgsqlCommand comandUpdateMedStock = new NpgsqlCommand(operacionMed, conexion);
                        NpgsqlCommand comandUpdateMed2 = new NpgsqlCommand(operacion, conexion);
                        comandUpdateMed2.Parameters.AddWithValue("@Cantidad", cantidad);
                        comandUpdateMed2.Parameters.AddWithValue("@Medicamento", medicamento);
                        comandUpdateMed2.Parameters.AddWithValue("@VentaId", idventa);
                        comandUpdateMedStock.Parameters.AddWithValue("@Stock", stock);
                        comandUpdateMedStock.Parameters.AddWithValue("@Nombre", medicamento);

                        conexion.Open();
                        comandUpdateMed2.ExecuteNonQuery();
                        comandUpdateMedStock.ExecuteNonQuery();
                        conexion.Close();
                        MessageBox.Show("Medicamento 2 insertado");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            });
            Dispatcher.Invoke(() =>
            {
                if (CBMed3.SelectedIndex != -1)
                {

                    cantidad = int.Parse(TxtMed3.Text);
                    medicamento = CBMed3.SelectedItem.ToString();
                    stock =  int.Parse(LblMaxMed3.Content.ToString()) - int.Parse(TxtMed3.Text);


                    try
                    {
                        string operacion = "INSERT INTO detallesventa (ventaid, medicamentoid, cantidad) VALUES (@VentaId, @Medicamento, @Cantidad)";
                        string operacionMed = "UPDATE medicamentos SET stock = @Stock WHERE nombre = @Nombre";

                        NpgsqlCommand comandUpdateMedStock = new NpgsqlCommand(operacionMed, conexion);
                        NpgsqlCommand comandUpdateMed3 = new NpgsqlCommand(operacion, conexion);
                        comandUpdateMed3.Parameters.AddWithValue("@Cantidad", cantidad);
                        comandUpdateMed3.Parameters.AddWithValue("@Medicamento", medicamento);
                        comandUpdateMed3.Parameters.AddWithValue("@VentaId", idventa);
                        comandUpdateMedStock.Parameters.AddWithValue("@Stock", stock);
                        comandUpdateMedStock.Parameters.AddWithValue("@Nombre", medicamento);

                        conexion.Open();
                        comandUpdateMed3.ExecuteNonQuery();
                        comandUpdateMedStock.ExecuteNonQuery();
                        conexion.Close();
                        MessageBox.Show("Medicamento 3 insertado");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            });
            MessageBox.Show("Insertado con exito");
            Thread t6 = new Thread(saveMov);
            t6.Start();
            Dispatcher.Invoke(() =>
            {
                TxtMed1.Text = "";
                TxtMed2.Text = "";
                TxtMed2.Text = "";
                LblMaxMed1.Content = "";
                LblMaxMed2.Content = "";
                LblMaxMed3.Content = "";
                LblPMed1.Content = "";
                LblPMed2.Content = "";
                LblPMed3.Content = "";
                LblMed1.Content = "Medicamento 1";
                LblMed2.Content = "Medicamento 2";
                LblMed3.Content = "Medicamento 3";
                this.Close();

            });
        }

        private bool EsEntero(string texto)
        {
            int numero;
            return int.TryParse(texto, out numero);
        }

        private void saveCliente()
        {
            string nombre = string.Empty;
            string dni = string.Empty;
            string telefono = string.Empty;
            string direccion = string.Empty;
            
            Dispatcher.Invoke(() =>
            {
                nombre = TxtNombre.Text;
                telefono = TxtTelefono.Text;
                direccion = TxtDireccion.Text;
                dni = TxtDNI.Text;
            });
            
                string operacion = "INSERT INTO clientes (dni, nombre, direccion, telefono) VALUES (@Dni, @Nombre, @Direccion, @Telefono)";
                try
                {
                    using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                    {
                        using (NpgsqlCommand command = new NpgsqlCommand(operacion, connection))
                        {
                            command.Parameters.AddWithValue("@Dni", dni);
                            command.Parameters.AddWithValue("@Nombre", nombre);
                            command.Parameters.AddWithValue("@Direccion", direccion);
                            command.Parameters.AddWithValue("@Telefono", telefono);
                            connection.Open();
                            command.ExecuteNonQuery();
                            connection.Close();
                            MessageBox.Show("Cliente creado correctamente");
                            
                            Dispatcher.Invoke(() =>
                            {
                                TxtNombre.Text = "";
                                TxtDNI.Text = "";
                                TxtDireccion.Text = "";
                                TxtTelefono.Text = "";
                                this.CBClientes.Items.Clear();
                                Thread t5 = new Thread(rellenarCBClientes);
                                t5.Start();
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
            string email = string.Empty;

            Dispatcher.Invoke(() =>
            {
                email = LblEmail.Content.ToString();
            });
            string operacion = "INSERT INTO movimientos (emailusuario, tipomovimiento, fecha) VALUES (@email, 'Crear Venta', CURRENT_DATE)";
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
