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
using Simulacion.Modelos.Distribuciones;

namespace Simulacion
{
    public partial class TP_3 : Form
    {
        public TP_3()
        {
            InitializeComponent();
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

        private void btn_uniforme_generar_Click(object sender, EventArgs e)
        {
            try
            {
                var a = Convert.ToDouble(txt_uniforme_a.Text);
                var b = Convert.ToDouble(txt_uniforme_b.Text);
                var cantidad = Convert.ToDouble(txt_uniforme_cantidad_variables.Text);

                var uniforme = new Uniforme();
                var lista = new List<Generado>();

                uniforme.A = a;
                uniforme.B = b;

                if (!uniforme.CompararAB())
                {
                    MessageBox.Show("A no puede ser mayor a B");
                    return;
                }

                for (int i = 0; i < cantidad; i++)
                {
                    var aleatorio = uniforme.GenerarVariableAleatoria(i + 1);
                    lista.Add(new Generado()
                    {
                        NumAleatorio = TruncateFunction(aleatorio.NumAleatorio, 4),
                        Iteracion = aleatorio.Iteracion
                    });
                }

                grilla_uniforme.DataSource = lista;
            }
            catch (Exception )
            {
                MessageBox.Show("Ingrese los valores obligatorios!!");
           
            }
        }

        private void btn_exponencial_generar_aleatorio_Click(object sender, EventArgs e)
        {
            try
            {
                var lambda = Convert.ToDouble(txt_exponencial_lambda.Text);
                var cantidad = Convert.ToDouble(txt_exponencial_cantidad_variables.Text);

                var exponencial = new Exponencial();
                var lista = new List<Generado>();

                exponencial.Lambda = lambda;

                if (!exponencial.VerificarLambda())
                {
                    MessageBox.Show("Lambda no puede ser menor a 0!!");
                    return;
                }

                for (int i = 0; i < cantidad; i++)
                {
                    var aleatorio = exponencial.GenerarVariableAleatoria(i + 1);
                    lista.Add(new Generado()
                    {
                        NumAleatorio = TruncateFunction(aleatorio.NumAleatorio, 4),
                        Iteracion = aleatorio.Iteracion
                    });
                }

                grilla_exponencial.DataSource = lista;
            }
            catch (Exception )
            {
                MessageBox.Show("Ingrese los valores obligatorios!!");
            }
        }

        private void btn_exponencial_generar_variables_Click(object sender, EventArgs e)
        {
            try
            {
                var media = Convert.ToDouble(txt_normal_media.Text);
                var desviacion = Convert.ToDouble(txt_normal_desviacion.Text);
                var cantidad = Convert.ToInt16(txt_normal_cantidad_variables.Text);

                var normal = new Normal();
                var lista = new List<Generado>();

                normal.Media = media;
                normal.DesviacionEstandar = desviacion;

                if (!normal.VerificarDesviacion())
                {
                    MessageBox.Show("La desviacion estandar tiene que ser mayor a 0!!!");
                    return;
                }

                if (!normal.VerificarMedia())
                {
                    MessageBox.Show("La media debe ser mayor a 0!!");
                    return;
                }

                for (int i = 0; i < cantidad; i++)
                {
                    var aleatorio = normal.GenerarVariableAleatoria(i + 1);
                    lista.Add(new Generado()
                    {
                        NumAleatorio = TruncateFunction(aleatorio.NumAleatorio, 4),
                        Iteracion = aleatorio.Iteracion
                    });
                }

                grilla_normal.DataSource = lista;
            }
            catch (Exception )
            {
                MessageBox.Show("Ingrese los valores obligatorios!!");
               
            }
        }

        private void btn_poisson_generar_aleatorios_Click(object sender, EventArgs e)
        {
            try
            {
                var lambda = Convert.ToDouble(txt_poisson_lambda.Text);
                var cantidad = Convert.ToInt16(txt_poisson_cantidad_variables.Text);

                var poisson = new Poisson();
                var lista = new List<Generado>();

                poisson.Lambda= lambda;
                
                if (!poisson.VerificarLambda())
                {
                    MessageBox.Show("Lambda tiene que ser mayor a 0!!!");
                    return;
                }

                var cantidadGenerados = 0;

                do
                {
                    var aleatorio = poisson.GenerarVariableAleatoria(cantidadGenerados + 1);

                    cantidadGenerados++;

                    lista.Add(new Generado()
                    {
                        NumAleatorio = aleatorio.NumAleatorio,
                        Iteracion = cantidadGenerados
                    });

                } while (cantidadGenerados != cantidad);

                   
                grilla_poisson.DataSource = lista;
            }
            catch (Exception)
            {
                MessageBox.Show("Ingrese los valores obligatorios!!");

            }
        }
    }
}