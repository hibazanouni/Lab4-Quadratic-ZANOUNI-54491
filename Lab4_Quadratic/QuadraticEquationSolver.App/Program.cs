using QuadraticEquationSolver;

Console.WriteLine("Quadratic Equation Solver (a*x^2 + b*x + c = 0)");
Console.Write("a = "); double a = double.Parse(Console.ReadLine() ?? "0");
Console.Write("b = "); double b = double.Parse(Console.ReadLine() ?? "0");
Console.Write("c = "); double c = double.Parse(Console.ReadLine() ?? "0");

try
{
    var result = Solver.Solve(a, b, c);
    Console.WriteLine(result.Message);
    if (result.Root1 is not null) Console.WriteLine($"Root 1 = {result.Root1}");
    if (result.Root2 is not null) Console.WriteLine($"Root 2 = {result.Root2}");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
