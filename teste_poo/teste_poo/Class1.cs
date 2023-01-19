using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ModificadoresDeAcesso
{

    private int Idade { get; set; }
    public string Nome { get; set; }
    protected double Salario { get; set; }
    private int AnoNascimento { get; set; }

    // Adicionando salário (que é uma propriedade protegida/protected), onde somente quem poderá ter acesso a propriedade é a classe criadora ou a que herdar.

    public string AdicionaSalario(double valor)
    {
        Salario = valor;
        return "Valor adicionado!";
    }

    // Adicionando salário (que é um propriedade protegida/protected), onde somente quem poderá ter acessoa a propriedade é a classe criadora.
    
    public void InsereAnoNascimento(int anoRecebido)
    {
        Console.WriteLine("Ano nascimento recebido...");
        // Atribuindo valor a propriedade privada.
        this.AnoNascimento = anoRecebido;
        // Visualizando a propriedade privada.
        Console.WriteLine("Ano nascimento alterado: " + this.AnoNascimento + ".");
    }

    static string MetodoEstatico()
    {
        return "Executando o método estático.";
    }

}
