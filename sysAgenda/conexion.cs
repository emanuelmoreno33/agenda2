using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace sysAgenda
{
    class conexion
    {
        public string LeerConexion()
        {
            try
            {
                return
                ConfigurationManager.ConnectionStrings["sysAgenda.Properties.Settings.bd_agendaConnectionString"].ConnectionString;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
