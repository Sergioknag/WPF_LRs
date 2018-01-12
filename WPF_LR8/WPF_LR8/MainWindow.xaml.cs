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
using System.Data.Entity;

namespace WPF_LR8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EntityContext context;

        public MainWindow()
        {
            context = new EntityContext("CarDbConnection");
            InitializeComponent();
            InitCarList();
        }

        private void InitCarList()
        {
            context.Cars.Load();
            dGrid.DataContext = context.Cars.Local;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            
            EnterDataWindow edw = new EnterDataWindow();
            if (edw.ShowDialog()==true)
            {
                if (edw.DialogResult==true)
                {
                    var car = new Car()
                    {
                        Model = edw.tbModel.Text,
                        Year = int.Parse(edw.tbYear.Text),
                        Color = edw.tbColor.Text,
                        EngineVolume = edw.tbEngine.Text,
                        Price = decimal.Parse(edw.tbPrice.Text)
                    };
                    context.Cars.Add(car);
                    context.SaveChanges();
                }
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Car car = dGrid.SelectedItem as Car;
            EnterDataWindow edw = new EnterDataWindow();
            edw.tbModel.Text = car.Model;
            edw.tbYear.Text = car.Year.ToString();
            edw.tbColor.Text = car.Color;
            edw.tbPrice.Text = car.Price.ToString();
            edw.tbEngine.Text = car.EngineVolume;
            if (edw.ShowDialog() == true)
            {
                if (edw.DialogResult == true)
                {
                    car.Model = edw.tbModel.Text;
                    car.Year = int.Parse(edw.tbYear.Text);
                    car.Color = edw.tbColor.Text;
                    car.EngineVolume = edw.tbEngine.Text;
                    car.Price = decimal.Parse(edw.tbPrice.Text);
                    context.SaveChanges();
                    dGrid.DataContext = null;
                    dGrid.DataContext = context.Cars.Local;
                }
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure?", "Delete record", MessageBoxButton.YesNo);
            if (result==MessageBoxResult.Yes)
            {
                Car car = dGrid.SelectedItem as Car;
                context.Cars.Remove(car);
                context.SaveChanges();
            }
        }

        private void dGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }
    }
}
