using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eat_Game
{
    public partial class Form1 : Form
    {
        // List<Point> points = new List<Point>();
        Point point = new Point();
        Bitmap myBitmap = new Bitmap(@"clown-fish-clipart-fish-nemo-clipart-animal-goldfish-amphiprion-sea-life-transparent-png-1526692.png");
        public int xEat { set; get; }
        public int yEat { set; get; }
        Rectangle fish;

        int x = 0;
        int y = 0;
        int w = 100;
        int h = 45;
        public Form1()
        {
            InitializeComponent();
        }


        public void StaticRectangleIntersection(object sender, PaintEventArgs e)
        {
             xEat = point.X;
             yEat = point.Y;
            x = 0;
            y = 0;
            
            Graphics g = e.Graphics;
            
            Image im = new Bitmap("clown-fish-clipart-fish-nemo-clipart-animal-goldfish-amphiprion-sea-life-transparent-png-1526692.png");
            Rectangle eat;

            if (fish.Size.Width <= this.ClientSize.Width && fish.Size.Height <= this.ClientSize.Height)
            {
                while ((y != this.ClientSize.Height) && (yEat < this.ClientSize.Height) )
                {

                    eat = new Rectangle(xEat, yEat, 6, 6);

                    fish = new Rectangle(new Point(x, y), new Size(w, h));
                    g.Clear(Color.MediumTurquoise);
                    g.DrawImage(im, fish);
                    g.FillRectangle(Brushes.Bisque, eat);

                    if (fish.IntersectsWith(eat))
                    {
                        g.Clear(Color.MediumTurquoise);
                        w += 10;
                        h += 10;
                        break;
                    }
                    if ((x+w) > xEat)
                    {
                        break;
                    }
                    else
                    {
                        x += 10;
                        y += 10;
                        yEat += 10;
                    }
                   

                    Thread.Sleep(300);

                }
            }
            else
            {
                MessageBox.Show( " Fish is too big!\n Game over!!!");
                this.Close();
                
            }

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            
            this.point = new Point(e.X, e.Y);
            Invalidate();

        }
   
    }
}
