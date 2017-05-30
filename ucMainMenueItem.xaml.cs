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
	/// Interaktionslogik für ucMainMenueItem.xaml
	/// </summary>
	public partial class ucMainMenueItem : UserControl
	{
		
		public ucMainMenueItem()
		{
			InitializeComponent();
		}


		private void UserControl_MouseEnter(object sender, MouseEventArgs e)
		{
			this.pnlBackground.Cursor = Cursors.Hand;
			this.Text.FontWeight = FontWeights.Bold;
			this.bottomBorder.Background = new SolidColorBrush(Color.FromArgb(255, 255, 160, 0));

		}

		private void UserControl_MouseLeave(object sender, MouseEventArgs e)
		{
			this.pnlBackground.Cursor = Cursors.AppStarting;
			this.Text.FontWeight = FontWeights.Normal;
			this.bottomBorder.Background = new SolidColorBrush(Color.FromArgb(127, 0, 0, 255));

		}

	}
}
