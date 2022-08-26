using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatKompGeo.GeoObjekti
{
    internal class Vektor2D
    {
        PointF koordinate;
        int vrijednost;

        public Vektor2D(float x, float y)
        {
            koordinate.X = x;
            koordinate.Y = y;
        }
        public Vektor2D(int vrijednost, float x, float y)
        {
            koordinate.X = x;
            koordinate.Y = y;
            this.vrijednost = vrijednost;
        }

        public Vektor2D(int vrijednost, Vektor2D vek)
        {
            koordinate.X = vek.X;
            koordinate.Y = vek.Y;
            this.vrijednost = vrijednost;
        }

        public float X { get { return koordinate.X; } }
        public float Y { get { return koordinate.Y; } }

        public int V { get { return vrijednost; } }

        public void SetV(int v)
        {
            vrijednost = v;
        }
        public void DrawVektor(Graphics g)
        {
            g.FillRectangle(Brushes.Red, this.koordinate.X, this.koordinate.Y, 5, 5);
        }
        public void DrawVektor(Graphics g, Brush boja)
        {
            g.FillRectangle(boja, this.koordinate.X, this.koordinate.Y, 5, 5);
        }
        public void DrawVektor(Graphics g, Brush boja, int velicina)
        {
            g.FillRectangle(boja, this.koordinate.X, this.koordinate.Y, velicina, velicina);
        }
        public PointF getPoint()
        {
            return new PointF(koordinate.X, koordinate.Y);
        }
        public static double getUdaljenost(Vektor2D A, Vektor2D B) {
            return Math.Sqrt(Math.Pow((B.X - A.X), 2) + Math.Pow((B.Y - A.Y), 2));
        } 
    }
}
