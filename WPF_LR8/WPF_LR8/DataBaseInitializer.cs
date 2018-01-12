using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WPF_LR8
{
    class DataBaseInitializer : DropCreateDatabaseIfModelChanges<EntityContext>
    {
        protected override void Seed(EntityContext context)
        {
            context.Cars.AddRange(new Car[]
            {
                new Car {Model="Mazda 6", Year=2010, Color="Red", Price=15000, EngineVolume="2,5"},
                new Car {Model="Audi A8", Year=2017, Color="White", Price=99000, EngineVolume="4,2"},
                new Car {Model="Honda Odyssey", Year=2014, Color="Grey", Price=43000, EngineVolume="3,5"},
                new Car {Model="VW Golf", Year=2015, Color="Yellow", Price=14000, EngineVolume="1,4"},
                new Car {Model="Opel Ascona", Year=1987, Color="Purple", Price=500, EngineVolume="1,6"},
                new Car {Model="ВАЗ 2106", Year=1990, Color="Green", Price=300, EngineVolume="1,5"},
                new Car {Model="Ford Tunderbird", Year=1974, Color="Red", Price=55000, EngineVolume="5,0"}
            });
        }
    }
}
