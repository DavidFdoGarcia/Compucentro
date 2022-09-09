using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compucentro
{
    class conexion
    {
        public static SqlConnection Conectar()
        {
            SqlConnection cn = new SqlConnection("Data Source=192.168.1.151;Initial Catalog=Compucentro;User ID=dttdato;Password=123456");
            cn.Open();
            return cn;
        }
    }
}
