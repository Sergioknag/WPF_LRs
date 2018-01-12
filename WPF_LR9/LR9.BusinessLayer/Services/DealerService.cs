using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LR9.BusinessLayer.Interfaces;
using LR9.BusinessLayer.Models;
using LR9.DataLayer.Entities;
using LR9.DataLayer.Interfaces;
using LR9.DataLayer.Repositories;

namespace LR9.BusinessLayer.Services
{
    // В этом классе для преобразования объектов Entities из уровня
    //доступа к данным в объекты ViewModel и обратно
    //используем библиотеку AutoMapper
    public class DealerService : IDealerService
    {
        IUnitOfWork dataBase;
        public DealerService(string name)
        {
            dataBase = new EFUnitOfWork(name);
        }

        public void AddCarToDealer(int dealerId, CarViewModel car)
        {
            var dealer = dataBase.Dealers.Get(dealerId);
            // Конфигурирование AutoMapper
            Mapper.Initialize(cfg => cfg.CreateMap<CarViewModel, Car>());
            // Отображение объекта CarViewModel на объект Car
            var c = Mapper.Map<Car>(car);
            // добавить авто
            dealer.Cars.Add(c);
            dataBase.Save();
        }

        public void CreateDealer(DealerViewModel dealerId)
        {
            throw new NotImplementedException();
        }

        public void DeleteDealer(int dealerId)
        {
            throw new NotImplementedException();
        }

        public DealerViewModel Get(int id)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<DealerViewModel> GetAll()
        {
            // Конфигурирование AutoMapper
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Dealer, DealerViewModel>();
                cfg.CreateMap<Car, CarViewModel>();
            });
            // отображение List<Dealer> на ObservaibleCollection<DealerViewModel>
            var dealers = Mapper.Map<ObservableCollection<DealerViewModel>>(dataBase.Dealers.GetAll());
            return dealers;
        }

        public void RemoveCarFromDealer(int dealerId, int carId)
        {
            dataBase.Cars.Delete(carId);
            dataBase.Save();
        }

        public void UpdateDealer(DealerViewModel dealer)
        {
            throw new NotImplementedException();
        }

        public void UpdateCar(CarViewModel car)
        {
            // Конфигурирование AutoMapper
            Mapper.Initialize(cfg => cfg.CreateMap<CarViewModel, Car>());
            //Отображение объекта CarViewModel на объект Car
            var c = Mapper.Map<Car>(car);
            dataBase.Cars.Update(c);
            //dataBase.Save();
        }
    }
}
