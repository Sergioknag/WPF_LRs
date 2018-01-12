using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LR9.BusinessLayer.Interfaces;
using LR9.BusinessLayer.Models;
using LR9.BusinessLayer.Services;
using System.Collections.ObjectModel;
using WPF_LR9.Dialogs;

namespace WPF_LR9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Привязка подробной информации о диллере и списка авто
        //осуществляется к свойству SelectedItem элемента ComboBox
        ObservableCollection<DealerViewModel> dealers;
        IDealerService dealerService;
        public MainWindow()
        {
            InitializeComponent();
            dealerService = new DealerService("TestDbConnection");
            dealers = dealerService.GetAll();
            cBoxDealer.DataContext = dealers;
        }

        private void btnAutoAdd_Click(object sender, RoutedEventArgs e)
        { 
            EditWindow editWin = new EditWindow();
            if (editWin.ShowDialog()==true)
            {
                if (editWin.DialogResult==true)
                {
                    var car = new CarViewModel();
                    car.Model = editWin.tbModel.Text;
                    car.Year = int.Parse(editWin.tbYear.Text);
                    car.Color = editWin.tbColor.Text;
                    car.EngineVolume = editWin.tbEngine.Text;
                    car.Price = decimal.Parse(editWin.tbPrice.Text);
                    car.CarImageFileName = editWin.tbFile.Text;
                    var dealer = (DealerViewModel)cBoxDealer.SelectedItem;
                    dealer.Cars.Add(car);
                    dealerService.AddCarToDealer(dealer.DealerId, car);
                }
            }
        }

        private void btnAutoRemove_Click(object sender, RoutedEventArgs e)
        {
            var dealer = (DealerViewModel)cBoxDealer.SelectedItem;
            var car = (CarViewModel)lBox.SelectedItem;
            dealer.Cars.Remove(car);
            dealerService.RemoveCarFromDealer(dealer.DealerId, car.CarId);
        }

        private void btnAutoEdit_Click(object sender, RoutedEventArgs e)
        {
            EditWindow editWin = new EditWindow();
            var car = (CarViewModel)lBox.SelectedItem;
            var dealer = (DealerViewModel)cBoxDealer.SelectedItem;
            editWin.tbModel.Text = car.Model;
            editWin.tbYear.Text = car.Year.ToString();
            editWin.tbColor.Text = car.Color.ToString();
            editWin.tbPrice.Text = car.Price.ToString();
            editWin.tbEngine.Text = car.EngineVolume;
            editWin.tbFile.Text = car.CarImageFileName;
            if (editWin.ShowDialog()==true)
            {
                if (editWin.DialogResult==true)
                {
                    car.Model = editWin.tbModel.Text;
                    car.Year = int.Parse(editWin.tbYear.Text);
                    car.Color = editWin.tbColor.Text;
                    car.EngineVolume = editWin.tbEngine.Text;
                    car.Price = decimal.Parse(editWin.tbPrice.Text);
                    car.CarImageFileName = editWin.tbFile.Text;
                    //?????????????
                    //dealerService.UpdateCar(car);
                }
            }
        }
    }
}
