using System.Security.Cryptography.X509Certificates;

namespace poo_aula1
{
    internal class Aula01
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando as aulas de POO!");

            // Instânciando a classe Pessoa.
            // Criando uma variável do tipo Pessoa.
            // ...ou seja, a partir desse momento a variável pessoa passa a ser um objeto da Classe Pessoa.
            Pessoa pessoa = new Pessoa();
            pessoa.Nome = "Rhuan";
            pessoa.Idade = 19;

            Console.WriteLine(pessoa.Nome);

            Pessoa pessoa1 = new Pessoa
            {
                Nome = "Rhuan",
                Idade = 19
            };

            Console.WriteLine(pessoa1.Idade);
        }
    }
}