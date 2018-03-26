using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Simulacion.Servicios;

namespace Simulacion
{
    public partial class TP_1 : Form
    {
        private GeneradorMultiplicativo aleatorioMultiplicativo { get; set; }
        private List<GeneradosMultiplicativo> listaAleatoriosMultiplicativos { get; set; }

        public TP_1()
        {
            InitializeComponent();
            this.aleatorioMultiplicativo = new GeneradorMultiplicativo();
        }

        public void inicializarGrilla()
        {
            this.listaAleatoriosMultiplicativos = new List<GeneradosMultiplicativo>();
            this.grilla_multiplicativo.Rows.Clear();
        }

        private void btn_generar_aleatorios_Click(object sender, EventArgs e)
        {
            this.inicializarGrilla();

            try
            {
                aleatorioMultiplicativo.Generado.Semilla = double.Parse(this.txt_semilla.Text);
                aleatorioMultiplicativo.C = double.Parse(this.txt_c.Text);
                aleatorioMultiplicativo.A = double.Parse(this.txt_a.Text);
                aleatorioMultiplicativo.M = double.Parse(this.txt_m.Text);

                this.grilla_multiplicativo.Rows.Add(0,
                                                    this.aleatorioMultiplicativo.Generado.Semilla,
                                                    0);

                for (int i = 0; i < 20; i++)
                {
                    this.listaAleatoriosMultiplicativos.Add(this.aleatorioMultiplicativo.generarAleatorio());
                    this.grilla_multiplicativo.Rows.Add(i + 1,
                                                        this.aleatorioMultiplicativo.Generado.Semilla,
                                                        this.TruncateFunction(this.aleatorioMultiplicativo.Generado.NumAleatorio,4));
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
                this.aleatorioMultiplicativo.CalcularA(k);

                this.txt_a.Text = aleatorioMultiplicativo.A.ToString();
                this.txt_a.Enabled = false;

            }
            catch (Exception)
            {
                this.txt_a.Text = "";
                Console.Write(e.ToString());
            }

        }

        private void txt_g_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var g = double.Parse(this.txt_g.Text);
                this.aleatorioMultiplicativo.CalcularM(g);

                this.txt_m.Text = aleatorioMultiplicativo.M.ToString();
                this.txt_m.Enabled = false;
            }
            catch (Exception)
            {
                this.txt_m.Text = "";
                Console.Write(e.ToString());
            }
            
        }

        private void btn_reestablecer_panel_multiplicativo_Click(object sender, EventArgs e)
        {
            this.txt_a.Text = "";
            this.txt_c.Text = "";
            this.txt_g.Text = "";
            this.txt_k.Text = "";
            this.txt_m.Text = "";
            this.txt_semilla.Text = "";

            this.txt_a.Enabled = true;
            this.txt_m.Enabled = true;

            this.inicializarGrilla();
        }
    }
}
