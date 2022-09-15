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
    public class GroupStateViewModel : ViewModelBase
    {
        public CollectionViewGroup Group { get; set; }

        internal void Init(CollectionViewGroup group)
        {
            lock (this)
            {
                if (Group == null)
                {
                    Group = group;
                    foreach (ICustomProperty item in Group.Items)
                    {
                        item.PropertyChanged -= ItemPropertyChanged;
                        item.PropertyChanged += ItemPropertyChanged;
                    }
                    RecalculateSums();
                }
            }

        }
        private void RecalculateSums()
        {
            OnPropertyChanged(nameof(TimeImpactSum));
            OnPropertyChanged(nameof(PriceImpactSum));
        }
        private void ItemPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            RecalculateSums();
        }

        public int TimeImpactSum
        {
            get
            {
                if (Group != null)
                {
                    var sum = 0;
                    foreach (ICustomProperty item in Group.Items)
                    {
                        sum += item.TimeImpact;
                    }
                    return sum;
                }
                return 0;
            }
        }

        public int PriceImpactSum
        {
            get
            {
                if (Group != null)
                {
                    var sum = 0;
                    foreach (ICustomProperty item in Group.Items)
                    {
                        sum += item.PriceImpact;
                    }
                    return sum;
                }
                return 0;
            }
        }
    }
}