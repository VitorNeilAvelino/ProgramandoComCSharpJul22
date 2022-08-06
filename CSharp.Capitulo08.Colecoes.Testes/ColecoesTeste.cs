using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Capitulo08.Colecoes.Testes
{
    [TestClass]
    public class ColecoesTeste
    {
        [TestMethod]
        public void ListTeste()
        {
            var inteiros = new List<int>(/*1000*/) { 1, 8, 33, 16, -78 };
            inteiros.Add(1);
            inteiros.Add(4);
            inteiros[0] = 16;
            //inteiros[100] = -9;

            var maisInteiros = new List<int> { 38, -7, 8 };

            inteiros.AddRange(maisInteiros);

            inteiros.Insert(2, 42);

            inteiros.Remove(42);

            inteiros.RemoveAt(0);

            inteiros.Sort();

            var primeiro = inteiros[0];
            primeiro = inteiros.First();

            var ultimo = inteiros.Last();
            ultimo = inteiros[inteiros.Count - 1];

            var indice = inteiros.IndexOf(38);

            inteiros.Reverse();

            inteiros.OrderByDescending(x => x); // expressões lâmbda

            foreach (var inteiro in inteiros)
            {
                Console.WriteLine($"{inteiros.IndexOf(inteiro)}: {inteiro}");
            }
        }

        [TestMethod]
        public void DictionaryTeste()
        {
            var feriados = new Dictionary<DateTime, string>();

            feriados.Add(new DateTime(2022, 9, 7), "Independência");
            feriados.Add(Convert.ToDateTime("15/11/2022"), "República");
            //feriados.Add(Convert.ToDateTime("15/11/2022"), "República");

            var independencia = feriados[new DateTime(2022, 9, 7)];

            foreach (var feriado in feriados)
            {
                Console.WriteLine($"{feriado.Key.ToShortDateString()}: {feriado.Value}");
            }

            Console.WriteLine(feriados.ContainsKey(Convert.ToDateTime("15/11/2022")));
            Console.WriteLine(feriados.ContainsValue("República"));
        }
    }
}
