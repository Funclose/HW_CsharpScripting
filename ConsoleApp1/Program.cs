using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Scripting;
namespace ConsoleApp1
{
     class Program
    {
        static async Task Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine("введите математическое выражение: ");
                string input = Console.ReadLine();

                if (input.ToLower() == "exit")
                {
                    break;
                }

                try
                {
                    var result = await CalculatedExpression(input);
                    Console.WriteLine($"result :{result}");
                }
                 catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            }
        }

        static async Task<double> CalculatedExpression(string exrp)
        {
            var option = ScriptOptions.Default
                .AddReferences(typeof(Math).Assembly)
                .AddImports("System", "System.Math");
            return await CSharpScript.EvaluateAsync<double>(exrp, option);
        }
    }
}
