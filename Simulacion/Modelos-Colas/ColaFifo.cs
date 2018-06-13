using System.Collections.Generic;
using System.Linq;
using Colas.Clientes;

namespace Colas.Colas
{
    public class ColaFifo : ICola
    {
        public List<Cliente> Clientes = new List<Cliente>();

        public ColaFifo(string nombre)
        {
            Nombre = nombre;
        }

        public bool Vacia()
        {
            return Clientes.Count == 0;
        }

        public void AgregarCliente(Cliente cliente)
        {
            Clientes.Add(cliente);
        }

        public Cliente ProximoCliente()
        {
            if (Vacia())
                return null;

            var cliente = Clientes.First();
            Clientes.Remove(cliente);
            return cliente;
        }

        public int Cantidad()
        {
            return Clientes.Count;
        }

        public void Vaciar()
        {
            Clientes.Clear();
        }

        public string Nombre { get; protected set; }
    }
}
