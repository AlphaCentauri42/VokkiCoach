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
	/// Interaktionslogik für ucItemKategorieSelect.xaml
	/// </summary>
	public partial class ucItemKategorieSelect : UserControl
	{

		public int ActionID { get; set; }
		public bool Clicked { get; set; }

		public ActionType Status { get; set; }

		public enum ActionType

		{
			Default,
			KategorieWaehlen,
			Neuladen
		}


		public ucItemKategorieSelect()
		{
			InitializeComponent();
		}

		private void ucPanel_MouseDown(object sender, MouseButtonEventArgs e)
		{
			Console.WriteLine("panel geklickt");
			this.Clicked = true;
		}
	}
}
