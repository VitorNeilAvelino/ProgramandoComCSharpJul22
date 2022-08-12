namespace Fintech.Dominio
{
    public class Movimento
    {
        /// <summary>
        /// Construtor vazio por requisito do Dapper.
        /// </summary>
        public Movimento() // ToDo: OO - polimorfismo (sobrecarga).
        {

        }

        public Movimento(decimal valor, Operacao operacao)
        {
            Valor = valor;
            Operacao = operacao;
        }

        //public Movimento(Operacao operacao, decimal valor)
        //{
        //    Valor = valor;
        //    Operacao = operacao;
        //}

        public int Id { get; set; }
        public Guid Guid { get; set; } = Guid.NewGuid();
        public DateTime Data { get; set; } = DateTime.Now;
        public Operacao Operacao { get; set; }
        public decimal Valor { get; set; }
        public Conta? Conta { get; set; } //= new Conta();
    }
}