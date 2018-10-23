using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptune.Models
{
    public class OrderItem : ModelBase
    {
        private Fly _fly;
        public Fly Fly
        {
            get => _fly;
            set => SetProperty(ref _fly, value);
        }

        private int _flySize;
        public int FlySize
        {
            get => _flySize;
            set => SetProperty(ref _flySize, value);
        }

        private decimal _dozens;
        public decimal Dozens
        {
            get => _dozens;
            set => SetProperty(ref _dozens, value);
        }

        private bool _isComplete;
        public bool IsComplete
        {
            get => _isComplete;
            set => SetProperty(ref _isComplete, value);
        }

        public string DisplayFlySizeWithHash { get => $"#{_flySize}"; }
        public string DisplayOrderTimeNameWithLabel { get => $"Order Item: {Fly.FlyName}"; }
    }
}
