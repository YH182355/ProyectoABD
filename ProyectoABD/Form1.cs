using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoABD
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
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
            //Verificacion que los textBox tengan datos
            if (txt_usuario.Text.Equals("") && txt_contraseña.Text.Equals(""))
            {
                MessageBox.Show("Debe anotar usuario y contraseña");
            }
            else if (txt_usuario.Text.Equals(""))
            {
                MessageBox.Show("Debe anotar usuario");
            }
            else if (txt_contraseña.Text.Equals(""))
            {
                MessageBox.Show("Debe anotar la contraseña");
            } 

            //Condicion para ver si existe el usuario en la bd
            else
            {
                string pwd = "SELECT usuario  FROM UsuariosUNE where usuario = '" + user + "'  and CONVERT(NVARCHAR, DECRYPTBYPASSPHRASE(N'ABC123', [contrasena])) = '" + pass + "'";
                SqlCommand comando2 = new SqlCommand(pwd, conexion);
                SqlDataReader registropwd = comando2.ExecuteReader();

                if (registropwd.HasRows == true)
                {
                    MessageBox.Show("Bienvenido " + txt_usuario.Text + "!!");
                    FrmMenu n = new FrmMenu();
                    n.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrecto");
                }
            }
        }

        private void btn_registrar_Click(object sender, EventArgs e)
        {
            FrmRegistro nuevo = new FrmRegistro();
            nuevo.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
