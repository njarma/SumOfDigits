namespace SumOfDigits.Interfaces
{
    public interface IValidation
    {
        public bool Validate(string value);

        public void Set(IValidateStrategy validation);
    }
}

