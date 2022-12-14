namespace Fintech.Dominio
{
    public abstract class Conta
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public string? DigitoVerificador { get; set; }
        public decimal Saldo 
        {
            get { return TotalDepositos - TotalSaques; }
            private set { } 
        }
        public Agencia? Agencia { get; set; }// = new Agencia();
        public Cliente? Cliente { get; set; }// = new Cliente();
        public List<Movimento> Movimentos { get; set; } = new List<Movimento>();
        public decimal TotalDepositos  // ToDo: OO - encapsulamento.
        {
            get 
            {
                return Movimentos.Where(m => m.Operacao == Operacao.Deposito).Sum(m => m.Valor);
            } 
            //set; 
        }

        public decimal TotalSaques => Movimentos.Where(m => m.Operacao == Operacao.Saque).Sum(m => m.Valor);

        public virtual Movimento EfetuarOperacao(decimal valor, Operacao operacao, decimal limite = 0)
        {
            //var sucesso = true;
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
                        //sucesso = false;
                        throw new SaldoInsuficienteException("Saldo insuficiente.");
                    }
                    break;
            }

            //if (sucesso)
            //{
                movimento = new Movimento(valor, operacao);
                movimento.Conta = this;
                
                Movimentos.Add(movimento);
            //}

            return movimento;
        }
    }
}