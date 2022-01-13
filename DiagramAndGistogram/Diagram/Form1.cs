using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Drawing.Imaging;

namespace DiagramAndGistogram
{
    public partial class Form1 : Form
    {
        ArrayList diagrammaSectors = new ArrayList();
        ArrayList diagrammaColors = new ArrayList();
       Bitmap bp = new Bitmap(200,200);
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "Діаграмa:  " + "'"+textBox2.Text+"'";
            
           
            
            
            Graphics g = Graphics.FromImage(bp);            
            DiagramCreator dc = null;
            
            if (textBox1.Text != "" && Convert.ToInt32(textBox1.Text) < 361)
            {
                dc = new DiagramCreator(Convert.ToInt32(textBox1.Text));
            }

            if (dc != null)
            {
                DialogResult r = dc.ShowDialog();
                if (r == DialogResult.OK)
                {
                    //String format for Label on PieChart
                    StringFormat string_format = new StringFormat();
                    string_format.Alignment = StringAlignment.Center;
                    string_format.LineAlignment = StringAlignment.Center;

                    // Find the center of the rectangle.
                    float cx = 200 / 2f;
                    float cy = 200 / 2f;
                    // Place the label about 2/3 of the way out to the edge.
                    float radius = (200 + 200) / 2f * 0.33f;

                    // Place the label 
                    float x;
                    float y;
                    // Label the slice.
                    double label_angle;

                    int grad = 0;
                        for (int i = 0; i < dc.procents.Count; i++)
                        {
                            if((int)dc.procents[i]!=0)
                            {
                                label_angle = Math.PI * (grad + ((int)dc.procents[i]) / 2f) / 180f;

                                x = cx + (float)(radius * Math.Cos(label_angle));
                                y = cy + (float)(radius * Math.Sin(label_angle));


                                g.FillPie(new SolidBrush(((Color)dc.colors[i])), new Rectangle(0, 0, 200, 200 ), grad, ((int)dc.procents[i]));
                                diagrammaSectors.Add(((int)dc.procents[i]));
                                diagrammaColors.Add(((Color)dc.colors[i]));
                                grad += ((int)dc.procents[i]);
                                g.DrawString(((int)dc.procents[i]).ToString(), Font, Brushes.Black, x, y, string_format);
                            }
                            
                    }
                    pictureBox1.Image = bp;
                    
                   
                }
            }
        }

        private void построениеДиаграмыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Діаграма складається з секторів, у сумі градуси всіх секторів мають бути 360, тобто. наприклад, 6 секторів по 60 градусів. Секторам задаються різні кольори для чіткого відображення.", "Інформація про побудову діаграм");
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void openbutton_Click(object sender, EventArgs e)
        {
            live live = new live();
            live.Show();

        }


        




        private void savePictureToolStripMenuItem_Click(object sender, EventArgs e)
        {  
          
            
            bp.Save(@"screensh0t.jpg");
            MessageBox.Show("Збережено до папки з програмою", "Інформація про збереження скріншоту");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
