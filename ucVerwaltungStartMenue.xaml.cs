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
	/// Interaktionslogik für ucVerwaltungStartMenue.xaml
	/// </summary>
	public partial class ucVerwaltungStartMenue : UserControl
	{
		private string clicked;

		public ucVerwaltungStartMenue()
		{
			InitializeComponent();
		}

		// Unterscheidung, was geklickt wurde aus dem Text der Menübezeichnung
		// TODO ggf unanhängig vom Menü-Text gestalten
		public string Clicked
		{
			get
			{
				return clicked;
			}

			set
			{
				this.clicked = value;
			}
		}


		// TODO Code vereinigen
		private void mKategorie_MouseDown(object sender, MouseButtonEventArgs e)
		{
			ucLeftMenuItem mi = (ucLeftMenuItem)sender;
			this.Clicked = mi.mlText.Text;
		}

		private void mVokabeln_MouseDown(object sender, MouseButtonEventArgs e)
		{
			ucLeftMenuItem mi = (ucLeftMenuItem)sender;
			this.Clicked = mi.mlText.Text;
		}

		private void mUebersetzungen_MouseDown(object sender, MouseButtonEventArgs e)
		{

		}
	}
}
