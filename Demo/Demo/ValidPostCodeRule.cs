using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace Demo
{
    public class ValidPostCodeRule : ValidationRule
    {


        public ValidPostCodeRule()
        {
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value != null && Regex.IsMatch(value.ToString(), "\\d\\d-\\d{3}") == false)
            {
                return new ValidationResult(false,
               $"valid post code format is dd-ddd");
            }



            return ValidationResult.ValidResult;
        }
    }
}