using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace sysAgenda
{
    class contacto
    {
        //Metodo para agregar contacto
        public void AgregarContacto(string xNombreContacto, string xDireccionContacto, int
        xTelefonoContacto, int xCelularContacto, string xEmailContacto, DateTime xFechaRegistro, int
        xCodigoProfesion, int xCodigoPais)
        {
            conexion cnn = new conexion();
            SqlConnection cn = new SqlConnection(cnn.LeerConexion());
            SqlCommand cmd = new SqlCommand("sp_tbContactoInsertar", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NombreContacto", xNombreContacto);
            cmd.Parameters.AddWithValue("@DireccionContacto", xDireccionContacto);
            cmd.Parameters.AddWithValue("@TelefonoContacto", Convert.ToString(xTelefonoContacto));
            cmd.Parameters.AddWithValue("@CelularContacto", Convert.ToString(xCelularContacto));
            cmd.Parameters.AddWithValue("@EmailContacto", xEmailContacto);
            cmd.Parameters.AddWithValue("@FechaRegistro", xFechaRegistro);
            cmd.Parameters.AddWithValue("@CodigoProfesion", xCodigoProfesion);
            cmd.Parameters.AddWithValue("@CodigoPais", xCodigoPais);
            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
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
        //Metodo para modificar contacto
        
        public void ModificarContacto(int xCodigoContacto, string xNombreContacto, string xDireccionContacto,
        int xTelefonoContacto, int xCelularContacto, string xEmailContacto, DateTime xFechaRegistro, int
        xCodigoProfesion, int xCodigoPais)
        {
            conexion cnn = new conexion();
            SqlConnection cn = new SqlConnection(cnn.LeerConexion());
            SqlCommand cmd = new SqlCommand("sp_tbContactoModificar", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CodigoContacto", xCodigoContacto);
            cmd.Parameters.AddWithValue("@NombreContacto", xNombreContacto);
            cmd.Parameters.AddWithValue("@DireccionContacto", xDireccionContacto);
            cmd.Parameters.AddWithValue("@TelefonoContacto", Convert.ToString(xTelefonoContacto));
            cmd.Parameters.AddWithValue("@CelularContacto", Convert.ToString(xCelularContacto));
            cmd.Parameters.AddWithValue("@EmailContacto", xEmailContacto);
            cmd.Parameters.AddWithValue("@FechaRegistro", xFechaRegistro);
            cmd.Parameters.AddWithValue("@CodigoProfesion", xCodigoProfesion);
            cmd.Parameters.AddWithValue("@CodigoPais", xCodigoPais);
            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
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
        //Metodo para eliminar contacto
        public void EliminarContacto(int xCodigoContacto)
        {
            conexion cnn = new conexion();
            SqlConnection cn = new SqlConnection(cnn.LeerConexion());
            SqlCommand cmd = new SqlCommand("sp_tbContactoEliminar", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CodigoContacto", xCodigoContacto);
            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
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
        public DataTable ListarContacto()
        {
            conexion cnn = new conexion();
            SqlConnection cn = new SqlConnection(cnn.LeerConexion());
            SqlCommand cmd = new SqlCommand("sp_tbContactoListar", cn);
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
