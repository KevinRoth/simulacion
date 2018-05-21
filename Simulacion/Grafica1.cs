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
        private readonly List<Generado> _lista;
        private double _chi;
        private readonly int _cantidadIntervalos;
        private readonly Distribucion _distribucion;
        private Intervalo[] _intervalos; //vector de subintervalos

        public Grafica1(List<Generado> lista, int cantidadIntervalos, Distribucion distribucion = null)
        {
            InitializeComponent();
            _lista = lista;
            _cantidadIntervalos = cantidadIntervalos;
            _distribucion = distribucion;
            CargarHistograma();
        }

        /// <summary>
        /// Metodo que permite cargar el histograma
        /// </summary>
        private void CargarHistograma()
        {
            //creo los intervalos del histograma
            _intervalos = new Intervalo[_cantidadIntervalos];

            var rango = _lista.Max(aleatorio => aleatorio.NumAleatorio) - _lista.Min(aleatorio => aleatorio.NumAleatorio);
            var amplitudIntervalo = rango / _cantidadIntervalos;

            //A partir de la cantidad de cantidadIntervalos, calculamos sus limites
            //Intervalo [a,b)
            for (var i = 0; i < _cantidadIntervalos; i++)
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
                    _intervalos[i] = new Intervalo(_lista.Min(aleatorio => aleatorio.NumAleatorio), 
                                                  _lista.Min(aleatorio => aleatorio.NumAleatorio) + amplitudIntervalo);
                else
                {
                    _intervalos[i] = new Intervalo(_intervalos[i - 1].LimiteSuperior,
                        _intervalos[i - 1].LimiteSuperior + amplitudIntervalo);
                }
            }

            //ahora recorremos la lista para calcular las frecuencias observadas.
            foreach (var t1 in _lista)
            {
                foreach (var t in _intervalos)
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
            for (int i = 0; i < _cantidadIntervalos; i++)
            {
                listaEnteros.Add(_intervalos[i].CantidadObservaciones);

                //Agrego el punto a la serie
                histogramaGenerado.Series[0].Points.Add(_intervalos[i].CantidadObservaciones);

                //Agrego los labels de de los intervalos
                histogramaGenerado.Series[0].Points[i].AxisLabel =
                    "[" + TruncateFunction(_intervalos[i].LimiteInferior, 4)
                    + " / " +
                    TruncateFunction(_intervalos[i].LimiteSuperior, 4) + ")";

                //Pongo vertical los label 
                histogramaGenerado.ChartAreas[0].AxisX.LabelStyle.Angle = 90;

                histogramaGenerado.Series[0].IsValueShownAsLabel = true;
                histogramaGenerado.Series[0].LegendText = _intervalos[i].CantidadObservaciones.ToString();
                histogramaGenerado.Series[0].LabelAngle = 90;
                histogramaGenerado.Series[0].Points[i].LabelAngle = 90;
            }

            //Obtenemos la cantidad total de observaciones
            var cantidadObservaciones = double.Parse(_lista.Count.ToString());
            histogramaGenerado.ChartAreas[0].AxisY.Maximum = listaEnteros.Max();

            //Obtenemos la frecuencia esperada de la serie

            //es del tp1
            if (_distribucion == null)
            {
                var freEsperada = (double) cantidadObservaciones / (double) _cantidadIntervalos;
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
            foreach (var t in _intervalos)
            {
                var subint = TruncateFunction(t.LimiteInferior, 4) + " / " + TruncateFunction(t.LimiteSuperior, 4);
                var frecuenciaEsperadaPorIntervalo = _distribucion.CalcularFrecuenciaEsperadaEnIntervalo(t, _lista.Count, _intervalos.Length);
                var suma = Math.Pow((t.CantidadObservaciones - frecuenciaEsperadaPorIntervalo), 2) / frecuenciaEsperadaPorIntervalo;

                dataGridView1.Rows.Add(subint,
                    t.CantidadObservaciones,
                    frecuenciaEsperadaPorIntervalo,
                    suma);

                //Vamos acumulando chi observado
                _chi += suma;
            }

            label1.Text = _chi.ToString();
        }

        /// <summary>
        /// Retorna el numero con la cantidad de digitos despues de la coma indicados por parametro
        /// </summary>
        /// <param name="number"></param>
        /// <param name="digits"></param>
        /// <returns></returns>
        public double TruncateFunction(double number, int digits)
        {
            var stepper = (double) (Math.Pow(10.0, (double) digits));
            var temp = (int) (stepper * number);
            return (double) temp / stepper;
        }

        /// <summary>
        /// Evento que permite comprobar la prueba de bondad de ajuste
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_compro_Click_1(object sender, EventArgs e)
        {
            if (_chi <= double.Parse(txt_chicierto.Text))
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