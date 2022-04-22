using SumOfDigits.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SumOfDigits.Classes
{
    public class Validation: IValidation
    {
        private readonly List<IValidateStrategy> _validations = new();
        public void Set(IValidateStrategy validation)
        {
            _validations.Add(validation);
        }

        public bool Validate(string value)
        {
            var validation = _validations.AsEnumerable()
                        .All(x => x.Validate(value));

            return validation;
        }
    }
}