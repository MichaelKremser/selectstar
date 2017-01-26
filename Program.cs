using System;

namespace SelectStar
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var tempTable = "TEMP_PS_000";
			var tabDef1 = "CREATE TABLE " + tempTable + " (SESSIONID VARCHAR(40), EXECNR INTEGER, DUEDATE DATE)";
			var tabDef2 = "CREATE TABLE " + tempTable + " (YADUEDATE DATE, NEWFIELD VARCHAR(100), SOMEOTHER INTEGER)";

			try
			{
				var wantedDb = SelectStarDbAccess.SelectStarDbAccessKind.Mysql;
				var db = SelectStarDbAccess.CreateSelectStarDbAccess(wantedDb);
				if (db == null)
				{
					Console.WriteLine ("Could not get an instance of " + wantedDb.ToString());
				}
				else
				{
					db.OpenConnection();

					foreach (var tabDefX in new string[] { tabDef1, tabDef2 })
					{
						Console.WriteLine("Dropping " + tempTable + "... ");
						db.DropTable(tempTable);
						Console.Write("Creating " + tempTable + " with these columns: " + tabDefX.Substring(tabDefX.IndexOf('(')) + " ...");
						db.ExecuteCommand(tabDefX);
						Console.WriteLine("Done!");
						db.PerformSelectStar(tempTable);
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine ("Error: " + ex.Message + "\n" + ex.StackTrace);
			}

//			Console.ReadKey(true);
		}
	}
}
