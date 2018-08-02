using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptune.Models
{
    public sealed class Modify
    {
        public int Id { get; set; }

        private string _firstName;
        public string FirstName
        {
            get => _firstName;
            set => _firstName = value ?? throw new ArgumentException(nameof(FirstName) + "cannot be null");
        }

        private string _lastName;
        public string LastName
        {
            get => _lastName;
            set => _lastName = value ?? throw new ArgumentException(nameof(FirstName) + "cannot be null");
        }

        private string _PhoneNumber;
        public string PhoneNumber
        {
            get => _PhoneNumber;
            set => _PhoneNumber = value ?? throw new ArgumentException(nameof(PhoneNumber) + "cannot be null");
        }

        private Position _position;
        public Position Position
        {
            get => _position;
            set => _position = value ?? throw new ArgumentException(nameof(Position) + "cannot be null");
        }
    }
}
