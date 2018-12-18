using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrdenacaoService;
using OrdenacaoService.Exceptions;
using OrdenacaoService.Model;

namespace OrdenacaoServiceTeste
{
    /// <summary>
    /// Classe responsável pelos testes dos requisitos
    /// </summary>
    [TestClass]
    public class OrdenacaoTestes
    {
        private Livro Livro1 { get; } = new Livro("Java How to Program", "Deitel & Deitel", 2007);
        private Livro Livro2 { get; } = new Livro("Patterns of Enterprise Application Architecture", "Martin Fowler", 2002);
        private Livro Livro3 { get; } = new Livro("Head First Design Patterns", "Elisabeth Freeman", 2004);
        private Livro Livro4 { get; } = new Livro("Internet & World Wide Web: How to Program", "Deitel & Deitel", 2007);
        private List<Livro> ListaLivros { get; set; } = new List<Livro>();

        public void AdicionaLivrosLista()
        {
            ListaLivros.Add(Livro1);
            ListaLivros.Add(Livro2);
            ListaLivros.Add(Livro3);
            ListaLivros.Add(Livro4);
        }

        /// <summary>
        /// Método responsável por testar o primeiro requisito
        /// </summary>
        [TestMethod]
        public void Titulo_Ascendente()
        {
            //Arrange
            List<Livro> result = new List<Livro>();
            Ordenador sut = new Ordenador();

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["Titulo"].Value = "a";
            config.AppSettings.Settings["Autor"].Value = "a";
            config.AppSettings.Settings["AnoEdicao"].Value = "a";
            config.Save(ConfigurationSaveMode.Full);

            //Act
            AdicionaLivrosLista();
            result = sut.Ordernar(ListaLivros);

            //Assert
            // Valida se a lista ordenada retornada é igual a ordem requisitada no caso de testes

            Assert.AreEqual(result[0].Titulo, Livro3.Titulo);
            Assert.AreEqual(result[1].Titulo, Livro4.Titulo);
            Assert.AreEqual(result[2].Titulo, Livro1.Titulo);
            Assert.AreEqual(result[3].Titulo, Livro2.Titulo);
        }

        /// <summary>
        /// Método responsável por testar o segundo requisito
        /// </summary>
        [TestMethod]
        public void Autor_Ascendente_E_Titulo_Descendente()
        {
            //Arrange
            List<Livro> result = new List<Livro>();
            Ordenador sut = new Ordenador();

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["Autor"].Value = "a";
            config.AppSettings.Settings["Titulo"].Value = "d";
            config.Save(ConfigurationSaveMode.Full);

            //Act
            AdicionaLivrosLista();
            result = sut.Ordernar(ListaLivros);

            //Assert
            // Valida se a lista ordenada retornada é igual a ordem requisitada no caso de testes

            Assert.AreEqual(result[0].Titulo, Livro1.Titulo);
            Assert.AreEqual(result[1].Titulo, Livro4.Titulo);
            Assert.AreEqual(result[2].Titulo, Livro3.Titulo);
            Assert.AreEqual(result[3].Titulo, Livro2.Titulo);
        }

        /// <summary>
        /// Método responsável por testar o terceiro requisito
        /// </summary>
        [TestMethod]
        public void Edicao_Descendente_E_Autor_Descendente_E_Titulo_Ascendente()
        {
            //Arrange
            List<Livro> result = new List<Livro>();
            Ordenador sut = new Ordenador();

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["AnoEdicao"].Value = "d";
            config.AppSettings.Settings["Autor"].Value = "d";
            config.AppSettings.Settings["Titulo"].Value = "a";
            config.Save(ConfigurationSaveMode.Full);

            //Act
            AdicionaLivrosLista();
            result = sut.Ordernar(ListaLivros);

            //Assert
            // Valida se a lista ordenada retornada é igual a ordem requisitada no caso de testes

            Assert.AreEqual(result[0].Titulo, Livro4.Titulo);
            Assert.AreEqual(result[1].Titulo, Livro1.Titulo);
            Assert.AreEqual(result[2].Titulo, Livro3.Titulo);
            Assert.AreEqual(result[3].Titulo, Livro2.Titulo);
        }

        /// <summary>
        /// Método responsável por testar o quarto requisito
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(OrdenacaoException))]
        public void Ordenacao_Eh_Nulo()
        {
            Ordenador sut = new Ordenador();

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["Titulo"].Value = null;
            config.Save(ConfigurationSaveMode.Full);

            sut.VerificaRegraOrdenacaoEhNulo();
        }

        /// <summary>
        /// Método responsável por testar o último requisito
        /// </summary>
        [TestMethod]
        public void Conjunto_Eh_Vazio()
        {
            //Arrange
            Ordenador sut = new Ordenador();
            List<Livro> lista = new List<Livro>();

            //Act
            sut.Ordernar(lista = null);

            //Assert
            Assert.IsTrue(Ordenador.ConjuntoEhVazio);
        }
    }
}
