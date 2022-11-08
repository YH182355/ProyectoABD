using System;
using System.Data.SqlClient;
using System.Windows.Forms;

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
            string user, pass;
            user = txt_usuario.Text;
            pass = txt_contraseña.Text;

            //Cadena de conexión a SQL
            SqlConnection conexion = new SqlConnection("server=YH7w7\\SQLEXPRESS ; database=Proyecto_PC ; integrated security = true");

            try
            {
                conexion.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error" + ex.ToString());
                throw;
            }

            if (txt_usuario.Text.Equals("") && txt_contraseña.Text.Equals(""))
            {
                MessageBox.Show("Debe anotar usuario y contraseña");
            }
            else
            {
                string pwd = "SELECT usuario  FROM UsuariosUNE where usuario = '" + user + "'  and CONVERT(NVARCHAR, DECRYPTBYPASSPHRASE(N'ABC123', [contrasena])) = '" + pass + "'";

                SqlCommand comando2 = new SqlCommand(pwd, conexion);
                SqlDataReader registropwd = comando2.ExecuteReader();

                if (registropwd.HasRows == true)
                {
                    MessageBox.Show("Bienvenido " + txt_usuario.Text);
                    FrmMenu n = new FrmMenu();
                    n.Show();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrecto");
                }
            }
        }

        private void btn_registrar_Click(object sender, EventArgs e)
        {
            Form2 nuevo = new Form2();
            nuevo.Show();
        }
    }
}
