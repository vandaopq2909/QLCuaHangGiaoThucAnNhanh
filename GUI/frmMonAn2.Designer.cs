namespace GUI
{
    partial class frmMonAn2
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            btnUpdate = new Guna.UI2.WinForms.Guna2Button();
            btnDelete = new Guna.UI2.WinForms.Guna2Button();
            guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            txtTimKiem = new Guna.UI2.WinForms.Guna2TextBox();
            label1 = new Label();
            dgvMonAn = new Guna.UI2.WinForms.Guna2DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMonAn).BeginInit();
            SuspendLayout();
            // 
            // guna2Panel1
            // 
            guna2Panel1.BackColor = Color.White;
            guna2Panel1.Controls.Add(btnUpdate);
            guna2Panel1.Controls.Add(btnDelete);
            guna2Panel1.Controls.Add(guna2Button1);
            guna2Panel1.Controls.Add(txtTimKiem);
            guna2Panel1.Controls.Add(label1);
            guna2Panel1.CustomizableEdges = customizableEdges9;
            guna2Panel1.Dock = DockStyle.Top;
            guna2Panel1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2Panel1.Location = new Point(0, 0);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges10;
            guna2Panel1.Size = new Size(1505, 152);
            guna2Panel1.TabIndex = 1;
            // 
            // btnUpdate
            // 
            btnUpdate.BorderRadius = 8;
            btnUpdate.CustomizableEdges = customizableEdges1;
            btnUpdate.DisabledState.BorderColor = Color.DarkGray;
            btnUpdate.DisabledState.CustomBorderColor = Color.DarkGray;
            btnUpdate.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnUpdate.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnUpdate.FillColor = Color.FromArgb(255, 128, 0);
            btnUpdate.Font = new Font("Segoe UI", 9F);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Image = Properties.Resources.icon_update1;
            btnUpdate.ImageSize = new Size(30, 30);
            btnUpdate.Location = new Point(273, 66);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnUpdate.Size = new Size(74, 51);
            btnUpdate.TabIndex = 5;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(255, 255, 192);
            btnDelete.BorderRadius = 8;
            btnDelete.CustomizableEdges = customizableEdges3;
            btnDelete.DisabledState.BorderColor = Color.DarkGray;
            btnDelete.DisabledState.CustomBorderColor = Color.DarkGray;
            btnDelete.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnDelete.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnDelete.FillColor = Color.Snow;
            btnDelete.Font = new Font("Segoe UI", 9F);
            btnDelete.ForeColor = Color.White;
            btnDelete.Image = Properties.Resources.icon_rubbish1;
            btnDelete.ImageSize = new Size(30, 30);
            btnDelete.Location = new Point(179, 66);
            btnDelete.Name = "btnDelete";
            btnDelete.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnDelete.Size = new Size(74, 51);
            btnDelete.TabIndex = 4;
            btnDelete.Click += btnDelete_Click;
            // 
            // guna2Button1
            // 
            guna2Button1.BorderRadius = 8;
            guna2Button1.CustomizableEdges = customizableEdges5;
            guna2Button1.DisabledState.BorderColor = Color.DarkGray;
            guna2Button1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button1.FillColor = Color.DarkSeaGreen;
            guna2Button1.Font = new Font("Segoe UI", 9F);
            guna2Button1.ForeColor = Color.White;
            guna2Button1.Image = Properties.Resources.plus_symbol_button;
            guna2Button1.ImageSize = new Size(30, 30);
            guna2Button1.Location = new Point(34, 66);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2Button1.Size = new Size(74, 51);
            guna2Button1.TabIndex = 3;
            guna2Button1.Click += guna2Button1_Click;
            // 
            // txtTimKiem
            // 
            txtTimKiem.AutoValidate = AutoValidate.EnablePreventFocusChange;
            txtTimKiem.BackColor = Color.Transparent;
            txtTimKiem.CustomizableEdges = customizableEdges7;
            txtTimKiem.DefaultText = "Tìm kiếm món ăn";
            txtTimKiem.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtTimKiem.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtTimKiem.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtTimKiem.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtTimKiem.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtTimKiem.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTimKiem.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtTimKiem.IconLeft = Properties.Resources.search;
            txtTimKiem.Location = new Point(810, 50);
            txtTimKiem.Margin = new Padding(4, 6, 4, 6);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PasswordChar = '\0';
            txtTimKiem.PlaceholderText = "";
            txtTimKiem.SelectedText = "";
            txtTimKiem.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtTimKiem.Size = new Size(641, 67);
            txtTimKiem.TabIndex = 2;
            txtTimKiem.TabStop = false;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged_1;
            txtTimKiem.Click += txtTimKiem_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Black;
            label1.Location = new Point(34, 9);
            label1.Name = "label1";
            label1.Size = new Size(260, 38);
            label1.TabIndex = 0;
            label1.Text = "Danh sách món ăn";
            // 
            // dgvMonAn
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            dgvMonAn.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvMonAn.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvMonAn.ColumnHeadersHeight = 50;
            dgvMonAn.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvMonAn.Columns.AddRange(new DataGridViewColumn[] { Column1 });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvMonAn.DefaultCellStyle = dataGridViewCellStyle3;
            dgvMonAn.GridColor = Color.FromArgb(231, 229, 255);
            dgvMonAn.Location = new Point(34, 181);
            dgvMonAn.Name = "dgvMonAn";
            dgvMonAn.RowHeadersVisible = false;
            dgvMonAn.RowHeadersWidth = 51;
            dgvMonAn.Size = new Size(1417, 665);
            dgvMonAn.TabIndex = 2;
            dgvMonAn.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvMonAn.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvMonAn.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvMonAn.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvMonAn.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvMonAn.ThemeStyle.BackColor = Color.White;
            dgvMonAn.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgvMonAn.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgvMonAn.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvMonAn.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgvMonAn.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvMonAn.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvMonAn.ThemeStyle.HeaderStyle.Height = 50;
            dgvMonAn.ThemeStyle.ReadOnly = false;
            dgvMonAn.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvMonAn.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvMonAn.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvMonAn.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgvMonAn.ThemeStyle.RowsStyle.Height = 29;
            dgvMonAn.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvMonAn.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dgvMonAn.CellClick += dgvMonAn_CellClick;
            // 
            // Column1
            // 
            Column1.HeaderText = "Mã Món Ăn";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            // 
            // frmMonAn2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1505, 880);
            Controls.Add(dgvMonAn);
            Controls.Add(guna2Panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmMonAn2";
            Text = "frmMonAn2";
            Load += frmMonAn2_Load;
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMonAn).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2TextBox txtTimKiem;
        private Label label1;
        private Guna.UI2.WinForms.Guna2DataGridView dgvMonAn;
        private DataGridViewTextBoxColumn Column1;
        private Guna.UI2.WinForms.Guna2Button btnUpdate;
        private Guna.UI2.WinForms.Guna2Button btnDelete;
    }
}