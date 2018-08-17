using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptune.Models
{
    public class Material : ModelBase
    {
        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private Decimal _quantity;
        public Decimal Quantity
        {
            get => _quantity;
            set => SetProperty(ref _quantity, value);
        }

        private Decimal _depletionAlertLevel;
        public Decimal DepletionAlertLevel
        {
            get => _depletionAlertLevel;
            set => SetProperty(ref _depletionAlertLevel, value);
        }
    }
}
