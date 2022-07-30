namespace Fintech.Dominio
{
    public class ContaCorrente
    {
        public int Numero { get; set; }
        public string DigitoVerificador { get; set; }
        public decimal Saldo { get; set; }
        public Agencia Agencia { get; set; }
        public Cliente Cliente { get; set; }
    }
}