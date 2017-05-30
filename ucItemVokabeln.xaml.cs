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
	/// Interaktionslogik für ucItemVokabeln.xaml
	/// </summary>
	public partial class ucItemVokabeln : UserControl
	{

		public int ActionID { get; set; }
		public bool Clicked { get; set; }

		public ActionType Status { get; set; }

		public enum ActionType

		{
			Default,
			Bearbeiten,
			Loeschen,
			Kopieren,
			Neuladen,
		}

		public ucItemVokabeln()
		{
			InitializeComponent();
			this.ActionID = -1;
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
		/// Vokabel-Eintrag aus der Datenbank löschen
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void loeschen_MouseDown(object sender, RoutedEventArgs e)
		{

			Console.WriteLine("loesche " + this.ActionID.ToString());
			clsSQLService db = new clsSQLService();
			db.loescheVokabel(this.ActionID);
			this.Status = ActionType.Neuladen;


		}

		private void bearbeiten_MouseDown(object sender, RoutedEventArgs e)
		{

		}

		private void Copy_MouseDown(object sender, RoutedEventArgs e)
		{
			Console.WriteLine("copy");
			this.Status = ActionType.Kopieren;
		}

		private void itemSave_MouseDown(object sender, RoutedEventArgs e)
		{
			Console.WriteLine("save");
			this.itemEdit.Visibility = Visibility.Collapsed;
			this.itemSave.Visibility = Visibility.Collapsed;
			this.Copy.Visibility = Visibility.Visible;

			clsSQLService db = new clsSQLService();
			db.andereVokabel(this.ActionID, this.itemEdit.Text);
			this.Status = ActionType.Neuladen;
		}

		private void ucPanel_MouseDown(object sender, MouseButtonEventArgs e)
		{
			Console.WriteLine("panel geklickt");
			this.Clicked = true;

		}


	}
}
