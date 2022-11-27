namespace BitirmeTezi;

partial class Form3
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
			this.components = new System.ComponentModel.Container();
			this.gridView1 = new CustomeElements.GridView();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.seçilenSatırlarıSilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// gridView1
			// 
			this.gridView1.Baslik = "Başlık";
			this.gridView1.ContextMenuStrip = this.contextMenuStrip1;
			this.gridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gridView1.Location = new System.Drawing.Point(0, 0);
			this.gridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.gridView1.Name = "gridView1";
			this.gridView1.Size = new System.Drawing.Size(800, 450);
			this.gridView1.TabIndex = 0;
			this.gridView1.Load += new System.EventHandler(this.gridView1_Load);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seçilenSatırlarıSilToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(169, 26);
			// 
			// seçilenSatırlarıSilToolStripMenuItem
			// 
			this.seçilenSatırlarıSilToolStripMenuItem.Name = "seçilenSatırlarıSilToolStripMenuItem";
			this.seçilenSatırlarıSilToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
			this.seçilenSatırlarıSilToolStripMenuItem.Text = "Seçilen Satırları Sil";
			this.seçilenSatırlarıSilToolStripMenuItem.Click += new System.EventHandler(this.seçilenSatırlarıSilToolStripMenuItem_Click);
			// 
			// Form3
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.gridView1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "Form3";
			this.Text = "Form3";
			this.Load += new System.EventHandler(this.Form3_Load);
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);

	}

	#endregion

	private CustomeElements.GridView gridView1;
	private ContextMenuStrip contextMenuStrip1;
	private ToolStripMenuItem seçilenSatırlarıSilToolStripMenuItem;
}