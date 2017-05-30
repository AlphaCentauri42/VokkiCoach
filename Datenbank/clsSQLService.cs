using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VokkiCoach
{
	class clsSQLService : clsSQLite
	{
		//private clsSQLite sql = null;

		public clsSQLService()
		{
		}

		// Rohabfrage für alle anderen Abfragen als alternative unspezialisier Methoden
		public List<List<object>> getRaw(string sql)
		{
			List<List<object>> result = new List<List<object>>();
			result = readData(sql);
			return result;
		}


		#region Vokabeln

		/// <summary>
		/// sucht ganzes Wort oder Wort mit entsprechenden Anfangsbuchstaben
		/// </summary>
		/// <param name="suche"></param>
		/// <returns></returns>
		public List<List<object>> getVokabelListeLike(string suche)
		{
			List<List<object>> result = new List<List<object>>();

			result = readData(
				@" SELECT vokID , vokName, vokPhonetik , vokSprID , vokTimestamp FROM Vokabeln WHERE vokName LIKE '" + suche + "%' ORDER BY vokTimestamp DESC"
			);
			return result;
		}

		/// <summary>
		/// Vokabeldaten lesen
		/// </summary>
		/// <returns></returns>
		internal List<List<object>> getVokabelnListeAlles()
		{
			List<List<object>> result = new List<List<object>>();
			result = readData(
				@" SELECT vokID , vokName, vokPhonetik , vokSprID , vokTimestamp FROM Vokabeln ORDER BY vokTimestamp DESC"
			);
			return result;
		}

		/// <summary>
		/// Einzelne Vokabel loeschen
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public bool loescheVokabel(int id)
		{
			// TODO - prüfen ob die Kategorie schon verwendet wird
			this.toWrite(@"DELETE FROM Vokabeln WHERE vokID = " + id.ToString());
			return true;
		}

		/// <summary>
		/// Vokabel updaten
		/// </summary>
		/// <param name="id"></param>
		/// <param name="val"></param>
		/// <returns></returns>
		public bool andereVokabel(int id, string val)
		{
			this.toWrite(@"UPDATE Vokabeln SET katName = '" + val + "' WHERE vokID = " + id.ToString());
			return true;
		}

		/// <summary>
		/// Neue Vokabel in Datenbank eintragen
		/// </summary>
		/// <param name="eintrag"></param>
		/// <returns></returns>
		public bool neuVokabel(string vokabel, int sprache)
		{
			//TODO Defalt / Kategorie und Sprache
			// Datenbank-Eintrag
			this.toWrite(
				@"INSERT INTO Vokabeln 
				( vokName , vokSprID , vokTimestamp )
					VALUES 
				( '" + vokabel + @"' , " + sprache.ToString() + " , " + this.timestamp().ToString() + @" )");

			// Ausnahme muss noch behandelt werden
			return true;
		}

		#endregion

		#region Kategorie


		/// <summary>
		/// sucht ganzes Wort oder Wort mit entsprechenden Anfangsbuchstaben
		/// </summary>
		/// <param name="suche"></param>
		/// <returns></returns>
		public List<List<object>> getKategorieListeLike(string suche)
		{
			List<List<object>> result = new List<List<object>>();

			result = readData(
				@" SELECT katID , katBezeichnung FROM Kategorie WHERE katBezeichnung LIKE '" + suche + @"%'"
			);
			return result;
		}

		/// <summary>
		/// Kategoriedaten lesen
		/// </summary>
		/// <returns></returns>
		internal List<List<object>> getKategorieListeAlles()
		{
			List<List<object>> result = new List<List<object>>();
			result = readData(
				@" SELECT katID , katBezeichnung, katTimestamp FROM Kategorie ORDER BY katTimestamp DESC"
			);
			return result;
		}

		/// <summary>
		/// Prüfen ob ein Eintrag in Kategorie schon exisitiert
		/// </summary>
		/// <param name="suche"></param>
		/// <returns></returns>
		public bool chkEintragVorhanden( string suche ) {

			int result = Convert.ToInt32( readData(
				@" SELECT Count(*) FROM Kategorie WHERE katBezeichnung = '" + suche + @"'"
			)[0][0] );

			return ( result == 0 ) ? false : true ;
		}

		/// <summary>
		/// Neue Kategorie in Datenbank eintragen
		/// </summary>
		/// <param name="eintrag"></param>
		/// <returns></returns>
		public bool neuKategorie( string eintrag )
		{

			// Datenbank-Eintrag
			this.toWrite(
				@"INSERT INTO Kategorie 
				( katBezeichnung , katBeschreibung , katTimestamp )
					VALUES 
				( '" + eintrag + @"' , '--' , " + this.timestamp().ToString() + @" )");

			// Ausnahme muss noch behandelt werden
			return true;
		}
		
		/// <summary>
		/// Einzelne Kategorie loeschen
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public bool loescheKategorie( int id)
		{
			// TODO - prüfen ob die Kategorie schon verwendet wird
			this.toWrite( @"DELETE FROM Kategorie WHERE katID = " + id.ToString()  );
			return true;
		}

		/// <summary>
		/// Kategorie Updaten
		/// </summary>
		/// <param name="id"></param>
		/// <param name="val"></param>
		/// <returns></returns>
		public bool andereKategorie( int id , string val)
		{
			this.toWrite(@"UPDATE Kategorie SET katBezeichnung = '" + val + "' WHERE katID = " + id.ToString() );
			return true;
		}

		#endregion

		// allgemeine Datenanfrage über SQL-String
		public List<List<object>> readData(string q)
		{
			return this.query(q);
		}


	}
}
