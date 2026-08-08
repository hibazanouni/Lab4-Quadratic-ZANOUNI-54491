using QuadraticEquationSolver;
using Xunit;

namespace QuadraticEquationSolver.Tests;

public class SolverTests
{
    [Fact]
    public void Solve_NoRealRoots_ReturnsNullsAndMessage()
    {
        var result = Solver.Solve(1, 0, 1); // x^2 + 1 = 0, discriminant = -4
        Assert.Null(result.Root1);
        Assert.Null(result.Root2);
        Assert.Equal("No real roots.", result.Message);
    }

    [Fact]
    public void Solve_OneRealRoot_ReturnsRootAndMessage()
    {
        var result = Solver.Solve(1, -2, 1); // (x-1)^2 = 0
        Assert.NotNull(result.Root1);
        Assert.Null(result.Root2);
        Assert.Equal(1, result.Root1!.Value, 6);
        Assert.Equal("One real root.", result.Message);
    }

    [Fact]
    public void Solve_TwoRealRoots_ReturnsBothRootsAndMessage()
    {
        var result = Solver.Solve(1, -3, 2); // (x-1)(x-2) = 0
        Assert.NotNull(result.Root1);
        Assert.NotNull(result.Root2);
        Assert.Equal(2, result.Root1!.Value, 6);
        Assert.Equal(1, result.Root2!.Value, 6);
        Assert.Equal("Two real roots.", result.Message);
    }

    [Fact]
    public void Solve_AIsZero_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => Solver.Solve(0, 2, 1));
    }

    // xUnit Theory: exercises several coefficient sets and their expected roots/message
    // in a single, data-driven test, as recommended by the lab instructions.
    [Theory]
    [InlineData(1.0, 0.0, -4.0, 2.0, -2.0, "Two real roots.")]
    [InlineData(2.0, 4.0, 2.0, -1.0, null, "One real root.")]
    [InlineData(1.0, 1.0, 1.0, null, null, "No real roots.")]
    [InlineData(1.0, -5.0, 6.0, 3.0, 2.0, "Two real roots.")]
    public void Solve_MultipleScenarios(double a, double b, double c,
        double? expectedRoot1, double? expectedRoot2, string expectedMessage)
    {
        var result = Solver.Solve(a, b, c);

        Assert.Equal(expectedMessage, result.Message);
        if (expectedRoot1 is null)
            Assert.Null(result.Root1);
        else
            Assert.Equal(expectedRoot1.Value, result.Root1!.Value, 6);

        if (expectedRoot2 is null)
            Assert.Null(result.Root2);
        else
            Assert.Equal(expectedRoot2.Value, result.Root2!.Value, 6);
    }
}

