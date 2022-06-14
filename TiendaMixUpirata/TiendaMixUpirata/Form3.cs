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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        MySqlConnection con = new MySqlConnection("server=localhost;user id=root; password=;" +
            "database=bdmixupirata;sslMode=none");

        MySqlCommand cmd;
        MySqlDataAdapter da;
        DataTable dt;
        string sql;
        string id_producto;
        int resulta;


        private void loadData()
        {
            try
            {
                sql = "Select id_producto, Nombre, Autor, Disquera, Precio From discos";
                con.Open();
                cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = sql;
                da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                dt = new DataTable();
                da.Fill(dt);
                dgvDiscos.DataSource = dt;

                txtNombre.Clear();
                txtAutor.Clear();
                txtDisquera.Clear();
                txtPrecio.Clear();
                


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
                sql = "Insert into discos(Nombre, Autor, Disquera, Precio) values (" +
                    "'" + txtNombre.Text + "','" + txtAutor.Text + "'," +
                    "'" + txtDisquera.Text + "','" + txtPrecio.Text + "')";
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
                sql = "Update discos set Nombre='" + txtNombre.Text
                    + "',Autor='" + txtAutor.Text +
                    "',Disquera='" + txtDisquera.Text +
                    "',Precio='" + txtPrecio.Text + "' Where" +
                    "id_producto=" + id_producto;
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
                sql = "Delete From discos Where id_producto=" + id_producto;
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

        private void dgvDiscos_Click(object sender, EventArgs e)
        {
            id_producto = dgvDiscos.CurrentRow.Cells[0].Value.ToString();
            txtNombre.Text = dgvDiscos.CurrentRow.Cells[1].Value.ToString();
            txtAutor.Text= dgvDiscos.CurrentRow.Cells[2].Value.ToString();
            txtDisquera.Text= dgvDiscos.CurrentRow.Cells[3].Value.ToString();
            txtPrecio.Text= dgvDiscos.CurrentRow.Cells[4].Value.ToString();

            btnGuardar.Enabled = false;
            btnActualizar.Enabled = true;
            btnEliminar.Enabled = true;
        }
    }
}
