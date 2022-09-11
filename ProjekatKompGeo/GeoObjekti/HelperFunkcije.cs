using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatKompGeo.GeoObjekti
{
    internal class HelperFunkcije
    {
        public static Graphics gr;
        public static void TrapezoidnaDekompozicija(Size dimenzija, List<Poligon> prepreke, Graphics g, ref Graf mapaPuteva, Dictionary<string, bool> postavke)
        {
            Brush brush = new SolidBrush(Color.Blue);
            List<Tuple<Segment, Vektor2D, int>> ekstenzije = new List<Tuple<Segment, Vektor2D, int>>();
            List<Segment> trapezSegmenti = new List<Segment>();
            List<Vektor2D> tackeEkstenzija = new List<Vektor2D>();
            List<Poligon> prazneCelije = new List<Poligon>();

            for (int i = 0; i < prepreke.Count; i++)
            {
                Poligon prepreka = prepreke[i];
                for (int j = 0; j < prepreka.getTacke().Count; j++)
                {
                    Vektor2D tacka = prepreka.getTacke()[j];
                    if (!prepreka.SegmentPresijekSaPoligonom(new Segment(new Vektor2D(tacka.X, 0), new Vektor2D(tacka.getPoint().X, tacka.getPoint().Y))))
                        ekstenzije.Add(new Tuple<Segment, Vektor2D, int>(new Segment(new Vektor2D(tacka.X, 0), new Vektor2D(tacka.getPoint().X, tacka.getPoint().Y)), tacka, -1));
                    if (!prepreka.SegmentPresijekSaPoligonom(new Segment(new Vektor2D(tacka.getPoint().X, tacka.getPoint().Y), new Vektor2D(tacka.X, dimenzija.Height))))
                        ekstenzije.Add(new Tuple<Segment, Vektor2D, int>(new Segment(new Vektor2D(tacka.getPoint().X, tacka.getPoint().Y), new Vektor2D(tacka.X, dimenzija.Height)), tacka, 1));
                }
            }
            for (int i = 0; i < prepreke.Count; i++)
            {
                Poligon prepreka = prepreke[i];
                for (int j = 0; j < ekstenzije.Count; j++)
                {
                    double najkracaUdaljenost = double.PositiveInfinity;
                    Vektor2D tackaUdaljenosti = null;
                    Vektor2D tackaOd = null;
                    int brojPresijeka = 0;
                    for (int k = 0; k < prepreka.getSegmenti().Count; k++)
                    {
                        Vektor2D tackaPresijeka = ekstenzije[j].Item1.TackaPresijeka(prepreka.getSegmenti()[k]);
                        if (tackaPresijeka != null)
                        {
                            brojPresijeka++;
                            // tackaPresijeka.DrawVektor(g, brushPresijek);
                            double trenutnaUdaljenost = Vektor2D.getUdaljenost(tackaPresijeka, ekstenzije[j].Item2);
                            if (trenutnaUdaljenost < najkracaUdaljenost && trenutnaUdaljenost > 0)
                            {
                                najkracaUdaljenost = trenutnaUdaljenost;
                                tackaUdaljenosti = tackaPresijeka;
                                tackaOd = ekstenzije[j].Item2;
                            }
                        }
                    }
                    if (tackaUdaljenosti != null && brojPresijeka % 2 == 0)
                    {
                        // tackaUdaljenosti.DrawVektor(g, new SolidBrush(Color.Yellow));
                        Segment segment = new Segment(tackaUdaljenosti, tackaOd);
                        trapezSegmenti.Add(segment);
                        if (postavke["dodatno"])
                            segment.DrawSegment(g, Color.Chocolate);
                    }
                }
            }

            for (int i = 0; i < ekstenzije.Count; i++)
            {
                bool sijeku = false;
                for (int j = 0; j < prepreke.Count; j++)
                {
                    if (prepreke[j].SegmentPresijekSaPoligonom(ekstenzije[i].Item1))
                    {
                        sijeku = true;
                        break;
                    }
                }
                if (!sijeku)
                {
                    if (postavke["dodatno"])
                        ekstenzije[i].Item1.DrawSegment(g, Color.Chocolate);
                   trapezSegmenti.Add(ekstenzije[i].Item1);
                }
            }

            // Pronadji srednje tacke svakog segmenta
            Font font1 = new Font("Arial", 9, FontStyle.Regular, GraphicsUnit.Point);
            for (int i = 0; i < trapezSegmenti.Count; i++)
            {
                Segment segment = trapezSegmenti[i];
                float srednjeY = Math.Abs(Math.Max(segment.Poc.Y, segment.Kraj.Y)) + Math.Abs(Math.Min(segment.Poc.Y, segment.Kraj.Y));
                Vektor2D srednjaTacka = new Vektor2D(segment.Poc.X, srednjeY / 2);
                if (postavke["vrhovi"])
                    srednjaTacka.DrawVektor(g, new SolidBrush(Color.Pink));
                tackeEkstenzija.Add(srednjaTacka);
            }
            // TODO: pogledati bolji nacin (ovo je naivna provjera za pronalazenje grana)
            List<Vektor2D> sortiraneEkstenzijeTacke = tackeEkstenzija.OrderBy(i => i.X).ToList();
            int index = 1;
            foreach (Vektor2D tacka in sortiraneEkstenzijeTacke)
            {
                tacka.SetV(index);
                index++;
                if (postavke["vrhovi"])
                    g.DrawString(tacka.V.ToString(), font1, brush, tacka.getPoint());
            }

            // Dodaj pocetnu tacku
            float midTackaX = sortiraneEkstenzijeTacke[0].X / 2;
            float midTackaY = sortiraneEkstenzijeTacke[0].Y;
            if (sortiraneEkstenzijeTacke[0].X == sortiraneEkstenzijeTacke[1].X)
            {
                midTackaY = dimenzija.Height / 2;
            }
            Vektor2D pocetnaTacka = new Vektor2D(0, midTackaX, midTackaY);
            if (postavke["vrhovi"])
            {
                pocetnaTacka.DrawVektor(g, new SolidBrush(Color.Pink));
                g.DrawString(pocetnaTacka.V.ToString(), font1, brush, pocetnaTacka.getPoint());

            }
            sortiraneEkstenzijeTacke.Insert(0, pocetnaTacka);

            // Dodaj krajnju tacku
            int brojTacaka = sortiraneEkstenzijeTacke.Count;
            float midTacka2X = (sortiraneEkstenzijeTacke[brojTacaka - 1].X + dimenzija.Width) / 2;
            float midTacka2Y = sortiraneEkstenzijeTacke[brojTacaka - 1].Y;
            if (sortiraneEkstenzijeTacke[brojTacaka - 2].X == sortiraneEkstenzijeTacke[brojTacaka - 1].X)
            {
                midTacka2Y = dimenzija.Height / 2;
            }
            Vektor2D pocetnaTacka2 = new Vektor2D(sortiraneEkstenzijeTacke.Count, midTacka2X, midTacka2Y);
            if (postavke["vrhovi"])
            {

                pocetnaTacka2.DrawVektor(g, new SolidBrush(Color.Pink));
                g.DrawString(pocetnaTacka2.V.ToString(), font1, brush, pocetnaTacka2.getPoint());
            }
            sortiraneEkstenzijeTacke.Add(pocetnaTacka2);
            mapaPuteva = new Graf(sortiraneEkstenzijeTacke.Count);
            mapaPuteva.SortiraneTackePuteva = sortiraneEkstenzijeTacke;

            for (int i = 0; i < sortiraneEkstenzijeTacke.Count; i++)
            {
                for (int k = i + 1; k < sortiraneEkstenzijeTacke.Count; k++)
                {
                    Segment potencijalnaGrana = new Segment(new Vektor2D(i, sortiraneEkstenzijeTacke[i]), new Vektor2D(k, sortiraneEkstenzijeTacke[k]));
                    bool sijeku = false;
                    for (int j = 0; j < prepreke.Count; j++)
                    {
                        if (prepreke[j].SegmentPresijekSaPoligonom(potencijalnaGrana))
                        {
                            sijeku = true;
                            break;
                        }
                    }
                    if (!sijeku)
                    {
                        if (postavke["grane"])
                            potencijalnaGrana.DrawSegment(g);
                        mapaPuteva.AddEdge(potencijalnaGrana.Poc, potencijalnaGrana.Kraj);
                        if (k != sortiraneEkstenzijeTacke.Count - 1 && Math.Abs(sortiraneEkstenzijeTacke[k].X - sortiraneEkstenzijeTacke[k + 1].X) < 1)
                        {
                            Segment dodatniSegment = new Segment(new Vektor2D(i, sortiraneEkstenzijeTacke[i]), new Vektor2D(k + 1, sortiraneEkstenzijeTacke[k + 1]));
                            bool sijeku2 = false;
                            for (int c = 0; c < prepreke.Count; c++)
                            {
                                if (prepreke[c].SegmentPresijekSaPoligonom(dodatniSegment))
                                {
                                    sijeku2 = true;
                                    break;
                                }
                            }
                            if (!sijeku2)
                            {
                                if (postavke["grane"])
                                    dodatniSegment.DrawSegment(g);
                                    mapaPuteva.AddEdge(dodatniSegment.Poc, dodatniSegment.Kraj);
                            }
                        }
                        break;
                    }
                }
            }
        }

        public static void GrafVidljivosti(List<Poligon> prepreke, Graphics g, ref Graf mapaPuteva, Dictionary<string, bool> postavke)
        {
            int brojTacaka = 0;
            for (int i = 0; i < prepreke.Count; i++)
                brojTacaka += prepreke[i].getTacke().Count;

            List<Vektor2D> tacke = new List<Vektor2D>();
            for (int i = 0; i < prepreke.Count; i++)
            {
                for (int j = 0; j < prepreke[i].getTacke().Count; j++)
                {
                    tacke.Add(prepreke[i].getTacke()[j]);
                }
            }

            List<Vektor2D> sortiraneTacke = tacke.OrderBy(i => i.X).ToList();
            Font font1 = new Font("Arial", 9, FontStyle.Regular, GraphicsUnit.Point);
            int index = 0;
            foreach (Vektor2D tacka in sortiraneTacke)
            {
                tacka.SetV(index);
                if (postavke["vrhovi"])
                    g.DrawString(tacka.V.ToString(), font1, new SolidBrush(Color.Green), tacka.getPoint());

                // Postaviti labelu za vrhove segmenta
                for (int i = 0; i < prepreke.Count; i++)
                {
                    for (int j = 0; j < prepreke[i].getSegmenti().Count; j++)
                    {
                        if (prepreke[i].getSegmenti()[j].Poc.Isti(tacka))
                        {
                            prepreke[i].getSegmenti()[j].Poc.SetV(index);
                        }
                        if (prepreke[i].getSegmenti()[j].Kraj.Isti(tacka))
                        {
                            prepreke[i].getSegmenti()[j].Kraj.SetV(index);
                        }
                    }
                }
                index++;
            }

            mapaPuteva = new Graf(brojTacaka);

            // Dodati susjedne grane u graf
            for (int i = 0; i < prepreke.Count; i++)
            {
                Poligon poligonA = prepreke[i];
                for (int j = 0; j < poligonA.getSegmenti().Count; j++)
                {
                    Segment segmentA = poligonA.getSegmenti()[j];
                    mapaPuteva.AddEdge(segmentA.Poc, segmentA.Kraj);
                }
            }



            for (int i = 0; i < prepreke.Count; i++)
            {
                Poligon poligonA = prepreke[i];
                for (int k = 0; k < poligonA.getTacke().Count; k++)
                {
                    Vektor2D tackaA = prepreke[i].getTacke()[k];
                    for (int j = i + 1; j < prepreke.Count; j++)
                    {

                        Poligon poligonB = prepreke[j];
                        for (int l = 0; l < prepreke[j].getTacke().Count; l++)
                        {
                            Vektor2D tackaB = poligonB.getTacke()[l];
                            Segment segment = new Segment(tackaA, tackaB);
                            bool presjek = false;
                            for (int p = 0; p < prepreke.Count; p++)
                            {
                                if (prepreke[p].SegmentPresijekSaPoligonom(segment))
                                {
                                    presjek = true;
                                    break;
                                }
                            }
                            if (!presjek)
                            {
                                if (postavke["grane"])
                                    segment.DrawSegment(g, Color.Blue);
                                mapaPuteva.AddEdge(segment.Poc, segment.Kraj);
                            }
                        }
                    }
                }
            }
        }



        public static int ProvjeriCeliju(List<Vektor2D> celija, List<Poligon> prepreke, List<Poligon> prazneCelije)
        {
            List<Segment> granice = new List<Segment> {
                new Segment(celija[0], celija[1]), new Segment(celija[1], celija[2]),
                new Segment(celija[2], celija[3]), new Segment(celija[3], celija[0]), };


            Poligon polya = new Poligon(granice);
            foreach (Poligon obs in prepreke)
            {
                Poligon polyb = obs;
                if (polyb.SadrziPoligon(polya))
                    return 1;
                if (polya.SadrziPoligon(polyb))
                    return 0;

                foreach (Segment granica in granice)
                {
                    for (int i = 0; i < obs.getTacke().Count; i++)
                    {
                        if (i == obs.getTacke().Count - 1)
                        {
                            Segment segment1 = new Segment(obs.getTacke()[i], obs.getTacke()[0]);
                            Segment segment2 = granica;
                            if (segment1.DaLiSeSegmentiSijeku(segment2))
                                return 0;
                        }
                        else
                        {
                            Segment segment1 = new Segment(obs.getTacke()[i], obs.getTacke()[i + 1]);
                            Segment segment2 = granica;
                            if (segment1.DaLiSeSegmentiSijeku(segment2))
                                return 0;
                        }
                    }
                }
            }
            prazneCelije.Add(new Poligon(granice));
            return -1;
        }
        public static void QuadTree(List<Vektor2D> regija, List<Poligon> prepreke, Graphics g, Dictionary<string, bool> postavke, ref Graf mapaPuteva)
        {
            Stack<List<Vektor2D>> celije = new Stack<List<Vektor2D>>();
            List<Poligon> prazneCelije = new List<Poligon>();

            celije.Push(regija);
            int regijaBr = 0;

            while (celije.Count > 0)
            {
                regija = celije.Pop();
                Vektor2D v0 = regija[0];
                Vektor2D v1 = regija[1];
                Vektor2D v2 = regija[2];
                Vektor2D v3 = regija[3];

                if ((v1.Y - v0.Y) > 10) // Udaljenost izmedju, finoca celija
                {
                    if (postavke["grane"])
                    {
                        new Segment(new Vektor2D((v3.X + v0.X) / 2, v0.Y), new Vektor2D((v3.X + v0.X) / 2, v1.Y)).DrawSegment(g);
                        new Segment(new Vektor2D(v0.X, (v1.Y + v0.Y) / 2), new Vektor2D(v3.X, (v1.Y + v0.Y) / 2)).DrawSegment(g);
                    }
                    List<Vektor2D> celija0 = new List<Vektor2D>{
                        new Vektor2D(v0.X, v0.Y), new Vektor2D(v0.X, (v1.Y + v0.Y) / 2),
                        new Vektor2D((v3.X + v0.X) / 2, (v1.Y + v0.Y) / 2), new Vektor2D((v3.X + v0.X) / 2, v0.Y) };
                    // Debug.WriteLine(ProvjeriCeliju(celija0, prepreke));
                    int rezultat = ProvjeriCeliju(celija0, prepreke, prazneCelije);
                    if (rezultat == 0)
                        celije.Push(celija0);    
                    List<Vektor2D> celija1 = new List<Vektor2D>{
                        new Vektor2D(v0.X, (v1.Y + v0.Y) / 2), new Vektor2D(v1.X, v1.Y),
                        new Vektor2D((v3.X + v0.X) / 2, v1.Y), new Vektor2D((v3.X + v0.X) / 2, (v1.Y + v0.Y) / 2) };
                     rezultat = ProvjeriCeliju(celija1, prepreke, prazneCelije);
                    if (rezultat == 0)
                        celije.Push(celija1);
                    List<Vektor2D> celija2 = new List<Vektor2D>{
                        new Vektor2D((v3.X + v0.X) / 2, (v1.Y + v0.Y) / 2), new Vektor2D((v3.X + v0.X) / 2, v1.Y),
                        new Vektor2D(v2.X,v2.Y), new Vektor2D(v3.X, (v1.Y + v0.Y) / 2) };
                     rezultat = ProvjeriCeliju(celija2, prepreke, prazneCelije);
                    if (rezultat == 0)
                        celije.Push(celija2);
                    List<Vektor2D> celija3 = new List<Vektor2D>{
                        new Vektor2D((v3.X + v0.X) / 2, v0.Y), new Vektor2D((v3.X + v0.X) / 2,(v1.Y + v0.Y) / 2),
                        new Vektor2D(v3.X,(v1.Y + v0.Y) / 2), new Vektor2D(v3.X,v3.Y) };
                     rezultat = ProvjeriCeliju(celija3, prepreke, prazneCelije);
                    if (rezultat == 0)
                        celije.Push(celija3);
                }
            }

            mapaPuteva = GenerisiQuadTreeGraf(prazneCelije, g, postavke, prepreke);

            // mapaPuteva.printGrane();
        }

        public static Graf GenerisiQuadTreeGraf(List<Poligon> prazneCelije, Graphics g, Dictionary<string, bool> postavke, List<Poligon> prepreke) {
            int brojacV = 0;
            int granica = 200;
            Graf noviGraf = new Graf(prazneCelije.Count);
            Font font = new Font("Arial", 9, FontStyle.Regular, GraphicsUnit.Point);


            foreach (Poligon celija in prazneCelije) {
                // Dodavanje cvorova u graf i iscrtavanje celije
                List<Segment> granice = new List<Segment> {
                    new Segment(celija.getTacke()[0], celija.getTacke()[1]), new Segment(celija.getTacke()[1], celija.getTacke()[2]),
                    new Segment(celija.getTacke()[2], celija.getTacke()[3]), new Segment(celija.getTacke()[3], celija.getTacke()[0]), };
                Vektor2D sredina = new Vektor2D((celija.getTacke()[3].X + celija.getTacke()[0].X) / 2, (celija.getTacke()[1].Y + celija.getTacke()[0].Y) / 2);
                // 
                if (postavke["vrhovi"])
                    sredina.DrawVektor(g);
                sredina.SetV(brojacV);
                if (postavke["vrhovi"])
                    g.DrawString(sredina.V.ToString(), font, new SolidBrush(Color.Green), sredina.getPoint());
                // noviGraf.AddNode(sredina);
                prazneCelije[brojacV].sredina = sredina;

                brojacV++;

            }

            // Povezivanje cvorova koji su na granici
            foreach (Poligon celija in prazneCelije) {
                Vektor2D sredina = celija.sredina;
                foreach (Poligon celija2 in prazneCelije) {
                    if (!celija.Isti(celija2)) {
                        Vektor2D sredina2 = celija2.sredina;
                        if (Vektor2D.getUdaljenost(sredina, sredina2) < granica) {
                            // Check if edge is intersecting with any of the edges of the polygon
                            bool intersect = false;
                            foreach(Poligon prepreka in prepreke) {
                                foreach (Segment granicaPrepreke in prepreka.getSegmenti()) {
                                    if (granicaPrepreke.DaLiSeSegmentiSijeku(new Segment(sredina, sredina2))) {
                                        intersect = true;
                                        break;
                                    }
                                }
                                if (intersect)
                                    break;
                            }
                            if (!intersect) {
                                noviGraf.AddEdge(sredina, sredina2);
                                if (postavke["dodatno"])
                                    new Segment(sredina, sredina2).DrawSegment(g);
                            }
                        }
                    }
                }
            }



            return noviGraf;
        }
    }
}
