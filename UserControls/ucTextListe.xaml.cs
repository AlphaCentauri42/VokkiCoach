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
	/// Eine Liste mit bearbeitbaren Kategorien
	/// </summary>
	public partial class ucTextListe : UserControl
	{
		private List<ucItemPanel> itemList = new List<ucItemPanel>();
		// Weiterreichen eines geklickten Objekts
		public ucItemPanel Target = null;

		public ucTextListe()
		{
			InitializeComponent();
		}


		/// <summary>
		/// Hinzufügen einzelner Texte
		/// </summary>
		/// <param name="txt"></param>
		public void addColumn(string txt)
		{
			TextBlock txtObj = new TextBlock();
			txtObj.Text = txt;
			this.stPanel.Children.Add(txtObj);
		}

		/// <summary>
		/// Hinzufügen einer Liste an Texten
		/// </summary>
		/// <param name="dbDataField"></param>
		public void addColumn( List<List<object>> dbDataField )
		{
			for (int i = 0; i < dbDataField.Count; i++)
			{
				ucItemPanel item = new ucItemPanel();
				item.ActionID = Convert.ToInt32( dbDataField[i][0] );
				item.Inhalt.Text = dbDataField[i][1].ToString();
				this.itemList.Add(item);
				this.stPanel.Children.Add( item );
			}
		}

		/// <summary>
		/// Ersetze alle Text-Einträge durch die Liste neuer Text-Einträge
		/// </summary>
		/// <param name="txtList"></param>
		public void replaceAll()
		{
			stPanel.Children.Clear();
			this.itemList.Clear();
		}

		private void stPanel_MouseDown(object sender, MouseButtonEventArgs e)
		{
			for (int i = 0; i < this.itemList.Count; i++)
			{
				if (this.itemList[i].Clicked == true)
				{
					Target = itemList[i];
					break;
				}
			}

		}
	}
}
