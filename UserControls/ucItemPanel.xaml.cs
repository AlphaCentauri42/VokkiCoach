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
	/// Interaktionslogik für ucItemList.xaml
	/// </summary>
	public partial class ucItemPanel : UserControl
	{

		//public event EventHandler mainwin = delegate {};

		public int ActionID { get; set; }
		public bool Clicked { get; set; }

		public ActionType Status { get; set; }

		public enum ActionType

		{
			Default,
			Bearbeiten,
			Loeschen,
			Kopieren,
			Neuladen
		}

		public ucItemPanel()
		{
			InitializeComponent();
			this.ActionID = -1;
		}

		/// <summary>
		/// Eintrag aus der Datenbank löschen
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Loeschen_MouseDown(object sender, RoutedEventArgs e)
		{

			Console.WriteLine("loesche " + this.ActionID.ToString());
			clsSQLService db = new clsSQLService();
			db.loescheKategorie(this.ActionID);
			this.Status = ActionType.Neuladen;

		}


		private void ucPanel_MouseEnter(object sender, RoutedEventArgs e)
		{
			this.ucPanel.Background = new SolidColorBrush(Color.FromArgb(30, 0, 0, 0));
		}

		private void ucPanel_MouseLeave(object sender, RoutedEventArgs e)
		{
			this.ucPanel.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
		}

		/// <summary>
		/// Öffne Feld zum direkten Bearbeiten
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void bearbeiten_MouseDown(object sender, RoutedEventArgs e)
		{
			Console.WriteLine("bearbeiten");
			this.itemEdit.Visibility = Visibility.Visible;
			this.itemSave.Visibility = Visibility.Visible;
			this.Copy.Visibility = Visibility.Collapsed;
			this.Status = ActionType.Bearbeiten;
			this.itemEdit.Text = this.Inhalt.Text;

		}

		private void ucPanel_MouseDown(object sender, MouseButtonEventArgs e)
		{
			Console.WriteLine("panel geklickt");
			this.Clicked = true;
		}

		/// <summary>
		/// Übergitb Kopieranweisung an Übergeordnetes Feld
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void copy_MouseDown(object sender, MouseButtonEventArgs e)
		{
			Console.WriteLine("copy");
			this.Status = ActionType.Kopieren;
		}

		/// <summary>
		/// Speichere Eingaben in Datenbank per Update
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void save_MouseDown(object sender, MouseButtonEventArgs e)
		{

			Console.WriteLine("save");
			this.itemEdit.Visibility = Visibility.Collapsed;
			this.itemSave.Visibility = Visibility.Collapsed;
			this.Copy.Visibility = Visibility.Visible;

			clsSQLService db = new clsSQLService();
			db.andereKategorie(this.ActionID, this.itemEdit.Text);
			this.Status = ActionType.Neuladen;

			//TODO reiche event weiter
			//this.mainwin(sender, e);

		}
	}
}
