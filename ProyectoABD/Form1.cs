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
            //Cadena de conexión a SQL
            SqlConnection conexion = new SqlConnection("server=LAPTOP-5DSHMTTE\\SQLEXPRESS182355 ; database=Proyecto_PC ; integrated security = true");
            conexion.Open();

            string query = "select TipoUsuario from UsuariosUNE join Tipo_usuario on UsuariosUNE.id_usuario=Tipo_usuario.id_tipousuario and usuario='"+txt_usuario.Text+"'";
            SqlCommand comando = new SqlCommand(query, conexion);
            SqlDataReader registros = comando.ExecuteReader();

            if(registros.HasRows == false)
            {
                MessageBox.Show("El usuario no existe");
            }
            else
            {
                while (registros.Read())
                {
                    MessageBox.Show("El usuario: " + txt_usuario.Text + " esta asignado al tipo: " + registros["Tipousuario"].ToString()); 
                }
            }
        }
    }
}
