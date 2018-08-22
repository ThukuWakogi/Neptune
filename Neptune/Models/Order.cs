using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptune.Models
{
    public class Order : ModelBase
    {
        private Customer _customer;
        public Customer Customer
        {
            get => _customer;
            set => SetProperty(ref _customer, value);
        }

        private List<OrderItem> _orderItems;
        public List<OrderItem> OrderItems
        {
            get => _orderItems;
            set => SetProperty(ref _orderItems, value);
        }

        public Order() => OrderItems = new List<OrderItem>();

        public string DisplayOrderNo { get => $"Order No.{Id}"; }
        public string DisplayOrderItemNumber { get => (OrderItems.Count == 1) ? $"{OrderItems.Count} item" : $"{OrderItems.Count} items"; }
    }
}
