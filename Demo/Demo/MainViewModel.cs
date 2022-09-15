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
class MainViewModel : ViewModelBase
    {
        public RelayCommand Order { get; set; }
        public MainViewModel()
        {
            Order = new RelayCommand(() =>
            {
                try
                {
                    PlacedOrders.Add(new PlacedOrder() { Order = JsonConvert.SerializeObject(CurrentOrder) });
                }
                catch (Exception)
                {

                    throw;
                }
            });
        }

        public BindingList<PlacedOrder> PlacedOrders { get; set; } = new BindingList<PlacedOrder>();

        private List<Material> _materials = new List<Material>() {
            new Material(){Name ="M1" , AddedValue=1},
            new Material(){Name ="M2" , AddedValue = 2},
            new Material(){Name ="M3", AddedValue = 3}
        };

        public List<Material> Materials
        {
            get { return _materials; }
            set { _materials = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Color> _colors = new ObservableCollection<Color>()
        {
            Brushes.Brown.Color,
            Brushes.Red.Color,
            Brushes.Green.Color
        };
        public ObservableCollection<Color> Colors
        {
            get { return _colors; }
            set { _colors = value; OnPropertyChanged(); }
        }
        private OrderViewModel _currentOrder = new OrderViewModel();

        public OrderViewModel CurrentOrder
        {
            get { return _currentOrder; }
            set
            {
                _currentOrder = value;
                OnPropertyChanged();
            }
        }


    }
}