using System;
using SumOfDigits.Interfaces;

namespace SumOfDigits.Classes
{
    public class PositiveInputStrategy: IValidateStrategy
    {
        public bool Validate(string value)
        {
            if (Convert.ToInt64(value) < 0)
            {
                Console.WriteLine("Number have to be positive");
                return false;
            }
            return true;
        }
    }
}
