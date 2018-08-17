using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptune.Models
{
    public class FlyMaterial : ModelBase
    {
        private Material _material;
        public Material Material
        {
            get => _material;
            set => SetProperty(ref _material, value);
        }

        private string _flyPart;
        public string FlyPart
        {
            get => _flyPart;
            set => SetProperty(ref _flyPart, value);
        }
    }
}
