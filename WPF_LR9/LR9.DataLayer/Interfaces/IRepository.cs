using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR9.DataLayer.Interfaces
{
    // обобщенный интерфейс, описывающий репозиторий
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();//Метод GetAll возвращает список всех объектов типа <T>.
        T Get(int id);//Метод Get ищет объект в базе данных по заданному id.
        //Метод Find осуществляет поиск объекта, удовлетворяющего условию predicate.
        IEnumerable<T> Find(Func<T, bool> predicate);
        void Create(T t);//Метод Create добавляет объект типа<T> в базу данных.
        void Update(T t);//Метод Update принимает измененный объект типа <T> и вносит изменения в базу данных.
        void Delete(int id);
    }
    
    
    
    
    
}
