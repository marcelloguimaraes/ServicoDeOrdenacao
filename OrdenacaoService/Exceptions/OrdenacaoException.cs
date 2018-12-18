using System;

namespace OrdenacaoService.Exceptions
{
    /// <summary>
    /// Classe responsável por lançar uma excessão de ordenação
    /// Obs: Boa prática implementar os 3 construtores da classe base Exception
    /// </summary>
    public class OrdenacaoException : Exception
    {
        /// <summary>
        /// Método construtor vazio
        /// </summary>
        public OrdenacaoException()
        {

        }

        /// <summary>
        /// Método construtor passando a mensagem para a classe base Exception
        /// </summary>
        /// <param name="mensagem">Mensagem que será exibida se a excessão for lançada</param>
        public OrdenacaoException(string mensagem)
            : base(mensagem)
        {

        }

        /// <summary>
        /// Método construtor 
        /// </summary>
        /// <param name="mensagem">Mensagem que será exibida se a excessão for lançada</param>
        /// <param name="innerException">Excessão interna caso seja necessário</param>
        public OrdenacaoException(string mensagem, Exception innerException)
            : base(mensagem, innerException)
        {

        }
    }
}
