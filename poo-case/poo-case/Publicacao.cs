using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poo_case
{
    public class Publicacao
    {
        public int ContadorDeLike { get; set; }
        public int ContadorDeCompartilhamento { get; set; }
        public int ContadorDeComentario { get; set; }
        public bool SinalizaAjuda { get; set; }
        public string TextoPublicado { get; set; }
        public Usuario Autor { get; set; }
        public static bool comentarioDestacado { get; set; }
        public List<Comentario> Comentarios { get; set; }

        public Publicacao(Usuario autor, string textoPublicacao)
        {
            this.Autor = autor;
            this.TextoPublicacao = textoPublicacao;
            this.DataPublicacao = DateTime.Now;
        }

        // Método para sinalizar que a publicação precisa de ajuda.
        public void SetSinalizaAjuda(bool validador)
        {
            this.SinalizaAjuda = validador;
        }

        // Método que atualiza os contadores.
        public void atualizaContadores(string tipoContador)
        {
            if(tipoContador.Equals("Like"))
            {
                this.ContadorDeLike++;
            }
            if (tipoContador.Equals("Comentario"))
            {
                this.ContadorDeComentario++;
            }
            if (tipoContador.Equals("Compartilhamento"))
            {
                this.ContadorDeCompartilhamento++;
            }
        }

        public void SetComentarioDestaque(Comentario comentario)
        {
            // Se o método nunca foi invocado
            if(!comentarioDestacado)
            {
                // Garantindo que a publicação foi resolvida não fique mais marcada como uma publicação de ajuda.
                SetSinalizaAjuda(false);

                // Preciso sinalizar que o comentário teve destaque.
                comentario.DestacaComentario(true);

                comentarioDestacado = true;
            }
        }
    }
}
