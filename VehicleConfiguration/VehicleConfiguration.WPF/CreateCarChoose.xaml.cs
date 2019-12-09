using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for CreateCarChoose.xaml
    /// </summary>
    public partial class CreateCarChoose : Window
    {
        GeneralOperation generalOperation;
        List<int> optionList = new List<int>();
        int bodyFeatureId = 0;
        int engineFeatureId = 0;
        int gearboxFeatureId = 0;
        int colorFeatureId = 0;
        int floorFeatureId = 0;
        public CreateCarChoose()
        {
            InitializeComponent();
            btnSave.Click += BtnSave_Click;

            generalOperation = new GeneralOperation();

            int packageType = StaticOrder.GetPackageTypeId();

            #region Gövde listesini getiriyor
            List<VehicleFeatures> bodyList = generalOperation.GetAllVehicleFeaturesByPackageTypeAndVehicleFeaturesType(packageType, Helper.VehicleFeaturesTypeList.BodyList);

            Grid bodyGrid = new Grid();
            StackPanel stackBodyPanel = new StackPanel();


            foreach (var item in bodyList)
            {
                RadioButton radioButton = new RadioButton()
                {
                    Content = item.FeaturesName,
                    DataContext = item
                };
                radioButton.Checked += RadioButton_Checked;
                stackBodyPanel.Children.Add(radioButton);

            }


            bodyGrid.Children.Add(stackBodyPanel);
            tabBody.Content = bodyGrid;
            #endregion Gövde listesini getiriyor

            #region Motor listesini getiriyor
            List<VehicleFeatures> engineList = generalOperation.GetAllVehicleFeaturesByPackageTypeAndVehicleFeaturesType(packageType, Helper.VehicleFeaturesTypeList.EngineList);

            Grid engineGrid = new Grid();
            StackPanel stackEnginePanel = new StackPanel();


            foreach (var item in engineList)
            {
                RadioButton radioButton = new RadioButton()
                {
                    Content = item.FeaturesName,
                    DataContext = item
                };
                radioButton.Checked += RadioButton_Checked;
                stackEnginePanel.Children.Add(radioButton);

            }


            engineGrid.Children.Add(stackEnginePanel);
            tabEngine.Content = engineGrid;

            #endregion Motor listesini getiriyor

            #region Vites listesini getiriyor
            List<VehicleFeatures> gearboxList = generalOperation.GetAllVehicleFeaturesByPackageTypeAndVehicleFeaturesType(packageType, Helper.VehicleFeaturesTypeList.GearboxList);

            Grid gearboxGrid = new Grid();
            StackPanel stackGearboxPanel = new StackPanel();


            foreach (var item in gearboxList)
            {
                RadioButton radioButton = new RadioButton()
                {
                    Content = item.FeaturesName,
                    DataContext = item
                };
                radioButton.Checked += RadioButton_Checked;
                stackGearboxPanel.Children.Add(radioButton);

            }


            gearboxGrid.Children.Add(stackGearboxPanel);
            tabGearbox.Content = gearboxGrid;

            #endregion Vites listesini getiriyor

            #region Renk listesini getiriyor
            List<VehicleFeatures> colorList = generalOperation.GetAllVehicleFeaturesByPackageTypeAndVehicleFeaturesType(packageType, Helper.VehicleFeaturesTypeList.ColorList);

            Grid colorGrid = new Grid();
            StackPanel stackColorPanel = new StackPanel();


            foreach (var item in colorList)
            {
                RadioButton radioButton = new RadioButton()
                {
                    Content = item.FeaturesName.Trim(),
                    DataContext = item
                };
                radioButton.Checked += RadioButton_Checked;
                stackColorPanel.Children.Add(radioButton);

            }


            colorGrid.Children.Add(stackColorPanel);
            tabColor.Content = colorGrid;

            #endregion Renk listesini getiriyor

            #region Döşeme listesini getiriyor
            List<VehicleFeatures> floorList = generalOperation.GetAllVehicleFeaturesByPackageTypeAndVehicleFeaturesType(packageType, Helper.VehicleFeaturesTypeList.FloorList);

            Grid bodyFloorGrid = new Grid();
            StackPanel stackFloorPanel = new StackPanel();


            foreach (var item in floorList)
            {
                RadioButton radioButton = new RadioButton()
                {
                    Content = item.FeaturesName,
                    DataContext = item
                };
                radioButton.Checked += RadioButton_Checked;
                stackFloorPanel.Children.Add(radioButton);

            }


            bodyFloorGrid.Children.Add(stackFloorPanel);
            tabFloor.Content = bodyFloorGrid;

            #endregion Döşeme listesini getiriyor

            #region Opsiyon listesini getiriyor
            List<VehicleFeatures> optionList = generalOperation.GetAllVehicleFeaturesByPackageTypeAndVehicleFeaturesType(packageType, Helper.VehicleFeaturesTypeList.OptionList);

            Grid bodyOptionGrid = new Grid();
            StackPanel stackOptionPanel = new StackPanel();


            foreach (var item in optionList)
            {
                CheckBox checkBox = new CheckBox()
                {
                    Content = item.FeaturesName,
                    DataContext = item
                };
                checkBox.Click += CheckBox_Click;
                stackOptionPanel.Children.Add(checkBox);

            }


            bodyOptionGrid.Children.Add(stackOptionPanel);
            tabOption.Content = bodyOptionGrid;

            #endregion Opsiyon listesini getiriyor
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            VehicleFeatures vehicleFeatures = (VehicleFeatures)radioButton.DataContext;

            if (vehicleFeatures.VehicleFeaturesTypeId == (int)Helper.VehicleFeaturesTypeList.BodyList)
            {
                bodyFeatureId = vehicleFeatures.VehicleFeaturesId;
            }
            else if (vehicleFeatures.VehicleFeaturesTypeId == (int)Helper.VehicleFeaturesTypeList.EngineList)
            {
                engineFeatureId = vehicleFeatures.VehicleFeaturesId;
            }
            else if (vehicleFeatures.VehicleFeaturesTypeId == (int)Helper.VehicleFeaturesTypeList.GearboxList)
            {
                gearboxFeatureId = vehicleFeatures.VehicleFeaturesId;
            }
            else if (vehicleFeatures.VehicleFeaturesTypeId == (int)Helper.VehicleFeaturesTypeList.ColorList)
            {
                colorFeatureId = vehicleFeatures.VehicleFeaturesId;
            }
            else if (vehicleFeatures.VehicleFeaturesTypeId == (int)Helper.VehicleFeaturesTypeList.FloorList)
            {
                floorFeatureId = vehicleFeatures.VehicleFeaturesId;
            }
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            VehicleFeatures vehicleFeatures = (VehicleFeatures)checkBox.DataContext;
            if (checkBox.IsChecked.Value)
            {
                optionList.Add(vehicleFeatures.VehicleFeaturesId);
            }
            else
            {
                optionList.Remove(vehicleFeatures.VehicleFeaturesId);
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (bodyFeatureId == 0)
            {
                MessageBox.Show("Lütfen Gövde Seçiniz");
            }
            else if (engineFeatureId == 0)
            {
                MessageBox.Show("Lütfen Motor Seçiniz");
            }
            else if (gearboxFeatureId == 0)
            {
                MessageBox.Show("Lütfen Vites Kutusu Seçiniz");
            }
            else if (colorFeatureId == 0)
            {
                MessageBox.Show("Lütfen Renk Seçiniz");
            }
            else if (floorFeatureId == 0)
            {
                MessageBox.Show("Lütfen Döşeme Seçiniz");
            }
        }
    }
}
