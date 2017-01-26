using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace SelectStar
{
	public class SelectStarDbAccessMySql : SelectStarDbAccess
	{
		public SelectStarDbAccessMySql ()
		{
		}

		private readonly string connString = @"server=localhost;userid=testuser;password=TestUser#;database=playground;";
		private MySqlConnection conn;

		public override void OpenConnection()
		{
			conn = new MySqlConnection(connString);
			conn.Open();
		}

		public override IDbConnection GetConnection ()
		{
			return conn;
		}

		public override IDbDataAdapter GetDataAdapterForSQL (string sql)
		{
			var cmd = conn.CreateCommand();
			cmd.CommandText = sql;
			var dataAdapter = new MySqlDataAdapter(cmd);
			return dataAdapter;
		}
	}
}

