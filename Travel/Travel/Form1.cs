using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Travel
{
    public partial class Form1 : Form
    {
        private Population _population;
        private int populationNumber = 20;

        public Form1()
        {
            InitializeComponent();

            _population = new Population(populationNumber);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            return;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Drawing.Graphics graphicsObj;
            graphicsObj = this.CreateGraphics();
            var clipRect = graphicsObj.VisibleClipBounds;

            Pen myPen = new Pen(System.Drawing.Color.Green, 2);

            // Create font and brush.
            Font drawFont = new Font("Arial", 16);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            float dx = clipRect.Width;
            float dy = clipRect.Height;

            var chromosome = _population.GetBestChromosome();

            var xMin = 999999.9;
            var xMax = -999999.9;
            var yMin = 999999.9;
            var yMax = -999999.9;

            for (int n = 0; n < chromosome.i_genotype.genes.Count; n++)
            {
                var city = chromosome.i_genotype.genes[n];
                var R = 6371;

                var x1 = (float)(R * Math.Cos(DegreesToRadians(city._Latitude)) * Math.Cos(DegreesToRadians(city._Longitude)));
                var y1 = (float)(R * Math.Cos(DegreesToRadians(city._Latitude)) * Math.Sin(DegreesToRadians(city._Longitude)));

                xMin = Math.Min(xMin, x1);
                xMax = Math.Max(xMax, x1);
                yMin = Math.Min(yMin, y1);
                yMax = Math.Max(yMax, y1);
            }

            var xMulti = (dx / (xMax - xMin)) * 0.8;
            var yMulti = (dy / (yMax - yMin)) * 0.8;

            for (int n = 0; n < chromosome.i_genotype.genes.Count - 1; n++)
            {
                var city = chromosome.i_genotype.genes[n];
                var nextCity = chromosome.i_genotype.genes[n+1];
                var R = 6371;

                var x1 = (float)(R * Math.Cos(DegreesToRadians(city._Latitude)) * Math.Cos(DegreesToRadians(city._Longitude)) - xMin) * (float)xMulti;
                var y1 = (float)(R * Math.Cos(DegreesToRadians(city._Latitude)) * Math.Sin(DegreesToRadians(city._Longitude)) - yMin) * (float)yMulti;
                var x2 = (float)(R * Math.Cos(DegreesToRadians(nextCity._Latitude)) * Math.Cos(DegreesToRadians(nextCity._Longitude)) - xMin) * (float)xMulti;
                var y2 = (float)(R * Math.Cos(DegreesToRadians(nextCity._Latitude)) * Math.Sin(DegreesToRadians(nextCity._Longitude)) - yMin) * (float)yMulti;

                graphicsObj.DrawLine(myPen, x1, y1, x2, y2);

                graphicsObj.DrawString(city._Name, drawFont, drawBrush, x1, y1);
                graphicsObj.DrawString(nextCity._Name, drawFont, drawBrush, x2, y2);
            }
        }

        private static double DegreesToRadians(double deg)
        {
            return deg * (System.Math.PI / 180);
        }

        private void button2_Click(object sender, EventArgs e)
        {           
            int gen = 0;
            while (gen <= 100)
            {
                this._population.evolve();
                ++gen;
            }
            return;
        }
    }
}
