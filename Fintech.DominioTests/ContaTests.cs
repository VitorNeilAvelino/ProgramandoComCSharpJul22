using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fintech.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fintech.Dominio.Tests
{
    [TestClass()]
    public class ContaTests
    {
        [TestMethod()]
        public void EfetuarOperacaoTest()
        {
            var conta = new ContaEspecial(new Agencia(), 2229, "X", 1000);

            conta.EfetuarOperacao(50, Operacao.Deposito);
            Assert.IsTrue(conta.Saldo == 50);

            conta.EfetuarOperacao(20, Operacao.Saque);
            Assert.IsTrue(conta.Saldo == 30);

            conta.EfetuarOperacao(40, Operacao.Saque);
            Assert.IsTrue(conta.Saldo == -10);

            conta.EfetuarOperacao(990, Operacao.Saque);
            Assert.IsTrue(conta.Saldo == -1000);

            conta.EfetuarOperacao(10, Operacao.Saque);
            Assert.IsTrue(conta.Saldo == -1000);

            conta.EfetuarOperacao(1000, Operacao.Deposito);
            Assert.IsTrue(conta.Saldo == 0);

            foreach (var movimento in conta.Movimentos)
            {
                Console.WriteLine($"{movimento.Data} - {movimento.Operacao} - {movimento.Valor}");
            }
        }
    }
}