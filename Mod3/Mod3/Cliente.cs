using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod3
{
    internal class Cliente : Produto
    {
        private int clienteId;
        private string nomeCliente;
        private decimal limiteCredito;
        private int quantidadeProdutos;
        public int produtosAdquiridos;
        public readonly bool EclienteEspecial;

        public Cliente
        {
            if(produtosAdquiridos < quantidade)
            {
                EclienteEspecial = false;
            }
            else
            {
                EclienteEspecial = true;
            }
        }

        public void ComprarEspecial()
        {
            // Ação
        }

        public void DefinirProdutosAdquiridos(int quantidade)
        {
            produtosAdquiridos = quantidade;
        }

        public void DefinirProdutosAdquiridos(int quantidade, bool clienteModificado)
        {
            if(clienteModificado)
            {
                produtosAdquiridos = quantidade;
            }
        }

        public void DefinirProdutosAdquiridos()
        {
                produtosAdquiridos = recuperarProdutos(clienteId);
        }

        public void Comprar(int idProduto)
        {
            // Buscar produto
        }
    }
}
