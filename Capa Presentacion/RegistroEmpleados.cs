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
        //objBusqueda = new CBusqueda();
        CProvincia provincia = new CProvincia();
        CMunicipio municipio = new CMunicipio();
        CSexo sexo = new CSexo();
        CEstadoCivil estadocivil = new CEstadoCivil();
        CCargo cargo = new CCargo();
        CEmpleado objEmpleado = new CEmpleado();

        private void Registro_Empleados_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'proyecto_FinalDataSet2.Empleado' table. You can move, or remove it, as needed.
            this.empleadoTableAdapter1.Fill(this.proyecto_FinalDataSet2.Empleado);
            // TODO: This line of code loads data into the 'proyecto_FinalDataSet.Empleado' table. You can move, or remove it, as needed.
            //this.empleadoTableAdapter.Fill(this.proyecto_FinalDataSet.Empleado);
            //CBEmpleadoSexo.DataSource = objBusqueda.SeleccionarSexo();
            CBEmpleadoProvincia.DataSource = provincia.SeleccionarProvincia();
            provincia.ID = Convert.ToInt32(CBEmpleadoProvincia.SelectedValue);
            CBEmpleadoMunicipio.DataSource = municipio.SeleccionarMunicipio(provincia.ID);
            // sexo.Sexo_ID = Convert.ToInt32(CBEmpleadoSexo.SelectedValue);
            CBEmpleadoSexo.DataSource = sexo.SeleccionarSexo();
            CBEmpleadoEstadoCivil.DataSource = estadocivil.SeleccionarEstadoCivil();
            CBCargo.DataSource = cargo.SeleccionarCargo();

            //CBEmpleadoMunicipio.DataSource = municipio.SeleccionarMunicipio();
            //this.empleadoTableAdapter.Fill(this.proyecto_FinalDataSet.Empleado);
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
                MessageBox.Show(objEmpleado.Empleado_ID.ToString() + "Guardado Exitosamente.");
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





        
            //using (SqlConnection con = new SqlConnection(CConexion.Conectar()))
            //    con.Open();
            //SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Empleado", con);
            //DataTable dataTable = new DataTable();
            //sqlDa.Fill(dataTable);

            //DGVEmpleado.DataSource = dataTable;

            //SqlConnection con = new SqlConnection("Data Source =.; Initial Catalog = Proyecto Final; Integrated Security = True;");
            //SqlDa = new SqlDataAdapter("SELECT * FROM Empleado", con);
            //dt = new DataTable();
            //SqlDa.Fill(dt);
            //DGVEmpleado.DataSource = dt;

            //    Cursor.Current = Cursors.WaitCursor;

            //    try
            //    {
            //        empleadoBindingSource.EndEdit();
            //        empleadoTableAdapter.Update(this.proyecto_FinalDataSet.Empleado);
            //        MessageBox.Show("El empleado ha sido agregado exitosamente.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }

            //    Cursor.Current = Cursors.Default;
            //}

            //private void DGVEmpleado_KeyDown(object sender, KeyEventArgs e)
            //{
            //    if (e.KeyCode == Keys.Delete)
            //    {
            //        if (MessageBox.Show("Realmente desea eliminar este registro?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //            empleadoBindingSource.RemoveCurrent();
            //    }




     

        //public void CargarEmpleados(DataGridView DGVEmpleado)
        //{
        //    try
        //    {

        //        SqlDa = new SqlDataAdapter("SELECT * FROM Empleado", con);
        //        dt = new DataTable();
        //        SqlDa.Fill(dt);
        //        DGVEmpleado.DataSource = dt;


        //    }

        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("No se pudo obtener la información del empleado: " + ex.ToString());
        //    }
        //}

     

        //Display Data in DataGridView  
        private void DisplayData()
        {
            SqlConnection con = new SqlConnection("Data Source =.; Initial Catalog = Proyecto Final; Integrated Security = True;");
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter SqlDa = new SqlDataAdapter("SELECT * FROM Empleado", con);
            SqlDa.Fill(dt);
            DGVEmpleado.DataSource = dt;
            con.Close();
        }
        

        private void BtnActualizarRegistroEmpleado_Click(object sender, EventArgs e)
        {
            //Update Record  
            //    if (TBEmpleadoNombres.Text != "" && TBEmpleadoApellidos.Text != "" && CBEmpleadoSexo.Text != "" && DTPFechaNac.Text != "" && TBCedula.Text != "" &&
            //        TBCelular.Text != "" && TBTelefono.Text != "" && TBEmpleadoEmail.Text != "" && CBEmpleadoEstadoCivil.Text != "" && CBCargo.Text != "" &&
            //        TBEmpleadoCalle.Text != "" && TBSector.Text != "" && CBEmpleadoProvincia.Text != "" && CBEmpleadoMunicipio.Text != "")
            //    {
            //        SqlConnection con = new SqlConnection("Data Source =.; Initial Catalog = Proyecto Final; Integrated Security = True;");
            //        SqlCommand cmd = new SqlCommand();
            //            cmd = new SqlCommand("UPDATE Empleado SET Empleado_Nombre = @Empleado_Nombres, Empleado_Apellidos = @Empleado_Apellidos, " +
            //            "Empleado_Telefono = @Empleado_Telefono, Empleado_Celular = @Empleado_Celular, Empleado_Email = @Empleado_Email" +
            //            "Empleado_Cedula = @Empleado_Cedula, Sexo_ID = @Sexo_ID, Empleado_FechaNac = @Empleado_FechaNac, EstadoC_ID = @EstadoC_ID" +
            //            "Empleado_Direccion = @Empleado_Direccion, Municipio_ID = @Municipio_ID, Cargo_ID = @Cargo_ID, Empleado_Sector = @Empleado_Sector WHERE Empleado_ID = @Empleado_ID", con);
            //        con.Open();
            //        cmd.Parameters.AddWithValue("@Empleado_ID", Empleado_ID);
            //        cmd.Parameters.AddWithValue("@Empleado_Nombres", TBEmpleadoNombres.Text);
            //        cmd.Parameters.AddWithValue("@Empleado_Apellidos", TBEmpleadoApellidos.Text);
            //        cmd.Parameters.AddWithValue("@Empleado_Telefono", TBTelefono.Text);
            //        cmd.Parameters.AddWithValue("@Empleado_Celular", TBCelular.Text);
            //        cmd.Parameters.AddWithValue("@Empleado_Email", TBEmpleadoEmail.Text);
            //        cmd.Parameters.AddWithValue("@Empleado_Cedula", TBCedula.Text);
            //        cmd.Parameters.AddWithValue("@Sexo_ID", CBEmpleadoSexo);
            //        cmd.Parameters.AddWithValue("@Empleado_FechaNac", DTPFechaNac.Text);
            //        cmd.Parameters.AddWithValue("@EstadoC_ID", CBEmpleadoEstadoCivil);
            //        cmd.Parameters.AddWithValue("@Empleado_Direccion", TBEmpleadoCalle.Text);
            //        //cmd.Parameters.AddWithValue("@Empleado_Activo", objEmpleado.Activo);
            //        cmd.Parameters.AddWithValue("@Municipio_ID", CBEmpleadoMunicipio);
            //        cmd.Parameters.AddWithValue("@Cargo_ID", CBCargo);
            //        cmd.Parameters.AddWithValue("@Empleado_Sector", TBSector.Text);
            //       // cmd.ExecuteNonQuery();
            //        MessageBox.Show("Record Updated Successfully");
            //        con.Close();
            //        DisplayData();
            //        ClearData();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Please Select Record to Update");
            //    }
            if (string.IsNullOrEmpty(TBEmpleadoID.Text))
            {
                MessageBox.Show("Advertencia","No ha elegido ningun Registro",MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("Advertencia", "No ha elegido ningun Registro para eliminar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                objEmpleado.Empleado_ID = Convert.ToInt32(TBEmpleadoID.Text.ToString().Trim());
                objEmpleado.EliminarPaciente(objEmpleado.Empleado_ID,ref ResultadoOk, ref MensajeError);
            }

            if (ResultadoOk)
            {
                MessageBox.Show("Notificacion", "Empleado Elimininado Exitosamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            
        //}
        ////dataGridView1 RowHeaderMouseClick Event  
        //private void DGVEmpleado_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //    Empleado_ID = Convert.ToInt32(DGVEmpleado.Rows[e.RowIndex].Cells[0].Value.ToString());
        //    TBEmpleadoNombres.Text = DGVEmpleado.Rows[e.RowIndex].Cells[1].Value.ToString();
        //    TBEmpleadoApellidos.Text = DGVEmpleado.Rows[e.RowIndex].Cells[2].Value.ToString();
        //    CBEmpleadoSexo.Text = DGVEmpleado.Rows[e.RowIndex].Cells[3].Value.ToString();
        //    DTPFechaNac.Text = DGVEmpleado.Rows[e.RowIndex].Cells[4].Value.ToString();
        //    TBCedula.Text = DGVEmpleado.Rows[e.RowIndex].Cells[5].Value.ToString();
        //    TBCelular.Text = DGVEmpleado.Rows[e.RowIndex].Cells[6].Value.ToString();
        //    TBTelefono.Text = DGVEmpleado.Rows[e.RowIndex].Cells[7].Value.ToString();
        //    TBEmpleadoEmail.Text = DGVEmpleado.Rows[e.RowIndex].Cells[8].Value.ToString();
        //    CBEmpleadoEstadoCivil.Text = DGVEmpleado.Rows[e.RowIndex].Cells[9].Value.ToString();
        //    CBCargo.Text = DGVEmpleado.Rows[e.RowIndex].Cells[10].Value.ToString();
        //    TBEmpleadoCalle.Text = DGVEmpleado.Rows[e.RowIndex].Cells[11].Value.ToString();
        //    TBSector.Text = DGVEmpleado.Rows[e.RowIndex].Cells[12].Value.ToString();
        //    CBEmpleadoProvincia.Text = DGVEmpleado.Rows[e.RowIndex].Cells[13].Value.ToString();
        //    CBEmpleadoMunicipio.Text = DGVEmpleado.Rows[e.RowIndex].Cells[14].Value.ToString();
        //    CHBActivo.Checked = Convert.ToBoolean(DGVEmpleado.Rows[e.RowIndex].Cells[15].Value.ToString());


        //}

        private void DGVEmpleado_DoubleClick(object sender, EventArgs e)
        {
            bool ResultadoOK = true;
            try
            {

                TBEmpleadoID.Text = DGVEmpleado.Rows[DGVEmpleado.CurrentRow.Index].Cells["empleadoIDDataGridViewTextBoxColumn"].Value.ToString();
                TBEmpleadoNombres.Text = DGVEmpleado.Rows[DGVEmpleado.CurrentRow.Index].Cells["empleadoNombresDataGridViewTextBoxColumn"].Value.ToString();
                TBEmpleadoApellidos.Text = DGVEmpleado.Rows[DGVEmpleado.CurrentRow.Index].Cells["empleadoApellidosDataGridViewTextBoxColumn"].Value.ToString();
                TBCedula.Text = DGVEmpleado.Rows[DGVEmpleado.CurrentRow.Index].Cells["empleadoCedulaDataGridViewTextBoxColumn"].Value.ToString();
                TBCelular.Text = DGVEmpleado.Rows[DGVEmpleado.CurrentRow.Index].Cells["empleadoCelularDataGridViewTextBoxColumn"].Value.ToString();
                TBTelefono.Text = DGVEmpleado.Rows[DGVEmpleado.CurrentRow.Index].Cells["empleadoTelefonoDataGridViewTextBoxColumn"].Value.ToString();
                TBEmpleadoEmail.Text = DGVEmpleado.Rows[DGVEmpleado.CurrentRow.Index].Cells["empleadoEmailDataGridViewTextBoxColumn"].Value.ToString();
                TBSector.Text = DGVEmpleado.Rows[DGVEmpleado.CurrentRow.Index].Cells["empleadoSectorDataGridViewTextBoxColumn"].Value.ToString();
                TBEmpleadoCalle.Text = DGVEmpleado.Rows[DGVEmpleado.CurrentRow.Index].Cells["empleadoDireccionDataGridViewTextBoxColumn"].Value.ToString();
                CBEmpleadoEstadoCivil.SelectedValue = DGVEmpleado.Rows[DGVEmpleado.CurrentRow.Index].Cells["estadoCIDDataGridViewTextBoxColumn"].Value.ToString();
                DTPFechaNac.Text = DGVEmpleado.Rows[DGVEmpleado.CurrentRow.Index].Cells["empleadoFechaNacimientoDataGridViewTextBoxColumn"].Value.ToString();
                CBCargo.SelectedValue = DGVEmpleado.Rows[DGVEmpleado.CurrentRow.Index].Cells["cargoIDDataGridViewTextBoxColumn"].Value.ToString();
                CBEmpleadoSexo.SelectedValue = DGVEmpleado.Rows[DGVEmpleado.CurrentRow.Index].Cells["sexoIDDataGridViewTextBoxColumn"].Value.ToString();
                CBEmpleadoProvincia.SelectedValue = DGVEmpleado.Rows[DGVEmpleado.CurrentRow.Index].Cells["empleadoIDDataGridViewTextBoxColumn"].Value.ToString();
                CBEmpleadoMunicipio.SelectedText  = DGVEmpleado.Rows[DGVEmpleado.CurrentRow.Index].Cells["muIDDataGridViewTextBoxColumn"].Value.ToString();
                CHBActivo.Checked = Convert.ToBoolean(DGVEmpleado.Rows[DGVEmpleado.CurrentRow.Index].Cells["empleadoActivoDataGridViewCheckBoxColumn"].Value);
            
            }
            catch (Exception error)
            {
                ResultadoOK = false;
                MessageBox.Show(error.ToString());
            }
        }

        private void BtnEmpleadoEliminarRegistro_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
