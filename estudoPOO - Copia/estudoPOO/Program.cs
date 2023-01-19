using System.Reflection;
using System.Text;

namespace estudoPOO
{
    class Program
    {
        static void Main(string[] args)
        {

            ClienteVip clienteV1 = new ClienteVip();
            clienteV1.vip();

            Cliente cliente1 = new Cliente();
            cliente1.vip();

        }
    }
}