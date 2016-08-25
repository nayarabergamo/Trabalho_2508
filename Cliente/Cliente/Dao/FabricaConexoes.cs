using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Trabalho.Dao
{
    class FabricaConexoes
    {
        public MySqlConnection GetConnection()
        {
            String connectionString = @"server=localhost;database=aulapoo;userid=usuario;password=senha";
            return new MySqlConnection(connectionString);
        }
    }
}
