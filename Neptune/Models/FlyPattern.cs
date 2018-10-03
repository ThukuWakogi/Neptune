using Neptune.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptune.Models
{
    public class FlyPattern : ModelBase
    {
        private string _flyPatternName;
        public string FlyPatternName
        {
            get => _flyPatternName;
            set => SetProperty(ref _flyPatternName, value);
        }

        public string DisplayNumberOfFliesInPattern
        {
            get => 
                (AppShell.Flies.Count(x => x.FlyPattern.Id == Id) == 1) ? $"{AppShell.Flies.Count(x => x.FlyPattern.Id == Id)} fly" : $"{AppShell.Flies.Count(x => x.FlyPattern.Id == Id)} flies";
        }
    }
}
