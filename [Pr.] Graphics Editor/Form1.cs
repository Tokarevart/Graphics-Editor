using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace _Pr.__Graphics_Editor
{
    public partial class Form1 : Form
    {
        private bool brushvar = true;
        private bool linevar = false;
        private bool startc1var = true;
        private bool startc2var = false;
        private bool startc3var = false;
        private bool endc1var = true;
        private bool endc2var = false;
        private bool endc3var = false;
        private bool ellivar = false;
        private bool rect4var = false;
        private bool textvar = false;
        private bool col1var = false;
        private bool col2var = false;
        private int x = 0, y = 0, i = -1;
        private Point[] PMas = new Point[0];
        private Point PLineEnd;
        private Pen myPen;
        private Brush br;
        private Rectangle r;
        private Bitmap bmpImage;
        private Bitmap bmpBg;
        private Bitmap bmpBuf;
        private Graphics g;
        public Form1()
        {
            InitializeComponent();
            brush.BackColor = Color.FromArgb(130, 255, 192, 128);
            startc1.BackColor = Color.FromArgb(130, 255, 192, 128);
            endc1.BackColor = Color.FromArgb(130, 255, 192, 128);
            CreateField();
        }

        private void CreateField()
        {
            FormSize fs = new FormSize();
            fs.ShowDialog();

            bmpImage = new Bitmap(fs.width, fs.height, PixelFormat.Format32bppArgb);
            bmpBg = new Bitmap(fs.width, fs.height, PixelFormat.Format32bppArgb);
            bmpBuf = new Bitmap(fs.width, fs.height, PixelFormat.Format32bppArgb);

            //
            // Создает новый объект Graphics из указанного рисунка Image.
            g = Graphics.FromImage(bmpImage);
            g.Clear(Color.Transparent);
            g.Dispose();

            g = Graphics.FromImage(bmpBg);
            g.Clear(Color.White);
            g.Dispose();

            g = Graphics.FromImage(bmpBuf);
            g.Clear(Color.Transparent);
            g.Dispose();

            //
            //Задаются свойства для PictureBox
            pictureBox13.Width = fs.width + 2;
            pictureBox13.Height = fs.height + 2;
            pictureBox13.Image = bmpImage;
        }

        private void brush_Click(object sender, EventArgs e)
        {
            pictureBox13.Image = bmpImage;
            pictureBox13.BackgroundImage = bmpBg;

            brushvar = true;
            linevar = false;
            ellivar = false;
            rect4var = false;
            textvar = false;

            brush.BackColor = Color.FromArgb(130, 255, 192, 128);
            pbEllipse.BackColor = Color.White;
            pbLine.BackColor = Color.White;
            pbRect.BackColor = Color.White;
            textbtn.BackColor = Color.White;

            panel8.Visible = false;
        }

        private void pictureBox13_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                if (brushvar == true)
                {
                    i++;

                    g = Graphics.FromImage(bmpImage);
                    g.SmoothingMode = SmoothingMode.HighQuality;

                    if (x == 0 && y == 0) { x = e.X; y = e.Y; }
                    g.DrawLine(myPen, x, y, e.X, e.Y);

                    Array.Resize<Point>(ref PMas, PMas.Length + 1);
                    PMas[i] = new Point(x, y);
                    x = e.X;
                    y = e.Y;

                    pictureBox13.Refresh();
                    g.Dispose();
                }
                if (linevar == true)
                {
                    bmpBuf = new Bitmap(bmpImage);

                    g = Graphics.FromImage(bmpBuf);
                    g.SmoothingMode = SmoothingMode.HighQuality;

                    g.DrawLine(myPen, x, y, e.X, e.Y);

                    pictureBox13.Image = new Bitmap(bmpBuf);
                    pictureBox13.Refresh();
                    g.Dispose();
                }
                if (ellivar == true)
                {
                    bmpBuf = new Bitmap(bmpImage);

                    g = Graphics.FromImage(bmpBuf);
                    g.SmoothingMode = SmoothingMode.HighQuality;

                    r = new Rectangle(x, y, e.X - x, e.Y - y);
                    if (checkBox1.Checked == true) g.FillEllipse(br, r);
                    g.DrawEllipse(myPen, r);

                    pictureBox13.Image = new Bitmap(bmpBuf);
                    pictureBox13.Refresh();
                    g.Dispose();
                }
                if (rect4var == true)
                {
                    bmpBuf = new Bitmap(bmpImage);

                    g = Graphics.FromImage(bmpBuf);
                    g.SmoothingMode = SmoothingMode.HighQuality;

                    if (e.X >= x && e.Y >= y) r = new Rectangle(x, y, e.X - x, e.Y - y);
                    if (e.X < x && e.Y < y) r = new Rectangle(e.X, e.Y, x - e.X, y - e.Y);
                    if (e.X < x && e.Y >= y) r = new Rectangle(e.X, y, x - e.X, e.Y - y);
                    if (e.X >= x && e.Y < y) r = new Rectangle(x, e.Y, e.X - x, y - e.Y);
                    if (checkBox1.Checked == true) g.FillRectangle(br, r);
                    g.DrawRectangle(myPen, r);

                    pictureBox13.Image = new Bitmap(bmpBuf);
                    pictureBox13.Refresh();
                    g.Dispose();
                }
            }
        }

        private void brcolor1_Click(object sender, EventArgs e)
        {
            panel3.BackColor = Color.FromArgb(130, 255, 192, 128);
            col1var = true;
            col2var = false;
            panel4.BackColor = Color.Transparent;
        }

        private void brcolor2_Click(object sender, EventArgs e)
        {
            panel4.BackColor = Color.FromArgb(130, 255, 192, 128);
            col1var = false;
            col2var = true;
            panel3.BackColor = Color.Transparent;
        }

        private void CBlack_Click(object sender, EventArgs e)
        {
            if (col1var == true) 
                brcolor1.BackColor = CBlack.BackColor;
            if (col2var == true) 
                brcolor2.BackColor = CBlack.BackColor;
        }

        private void CWhite_Click(object sender, EventArgs e)
        {
            if (col1var == true) 
                brcolor1.BackColor = CWhite.BackColor;
            if (col2var == true) 
                brcolor2.BackColor = CWhite.BackColor;
        }

        private void CDimGray_Click(object sender, EventArgs e)
        {
            if (col1var == true) 
                brcolor1.BackColor = CDimGray.BackColor;
            if (col2var == true) 
                brcolor2.BackColor = CDimGray.BackColor;
        }

        private void CDarkGray_Click(object sender, EventArgs e)
        {
            if (col1var == true) 
                brcolor1.BackColor = CDarkGray.BackColor;
            if (col2var == true) 
                brcolor2.BackColor = CDarkGray.BackColor;
        }

        private void CMaroon_Click(object sender, EventArgs e)
        {
            if (col1var == true) 
                brcolor1.BackColor = CMaroon.BackColor;
            if (col2var == true) 
                brcolor2.BackColor = CMaroon.BackColor;
        }

        private void CSienna_Click(object sender, EventArgs e)
        {
            if (col1var == true) 
                brcolor1.BackColor = CSienna.BackColor;
            if (col2var == true) 
                brcolor2.BackColor = CSienna.BackColor;
        }

        private void CRed_Click(object sender, EventArgs e)
        {
            if (col1var == true) 
                brcolor1.BackColor = CRed.BackColor;
            if (col2var == true) 
                brcolor2.BackColor = CRed.BackColor;
        }

        private void CPink_Click(object sender, EventArgs e)
        {
            if (col1var == true) 
                brcolor1.BackColor = CPink.BackColor;
            if (col2var == true) 
                brcolor2.BackColor = CPink.BackColor;
        }

        private void COrange_Click(object sender, EventArgs e)
        {
            if (col1var == true) 
                brcolor1.BackColor = COrange.BackColor;
            if (col2var == true) 
                brcolor2.BackColor = COrange.BackColor;
        }

        private void CLightOrange_Click(object sender, EventArgs e)
        {
            if (col1var == true) 
                brcolor1.BackColor = CLightOrange.BackColor;
            if (col2var == true) 
                brcolor2.BackColor = CLightOrange.BackColor;
        }

        private void CYellow_Click(object sender, EventArgs e)
        {
            if (col1var == true) 
                brcolor1.BackColor = CYellow.BackColor;
            if (col2var == true) 
                brcolor2.BackColor = CYellow.BackColor;
        }

        private void CKhaki_Click(object sender, EventArgs e)
        {
            if (col1var == true) 
                brcolor1.BackColor = CKhaki.BackColor;
            if (col2var == true) 
                brcolor2.BackColor = CKhaki.BackColor;
        }

        private void CForestGreen_Click(object sender, EventArgs e)
        {
            if (col1var == true) 
                brcolor1.BackColor = CForestGreen.BackColor;
            if (col2var == true) 
                brcolor2.BackColor = CForestGreen.BackColor;
        }

        private void CGreenYellow_Click(object sender, EventArgs e)
        {
            if (col1var == true) 
                brcolor1.BackColor = CGreenYellow.BackColor;
            if (col2var == true) 
                brcolor2.BackColor = CGreenYellow.BackColor;
        }

        private void CDodgerBlue_Click(object sender, EventArgs e)
        {
            if (col1var == true) 
                brcolor1.BackColor = CDodgerBlue.BackColor;
            if (col2var == true) 
                brcolor2.BackColor = CDodgerBlue.BackColor;
        }

        private void CLightSkyBlue_Click(object sender, EventArgs e)
        {
            if (col1var == true) 
                brcolor1.BackColor = CLightSkyBlue.BackColor;
            if (col2var == true) 
                brcolor2.BackColor = CLightSkyBlue.BackColor;
        }

        private void CRoyalBlue_Click(object sender, EventArgs e)
        {
            if (col1var == true) 
                brcolor1.BackColor = CRoyalBlue.BackColor;
            if (col2var == true) 
                brcolor2.BackColor = CRoyalBlue.BackColor;
        }

        private void CSteelBlue_Click(object sender, EventArgs e)
        {
            if (col1var == true) 
                brcolor1.BackColor = CSteelBlue.BackColor;
            if (col2var == true) 
                brcolor2.BackColor = CSteelBlue.BackColor;
        }

        private void CPurple_Click(object sender, EventArgs e)
        {
            if (col1var == true) 
                brcolor1.BackColor = CPurple.BackColor;
            if (col2var == true) 
                brcolor2.BackColor = CPurple.BackColor;
        }

        private void CPlum_Click(object sender, EventArgs e)
        {
            if (col1var == true) 
                brcolor1.BackColor = CPlum.BackColor;
            if (col2var == true) 
                brcolor2.BackColor = CPlum.BackColor;
        }

        private void pictureBox13_MouseUp(object sender, MouseEventArgs e)
        {
            if (brushvar == true)
            {
                i++;
                Array.Resize<Point>(ref PMas, PMas.Length + 1);
                PMas[i] = new Point(x, y);
                g = Graphics.FromImage(bmpBg);
                g.SmoothingMode = SmoothingMode.HighQuality;
                for (int j = 0; j < PMas.Length - 1; j++) g.DrawLine(myPen, PMas[j], PMas[j+1]);
                i = -1;
                Array.Resize<Point>(ref PMas, 0);
                pictureBox13.Refresh();
            }
            if (linevar == true || ellivar == true || rect4var == true)
            {
                bmpImage = new Bitmap(bmpBuf);
                pictureBox13.Image = bmpImage;
                pictureBox13.Refresh();
                if (linevar == true)
                {
                    PLineEnd = new Point(e.X, e.Y);
                    g = Graphics.FromImage(bmpBg);
                    g.SmoothingMode = SmoothingMode.HighQuality;
                    g.DrawLine(myPen, x, y, PLineEnd.X, PLineEnd.Y);
                }
                if (ellivar == true)
                {
                    g = Graphics.FromImage(bmpBg);
                    g.SmoothingMode = SmoothingMode.HighQuality;
                    if (checkBox1.Checked == true) g.FillEllipse(br, r);
                    g.DrawEllipse(myPen, r);
                    g.Dispose();
                }
                if (rect4var == true)
                {
                    g = Graphics.FromImage(bmpBg);
                    g.SmoothingMode = SmoothingMode.HighQuality;
                    if (e.X >= x && e.Y >= y) r = new Rectangle(x, y, e.X - x, e.Y - y);
                    if (e.X < x && e.Y < y) r = new Rectangle(e.X, e.Y, x - e.X, y - e.Y);
                    if (e.X < x && e.Y >= y) r = new Rectangle(e.X, y, x - e.X, e.Y - y);
                    if (e.X >= x && e.Y < y) r = new Rectangle(x, e.Y, e.X - x, y - e.Y);
                    if (checkBox1.Checked == true) g.FillRectangle(br, r);
                    g.DrawRectangle(myPen, r);
                    g.Dispose();
                }
            }
            if (textvar == true)
            {
                if (fontDialog1.ShowDialog() == DialogResult.OK)
                {
                    FormStr fstr = new FormStr();
                    fstr.ShowDialog();
                    g = Graphics.FromImage(bmpImage);
                    g.SmoothingMode = SmoothingMode.HighQuality;
                    br = new SolidBrush(Color.Black);
                    g.DrawString(fstr.str, fontDialog1.Font, br, e.X, e.Y);
                    pictureBox13.Refresh();
                    g.Dispose();
                    g = Graphics.FromImage(bmpBg);
                    g.SmoothingMode = SmoothingMode.HighQuality;
                    g.DrawString(fstr.str, fontDialog1.Font, br, e.X, e.Y);
                    g.Dispose();
                }
            }
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateField();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (sfd.FilterIndex == 1)
                    bmpBg.Save(sfd.FileName, ImageFormat.Jpeg);
                else if (sfd.FilterIndex == 2)
                    bmpImage.Save(sfd.FileName, ImageFormat.Png);
                else if (sfd.FilterIndex == 3)
                    bmpBg.Save(sfd.FileName + ".jpg", ImageFormat.Jpeg);
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                bmpBg = new Bitmap(ofd.FileName);
                bmpImage = new Bitmap(bmpBg);
                pictureBox13.Size = bmpBg.Size;
                pictureBox13.BackgroundImage = bmpBg;
                pictureBox13.Image = bmpImage;
            }
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Разработчик: Токарев А.А.");
        }

        private void pbLine_Click(object sender, EventArgs e)
        {
            brushvar = false;
            linevar = true;
            ellivar = false;
            rect4var = false;
            textvar = false;
            pbLine.BackColor = Color.FromArgb(130, 255, 192, 128);
            brush.BackColor = Color.Transparent;
            pbEllipse.BackColor = Color.White;
            pbRect.BackColor = Color.White;
            textbtn.BackColor = Color.White;
            panel8.Visible = true;
        }

        private void pbEllipse_Click(object sender, EventArgs e)
        {
            ellivar = true;
            linevar = false;
            brushvar = false;
            rect4var = false;
            textvar = false;
            pbEllipse.BackColor = Color.FromArgb(130, 255, 192, 128);
            brush.BackColor = Color.Transparent;
            pbLine.BackColor = Color.White;
            pbRect.BackColor = Color.White;
            textbtn.BackColor = Color.White;
            panel8.Visible = false;
        }

        private void pbRect_Click(object sender, EventArgs e)
        {
            ellivar = false;
            linevar = false;
            brushvar = false;
            rect4var = true;
            textvar = false;
            pbEllipse.BackColor = Color.White;
            brush.BackColor = Color.Transparent;
            pbLine.BackColor = Color.White;
            pbRect.BackColor = Color.FromArgb(130, 255, 192, 128);
            textbtn.BackColor = Color.White;
            panel8.Visible = false;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void eraseallbtn_Click(object sender, EventArgs e)
        {
            g = Graphics.FromImage(bmpImage);
            g.Clear(Color.Transparent);
            g.Dispose();
            g = Graphics.FromImage(bmpBg);
            g.Clear(Color.White);
            g.Dispose();
            g = Graphics.FromImage(bmpBuf);
            g.Clear(Color.Transparent);
            g.Dispose();
            pictureBox13.Refresh();
        }

        private void startc1_Click(object sender, EventArgs e)
        {
            startc1var = true;
            startc2var = false;
            startc3var = false;
            startc1.BackColor = Color.FromArgb(130, 255, 192, 128);
            startc2.BackColor = Color.White;
            startc3.BackColor = Color.White;
        }

        private void startc2_Click(object sender, EventArgs e)
        {
            startc1var = false;
            startc2var = true;
            startc3var = false;
            startc1.BackColor = Color.White;
            startc2.BackColor = Color.FromArgb(130, 255, 192, 128);
            startc3.BackColor = Color.White;
        }

        private void startc3_Click(object sender, EventArgs e)
        {
            startc1var = false;
            startc2var = false;
            startc3var = true;
            startc1.BackColor = Color.White;
            startc2.BackColor = Color.White;
            startc3.BackColor = Color.FromArgb(130, 255, 192, 128);
        }

        private void endc1_Click(object sender, EventArgs e)
        {
            endc1var = true;
            endc2var = false;
            endc3var = false;
            endc1.BackColor = Color.FromArgb(130, 255, 192, 128);
            endc2.BackColor = Color.White;
            endc3.BackColor = Color.White;
        }

        private void endc2_Click(object sender, EventArgs e)
        {
            endc1var = false;
            endc2var = true;
            endc3var = false;
            endc1.BackColor = Color.White;
            endc2.BackColor = Color.FromArgb(130, 255, 192, 128);
            endc3.BackColor = Color.White;
        }

        private void endc3_Click(object sender, EventArgs e)
        {
            endc1var = false;
            endc2var = false;
            endc3var = true;
            endc1.BackColor = Color.White;
            endc2.BackColor = Color.White;
            endc3.BackColor = Color.FromArgb(130, 255, 192, 128);
        }

        private void textbtn_Click(object sender, EventArgs e)
        {
            ellivar = false;
            linevar = false;
            brushvar = false;
            rect4var = false;
            textvar = true;
            pbEllipse.BackColor = Color.White;
            brush.BackColor = Color.Transparent;
            pbLine.BackColor = Color.White;
            pbRect.BackColor = Color.White;
            panel8.Visible = false;
            textbtn.BackColor = Color.FromArgb(130, 255, 192, 128);
        }

        private void pictureBox13_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) myPen = new Pen(brcolor1.BackColor, Convert.ToInt32(brthickness.Value));
            if (e.Button == MouseButtons.Right) myPen = new Pen(brcolor2.BackColor, Convert.ToInt32(brthickness.Value));
            myPen.StartCap = LineCap.Round;
            myPen.EndCap = LineCap.Round;
            if (linevar == true)
            {
                if (startc1var == true) myPen.StartCap = LineCap.Round;
                if (startc2var == true) myPen.StartCap = LineCap.ArrowAnchor;
                if (startc3var == true) myPen.StartCap = LineCap.RoundAnchor;
                if (endc1var == true) myPen.EndCap = LineCap.Round;
                if (endc2var == true) myPen.EndCap = LineCap.ArrowAnchor;
                if (endc3var == true) myPen.EndCap = LineCap.RoundAnchor;
            }
            br = new SolidBrush(brcolor2.BackColor);
            x = 0;
            y = 0;
            if (linevar == true || ellivar == true || rect4var == true)
            {
                x = e.X;
                y = e.Y;
                bmpBuf = new Bitmap(bmpImage);
                pictureBox13.Image = bmpBuf;
            }
        }
    }
}
