using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _Pr.__Graphics_Editor
{
    public partial class FormSize : Form
    {
        public int width, height;
        public FormSize()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormSize_FormClosing(object sender, FormClosingEventArgs e)
        {
            width = Convert.ToInt32(numericUpDown1.Value);
            height = Convert.ToInt32(numericUpDown2.Value);
        }
    }
}
