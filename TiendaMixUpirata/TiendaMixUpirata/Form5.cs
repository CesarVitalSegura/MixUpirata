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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        MySqlConnection con = new MySqlConnection("server=localhost;user id=root; password=;" +
           "database=bdmixupirata;sslMode=none");

        MySqlCommand cmd;
        MySqlDataAdapter da;
        DataTable dt;
        string sql;
        string id_tienda;
        int resulta;

        private void loadData()
        {
            try
            {
                sql = "Select id_tienda, Nombre, Ubicacion, Horario, Encargado From tiendas";
                con.Open();
                cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = sql;
                da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                dt = new DataTable();
                da.Fill(dt);
                dgvTiendas.DataSource = dt;

                txtNombre.Clear();
                txtUbicacion.Clear();
                txtHorario.Clear();
                txtEncargado.Clear();
                


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
                sql = "Insert into tiendas(Nombre, Ubicacion, Horario, Encargado) values (" +
                    "'" + txtNombre.Text + "','" + txtUbicacion.Text + "'," +
                    "'" + txtHorario.Text + "','" + txtEncargado.Text + "')";
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
                sql = "Update tiendas set Nombre='" + txtNombre.Text
                    + "',Ubicacion='" + txtUbicacion.Text +
                    "',Horario='" + txtHorario.Text +
                    "',Encargado='" + txtEncargado.Text +"' Where" +
                    "id_tienda=" + id_tienda;
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
                sql = "Delete From tiendas Where id_tienda=" + id_tienda;
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
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            guardarDatos();
            loadData();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            actualizarDatos();
            loadData();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarDatos();
            loadData();
        }

        private void dgvTiendas_Click(object sender, EventArgs e)
        {
            id_tienda = dgvTiendas.CurrentRow.Cells[0].Value.ToString();
            txtNombre.Text = dgvTiendas.CurrentRow.Cells[1].Value.ToString();
            txtUbicacion.Text= dgvTiendas.CurrentRow.Cells[2].Value.ToString();
            txtHorario.Text= dgvTiendas.CurrentRow.Cells[3].Value.ToString();
            txtEncargado.Text= dgvTiendas.CurrentRow.Cells[4].Value.ToString();

            btnGuardar.Enabled = false;
            btnActualizar.Enabled = true;
            btnEliminar.Enabled = true;
        }
    }
}
