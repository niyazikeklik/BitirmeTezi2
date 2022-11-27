namespace BitirmeTezi;

partial class HaberSitesiForm
{
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	/// <summary>
	/// Clean up any resources being used.
	/// </summary>
	/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	protected override void Dispose(bool disposing)
	{
		if (disposing && (components != null))
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	#region Windows Form Designer generated code

	/// <summary>
	/// Required method for Designer support - do not modify
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent()
	{
			this.panel1 = new System.Windows.Forms.Panel();
			this.pnl_Kategoriler = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lbl_Kaynak = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.button1 = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.pnl_Kategoriler);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Controls.Add(this.panel3);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(293, 309);
			this.panel1.TabIndex = 0;
			// 
			// pnl_Kategoriler
			// 
			this.pnl_Kategoriler.AutoScroll = true;
			this.pnl_Kategoriler.AutoSize = true;
			this.pnl_Kategoriler.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnl_Kategoriler.Location = new System.Drawing.Point(0, 35);
			this.pnl_Kategoriler.Name = "pnl_Kategoriler";
			this.pnl_Kategoriler.Size = new System.Drawing.Size(293, 237);
			this.pnl_Kategoriler.TabIndex = 1;
			this.pnl_Kategoriler.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_Kategoriler_Paint);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.lbl_Kaynak);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(293, 35);
			this.panel2.TabIndex = 0;
			// 
			// lbl_Kaynak
			// 
			this.lbl_Kaynak.BackColor = System.Drawing.Color.Maroon;
			this.lbl_Kaynak.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbl_Kaynak.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lbl_Kaynak.ForeColor = System.Drawing.Color.White;
			this.lbl_Kaynak.Location = new System.Drawing.Point(0, 0);
			this.lbl_Kaynak.Name = "lbl_Kaynak";
			this.lbl_Kaynak.Size = new System.Drawing.Size(293, 35);
			this.lbl_Kaynak.TabIndex = 0;
			this.lbl_Kaynak.Text = "Kaynak";
			this.lbl_Kaynak.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.button1);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel3.Location = new System.Drawing.Point(0, 272);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(293, 37);
			this.panel3.TabIndex = 2;
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.White;
			this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.button1.Font = new System.Drawing.Font("Segoe Print", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.button1.ForeColor = System.Drawing.Color.Brown;
			this.button1.Location = new System.Drawing.Point(0, 0);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(293, 37);
			this.button1.TabIndex = 0;
			this.button1.Text = "Kategori Ekle";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// HaberSitesiForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(293, 309);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "HaberSitesiForm";
			this.Text = "HaberSitesi";
			this.Load += new System.EventHandler(this.HaberSitesi_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.ResumeLayout(false);

	}

	#endregion

	private Panel panel1;
	private Panel pnl_Kategoriler;
	private Panel panel2;
	private Label lbl_Kaynak;
	private Panel panel3;
	private Button button1;
}