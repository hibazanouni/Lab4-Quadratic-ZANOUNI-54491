using System;

namespace QuadraticEquationSolver;

/// <summary>
/// Solves quadratic equations of the form a*x^2 + b*x + c = 0.
/// Lab 4 requirement: a program that calculates the roots of the quadratic equation,
/// covering the three basic cases: no real roots, one real root, two real roots.
/// </summary>
public static class Solver
{
    public readonly record struct Result(double? Root1, double? Root2, string Message);

    public static Result Solve(double a, double b, double c)
    {
        if (a == 0)
            throw new ArgumentException("Coefficient 'a' cannot be zero for a quadratic equation.", nameof(a));

        double discriminant = b * b - 4 * a * c;

        if (discriminant < 0)
            return new Result(null, null, "No real roots.");

        if (discriminant == 0)
        {
            double root = -b / (2 * a);
            return new Result(root, null, "One real root.");
        }

        double sqrtD = Math.Sqrt(discriminant);
        double root1 = (-b + sqrtD) / (2 * a);
        double root2 = (-b - sqrtD) / (2 * a);
        return new Result(root1, root2, "Two real roots.");
    }
}
