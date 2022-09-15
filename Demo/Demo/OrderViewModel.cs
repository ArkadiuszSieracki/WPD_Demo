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
    internal class OrderViewModel : ViewModelBase
    {
        public Material SelectedMaterial
        {
            get => selectedMaterial; set
            {
                selectedMaterial = value;
                OnPropertyChanged();
            }
        }

        private Color _selectedBrush;
        private Material selectedMaterial;
        private string zipCode;
       
        public Color SelectedBrush
        {
            get { return _selectedBrush; }
            set { _selectedBrush = value; OnPropertyChanged(); }
        }

        public string ZipCode
        {
            get => zipCode; set
            {
                zipCode = value;
                OnPropertyChanged();
            }
        }

        private string projectName;

        public string ProjectName
        {
            get { return projectName; }
            set { projectName = value; OnPropertyChanged(); }
        }

        public int BoardsQuantity { get; set; }
        public decimal Thickness { get; set; }

        public BindingList<CustomProperty> CustomProperties { get; set; } = new BindingList<CustomProperty>()
        {
            new CustomProperty(){ GroupingElement = "Group1", Name = "Something", TimeImpact=1, PriceImpact=100},
            new CustomProperty(){ GroupingElement = "Group1", Name = "Something 1", TimeImpact=2, PriceImpact=200},
            new CustomProperty(){ GroupingElement = "Group2", Name = "Something", TimeImpact=3, PriceImpact=300},
        };
        BindingList<CostDistribution> costDistributions;
        public BindingList<CostDistribution> CostDistributions
        {
            get
            {
                if (costDistributions is null)
                {
                    var groups = CustomProperties.GroupBy(o => o.GroupingElement);
                    costDistributions = new BindingList<CostDistribution>(groups.Select(o => new CostDistribution(o, CustomProperties)).ToArray());
                }
                return costDistributions;
            }
        }

    }
}