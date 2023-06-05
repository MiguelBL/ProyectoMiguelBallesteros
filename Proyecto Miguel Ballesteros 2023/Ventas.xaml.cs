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
    /// Lógica de interacción para Ventas.xaml
    /// </summary>
    public partial class Ventas : Window
    {
        private string connectionString = "Server=localhost;Database=Proyecto Miguel Ballesteros 2023;User Id=miguel;Password=miguel;";
        private List<DetallesVenta> listaVenta = new List<DetallesVenta>();
        private NewVenta nv;
        public Ventas()
        {
            InitializeComponent();
        }

        private void TxtMed1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (LblMed1.Content.Equals("Medicamento 1"))
            {
                TxtMed1.Text = "";
            }
            bool entero = EsEntero(TxtMed1.Text);
            if (entero == true)
            {
                if (Int32.Parse(LblMed1Reg.Content.ToString()) + Int32.Parse(LblMaxMed1.Content.ToString()) < Int32.Parse(TxtMed1.Text) && !LblMed1.Content.Equals("Medicamento 1"))
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

        private void TxtMed2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (LblMed2.Content.Equals("Medicamento 2"))
            {
                TxtMed2.Text = "";
            }
            bool entero = EsEntero(TxtMed2.Text);
            if (entero == true)
            {
                if (Int32.Parse(LblMed2Reg.Content.ToString()) + Int32.Parse(LblMaxMed2.Content.ToString()) < Int32.Parse(TxtMed2.Text) && !LblMed2.Content.Equals("Medicamento 2"))
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

        private void TxtMed3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (LblMed3.Content.Equals("Medicamento 3"))
            {
                TxtMed3.Text = "";
            }
            bool entero = EsEntero(TxtMed3.Text);
            if (entero == true)
            {
                if (Int32.Parse(LblMed3Reg.Content.ToString()) + Int32.Parse(LblMaxMed3.Content.ToString()) < Int32.Parse(TxtMed3.Text) && !LblMed3.Content.Equals("Medicamento 3"))
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

        private void BTActualizar_Click(object sender, RoutedEventArgs e)
        {
            Thread t2 = new Thread(actualizarVenta);
            t2.Start();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LblMed1.Content = "Medicamento 1";
            LblMed2.Content = "Medicamento 2";
            LblMed3.Content = "Medicamento 3";
            LblPMed1.Content = "";
            LblPMed2.Content = "";
            LblPMed3.Content = "";
            LblMed1Reg.Content = "";
            LblMed2Reg.Content = "";
            LblMed3Reg.Content = "";
            LblMaxMed1.Content = "";
            LblMaxMed2.Content = "";
            LblMaxMed3.Content = "";
            TxtMed1.Text = "";
            TxtMed2.Text = "";
            TxtMed3.Text = "";

            Thread t1 = new Thread(detallesVenta);
            t1.Start();
        }
        private bool EsEntero(string cadena)
        {
            int numero;
            return int.TryParse(cadena, out numero);
        }
        private void detallesVenta()
        {
            listaVenta.Clear();
            int id = 0;
            Venta ventaS = new Venta();
            Dispatcher.Invoke(() =>
            {
                ventaS = (Venta)LVVentas.SelectedItem;
                if (LVVentas.SelectedItem != null)
                {
                    id = ventaS.id;
                }

            });


            string consulta = "SELECT ventaid, medicamentoid ,cantidad FROM detallesventa  WHERE ventaid = @VentaId";
            try
            {
                NpgsqlConnection conexion = new NpgsqlConnection(connectionString);
                NpgsqlCommand comando = new NpgsqlCommand(consulta, conexion);
                conexion.Open();
                comando.Parameters.AddWithValue("@VentaId", id);
                NpgsqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    int ventaid = reader.GetInt32(0);
                    string medicamentoid = reader.GetString(1);
                    int cantidad = reader.GetInt32(2);
                    DetallesVenta dv = new DetallesVenta(ventaid, medicamentoid, cantidad);
                    listaVenta.Add(dv);
                }

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            //MessageBox.Show(listaCompra.Count.ToString());
            int n = 0;
            int stock = 0;
            int precio = 0;
            while (n < listaVenta.Count)
            {
                DetallesVenta dv1 = listaVenta[n];
                if (n == 0)
                {
                    string consulta0 = "SELECT stock, precio FROM medicamentos  WHERE nombre = @Nombre";
                    try
                    {
                        NpgsqlConnection conexion = new NpgsqlConnection(connectionString);
                        NpgsqlCommand comando = new NpgsqlCommand(consulta0, conexion);
                        conexion.Open();
                        comando.Parameters.AddWithValue("@Nombre", dv1.medicamentoid);
                        NpgsqlDataReader reader = comando.ExecuteReader();
                        while (reader.Read())
                        {
                            stock = reader.GetInt32(0);
                            precio = reader.GetInt32(1);
                        }

                    }
                    catch (Exception ex)
                    {
                        System.Windows.MessageBox.Show(ex.Message);
                    }
                    Dispatcher.Invoke(() =>
                    {
                        //int indice = CBMed1.Items.IndexOf(dc1.medicamentoid);
                        LblMed1.Content = dv1.medicamentoid;
                        //CBMed1.SelectedIndex=indice;
                        LblPMed1.Content = precio;
                        LblMed1Reg.Content = dv1.cantidad;
                        LblMaxMed1.Content = stock;
                        //MessageBox.Show(indice.ToString());

                    });
                    n++;
                }
                else if (n == 1)
                {
                    string consulta0 = "SELECT stock, precio FROM medicamentos  WHERE nombre = @Nombre";
                    try
                    {
                        NpgsqlConnection conexion = new NpgsqlConnection(connectionString);
                        NpgsqlCommand comando = new NpgsqlCommand(consulta0, conexion);
                        conexion.Open();
                        comando.Parameters.AddWithValue("@Nombre", dv1.medicamentoid);
                        NpgsqlDataReader reader = comando.ExecuteReader();
                        while (reader.Read())
                        {
                            stock = reader.GetInt32(0);
                            precio = reader.GetInt32(1);
                        }

                    }
                    catch (Exception ex)
                    {
                        System.Windows.MessageBox.Show(ex.Message);
                    }
                    Dispatcher.Invoke(() =>
                    {
                        LblMed2.Content = dv1.medicamentoid;
                        LblPMed2.Content = precio;
                        LblMed2Reg.Content = dv1.cantidad;
                        LblMaxMed2.Content = stock;

                        //MessageBox.Show(indice.ToString());
                    });
                    n++;
                }
                else if (n == 2)
                {
                    string consulta0 = "SELECT stock, precio FROM medicamentos  WHERE nombre = @Nombre";
                    try
                    {
                        NpgsqlConnection conexion = new NpgsqlConnection(connectionString);
                        NpgsqlCommand comando = new NpgsqlCommand(consulta0, conexion);
                        conexion.Open();
                        comando.Parameters.AddWithValue("@Nombre", dv1.medicamentoid);
                        NpgsqlDataReader reader = comando.ExecuteReader();
                        while (reader.Read())
                        {
                            stock = reader.GetInt32(0);
                            precio = reader.GetInt32(1);
                        }

                    }
                    catch (Exception ex)
                    {
                        System.Windows.MessageBox.Show(ex.Message);
                    }

                    Dispatcher.Invoke(() =>
                    {
                        LblMed3.Content = dv1.medicamentoid;
                        LblPMed3.Content = precio;
                        LblMed3Reg.Content = dv1.cantidad;
                        LblMaxMed3.Content = stock;
                        //MessageBox.Show(indice.ToString());
                    });
                    n++;
                }
            }
        }
        private void actualizarVenta()
        {
            NpgsqlConnection conexion = new NpgsqlConnection(connectionString);
            string medicamento = string.Empty;
            int cantidad = 0;
            int total = 0;
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
                ventaS = (Venta)LVVentas.SelectedItem;
                Med1 = TxtMed1.Text;
                Med2 = TxtMed2.Text;
                Med3 = TxtMed3.Text;
            });
            id = ventaS.id;
            Dispatcher.Invoke(() =>
            {
                if (!LblMed1.Content.Equals("Medicamento 1"))
                {
                    if (!TxtMed1.Text.Equals(""))
                    {


                        total = total + (Int32.Parse(LblPMed1.Content.ToString()) * Int32.Parse(TxtMed1.Text)); ;
                        //MessageBox.Show(TxtMed1.Text);
                    }
                    else
                    {


                        total = total + (Int32.Parse(LblPMed1.Content.ToString()) * Int32.Parse(LblMed1Reg.Content.ToString()));



                    }

                }
            });
            Dispatcher.Invoke(() =>
            {
                if (!LblMed2.Content.Equals("Medicamento 2"))
                {
                    if (!TxtMed2.Text.Equals(""))
                    {

                        total = total + (Int32.Parse(LblPMed2.Content.ToString()) * Int32.Parse(TxtMed2.Text));

                    }
                    else
                    {

                        total = total + (Int32.Parse(LblPMed2.Content.ToString()) * Int32.Parse(LblMed2Reg.Content.ToString()));


                    }

                }
            });
            Dispatcher.Invoke(() =>
            {
                if (!LblMed3.Content.Equals("Medicamento 3"))
                {

                    if (!TxtMed3.Text.Equals(""))
                    {

                        total = total + (Int32.Parse(LblPMed3.Content.ToString()) * Int32.Parse(TxtMed3.Text));

                    }
                    else
                    {

                        total = total + (Int32.Parse(LblPMed3.Content.ToString()) * Int32.Parse(LblMed3Reg.Content.ToString()));


                    }
                }
            });
            try
            {
                string updateTotal = "UPDATE compras SET total = @Total WHERE  id = @Id";
                NpgsqlCommand commandTotal = new NpgsqlCommand(updateTotal, conexion);
                commandTotal.Parameters.AddWithValue("@Total", total);
                commandTotal.Parameters.AddWithValue("@Id", ventaS.id);
                conexion.Open();
                commandTotal.ExecuteNonQuery();
                conexion.Close();
                MessageBox.Show("Compra acutualizada");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conexion.Close();
            }

            Dispatcher.Invoke(() =>
            {
                if (!LblMed1.Content.Equals("Medicamento 1") && TxtMed1.Text!="")
                {

                    cantidad = Int32.Parse(TxtMed1.Text);
                    medicamento = LblMed1.Content.ToString();
                    stock = Int32.Parse(LblMaxMed1.Content.ToString()) - Int32.Parse(TxtMed1.Text) + Int32.Parse(LblMed1Reg.Content.ToString());


                    try
                    {
                        string operacionMed = "UPDATE medicamentos SET stock = @Stock WHERE nombre = @Nombre";
                        string operacion = "UPDATE detallescompra SET cantidad = @Cantidad WHERE  medicamentoid = @medicamentoid";

                        NpgsqlCommand comandUpdateMed1 = new NpgsqlCommand(operacion, conexion);
                        NpgsqlCommand comandUpdateMedStock = new NpgsqlCommand(operacionMed, conexion);
                        comandUpdateMed1.Parameters.AddWithValue("@Cantidad", cantidad);
                        comandUpdateMed1.Parameters.AddWithValue("@medicamentoid", medicamento);
                        comandUpdateMedStock.Parameters.AddWithValue("@Stock", stock);
                        comandUpdateMedStock.Parameters.AddWithValue("@Nombre", medicamento);

                        conexion.Open();
                        comandUpdateMed1.ExecuteNonQuery();
                        comandUpdateMedStock.ExecuteNonQuery();
                        conexion.Close();
                        MessageBox.Show("Medicamento 1 actualizado");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            });
            Dispatcher.Invoke(() =>
            {
                if (!LblMed2.Content.Equals("Medicamento 2") && TxtMed2.Text != "")
                {

                    cantidad = int.Parse(TxtMed2.Text);
                    stock = Int32.Parse(LblMaxMed2.Content.ToString()) - Int32.Parse(TxtMed2.Text) + Int32.Parse(LblMed2Reg.Content.ToString());
                    medicamento = LblMed2.Content.ToString();
                    //MessageBox.Show(medicamento + "---" + stock);


                    try
                    {
                        string operacion = "UPDATE detallescompra SET cantidad = @Cantidad WHERE  medicamentoid = @medicamentoid";
                        string operacionMed = "UPDATE medicamentos SET stock = @Stock WHERE nombre = @Nombre";
                        NpgsqlCommand comandUpdateMedStock = new NpgsqlCommand(operacionMed, conexion);
                        NpgsqlCommand comandUpdateMed2 = new NpgsqlCommand(operacion, conexion);
                        comandUpdateMed2.Parameters.AddWithValue("@Cantidad", cantidad);
                        comandUpdateMed2.Parameters.AddWithValue("@medicamentoid", medicamento);
                        comandUpdateMedStock.Parameters.AddWithValue("@Stock", stock);
                        comandUpdateMedStock.Parameters.AddWithValue("@Nombre", medicamento);

                        conexion.Open();
                        comandUpdateMed2.ExecuteNonQuery();
                        comandUpdateMedStock.ExecuteNonQuery();
                        conexion.Close();
                        MessageBox.Show("Medicamento 2 actualizado");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            });
            Dispatcher.Invoke(() =>
            {
                if (!LblMed3.Content.Equals("Medicamento 3") && TxtMed3.Text != "")
                {

                    cantidad = int.Parse(TxtMed3.Text);
                    medicamento = LblMed3.Content.ToString();
                    stock = Int32.Parse(LblMaxMed3.Content.ToString()) - Int32.Parse(TxtMed3.Text) + Int32.Parse(LblMed3Reg.Content.ToString());


                    try
                    {
                        string operacion = "UPDATE detallescompra SET cantidad = @Cantidad WHERE  medicamentoid = @medicamentoid";
                        string operacionMed = "UPDATE medicamentos SET stock = @Stock WHERE nombre = @Nombre";

                        NpgsqlCommand comandUpdateMedStock = new NpgsqlCommand(operacionMed, conexion);
                        NpgsqlCommand comandUpdateMed3 = new NpgsqlCommand(operacion, conexion);
                        comandUpdateMed3.Parameters.AddWithValue("@Cantidad", cantidad);
                        comandUpdateMed3.Parameters.AddWithValue("@medicamentoid", medicamento);
                        comandUpdateMedStock.Parameters.AddWithValue("@Stock", stock);
                        comandUpdateMedStock.Parameters.AddWithValue("@Nombre", medicamento);

                        conexion.Open();
                        comandUpdateMed3.ExecuteNonQuery();
                        comandUpdateMedStock.ExecuteNonQuery();
                        conexion.Close();
                        MessageBox.Show("Medicamento 3 actualizado");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            });
            MessageBox.Show("Actualizado con exito");
            Dispatcher.Invoke(() =>
            {
                TxtMed1.Text = "";
                TxtMed2.Text = "";
                TxtMed2.Text = "";
                LblMaxMed1.Content = "";
                LblMaxMed2.Content = "";
                LblMaxMed3.Content = "";
                LblMed1Reg.Content = "";
                LblMed2Reg.Content = "";
                LblMed3Reg.Content = "";
                LblPMed1.Content = "";
                LblPMed2.Content = "";
                LblPMed3.Content = "";
                LblMed1.Content = "Medicamento 1";
                LblMed2.Content = "Medicamento 2";
                LblMed3.Content = "Medicamento 3";
                LVVentas.SelectedItem = null;
                LVVentas.Items.Clear();
                Thread actDatos = new Thread(datosLVVentas);
                actDatos.Start();
                Thread saveReg = new Thread(saveMov);
                saveReg.Start();
            });
        }
        private void datosLVVentas()
        {

           

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
                                    this.LVVentas.Items.Add(v);
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


        private void saveMov()
        {
            string email = string.Empty;

            Dispatcher.Invoke(() =>
            {
                email = LblEmail.Content.ToString();
            });
            string operacion = "INSERT INTO movimientos (emailusuario, tipomovimiento, fecha) VALUES (@email, 'Actualizar Venta', CURRENT_DATE)";
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

        private void BTNewVenta_Click_1(object sender, RoutedEventArgs e)
        {
            nv = new NewVenta();
            nv.LblEmail.Content = LblEmail.Content;
            nv.Show();
            nv = null;
        }
    }
}
