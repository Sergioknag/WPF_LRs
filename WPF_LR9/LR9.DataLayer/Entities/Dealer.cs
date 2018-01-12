using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR9.DataLayer.Entities
{
    public class Dealer
    {
        public int DealerId { get; set; }
        public string DealerName { get; set; }
        public string DealerAdress { get; set; }
        public string DealerURL { get; set; }
        // навигационное свойтво
        public List<Car> Cars { get; set; }
    }
}
