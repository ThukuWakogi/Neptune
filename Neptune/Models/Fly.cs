using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptune.Models
{
    public class Fly : ModelBase
    {
        private string _flyNumber;
        public string FlyNumber
        {
            get => _flyNumber;
            set => SetProperty(ref _flyNumber, value);
        }

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

        private List<FlyMaterial> _materials;
        public List<FlyMaterial> Materials
        {
            get => _materials;
            set => SetProperty(ref _materials, value);
        }

        public Fly()
        {
            Materials = new List<FlyMaterial>();
        }
    }
}
