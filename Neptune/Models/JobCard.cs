using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptune.Models
{
    public sealed class JobCard : ModelBase
    {
        private OrderItem _orderItem;
        public OrderItem OrderItem
        {
            get => _orderItem;
            set => SetProperty(ref _orderItem, value);
        }

        private int _dozens;
        public int Dozens
        {
            get => _dozens;
            set => SetProperty(ref _dozens, value);
        }

        private Worker _qa;
        public Worker Qa
        {
            get => _qa;
            set => SetProperty(ref _qa, value);
        }

        private Worker _tier;
        public Worker Tier
        {
            get => _tier;
            set => SetProperty(ref _tier, value);
        }

        private DateTime? _tieDateCompleted;
        public DateTime? TieDateCompleted
        {
            get => _tieDateCompleted;
            set => SetProperty(ref _tieDateCompleted, value);
        }

        private Worker _packer;
        public Worker Packer
        {
            get => _packer;
            set => SetProperty(ref _packer, value);
        }

        private DateTime? _packDateComplete;
        public DateTime? PackDateComplete
        {
            get => _packDateComplete;
            set => SetProperty(ref _packDateComplete, value);
        }
    }
}
