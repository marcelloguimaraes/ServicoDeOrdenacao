using OrdenacaoService.Exceptions;
using OrdenacaoService.Interfaces;
using OrdenacaoService.Model;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System;

namespace OrdenacaoService
{
    /// <summary>
    /// Classe responsável por implementar a interface de Ordenação e ser consumida pelo CSO
    /// </summary>
    public class Ordenador : IOrdenacaoLivros
    {
        /// <summary>
        /// Propriedades que recuperam a parametrização do arquivo de configuração
        /// </summary>
        private string Titulo { get; set; } = ConfigurationManager.AppSettings["Titulo"];
        private string Autor { get; set; } = ConfigurationManager.AppSettings["Autor"];
        private string AnoEdicao { get; set; } = ConfigurationManager.AppSettings["AnoEdicao"];

        /// <summary>
        /// Propriedade que controla e expõe se o conjunto passado para o serviço foi vazio
        /// </summary>
        public static bool ConjuntoEhVazio { get; set; }

        /// <summary>
        /// Método sobrescrito e implementado da interface que ordena os livros
        /// </summary>
        /// <param name="livros">Coleção de livros recebida a ser ordenada</param>
        /// </param>
        public List<Livro> Ordernar(List<Livro> livros)
        {
            IEnumerable<Livro> lista = null;

            VerificaRegraOrdenacaoEhNulo();

            if (livros == null)
            {
                ConjuntoEhVazio = true;
                return livros;
            }

            if (Titulo == "a" && Autor == "d" && AnoEdicao == "d")
            {
                lista = from livro in livros
                        orderby livro.AnoEdicao descending,
                                livro.Autor descending,
                                livro.Titulo ascending
                        select livro;
            }
            else if (Autor == "a" && Titulo == "d")
            {
                lista = from livro in livros
                        orderby livro.Autor ascending, livro.Titulo descending
                        select livro;
            }
            else if (Autor == "a")
            {
                lista = from livro in livros
                        orderby livro.Titulo ascending
                        select livro;
            }

            return lista.ToList();
        }

        public void VerificaRegraOrdenacaoEhNulo()
        {
            if (String.IsNullOrEmpty(Titulo) || String.IsNullOrEmpty(Autor) || String.IsNullOrEmpty(AnoEdicao))
            {
                throw new OrdenacaoException("Tipo de ordenação não informado no arquivo de configuração App.config");
            }
        }
    }
}
