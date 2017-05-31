using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VokkiCoach
{
	/// <summary>
	/// Interaktionslogik für ucNeueKategorie.xaml
	/// </summary>
	public partial class ucNeueKategorie : UserControl
	{
		private bool anDBSendenErlaubt = false;
		

		public ucNeueKategorie()
		{
			InitializeComponent();
			this.chkButtonStatusDB();
		}


		/// <summary>
		/// Reagiert auf Eingaben sofort und such in der Datenbank nach Ähnlichkeiten
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			this.reloadKategorieListe();
			this.chkButtonStatusDB();
			this.txtKategorie.Focus();
		}



		private void reloadKategorieListe()
		{
			if (this.txtKategorie.Text.Length > 0)
			{

				// Prüfenn ob ähnliche Einträge exsistieren -> ja max 5 anzeigen
				clsSQLService db = new clsSQLService();
				List<List<object>> treffer = db.getKategorieListeLike(this.txtKategorie.Text);
				if (treffer.Count > 0)
				{
					this.txtListDaten.replaceAll();
					this.txtListDaten.addColumn(treffer.Count.ToString() + " ähnlichen Kategorien!");
					this.txtListDaten.addColumn(treffer);
				}
				else
				{
					this.txtListDaten.replaceAll();
					this.txtListDaten.addColumn("Keine ähnlichen Kategorien gefunden!");
				}

				// Prüfen ob der Eintrag schon exsistiert
				this.anDBSendenErlaubt = !db.chkEintragVorhanden(this.txtKategorie.Text);

			}
			else
			{
				this.ladeAlleKategorien();
			}
		}

		/// <summary>
		/// Button prüfen und festlegen ob der Datenbankeintrag zugelassen ist
		/// </summary>
		public void chkButtonStatusDB()
		{
			this.picNeuerEintrag.IcoName = (anDBSendenErlaubt) ? "Save" : "StatusNo";
			this.picNeuerEintrag.ToolTip = (anDBSendenErlaubt) ? "Kategorie eintragen!" : "Keine Doppelten Einträge möglich!";
			this.btnDBEintrag.IsEnabled = anDBSendenErlaubt;
		}

		/// <summary>
		/// Stand der aktuellen Kategorien
		/// </summary>
		private void ladeAlleKategorien()
		{
			clsSQLService db = new clsSQLService();
			List<List<object>> treffer = db.getKategorieListeAlles();
			if (treffer.Count > 0)
			{
				this.txtListDaten.replaceAll();
				this.txtListDaten.addColumn(treffer.Count.ToString() + " Kategorien vorhanden");
				this.txtListDaten.addColumn(treffer);
			}
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnDBEintrag_Click(object sender, RoutedEventArgs e)
		{
			clsSQLService db = new clsSQLService();
			// Korrigiere Fehler im Text

			if ( this.chkTextfeld() == true ) { 
				db.neuKategorie(this.txtKategorie.Text);
				this.txtKategorie.Text = "";
				this.picNeuerEintrag.IcoName = "StatusOK";
				this.reloadKategorieListe();
			} else
			{
				this.txtKategorie.Text = "";
				this.picNeuerEintrag.IcoName = "Cancel";
			}
		}

		private bool chkTextfeld()
		{
			// Whitespaces am Anfang und Ende entfernen
			this.txtKategorie.Text.Trim();

			// Prüfe die Textlänge
			bool ok = false;
			ok = (this.txtKategorie.Text.Length > 0) ? true : false;
			return ok;
		}

		/// <summary>
		/// LINKS - Klick auf die Textliste für Bearbeitung
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtListDaten_MouseDown(object sender, RoutedEventArgs e)
		{

			if (this.txtListDaten.Target.Status == ucItemPanel.ActionType.Loeschen)
			{
				this.reloadKategorieListe();
			}

			if (this.txtListDaten.Target.Status == ucItemPanel.ActionType.Kopieren)
			{
				this.txtKategorie.Text = this.txtListDaten.Target.Inhalt.Text;
			}

			if (this.txtListDaten.Target.Status == ucItemPanel.ActionType.Neuladen)
			{
				this.reloadKategorieListe();
				chkButtonStatusDB();
			}


			this.txtListDaten.Target.Clicked = false;

		}

		/// <summary>
		/// Initialanweisung nach dem Laden
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			this.txtKategorie.Focus();
			this.ladeAlleKategorien();
		}

		/// <summary>
		/// RECHTS - Klick auf die Textliste für Bearbeitung
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// 
		/*
		private void txtListDatenAlt_MouseDown(object sender, MouseButtonEventArgs e)
		{

			if (this.txtListDatenAlt.Target.Status == ucItemPanel.ActionType.Loeschen)
			{
				this.reloadKategorieListe();
			}

			if (this.txtListDatenAlt.Target.Status == ucItemPanel.ActionType.Kopieren)
			{
				this.txtKategorie.Text = this.txtListDatenAlt.Target.Inhalt.Text;
			}

			if (this.txtListDatenAlt.Target.Status == ucItemPanel.ActionType.Neuladen)
			{
				this.reloadKategorieListe();
				chkButtonStatusDB();
			}


			this.txtListDatenAlt.Target.Clicked = false;

		}*/
	}
}
