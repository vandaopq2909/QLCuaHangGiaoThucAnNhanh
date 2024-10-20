namespace GUI
{
    partial class ucMonAn
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            lblGia = new Label();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            lblTenMon = new Label();
            hinh_MonAn = new Guna.UI2.WinForms.Guna2PictureBox();
            guna2ShadowPanel1.SuspendLayout();
            guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)hinh_MonAn).BeginInit();
            SuspendLayout();
            // 
            // guna2ShadowPanel1
            // 
            guna2ShadowPanel1.BackColor = Color.Transparent;
            guna2ShadowPanel1.Controls.Add(lblGia);
            guna2ShadowPanel1.Controls.Add(guna2Panel1);
            guna2ShadowPanel1.Controls.Add(hinh_MonAn);
            guna2ShadowPanel1.Dock = DockStyle.Fill;
            guna2ShadowPanel1.FillColor = Color.White;
            guna2ShadowPanel1.Location = new Point(0, 0);
            guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            guna2ShadowPanel1.ShadowColor = Color.Black;
            guna2ShadowPanel1.Size = new Size(250, 250);
            guna2ShadowPanel1.TabIndex = 0;
            // 
            // lblGia
            // 
            lblGia.AutoSize = true;
            lblGia.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGia.ForeColor = Color.Red;
            lblGia.Location = new Point(14, 156);
            lblGia.Name = "lblGia";
            lblGia.Size = new Size(72, 23);
            lblGia.TabIndex = 2;
            lblGia.Text = "Giá tiền";
            // 
            // guna2Panel1
            // 
            guna2Panel1.Controls.Add(lblTenMon);
            guna2Panel1.CustomizableEdges = customizableEdges1;
            guna2Panel1.Dock = DockStyle.Bottom;
            guna2Panel1.Location = new Point(0, 195);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Panel1.Size = new Size(250, 55);
            guna2Panel1.TabIndex = 1;
            // 
            // lblTenMon
            // 
            lblTenMon.AutoSize = true;
            lblTenMon.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTenMon.Location = new Point(14, 12);
            lblTenMon.Name = "lblTenMon";
            lblTenMon.Size = new Size(148, 28);
            lblTenMon.TabIndex = 0;
            lblTenMon.Text = "Mì cay hải sản";
            // 
            // hinh_MonAn
            // 
            hinh_MonAn.CustomizableEdges = customizableEdges3;
            hinh_MonAn.Image = Properties.Resources.micayhaisan;
            hinh_MonAn.ImageRotate = 0F;
            hinh_MonAn.Location = new Point(45, 14);
            hinh_MonAn.Name = "hinh_MonAn";
            hinh_MonAn.ShadowDecoration.CustomizableEdges = customizableEdges4;
            hinh_MonAn.Size = new Size(163, 139);
            hinh_MonAn.SizeMode = PictureBoxSizeMode.StretchImage;
            hinh_MonAn.TabIndex = 0;
            hinh_MonAn.TabStop = false;
            hinh_MonAn.Click += hinh_MonAn_Click;
            // 
            // ucMonAn
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(guna2ShadowPanel1);
            Name = "ucMonAn";
            Size = new Size(250, 250);
            Load += ucMonAn_Load;
            guna2ShadowPanel1.ResumeLayout(false);
            guna2ShadowPanel1.PerformLayout();
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)hinh_MonAn).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Label lblTenMon;
        private Guna.UI2.WinForms.Guna2PictureBox hinh_MonAn;
        private Label lblGia;
    }
}
