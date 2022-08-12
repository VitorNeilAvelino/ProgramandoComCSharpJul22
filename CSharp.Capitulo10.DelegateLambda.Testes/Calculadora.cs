using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Capitulo10.DelegateLambda.Testes
{
    public delegate int EfetuarOperacao(int valor1, int valor2);
    internal static class Calculadora
    {
        private static int Somar(int x, int y)
        {
            return x + y;
        }

        public static EfetuarOperacao ObterOperacao(TipoOperacao tipoOperacao)
        {
            switch (tipoOperacao)
            {
                case TipoOperacao.Soma:
                    return Somar;
                case TipoOperacao.Subtracao:
                    return Subtrair;
                //case TipoOperacao.Multiplicacao:
                //    return Multiplicar;
            }

            throw new Exception();
        }

        private static int Multiplicar(int x, int y, int z)
        {
            return x * y * z;
        }

        private static int Subtrair(int valor1, int valor2)
        {
            return valor1 - valor2;
        }
    }
}
