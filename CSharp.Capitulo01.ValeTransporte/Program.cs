Inicio:

Console.Write("Nome: ");
var nome = Console.ReadLine();

Console.Write("Salário: ");
var salario = Convert.ToDecimal(Console.ReadLine());

Console.Write("Transporte: ");
var gastoComTransporte = Convert.ToDecimal(Console.ReadLine());

var descontoMaximo = salario * 6 / 100;

var descontoVT = gastoComTransporte > descontoMaximo ? descontoMaximo : gastoComTransporte;

var resultado = $"Funcionário: {nome}\n" +
    $"Salário: {salario}\n" +
    $"Desconto VT: {descontoVT}";

Console.WriteLine(resultado);

Console.WriteLine("\nPressione Enter para novo cálculo ou Esc  para sair.");

var comando = Console.ReadKey();

if (comando.Key == ConsoleKey.Escape)
{
    Environment.Exit(0);
}

Console.Clear();

goto Inicio;