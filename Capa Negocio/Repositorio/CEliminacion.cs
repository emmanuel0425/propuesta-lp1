using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio.Repositorio
{
    internal class CEliminacion
    {
        
            
        internal void EliminarPaciente(int Empleado_ID, ref bool ResultadoOK, ref string MensajeError)
        {
            DataSet dataset = new DataSet();
            SqlConnection coneccion = new SqlConnection(CConexion.Conectar());
            try
            {

                SqlCommand cmd = new SqlCommand("SIUD_Empleado1", coneccion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Control", "D");
                cmd.Parameters.AddWithValue("@Empleado_ID", Empleado_ID);

                SqlDataAdapter SqlDa = new SqlDataAdapter(cmd);
                SqlDa.Fill(dataset);
                ResultadoOK = true;
                MensajeError = "";

            }
            catch (Exception error)
            {
                ResultadoOK = false;
                MensajeError = "No se pudo eliminar el Empleado " + error.Message.ToString();
            }
            finally
            {
                coneccion.Close();
            }


        }

    }
}
