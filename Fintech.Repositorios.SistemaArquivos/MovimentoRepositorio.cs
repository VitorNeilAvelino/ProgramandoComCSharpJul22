using Fintech.Dominio;

namespace Fintech.Repositorios.SistemaArquivos
{
    public class MovimentoRepositorio
    {
        public MovimentoRepositorio(string caminho)
        {
            Caminho = caminho;
        }

        private const string DiretorioBase = "Dados";

        public string Caminho { get; private set; }

        public void Inserir(Movimento movimento)
        {
            var registro = $"{movimento.Guid}|" +
                $"{movimento.Conta.Agencia.Numero}|" +
                $"{movimento.Conta.Numero}|" +
                $"{movimento.Data}|{(int)movimento.Operacao}|{movimento.Valor}";

            if (!Directory.Exists(DiretorioBase))
            {
                Directory.CreateDirectory(DiretorioBase);
            }

            File.AppendAllText(@$"{DiretorioBase}\Movimento.txt", registro + Environment.NewLine);
        }

        public List<Movimento> Selecionar(int numeroAgencia, int numeroConta)
        {
            var movimentos = new List<Movimento>();

            foreach (var linha in File.ReadAllLines(Caminho))
            {
                var propriedades = linha.Split('|');

                var guid = propriedades[0];
                var propriedadeNumeroAgencia = propriedades[1];
                var propriedadeNumeroConta = propriedades[2];
                var data = propriedades[3];
                var operacao = propriedades[4];
                var valor = propriedades[5];
            }

            return movimentos;
        }
    }
}