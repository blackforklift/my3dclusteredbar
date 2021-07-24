using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My3DChart
{
    public partial class My3DClusteredBar : Control
    {

        private String[] xValue; //x değerlerini tutacağımız array property si 
        public string[] XValue
        {
            get
            {
                return xValue;
            }
            set
            {
                xValue = value;
                this.Refresh();
            }
        }

        private int[] yValue;   //y değerlerini tutacağımız array property si 
        public int[] YValue
        {
            get
            {
                return yValue;
            }
            set
            {
                yValue = value;
                this.Refresh();
            }
        }
        public My3DClusteredBar()
        {
            InitializeComponent();

        }
        public void Line(Graphics G) ///süsleme mavi çizgiyi çizen metod 
        {

            Pen pen = new Pen(Color.Blue);

            Point pt1 = new Point(90, 310);
            Point pt2 = new Point(280, 310);
            G.DrawLine(pen, pt1, pt2);

            Point pt3 = new Point(90, 30);
            G.DrawLine(pen, pt1, pt3);

        }
        public void drawString(Graphics G, string[] array, int x, int y, int font_size)  ///prizmaların altına yazı yazdıran metod
        {
            for (int i = 0; i < array.Length; i++)
            {
                Font fnt = new Font("Times New Roman", font_size);

                G.DrawString((string)array.GetValue(i), fnt, new SolidBrush(Color.Black), x, y);
                x = x + 60;
            }

        }
        public void drawString2(Graphics G, string a, int x, int y, int font_size) ///değerleri yazdırmak için kullandığım yazdırma metodu
        {

            Font fnt = new Font("Times New Roman", font_size);

            G.DrawString(a, fnt, new SolidBrush(Color.Black), x, y);
        }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs pe) ///çizimin başladığı metodların kullanıldığı yer
        {
            base.OnPaint(pe);
            Line(pe.Graphics);

            Draw(pe.Graphics, 50, 100, Color.Blue, YValue, Color.DarkBlue);

            drawString(pe.Graphics, XValue, 100, 310, 9);

            for (int i = 1; i < 27; i++)
            {
                int a_ = i * 10;
                string a__ = a_.ToString();
                drawString2(pe.Graphics, a__, 65, 290 - a_, 8);
            }

        }

        public void Draw(Graphics G, int width, int x, Color color, int[] y, Color shade_color)
        {

            for (int j = 0; j < y.Length; j++) ///3 boyutlu çizim yapan metod
            {

                int m = j * 60  ;                  ///x ekseninde kayması için
                int height = Convert.ToInt32(y.GetValue(j));   /// y değerlerini arrayden tek tek buraya yükseklik olarak giriyoruz
                int skew = 10;                                 //derinlik için çarpıtma
                Point O = new Point(x, 300 - Convert.ToInt32(y.GetValue(j)));
                Pen pencil = new Pen(shade_color, 1f);
                SolidBrush brush = new SolidBrush(color);
                Rectangle R = new Rectangle(O.X + m, O.Y, width, height);
                Point[] topCube;
                topCube = new Point[]{
                new Point(O.X+m, O.Y),
                new Point(O.X+m + skew, O.Y - skew),
                new Point(O.X +m+ width + skew, O.Y - skew),
                new Point(O.X +m+ width , O.Y)};

                O.X = width + x;                               
                                                    /// yan dörtgeni çizdiren metod
                Rectangle[] rectangles = new Rectangle[skew];
                for (int i = 1; i < skew; i++)
                {
                    rectangles[i].X = O.X + m;
                    rectangles[i].Y = O.Y - i;
                    rectangles[i].Height = height;
                    rectangles[i].Width = i;

                }
                for (int i = 1; i < skew; i++)
                {
                    G.DrawRectangle(pencil, rectangles[i]);
                }


                G.DrawPolygon(pencil, topCube);
                G.FillPolygon(brush, topCube);
                G.DrawRectangle(pencil, R);
                G.FillRectangle(new SolidBrush(color), R);
            }






        }


    }
}


