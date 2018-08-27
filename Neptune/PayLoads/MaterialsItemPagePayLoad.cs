using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neptune.Models;

namespace Neptune.PayLoads
{
    public class MaterialsItemPagePayLoad : ObservableModel
    {
        private MaterialCategory _materialCategory = new MaterialCategory();
        public MaterialCategory MaterialCategory
        {
            get => _materialCategory;
            set => SetProperty(ref _materialCategory, value);
        }

        public MaterialsItemPagePayLoad(MaterialCategory materialCategory) => MaterialCategory = materialCategory;
    }
}
