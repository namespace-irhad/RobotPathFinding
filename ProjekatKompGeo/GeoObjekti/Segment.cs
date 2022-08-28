using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatKompGeo.GeoObjekti
{
    internal class Segment
    {
        private readonly Vektor2D poc;
        private readonly Vektor2D kraj;

        public Segment(Vektor2D poc, Vektor2D kraj)
        {
            this.poc = poc;
            this.kraj = kraj;
        }
        public Vektor2D Poc { get { return poc; } }
        public Vektor2D Kraj { get { return kraj; } }
        public void DrawSegment(Graphics g)
        {
            Pen pen = new Pen(Color.FromArgb(255, 0, 255));
            g.DrawLine(pen, new PointF(poc.X, poc.Y), new PointF(kraj.X, kraj.Y));
        }
        public void DrawSegment(Graphics g, Color color)
        {
            Pen pen = new Pen(color);
            g.DrawLine(pen, new PointF(poc.X, poc.Y), new PointF(kraj.X, kraj.Y));
        }

        public bool Isti(Segment B)
        {
            return B.poc.Isti(this.poc) && B.kraj.Isti(this.kraj);
        }

        public static bool CCW(Vektor2D A, Vektor2D B, Vektor2D C)
        {
            return (C.Y - A.Y) * (B.X - A.X) > (B.Y - A.Y) * (C.X - A.X);
        }

        public bool DaLiSeSegmentiSijeku(Segment B)
        {
            Segment A = this;
            // Debug.WriteLine(CCW(A.poc, B.poc, B.kraj) + " " + CCW(A.kraj, B.poc, B.kraj) + " " + CCW(A.poc, A.kraj, B.poc) + " " + CCW(A.poc, A.kraj, B.kraj));
            return CCW(A.poc, B.poc, B.kraj) != CCW(A.kraj, B.poc, B.kraj) && CCW(A.poc, A.kraj, B.poc) != CCW(A.poc, A.kraj, B.kraj);
        }

        public Vektor2D TackaPresijeka(Segment B)
        {
            Segment A = this;
            float x1 = A.poc.X;
            float x2 = A.kraj.X;
            float y1 = A.poc.Y;
            float y2 = A.kraj.Y;

            float x3 = B.poc.X;
            float x4 = B.kraj.X;
            float y3 = B.poc.Y;
            float y4 = B.kraj.Y;


            // Check if none of the lines are of length 0
            if ((x1 == x2 && y1 == y2) || (x3 == x4 && y3 == y4))
            {
                return null;
        
            }

            float denominator = ((y4 - y3) * (x2 - x1) - (x4 - x3) * (y2 - y1));

            if (denominator == 0)
            {
                return null;

            }

            float ua = ((x4 - x3) * (y1 - y3) - (y4 - y3) * (x1 - x3)) / denominator;

            float ub = ((x2 - x1) * (y1 - y3) - (y2 - y1) * (x1 - x3)) / denominator;

            if (ua < 0 || ua > 1 || ub < 0 || ub > 1)
            {
                return null;
                    
            }

            // Return a object with the x and y coordinates of the intersection
            float x = x1 + ua * (x2 - x1);

            float y = y1 + ua * (y2 - y1);

            if (x == x1 && y == y1 || x == x2 && y == y2)
                return null;

            return new Vektor2D(x, y);
        }
    }
}
