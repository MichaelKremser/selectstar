using System;
using System.Data;
using Npgsql;

namespace SelectStar
{
	public class SelectStarDbAccessPostgre : SelectStarDbAccess
	{
		public SelectStarDbAccessPostgre ()
		{
		}

		private readonly string connString = @"server=localhost;userid=testuser;password=TestUser#;database=playground;";
		private NpgsqlConnection conn;

		public override void OpenConnection()
		{
			conn = new NpgsqlConnection(connString);
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
			var dataAdapter = new NpgsqlDataAdapter(cmd);
			return dataAdapter;
		}
	}
}

