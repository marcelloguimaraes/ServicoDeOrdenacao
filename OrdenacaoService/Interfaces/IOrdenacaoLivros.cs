using OrdenacaoService.Model;
using System.Collections.Generic;

namespace OrdenacaoService.Interfaces
{
    /// <summary>
    /// Interface responsável por fornecer o serviço de ordenação de livros
    /// </summary>
    public interface IOrdenacaoLivros
    {
        /// <summary>
        /// Ordena os livros recebidos
        /// </summary>
        /// <param name="livros">Coleção de Livros recebida a ser ordenada</param>
        List<Livro> Ordernar(List<Livro> livros);
    }
}
