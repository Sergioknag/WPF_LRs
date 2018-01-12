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
    class DealersRepository : IRepository<Dealer>
    {
        SellersContext context;
        public DealersRepository(SellersContext context)
        {
            this.context = context;
        }

        public void Create(Dealer t)
        {
            context.Dealers.Add(t);
        }

        public void Delete(int id)
        {
            var dealer = context.Dealers.Find(id);
            context.Dealers.Remove(dealer);
        }

        public IEnumerable<Dealer> Find(Func<Dealer, bool> predicate)
        {
            return context.Dealers.Include(v => v.Cars).Where(predicate).ToList();
        }

        public Dealer Get(int id)
        {
            return context.Dealers.Find(id);
        }

        public IEnumerable<Dealer> GetAll()
        {
            return context.Dealers.Include(v => v.Cars);
        }

        public void Update(Dealer t)
        {
            context.Entry<Dealer>(t).State = EntityState.Modified;
        }
    }
}
