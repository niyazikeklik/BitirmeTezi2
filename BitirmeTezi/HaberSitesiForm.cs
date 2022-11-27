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
public partial class HaberSitesiForm : Form
{
	List<Button> Kategoriler = new List<Button>();
	DBContext dB;
	public HaberSitesiForm(string kaynak, DBContext dB)
	{
		this.dB = dB;
		InitializeComponent();
		this.lbl_Kaynak.Text = kaynak;
	}

	public Button KategoriButtonCretor(string KategoriAdi)
	{
		var kategoriBtn = new Button()
		{
			Text = KategoriAdi,
			BackColor = Color.White,
			ForeColor = Color.Red,
			Dock = DockStyle.Top,
			Height = 50,
			Font = new Font("Arial", 12, FontStyle.Bold),

		};
		kategoriBtn.Click += Form2Ac;
		return kategoriBtn;
	}

	private void button1_Click(object sender, EventArgs e)
	{
		//input Box
		string KategoriAdi = Microsoft.VisualBasic.Interaction.InputBox("Kategori Adı Giriniz", "Kategori Ekle", "Kategori Adı", -1, -1);

		this.Kategoriler.Add(KategoriButtonCretor(KategoriAdi));
		dB.Kategoriler.Add(new Entity.Conc.Kategoriler()
		{
			Name = KategoriAdi,
			site = dB.HaberSiteleri.First(t => t.Name == this.lbl_Kaynak.Text)
		});
		dB.SaveChanges();
		panelDoldur();
	}

	private void Form2Ac(object? sender, EventArgs e)
	{
		var btn = sender as Button;
		new Form2(btn.Text, lbl_Kaynak.Text, new DBContext()).Show();
	}
	void panelDoldur()
	{
		this.pnl_Kategoriler.Controls.Clear();
		this.pnl_Kategoriler.Controls.AddRange(Kategoriler.ToArray());
	}

	private void HaberSitesi_Load(object sender, EventArgs e)
	{
		var kategoriler = dB.HaberSiteleri.Include(x => x.Kategoriler).First(x => x.Name == this.lbl_Kaynak.Text).Kategoriler.Select(x => x.Name).ToList();
		foreach (var item in kategoriler)
		{
			this.Kategoriler.Add(KategoriButtonCretor(item));
		}
		panelDoldur();
	}

	private void pnl_Kategoriler_Paint(object sender, PaintEventArgs e)
	{

	}
}
