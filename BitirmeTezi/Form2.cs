using Entity.Conc;
using Service.HaberSiteleri;
using Service;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using DTO;
using OpenQA.Selenium;
using static System.Windows.Forms.LinkLabel;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Microsoft.VisualBasic;

namespace BitirmeTezi;
public partial class Form2 : Form
{
	DBContext ct;
	string path = "";
	public Form2(string Kategori, string Kaynak,
		DBContext ct, string acilmaYeri = "", bool ozelDosya = false)
	{
		//PROGRESS BAR VALUE CHANGE EVENT

		this.ct = ct;
		InitializeComponent();
		//if (ozelDosya)
		//{

		//	this.path = Kaynak + "\\" + Kategori + "\\";
		//	this.checkBox1.Checked = true;
		//}
		//else
		//{
		//	if (Directory.Exists(Kaynak + "\\" + Kategori + "\\") && acilmaYeri != "")
		//	{
		//		var x = MessageBox.Show("Klasör içindeki tüm dosyalar ile silinecek. Emin misiniz?\n\nKlasör: " + Kaynak + "\\" + Kategori + "\\",
		//			"Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
		//		if (x == DialogResult.Yes)
		//		{
		//			Directory.Delete(Kaynak + "\\" + Kategori + "\\", true);
		//			path = Kaynak + "\\";
		//			this.checkBox1.Checked = false;
		//		}
		//		else
		//		{
		//			this.path = Kaynak + "\\" + Kategori + "\\";
		//			this.checkBox1.Checked = true;
		//		}
		//	}
		//	else
		//	{
		//		this.path = Kaynak + "\\" + Kategori + "\\";
		//		this.checkBox1.Checked = true;
		//	}
		//}
		path = Kaynak + "\\";
		if (!Directory.Exists(path))
			Directory.CreateDirectory(path);
		lbl_Kategori.Text = Kategori;
		lbl_Kayank.Text = Kaynak;
	}
	void Calistir(params string[] Linkler)
	{
		Task.Run(() =>
		{
			var dr = Drivers.CreateDrivers();
			var bbc = new HaberSitesi(dr);
			List<Haber> haberler = new();
			foreach (var item in Linkler)
			{
				if (item.Contains("yazarlar")) continue;
				try
				{
					dr.Navigate().GoToUrl(item);

					var haber = new Haber
					{
						Baslik = bbc.GetBaslik(txt_Baslik.Text),
						Icerik = bbc.GetIcerik(txt_Icerik.Text),
						Kaynak = lbl_Kayank.Text,
						Tarih = bbc.GetTarih(tarih_Txt.Text),
						Kategori = lbl_Kategori.Text
					};
					if (haber.IsValid())
					{
						ct.Add(haber);
						ct.SaveChanges();
					}
					metroProgressBar1.Value++;
				}
				catch (Exception ex)
				{

					;
				}

			}
			dr.Quit();

		});
	}
	void refresh()
	{
		var dsyalar = Directory.GetFiles(path, "*.js", SearchOption.TopDirectoryOnly);
		foreach (var dosya2 in dsyalar)
		{
			var dosya = new FileInfo(dosya2);
			foreach (var control in this.Controls.Cast<Control>())
			{
				if (dosya.Name.Contains(control.Name) && control is RichTextBox)
				{
					var richText = control as RichTextBox;
					richText.Text = File.ReadAllText(dosya.FullName);
				}
			}
		}
	}

	private void Form2_Load(object sender, EventArgs e)
	{
		refresh();

	}



	void Kaydet(RichTextBox textBox)
	{
		var path2 = path + textBox.Name + ".js";

		if (!File.Exists(path2))
		{
			File.Create(path2).Close();
		}
		File.WriteAllText(path2, textBox.Text);

	}

	private void btn_Tarih_Click(object sender, EventArgs e)
	{
		Kaydet(tarih_Txt);
	}

	private void btn_Baslik_Click(object sender, EventArgs e)
	{
		Kaydet(txt_Baslik);
	}

	private void btn_Icerik_Click(object sender, EventArgs e)
	{
		Kaydet(txt_Icerik);
	}

	void JsFileOpenWithDefaultProgram(object sender)
	{
		var path2 = path + ((RichTextBox)sender).Name + ".js";
		if (!File.Exists(path2))
		{
			File.Create(path2).Close();
			File.WriteAllText(path2, "");
		}
		Process.Start(new ProcessStartInfo(path2)
		{
			UseShellExecute = true
		});

	}

	private void txt_Baslik_DoubleClick(object sender, EventArgs e)
	{
		JsFileOpenWithDefaultProgram(sender);
	}

	private void tarih_Txt_DoubleClick(object sender, EventArgs e)
	{
		JsFileOpenWithDefaultProgram(sender);
	}

	private void txt_Icerik_DoubleClick(object sender, EventArgs e)
	{
		JsFileOpenWithDefaultProgram(sender);
	}

	private void button1_Click(object sender, EventArgs e)
	{
		string[] linkler = gridView1.View.Rows.Cast<DataGridViewRow>().Select(x => x.Cells[0].Value.ToString()).ToArray();
		Calistir(linkler);
	}
	List<string> linkler = new();
	string oncekiURL = "";
	void Toplayici(IWebDriver dr, string url)
	{
		if (url == null)
		{
			gridView1.View.SetData(linkler);
			return;
		}
		dr.Navigate().GoToUrl(url);
		oncekiURL = url;

		var urls = (ReadOnlyCollection<object>)dr.JsRun(txt_AElements.Text);
		if (urls != null)
		{
			foreach (var item in urls)
			{
				linkler.Add(item.ToString());
			}
		}
		string nextPage = dr.JsRun(txt_NextPage.Text) as string;
		if (nextPage != oncekiURL)
		{
			Toplayici(dr, nextPage);
		}
		else
		{
			gridView1.View.SetData(linkler);
			return;
		}

	}

	private void button2_Click(object sender, EventArgs e)
	{
		var dr = Drivers.CreateDrivers();
		Toplayici(dr, txt_BaslangicURL.Text);
		dr.Close();
	}

	private void button5_Click(object sender, EventArgs e)
	{
		Kaydet(txt_BaslangicURL);
	}

	private void button4_Click(object sender, EventArgs e)
	{
		Kaydet(txt_AElements);
	}

	private void button3_Click(object sender, EventArgs e)
	{
		Kaydet(txt_NextPage);
	}

	private void ManuelGir(object sender, EventArgs e)
	{
		var form = new InputBox();
		form.ShowDialog();
		string[] linkler = form.kelimeler;
		this.gridView1.View.SetData(linkler);


	}

	private void Refresh(object sender, EventArgs e)
	{
		refresh();
	}

	private void checkBox1_CheckedChanged(object sender, EventArgs e)
	{

	}

	private void checkBox1_Click(object sender, EventArgs e)
	{

		new Form2(this.lbl_Kategori.Text, this.lbl_Kayank.Text, this.ct, "Kendi", checkBox1.Checked).Show();
		this.Close();
	}

	private void txt_AElements_DoubleClick(object sender, EventArgs e)
	{
		JsFileOpenWithDefaultProgram(sender);
	}

	private void txt_NextPage_DoubleClick(object sender, EventArgs e)
	{
		JsFileOpenWithDefaultProgram(sender);
	}

	private void label9_Click(object sender, EventArgs e)
	{

	}

	private void metroProgressBar1_ValueChanged(object sender)
	{

		Task.Run(() =>
		{
			metroProgressBar1.Minimum = 0;
			metroProgressBar1.Maximum = this.gridView1.View.Rows.Count;
			if (metroProgressBar1.Value == metroProgressBar1.Maximum + 1)
			{
				metroProgressBar1.Value = 0;
				MessageBox.Show("Tamamlandı");
			}
			else
			{
				label9.Text = metroProgressBar1.Value.ToString() + "/" + metroProgressBar1.Maximum.ToString();
			}
		});

	}
}
