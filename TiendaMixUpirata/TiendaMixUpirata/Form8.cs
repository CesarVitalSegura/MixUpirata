using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TiendaMixUpirata
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }
        private void Acceso()
        {
            string usuario;
            usuario = Convert.ToString("ROOTt");
            string contra;
            contra = Convert.ToString("password");

            string usuari;
            usuari = Convert.ToString("ROOTct");
            string contr;
            contr = Convert.ToString("password");

            string usuar;
            usuar = Convert.ToString("ROOTvm");
            string cont;
            cont = Convert.ToString("password");

            if (txtUsuario.Text == usuario && txtContra.Text == contra)
            {

                Form5 form5 = new Form5();

                form5.Show(Form5.ActiveForm);

            }
            else if (txtUsuario.Text == usuari && txtContra.Text == contr)
            {
                Form1 form1 = new Form1();
                form1.Show(Form1.ActiveForm);
            }
            else if(txtUsuario.Text == usuar && txtContra.Text == cont)
            {
                Form6 form6 = new Form6();
                form6.Show(Form6.ActiveForm);
            }
            else
            {
                Exception ex;
                ex = new Exception("DATOS ERRONEOS");
                MessageBox.Show(ex.Message);
            }
          

        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Acceso();
        }
    }
}  

    

    

