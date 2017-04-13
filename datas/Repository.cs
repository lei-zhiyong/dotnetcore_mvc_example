using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;

namespace datas
{
    public class Repository
    {
        public Repository(IConfigurationRoot configuration)
        {
            _configuration = configuration;
        }
        private IConfigurationRoot _configuration { get; }
        private string _readConnStr => _configuration.GetConnectionString("read");
        private string _writeConnStr => _configuration.GetConnectionString("write");
        public virtual Greeting GetGreeting(int id)
        {
            string sql = "SELECT * FROM Greeting WHERE Id=@id";
            using (var conn = new SqlConnection(_readConnStr))
            {
                return conn.QueryFirst<Greeting>(sql, new { id });
            }
        }
    }
}