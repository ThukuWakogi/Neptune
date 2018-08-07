using Neptune.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptune.PayLoads
{
    public class WorkersPagePayload
    {
        public int UserID { get; set; }
        public ObservableCollection<Modifier> Modifiers { get; set; }
        public ObservableCollection<Position> Positions { get; set; }
        public ObservableCollection<Worker> Workers { get; set; }
    }
}
