using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptune.Models
{
    public sealed class Worker : Person
    {
        private string _phoneNumber;
        public string PhoneNumber
        {
            get => _phoneNumber;
            set => SetProperty(ref _phoneNumber, value);
        }

        private Position _position;
        public Position Position
        {
            get => _position;
            set => SetProperty(ref _position, value);
        }

        public string DisplayFullNameAndPosition { get => $"{_position.PositionName}: {FullName}"; }
    }
}
