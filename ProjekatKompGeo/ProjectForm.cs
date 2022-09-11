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
                if (pocetakKraj.Count == 2)
                {
                    MessageBox.Show("Tačke destinacija su postavljene!");
                    return;
                }
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
                // Check if point is inside polygon
                Vektor2D tackaPuta = new Vektor2D(e.X, e.Y);    
                for (int i = 0; i < prepreke.Count; i++)
                {
                    if (prepreke[i].TackaUnutarPoligona(tackaPuta))
                    {
                        MessageBox.Show("Tacka je unutar poligona!");
                        return;
                    }
                }
                if (pocetakKraj.Count < 2)
                {
                    Vektor2D tacka = new Vektor2D(e.X, e.Y);
                    if (pocetakKraj.Count == 0)
                    {
                        tacka.DrawVektor(g, new SolidBrush(Color.Green), 10);
                        pocetakKraj.Add(tacka);
                    }
                    else
                    {
                        tacka.DrawVektor(g, new SolidBrush(Color.Violet), 10);
                        pocetakKraj.Add(tacka);
                    }
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
            Dictionary<string, bool> postavke = new Dictionary<string, bool>();
            postavke["vrhovi"] = vrhoviBox.Checked;
            postavke["grane"] = graneBox.Checked;
            postavke["dodatno"] = dodatnoBox.Checked;

            HelperFunkcije.TrapezoidnaDekompozicija(dimenzija, prepreke, g, ref mapaPuteva, postavke);
        }

        private void grafVidButton_Click(object sender, EventArgs e)
        {
            Dictionary<string, bool> postavke = new Dictionary<string, bool>();
            postavke["vrhovi"] = vrhoviBox.Checked;
            postavke["grane"] = graneBox.Checked;

            HelperFunkcije.GrafVidljivosti(prepreke, g, ref mapaPuteva, postavke);
        }

        private void quadtreeButton_Click(object sender, EventArgs e)
        {
            Size d = screenPanel.Size;
            Dictionary<string, bool> postavke = new Dictionary<string, bool>();
            postavke["vrhovi"] = vrhoviBox.Checked;
            postavke["grane"] = graneBox.Checked;
            postavke["dodatno"] = dodatnoBox.Checked;

            HelperFunkcije.QuadTree(new List<Vektor2D> {
                 new Vektor2D(0,0), new Vektor2D(0,d.Height),
                 new Vektor2D(d.Width,d.Height), new Vektor2D(d.Width,0) },
                 prepreke, g, postavke, ref mapaPuteva);     
        }

        private void nadjiPut_click(object sender, EventArgs e)
        {

            if (mapaPuteva == null || pocetakKraj.Count == 0)
                return;
            
            if (bfsButton.Checked)
            {
                mapaPuteva.BFS(pocetakKraj[0], pocetakKraj[1], g);
                return;
            }

            if (dfsButton.Checked)
            {
                mapaPuteva.DFS(pocetakKraj[0], pocetakKraj[1], g);
                return;
            }
             
            if (djikstraRadio.Checked)
            {
                mapaPuteva.DJIKSTRA(pocetakKraj[0], pocetakKraj[1], g);
                return;
            }

            if (astarRadio.Checked)
            {
                mapaPuteva.A_STAR(pocetakKraj[0], pocetakKraj[1], g);
                return;
            }

        }

        private void destRadio_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void bfsButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void reset_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            prepreke.Clear();
            pocetakKraj.Clear();
            mapaPuteva = null;
        }
    }
}
