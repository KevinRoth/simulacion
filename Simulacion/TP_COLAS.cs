using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Simulacion.Modelos.Distribuciones;
using Simulacion.Modelos_Colas_2;

namespace Simulacion
{
    public partial class TP_COLAS : Form
    {
        public TP_COLAS()
        {
            InitializeComponent();
        }

        private void btn_simular_Click(object sender, EventArgs e)
        {
            var distribucionLlegadaAutosContinenteAIslaDe730A12 = new Uniforme(10, 20);
            var distribucionLlegadaAutosContinenteAIslaDe12A19 = new Uniforme(25, 35);
            var distribucionLlegadaCamionesContinenteAIslaDe7A11 = new Uniforme(17, 23);
            var distribucionLlegadaCamionesContinenteAIslaDe11A1930 = new Uniforme(110, 130);

            var distribucionLlegadaCamionesIslaAContinenteDe10A18 = new Uniforme(30, 90);
            var distribucionLlegadaAutosIslaAContinenteDe10A18 = new Uniforme(7, 17);

            var distribucionCargaAuto = new Uniforme(1, 3);
            var distribucionCargaCamion = new Uniforme(3, 5);

            var horaInicio = DateTime.Today.AddHours(7);
            var horaFin = DateTime.Today.AddHours(20);

            var llegadas = new Llegada(distribucionLlegadaAutosContinenteAIslaDe730A12,
                distribucionLlegadaAutosIslaAContinenteDe10A18, distribucionLlegadaCamionesContinenteAIslaDe7A11,
                distribucionLlegadaCamionesIslaAContinenteDe10A18, horaInicio, horaFin);

            var transbordador1 = new Transbordador("Continente", distribucionCargaAuto, distribucionCargaCamion, 10);
            var transbordador2 = new Transbordador("Continente", distribucionCargaAuto, distribucionCargaCamion, 20);

            var dias = int.Parse(txt_dias.Text);
            var desde = int.Parse(txt_desde.Text);
            var hasta = int.Parse(txt_hasta.Text);

            var colaVehiculosContinente = new List<Vehiculo>();
            var colaVehiculosIsla = new List<Vehiculo>();

            Random random = new Random();

            for (var dia = 1; dia <= dias; dia++)
            {
                var reloj = horaInicio;

                //  while (llegadas.EstaAbierto(reloj) ||
                //       !llegadas.EstaCerrado(reloj))
                //{
                llegadas.ObtenerLlegadaVehiculo("Auto", "Continente", reloj, random.NextDouble());
                var llegadaAutoC = llegadas.LlegadaActual;
                colaVehiculosContinente.Add(llegadaAutoC.Vehiculo);

                llegadas.ObtenerLlegadaVehiculo("Camion", "Continente", reloj, random.NextDouble());
                var llegadaCamionC = llegadas.LlegadaActual;
                colaVehiculosContinente.Add(llegadaCamionC.Vehiculo);

                llegadas.ObtenerLlegadaVehiculo("Auto", "Isla", reloj, random.NextDouble());
                var llegadaAutoI = llegadas.LlegadaActual;
                colaVehiculosIsla.Add(llegadaAutoI.Vehiculo);

                llegadas.ObtenerLlegadaVehiculo("Camion", "Isla", reloj, random.NextDouble());
                var llegadaCamionI = llegadas.LlegadaActual;
                colaVehiculosIsla.Add(llegadaCamionI.Vehiculo);

                GuardarEnGrilla(dia, reloj, llegadaAutoC, llegadaCamionC, llegadaAutoI, llegadaCamionI);

                if (transbordador1.Ubicacion == "Continente")
                {
                    if (transbordador1.EstaLibre() && transbordador1.Vehiculos.Count + colaVehiculosContinente.First().Tamanio <= 10)
                    {
                        transbordador1.CargarVehiculo(colaVehiculosContinente.First());
                    }
                    else
                    {
                        
                    }
                }
                else
                {

                }
            
                if (transbordador2.Ubicacion == "Continente")
                {

                }
                else
                {

                }



                // }
            }
        }

        private void GuardarEnGrilla(int dia, DateTime reloj, Llegada llegadaAutoC, Llegada llegadaCamionC,
            Llegada llegadaAutoI, Llegada llegadaCamionI)
        {
            dgv_simulaciones.Rows.Add(
                dia,
                reloj.ToString("HH:mm:ss"),
                llegadaAutoC.ObtenerEvento(),
                TruncateFunction(llegadaAutoC.RandomLlegada, 3),
                llegadaAutoC.TiempoEntreLlegadas.ToString("HH:mm:ss"),
                llegadaAutoC.ProximaLlegada.ToString("HH:mm:ss"),
                TruncateFunction(llegadaCamionC.RandomLlegada, 3),
                llegadaCamionC.TiempoEntreLlegadas.ToString("HH:mm:ss"),
                llegadaCamionC.ProximaLlegada.ToString("HH:mm:ss"),
                TruncateFunction(llegadaAutoI.RandomLlegada, 2),
                llegadaAutoI.TiempoEntreLlegadas.ToString("HH:mm:ss"),
                llegadaAutoI.ProximaLlegada.ToString("HH:mm:ss"),
                TruncateFunction(llegadaCamionI.RandomLlegada, 2),
                llegadaCamionI.TiempoEntreLlegadas.ToString("HH:mm:ss"),
                llegadaCamionI.ProximaLlegada.ToString("HH:mm:ss")
            );

            Application.DoEvents();
        }

        public double TruncateFunction(double number, int digits)
        {
            double stepper = (double) (Math.Pow(10.0, (double) digits));
            int temp = (int) (stepper * number);
            return (double) temp / stepper;
        }
    }
}