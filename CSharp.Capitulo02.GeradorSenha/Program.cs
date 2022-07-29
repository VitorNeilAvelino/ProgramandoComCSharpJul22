namespace CSharp.Capitulo02.GeradorSenha
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.Write("Informe a quantidade de dígitos da senha (entre 4 e 10 - números pares): ");

            //var quantidadeDigitos = 0;

            //while (quantidadeDigitos == 0)
            //{
            //    quantidadeDigitos = ObterQuantidadeDigitos();
            //}

            int quantidadeDigitos;

            do
            {
                Console.Write("Informe a quantidade de dígitos da senha (entre 4 e 10 - números pares): ");
                quantidadeDigitos = ObterQuantidadeDigitos();
            } while (quantidadeDigitos == 0);

            var senha = string.Empty;
            var randomico = new Random();

            for (int i = 0; i < quantidadeDigitos; i++)
            {
                var numero = randomico.Next(10);

                //senha = senha + numero;
                senha += numero;
            }

            Console.WriteLine($"Senha gerada: {senha}");
        }

        private static int ObterQuantidadeDigitos()
        {
            int.TryParse(Console.ReadLine(), out int quantidadeDigitos);

            if (quantidadeDigitos < 4 || quantidadeDigitos > 10 || quantidadeDigitos % 2 != 0)
            {
                Console.WriteLine($"O valor {quantidadeDigitos} é inválido de acordo com as regras.");

                quantidadeDigitos = 0;
            }

            return quantidadeDigitos;
        }
    }
}