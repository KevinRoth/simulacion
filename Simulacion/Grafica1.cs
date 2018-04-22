using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Simulacion.Modelos;
using Simulacion.Modelos.Distribuciones;

namespace Simulacion
{
    public partial class Grafica1 : Form
    {
        private readonly List<Generado> lista;
        double chi;
        private readonly int cantidadIntervalos;
        private Distribucion Distribucion;
        Intervalo[] intervalos; //vector de subintervalos

        public Grafica1(List<Generado> lista, int cantidadIntervalos, Distribucion distribucion = null)
        {
            InitializeComponent();
            this.lista = lista;
            this.cantidadIntervalos = cantidadIntervalos;
            Distribucion = distribucion;
            CargarHistograma();
        }

        /// <summary>
        /// Metodo que permite cargar el histograma
        /// </summary>
        private void CargarHistograma()
        {
            //creo los intervalos del histograma
            intervalos = new Intervalo[cantidadIntervalos];

            var rango = lista.Max(aleatorio => aleatorio.NumAleatorio) - lista.Min(aleatorio => aleatorio.NumAleatorio);
            var amplitudIntervalo = rango / cantidadIntervalos;

            //A partir de la cantidad de cantidadIntervalos, calculamos sus limites
            //Intervalo [a,b)
            for (var i = 0; i < cantidadIntervalos; i++)
            {
                //para tp1
                /*  if (i == 0)
                      intervalos[i] = new Intervalo(0, ((double) 1 / cantidadIntervalos) * (i + 1));
                  else
                  {
                      intervalos[i] = new Intervalo(intervalos[i - 1].LimiteSuperior,
                          ((double) 1 / cantidadIntervalos) * (i + 1));
                  }*/


                if (i == 0)
                    intervalos[i] = new Intervalo(lista.Min(aleatorio => aleatorio.NumAleatorio), 
                                                  lista.Min(aleatorio => aleatorio.NumAleatorio) + amplitudIntervalo);
                else
                {
                    intervalos[i] = new Intervalo(intervalos[i - 1].LimiteSuperior,
                        intervalos[i - 1].LimiteSuperior + amplitudIntervalo);
                }
            }

            //ahora recorremos la lista para calcular las frecuencias observadas.
            foreach (var t1 in lista)
            {
                foreach (var t in intervalos)
                {
                    if (t1.NumAleatorio >= t.LimiteInferior &&
                        t1.NumAleatorio < t.LimiteSuperior)
                    {
                        t.CantidadObservaciones++;
                    }
                }
            }

            //limpiamos el chart y preparamos el nuevo histograma
            List<int>
                listaEnteros =
                    new List<int>(); //lista para acumular las cantidades de cada intervalo y luego poder obtener el MAX()


            //creo la serie y la seteo
            histogramaGenerado.Series.Clear();
            histogramaGenerado.Series.Add("Frecuecias Observadas");
            histogramaGenerado.Series["Frecuecias Observadas"].ChartType = SeriesChartType.Column;
            histogramaGenerado.Series["Frecuecias Observadas"].Color = Color.DarkGray;
     
            //cargamos el histograma con la cantidad de observaciones de cada intervalo
            for (int i = 0; i < cantidadIntervalos; i++)
            {
                listaEnteros.Add(intervalos[i].CantidadObservaciones);

                //Agrego el punto a la serie
                histogramaGenerado.Series[0].Points.Add(intervalos[i].CantidadObservaciones);

                //Agrego los labels de de los intervalos
                histogramaGenerado.Series[0].Points[i].AxisLabel =
                    "[" + TruncateFunction(intervalos[i].LimiteInferior, 4)
                    + " - " +
                    TruncateFunction(intervalos[i].LimiteSuperior, 4) + "]";

                //Pongo vertical los label 
                histogramaGenerado.ChartAreas[0].AxisX.LabelStyle.Angle = 90;

                histogramaGenerado.Series[0].IsValueShownAsLabel = true;
                histogramaGenerado.Series[0].LegendText = intervalos[i].CantidadObservaciones.ToString();
                histogramaGenerado.Series[0].LabelAngle = 90;
                histogramaGenerado.Series[0].Points[i].LabelAngle = 90;
            }

            //Obtenemos la cantidad total de observaciones
            double cantidadObservaciones = double.Parse(lista.Count.ToString());
            histogramaGenerado.ChartAreas[0].AxisY.Maximum = listaEnteros.Max();

            //Obtenemos la frecuencia esperada de la serie

            //es del tp1
            if (Distribucion == null)
            {
                double freEsperada = (double) cantidadObservaciones / (double) cantidadIntervalos;
                lblFrecuenciaEsperada.Text = freEsperada.ToString();
            }
            

            //llamada al metodo para cargar la tabla de frecuencias
            CargarTabla();
        }

        /// <summary>
        /// Metodo que permite cargar la tabla de frecuencias
        /// </summary>
        private void CargarTabla()
        {
            foreach (var t in intervalos)
            {
                var subint = TruncateFunction(t.LimiteInferior, 4) + " - " + TruncateFunction(t.LimiteSuperior, 4);
                var frecuenciaEsperadaPorIntervalo = Distribucion.CalcularFrecuenciaEsperadaEnIntervalo(t, lista.Count, intervalos.Length);
                var suma = Math.Pow((t.CantidadObservaciones - frecuenciaEsperadaPorIntervalo), 2) / frecuenciaEsperadaPorIntervalo;

                dataGridView1.Rows.Add(subint,
                    t.CantidadObservaciones,
                    frecuenciaEsperadaPorIntervalo,
                    suma);

                //Vamos acumulando chi observado
                chi += suma;
            }

            label1.Text = chi.ToString();
        }

        /// <summary>
        /// Retorna el numero con la cantidad de digitos despues de la coma indicados por parametro
        /// </summary>
        /// <param name="number"></param>
        /// <param name="digits"></param>
        /// <returns></returns>
        public double TruncateFunction(double number, int digits)
        {
            double stepper = (double) (Math.Pow(10.0, (double) digits));
            int temp = (int) (stepper * number);
            return (double) temp / stepper;
        }

        /// <summary>
        /// Evento que permite comprobar la prueba de bondad de ajuste
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_compro_Click_1(object sender, EventArgs e)
        {
            if (chi <= double.Parse(txt_chicierto.Text))
            {
                MessageBox.Show("Se acepta la hipotesis nula");
            }
            else
            {
                MessageBox.Show("Se rechaza la hipotesis nula");
            }
        }
    }
}