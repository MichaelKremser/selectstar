using System;
using System.Data;

namespace SelectStar
{
	public class SelectStarDbAccess
	{
		public SelectStarDbAccess ()
		{
		}

		public static SelectStarDbAccess CreateSelectStarDbAccess(SelectStarDbAccessKind kind)
		{
			switch (kind)
			{
			case SelectStarDbAccessKind.Npgsql:
				return new SelectStarDbAccessPostgre();
			case SelectStarDbAccessKind.Mysql:
				return new SelectStarDbAccessMySql();
			}
			return null;
		}

		public virtual void OpenConnection()
		{
			throw new NotImplementedException("OpenConnection");
		}

		public virtual System.Data.IDbConnection GetConnection()
		{
			throw new NotImplementedException("GetConnection");
		}

		public virtual int ExecuteCommand(string sql)
		{
			int ra = -1;
			using (var cmd = GetConnection().CreateCommand())
			{
				cmd.CommandText = sql;
				ra = cmd.ExecuteNonQuery();
			}
			return ra;
		}

		public virtual void DropTable(string TableName)
		{
			var sql = string.Format("drop table if exists {0}", TableName);
			ExecuteCommand(sql);
		}

		public virtual IDbDataAdapter GetDataAdapterForSQL(string sql)
		{
			throw new NotImplementedException("GetDataAdapterForSQL");
		}

		public virtual void PerformSelectStar(string TableName)
		{
			try
			{
				var sql = "select * from " + TableName;
				var dataAdapter = GetDataAdapterForSQL(sql);
				var dataSet = new DataSet();
				dataAdapter.Fill(dataSet);
				var columns = "";
				foreach (DataColumn column in dataSet.Tables[0].Columns)
				{
					columns += column.ColumnName + " ";
				}
				Console.WriteLine("Columns: " + columns);
			}
			catch (Exception ex)
			{
				Console.WriteLine("PerformSelectStar: " + ex.Message);
			}
		}

		public enum SelectStarDbAccessKind
		{
			Npgsql,
			Mysql
		}
	}
}

