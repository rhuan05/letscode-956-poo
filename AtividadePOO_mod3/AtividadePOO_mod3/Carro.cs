using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtividadePOO_mod3
{
    public class Carro
    {

        public string cor;
        public string marca;
        public string modelo;
        public float capacidadeDoTanque;
        public string tipoDeGasolina;

        public float gasolinaNoTanque;
        public float litrosComprados;

        public void Abastecer(string tipoGasolina, float capacidadeDoTanque)
        {
            if(gasolinaNoTanque + litrosComprados >= capacidadeDoTanque)
            {
                Console.WriteLine("Seu tanque não suporta essa quantidade de gasolina.");
            }

            if(tipoDeGasolina == "Etanol")
            {
                gasolinaNoTanque = gasolinaNoTanque + litrosComprados;
                Console.WriteLine($"Preço final: R${4.16 * litrosComprados}");
            }

            if(tipoDeGasolina == "Gasolina")
            {
                gasolinaNoTanque = gasolinaNoTanque + litrosComprados;
                Console.WriteLine($"Preço final: R${5.62 * litrosComprados}");
            }

        }

    }
}
