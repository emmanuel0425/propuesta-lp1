using Capa_Negocio.Repositorio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio.Logica
{
    public class CUsuario
    {

        public DataTable Login(string Usuario, string Clave, ref bool ResultadoOK, ref string MensajeError)
        {
            CBusqueda objBusqueda = new CBusqueda();
            return objBusqueda.SeleccionarUsuario(Usuario, Clave, ref ResultadoOK, ref MensajeError);

        }
    }
}
