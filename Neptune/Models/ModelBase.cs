using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptune.Models
{
    public abstract class ModelBase : ObservableModel
    {
        protected int _id;
        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        protected DateTime _dateAdded;
        public DateTime DateAdded
        {
            get => _dateAdded;
            set => SetProperty(ref _dateAdded, value);
        }

        protected Modifier _addedBy;
        public Modifier AddedBy
        {
            get => _addedBy;
            set => SetProperty(ref _addedBy, value);
        }

        protected DateTime _dateLastUpdated;
        public DateTime DateLastUpdated
        {
            get => _dateLastUpdated;
            set => SetProperty(ref _dateLastUpdated, value);
        }

        protected Modifier _lastUpdatedBy;
        public Modifier LastUpdatedBy
        {
            get => _lastUpdatedBy;
            set => SetProperty(ref _lastUpdatedBy, value);
        }
    }
}
