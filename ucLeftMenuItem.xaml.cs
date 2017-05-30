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
	/// Interaktionslogik für ucLeftMenuItem.xaml
	/// </summary>
	public partial class ucLeftMenuItem : UserControl
	{

		private string itemText;


		public ucLeftMenuItem()
		{
			InitializeComponent();
		}

		public string ItemText
		{
			get
			{
				return itemText;
			}

			set
			{
				this.itemText = value;
				this.mlText.Text = this.itemText;
			}
		}


		private void UserControl_MouseEnter(object sender, MouseEventArgs e)
		{
			this.mlText.FontWeight = FontWeights.Bold;
			this.mlIconName.Padding = new Thickness((double)12);
		}

		private void UserControl_MouseLeave(object sender, MouseEventArgs e)
		{
			this.mlText.FontWeight = FontWeights.Normal;
			this.mlIconName.Padding = new Thickness((double)15);
		}
	}
}
