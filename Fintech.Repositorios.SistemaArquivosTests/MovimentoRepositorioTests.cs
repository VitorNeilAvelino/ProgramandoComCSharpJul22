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
        [TestMethod()]
        public void InserirTest()
        {
            var conta = new ContaCorrente(new Agencia { Numero = 123 }, 526, "1");
            
            var movimento = new Movimento(200, Operacao.Saque);
            movimento.Conta = conta;
            
            var repositorio = new MovimentoRepositorio("Dados\\Movimento.txt");
            repositorio.Inserir(movimento);
        }
    }
}