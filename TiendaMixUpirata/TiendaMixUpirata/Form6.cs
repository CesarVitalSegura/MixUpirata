using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TiendaMixUpirata
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        MySqlConnection con = new MySqlConnection("server=localhost;user id=root; password=;" +
           "database=bdmixupirata;sslMode=none");

        MySqlCommand cmd;
        MySqlDataAdapter da;
        DataTable dt;
        string sql;
        string id_venta;
        int resulta;

        private void loadData()
        {
            try
            {
                sql = "Select id_venta, Tienda, Ubicacion, Encargado, Total From ventas_mes";
                con.Open();
                cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = sql;
                da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                dt = new DataTable();
                da.Fill(dt);
                dgvVentas.DataSource = dt;

                txtTienda.Clear();
                txtUbicacion.Clear();
                txtEncargado.Clear();
                txtTotal.Clear();



                btnEliminar.Enabled = false;
                btnActualizar.Enabled = false;
                btnGuardar.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
                da.Dispose();
            }
        }
        private void guardarDatos()
        {
            try
            {
                sql = "Insert into ventas_mes(Tienda, Ubicacion, Encargado, Total) values (" +
                    "'" + txtTienda.Text + "','" + txtUbicacion.Text + "'," +
                    "'" + txtEncargado.Text + "','" + txtTotal.Text + "')";
                con.Open();
                cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = sql;
                resulta = cmd.ExecuteNonQuery();
                if (resulta > 0)
                {
                    MessageBox.Show("guardado con exito!!", "Guardado");
                }
                else
                {
                    MessageBox.Show("No se pudo guardar", "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void actualizarDatos()
        {
            try
            {
                sql = "Update discos set Nombre='" + txtTienda.Text
                    + "',Autor='" + txtUbicacion.Text +
                    "',Disquera='" + txtEncargado.Text +
                    "',Precio='" + txtTotal.Text + "' Where" +
                    "id_venta=" + id_venta;
                con.Open();
                cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = sql;
                resulta = cmd.ExecuteNonQuery();

                if (resulta > 0)
                {
                    MessageBox.Show("Actualizado con exito!!", "Actualizado");
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar", "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void EliminarDatos()
        {
            try
            {
                sql = "Delete From ventas_mes Where id_venta=" + id_venta ;
                con.Open();
                cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = sql;
                resulta = cmd.ExecuteNonQuery();

                if (resulta > 0)
                {
                    MessageBox.Show("Eliminado con exito!!", "Eliminado");
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar", "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            guardarDatos();
            loadData();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarDatos();
            loadData();

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            actualizarDatos();
            loadData();

        }

        private void dgvVentas_Click(object sender, EventArgs e)
        {
            id_venta = dgvVentas.CurrentRow.Cells[0].Value.ToString();
            txtTienda.Text = dgvVentas.CurrentRow.Cells[1].Value.ToString();
            txtUbicacion.Text= dgvVentas.CurrentRow.Cells[2].Value.ToString();
            txtEncargado.Text= dgvVentas.CurrentRow.Cells[3].Value.ToString();
            txtTotal.Text= dgvVentas.CurrentRow.Cells[4].Value.ToString();

            btnGuardar.Enabled = false;
            btnActualizar.Enabled = true;
            btnEliminar.Enabled = true;
        }
    }
}
