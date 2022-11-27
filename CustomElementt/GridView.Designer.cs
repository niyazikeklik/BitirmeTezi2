

using NesePlastikForms.CustomElements;

namespace CustomeElements
{
    partial class GridView
    {
        /// <summary> 
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Bileşen Tasarımcısı üretimi kod

        /// <summary> 
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.gridContextStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ExceleAktar = new System.Windows.Forms.ToolStripMenuItem();
            this.seçiliSatırlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.View = new NesePlastikForms.CustomElements.CustomDataGrid();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbl_baslikk = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.gridContextStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.View)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 471);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(740, 28);
            this.panel2.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(490, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(250, 28);
            this.panel4.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe WP", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gridContextStrip
            // 
            this.gridContextStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.gridContextStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExceleAktar,
            this.seçiliSatırlarToolStripMenuItem});
            this.gridContextStrip.Name = "contextMenuStrip1";
            this.gridContextStrip.Size = new System.Drawing.Size(257, 52);
            // 
            // ExceleAktar
            // 
            this.ExceleAktar.Name = "ExceleAktar";
            this.ExceleAktar.Size = new System.Drawing.Size(256, 24);
            this.ExceleAktar.Text = "Tümünü Excel\'e Aktar";
            this.ExceleAktar.Click += new System.EventHandler(this.ExceleAktar_Click);
            // 
            // seçiliSatırlarToolStripMenuItem
            // 
            this.seçiliSatırlarToolStripMenuItem.Name = "seçiliSatırlarToolStripMenuItem";
            this.seçiliSatırlarToolStripMenuItem.Size = new System.Drawing.Size(256, 24);
            this.seçiliSatırlarToolStripMenuItem.Text = "Seçili Satırları Excel\'e Aktar";
            this.seçiliSatırlarToolStripMenuItem.Click += new System.EventHandler(this.seçiliSatırlarToolStripMenuItem_Click);
            // 
            // View
            // 
            this.View.AllowUserToOrderColumns = true;
            this.View.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.View.BackgroundColor = System.Drawing.Color.White;
            this.View.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.View.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.View.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.View.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.View.ContextMenuStrip = this.gridContextStrip;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.View.DefaultCellStyle = dataGridViewCellStyle4;
            this.View.Dock = System.Windows.Forms.DockStyle.Fill;
            this.View.EnableHeadersVisualStyles = false;
            this.View.FilterAndSortEnabled = true;
            this.View.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.View.GridColor = System.Drawing.Color.White;
            this.View.Location = new System.Drawing.Point(0, 35);
            this.View.Name = "View";
            this.View.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.View.RowHeadersVisible = false;
            this.View.RowHeadersWidth = 51;
            this.View.RowTemplate.Height = 29;
            this.View.ShowCellToolTips = false;
            this.View.ShowEditingIcon = false;
            this.View.Size = new System.Drawing.Size(740, 436);
            this.View.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.View.TabIndex = 2;
            this.View.DataSourceChanged += new System.EventHandler(this.View_DataSourceChanged);
            this.View.SelectionChanged += new System.EventHandler(this.View_SelectionChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Maroon;
            this.panel3.Controls.Add(this.lbl_baslikk);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(740, 35);
            this.panel3.TabIndex = 1;
            // 
            // lbl_baslikk
            // 
            this.lbl_baslikk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_baslikk.Font = new System.Drawing.Font("Segoe WP", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_baslikk.ForeColor = System.Drawing.Color.White;
            this.lbl_baslikk.Location = new System.Drawing.Point(0, 0);
            this.lbl_baslikk.Name = "lbl_baslikk";
            this.lbl_baslikk.Size = new System.Drawing.Size(740, 35);
            this.lbl_baslikk.TabIndex = 0;
            this.lbl_baslikk.Text = "Başlık";
            this.lbl_baslikk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.View);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Name = "GridView";
            this.Size = new System.Drawing.Size(740, 499);
            this.Load += new System.EventHandler(this.GridView_Load);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.gridContextStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.View)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public Panel panel2;
        public Panel panel4;
        public Label label1;
        private ToolStripMenuItem ExceleAktar;
        public ContextMenuStrip gridContextStrip;
        public CustomDataGrid View;
        private Panel panel3;
        public Label lbl_baslikk;
        private ToolStripMenuItem seçiliSatırlarToolStripMenuItem;
    }
}
