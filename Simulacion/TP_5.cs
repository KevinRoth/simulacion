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
        private bool _cancelar;

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

            var transbordador1 = new Servidor(distribucionCargaAuto, distribucionCargaCamion, distribucionCursoAgua,
                colaRecepcion, "Transbordador 1", 10);
            var transbordador2 = new Servidor(distribucionCargaAuto, distribucionCargaCamion, distribucionCursoAgua,
                colaRecepcion, "Transbordador 2", 20);

            Llegada llegadasContinente;
            Llegada llegadasIsla;

            var horaInicio = DateTime.Today.AddHours(7);
            var horaFin = DateTime.Today.AddHours(20);

            var distribucionLlegadaAutosContinenteAIslaDe730A12 = new Uniforme(10, 20);
            var distribucionLlegadaAutosContinenteAIslaDe12A19 = new Uniforme(25, 35);
            var distribucionLlegadaCamionesContinenteAIslaDe7A11 = new Uniforme(17, 23);
            var distribucionLlegadaCamionesContinenteAIslaDe11A1930 = new Uniforme(110, 130);

            var distribucionLlegadaCamionesIslaAContinenteDe10A18 = new Uniforme(30, 90);
            var distribucionLlegadaAutosIslaAContinenteDe10A18 = new Uniforme(30, 90);

            var dias = int.Parse(txt_dias.Text);
            var desde = int.Parse(txt_desde.Text);
            var hasta = int.Parse(txt_hasta.Text);

            decimal promedioAtendidosAutosEnContinentePorDia = 0;
            decimal promedioAtendidosCamionesEnContinentePorDia = 0;
            decimal promedioAtendidosAutosEnIslaPorDia = 0;
            decimal promedioAtendidosCamionesEnIslaPorDia = 0;
            int colaMaximaIsla = 0;
            int colaMaximaContinente = 0;
            decimal promedioNoAtendidosVehiculosPorDia = 0;

            var colaEnIsla = new List<Cliente>();
            var colaEnContinente = new List<Cliente>();
            var simulacion = 0;

            var clientes = new List<Cliente>();

            _cancelar = false;

            llegadasContinente = new Llegada(distribucionLlegadaAutosContinenteAIslaDe730A12, horaInicio, horaFin);
            llegadasIsla = new Llegada(distribucionLlegadaAutosIslaAContinenteDe10A18, horaInicio, horaFin);

            var esMantenido1 = false;
            var esMantenido2 = false;

            var mantenimiento = 0;

            for (var dia = 1; dia < dias; dia++)
            {
                if (_cancelar) break;

                mantenimiento = dia;

                llegadasContinente.Abrir();
                llegadasIsla.Abrir();

                while (llegadasContinente.EstaAbierto() ||
                       llegadasIsla.EstaAbierto() ||
                       transbordador1.EstaLibre() ||
                       transbordador2.EstaLibre())
                {
                    simulacion++;

                    llegadasContinente.ActualizarLlegada();
                    llegadasIsla.ActualizarLlegada();


                    var eventos = new List<Evento>
                    {
                        new Evento("Llegada Continente", llegadasContinente.ProximaLlegada),
                        new Evento("Llegada Isla", llegadasIsla.ProximaLlegada),
                        new Evento("Cierre", llegadasContinente.Cierre),
                        new Evento("Fin Carga Transbordador 1", transbordador1.ProximoFinCarga),
                        new Evento("Fin Carga Transbordador 2", transbordador2.ProximoFinCarga),
                        new Evento("Fin Curso Agua Transbordador 1", transbordador1.ProximoFinCursoAgua),
                        new Evento("Fin Curso Agua Transbordador 2", transbordador2.ProximoFinCursoAgua),
                        new Evento("Fin Descarga Transbordador 1", transbordador1.ProximoFinDescarga),
                        new Evento("Fin Descarga Transbordador 2", transbordador2.ProximoFinDescarga),
                        new Evento("Fin Mantenimiento Transbordador 1", transbordador1.ProximoFinMantenimiento),
                        new Evento("Fin Mantenimiento Transbordador 2", transbordador2.ProximoFinMantenimiento),
                    };

                    var relojActual = eventos.Where(ev => ev.Hora.HasValue).Min(ev => ev.Hora).Value;
                    var eventoActual = eventos.First(ev => ev.Hora.Equals(relojActual)).Nombre;

                    if (mantenimiento % 5 == 0)
                    {
                        if (!esMantenido1)
                        {
                            esMantenido1 = true;
                            transbordador1.SetMantenimiento(relojActual);
                        }
                        else
                        {
                            esMantenido1 = false;
                            transbordador2.SetMantenimiento(relojActual);
                        }
                    }

                    switch (eventoActual)
                    {
                        case "Llegada Continente":
                            Cliente clienteContinente = new Cliente(simulacion.ToString(), ObtenerTipoVehiculo());

                            if (colaEnContinente.Count == 0)
                            {
                                if ((transbordador1.EstaLibre() && !transbordador1.EstaLleno() &&
                                     transbordador1.EstaEnContinente()) ||
                                    (transbordador2.EstaLibre() && !transbordador2.EstaLleno() &&
                                     transbordador2.EstaEnContinente()))
                                {
                                    if (transbordador1.EstaLibre())
                                    {
                                        colaEnContinente.First().TipoCliente = ObtenerTipoVehiculo();
                                        transbordador1.ActualizarFinCarga(relojActual, colaEnContinente.First());
                                    }
                                    else
                                    {
                                        colaEnContinente.First().TipoCliente = ObtenerTipoVehiculo();
                                        transbordador2.ActualizarFinCarga(relojActual,
                                            colaEnContinente.First());
                                    }

                                    colaEnContinente.RemoveAt(0);
                                }
                                else
                                {
                                    colaEnContinente.Add(clienteContinente);
                                }
                            }
                            else
                            {
                                colaEnContinente.Add(clienteContinente);
                            }
                        
                            CargarGrilla(relojActual.ToString("HH:mm:ss"), eventoActual, dia.ToString(),transbordador1.Estado, transbordador2.Estado, 
                                transbordador1.Ubicacion, transbordador2.Ubicacion, colaEnContinente.First().TipoCliente, (llegadasContinente.ProximaLlegada - relojActual).Value.ToString("HH:mm:ss"),llegadasContinente.ProximaLlegada.Value.ToString("HH:mm:ss"),
                                colaEnContinente.Count.ToString(), 
                                (transbordador1.ProximoFinCarga - relojActual).Value.ToString("HH:mm:ss"), transbordador1.ProximoFinCarga.Value.ToString("HH:mm:ss"), 
                                transbordador1.VehiculosABordo.Where(vehiculo => vehiculo.TipoCliente == "Auto").ToList().Count.ToString(),
                                transbordador1.VehiculosABordo.Where(vehiculo => vehiculo.TipoCliente == "Camion").ToList().Count.ToString(),
                                string.Empty,string.Empty,string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 
                                string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty,
                                string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 
                                string.Empty, string.Empty, string.Empty, string.Empty);

                            break;

                        case "Llegada Isla":
                            Cliente clienteIsla = new Cliente(simulacion.ToString(), ObtenerTipoVehiculo());

                            if (colaEnIsla.Count == 0)
                            {
                                if ((transbordador1.EstaLibre() && !transbordador1.EstaLleno() &&
                                     !transbordador1.EstaEnContinente()) ||
                                    (transbordador2.EstaLibre() && !transbordador2.EstaLleno() &&
                                     !transbordador2.EstaEnContinente()))
                                {
                                    if (transbordador1.EstaLibre())
                                    {
                                        colaEnIsla.First().TipoCliente = ObtenerTipoVehiculo();
                                        transbordador1.ActualizarFinCarga(relojActual,
                                            colaEnIsla.First());
                                    }
                                    else
                                    {
                                        colaEnIsla.First().TipoCliente = ObtenerTipoVehiculo();
                                        transbordador2.ActualizarFinCarga(relojActual,
                                            colaEnIsla.First());
                                    }

                                    colaEnIsla.RemoveAt(0);
                                }
                                else
                                {
                                    colaEnIsla.Add(clienteIsla);
                                }
                            }
                            else
                            {
                                colaEnIsla.Add(clienteIsla);
                            }

                            break;

                        case "Cierre":
                            llegadasContinente.Cerrar();
                            llegadasIsla.Cerrar();


                            break;

                        case "Fin Carga Transbordador 1":
                            if (transbordador1.EstaEnContinente())
                            {
                                if (colaEnContinente.Count > 0 && !transbordador1.EstaLleno())
                                {
                                    colaEnContinente.First().TipoCliente = ObtenerTipoVehiculo();
                                    transbordador1.ActualizarFinCarga(relojActual,
                                        colaEnContinente.First());

                                    colaEnContinente.RemoveAt(0);
                                }

                                if (transbordador1.EstaLleno())
                                {
                                    transbordador1.SetEnCursoAgua(relojActual);
                                }
                            }
                            else //esta en isla
                            {
                                if (colaEnIsla.Count > 0)
                                {
                                    colaEnIsla.First().TipoCliente = ObtenerTipoVehiculo();
                                    transbordador1.ActualizarFinCarga(relojActual,
                                        colaEnIsla.First());

                                    colaEnIsla.RemoveAt(0);
                                }

                                if (transbordador1.EstaLleno())
                                {
                                    transbordador1.SetEnCursoAgua(relojActual);
                                }
                            }

                            break;

                        case "Fin Carga Transbordador 2":

                            if (transbordador2.EstaEnContinente())
                            {
                                if (colaEnContinente.Count > 0 && !transbordador2.EstaLleno())
                                {
                                    colaEnContinente.First().TipoCliente = ObtenerTipoVehiculo();
                                    transbordador2.ActualizarFinCarga(relojActual,
                                        colaEnContinente.First());

                                    colaEnContinente.RemoveAt(0);
                                }

                                if (transbordador2.EstaLleno())
                                {
                                    transbordador2.SetEnCursoAgua(relojActual);
                                }
                            }
                            else //esta en isla
                            {
                                if (colaEnIsla.Count > 0)
                                {
                                    colaEnIsla.First().TipoCliente = ObtenerTipoVehiculo();
                                    transbordador2.ActualizarFinCarga(relojActual,
                                        colaEnIsla.First());

                                    colaEnIsla.RemoveAt(0);
                                }

                                if (transbordador2.EstaLleno())
                                {
                                    transbordador2.SetEnCursoAgua(relojActual);
                                }
                            }

                            break;

                        case "Fin Curso Agua Transbordador 1":

                            transbordador1.SetDescargaVehiculos();

                            if (transbordador1.VehiculosABordo.Count > 0)
                            {
                                transbordador1.ProximoFinDescarga = new DateTime(
                                    long.Parse((transbordador1.VehiculosABordo.First().TiempoCarga / 2).ToString()));
                                transbordador1.VehiculosABordo.RemoveAt(0);
                            }

                            break;

                        case "Fin Curso Agua Transbordador 2":
                            transbordador2.SetDescargaVehiculos();

                            if (transbordador2.VehiculosABordo.Count > 0)
                            {
                                transbordador2.ProximoFinDescarga = new DateTime(
                                    long.Parse((transbordador2.VehiculosABordo.First().TiempoCarga / 2).ToString()));
                                transbordador2.VehiculosABordo.RemoveAt(0);
                            }

                            break;

                        case "Fin Descarga Transbordador 1":

                            if (transbordador1.VehiculosABordo.Count > 0)
                            {
                                transbordador1.ProximoFinDescarga = new DateTime(
                                    long.Parse((transbordador1.VehiculosABordo.First().TiempoCarga / 2).ToString()));
                                transbordador1.VehiculosABordo.RemoveAt(0);
                            }
                            else
                            {
                                transbordador1.SetLibre();
                            }

                            break;

                        case "Fin Descarga Transbordador 2":
                            if (transbordador2.VehiculosABordo.Count > 0)
                            {
                                transbordador2.ProximoFinDescarga = new DateTime(
                                    long.Parse((transbordador2.VehiculosABordo.First().TiempoCarga / 2).ToString()));
                                transbordador2.VehiculosABordo.RemoveAt(0);
                            }
                            else
                            {
                                transbordador2.SetLibre();
                            }

                            break;

                        case "Fin Mantenimiento Transbordador 1":
                            if (colaEnContinente.Count > 0)
                            {
                                colaEnContinente.First().TipoCliente = ObtenerTipoVehiculo();
                                transbordador1.ActualizarFinCarga(relojActual,
                                    colaEnContinente.First());

                                colaEnContinente.RemoveAt(0);
                            }

                            break;

                        case "Fin Mantenimiento Transbordador 2":
                            if (colaEnContinente.Count > 0)
                            {
                                colaEnContinente.First().TipoCliente = ObtenerTipoVehiculo();
                                transbordador2.ActualizarFinCarga(relojActual,
                                    colaEnContinente.First());

                                colaEnContinente.RemoveAt(0);
                            }

                            break;
                    }
                }
            }
        }

        public void CargarGrilla(string reloj, string evento, string dia, string estadoT1, string estadoT2,
            string lugarT1, string lugarT2, string tipoVehiculo, string horaLlegada, string proximaLlegada,
            string colaEspera, string horaCarga, string proximoFinCarga, string autoSubidoT1, string camionSubidoT1,
            string autoSubidoT2, string camionSubidoT2, string cruceAguaT1, string llegadaCruceAguaT1,
            string cruceAguaT2,
            string llegadaCruceAguaT2, string horaDescargaT1, string finDescargaT1, string horaDescargaT2,
            string finDescargaT2,
            string autoSubidoT1Descarga, string camionSubidoT1Descarga, string autoSubidoT2Descarga,
            string camionSubidoT2Descarga,
            string mantencionT1, string inicioT1, string finT1, string mantencionT2, string inicioT2, string finT2,
            string colaMaxima,
            string sumatoriaAutoT1, string sumatoriaCamionT1, string sumatoriaAutoT2, string sumatoriaCamionT2)

        {
            dgv_simulacion.Rows.Add(reloj, evento, dia, estadoT1, estadoT2, lugarT1, lugarT2, tipoVehiculo, horaLlegada,
                proximaLlegada,
                colaEspera, horaCarga, proximoFinCarga, autoSubidoT1, camionSubidoT1,
                autoSubidoT2, camionSubidoT2, cruceAguaT1, llegadaCruceAguaT1, cruceAguaT2,
                llegadaCruceAguaT2, horaDescargaT1, finDescargaT1, horaDescargaT2, finDescargaT2,
                autoSubidoT1Descarga, camionSubidoT1Descarga, autoSubidoT2Descarga, camionSubidoT2Descarga,
                mantencionT1, inicioT1, finT1, mantencionT2, inicioT2, finT2, colaMaxima,
                sumatoriaAutoT1, sumatoriaCamionT1, sumatoriaAutoT2, sumatoriaCamionT2);
        }

        public string ObtenerTipoVehiculo()
        {
            var random = new Random().NextDouble();

            if (random < 0.5)
            {
                return "Auto";
            }
            else
            {
                return "Camion";
            }
        }
    }
}