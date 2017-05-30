using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
	/// Interaktionslogik für ucNeueVokabeln.xaml
	/// </summary>
	public partial class ucNeueVokabeln : UserControl
	{
		private bool anDBSendenErlaubt = false;
		public ucNeueVokabeln()
		{
			InitializeComponent();
		}

		private void txtListDaten_MouseDown(object sender, MouseButtonEventArgs e)
		{

		}

		private void btnVokabeleintrag_MouseDown(object sender, MouseButtonEventArgs e)
		{

		}

		private void txtVokabel_TextChanged(object sender, TextChangedEventArgs e)
		{
			this.reloadVokabelnListe();
			this.chkButtonStatusDB();
			//this.txtKategorie.Focus();
		}

		private void reloadVokabelnListe()
		{
			if (this.txtVokabel.Text.Length > 0)
			{
				clsSQLService db = new clsSQLService();
				List<List<object>> treffer = db.getVokabelListeLike(this.txtVokabel.Text);
				if (treffer.Count > 0)
				{
					this.txtListVokabeln.replaceAll();
					this.txtListVokabeln.addColumn(treffer.Count.ToString() + " ähnlichen Vokabeln!");
					this.txtListVokabeln.addColumn(treffer);
				}
				else
				{
					this.txtListVokabeln.replaceAll();
					this.txtListVokabeln.addColumn("Keine ähnlichen Vokabeln gefunden!");
				}

				// Prüfen ob der Eintrag schon exsistiert
				this.anDBSendenErlaubt = !db.chkEintragVorhanden(this.txtVokabel.Text);

			}
			else
			{

				this.ladeAlleVokabeln();
			}

		}

		/// <summary>
		/// Gesamte Vokabelliste laden ggf Einschränken ( TODO )
		/// </summary>
		private void ladeAlleVokabeln()
		{
			clsSQLService db = new clsSQLService();
			List<List<object>> treffer = db.getVokabelnListeAlles();
			if (treffer.Count > 0)
			{
				this.txtListVokabeln.replaceAll();
				this.txtListVokabeln.addColumn(treffer.Count.ToString() + " Kategorien vorhanden");
				this.txtListVokabeln.addColumn(treffer);
			}

		}

		/// <summary>
		/// Button prüfen und festlegen ob der Datenbankeintrag zugelassen ist
		/// </summary>
		public void chkButtonStatusDB()
		{
			this.picNeueVokabel.IcoName = (anDBSendenErlaubt) ? "AddDatabase" : "StatusNo";
			this.picNeueVokabel.ToolTip = (anDBSendenErlaubt) ? "Vokabel eintragen!" : "Keine Doppelten Einträge möglich!";
			this.picNeueVokabel.IsEnabled = anDBSendenErlaubt;

		}

		private void txtListVokabeln_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (this.txtListVokabeln.Target.Status == ucItemVokabeln.ActionType.Neuladen)
			{
				this.reloadVokabelnListe();
				chkButtonStatusDB();
			}
		}

		private void btnKategorieSuche_MouseDown(object sender, MouseButtonEventArgs e)
		{

		}



		private void txtListKategorien_MouseDown(object sender, MouseButtonEventArgs e)
		{

		}

		private void txtKategorie_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			this.txtVokabel.Focus();
			this.ladeAlleVokabeln();
		}

		private void radSprache_Checked(object sender, RoutedEventArgs e)
		{
			this.reloadVokabelnListe();
			this.chkButtonStatusDB();
		}


	}
}
