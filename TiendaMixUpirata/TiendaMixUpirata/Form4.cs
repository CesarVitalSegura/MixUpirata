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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        MySqlConnection con = new MySqlConnection("server=localhost;user id=root; password=;" +
            "database=bdmixupirata;sslMode=none");

        MySqlCommand cmd;
        MySqlDataAdapter da;
        DataTable dt;
        string sql;
        string id_cliente;
        int resulta;

        private void loadData()
        {
            try
            {
                sql = "Select id_cliente, Nombre, Edad, Sexo, Disco, Total From clientes";
                con.Open();
                cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = sql;
                da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                dt = new DataTable();
                da.Fill(dt);
                dgvClientes.DataSource = dt;

                txtNombre.Clear();
                txtEdad.Clear();
                txtSexo.Clear();
                txtDisco.Clear();
                txtTotal.Clear();
                txtTienda.Clear();
                


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
                sql = "Insert into clientes(Nombre, Edad, Sexo, Disco, Total, Tienda) values (" +
                    "'" + txtNombre.Text + "','" + txtEdad.Text + "'," +
                    "'" + txtSexo.Text + "','" + txtDisco.Text + "'," +
                    "'" + txtTotal.Text + "','" + txtTienda.Text + "')";
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
                sql = "Update clientes set Nombre='" + txtNombre.Text
                    + "',Edad='" + txtEdad.Text +
                    "',Sexo='" + txtSexo.Text +
                    "',Disco='" + txtDisco.Text +
                    "',Total='" + txtTotal.Text +
                    "',Tienda='" + txtTienda.Text + "' Where"+
                    "id_cliente=" + id_cliente;
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
                sql = "Delete From clientes Where id_cliente=" + id_cliente;
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

        private void dgvClientes_Click(object sender, EventArgs e)
        {
            id_cliente = dgvClientes.CurrentRow.Cells[0].Value.ToString();
            txtNombre.Text = dgvClientes.CurrentRow.Cells[1].Value.ToString();
            txtEdad.Text = dgvClientes.CurrentRow.Cells[2].Value.ToString();
            txtSexo.Text= dgvClientes.CurrentRow.Cells[3].Value.ToString();
            txtDisco.Text= dgvClientes.CurrentRow.Cells[4].Value.ToString();
            txtTotal.Text= dgvClientes.CurrentRow.Cells[5].Value.ToString();


            btnEliminar.Enabled = true;
            btnActualizar.Enabled= true;
            btnGuardar.Enabled = false;
        }
    }


}
