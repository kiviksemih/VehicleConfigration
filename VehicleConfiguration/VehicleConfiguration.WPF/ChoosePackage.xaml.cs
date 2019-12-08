using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using VehicleConfiguration.DATA.Models;
using VehicleConfiguration.WPF.Helper;
using VehicleConfiguration.WPF.Operations;

namespace VehicleConfiguration.WPF
{
    /// <summary>
    /// Interaction logic for ChoosePackage.xaml
    /// </summary>
    public partial class ChoosePackage : Window
    {
        GeneralOperation generalOperation;
        public ChoosePackage()
        {
            InitializeComponent();

            generalOperation = new GeneralOperation();
            btnChoosePackage.Click += BtnChoosePackage_Click;
            imgNormal.Source = new BitmapImage(new Uri("pack://application:,,,/image/standart.png"));
            imgSpecial.Source = new BitmapImage(new Uri("pack://application:,,,/image/special.png"));

            int carId = StaticOrder.GetCarId();

            Cars car = generalOperation.GetCarById(carId);

            lblModelName.Content = car.CarName;

        }

        private void BtnChoosePackage_Click(object sender, RoutedEventArgs e)
        {
            if (!rbSpecial.IsChecked.Value && !rbStandart.IsChecked.Value)
            {
                MessageBox.Show("Lütfen Paket Seçiniz");
            }
            else
            {
                if (rbSpecial.IsChecked.Value)
                {
                    StaticOrder.SetPackageTypeId((int)PackageTypeList.Special);
                }
                else
                {
                    StaticOrder.SetPackageTypeId((int)PackageTypeList.Standart);
                }
            }
        }
    }
}
