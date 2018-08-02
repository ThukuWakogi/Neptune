using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptune.Models
{
    public sealed class Position : ModelBase
    {
        private string _position;
        public string PositionName
        {
            get => _position;
            set => SetProperty(ref _position, value);
        }

        private decimal _salary;
        public decimal Salary
        {
            get => _salary;
            set => SetProperty(ref _salary, value);
        }
    }
}
