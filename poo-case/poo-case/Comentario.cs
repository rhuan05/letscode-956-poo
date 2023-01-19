using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poo_case
{
    public class Comentario
    {
        public string Conteudo { get; set; }
        public Usuario AutorComentario { get; set; }
        public Publicacao Publicacao { get; set; }
        public bool Destaque { get; set; } // Se destaque fosse igual a true o publicação foi resolvida.

        public Comentario(string conteudo, Usuario autorDoComentario, Publicacao publicacao)
        {
            this.Conteudo = conteudo;
            this.AutorComentario = autorDoComentario;
            this.Publicacao = publicacao;
        }

        public void DestacaComentario(bool validador)
        {
            this.Destaque = true;
        }
    }
}
