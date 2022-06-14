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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        MySqlConnection con = new MySqlConnection("server=localhost;user id=root; password=;"+
            "database=bdmixupirata;sslMode=none");

        MySqlCommand cmd;
        MySqlDataAdapter da;
        DataTable dt;
        string sql;
        string id_trabajador;
        int resulta;

        private void loadData()
        {
            try
            {
                sql = "Select id_trabajador, Nombre, Edad, Sexo, Tienda, Puesto From trabajadores";
                con.Open();
                cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = sql;
                da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                dt = new DataTable();
                da.Fill(dt);
                dgvTrabajadores.DataSource = dt;

                txtNombre.Clear();
                txtEdad.Clear();
                txtSexo.Clear();
                txtTienda.Clear();
                txtPuesto.Clear();
                

                btnEliminar.Enabled = false;
                btnActualizar.Enabled = false;
                btnGuardar.Enabled = true;
            }catch(Exception ex)
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
                sql = "Insert into trabajadores(Nombre, Edad, Sexo, Tienda, Puesto) values ("+
                    "'"+ txtNombre.Text + "','"+txtEdad.Text+"',"+
                    "'"+ txtSexo.Text+"','"+txtTienda.Text+"',"+
                    "'"+ txtPuesto.Text+"')";
                con.Open();
                cmd = new MySqlCommand();
                cmd.Connection=con;
                cmd.CommandText = sql;
                resulta = cmd.ExecuteNonQuery();
                if (resulta > 0)
                {
                    MessageBox.Show("guardado con exito!!","Guardado");
                }
                else
                {
                    MessageBox.Show("No se pudo guardar","Error");
                }
            }
            catch(Exception ex)
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
                sql = "Update trabajadores set Nombre='" + txtNombre.Text
                    + "',Edad='" + txtEdad.Text +
                    "',Sexo='" + txtSexo.Text +
                    "',Tienda='" + txtTienda.Text +
                    "',Puesto='" + txtPuesto.Text+"' Where"+
                    "id_trabajador="+id_trabajador;
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
            }catch(Exception ex)
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
                sql = "Delete From trabajadores Where id_trabajador=" +id_trabajador;
                con.Open();
                cmd=new MySqlCommand(); 
                cmd.Connection=con;
                cmd.CommandText = sql;
                resulta=cmd.ExecuteNonQuery ();

                if (resulta > 0)
                {
                    MessageBox.Show("Eliminado con exito!!", "Eliminado");
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar", "Error");
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
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

        private void dgvTrabajadores_Click(object sender, EventArgs e)
        {
            id_trabajador = dgvTrabajadores.CurrentRow.Cells[0].Value.ToString();
            txtNombre.Text = dgvTrabajadores.CurrentRow.Cells[1].Value.ToString();
            txtEdad.Text=dgvTrabajadores.CurrentRow.Cells[2].Value.ToString();
            txtSexo.Text= dgvTrabajadores.CurrentRow.Cells[3].Value.ToString();
            txtTienda.Text= dgvTrabajadores.CurrentRow.Cells[4].Value.ToString();
            txtPuesto.Text= dgvTrabajadores.CurrentRow.Cells[5].Value.ToString();

            btnEliminar.Enabled = true;
            btnActualizar.Enabled = true;
            btnGuardar.Enabled = false;
        }

        private void txtTienda_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
