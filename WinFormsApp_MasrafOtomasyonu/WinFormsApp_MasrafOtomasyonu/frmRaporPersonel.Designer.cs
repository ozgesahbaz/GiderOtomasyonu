
namespace WinFormsApp_MasrafOtomasyonu
{
    partial class frmRaporPersonel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRaporPersonel));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnExcelExport = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblAdet = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvVeriler = new System.Windows.Forms.DataGridView();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVeriler)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExcelExport});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 55);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnExcelExport
            // 
            this.btnExcelExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExcelExport.Image = global::WinFormsApp_MasrafOtomasyonu.Properties.Resources.excel_microsoft_office_office365_icon_48;
            this.btnExcelExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExcelExport.Name = "btnExcelExport";
            this.btnExcelExport.Size = new System.Drawing.Size(52, 52);
            this.btnExcelExport.Text = "Excel Aktarım";
            this.btnExcelExport.Click += new System.EventHandler(this.btnExcelExport_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblAdet});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblAdet
            // 
            this.lblAdet.Name = "lblAdet";
            this.lblAdet.Size = new System.Drawing.Size(53, 17);
            this.lblAdet.Text = "Adet : 0";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvVeriler);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 373);
            this.panel1.TabIndex = 2;
            // 
            // dgvVeriler
            // 
            this.dgvVeriler.AllowUserToAddRows = false;
            this.dgvVeriler.AllowUserToDeleteRows = false;
            this.dgvVeriler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVeriler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVeriler.Location = new System.Drawing.Point(0, 0);
            this.dgvVeriler.Name = "dgvVeriler";
            this.dgvVeriler.ReadOnly = true;
            this.dgvVeriler.RowTemplate.Height = 27;
            this.dgvVeriler.Size = new System.Drawing.Size(800, 373);
            this.dgvVeriler.TabIndex = 0;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "Excel aktarım işlemi tamamlanmıştır.";
            this.notifyIcon1.BalloonTipTitle = "Aktarım Tamamlandı";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // frmRaporPersonel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmRaporPersonel";
            this.Text = "Personel Masraf Raporu";
            this.Load += new System.EventHandler(this.frmRaporPersonel_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVeriler)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnExcelExport;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblAdet;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvVeriler;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}