using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace DiagramAndGistogram
{
    public partial class DiagramCreator : Form
    {
        int sectors;
        int x = 4, y = 8;
        int x2 = 114, y2 = 8;
        int ind = 2;
        public ArrayList colors = new ArrayList();
        public ArrayList procents = new ArrayList();
        public DiagramCreator(int s)
        {
            InitializeComponent();
            sectors = s;
            for (int i = 0; i < sectors ; i++, ind++)
            {
                TextBox temp = new TextBox();
                PictureBox temp2 = new PictureBox();
                temp.Name = "textBox" + ind.ToString();
                temp.Location = new System.Drawing.Point(x, y);
                temp.Size = new System.Drawing.Size(90, 20);
                temp2.Name = "pictureBox" + ind.ToString();
                temp2.Location = new System.Drawing.Point(x2, y2);
                temp2.Size = new System.Drawing.Size(114, 20);
                temp2.Click += new System.EventHandler(this.pictureBox1_Click);
                temp2.BackColor = Color.FromArgb(255,128,64);
                panel1.Controls.Add(temp);
                panel1.Controls.Add(temp2);
                y += 35;
                y2 = y;
                
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ColorDialog c = new ColorDialog();
            DialogResult r = c.ShowDialog();
            if (r == DialogResult.OK)
                ((PictureBox)sender).BackColor = c.Color;
        }

        private void DiagramCreator_Scroll(object sender, ScrollEventArgs e)
        {
            Invalidate();
        }

        private void DiagramCreator_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int tso = 0;
            foreach (Control c in panel1.Controls)
            {
                if(c is PictureBox)
                    colors.Add(((PictureBox)c).BackColor);
                try
                {
                    if (c is TextBox)
                    {
                        procents.Add(Convert.ToInt32(((TextBox)c).Text));
                        tso += Convert.ToInt32(((TextBox)c).Text);
                    }
                }
                catch
                {
                    procents.Add(0);
                }
            }
            DialogResult r = DialogResult.Yes;
            if (tso != 360)
                r = MessageBox.Show("Сума градусів секторів не є коректною, продовжити?","Попередження",MessageBoxButtons.YesNo);
            if(r==DialogResult.Yes)
                this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
