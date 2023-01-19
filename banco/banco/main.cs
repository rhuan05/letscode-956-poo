using System;
using System.Collections.Generic;
using System.Threading;

class Banco
{
    //Armazena as contas criadas pelo usuário independentemente do tipo
    static List<Conta> listaContas = new List<Conta>();
    //Armazena as contas salarios criadas, contas que nao sao salario o indice armazena valor nulo.
    static List<ContaSalario> listaContaSalario = new List<ContaSalario>();

    public static void Main(string[] args)
    {
        string opcaoDoUsuario = ObterOpcaoDoUsuario();

        while (opcaoDoUsuario.ToUpper() != "E")
        {
            switch (opcaoDoUsuario)
            {
                case "1":
                    CadastrarConta();
                    break;
                case "2":
                    ListarContas();
                    break;
                case "3":
                    Transferir();
                    break;
                case "4":
                    Sacar();
                    break;
                case "5":
                    Depositar();
                    break;
                case "6":
                    VerExtrato();
                    break;
                case "C":
                    Console.Clear();
                    break;
                case "E":
                    return;

                default:
                    throw new ArgumentOutOfRangeException();
            }
            opcaoDoUsuario = ObterOpcaoDoUsuario();
        }

        Console.WriteLine("Obrigado(a) por utilizar nossos serviços, até breve!!");
        Console.ReadLine();
    }

    public static void CadastrarConta()
    {
        Console.Clear();
        Console.WriteLine("Cadastrar nova conta");

        Console.Write("Digite 1 para Conta Poupança | 2 para Conta Salário | 3 para Conta Investimento : ");
        int entradaTipoConta = int.Parse(Console.ReadLine());

        Console.Write("Digite o número da conta: ");
        double entradaNumeroConta = double.Parse(Console.ReadLine());

        Console.Write("Digite o saldo inicial da conta: ");
        double entradaSaldo = double.Parse(Console.ReadLine());

        Console.Write("Digite o nome do titular da conta: ");
        string entradaNome = Console.ReadLine();

        Console.Write("Digite o CPF do titular da conta: ");
        string entradaCpf = Console.ReadLine();

        Console.Write("Digite a data de nascimento do titular da conta: ");
        string entradaDataNascimento = Console.ReadLine();

        //Seleciona o construtor referente ao tipo de conta especificado pelo usuário.
        switch (entradaTipoConta)

        {
            //Construtor da classe ContaPoupança com os parametros próprios da classe.
            case 1:
                Console.Write("Entre com o saldo mínimo:");
                decimal entradaSaldoMinimo = decimal.Parse(Console.ReadLine());

                ContaPoupanca novaContaPoupanca = new ContaPoupanca(tipoConta: (TipoConta)entradaTipoConta,
                                                                    numeroConta: entradaNumeroConta,
                                                                    saldo: entradaSaldo,
                                                                    nome: entradaNome,
                                                                    cpf: entradaCpf,
                                                                    dataNascimento: entradaDataNascimento,
                                                                    saldoMinimo: entradaSaldoMinimo);

                listaContaSalario.Add(null); // se a conta criada nao é salario, adiciona nulo na lista de contas salarios
                listaContas.Add(novaContaPoupanca);
                Console.WriteLine("Criando conta...");
                Thread.Sleep(2000);
                Console.Clear();
                Console.WriteLine("Conta poupança criada.");
                Console.WriteLine("Aperte qualquer tecla para voltar ao menu");
                Console.ReadKey();

                break;

            //Construtor da classe ContaSalario com os parametros próprios da classe.
            case 2:

                Console.Write("Digite o nome da empresa:");
                string nomeEmpresa = Console.ReadLine();

                Console.Write("Digite o CNPJ:");
                int entradaCNPJ = int.Parse(Console.ReadLine());

                Console.Write("Digite o salário:");
                double entradaSalario = double.Parse(Console.ReadLine());

                ContaSalario novaContaSalario = new ContaSalario(tipoConta: (TipoConta)entradaTipoConta,
                                                                              numeroConta: entradaNumeroConta,
                                                                              saldo: entradaSaldo,
                                                                              nome: entradaNome,
                                                                              cpf: entradaCpf,
                                                                              dataNascimento: entradaDataNascimento,
                                                                              nomeEmpresa: nomeEmpresa,
                                                                              cnpj: entradaCNPJ,
                                                                              salario: entradaSalario);

                //verifica se a propriedade CNPJ está zerada a fim de validar as informações do holerite no
                //construtor da classe, caso inválido, o objeto não é salvo.
                if (novaContaSalario.CNPJPagador == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Não foi possível criar a conta por divergência entre os dados fornecidos e o holerite\n" +
                    "Pressione qualquer tecla para continuar");
                    Console.ReadKey();
                    break;
                }
                listaContaSalario.Add(novaContaSalario);
                listaContas.Add(novaContaSalario);
                Console.WriteLine("Criando conta...");
                Thread.Sleep(2000);
                Console.Clear();
                Console.WriteLine("Conta salário criada.");
                Console.WriteLine("Aperte qualquer tecla para voltar ao menu");
                Console.ReadKey();
                break;

            //Construtor da classe ContaInvestimento com os parametros próprios da classe.
            case 3:
                ContaInvestimento novaContaInvestidor = new ContaInvestimento(tipoConta: (TipoConta)entradaTipoConta,
                                                                              numeroConta: entradaNumeroConta,
                                                                              saldo: entradaSaldo,
                                                                              nome: entradaNome,
                                                                              cpf: entradaCpf,
                                                                              dataNascimento: entradaDataNascimento);

                string perfilInvestidor = novaContaInvestidor.SimulaPerfilInvestidor();

                Console.WriteLine($"Seu perfil de investidor é {perfilInvestidor}");

                listaContaSalario.Add(null); // se a conta criada nao é salario, adiciona nulo na lista de contas salarios
                listaContas.Add(novaContaInvestidor);
                Console.WriteLine("Criando conta...");
                Thread.Sleep(2000);
                Console.Clear();
                Console.WriteLine("Conta salário criada.");
                Console.WriteLine("Aperte qualquer tecla para voltar ao menu");
                Console.ReadKey();

                break;
        }

    }

    private static void ListarContas()
    {
        if (listaContas.Count == 0)
        {
            Console.Clear();
            Console.WriteLine("Não há contas abertas");
            Thread.Sleep(3000);
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Listar contas");
            Console.WriteLine();
        }

        if (listaContas.Count == 0)
        {
            Console.WriteLine("Nenhuma conta encontrada.");
            Console.WriteLine();
            return;
        }

        //Percorre a lista de contas criadas exibindo o ID da conta (criado no momento que ela é adicionada na List), nome do titular, numero da conta e tipo da conta
        for (int i = 0; i < listaContas.Count; i++)
        {
            Conta conta = listaContas[i];
            Console.WriteLine($"ID da conta: #{i} - Titular: {conta.Nome} - Número da conta: {conta.NumeroConta} Tipo da Conta: {conta.TipoConta}");
        }
        Console.WriteLine();
        Console.WriteLine("Aperte qualquer tecla para voltar ao menu");
        Console.ReadKey();
    }

    //Esse método passamos os IDs da conta que queremos Sacar e o valor a ser sacado, ele identifica esse ID dentro da List de contas criadas, com isso ele chama o método SacarDinheiro da classe Conta
    private static void Transferir()
    {
        Console.Write("Digite o ID da conta de destino: ");
        int indiceContaDestino = int.Parse(Console.ReadLine());

        Console.Write("Digite o ID da conta de origem: ");
        int indiceContaOrigem = int.Parse(Console.ReadLine());

        Console.Write("Digite a quantia a ser transferida: ");
        double valorTransferencia = double.Parse(Console.ReadLine());

        listaContas[indiceContaOrigem].TransferirDinheiro(valorTransferencia, listaContas[indiceContaDestino]);

        Console.WriteLine();
        Console.WriteLine("Aperte qualquer tecla para voltar ao menu");
        Console.ReadKey();
    }

    //Esse método passamos o ID das contas que queremos tirar o dinheiro e o da conta que queremos enviar o dineiro, ele identifica esses IDs dentro da List de contas criadas, com isso ele chama o método TransferirDinheiro da classe Conta
    private static void Sacar()
    {
        Console.Write("Digite o ID da conta: ");
        int indiceConta = int.Parse(Console.ReadLine());

        Console.Write("Digite a quantia a ser sacada: ");
        double valorSaque = double.Parse(Console.ReadLine());

        listaContas[indiceConta].SacarDinheiro(valorSaque);

        Console.WriteLine();
        Console.WriteLine("Aperte qualquer tecla para voltar ao menu");
        Console.ReadKey();
    }

    //Esse método passamos o ID da conta que queremos depositar e o valor a ser depositado, ele identifica esse ID dentro da List de contas criadas, com isso ele chama o método DepositarDinheiro da classe Conta
    private static void Depositar()
    {
        Console.Write("Digite o ID da conta: ");
        int indiceConta = int.Parse(Console.ReadLine());

        double valorDeposito;
        //valida se o tipo de conta é salario para alterar o deposito para deposito de salario(conta salario só se pode depositar o salario)
        TipoConta tipoDeConta = listaContas[indiceConta].TipoConta;
        if (tipoDeConta == TipoConta.ContaSalario)
        {
            Console.Clear();
            Console.WriteLine("Depósito em conta Salário selecionado");
            Console.WriteLine("Digite o número do seu CNPJ (apenas números): ");
            int cnpj = int.Parse(Console.ReadLine());
            //chama o metodo depositar salario na classe conta salario e passa os paramentros
            listaContaSalario[indiceConta].DepositarSalario(listaContaSalario[indiceConta].Salario, indiceConta, cnpj);
        }
        valorDeposito = double.Parse(Console.ReadLine());
        listaContas[indiceConta].DepositarDinheiro(valorDeposito);

        Console.WriteLine();
        Console.WriteLine("Aperte qualquer tecla para voltar ao menu");
        Console.ReadKey();
    }

    //Nesse método, a variavel indiceConta percorre a List listaContas em que estão armazenadas as contas, identificando a respectiva pelo Id que é gerado quando a conta é adicionada nessa List, então ela chama o método ExtratoBancário da classe Conta
    private static void VerExtrato()
    {
        Console.Write("Digite o ID da conta: ");
        int indiceConta = int.Parse(Console.ReadLine());

        Console.WriteLine("------------Extrato------------");
        listaContas[indiceConta].ExtratoBancario();

        Console.WriteLine();
        Console.WriteLine("Aperte qualquer tecla para voltar ao menu");
        Console.ReadKey();
    }

    //Menu da aplicação
    private static string ObterOpcaoDoUsuario()
    {
        Console.WriteLine();
        Console.WriteLine("Bem vindo(a) ao Banco!!!");
        Console.WriteLine();
        Console.WriteLine("Digite a opção desejada: ");

        Console.WriteLine("1 - Cadastrar uma conta");
        Console.WriteLine("2 - Listar contas");
        Console.WriteLine("3 - Transferir");
        Console.WriteLine("4 - Sacar");
        Console.WriteLine("5 - Depositar");
        Console.WriteLine("6 - Ver extrato");
        Console.WriteLine("C - Limpar terminal");
        Console.WriteLine("E - Sair");
        Console.WriteLine();

        string opcaoDoUsuario = Console.ReadLine().ToUpper();
        Console.WriteLine();
        return opcaoDoUsuario;
    }

}