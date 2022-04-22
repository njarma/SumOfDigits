using SumOfDigits.Interfaces;
using System;

namespace SumOfDigits.Classes
{
    public class Number: INumber
    {
        public readonly IValidation _validation;
        public Number(IValidation validation)
        {
            _validation = validation;
        }
        public double Value { get; private set; }

        public double AuxValue { get; private set; } = 0;

        public double Sum { get; private set; } = 0;

        public string Input { get; private set; } = "";

        public void SetValue(double value)
        {
            Value = AuxValue = value;
        }

        public void SetInput(string input)
        {
            if (ValidInput(input))
            {
                Input = input;
            }
        }

        public void SetSum(double sum)
        {
            Sum = sum;
        }

        public void SetAuxValue(double value)
        {
            AuxValue = value;
        }

        public int Execute(string input)
        {
            var result = 0;
            if (ValidInput(input))
            {
                SetInput(input);
                SetValue(Convert.ToDouble(Input));
                result = DigitalRoot();
                Console.WriteLine($"The final sum is: {result}");
            }
            return result;
        }

        public bool ValidInput(string value)
        {
            _validation.Set(new NotNullOrEmptyStrategy());
            _validation.Set(new PositiveInputStrategy());
            
            return _validation.Validate(value);
        }

        public int DigitalRoot(double newValue = 0)
        {
            SetSum(0);

            if (newValue > 0)
            {
                SetValue(newValue);
            }

            Console.WriteLine($"The input number is: {Value}");
            while (Value.ToString().Length > 1)
            {
                SplitDigit();
                if (Sum.ToString().Length > 1)
                {
                    DigitalRoot(Sum);
                }
                else
                {
                    return (int)Sum;
                }
            }
            Console.WriteLine("The input number have already only 1 digit");
            return (int)Value;
        }

        private void SplitDigit()
        {
            while (AuxValue > 0)
            {
                var digit = AuxValue % 10;
                SetAuxValue(Math.Truncate(AuxValue / 10));
                SetSum(Sum + (int)digit);
            }
        }
    }
}
