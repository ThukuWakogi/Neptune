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
        private Fly Fly
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
        public string FlySizeWithHash { get => $"#{_flySize}"; }

        private Decimal _quantity;
        public Decimal Quantity
        {
            get => _quantity;
            set => SetProperty(ref _quantity, value);
        }

        private bool _isComplete;
        public bool IsComplete
        {
            get => _isComplete;
            set => SetProperty(ref _isComplete, value);
        }
    }
}
