using System.Diagnostics;
using System.Reflection;
using LeetCodeSolutions.Problems.Interfaces;

namespace LeetCodeSolutions;

class Program
{
    static void Main(string[] args)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var problemTypes = assembly.GetTypes()
            .Where(t => typeof(ILeetCodeProblem).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
            .OrderBy(t => t.Name)
            .ToList();

        if (!problemTypes.Any())
        {
            Console.WriteLine("⚠️ No problems found implementing ILeetCodeProblem.");
            return;
        }

        string? problemName = args.Length > 0 ? args[0] : null;

        // If no argument is provided, show interactive menu
        if (string.IsNullOrWhiteSpace(problemName))
        {
            Console.WriteLine("📘 Available Problems:\n");
            for (int i = 0; i < problemTypes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {problemTypes[i].Name}");
            }

            Console.WriteLine("\nEnter the problem number to run:");
            Console.Write("> ");
            var input = Console.ReadLine();

            if (!int.TryParse(input, out int choice) || choice < 1 || choice > problemTypes.Count)
            {
                Console.WriteLine("❌ Invalid selection. Exiting.");
                return;
            }

            problemName = problemTypes[choice - 1].Name;
        }

        RunProblem(problemName!, problemTypes);
    }

    static void RunProblem(string problemName, System.Collections.Generic.List<Type> problemTypes)
    {
        var assembly = Assembly.GetExecutingAssembly();
        string fullName = $"LeetCodeSolutions.Problems.{problemName}";

        Type? problemType = assembly.GetType(fullName, throwOnError: false, ignoreCase: true)
                            ?? problemTypes.FirstOrDefault(t =>
                                string.Equals(t.Name, problemName, StringComparison.OrdinalIgnoreCase));

        if (problemType == null)
        {
            Console.WriteLine($"❌ Problem '{problemName}' not found.");
            return;
        }

        if (!typeof(ILeetCodeProblem).IsAssignableFrom(problemType))
        {
            Console.WriteLine($"⚠️ {problemName} does not implement ILeetCodeProblem.");
            return;
        }

        var instance = (ILeetCodeProblem)Activator.CreateInstance(problemType)!;
        Console.WriteLine($"\n▶ Running {problemType.Name}...\n");

        var stopwatch = Stopwatch.StartNew();
        instance.SolveProblem();
        stopwatch.Stop();
        Console.WriteLine($"\n✅ Execution finished in {stopwatch.Elapsed.TotalMilliseconds:f2} ms.\n");
    }
}