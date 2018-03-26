using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Simulacion.Modelos;
using Simulacion.Servicios;

namespace Simulacion
{
    public partial class Histograma : Form
    {
        private int Intervalos { set; get; }
        private List<double> ListaNumeros { set; get; }
        public List<Intervalo> ListaIntervalos { set; get; }
        public double frecEsperada;

        public Histograma(int intervalos, List<double> listaNumeros, double frecEsperada)
        {
            InitializeComponent();
            this.Intervalos = intervalos;
            this.ListaNumeros = listaNumeros;
            this.ListaIntervalos = new List<Intervalo>();//creo lista vacia para despues enviarse a HistogramChartHelper y la llene
            this.frecEsperada = frecEsperada;
        }


        public void crearHistograma()
        {
            chart1.Series[0].Points.Clear();
            foreach (var nroRnd in ListaNumeros)
            {
                chart1.Series[0].Points.Add(nroRnd);
            }
            //' Set Legend visual attributes
            HistogramChartHelper hch = new HistogramChartHelper();
            //' Show the percent frequency on the right Y axis.
            hch.ShowPercentOnSecondaryYAxis = false;
            //' Specify number of segment intervals
            hch.SegmentIntervalNumber = this.Intervalos;

            //histogramHelper.SegmentIntervalNumber = Me.cantidadIntervalos
            //'histogramHelper.SegmentIntervalWidth = Me.amplitudIntervalo
            //' Or you can specify the exact length of the interval
            //' histogramHelper.SegmentIntervalWidth = 15;
            //' Create histogram series
            hch.CreateHistogram(chart1, "Series1", "Histogram", ListaIntervalos);
       //     lblFrecuencia.Text = frecEsperada.ToString();
        }


        /// <summary>
        /// devuelve la amplitud unicamente si los numeros generados estan entre 0 y 1
        /// </summary>
        /// <returns></returns>
        private double calcularAmplitudDeIntervalos()
        {

            ListaNumeros.Sort();//ordeno la lista de numeros generados
            return ListaNumeros.Count / Intervalos;
        }

        public double TruncateFunction(double number, int digits)
        {
            double stepper = (double)(Math.Pow(10.0, (double)digits));
            int temp = (int)(stepper * number);
            return (double)temp / stepper;
        }



        private void Histograma_Load(object sender, EventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
