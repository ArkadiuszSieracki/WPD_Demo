using System.ComponentModel;

namespace Demo
{
    public interface ICustomProperty : INotifyPropertyChanged
    {
        public string GroupingElement { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public int TimeImpact { get; set; }
        public int PriceImpact { get; set; }
    }
}