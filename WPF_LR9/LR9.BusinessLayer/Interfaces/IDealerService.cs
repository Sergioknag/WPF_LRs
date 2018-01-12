using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using LR9.BusinessLayer.Models;

namespace LR9.BusinessLayer.Interfaces
{
    // интерфейс для работы с диллерами
    public interface IDealerService
    {
        ObservableCollection<DealerViewModel> GetAll();
        DealerViewModel Get(int id);
        void AddCarToDealer(int dealerId, CarViewModel car);
        void RemoveCarFromDealer(int dealerId, int carId);
        void UpdateCar(CarViewModel car);
        void CreateDealer(DealerViewModel dealerId);
        void DeleteDealer(int dealerId);
        void UpdateDealer(DealerViewModel dealer);
    }
}
