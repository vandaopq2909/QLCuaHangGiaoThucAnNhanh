using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmMonAn : Form
    {
        public frmMonAn()
        {
            InitializeComponent();
        }

        private void guna2TextBox1_MouseClick(object sender, MouseEventArgs e)
        {
            guna2TextBox1.Text=string.Empty;
        }
    }
}
