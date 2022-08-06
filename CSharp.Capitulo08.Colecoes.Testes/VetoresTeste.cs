using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace CSharp.Capitulo08.Colecoes.Testes
{
    [TestClass]
    public class VetoresTeste
    {
        [TestMethod]
        public void InicializacaoTeste()
        {
            //array
            /*int[]*/ var inteiros = new int[5];
            inteiros[0] = 14;
            inteiros[1] = 1;
            //inteiros[5] = -37; // IndexOutOfRangeException

            var decimais = new decimal[] { 0.4m, 0.9m, 4m, 7.8m, -6.2m };

            string[] nomes = { "Vítor", "Avelino" };

            var chars = new[] {'a', 'b', 'c' };

            foreach (var @decimal in decimais)
            {
                Console.WriteLine(@decimal);
            }

            Console.WriteLine($"O tamanho do vetor {nameof(decimais)} é {decimais.Length}.");
        }

        [TestMethod]
        public void RedimensionamentoTeste()
        {
            var decimais = new decimal[] { 0.4m, 0.9m, 4m, 7.8m, -6.2m };

            Array.Resize(ref decimais, 6);

            decimais[5] = 2.3m;
        }

        [TestMethod]
        public void OrdenacaoTeste()
        {
            var decimais = new decimal[] { 0.4m, 0.9m, 4m, 7.8m, -6.2m };

            Array.Sort(decimais);

            Assert.IsTrue(decimais[0] == -6.2m);
        }

        [TestMethod]
        public void TodaStringEhUmVetorTeste() // StringBuilder
        {
            var nome = "Vítor";
            nome += " Avelino";

            Assert.AreEqual(nome[0], 'V');

            foreach (var @char in nome)
            {
                Console.WriteLine(@char);
            }
        }
    }
}