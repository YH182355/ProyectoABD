using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProyectoABD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string usuario, pass;
            usuario = txt_usuario.Text;
            pass = txt_contraseña.Text;

            //Cadena de conexión a SQL
            SqlConnection conexion = new SqlConnection("server=LAPTOP-5DSHMTTE\\SQLEXPRESS182355 ; database=Proyecto_PC ; integrated security = true");

            try
            {
                conexion.Open();
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Error" + ex.ToString());
                throw;
            }

            string usr = "SELECT usuario  FROM UsuariosUNE where usuario = '" + usuario + "'";

            SqlCommand comando = new SqlCommand(usr, conexion);
            SqlDataReader registrousr = comando.ExecuteReader();

            string pwd = "SELECT usuario  FROM UsuariosUNE where usuario = usuario  and CONVERT(NVARCHAR, DECRYPTBYPASSPHRASE(N'ABC123', ['" + pass + "'])) = pass";

            SqlCommand comando2 = new SqlCommand(pwd, conexion);
            SqlDataReader registropwd = comando2.ExecuteReader();


            if (registrousr.HasRows == false || registropwd.HasRows == false)
            {
                MessageBox.Show("Favor de ingrear un usuario");
                MessageBox.Show("Si desea registrarse presione el boton de 'Registrar'");
            }


            else if (registrousr.HasRows == true && registropwd.HasRows == true)
            {
                if (pwd == pass)
                {
                    MessageBox.Show("Bienvido " + usuario);
                }
            }
            else
            {
                MessageBox.Show("El usuario " + usuario + " o contraseña es incorrecto");
            }
        }

        private void btn_registrar_Click(object sender, EventArgs e)
        {
            Form2 nuevo = new Form2();
            nuevo.Show();
        }
    }
}
