﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Negocio.Repositorio;


namespace Capa_Negocio.Logica
{
    public class CEmpleado
    {

        public int Empleado_ID { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Cedula { get; set; }
        public string Telefono{ get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public int Sexo_ID { get; set; }
        public DateTime FechaNac { get; set; }
        public int EstadoC_ID { get; set; }
        public string Direccion { get; set; }
        public string Provincia { get; set; }
        public int Municipio_ID { get; set; }
        public bool Activo { get; set; }
        public int Cargo_ID { get; set; }
        public string Sector { get; set; }
        

        public int Registrar(CEmpleado empleado, ref bool ResultadoOK, ref string MensajeError)
        {
            CRegistro objRegistro = new CRegistro();
            objRegistro.Registro(empleado, ref ResultadoOK, ref MensajeError);
            return Empleado_ID; 

        }

        public void EliminarPaciente(int Empleado_ID, ref bool ResultadoOK, ref string MensajeError)
        {
            CEliminacion objEliminacion = new CEliminacion();
            objEliminacion.EliminarPaciente(Empleado_ID, ref ResultadoOK, ref MensajeError);
        
        }

        public DataTable SeleccionarEmpleado()
        {
            CBusqueda objBusquedad = new CBusqueda();
            return objBusquedad.SeleccionarEmpleado();
        }

        }

}
