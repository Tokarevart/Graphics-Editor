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
    public partial class FormStr : Form
    {
        public string str;
        public FormStr()
        {
            InitializeComponent();
        }

        private void btnStr_Click(object sender, EventArgs e)
        {
            str = tbStr.Text;
            Close();
        }
    }
}
