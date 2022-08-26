using ProjekatKompGeo.GeoObjekti;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ProjekatKompGeo
{
    public partial class ProjectForm : Form
    {
        private readonly Graphics g;
        private readonly Pen p;

        private readonly List<Vektor2D> tacke = new List<Vektor2D>();
        private List<Poligon> prepreke = new List<Poligon>();
        private List<Vektor2D> pocetakKraj = new List<Vektor2D>();
        private Graf mapaPuteva;

        public ProjectForm()
        {
            InitializeComponent();
            g = screenPanel.CreateGraphics();
            p = new Pen(Color.FromArgb(255, 0, 0, 0));

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e) { }

        private void screenPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (poligonRadio.Checked)
            {
                Vektor2D tacka = new Vektor2D(e.X, e.Y);
                tacke.Add(tacka);
                tacka.DrawVektor(g);
                
                if (tacke.Count == 5)
                {
                    Poligon noviPoligon = new Poligon(new List<Vektor2D>(tacke));
                    prepreke.Add(noviPoligon);
                    noviPoligon.DrawPoligon(g, p);

                    tacke.Clear();
                }
            }
            if (destRadio.Checked)
            {
                if (pocetakKraj.Count < 2)
                {
                    Vektor2D tacka = new Vektor2D(e.X, e.Y);
                    pocetakKraj.Add(tacka);
                    if (pocetakKraj.Count == 0)
                        tacka.DrawVektor(g, new SolidBrush(Color.Green), 10);
                    else
                        tacka.DrawVektor(g, new SolidBrush(Color.Violet), 10);
                }
            }
        }

        private void generisiPoligone_Click(object sender, EventArgs e)
        {
            Size dimenzija =  screenPanel.Size;
            // Poligon generisaniPoligon = Poligon.GenerisiPoligon(10, dimenzija, 300);
            // generisaniPoligon.DrawPoligon(g, p);

            int brojPoligona = (int)generisiNo.Value;
            int velicinaPoligona = (int)velicinaNo.Value;

            prepreke = Poligon.GenerisiPoligone(brojPoligona, dimenzija, velicinaPoligona);
            for (int i = 0; i < prepreke.Count; i++)
                prepreke[i].DrawPoligon(g, p);

        }

        private void trapezDekom_Click(object sender, EventArgs e)
        {
            Size dimenzija = screenPanel.Size;
            HelperFunkcije.TrapezoidnaDekompozicija(dimenzija, prepreke, g, ref mapaPuteva);
        }

        private void grafVidButton_Click(object sender, EventArgs e)
        {
            HelperFunkcije.GrafVidljivosti(prepreke, g, ref mapaPuteva);
        }

        private void quadtreeButton_Click(object sender, EventArgs e)
        {
            Size d = screenPanel.Size;
            HelperFunkcije.QuadTree(new List<Vektor2D> {
                 new Vektor2D(0,0), new Vektor2D(0,d.Height),
                 new Vektor2D(d.Width,d.Height), new Vektor2D(d.Width,0) },
                 prepreke, g);
            

        }

        private void nadjiPut_click(object sender, EventArgs e)
        {
            if (mapaPuteva == null)
                return;

            if (bfsButton.Checked)
            {
                // mapePuteva.printGrane();
                List<Vektor2D> sortiraneEkstenzijeTacke = mapaPuteva.SortiraneTackePuteva;
                
                List<int> BFSput = mapaPuteva.BFS(sortiraneEkstenzijeTacke[0], sortiraneEkstenzijeTacke[sortiraneEkstenzijeTacke.Count - 1], g);
                /*
                for (int i = 0; i < BFSput.Count - 1; i++)
                {
                     Segment segmentPuta = new Segment(sortiraneEkstenzijeTacke[BFSput[i]], sortiraneEkstenzijeTacke[BFSput[i + 1]]);
                     segmentPuta.DrawSegment(g, Color.Chocolate);
                }
                */
                return;
            }

            if (dfsButton.Checked)
            {
                List<Vektor2D> sortiraneEkstenzijeTacke = mapaPuteva.SortiraneTackePuteva;
                List<int> DFSput = mapaPuteva.DFS(sortiraneEkstenzijeTacke[0], sortiraneEkstenzijeTacke[sortiraneEkstenzijeTacke.Count - 1], g);
                /*
                for (int i = 0; i < DFSput.Count - 1; i++)
                {
                    Segment segmentPuta = new Segment(sortiraneEkstenzijeTacke[DFSput[i]], sortiraneEkstenzijeTacke[DFSput[i + 1]]);
                    segmentPuta.DrawSegment(g, Color.DarkGreen);
                }
                */
                return;
            }

        }

        private void destRadio_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
