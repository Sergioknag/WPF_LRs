using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR9.DataLayer.Entities
{
    public class Car
    {
        public int CarId { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public string EngineVolume { get; set; }
        public string CarImageFileName { get; set; }
        // Навигационные свойства
        public int DealerId { get; set; }
        public Dealer Dealer { get; set; }
    }
}
