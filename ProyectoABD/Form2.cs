using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoABD
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btn_registrar_Click(object sender, EventArgs e)
        {
            string user, pass;
            user = txt_usuario.Text;
            pass = txt_contraseña.Text;

            SqlConnection conexion = new SqlConnection("server=YH7w7\\SQLEXPRESS ; database=Proyecto_PC ; integrated security = true");
            conexion.Open();

            string query = "insert into UsuariosUNE(usuario, contrasena) values('" + user + "', ENCRYPTBYPASSPHRASE(N'ABC123', N'" + pass + "'))";
            SqlCommand comando = new SqlCommand(query, conexion);
            SqlDataReader registros = comando.ExecuteReader();

            MessageBox.Show("El usuario: " + txt_usuario.Text + " se ha reistrado con éxito");
            Close();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
