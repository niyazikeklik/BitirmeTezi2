using DTO;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BitirmeTezi;
public partial class Form3 : Form
{
	DBContext ct;
	public Form3(DBContext ct)
	{
		this.ct = ct;
		InitializeComponent();
	}
	private void seçilenSatırlarıSilToolStripMenuItem_Click(object sender, EventArgs e)
	{
		foreach (DataGridViewRow item in this.gridView1.View.SelectedRows)
		{
			var haber = ct.Haberler.First(t => t.Id == (int)item.Cells[0].Value);
			ct.Haberler.Remove(haber);

		}
		ct.SaveChanges();
		MessageBox.Show("Seçili Satırlar Silindi", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
	}

	private void gridView1_Load(object sender, EventArgs e)
	{
		//selection row mode full
		this.gridView1.View.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		this.gridView1.View.DataSource = ct.Haberler.ToList();

	}

	private void Form3_Load(object sender, EventArgs e)
	{

	}
}
