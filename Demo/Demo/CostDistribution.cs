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
    class CostDistribution : ViewModelBase
    {
        private IGrouping<string, CustomProperty> group;
        private BindingList<CustomProperty> customProperties;
        public string GroupKey { get { return group.Key; } }
        public CostDistribution(IGrouping<string, CustomProperty> group, BindingList<CustomProperty> customProperties, bool addSingleItems = true)
        {
            this.group = group;
            foreach (var item in customProperties)
            {
                item.PropertyChanged += ItemPropertyChanged;
            }
            this.customProperties = customProperties;
            if (addSingleItems)
            {
                SingleItems = new BindingList<CostDistribution>(group.GroupBy(o => o.Name).Select(o => new CostDistribution(o, new BindingList<CustomProperty>(group.ToList()), false)).ToList());
            }
        }

        private void ItemPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(nameof(TimeValue));
            OnPropertyChanged(nameof(PriceValue));
        }

        public double TimeValue
        {
            get
            {
                return (double)(((double)group.Sum(o => o.TimeImpact) / (double)customProperties.Sum(o => o.TimeImpact)));
            }
        }

        public double PriceValue
        {
            get
            {
                return (double)(((double)group.Sum(o => o.PriceImpact) / (double)customProperties.Sum(o => o.PriceImpact)));
            }
        }

        public BindingList<CostDistribution> SingleItems { get; set; }
    }
}