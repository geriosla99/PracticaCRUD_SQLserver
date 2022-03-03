using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace PracticaCRUD_SQLserver
{
    class Conexion
    {
        public static SqlConnection Conectar()
        {
            SqlConnection cn = new SqlConnection("SERVER=DESKTOP-BPKCT8N\\SQLEXPRESS01;DATABASE=Empresas;integrated security=true");
            cn.Open();
            return cn;
        }
    }
}
