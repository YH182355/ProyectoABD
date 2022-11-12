using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoABD
{
    public partial class FrmRegistro : Form
    {
        public FrmRegistro()
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

            //Verificacion que los textBox tengan datos

            if (user.Equals("") && pass.Equals(""))
            {
                MessageBox.Show("Debe anotar un usuario y una contraseña");
            }
            else if (user.Equals(""))
            {
                MessageBox.Show("Favor de anotar un usuario");
            }
            else if (pass.Equals(""))
            {
                MessageBox.Show("Favor de anotar una contraseña");
            }

            //Condicion para ver si existe el usuario en la bd
            else
            {
                string usrdup = "select usuario from UsuariosUNE where usuario = '" + user + "'";
                SqlCommand dup = new SqlCommand(usrdup, conexion);
                SqlDataReader regdup = dup.ExecuteReader();
                
                if (regdup.HasRows == true)
                {
                    MessageBox.Show("Este usuario ya es existente");
                    MessageBox.Show("Favor de ingresar otro usuario");
                    conexion.Close();
                }

                //Si no existe se agrega a la bd
                else
                {

                    SqlConnection conexion2 = new SqlConnection("server=YH7w7\\SQLEXPRESS ; database=Proyecto_PC ; integrated security = true");
                    conexion2.Open();

                    string query = "insert into UsuariosUNE(usuario, contrasena) values('" + user + "', ENCRYPTBYPASSPHRASE(N'ABC123', N'" + pass + "'))";
                    SqlCommand comando = new SqlCommand(query, conexion2);
                    SqlDataReader registros = comando.ExecuteReader();

                    MessageBox.Show("El usuario: " + user + " se ha registrado con éxito");
                    Close();

                    FrmLogin Login = new FrmLogin();
                    Login.Show();
                }
            }
            
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
