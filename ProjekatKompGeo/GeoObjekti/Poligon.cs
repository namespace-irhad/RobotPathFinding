using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatKompGeo.GeoObjekti
{
    internal class Poligon
    {
        readonly List<Vektor2D> tacke = new List<Vektor2D>();
        readonly List<Segment> segmenti = new List<Segment>();
        readonly PointF[] tackeF;
        readonly Brush bojaPozadina;
        public Vektor2D sredina { get; set; }

        public List<Vektor2D> getTacke()
        {
            return tacke;
        }
        public List<Segment> getSegmenti()
        {
            return segmenti;
        }

        public Poligon(List<Vektor2D> tacke)
        {
            this.tacke = tacke;
            tackeF = new PointF[tacke.Count];
            for (int i = 0; i < tacke.Count; i++)
                tackeF[i] = new PointF(tacke[i].X, tacke[i].Y);
            for (int i = 1; i <= tacke.Count; i++)
            {
                segmenti.Add(new Segment(new Vektor2D(tacke[i - 1].X, tacke[i - 1].Y), new Vektor2D(tacke[i % tacke.Count].X, tacke[i % tacke.Count].Y)));
            }

            this.bojaPozadina = new SolidBrush(Color.Gray);
        }

        public Poligon(List<Segment> segmenti)
        {
            this.segmenti = segmenti;
            for (int i = 0; i < segmenti.Count; i++)
            {
                tacke.Add(segmenti[i].Poc);
                tacke.Add(segmenti[i].Kraj);
            }
            tackeF = new PointF[tacke.Count];
            for (int i = 0; i < tacke.Count; i++)
                tackeF[i] = new PointF(tacke[i].X, tacke[i].Y);

            this.bojaPozadina = new SolidBrush(Color.Gray);
        }

        public Poligon(Poligon A)
        {
            this.tacke = A.tacke;
            this.tackeF = A.tackeF;
            this.segmenti = A.segmenti;
            this.bojaPozadina = A.bojaPozadina;
        }
        public void DrawPoligon(Graphics g, Pen p)
        {
            g.FillPolygon(bojaPozadina, tackeF);
            for (int i = 1; i <= tacke.Count; i++)
            {
                g.DrawLine(p, tacke[i - 1].X, tacke[i - 1].Y, tacke[i % tacke.Count].X, tacke[i % tacke.Count].Y);
                tacke[i % tacke.Count].DrawVektor(g);
            }

        }

        // STATIC FUNKCIJE
        public static bool DaLiSePoligoniSijeku(Poligon A, Poligon B)
        {
            bool sijeku = false;
            List<Vektor2D> tackeA = A.getTacke();
            List<Vektor2D> tackeB = B.getTacke();

            for (int i = 1; i <= tackeA.Count; i++)
            {
                Segment segmentA = new Segment(tackeA[i - 1], tackeA[i % tackeA.Count]);
                for (int j = 1; j <= tackeB.Count; j++)
                {
                    Segment segmentB = new Segment(tackeB[j - 1], tackeB[j % tackeB.Count]);
                    if (segmentA.DaLiSeSegmentiSijeku(segmentB))
                    {
                        sijeku = true;
                        break;
                    }

                }
                if (sijeku) break;
            }
            return sijeku;
        }

        public static List<Vektor2D> SortirajTacke(List<Vektor2D> vt)
        {
            float meanX = 0;
            float meanY = 0;
            for (int i = 0; i < vt.Count; i++)
            {
                meanX += vt[i].X;
                meanY += vt[i].Y;
            }
            meanX = meanX / vt.Count;
            meanY = meanY / vt.Count;
            Vektor2D Centar = new Vektor2D(meanX, meanY);
            List<Vektor2D> sortiraneTacke = vt;

            int SortirajPoUglu(Vektor2D A, Vektor2D B)
            {
                return (int)(Math.Atan2(A.Y - Centar.Y, A.X - Centar.X) * 180 / Math.PI - Math.Atan2(B.Y - Centar.Y, B.X - Centar.X) * 180 / Math.PI);
            }

            sortiraneTacke.Sort(SortirajPoUglu);

            return sortiraneTacke;
        }

        public static Poligon GenerisiPoligon(int brTacaka, Size dimenzijaPloce, int velicina)
        {
            Random rnd = new Random();
            int initialX = (10 + rnd.Next()) % (dimenzijaPloce.Width - 10);
            int initialY = (10 + rnd.Next()) % (dimenzijaPloce.Height - 10);

            List<Vektor2D> tackePoligona = new List<Vektor2D>();

            for (int i = 0; i < brTacaka; i++)
            {
                int x = Math.Max(10 + rnd.Next() % 100, Math.Min(initialX + (-1) * (rnd.Next() % velicina), dimenzijaPloce.Width - 10));
                int y = Math.Max(10 + rnd.Next() % 100, Math.Min(initialY + (-1) * (rnd.Next() % velicina), dimenzijaPloce.Height - 10));
                tackePoligona.Add(new Vektor2D(x, y));
            }
            int brojTacakaParalelne = 0;
            for (int i = 0; i < brTacaka - 1; i++)
            {
                if (tackePoligona[i].getPoint().X == tackePoligona[i + 1].getPoint().X || tackePoligona[i].getPoint().Y == tackePoligona[i + 1].getPoint().Y)
                    brojTacakaParalelne++;
            }
            if (brojTacakaParalelne > brTacaka * 0.8)
                return GenerisiPoligon(brTacaka, dimenzijaPloce, velicina);

            Poligon noviPoligon = new Poligon(SortirajTacke(tackePoligona));
            return noviPoligon;
        }

        public static List<Poligon> GenerisiPoligone(int brPoligona, Size dimenzijaPloce, int velicina, int dubina = 1000)
        {
            List<Poligon> generisaniPoligoni = new List<Poligon>();
            Random rnd = new Random();

            int brCelijaPoX = (int)Math.Ceiling((double)dimenzijaPloce.Width / velicina);
            int brCelijaPoY = (int)Math.Ceiling((double)dimenzijaPloce.Height / velicina);
            int brCelija = brCelijaPoX * brCelijaPoY;
            int brPoligonaPoCeliji = (int)Math.Ceiling((double)brPoligona / brCelija);

            for (int i = 0; i < brCelijaPoX; i++)
            {
                for (int j = 0; j < brCelijaPoY; j++)
                {
                    for (int k = 0; k < brPoligonaPoCeliji; k++)
                    {
                        int brTacaka = 5;
                        int x = (10 + rnd.Next()) % (dimenzijaPloce.Width - 10);
                        int y = (10 + rnd.Next()) % (dimenzijaPloce.Height - 10);
                        List<Vektor2D> tackePoligona = new List<Vektor2D>();

                        for (int l = 0; l < brTacaka; l++)
                        {
                            int x1 = Math.Max(10 + rnd.Next() % 100, Math.Min(x + (-1) * (rnd.Next() % velicina), dimenzijaPloce.Width - 10));
                            int y1 = Math.Max(10 + rnd.Next() % 100, Math.Min(y + (-1) * (rnd.Next() % velicina), dimenzijaPloce.Height - 10));
                            tackePoligona.Add(new Vektor2D(x1, y1));
                        }
                        

                        int brojTacakaParalelne = 0;
                        for (int l = 0; l < brTacaka - 1; l++)
                        {
                            if (tackePoligona[l].getPoint().X == tackePoligona[l + 1].getPoint().X || tackePoligona[l].getPoint().Y == tackePoligona[l + 1].getPoint().Y)
                                brojTacakaParalelne++;
                        }
                        if (brojTacakaParalelne > brTacaka * 0.8)
                            continue;

                        Poligon noviPoligon = new Poligon(SortirajTacke(tackePoligona));
                        generisaniPoligoni.Add(noviPoligon);
                    }
                }
            }

            for (int i = 0; i < generisaniPoligoni.Count; i++)
            {
                for (int j = i + 1; j < generisaniPoligoni.Count; j++)
                {
                    if (DaLiSePoligoniSijeku(generisaniPoligoni[i], generisaniPoligoni[j]))
                    {
                        generisaniPoligoni.RemoveAt(j);
                        j--;
                    }
                }
            }

            return generisaniPoligoni;
            

            // Stara metoda
            /*
            int dodaniBrPoligona = 0;
            List<Poligon> generisaniPoligoni = new List<Poligon>();
            while (dodaniBrPoligona < brPoligona && dubina > 0)
            {
                Poligon noviPoligon = GenerisiPoligon(5, dimenzijaPloce, velicina);
                bool validan = true;
                for (int i = 0; i < generisaniPoligoni.Count; i++)
                {
                    if (DaLiSePoligoniSijeku(noviPoligon, generisaniPoligoni[i])) validan = false;
                }
                if (validan)
                {
                    generisaniPoligoni.Add(new Poligon(noviPoligon));
                    dodaniBrPoligona++;
                }
                else
                    dubina--;
            }
            return generisaniPoligoni;
            */
        }
        public bool SegmentPresijekSaPoligonom(Segment A)
        {
            for (int i = 0; i < segmenti.Count; i++)
            {
                if (A.TackaPresijeka(segmenti[i]) != null)
                    return true;
            }
            return false;
        }

        public bool TackaUnutarPoligona(Vektor2D vTacka)
        {
            bool rezultat = false;
            int j = tacke.Count - 1;
            for (int i = 0; i < tacke.Count; i++)
            {
                if (tacke[i].Y < vTacka.Y && tacke[j].Y >= vTacka.Y || tacke[j].Y < vTacka.Y && tacke[i].Y >= vTacka.Y)
                {
                    if (tacke[i].X + (vTacka.Y - tacke[i].Y) / (tacke[j].Y - tacke[i].Y) * (tacke[j].X - tacke[i].X) < vTacka.X)
                    {
                        rezultat = !rezultat;
                    }
                }
                j = i;
            }
            return rezultat;
        }

        public bool SadrziPoligon(Poligon B)
        {
            bool unutar = true;
            for (int i = 0; i < B.getTacke().Count; i++)
            {
                if (!this.TackaUnutarPoligona(B.getTacke()[i]))
                {
                    unutar = false;
                    break;
                }
            }
            return unutar;
        }

        public bool Isti(Poligon B) {
            if (this.getTacke().Count != B.getTacke().Count)
                return false;
            for (int i = 0; i < this.getTacke().Count; i++)
            {
                if (!this.getTacke()[i].Isti(B.getTacke()[i]))
                    return false;
            }
            return true;
        }
    }
}
