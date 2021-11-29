using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Done.Api.Services
{
    public class PostgresDbProvider
    {
        private readonly string _connectionString;

        public PostgresDbProvider(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public IDbConnection GetDbConnection()
        {
            return new NpgsqlConnection(_connectionString);
        } 
    }
}
