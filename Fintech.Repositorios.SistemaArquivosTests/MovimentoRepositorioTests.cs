using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fintech.Repositorios.SistemaArquivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fintech.Dominio;

namespace Fintech.Repositorios.SistemaArquivos.Tests
{
    [TestClass()]
    public class MovimentoRepositorioTests
    {
        MovimentoRepositorio repositorio = new ("Dados\\Movimento.txt");

        [TestMethod()]
        public void InserirTest()
        {
            var conta = new ContaCorrente(new Agencia { Numero = 123 }, 526, "1");

            var movimento = new Movimento(600, Operacao.Deposito);
            movimento.Conta = conta;            

            repositorio.Inserir(movimento);
        }

        [TestMethod()]
        public void SelecionarTest()
        {
            var movimentos = repositorio.Selecionar(123, 526);

            foreach (var movimento in movimentos)
            {
                Console.WriteLine($"{movimento.Data} - {movimento.Operacao} - {movimento.Valor:c}");
            }
        }

        [TestMethod]
        public void DelegateActionTeste()
        {
            var movimentos = repositorio.Selecionar(123, 526);

            //foreach (var movimento in movimentos)
            //{

            //}

            Action<Movimento> writeLine = m => Console.WriteLine($"{m.Data} - {m.Operacao} - {m.Valor:c}");

            //movimentos.ForEach(EscreverMovimento);
            //movimentos.ForEach(writeLine);
            movimentos.ForEach(m => Console.WriteLine($"{m.Data} - {m.Operacao} - {m.Valor:c}"));
        }

        private void EscreverMovimento(Movimento movimento)
        {
            Console.WriteLine($"{movimento.Data} - {movimento.Operacao} - {movimento.Valor:c}");
        }

        [TestMethod]
        public void DelegatePredicateTeste()
        {
            var movimentos = repositorio.Selecionar(123, 526);

            //var depositos = movimentos.FindAll(EncontrarMovimentoDeposito);
            var depositos = movimentos.FindAll(m => m.Operacao == Operacao.Deposito);

            depositos.ForEach(d => Console.WriteLine(d.Valor));
        }

        private bool EncontrarMovimentoDeposito(Movimento movimento)
        {
            return movimento.Operacao == Operacao.Deposito;
        }

        [TestMethod]
        public void DelegateFuncTeste()
        {
            var movimentos = repositorio.Selecionar(123, 526);

            //var totalDepositos = movimentos.Where(m => m.Operacao == Operacao.Deposito).Sum(RetornarCampoSoma);
            var totalDepositos = movimentos
                .Where(m => m.Operacao == Operacao.Deposito)
                .Sum(m => m.Valor);

            Console.WriteLine(totalDepositos);
        }

        private decimal RetornarCampoSoma(Movimento movimento)
        {
            return movimento.Valor;
        }

        [TestMethod]
        public void OrderByTeste()
        {
            var movimentos = repositorio.Selecionar(123, 526)
                //.OrderByDescending(m => m.Data)
                .OrderBy(m => m.Operacao)
                .ThenByDescending(m => m.Data)
                .ToList();
            //.ThenBy(m => m.Operacao);

            movimentos.ForEach(m => Console.WriteLine($"{m.Operacao} - {m.Data} - {m.Valor:c}"));
        }

        [TestMethod]
        public void CountTeste()
        {
            var quantidadeDepositos = repositorio.Selecionar(123, 526)
                .Count(m => m.Operacao == Operacao.Deposito);

            Assert.IsTrue(quantidadeDepositos == 2);
        }

        [TestMethod]
        public void LikeTeste()
        {
            var movimentos = repositorio.Selecionar(123, 526)
                .Where(m => m.Data.ToString().Contains("12/08/2022"));

            foreach (var movimento in movimentos)
            {
                Console.WriteLine(movimento.Data);
            }
        }

        [TestMethod]
        public void MinTeste()
        {
            var movimentos = repositorio.Selecionar(123, 526);

            var menorDeposito = movimentos
            .Where(m => m.Operacao == Operacao.Deposito)
            .Min(m => m.Valor);

            Assert.IsTrue(menorDeposito == 500);
        }

        [TestMethod]
        public void SkipTakeTeste()
        {
            var movimentos = repositorio.Selecionar(123, 526)
                .Skip(1)
                .Take(10)
                .ToList();

            Assert.IsTrue(movimentos.Count == 2);
        }

        [TestMethod]
        public void GroupByTeste()
        {
            var agrupamento = repositorio.Selecionar(123, 526)
                .GroupBy(m => m.Operacao)
                .Select(g => new { Operacao = g.Key, Total = g.Sum(m => m.Valor) });

            foreach (var item in agrupamento)
            {
                Console.WriteLine($"{item.Operacao}: {item.Total}");
            }
        }
    }
}