using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_LR8
{
    class EntityContext : DbContext
    {
        public EntityContext(string CarDbConnection) : base(CarDbConnection)
        {
            Database.SetInitializer(new DataBaseInitializer());
        }
        public DbSet<Car> Cars { get; set; }
    }
}
