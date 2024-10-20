namespace GUI
{
    partial class frmDangNhap
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
            panel1 = new Panel();
            ckbHienThiMatKhau = new Guna.UI2.WinForms.Guna2CheckBox();
            btnDangKi = new Button();
            btnDangNhap = new Button();
            txtMatKhau = new TextBox();
            txtTenDN = new TextBox();
            lblMatKhau = new Label();
            lblTenDN = new Label();
            panel2 = new Panel();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(ckbHienThiMatKhau);
            panel1.Controls.Add(btnDangKi);
            panel1.Controls.Add(btnDangNhap);
            panel1.Controls.Add(txtMatKhau);
            panel1.Controls.Add(txtTenDN);
            panel1.Controls.Add(lblMatKhau);
            panel1.Controls.Add(lblTenDN);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(558, 618);
            panel1.TabIndex = 0;
            // 
            // ckbHienThiMatKhau
            // 
            ckbHienThiMatKhau.AutoSize = true;
            ckbHienThiMatKhau.Checked = true;
            ckbHienThiMatKhau.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
            ckbHienThiMatKhau.CheckedState.BorderRadius = 0;
            ckbHienThiMatKhau.CheckedState.BorderThickness = 0;
            ckbHienThiMatKhau.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
            ckbHienThiMatKhau.CheckState = CheckState.Checked;
            ckbHienThiMatKhau.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ckbHienThiMatKhau.Location = new Point(55, 494);
            ckbHienThiMatKhau.Name = "ckbHienThiMatKhau";
            ckbHienThiMatKhau.Size = new Size(188, 32);
            ckbHienThiMatKhau.TabIndex = 7;
            ckbHienThiMatKhau.Text = "Hiển thị mật khẩu";
            ckbHienThiMatKhau.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
            ckbHienThiMatKhau.UncheckedState.BorderRadius = 0;
            ckbHienThiMatKhau.UncheckedState.BorderThickness = 0;
            ckbHienThiMatKhau.UncheckedState.FillColor = Color.FromArgb(125, 137, 149);
            ckbHienThiMatKhau.CheckedChanged += ckbHienThiMatKhau_CheckedChanged;
            // 
            // btnDangKi
            // 
            btnDangKi.BackColor = Color.Red;
            btnDangKi.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDangKi.ForeColor = Color.White;
            btnDangKi.Location = new Point(320, 542);
            btnDangKi.Name = "btnDangKi";
            btnDangKi.Size = new Size(155, 55);
            btnDangKi.TabIndex = 6;
            btnDangKi.Text = "Đăng kí";
            btnDangKi.UseVisualStyleBackColor = false;
            btnDangKi.Click += btnDangKi_Click;
            // 
            // btnDangNhap
            // 
            btnDangNhap.BackColor = Color.HotPink;
            btnDangNhap.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDangNhap.ForeColor = Color.White;
            btnDangNhap.Location = new Point(53, 542);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Size = new Size(155, 55);
            btnDangNhap.TabIndex = 5;
            btnDangNhap.Text = "Đăng nhập";
            btnDangNhap.UseVisualStyleBackColor = false;
            btnDangNhap.Click += button1_Click;
            // 
            // txtMatKhau
            // 
            txtMatKhau.Font = new Font("Segoe UI", 13.8F);
            txtMatKhau.Location = new Point(53, 444);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(422, 38);
            txtMatKhau.TabIndex = 4;
            // 
            // txtTenDN
            // 
            txtTenDN.Font = new Font("Segoe UI", 13.8F);
            txtTenDN.Location = new Point(53, 346);
            txtTenDN.Name = "txtTenDN";
            txtTenDN.Size = new Size(422, 38);
            txtTenDN.TabIndex = 3;
            // 
            // lblMatKhau
            // 
            lblMatKhau.AutoSize = true;
            lblMatKhau.Font = new Font("Segoe UI", 13.8F);
            lblMatKhau.Location = new Point(53, 398);
            lblMatKhau.Name = "lblMatKhau";
            lblMatKhau.Size = new Size(110, 31);
            lblMatKhau.TabIndex = 2;
            lblMatKhau.Text = "Mật khẩu";
            // 
            // lblTenDN
            // 
            lblTenDN.AutoSize = true;
            lblTenDN.Font = new Font("Segoe UI", 13.8F);
            lblTenDN.Location = new Point(53, 302);
            lblTenDN.Name = "lblTenDN";
            lblTenDN.Size = new Size(166, 31);
            lblTenDN.TabIndex = 1;
            lblTenDN.Text = "Tên đăng nhập";
            // 
            // panel2
            // 
            panel2.BackColor = Color.DarkSeaGreen;
            panel2.Controls.Add(label1);
            panel2.Controls.Add(pictureBox1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(558, 257);
            panel2.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(202, 165);
            label1.Name = "label1";
            label1.Size = new Size(161, 38);
            label1.TabIndex = 1;
            label1.Text = "Đăng nhập";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.image_user;
            pictureBox1.Location = new Point(217, 27);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(161, 135);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // frmDangNhap
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(558, 618);
            Controls.Add(panel1);
            Name = "frmDangNhap";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập";
            Load += frmDangNhap_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private PictureBox pictureBox1;
        private Label lblTenDN;
        private Label label1;
        private TextBox txtMatKhau;
        private TextBox txtTenDN;
        private Label lblMatKhau;
        private Button btnDangKi;
        private Button btnDangNhap;
        private Guna.UI2.WinForms.Guna2CheckBox ckbHienThiMatKhau;
    }
}