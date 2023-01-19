using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Atributos : Attribute
{
    string Nome;
    public double Versao;

    // Construtor de classe Atributos.
    public Atributos(string name)
    {
        this.Nome = name;

        // Para o campo versão eu vou setar 
    }
}
