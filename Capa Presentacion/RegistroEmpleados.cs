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
using Capa_Negocio.Repositorio;
using Capa_Negocio;
using System.Data.SqlClient;
using System.Data.Sql;
using Capa_Presentacion.Helper;

namespace Capa_Presentacion
{
    public partial class Registro_Empleados : Form
    {

        
        
        public Registro_Empleados()
        {
            InitializeComponent();
            DisplayData();
        }
        
        CProvincia provincia = new CProvincia();
        CMunicipio municipio = new CMunicipio();
        CSexo sexo = new CSexo();
        CEstadoCivil estadocivil = new CEstadoCivil();
        CCargo cargo = new CCargo();
        CEmpleado objEmpleado = new CEmpleado();

        private void Registro_Empleados_Load(object sender, EventArgs e)
        {
         
            CBEmpleadoProvincia.DataSource = provincia.SeleccionarProvincia();
            provincia.ID = Convert.ToInt32(CBEmpleadoProvincia.SelectedValue);
            CBEmpleadoMunicipio.DataSource = municipio.SeleccionarMunicipio(provincia.ID);
            CBEmpleadoSexo.DataSource = sexo.SeleccionarSexo();
            CBEmpleadoEstadoCivil.DataSource = estadocivil.SeleccionarEstadoCivil();
            CBCargo.DataSource = cargo.SeleccionarCargo();

           
        }

        void Load_Municipio()
        {
            provincia.ID = Convert.ToInt32(CBEmpleadoProvincia.SelectedValue);
            CBEmpleadoMunicipio.DataSource = municipio.SeleccionarMunicipio(provincia.ID);
        }

        void Load_Sexo()
        {
            //sexo.Sexo_ID = Convert.ToInt32(CBEmpleadoSexo.SelectedValue);
            //CBEmpleadoSexo.DataSource = sexo.SeleccionarSexo();
        }



        public void Registrar()
        {

            string MensajeError = "";
            bool ResultadoOK = true;

            objEmpleado.Nombres = TBEmpleadoNombres.Text.ToString();
            objEmpleado.Apellidos = TBEmpleadoApellidos.Text.ToString();
            objEmpleado.Telefono = TBTelefono.Text.ToString();
            objEmpleado.Celular = TBCelular.Text.ToString();
            objEmpleado.Cedula = TBCedula.Text.ToString();
            objEmpleado.Direccion = TBEmpleadoCalle.Text.ToString();
            objEmpleado.Email = TBEmpleadoEmail.Text.ToString();
            objEmpleado.Sector = TBSector.Text.ToString();
            objEmpleado.FechaNac = Convert.ToDateTime(DTPFechaNac.Text);
            if (CHBActivo.Checked)
            {
                objEmpleado.Activo = true;
            }
            else
            {
                objEmpleado.Activo = false;
            }
            objEmpleado.Municipio_ID = Convert.ToInt32(CBEmpleadoMunicipio.SelectedValue); // It must be obtained from the database using a DataTable
            objEmpleado.Sexo_ID = (int)CBEmpleadoSexo.SelectedValue;
            objEmpleado.EstadoC_ID = (int)CBEmpleadoEstadoCivil.SelectedValue;
            objEmpleado.Cargo_ID = (int)CBCargo.SelectedValue;
            objEmpleado.Registrar(objEmpleado, ref ResultadoOK, ref MensajeError);

            if (ResultadoOK == true)
            {
                MessageBox.Show("La información del empleado ha sido guardada exitosamente.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(MensajeError);
            }


        }

        private void CBEmpleadoProvincia_SelectedIndexChanged(object sender, EventArgs e)

        {
            Load_Municipio();
        }

        private void CBEmpleadoSexo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_Sexo();
        }



        private void BtnEmpleadoAgregarRegistro_Click(object sender, EventArgs e)
        {
            objEmpleado.Empleado_ID = 0;
            Registrar();
            DisplayData();

            CEfecto.LimpiarForm(this);
            

        }

        //Display Data in DataGridView  
        private void DisplayData()
        {
            //SqlConnection con = new SqlConnection("Data Source =.; Initial Catalog = Proyecto Final; Integrated Security = True;");
            //con.Open();
            //DataTable dt = new DataTable();
            //SqlDataAdapter SqlDa = new SqlDataAdapter("SELECT * FROM Empleado", con);
            //SqlDa.Fill(dt);
            //DGVEmpleado.DataSource = dt;
            //con.Close();

            DGVEmpleado.DataSource = objEmpleado.SeleccionarEmpleado();
        }
        

        private void BtnActualizarRegistroEmpleado_Click(object sender, EventArgs e)
        {
            //Update Record  
          
            if (string.IsNullOrEmpty(TBEmpleadoID.Text.ToString().Trim()))
            {
                MessageBox.Show("No ha elegido ningún registro para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                objEmpleado.Empleado_ID = Convert.ToInt32(TBEmpleadoID.Text);
                Registrar();
                DisplayData();
            }
            
            

        }

        private void BtnEliminarRegistroEmpleado_Click(object sender, EventArgs e)
        {
            bool ResultadoOk = false;
            string MensajeError = "";

            if (string.IsNullOrEmpty(TBEmpleadoID.Text.ToString().Trim()))
            {
                MessageBox.Show("No ha elegido ningún registro para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                objEmpleado.Empleado_ID = Convert.ToInt32(TBEmpleadoID.Text.ToString().Trim());
                objEmpleado.EliminarEmpleado(objEmpleado.Empleado_ID,ref ResultadoOk, ref MensajeError);
            }

            if (ResultadoOk)
            {
                MessageBox.Show("El empleado ha sido elimininado exitosamente.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DisplayData();
            }
            else
            {
                MessageBox.Show("Error", MensajeError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        //Clear Data  
        //private void ClearData()
        //{
        //    TBEmpleadoNombres.Text = "";
        //    TBEmpleadoApellidos.Text = "";
        //    CBEmpleadoSexo.Text = "";
        //    DTPFechaNac.Text = "";
        //    TBCedula.Text = "";
        //    TBCelular.Text = "";
        //    TBTelefono.Text = "";
        //    TBEmpleadoEmail.Text = "";
        //    CBEmpleadoEstadoCivil.Text = "";
        //    CBCargo.Text = "";
        //    //CHBActivo.Text = "";
        //    TBEmpleadoCalle.Text = "";
        //    TBSector.Text = "";
        //    CBEmpleadoProvincia.Text = "";
        //    CBEmpleadoMunicipio.Text = "";
        //    Empleado_ID = 0;
            
        

        private void DGVEmpleado_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void BtnEmpleadoEliminarRegistro_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTNNuevo_Click(object sender, EventArgs e)
        {
            CEfecto.LimpiarForm(this);
        }

        private void DGVEmpleado_Click(object sender, EventArgs e)
        {
            bool ResultadoOK = true;
            try
            {

                TBEmpleadoID.Text = DGVEmpleado.Rows[DGVEmpleado.CurrentRow.Index].Cells["Empleado_ID"].Value.ToString();
                TBEmpleadoNombres.Text = DGVEmpleado.Rows[DGVEmpleado.CurrentRow.Index].Cells["Empleado_Nombres"].Value.ToString();
                TBEmpleadoApellidos.Text = DGVEmpleado.Rows[DGVEmpleado.CurrentRow.Index].Cells["Empleado_Apellidos"].Value.ToString();
                TBCedula.Text = DGVEmpleado.Rows[DGVEmpleado.CurrentRow.Index].Cells["Empleado_Cedula"].Value.ToString();
                TBCelular.Text = DGVEmpleado.Rows[DGVEmpleado.CurrentRow.Index].Cells["Empleado_Celular"].Value.ToString();
                TBTelefono.Text = DGVEmpleado.Rows[DGVEmpleado.CurrentRow.Index].Cells["Empleado_Telefono"].Value.ToString();
                TBEmpleadoEmail.Text = DGVEmpleado.Rows[DGVEmpleado.CurrentRow.Index].Cells["Empleado_Email"].Value.ToString();
                TBSector.Text = DGVEmpleado.Rows[DGVEmpleado.CurrentRow.Index].Cells["Empleado_Sector"].Value.ToString();
                TBEmpleadoCalle.Text = DGVEmpleado.Rows[DGVEmpleado.CurrentRow.Index].Cells["Empleado_Direccion"].Value.ToString();
                CBEmpleadoEstadoCivil.SelectedValue = DGVEmpleado.Rows[DGVEmpleado.CurrentRow.Index].Cells["EstadoC_ID"].Value;
                DTPFechaNac.Text = DGVEmpleado.Rows[DGVEmpleado.CurrentRow.Index].Cells["Empleado_Fecha_Nacimiento"].Value.ToString();
                CBCargo.SelectedValue = DGVEmpleado.Rows[DGVEmpleado.CurrentRow.Index].Cells["Cargo_ID"].Value;
                CBEmpleadoSexo.SelectedValue = DGVEmpleado.Rows[DGVEmpleado.CurrentRow.Index].Cells["Sexo_ID"].Value;
                CBEmpleadoProvincia.SelectedValue = DGVEmpleado.Rows[DGVEmpleado.CurrentRow.Index].Cells["Pro_ID"].Value;
                CBEmpleadoMunicipio.SelectedValue = DGVEmpleado.Rows[DGVEmpleado.CurrentRow.Index].Cells["Mu_ID"].Value;
                CHBActivo.Checked = Convert.ToBoolean(DGVEmpleado.Rows[DGVEmpleado.CurrentRow.Index].Cells["Empleado_Activo"].Value);

            }
            catch (Exception error)
            {
                ResultadoOK = false;
                MessageBox.Show(error.ToString());
            }
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {

        }
    }
}
