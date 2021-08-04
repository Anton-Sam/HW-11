using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace hw_15.Task01
{
    [AttributeUsage(AttributeTargets.Property)]
    class MyCreditCardAttribute : ValidationAttribute
    {
        public MyCreditCardAttribute()
        {
            ErrorMessage = "The field value is not a valid credit card number.";
        }
        public override bool IsValid(object value)
        {
            string creditCard = value as string;
            if (creditCard.Length < 13 || creditCard.Length > 19)
                return false;

            int[] digitArray = new int[creditCard.Length - 1];
            int lastDigit;

            if (!int.TryParse(creditCard[creditCard.Length - 1].ToString(), out lastDigit))
                return false;
            for (var i = 0; i < digitArray.Length; i++)
                if (!int.TryParse(creditCard[i].ToString(), out digitArray[i]))
                    return false;

            digitArray.Reverse();
            for (var i = 0; i < digitArray.Length; i++)
            {
                digitArray[i] = i % 2 == 0 ? digitArray[i] * 2 : digitArray[i];
                digitArray[i] = digitArray[i] > 9 ? digitArray[i] - 9 : digitArray[i];
            }
            return (digitArray.Sum() + lastDigit) % 10 == 0;
        }
    }
}
