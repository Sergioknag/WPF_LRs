using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LR9.DataLayer.Entities;

namespace LR9.DataLayer.Interfaces
{
    // Каждый репозиторий работает с контекстом Entity Framework.
    //Для того, чтобы этот контекст был один для всех репозиториев,
    // используем шаблон проектирования Unit Of Work.
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Dealer> Dealers { get; }
        IRepository<Car> Cars { get; }
        void Save();
        // Как видим, Unit of Work должен создавать и возвращать репозитории,
        //а также сохранять изменения в базе данных.
        // Внутри класса будет создан один объект контекста для всех репозиториев.
    }
}
