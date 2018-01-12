using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using LR9.DataLayer.Entities;

namespace LR9.DataLayer.EFContext
{
    // класс контекста данных
    public class SellersContext : DbContext
    {
        public SellersContext(string name) :base(name)
        {
            Database.SetInitializer(new SellersInitializer());
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Dealer> Dealers { get; set; }
    }
}
