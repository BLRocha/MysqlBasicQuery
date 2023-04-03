using MySqlConnector;

namespace MySqlBasic.conexao
{
    public sealed class MysqlConnection
    {
        private readonly MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder {
                UserID = "root",
                Database = "test",
                Password = "",
                Server = "localhost",
                AllowUserVariables = true
            };
        private static MySqlConnection? conn = null;
        public MysqlConnection()
        {
            conn = new MySqlConnection(builder.ConnectionString);
        }
        public async Task<MySqlConnection> GetConnection()
        {
            if (MysqlConnection.conn != null) return conn;

            MysqlConnection.conn = new MySqlConnection(builder.ConnectionString);
            await conn.OpenAsync();
            Console.WriteLine("Conectando!");
            return conn;
        }
    }
}
