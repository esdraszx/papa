
using System.Collections.Generic;

namespace BLL
{
    public class EmpleadoBLL
    {
        private static EmpleadoBLL Instancia;
        public static EmpleadoBLL GetInstance()
        {
            if (Instancia == null)
            {
                Instancia = new EmpleadoBLL();
            }
            return Instancia;
        }
        //Alta de Empleado
        public bool AltaEmpleado(BE.EmpleadoBE Emp)
        {
            return DAL_Datos.EmpleadoDAL_D.GetInstance().AltaEmpleado(Emp);
        }
        //Validar si ya existe un empleado en la BD
        public bool Validar(BE.EmpleadoBE Emp)
        {
            return DAL_Datos.EmpleadoDAL_D.GetInstance().Validar(Emp);
        }
        //Buscar un mpleado
        public List<BE.EmpleadoBE> BuscarunEmpleadoDNI(string DNI)
        {
            return DAL_Datos.EmpleadoDAL_D.GetInstance().BuscarunEmpleadoDNI(DNI);
        }
        //Delete de Chofer
        public bool EliminarEmpleado(string Id)
        {
            return DAL_Datos.EmpleadoDAL_D.GetInstance().EliminarEmpleado(Id);
        }
        //Update de EMpleado
        public bool ActualizarEmpleado(BE.EmpleadoBE emp)
        {
            return DAL_Datos.EmpleadoDAL_D.GetInstance().ActualizarEmpleado(emp);
        }
        //Listar todos los EMpleados de la base
        public List<BE.EmpleadoBE> ListarChoferes(List<BE.EmpleadoBE> datEmp)
        {
            return DAL_Datos.EmpleadoDAL_D.GetInstance().ListarEmpleado(datEmp);
        }
    }
}
