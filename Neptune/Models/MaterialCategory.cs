using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptune.Models
{
    public class MaterialCategory : ModelBase
    {
        private string _category;
        public string Category
        {
            get => _category;
            set => SetProperty(ref _category, value);
        }

        private List<Material> _materials;
        public List<Material> Materials
        {
            get => _materials;
            set => SetProperty(ref _materials, value);
        }
    }
}
