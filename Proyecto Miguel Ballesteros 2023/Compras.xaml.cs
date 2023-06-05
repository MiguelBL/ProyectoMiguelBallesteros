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
    /// Lógica de interacción para Compras.xaml
    /// </summary>
    public partial class Compras : Window
    {
        private string connectionString = "Server=localhost;Database=Proyecto Miguel Ballesteros 2023;User Id=miguel;Password=miguel;";
        private List<DetallesCompra> listaCompra = new List<DetallesCompra>();
        private NewCompra nc;
        public Compras()
        {
            InitializeComponent();
            
        }

        private void BTActualizar_Click(object sender, RoutedEventArgs e)
        {
            Thread t3 = new Thread(actualizarCompra);
            t3.Start();
        }

        private void LVCompras_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
            Thread t2 = new Thread(detallesCompra);
            t2.Start();
        }

        /*private void CBMed1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(CBMed1.SelectedIndex == CBMed2.SelectedIndex && CBMed2.SelectedIndex != -1)
            {
                MessageBox.Show("No puedes seleccionar el mismo medicamento varias veces.");
                CBMed1.SelectedIndex = -1;
                TxtMed1.Text = "";
            }else if(CBMed1.SelectedIndex == CBMed3.SelectedIndex && CBMed3.SelectedIndex != -1)
            {
                MessageBox.Show("No puedes seleccionar el mismo medicamento varias veces.");
                CBMed1.SelectedIndex = -1;
                TxtMed1.Text = "";
            }
        }

        private void CBMed2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CBMed2.SelectedIndex == CBMed1.SelectedIndex && CBMed1.SelectedIndex != -1)
            {
                MessageBox.Show("No puedes seleccionar el mismo medicamento varias veces.");
                CBMed2.SelectedIndex = -1;
                TxtMed2.Text = "";
            }
            else if (CBMed2.SelectedIndex == CBMed3.SelectedIndex && CBMed3.SelectedIndex != -1)
            {
                MessageBox.Show("No puedes seleccionar el mismo medicamento varias veces.");
                CBMed2.SelectedIndex = -1;
                TxtMed2.Text = "";
            }
        }

        private void CBMed3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CBMed3.SelectedIndex == CBMed1.SelectedIndex && CBMed1.SelectedIndex != -1)
            {
                MessageBox.Show("No puedes seleccionar el mismo medicamento varias veces.");
                CBMed3.SelectedIndex = -1;
                TxtMed3.Text = "";
            }
            else if (CBMed3.SelectedIndex == CBMed2.SelectedIndex && CBMed2.SelectedIndex != -1)
            {
                MessageBox.Show("No puedes seleccionar el mismo medicamento varias veces.");
                CBMed3.SelectedIndex = -1;
                TxtMed3.Text = "";
            }
        }*/

        private void TxtMed1_TextChanged(object sender, TextChangedEventArgs e)
        {
            /*if (LblMed1.Content.Equals("Medicamento 1"))
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
            }*/
            if (LblMed1.Content.Equals("Medicamento 1"))
            {
                TxtMed1.Text = "";
            }
        }

        private void TxtMed2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (LblMed2.Content.Equals("Medicamento 2"))
            {
                TxtMed2.Text = "";
            }
            /*bool entero = EsEntero(TxtMed2.Text);
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
            }*/
        }

        private void TxtMed3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (LblMed3.Content.Equals("Medicamento 3"))
            {
                TxtMed3.Text = "";
            }/*
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
            }*/
        }
        /*private void rellenarComboBox()
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
            
        }*/

        private void detallesCompra()
        {
            listaCompra.Clear();
            int id = 0;
            Compra compraS = new Compra();
            Dispatcher.Invoke(() =>
            {
                compraS = (Compra)LVCompras.SelectedItem;
                if(LVCompras.SelectedItem != null)
                {
                    id = compraS.id;
                }
                
            });
            

            string consulta = "SELECT compraid, medicamentoid ,cantidad FROM detallescompra  WHERE compraid = @CompraId";
            try
            {
                NpgsqlConnection conexion = new NpgsqlConnection(connectionString);
                NpgsqlCommand comando = new NpgsqlCommand(consulta, conexion);
                conexion.Open();
                comando.Parameters.AddWithValue("@CompraId", id);
                NpgsqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    int compraid = reader.GetInt32(0);
                    string medicamentoid = reader.GetString(1);
                    int cantidad = reader.GetInt32(2);
                    DetallesCompra dc = new DetallesCompra(compraid, medicamentoid, cantidad);
                    listaCompra.Add(dc);
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
            while (n < listaCompra.Count)
            {
                DetallesCompra dc1 = listaCompra[n];
                if(n == 0)
                {
                    string consulta0 = "SELECT stock, precio FROM medicamentos  WHERE nombre = @Nombre";
                    try
                    {
                        NpgsqlConnection conexion = new NpgsqlConnection(connectionString);
                        NpgsqlCommand comando = new NpgsqlCommand(consulta0, conexion);
                        conexion.Open();
                        comando.Parameters.AddWithValue("@Nombre", dc1.medicamentoid);
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
                        LblMed1.Content = dc1.medicamentoid;
                        //CBMed1.SelectedIndex=indice;
                        LblPMed1.Content = precio;
                        LblMed1Reg.Content = dc1.cantidad;
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
                        comando.Parameters.AddWithValue("@Nombre", dc1.medicamentoid);
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
                        //CBMed2.SelectedIndex = indice;
                        LblMed2.Content = dc1.medicamentoid;
                        LblPMed2.Content = precio;
                        LblMed2Reg.Content = dc1.cantidad;
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
                        comando.Parameters.AddWithValue("@Nombre", dc1.medicamentoid);
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
                        //CBMed3.SelectedIndex = indice;
                        LblMed3.Content = dc1.medicamentoid;
                        LblPMed3.Content = precio;
                        LblMed3Reg.Content = dc1.cantidad;
                        LblMaxMed3.Content = stock;
                        //MessageBox.Show(indice.ToString());
                    });
                    n++;
                }
            }
            
        }
        private bool EsEntero(string cadena)
        {
            int numero;
            return int.TryParse(cadena, out numero);
        }

        private void actualizarCompra()
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
            Compra compraS = new Compra();
            Dispatcher.Invoke(() =>
            {
                compraS = (Compra)LVCompras.SelectedItem;
                Med1 = TxtMed1.Text;
                Med2 = TxtMed2.Text;
                Med3 = TxtMed3.Text;
            });
            id = compraS.id;
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
                commandTotal.Parameters.AddWithValue("@Id", compraS.id);
                conexion.Open();
                commandTotal.ExecuteNonQuery();
                conexion.Close();
                MessageBox.Show("Compra acutualizada");
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                conexion.Close();
            }

            Dispatcher.Invoke(() =>
            {
            if (!LblMed1.Content.Equals("Medicamento 1") && TxtMed1.Text != "")
            {
                
                    cantidad = Int32.Parse(TxtMed1.Text);
                    medicamento = LblMed1.Content.ToString();
                    stock = Int32.Parse(LblMaxMed1.Content.ToString()) + Int32.Parse(TxtMed1.Text) - Int32.Parse(LblMed1Reg.Content.ToString());
               

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
                }catch(Exception ex)
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
                    stock = int.Parse(TxtMed2.Text) - int.Parse(LblMed2Reg.Content.ToString()) + int.Parse(LblMaxMed2.Content.ToString());
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
                    stock = int.Parse(TxtMed3.Text) - int.Parse(LblMed3Reg.Content.ToString()) + int.Parse(LblMaxMed3.Content.ToString());
               

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
                LVCompras.SelectedItem = null;
                LVCompras.Items.Clear();
                Thread actDatos = new Thread(datosLVCompras);
                actDatos.Start();
                Thread saveReg = new Thread(saveMovAct);
                saveReg.Start();
            });
        }
        private void datosLVCompras()
        {

            

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
                                    this.LVCompras.Items.Add(c);
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

        private void BTNewCompra_Click(object sender, RoutedEventArgs e)
        {
            nc = new NewCompra();
            nc.LblEmail.Content = LblEmail.Content;
            nc.Show();
            nc = null;
        }

        private void saveMovAct()
        {
            string email = string.Empty;

            Dispatcher.Invoke(() =>
            {
                email = LblEmail.Content.ToString();
            });
            string operacion = "INSERT INTO movimientos (emailusuario, tipomovimiento, fecha) VALUES (@email, 'Actualizar Compra', CURRENT_DATE)";
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
