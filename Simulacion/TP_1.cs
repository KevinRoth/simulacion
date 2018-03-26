using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Simulacion.Modelos;

namespace Simulacion
{
    public partial class TP_1 : Form
    {
        private GeneradorMixto aleatorioMixtos { get; set; }
        private GeneradorMultiplicativo aleatorioMultiplicativo { get; set; }
        private List<Generados> listaAleatoriosMultiplicativos { get; set; }
        private List<Generados> listaAleatoriosMixtos{ get; set; }

        public TP_1()
        {
            InitializeComponent();
            aleatorioMixtos= new GeneradorMixto();
            aleatorioMultiplicativo = new GeneradorMultiplicativo();
        }

        public void inicializarGrilla()
        {
            listaAleatoriosMixtos = new List<Generados>();
            listaAleatoriosMultiplicativos = new List<Generados>();
            grilla_multiplicativo.Rows.Clear();
            grilla_mixto.Rows.Clear();
        }

        private void btn_generar_aleatorios_Click(object sender, EventArgs e)
        {
            inicializarGrilla();

            try
            {
                aleatorioMixtos.Generado.Semilla = double.Parse(txt_semilla.Text);
                aleatorioMixtos.C = double.Parse(txt_c.Text);
                aleatorioMixtos.A = double.Parse(txt_a.Text);
                aleatorioMixtos.M = double.Parse(txt_m.Text);

                grilla_mixto.Rows.Add(0,
                                           aleatorioMixtos.Generado.Semilla,
                                           0);

                for (int i = 0; i < 20; i++)
                {
                    listaAleatoriosMixtos.Add(aleatorioMixtos.generarAleatorio());

                    grilla_mixto.Rows.Add(i + 1,
                                         aleatorioMixtos.Generado.Semilla,
                                         TruncateFunction(aleatorioMixtos.Generado.NumAleatorio,4));
                }

                
            }
            catch (Exception)
            {

                MessageBox.Show("Ingrese los valores obligatorios!!");
            }


        }

        public double TruncateFunction(double number, int digits)
        {
            double stepper = (double)(Math.Pow(10.0, (double)digits));
            int temp = (int)(stepper * number);
            return (double)temp / stepper;
        }

        private void txt_k_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var k = double.Parse(this.txt_k.Text);
                aleatorioMixtos.CalcularA(k);

                txt_a.Text = aleatorioMixtos.A.ToString();
                txt_a.Enabled = false;

            }
            catch (Exception)
            {
                txt_a.Text = "";
                Console.Write(e.ToString());
            }

        }

        private void txt_g_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var g = double.Parse(this.txt_g.Text);
                aleatorioMixtos.CalcularM(g);

                txt_m.Text = aleatorioMixtos.M.ToString();
                txt_m.Enabled = false;
            }
            catch (Exception)
            {
                txt_m.Text = "";
                Console.Write(e.ToString());
            }
            
        }

        private void btn_reestablecer_panel_multiplicativo_Click(object sender, EventArgs e)
        {
            txt_a.Text = "";
            txt_c.Text = "";
            txt_g.Text = "";
            txt_k.Text = "";
            txt_m.Text = "";
            txt_semilla.Text = "";

            txt_a.Enabled = true;
            txt_m.Enabled = true;

            inicializarGrilla();
        }

        private void txt_k_multiplicativo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var k = double.Parse(this.txt_k_multiplicativo.Text);
                aleatorioMultiplicativo.CalcularA(k);

                txt_a_multiplicativo.Text = aleatorioMultiplicativo.A.ToString();
                txt_a_multiplicativo.Enabled = false;

            }
            catch (Exception)
            {
                txt_a_multiplicativo.Text = "";
                Console.Write(e.ToString());
            }
        }

        private void txt_g_multiplicativo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var g = double.Parse(this.txt_g_multiplicativo.Text);
                aleatorioMultiplicativo.CalcularM(g);

                txt_m_multiplicativo.Text = aleatorioMultiplicativo.M.ToString();
                txt_m_multiplicativo.Enabled = false;
            }
            catch (Exception)
            {
                txt_m_multiplicativo.Text = "";
                Console.Write(e.ToString());
            }
        }

        private void btn_reestablecer_multiplicativo_Click(object sender, EventArgs e)
        {
            txt_a_multiplicativo.Text = "";
            txt_g_multiplicativo.Text = "";
            txt_k_multiplicativo.Text = "";
            txt_m_multiplicativo.Text = "";
            txt_semilla_multiplicativo.Text = "";

            txt_a_multiplicativo.Enabled = true;
            txt_m_multiplicativo.Enabled = true;

            inicializarGrilla();
        }

        private void btn_generar_aleatorios_multiplicativo_Click(object sender, EventArgs e)
        {
            inicializarGrilla();

            try
            {
                aleatorioMultiplicativo.Generado.Semilla = double.Parse(txt_semilla_multiplicativo.Text);
                aleatorioMultiplicativo.A = double.Parse(txt_a_multiplicativo.Text);
                aleatorioMultiplicativo.M = double.Parse(txt_m_multiplicativo.Text);

                grilla_multiplicativo.Rows.Add(0,
                                           aleatorioMultiplicativo.Generado.Semilla,
                                           0);

                for (int i = 0; i < 20; i++)
                {
                    listaAleatoriosMixtos.Add(aleatorioMultiplicativo.generarAleatorio());

                    grilla_multiplicativo.Rows.Add(i + 1,
                                         aleatorioMultiplicativo.Generado.Semilla,
                                         TruncateFunction(aleatorioMultiplicativo.Generado.NumAleatorio, 4));
                }


            }
            catch (Exception)
            {

                MessageBox.Show("Ingrese los valores obligatorios!!");
            }

        }
    }
}
