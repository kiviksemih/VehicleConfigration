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
using VehicleConfiguration.DATA.Models;
using VehicleConfiguration.WPF.Helper;
using VehicleConfiguration.WPF.Operations;

namespace VehicleConfiguration.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GeneralOperation generalOperation;
        public MainWindow()
        {
           
            InitializeComponent();
            generalOperation = new GeneralOperation();

            btnClose.Click += BtnClose_Click;
            cmbCarList.SelectionChanged += CmbCarList_SelectionChanged;
            btnCreatedAndBuy.Click += BtnCreatedAndBuy_Click;
            List<Cars> carList = generalOperation.GetAllActiveCars();
            cmbCarList.ItemsSource = carList;
            cmbCarList.DisplayMemberPath = "CarName";
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Home home = new Home();

            home.Show();

            this.Close();
        }

        private void BtnCreatedAndBuy_Click(object sender, RoutedEventArgs e)
        {
            ChoosePackage choosePackage = new ChoosePackage();
            choosePackage.Show();
            this.Close();
        }

        private void CmbCarList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmbItem = (ComboBox)sender;

            #region Gizlenip alınan alanlar
            lblValCarSelect.Visibility = Visibility.Collapsed;
            btnCreatedAndBuy.Visibility = Visibility.Visible;
            btnExplore.Visibility = Visibility.Visible;
            lblCarName.Visibility = Visibility.Visible;
            lblCarModel.Visibility = Visibility.Visible;
            picCar.Visibility = Visibility.Visible;
            #endregion  Gizlenip alınan alanlar

            #region Seçili combobox'u buluyoruz
            Cars cars = (Cars)cmbItem.SelectedItem;
            #endregion Seçili combobox'u buluyoruz

            #region Seçili araç verilerini getiriyoruz
            #region Araç resimlerini getiriyoruz
            string startupPath = System.IO.Directory.GetCurrentDirectory();
            picCar.Source = new BitmapImage(new Uri(startupPath + "/image/" + cars.CarImagePath));
            #endregion Araç resimlerini getiriyoruz
            lblCarModel.Content = cars.CarModel;
            lblCarName.Content = cars.CarName;

            StaticOrder.SetCarId(cars.CarsId);

            #endregion Seçili araç verilerini getiriyoruz
        }

    }
}
