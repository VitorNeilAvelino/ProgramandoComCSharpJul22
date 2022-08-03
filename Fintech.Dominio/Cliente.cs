namespace Fintech.Dominio
{
    /// <summary>
    /// 
    /// </summary>
    public class Cliente
    {
        ///// <summary>
        ///// 
        ///// </summary>
        //public Cliente()
        //{

        //}

        /// <summary>
        /// 
        /// </summary>
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public Sexo Sexo { get; set; }
        public Endereco EnderecoResidencial { get; set; }
        public List<Conta> Contas { get; set; }
    }
}