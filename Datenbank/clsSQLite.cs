using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VokkiCoach
{
	class clsSQLite
	{
		private string dbs = "Data Source=vokabeltrainer.sqlite";

		SQLiteConnection con = null;
		SQLiteCommand cmd = null;

		public clsSQLite()
		{

		}

		/// <summary>
		/// Datenbank Verbindung
		/// </summary>
		protected void connect()
		{
			this.con = new SQLiteConnection(dbs);
			this.con.Open();
		}

		/// <summary>
		/// Datenbank Ausgaben
		/// </summary>
		/// <param name="q"></param>
		/// <returns></returns>
		protected List<List<object>> query(string q)
		{
			this.connect();
			cmd = new SQLiteCommand(this.con);
			cmd.CommandText = q;
			SQLiteDataReader sdr = cmd.ExecuteReader();
			List<List<object>> result = new List<List<object>>();

			while (sdr.Read())
			{
				List<object> zeile = new List<object>();
				for (int i = 0; i < sdr.FieldCount; i++)
				{
					zeile.Add(sdr.GetValue(i));
				}
				result.Add(zeile);
			}

			this.con.Close();
			return result;
		}

		/// <summary>
		/// Datenbankeinträge INSERT
		/// </summary>
		/// <param name="q"></param>
		/// <returns></returns>
		protected bool toWrite(string q)
		{
			if (q.Length > 0)
			{
				this.connect();
				cmd = new SQLiteCommand(this.con);
				cmd.CommandText = q;
				cmd.ExecuteNonQuery();
				this.con.Close();
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// UNIX-Timestamp basiert aus 1.1.1970
		/// </summary>
		/// <returns></returns>
		protected int timestamp()
		{
			return (Int32)(
				DateTime.UtcNow.Subtract(
					new DateTime(1970, 1, 1)
				)
			).TotalSeconds;
		}

	}
}
