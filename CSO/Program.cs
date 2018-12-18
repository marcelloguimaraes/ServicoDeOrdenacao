using OrdenacaoService;
using OrdenacaoService.Exceptions;
using OrdenacaoService.Model;
using System;
using System.Collections.Generic;

namespace CSO
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Cria conjunto de livros
            List<Livro> lista = new List<Livro>();
            List<Livro> listaOrdenada = new List<Livro>();

            Livro livro1 = new Livro("Java How to Program", "Deitel & Deitel", 2007);
            Livro livro2 = new Livro("Patterns of Enterprise Application Architecture", "Martin Fowler", 2002);
            Livro livro3 = new Livro("Head First Design Patterns", "Elisabeth Freeman", 2004);
            Livro livro4 = new Livro("Internet & World Wide Web: How to Program", "Deitel & Deitel", 2007);

            lista.Add(livro1);
            lista.Add(livro2);
            lista.Add(livro3);
            lista.Add(livro4);

            Ordenador ordenador = new Ordenador();

            try
            {
                listaOrdenada = ordenador.Ordernar(lista);
            }
            catch (OrdenacaoException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
