using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Colas;
using Colas.Clientes;
using Colas.Colas;
using Colas.Servidores;
using Simulacion.Modelos.Distribuciones;

namespace Simulacion
{
    public partial class TP_5 : Form
    {
        public TP_5()
        {
            InitializeComponent();
        }

        private void btn_simular_Click(object sender, EventArgs e)
        {
            var distribucionCargaAuto = new Uniforme(1, 3);
            var distribucionCargaCamion = new Uniforme(3, 5);

            var distribucionCursoAgua = new Uniforme(55, 65);

            var colaRecepcion = new ColaFifo("Recepción de vehiculos");

            var transbordador1 = new Servidor(distribucionCargaAuto, distribucionCargaCamion, distribucionCursoAgua, colaRecepcion, "Transbordador 1", 10);
            var transbordador2 = new Servidor(distribucionCargaAuto, distribucionCargaCamion, distribucionCursoAgua, colaRecepcion, "Transbordador 2", 20);

            Distribucion distribucionLlegadas;
            Llegada llegadas;

            var horaInicio = DateTime.Today.AddHours(7);
            var horaFin = DateTime.Today.AddHours(20);

            var distribucionLlegadaAutosContinenteAIslaDe730A12 = new Uniforme(10, 20);
            var distribucionLlegadaAutosContinenteAIslaDe12A19 = new Uniforme(25, 35);
            var distribucionLlegadaCamionesContinenteAIslaDe7A11 = new Uniforme(17, 23);
            var distribucionLlegadaCamionesContinenteAIslaDe11A1930 = new Uniforme(110, 130);

            var distribucionLlegadaCamionesIslaAContinenteDe10A18 = new Uniforme(30, 90);
            var distribucionLlegadaAutosIslaAContinenteDe10A18 = new Uniforme(30, 90);

            llegadas = new Llegada(distribucionLlegadaAutosContinenteAIslaDe730A12, horaInicio, horaFin);

            var eventos = new List<Evento>
            {
                new Evento("Llegada", llegadas.ProximaLlegada),
                new Evento("Cierre", llegadas.Cierre),
                new Evento("Fin Carga Transbordador 1", transbordador1.ProximoFinCarga),
                new Evento("Fin Carga Transbordador 2", transbordador2.ProximoFinCarga),
                new Evento("Fin Curso Agua Transbordador 1", transbordador1.ProximoFinCursoAgua),
                new Evento("Fin Curso Agua Transbordador 2", transbordador2.ProximoFinCursoAgua),
                new Evento("Fin Descarga Transbordador 1", transbordador1.ProximoFinDescarga),
                new Evento("Fin Descarga Transbordador 2", transbordador2.ProximoFinDescarga),
                new Evento("Fin Descarga Transbordador 1", transbordador1.ProximoFinMantenimiento),
                new Evento("Fin Descarga Transbordador 2", transbordador2.ProximoFinMantenimiento),
            };

        }
    }
}
