namespace FP_Playground;

public class Tuples
{
    // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-tuples
    public void TuplesWithExplicitNames()
    {
        var t = (Sum: 4.5, Count: 3);
        Console.WriteLine($"Sum of {t.Count} elements is {t.Sum}.");

        (double Sum, int Count) d = (4.5, 3);
        Console.WriteLine($"Sum of {d.Count} elements is {d.Sum}.");
    }

    public void TuplesWithInferredNames()
    {
        var sum = 4.5;
        var count = 3;
        var t = (sum, count);
        Console.WriteLine($"Sum of {t.count} elements is {t.sum}.");
    }

    public void DoWhatYouWantNames()
    {
        var a = 1;
        var t = (a, b: 2, 3);
        Console.WriteLine($"The 1st element is {t.Item1} (same as {t.a}).");
        Console.WriteLine($"The 2nd element is {t.Item2} (same as {t.b}).");
        Console.WriteLine($"The 3rd element is {t.Item3}.");
        // Output:
        // The 1st element is 1 (same as 1).
        // The 2nd element is 2 (same as 2).
        // The 3rd element is 3.
    }

    public void TupleEquality()
    {
        (int a, byte b) left = (5, 10);
        (long a, int b) right = (5, 10);
        Console.WriteLine(left == right);  // output: True
        Console.WriteLine(left != right);  // output: False

        var t1 = (A: 5, B: 10);
        var t2 = (B: 5, A: 10);
        Console.WriteLine(t1 == t2);  // output: True
        Console.WriteLine(t1 != t2);  // output: False
    }
}