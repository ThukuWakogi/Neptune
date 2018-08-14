using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptune.Models
{
    public class Fly : ModelBase
    {
        private string _flyName;
        public string FlyName
        {
            get => _flyName;
            set => SetProperty(ref _flyName, value);
        }

        private FlyPattern _flyPattern;
        public FlyPattern FlyPattern
        {
            get => _flyPattern;
            set => SetProperty(ref _flyPattern, value);
        }

        private List<Material> _materials;
        public List<Material> Materials
        {
            get => _materials;
            set => SetProperty(ref _materials, value);
        }
    }
}
