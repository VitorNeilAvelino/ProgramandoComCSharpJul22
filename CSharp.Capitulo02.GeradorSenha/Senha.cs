using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Capitulo02.GeradorSenha
{
    public class Senha
    {
        //public Senha()
        //{
        //    Valor = Gerar();
        //}

        public Senha(int tamanho = TamanhoMinimo)
        {
            Tamanho = tamanho;
            Valor = Gerar();
        }

        private const int TamanhoMinimo = 4;

        public int Tamanho { get; set; } = TamanhoMinimo;
        public string Valor { get; set; }

        private string Gerar()
        {
            var senha = string.Empty;
            var randomico = new Random();

            for (int i = 0; i < Tamanho; i++)
            {
                var numero = randomico.Next(10);

                senha += numero;
            }

            return senha;
        }
    }
}
