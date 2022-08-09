namespace Fintech.Dominio
{
    public abstract class Conta
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public string? DigitoVerificador { get; set; }
        public decimal Saldo { get; set; }
        public Agencia? Agencia { get; set; }// = new Agencia();
        public Cliente? Cliente { get; set; }// = new Cliente();
        public List<Movimento> Movimentos { get; set; } = new List<Movimento>();

        public virtual Movimento EfetuarOperacao(decimal valor, Operacao operacao, decimal limite = 0)
        {
            var sucesso = true;
            Movimento movimento = null;

            switch (operacao)
            {
                case Operacao.Deposito:
                    Saldo += valor;
                    break;
                case Operacao.Saque:
                    if (Saldo + limite >= valor)
                    {
                        Saldo -= valor;
                    }
                    else
                    {
                        sucesso = false;
                    }
                    break;
            }

            if (sucesso)
            {
                movimento = new Movimento(valor, operacao);
                movimento.Conta = this;
                
                Movimentos.Add(movimento);
            }

            return movimento;
        }
    }
}