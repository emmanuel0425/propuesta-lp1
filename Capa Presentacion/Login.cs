using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Negocio.Logica;
using System.Data.SqlClient;

namespace Capa_Presentacion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        

        private void BtnEntrar_Click(object sender, EventArgs e)
        {
            CUsuario objUsuario = new CUsuario();
            {
                bool ResultadoOK = false;
                string mensajeError = "";
                DataTable dt = new DataTable();
                if (string.IsNullOrEmpty(TBUsuario.Text.ToString().Trim()) || string.IsNullOrEmpty(TBPassword.Text.ToString().Trim()))
                {
                    MessageBox.Show("Por favor, digite el usuario y/o contrasena.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    try
                    {
                        string user = TBUsuario.Text.ToString().Trim();
                        string password = TBPassword.Text.ToString().Trim();

                        dt = objUsuario.Login(user, password, ref ResultadoOK, ref mensajeError);
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show(error.ToString());
                    }
                }

                if (dt.Rows.Count > 0)
                {
                    this.Hide();
                    Registro_Empleados formEmpleado = new Registro_Empleados();
                    formEmpleado.Show();
                    formEmpleado.BringToFront();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos");
                }
            }
        }

    }
}