using System;

class Program
{
    static void Main(string[] args)
    {
        // -------------------------
        // Divisors
        // -------------------------
        Console.WriteLine("\n======================");
        Console.WriteLine("Divisors");
        Console.WriteLine("======================");
        Divisors.Run();

        // -------------------------
        // Array Selector
        // -------------------------
        Console.WriteLine("\n======================");
        Console.WriteLine("Array Selector");
        Console.WriteLine("======================");
        ArraySelector.Run();

        // -------------------------
        // Algorithms
        // -------------------------
        Console.WriteLine("\n======================");
        Console.WriteLine("Algorithms");
        Console.WriteLine("======================");
        Algorithms.Run();

        // -------------------------
        // Solution versions
        // -------------------------
        DivisorsSolution.Run();
        ArraySelectorSolution.Run();
    }
}