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
            SqlConnection conexion = new SqlConnection("server=LAPTOP-5DSHMTTE\\SQLEXPRESS182355 ; database=Proyecto_PC ; integrated security = true");
            conexion.Open();

            string query = "insert into UsuariosUNE(id_tipousuario, usuario, contrasena) values(2, '" + txt_usuario.Text + "', ENCRYPTBYPASSPHRASE(N'ABC123', N'" + txt_contraseña + "'))";
            SqlCommand comando = new SqlCommand(query, conexion);
            SqlDataReader registros = comando.ExecuteReader();

            MessageBox.Show("El usuario: " + txt_usuario.Text + " se a reistrado con éxito");
            Close();
            
    }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
