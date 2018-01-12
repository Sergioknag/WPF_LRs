using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using LR9.DataLayer.Entities;

namespace LR9.DataLayer.EFContext
{
    // класс инициализации данных
    public class SellersInitializer : CreateDatabaseIfNotExists<SellersContext>
    {
        protected override void Seed(SellersContext context)
        {
            context.Dealers.AddRange(new Dealer[] {
                new Dealer { DealerName="Автосалон AV",
                            DealerAdress ="г. Минск, ул. Серова 5",
                            DealerURL ="www.audi.by",
                            Cars =new List<Car>
                            {
                                new Car{Model="Audi A4", Year=2017, Color="Silver", EngineVolume="1,8", Price=34000 ,CarImageFileName="audi-a4.jpg"},
                                new Car{Model="Audi A7", Year=2017, Color="Silver", EngineVolume="3,0", Price=54800 ,CarImageFileName="audi-a7.jpg"},
                                new Car{Model="Audi A8", Year=2017, Color="Red", EngineVolume="4,2", Price=89300 ,CarImageFileName="Audi-A8.jpg"},
                                new Car{Model="Audi Q7", Year=2017, Color="White", EngineVolume="3,0", Price=71400 ,CarImageFileName="Audi-Q7.jpg"}
                            }
                },
                new Dealer { DealerName="Энергия Гмбх",
                            DealerAdress ="г. Минск, ул. Тимирязева 43",
                            DealerURL ="www.mercedes-benz.by",
                            Cars =new List<Car>
                            {
                                new Car{Model="Mercedes E300", Year=2016, Color="Black", EngineVolume="3,0", Price=48000 ,CarImageFileName="mercedes-e.jpg"},
                                new Car{Model="Mercedes S600", Year=2017, Color="Red", EngineVolume="5,5", Price=86300 ,CarImageFileName="mercedes-S.jpg"},
                                new Car{Model="Mercedes S63 AMG", Year=2017, Color="White", EngineVolume="5,6", Price=99400 ,CarImageFileName="mercedes-s63.jpg"}
                            }
                },
                new Dealer { DealerName="Холпи Авто",
                            DealerAdress ="г. Минск, ул. Лещинского 2",
                            DealerURL ="www.mazda.by",
                            Cars =new List<Car>
                            {
                                new Car{Model="Mazda 3", Year=2016, Color="Black", EngineVolume="1,8", Price=22000 ,CarImageFileName="mazda3.jpg"},
                                new Car{Model="Mazda 6", Year=2017, Color="Silver", EngineVolume="2,5", Price=27800 ,CarImageFileName="mazda6.jpeg"},
                                new Car{Model="Mazda CX-5", Year=2017, Color="White", EngineVolume="2,0", Price=31400 ,CarImageFileName="mazdaCX-5.jpg"}
                            }
                }
            });
            context.SaveChanges();
        }
    }
}
