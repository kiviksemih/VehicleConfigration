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
    /// Interaction logic for CreateCarChoose.xaml
    /// </summary>
    public partial class CreateCarChoose : Window
    {
        GeneralOperation generalOperation;
        public CreateCarChoose()
        {
            InitializeComponent();
            generalOperation = new GeneralOperation();

            int packageType = StaticOrder.GetPackageTypeId();

            List<VehicleFeatures>  bodyList = generalOperation.GetAllVehicleFeaturesByPackageTypeAndVehicleFeaturesType(packageType, Helper.VehicleFeaturesTypeList.BodyList);

            Grid bodyGrid = new Grid();
            StackPanel stackPanel = new StackPanel();
          

            foreach (var item in bodyList)
            {
                RadioButton radioButton = new RadioButton()
                {
                    Content = item.FeaturesName,
                };
                stackPanel.Children.Add(radioButton);
             
            }
            bodyGrid.Children.Add(stackPanel);
            tabGovde.Content = bodyGrid;
        }
    }
}
