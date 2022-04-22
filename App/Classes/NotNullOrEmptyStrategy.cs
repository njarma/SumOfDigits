using System;
using SumOfDigits.Interfaces;

namespace SumOfDigits.Classes
{
    public class NotNullOrEmptyStrategy: IValidateStrategy
    {
        public bool Validate(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                Console.WriteLine("You have to set a valid number");
                return false;
            }
            return true;
        }
    }
}
