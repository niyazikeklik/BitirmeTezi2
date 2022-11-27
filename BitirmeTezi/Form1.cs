using DTO;

using Entity.Conc;

using Microsoft.EntityFrameworkCore;

using OpenQA.Selenium;

using Service;
using Service.HaberSiteleri;

using System.Collections.ObjectModel;
using System.Linq;

namespace BitirmeTezi
{
	public partial class Form1 : Form
	{
		List<HaberSitesiModel> HaberSiteleri = new List<HaberSitesiModel>();
		IWebDriver dr;
		public DBContext ct;
		public Form1(DBContext ct)
		{

			ct.Database.Migrate();
			this.ct = ct;
			InitializeComponent();
		}


		private void button1_Click_2(object sender, EventArgs e)
		{
			//inputbox
			string KategoriAdi = Microsoft.VisualBasic.Interaction.InputBox("Haber Sitesi Adı Giriniz", "Haber Sitesi Ekle", "Haber Sitesi Adı", -1, -1);
			var x = new Entity.Conc.HaberSitesiModel()
			{
				Name = KategoriAdi,
				Kategoriler = null
			};
			try
			{

				ct.HaberSiteleri.Add(x);
				this.HaberSiteleri.Add(x);
				ct.SaveChanges();
				new Form1(ct).Show();
				this.Hide();
			}
			catch (Exception ex)
			{

				MessageBox.Show("Aynı haber sitesinden zaten var.", "Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Stop);
			}
		}
		private void HaberSiteleriCreator()
		{


			foreach (var item in HaberSiteleri)
			{
				var x = new HaberSitesiForm(item.Name, ct);
				x.Dock = DockStyle.Left;
				x.Size = new Size(200, 200);


				x.TopLevel = false;
				panel1.Controls.Add(x);
				x.Show();
			}
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			this.HaberSiteleri = ct.HaberSiteleri.ToList();
			double x = 0.75;
			double y = 200.0;
			var conuc = Convert.ToInt32((Convert.ToDouble(HaberSiteleri.Count) + x) * y);
			this.Size = new Size(conuc, 500);
			HaberSiteleriCreator();
		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{

		}

		private void button2_Click(object sender, EventArgs e)
		{
			new Form3(ct).Show();
		}
	}
}