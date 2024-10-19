using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Podaj liczbę losowych punktów: ");
        int numSamples;
        while (!int.TryParse(Console.ReadLine(), out numSamples) || numSamples <= 0)
        {
            Console.WriteLine("Podaj poprawną liczbę całkowitą większą od 0.");
        }

        var startTime = DateTime.Now;

        double piEstimate = MonteCarloPi(numSamples);

        var endTime = DateTime.Now;

        Console.WriteLine($"Przybliżona wartość Pi: {piEstimate}");
        Console.WriteLine($"Czas obliczeń: {(endTime - startTime).TotalSeconds} sekund");
    }

    static double MonteCarloPi(int numSamples)
    {
        int insideCircle = 0;
        Random rand = new Random();

        for (int i = 0; i < numSamples; i++)
        {
            double x = rand.NextDouble() * 2 - 1;
            double y = rand.NextDouble() * 2 - 1;

            if (x * x + y * y <= 1)
            {
                insideCircle++;
            }
        }

        return 4.0 * insideCircle / numSamples;
    }
}
