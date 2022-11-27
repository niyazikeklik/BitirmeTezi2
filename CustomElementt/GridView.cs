using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomeElements
{
	public partial class GridView : UserControl
	{
		public string Baslik
		{
			get
			{
				return lbl_baslikk.Text;
			}
			set
			{
				lbl_baslikk.Text = value;
			}
		}

		public GridView()
		{
			InitializeComponent();
		}
		private void GridView_Load(object sender, EventArgs e)
		{
			//panel1.BackColor = Color.FromArgb(60, 255, 255, 255);
		}

		private void ExcelAktar()
		{
			DataObject dataObj = this.View.GetClipboardContent();
			if (dataObj != null)
				Clipboard.SetDataObject(dataObj);
			Microsoft.Office.Interop.Excel.Application xlexcel;
			Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
			Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
			object misValue = System.Reflection.Missing.Value;
			xlexcel = new Microsoft.Office.Interop.Excel.Application();
			xlexcel.Visible = true;
			xlWorkBook = xlexcel.Workbooks.Add(misValue);
			xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
			Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 1];
			CR.Select();
			xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
			this.View.ClearSelection();
		}
		private void ExceleAktar_Click(object sender, EventArgs e)
		{
			this.View.SelectAll();
			ExcelAktar();
		}

		private void View_DataSourceChanged(object sender, EventArgs e)
		{
			this.label1.Text = this.View.SelectedRows.Count + "/" + this.View.Rows.Count.ToString();
		}

		private void View_SelectionChanged(object sender, EventArgs e)
		{
			this.label1.Text = this.View.SelectedRows.Count + "/" + this.View.Rows.Count.ToString();
		}

		private void seçiliSatırlarToolStripMenuItem_Click(object sender, EventArgs e)
		{

			ExcelAktar();
		}
	}
}
