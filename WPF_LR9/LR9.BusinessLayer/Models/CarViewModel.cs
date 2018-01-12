using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR9.BusinessLayer.Models
{
    public class CarViewModel
    {
        public int CarId { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public string EngineVolume { get; set; }
        public string CarImageFileName { get; set; }
    }
}
