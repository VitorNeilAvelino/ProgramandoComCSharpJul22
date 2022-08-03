using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharp.Capitulo02.GeradorSenha;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Capitulo02.GeradorSenha.Tests
{
    [TestClass()]
    public class SenhaTests
    {
        [TestMethod()]
        public void GerarTest()
        {
            //Senha.Gerar
            
            var senha = new Senha();
            senha.Tamanho = 6;

            //var valorSenha = senha.Gerar();

            Console.WriteLine(senha.Valor);
        }

        [TestMethod]
        public void ConstrutorPadraoDeveRetornarSenhaPadrao()
        {
            var senha = new Senha();

            Console.WriteLine(senha.Valor);
        }

        [TestMethod]
        [DataRow(6)]
        [DataRow(8)]
        [DataRow(10)]
        public void ConstrutorParametrizadoDeveRetornarSenhaEspecifica(int tamanho)
        {
            var senha = new Senha(tamanho);

            Console.WriteLine(senha.Valor);
        }
    }
}