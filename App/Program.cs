using SumOfDigits.Classes;
using SumOfDigits.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace SumOfDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            //setup DI
            var serviceProvider = new ServiceCollection()
                .AddSingleton<INumber, Number>()
                .BuildServiceProvider();

            var number = serviceProvider.GetService<INumber>();
            Console.WriteLine("Enter the number:");
            number.Execute(Console.ReadLine());
        }
    }
}
