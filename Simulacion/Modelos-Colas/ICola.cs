using Colas.Clientes;

namespace Colas.Colas
{
    public interface ICola
    {
        bool Vacia();
        void AgregarCliente(Cliente cliente);
        Cliente ProximoCliente();
        int Cantidad();
        void Vaciar();
    }
}
