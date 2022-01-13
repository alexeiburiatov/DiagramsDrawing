using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Reflection;

namespace DiagramAndGistogram
{
    public partial class live : Form
    {
        Graphics g = null;
        volatile bool exit = false;

        public live()
        {
            InitializeComponent();
            g = this.CreateGraphics();

            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.live_KeyDown);
            this.Click += new System.EventHandler(this.runbutton_Click);
        }

        private void live_Load(object sender, EventArgs e)
        {
        }



        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void live_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                exit = true;
            }
        }


        private void changePie(float i, float j, float a, float b, float c)
        {

            g.FillPie(new SolidBrush(Color.FromArgb(226, 4, 3)), new Rectangle(50, 120, 200, 200), 0, i);
            g.FillPie(new SolidBrush(Color.FromArgb(100, 191, 144)), new Rectangle(50, 120, 200, 200), i, j);

            g.FillPie(new SolidBrush(Color.FromArgb(236, 87, 36)), new Rectangle(75, 145, 150, 150), 0, i);
            g.FillPie(new SolidBrush(Color.FromArgb(154, 218, 192)), new Rectangle(75, 145, 150, 150), i, j);

            g.FillPie(new SolidBrush(Color.FromArgb(254, 175, 13)), new Rectangle(300, 120, 200, 200), a, b);
            g.FillPie(new SolidBrush(Color.FromArgb(161, 91, 196)), new Rectangle(300, 120, 200, 200), 0, a);
            
             g.FillPie(new SolidBrush(Color.FromArgb(79, 132, 225)), new Rectangle(300, 120, 200, 200), b+a, c);


            g.FillPie(new SolidBrush(Color.FromArgb(198, 153, 220)), new Rectangle(325, 145, 150, 150), 0, a);
            g.FillPie(new SolidBrush(Color.FromArgb(255, 206, 86)), new Rectangle(325, 145, 150, 150), a, b);
            g.FillPie(new SolidBrush(Color.FromArgb(139,176,244)), new Rectangle(325, 145, 150, 150), b+a, c);

            
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        private void runbutton_Click(object sender, EventArgs e)
        {
            exit = false;

            
            float pop_sum;
            float pop_d;
            float pop_b;
            int sec;
            float h;
            float  m;
            float s ;
            float sum;
            Random rnd = new Random();
            while (!exit)
            {   
                Application.DoEvents();
                TimeSpan test = DateTime.Now - DateTime.Today.AddDays(-0);
                sec = Convert.ToInt32(test.TotalMilliseconds);
                

                
                float value = rnd.Next(180, 181);
                value = value / 100;
                
                pop_d = value * sec;
                pop_b = (6 - value) * sec;
                
                pop_sum = pop_b + pop_d;
                pop_d = pop_d / pop_sum;
                label4.Text = Convert.ToInt32((sec*4.2/1000)).ToString();
                label7.Text = Convert.ToInt32((sec *1.8 / 1000)).ToString();
                pop_b = 1 - pop_d;

                pop_d = (int)(360 * pop_d);
                pop_b = 360 - pop_d;
                
                Thread.Sleep(1000);

                h = DateTime.Now.Hour;

                label11.Text = h.ToString();
                                                          
                m = DateTime.Now.Minute;

                label8.Text = m.ToString();

                s = DateTime.Now.Second;

                label13.Text = s.ToString();

                sum = h + m + s;
                
                
                
                s = (s / sum) * 360;
                h = (h / sum) * 360;
                m = (m / sum) * 360;
                changePie(pop_d, pop_b,h,m,s);


            }
            Refresh();

            Close();
        }
        
        private void exitButton_Click(object sender, EventArgs e)
        {
            exit = true;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
