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
    public class CustomProperty : ViewModelBase, ICustomProperty
    {
        private int _timeImpact;
        private int _priceImpact;
        public string GroupingElement { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public int TimeImpact
        {
            get => _timeImpact; set
            {
                _timeImpact = value;
                OnPropertyChanged();
            }
        }

        public int PriceImpact
        {
            get => _priceImpact; set
            {
                _priceImpact = value;
                OnPropertyChanged();
            }
        }
    }
}