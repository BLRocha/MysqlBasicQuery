using MySqlBasic.conexao;
using MySqlConnector;
using System.Data;

namespace MySqlBasic.MySql.Query
{
    public class Query
    {
        private static IDictionary<string, string> _queryes =
            new Dictionary<string, string>();


        private static async Task<MySqlConnection> _connection()
        {
            var conn = await new MysqlConnection().GetConnection();
            return conn;
        }
        public static void createQuery(string queryName,string queryString)
        {
            Query._queryes.Add(queryName, queryString );
        }

        public static async Task<DataTable> executeQuery(string name)
        {
            string? stringCommand;
            Query._queryes.TryGetValue(name, out stringCommand);

            if (stringCommand == null) return new DataTable();

            DataTable dt = new DataTable();
            var con = await Query._connection();
            var command = con.CreateCommand();
            command.CommandText = stringCommand;
            var reader = command.ExecuteReader();
            dt.Load(reader);
            reader.Close();

            return dt;
        }
    }
}
