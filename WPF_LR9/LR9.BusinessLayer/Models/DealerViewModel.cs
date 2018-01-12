using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace LR9.BusinessLayer.Models
{
    public class DealerViewModel
    {
        public int DealerId { get; set; }
        public string DealerName { get; set; }
        public string DealerAdress { get; set; }
        public string DealerURL { get; set; }
        public ObservableCollection<CarViewModel> Cars { get; set; }
    }
}
