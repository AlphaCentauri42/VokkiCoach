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
	/// Interaktionslogik für MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{

		private ucVerwaltungStartMenue menueVerwaltung;
		private ucNeueKategorie verwaltungKategorie;
		private ucNeueVokabeln verwaltungVokabeln;
		

		public MainWindow()
		{
			InitializeComponent();
			this.mTraining.Text.Text = "TRAINING";
			this.mTraining.Ico.IcoName = "Run";

			this.mStatistik.Text.Text = "STATISTIK";
			this.mStatistik.Ico.IcoName = "AvailabilityColumnChart";

			this.mHilfe.Text.Text = "HILFE";
			this.mHilfe.Ico.IcoName = "Lightbulb";

			this.mVerwaltung.Text.Text = "VERWALTUNG";
			this.mVerwaltung.Ico.IcoName = "Settings";




		}


		private void mHilfe_MouseDown(object sender, MouseButtonEventArgs e)
		{

		}

		private void mStatistik_MouseDown(object sender, MouseButtonEventArgs e)
		{

		}

		private void mTraining_MouseDown(object sender, MouseButtonEventArgs e)
		{

		}


		/// <summary>
		/// Verwaltungsbereich
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mVerwaltung_MouseDown(object sender, MouseButtonEventArgs e)
		{
			this.menueVerwaltung = new ucVerwaltungStartMenue();
			this.menueVerwaltung.verwaltungMenueText.Text = "Verwaltung";
			this.areaLeft.Child = this.menueVerwaltung;

		}

		/// <summary>
		/// Ereignisse, wenn allg auf den Linken Bereich ( mit Menü ) geklickt wurde
		/// Prüfen, welchen Zustand die Menüliste besitzt
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void areaLeft_MouseDown(object sender, MouseButtonEventArgs e)
		{

			//Wer sendet? 
			
			Console.WriteLine( "linkes Menü : " + menueVerwaltung.Clicked);


			if (menueVerwaltung.Clicked == "Kategorie")
			{
				this.verwaltungKategorie = new ucNeueKategorie();
				this.areaRight.Child = this.verwaltungKategorie;
			}

			if (menueVerwaltung.Clicked == "Vokabeln")
			{
				this.verwaltungVokabeln = new ucNeueVokabeln();
				this.areaRight.Child = this.verwaltungVokabeln;
			}

			menueVerwaltung.Clicked = "";
			

		}
	}
}
