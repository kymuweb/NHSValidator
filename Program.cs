using System;
using NHSNumberValidator;

static class Program
{
    private static void Main(string[] args)
    {
        var testCases = new string[]
        {
            " 857 612 5455 ",
            "424 719 2949",
            "5695374634",
            "1111111112",
            "111111",
            "aaaaaaaaaa",
            "aa"
        };

        var validator = new NhsNumberValidator();

        foreach (var number in testCases)
        {
            Console.WriteLine(validator.ValidateNHSNumber(number)
                ? $"{number} is a valid NHS number."
                : $"{number} is NOT a valid NHS number.");
        }
    }
}
