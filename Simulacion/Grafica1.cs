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

namespace Simulacion
{
    public partial class Grafica1 : Form
    {
        List<Generados> lista;
        double chi;
        int intervalos;
        Subintervalos[] sub_intervalos; //vector de subintervalos

        public Grafica1(List<Generados> lista, int intervalos)
        {
            InitializeComponent();
            this.lista = lista;
            this.intervalos = intervalos;
            cargarHistograma();
        }

        private void cargarHistograma()
        {
            //creo los subintervalos del histograma
            sub_intervalos = new Subintervalos[intervalos];
            for (int i = 0; i < intervalos; i++)
            {
                if (i == 0)
                    sub_intervalos[i] = new Subintervalos(0, ((float) 1 / intervalos) * (i + 1));
                else
                {
                    sub_intervalos[i] = new Subintervalos(sub_intervalos[i - 1].LimiteSuperior,
                        ((float) 1 / intervalos) * (i + 1));
                }
            }

            //ahora recorremos la lista para calcular las frecuencias.
            for (int i = 0; i < lista.Count; i++)
            {
                for (int j = 0; j < sub_intervalos.Length; j++)
                {
                    if (lista[i].NumAleatorio >= sub_intervalos[j].LimiteInferior &&
                        lista[i].NumAleatorio <= sub_intervalos[j].LimiteSuperior)
                    {
                        sub_intervalos[j].CantidadObservaciones++;
                    }

                }
            }

            //limpiamos el chart y preparamos el nuevo histograma
            List<int> listaEnteros = new List<int>(); //lista para acumular las cantidades de cada intervalo y luego poder obtener el MAX()
            histogramaGenerado.Series.Clear();
            histogramaGenerado.Series.Add("Frecuecias Observadas");


            for (int i = 0; i < intervalos; i++)
            {
                listaEnteros.Add(sub_intervalos[i].CantidadObservaciones);
                histogramaGenerado.Series[0].Points.Add(sub_intervalos[i].CantidadObservaciones);
                histogramaGenerado.Series[0].Points[i].AxisLabel =
                    "[" + sub_intervalos[i].LimiteInferior + " - " + sub_intervalos[i].LimiteSuperior + "]";
                histogramaGenerado.Series[0].IsValueShownAsLabel = true;
            }

            double cantidadObservaciones = double.Parse(lista.Count.ToString());
            histogramaGenerado.ChartAreas[0].AxisY.Maximum = listaEnteros.Max();
            double freEsperada = (double) cantidadObservaciones / (double) intervalos;
            lblFrecuenciaEsperada.Text = freEsperada.ToString();
            histogramaGenerado.Series["Frecuecias Observadas"].Color = Color.Blue;


            cargarTabla();

        }

        private void cargarTabla()
        {

            for (int i = 0; i < sub_intervalos.Length; i++)
            {
                string subint = sub_intervalos[i].LimiteInferior + " - " + sub_intervalos[i].LimiteSuperior;
                double freEsp = lista.Count / intervalos;
                dataGridView1.Rows.Add(subint, sub_intervalos[i].CantidadObservaciones, freEsp, Math.Pow((sub_intervalos[i].CantidadObservaciones - freEsp), 2));

                chi += Math.Pow(sub_intervalos[i].CantidadObservaciones - freEsp, 2) / freEsp;
            }
            double suma = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                suma += Convert.ToDouble(row.Cells[3].Value);
            }
           // chi = suma / (lista.Count / intervalos);
            label1.Text = Convert.ToString(chi);
        }

        private void btn_compro_Click_1(object sender, EventArgs e)
        {
            if (chi < double.Parse(txt_chicierto.Text))
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

