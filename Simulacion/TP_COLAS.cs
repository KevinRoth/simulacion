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
            var distribucionLlegadaAutosIslaAContinenteDe10A18 = new Uniforme(30, 90);

            var distribucionCargaAuto = new Uniforme(1, 3);
            var distribucionCargaCamion = new Uniforme(3, 5);

            var horaInicio = DateTime.Today.AddHours(7);
            var horaFin = DateTime.Today.AddHours(20);

            var llegadas = new Llegada(distribucionLlegadaAutosContinenteAIslaDe730A12,
                distribucionLlegadaAutosIslaAContinenteDe10A18, distribucionLlegadaCamionesContinenteAIslaDe7A11,
                distribucionLlegadaCamionesIslaAContinenteDe10A18, horaInicio, horaFin);

            var dias = int.Parse(txt_dias.Text);
            var desde = int.Parse(txt_desde.Text);
            var hasta = int.Parse(txt_hasta.Text);

            for (var dia = 1; dia <= dias; dia++)
            {
                var reloj = horaInicio;

                //  while (llegadas.EstaAbierto(reloj) ||
                //       !llegadas.EstaCerrado(reloj))
                //{
                var llegadaAutoC = llegadas.ObtenerLlegadaVehiculo("Auto", "Continente", reloj);

                var llegadaCamionC = llegadas.ObtenerLlegadaVehiculo("Camion", "Continente", reloj);

                var llegadaAutoI = llegadas.ObtenerLlegadaVehiculo("Auto", "Isla", reloj);

                var llegadaCamionI = llegadas.ObtenerLlegadaVehiculo("Camion", "Isla", reloj);

                GuardarEnGrilla(dia, reloj, llegadaAutoC, llegadaCamionC, llegadaAutoI, llegadaCamionI);

                horaInicio.AddHours(14);
                // }
            }
        }

        private void GuardarEnGrilla(int dia, DateTime reloj, Llegada llegadaAutoC, Llegada llegadaCamionC,
            Llegada llegadaAutoI, Llegada llegadaCamionI)
        {
            dgv_simulaciones.Rows.Add(reloj, dia, llegadaAutoC.ObtenerEvento(), llegadaAutoC.RandomLlegada,
                llegadaAutoC.TiempoEntreLlegadas, llegadaAutoC.ProximaLlegada,
                llegadaCamionC.RandomLlegada, llegadaCamionC.TiempoEntreLlegadas, llegadaCamionC.ProximaLlegada,
                llegadaAutoI.RandomLlegada, llegadaAutoI.TiempoEntreLlegadas, llegadaAutoI.ProximaLlegada,
                llegadaCamionI.RandomLlegada, llegadaCamionI.TiempoEntreLlegadas, llegadaCamionI.ProximaLlegada
            );

            Application.DoEvents();
        }
    }
}