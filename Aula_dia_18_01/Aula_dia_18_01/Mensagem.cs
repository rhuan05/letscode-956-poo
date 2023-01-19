using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula_dia_18_01
{
    public class Mensagem<T>
    {

        public void MostrarMensagem(T mensagem)
        {
            Console.WriteLine(mensagem);
        }

    }
}
