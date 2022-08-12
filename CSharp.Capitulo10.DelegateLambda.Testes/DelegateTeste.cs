namespace CSharp.Capitulo10.DelegateLambda.Testes
{
    [TestClass]
    public class DelegateTeste
    {
        [TestMethod]
        [DataRow(TipoOperacao.Soma, 1, 2, 3)]
        [DataRow(TipoOperacao.Subtracao, 1, 2, -1)]
        public void CalculadoraTeste(TipoOperacao tipoOperacao, int x, int y, int resultado)
        {
            var operacao = Calculadora.ObterOperacao(tipoOperacao);
            
            Assert.IsTrue(operacao(x, y) == resultado);
        }
    }
}