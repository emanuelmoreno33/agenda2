using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace sysAgenda
{
    class pais
    {
        //Creamos un metodo que nos permita listar los paises
        //desde el procedimiento almacenado de la sgte. manera
        public DataTable ListarPais()
        {
            //instancia de la clase Conexion
            conexion cnn = new conexion();
            SqlConnection cn = new SqlConnection(cnn.LeerConexion());
            //nombre del procedimiento almacenado
            SqlCommand cmd = new SqlCommand("sp_tbPaisListar", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable tb = new DataTable();
                da.Fill(tb);
                return (tb);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cn.Dispose();
                cmd.Dispose();
            }
        }

    }
}
