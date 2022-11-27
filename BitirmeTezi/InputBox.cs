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
public partial class InputBox : Form
{
	public InputBox()
	{
		InitializeComponent();
	}
	public string[] kelimeler;
	private void richTextBox1_TextChanged(object sender, EventArgs e)
	{
		this.kelimeler = richTextBox1.Text.Split(';');
		label1.Text = "Toplam " + kelimeler.Length + " bulundu.";
	}

	private void button1_Click(object sender, EventArgs e)
	{
		this.Hide();
	}
}
