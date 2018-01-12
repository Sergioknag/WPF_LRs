using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LR9.DataLayer.Entities;
using LR9.DataLayer.Interfaces;
using LR9.DataLayer.EFContext;

namespace LR9.DataLayer.Repositories
{
    // Данный класс работает с БД через классы EntityFramework
    public class EFUnitOfWork : IUnitOfWork
    {
        SellersContext context;
        DealersRepository dealersRepo;
        CarsRepository carsRepo;

        public EFUnitOfWork(string name)
        {
            context = new SellersContext(name);
        }

        public IRepository<Dealer> Dealers
        {
            get
            {
                if (dealersRepo==null)
                {
                    dealersRepo = new DealersRepository(context);
                }
                return dealersRepo;
            }
        }

        public IRepository<Car> Cars
        {
            get
            {
                if (carsRepo==null)
                {
                    carsRepo = new CarsRepository(context);
                }
                return carsRepo;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        // Реализация интерфейса IDisposable

        // Flag: Has Dispose already been called?
        private bool disposed = false;

        // Protected implementation of Dispose pattern.
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                this.disposed = true;
            }
        }

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
