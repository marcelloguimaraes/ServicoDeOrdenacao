namespace OrdenacaoService.Model
{
    /// <summary>
    /// Classe modelo do Livro e que contém todas suas propriedades
    /// </summary>
    public class Livro
    {
        /// <summary>
        /// Título do livro
        /// </summary>
        public string Titulo { get; private set; }

        /// <summary>
        /// Autor do livro
        /// </summary>
        public string Autor { get; private set; }

        /// <summary>
        /// Ano de edição do Livro
        /// </summary>
        public int AnoEdicao { get; private set; }

        /// <summary>
        /// Método construtor de Livro
        /// </summary>
        public Livro(string titulo, string autor, int anoEdicao)
        {
            Titulo = titulo;
            Autor = autor;
            AnoEdicao = anoEdicao;
        }
    }
}
