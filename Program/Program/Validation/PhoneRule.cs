using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Курсовой_проект.Validation
{
    class PhoneRule : ValidationRule
    {
       public bool IsPhoneNumber(string input, string pattern)
        {
            if (input.Length != pattern.Length) return false;
            for (int i = 0; i < input.Length; ++i)
            {
                bool ith_character_ok;
                if (Char.IsDigit(pattern, i))
                    ith_character_ok = Char.IsDigit(input, i);
                else
                    ith_character_ok = (input[i] == pattern[i]);
                if (!ith_character_ok) return false;
            }
            return true;
        }
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            string number = string.Empty;
            if (value != null)
            {
                number = value.ToString();
                number.Trim();
            }
            else
                return new ValidationResult(false, " Номер телефона не задан! ");
            if ((number.All(char.IsDigit) == true) && (number.All(char.IsLetter) == false) && IsPhoneNumber(number, "80000000000"))
            {
                return new ValidationResult(true, null);
            }
            else
            {
                return new ValidationResult(false, " Номер телефона должен содержать символы 8 и длина 11\n Шаблон номера: 8XXXXXXXXXX ");
            }
        }
    }
}
