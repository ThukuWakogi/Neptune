using Neptune.Views;
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

        public string DisplayTiersInPosition
        {
            get => (AppShell.Workers.Count(x => x.Position.Id == Id) == 1) 
                ? $"{AppShell.Workers.Count(x => x.Position.Id == Id)} tier" 
                : $"{AppShell.Workers.Count(x => x.Position.Id == Id)} tiers";
        }

        public string DisplaySalary { get => $"Salary: {_salary}/-"; }
    }
}
