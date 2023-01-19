public class Pessoa
{

    public string Nome { get; set; }
    public int AnoNascimento { get; set; }
    public int Idade { get; set; }

    public Pessoa(string nome, int anoNascimento)
    {
        Nome = nome;
        AnoNascimento = anoNascimento;

        DateTime data = DateTime.Now;
        int AnoAtual = data.Year;
        Idade = AnoAtual - AnoNascimento;

        Console.WriteLine($"{Nome} nasceu no ano {AnoNascimento}. \nCom isso concluímos que {Nome} tem {Idade} anos!");
    }

}