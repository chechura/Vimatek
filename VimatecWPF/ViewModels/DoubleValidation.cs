using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace VimatecWPF
{
    public class DoubleValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value is string)
            {
                double number;
                if (!Double.TryParse((value as string), out number))
                    return new ValidationResult(false, "Please enter a valid number");                
                if ( number<0)
                    return new ValidationResult(false, "Please enter a valid number");
                if (number >65535)
                    return new ValidationResult(false, "Please enter a valid number");
                
            }

            return ValidationResult.ValidResult;
        }
    }
}
