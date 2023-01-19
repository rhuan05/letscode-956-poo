namespace Mod3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cliente novoCliente = new Cliente();

            int produtos = 250;
            novoCliente.DefinirProdutosAdquiridos(200);
            novoCliente.DefinirProdutosAdquiridos(produtos);
        }
    }
}