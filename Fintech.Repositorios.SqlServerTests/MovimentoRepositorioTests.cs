using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fintech.Repositorios.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fintech.Dominio;

namespace Fintech.Repositorios.SqlServer.Tests
{
    [TestClass()]
    public class MovimentoRepositorioTests
    {
        private readonly MovimentoRepositorio repositorio = new("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Fintech;Integrated Security=True");

        [TestMethod()]
        public void InserirTest()
        {
            var conta = new ContaCorrente(new Agencia { Numero = 123 }, 456, "1");

            var movimento = new Movimento(500, Operacao.Deposito);
            movimento.Conta = conta;

            repositorio.Inserir(movimento);
        }

        [TestMethod()]
        public void SelecionarAsyncTest()
        {
            var movimentos = repositorio.SelecionarAsync(123, 456).Result;

            foreach (var movimento in movimentos)
            {
                Console.WriteLine($"{movimento.Data} - {movimento.Operacao} - {movimento.Valor:c}");
            }
        }
    }
}