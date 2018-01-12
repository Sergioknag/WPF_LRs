using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using LR9.DataLayer.EFContext;
using LR9.DataLayer.Entities;
using LR9.DataLayer.Interfaces;

namespace LR9.DataLayer.Repositories
{
    // Для удобства работы с базой данных создадим классы репозиториев,
    // реализующих базовые операции CRUD (Create-Read-Update-Delete).
    class CarsRepository : IRepository<Car>
    {
        SellersContext context;
        public CarsRepository(SellersContext context)
        {
            this.context = context;
        }
        public void Create(Car t)
        {
            context.Cars.Add(t);
        }

        public void Delete(int id)
        {
            var car = context.Cars.Find(id);
            context.Cars.Remove(car);
        }

        public IEnumerable<Car> Find(Func<Car, bool> predicate)
        {
            return context.Cars.Where(predicate).ToList();
        }

        public Car Get(int id)
        {
            return context.Cars.Find(id);
        }

        public IEnumerable<Car> GetAll()
        {
            return context.Cars;
        }

        public void Update(Car t)
        {
            context.Entry<Car>(t).State = EntityState.Modified;
        }
    }
}
