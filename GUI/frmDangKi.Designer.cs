namespace GUI
{
    partial class frmDangKi
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
            button2 = new Button();
            button1 = new Button();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label3 = new Label();
            label2 = new Label();
            panel2 = new Panel();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            textBox3 = new TextBox();
            label4 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(558, 618);
            panel1.TabIndex = 0;
            // 
            // button2
            // 
            button2.BackColor = Color.Red;
            button2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.White;
            button2.Location = new Point(53, 551);
            button2.Name = "button2";
            button2.Size = new Size(155, 55);
            button2.TabIndex = 6;
            button2.Text = "Đăng kí";
            button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.HotPink;
            button1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(320, 551);
            button1.Name = "button1";
            button1.Size = new Size(155, 55);
            button1.TabIndex = 5;
            button1.Text = "Đăng nhập";
            button1.UseVisualStyleBackColor = false;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 13.8F);
            textBox2.Location = new Point(53, 415);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(422, 38);
            textBox2.TabIndex = 4;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 13.8F);
            textBox1.Location = new Point(53, 317);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(422, 38);
            textBox1.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F);
            label3.Location = new Point(53, 369);
            label3.Name = "label3";
            label3.Size = new Size(110, 31);
            label3.TabIndex = 2;
            label3.Text = "Mật khẩu";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F);
            label2.Location = new Point(53, 273);
            label2.Name = "label2";
            label2.Size = new Size(166, 31);
            label2.TabIndex = 1;
            label2.Text = "Tên đăng nhập";
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
            label1.Location = new Point(159, 180);
            label1.Name = "label1";
            label1.Size = new Size(251, 38);
            label1.TabIndex = 1;
            label1.Text = "Đăng kí tài khoản";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.image_register;
            pictureBox1.Location = new Point(203, 27);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(161, 135);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Segoe UI", 13.8F);
            textBox3.Location = new Point(53, 501);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(422, 38);
            textBox3.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13.8F);
            label4.Location = new Point(53, 456);
            label4.Name = "label4";
            label4.Size = new Size(201, 31);
            label4.TabIndex = 7;
            label4.Text = "Nhập lại mật khẩu";
            // 
            // frmDangKi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(558, 618);
            Controls.Add(panel1);
            Name = "frmDangKi";
            Text = "Đăng nhập";
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
        private Label label2;
        private Label label1;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label3;
        private Button button2;
        private Button button1;
        private TextBox textBox3;
        private Label label4;
    }
}