using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VokkiCoach
{
	/// <summary>
	/// Interaktionslogik für ucIcon.xaml
	/// </summary>
	public partial class ucIcon : UserControl
	{

		private string icoName;

		public ucIcon( )
		{
			InitializeComponent();
			// Fallback
			this.IcoName = "Add";
		}

		public string IcoName
		{
			get
			{
				return icoName;
			}

			set
			{
				this.icoName = value;
				genGrafik();
			}
		}

		private void genGrafik()
		{
			 
			FileStream fs = new FileStream("c:\\tmp\\" + this.IcoName + "_16x.xaml", FileMode.Open);
			 
			UIElement o = (UIElement)XamlReader.Load(fs);
			this.ico.Child = o;
		}
	}
}
