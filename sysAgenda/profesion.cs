using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace sysAgenda
{
    class profesion
    {
        public DataTable ListarProfesion()
        {
            conexion cnn = new conexion();
            SqlConnection cn = new SqlConnection(cnn.LeerConexion());
            SqlCommand cmd = new SqlCommand("sp_tbProfesionListar", cn);
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
