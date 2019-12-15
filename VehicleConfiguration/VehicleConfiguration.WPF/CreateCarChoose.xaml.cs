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
        decimal totalPrice = 0;
        int deallerId = 0;
        public CreateCarChoose()
        {
            InitializeComponent();
            btnSave.Click += BtnSave_Click;
            btnContinue.Click += BtnContinue_Click;
            btnOrder.Click += BtnOrder_Click;
            cmbDealer.SelectionChanged += CmbDealer_SelectionChanged;
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
                radioButton.Unchecked += RadioButton_Unchecked;
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
                radioButton.Unchecked += RadioButton_Unchecked;
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
                radioButton.Unchecked += RadioButton_Unchecked;
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
                radioButton.Unchecked += RadioButton_Unchecked;
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
                checkBox.Checked += CheckBox_Checked;
                checkBox.Unchecked += CheckBox_Unchecked;
                stackOptionPanel.Children.Add(checkBox);

            }


            bodyOptionGrid.Children.Add(stackOptionPanel);
            tabOption.Content = bodyOptionGrid;

            #endregion Opsiyon listesini getiriyor
        }

        private void CmbDealer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;

            Dealer dealer = (Dealer)cmb.SelectedItem;
            deallerId = dealer.DealerId;
        }

        private void BtnOrder_Click(object sender, RoutedEventArgs e)
        {

            if (deallerId == 0)
            {
                MessageBox.Show("Lütfen Bayi Seçiniz");
                return;
            }
            else if (string.IsNullOrEmpty(tbxemail.Text))
            {
                MessageBox.Show("Lütfen Mail Giriniz");
                return;
            }
            else if (string.IsNullOrEmpty(tbxFullName.Text))
            {
                MessageBox.Show("Lütfen Ad Soyad Giriniz");
                return;
            }
            else if (string.IsNullOrEmpty(tbxPhone.Text))
            {
                MessageBox.Show("Lütfen Telefon Giriniz");
                return;
            }
            Dealer dealer = generalOperation.GetDealerById(deallerId);

            Orders orders = new Orders()
            {
                AppUserId = StaticUser.GetUser().AppUserId,
                CarsId = StaticOrder.GetCarId(),
                IsActive = true,
                CreateDate = DateTime.Now,
                IsDeleted = false,
                IsStandartPackage = true,
                StatusType = (int)OrderStatus.Draft,
                DealerId = deallerId
            };
            orders.OrderDetails.Add(new OrderDetails
            {
                IsActive = true,
                CreateDate = DateTime.Now,
                IsDeleted = false,
                VehicleFeaturesId = bodyFeatureId
            });
            orders.OrderDetails.Add(new OrderDetails
            {
                IsActive = true,
                CreateDate = DateTime.Now,
                IsDeleted = false,
                VehicleFeaturesId = colorFeatureId
            });
            orders.OrderDetails.Add(new OrderDetails
            {
                IsActive = true,
                CreateDate = DateTime.Now,
                IsDeleted = false,
                VehicleFeaturesId = engineFeatureId
            });
            orders.OrderDetails.Add(new OrderDetails
            {
                IsActive = true,
                CreateDate = DateTime.Now,
                IsDeleted = false,
                VehicleFeaturesId = floorFeatureId
            });
            orders.OrderDetails.Add(new OrderDetails
            {
                IsActive = true,
                CreateDate = DateTime.Now,
                IsDeleted = false,
                VehicleFeaturesId = gearboxFeatureId
            });
            string optionTextList = string.Empty;

            foreach (var item in optionList)
            {
                orders.OrderDetails.Add(new OrderDetails
                {
                    IsActive = true,
                    CreateDate = DateTime.Now,
                    IsDeleted = false,
                    VehicleFeaturesId = item
                });

                VehicleFeatures vehicleFeatures = generalOperation.GetByIdVehicleFeatures(item);

                if (string.IsNullOrEmpty(optionTextList))
                {
                    optionTextList = vehicleFeatures.FeaturesName;
                }
                else
                {
                    optionTextList += "</br>" + vehicleFeatures.FeaturesName;
                }
            }
            generalOperation.InsertOrders(orders);

            AppUser appUser = generalOperation.GetAppUserById(orders.AppUserId);

            EmailHelper.Mail(tbxemail.Text, "Talebini Aldık", "Merhaba, " + appUser.Username + "<br>" + "Araç Sipariş Talebini Aldık Yakında Sana Geri Dönüş Yapacağız");

            EmailHelper.Mail(dealer.DealerEmail, "Yeni Sipariş Talebi", "Merhaba , <br>" +
                "Müşteri Adı:" + appUser.Username + "<br>" +
                "Telefon Numarası:" + tbxPhone + "<br>" +
                "Email:" + tbxemail + "<br>" +
                "</hr>" +
                "<h1>Araç Bilgileri </h1>" +
                "<br>" +
                "Araç Modeli:" + lblCarName.Content + "<br>" +
                "Araç Paketi:" + lblPackageType.Content + "<br>" +
                "Araç Gövde Seçimi:" + lblBody.Content + "<br>" +
                "Araç Motor Seçimi:" + lblEngine.Content + "<br>" +
                "Araç Şanzıman Seçimi:" + lblGearbox.Content + "<br>" +
                "Araç Döşeme Seçimi:" + lblFloor.Content + "<br>" +
                "Araç Opsiyon Seçimleri:" + optionTextList + "<br>" +
                "İyi Çalışmalar Teklif Olarak Müşteriye Dönüş Yapınız");


            Home home = new Home();

            this.Close();
            home.Show();
        }

        private void BtnContinue_Click(object sender, RoutedEventArgs e)
        {

            gridSecond.Visibility = Visibility.Collapsed;
            gridSection.Visibility = Visibility.Collapsed;
            gridOffer.Visibility = Visibility.Visible;

            cmbDealer.ItemsSource = generalOperation.GetAllDealer();
            cmbDealer.DisplayMemberPath = "DealerName";
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            VehicleFeatures vehicleFeatures = (VehicleFeatures)checkBox.DataContext;
            totalPrice -= vehicleFeatures.FeaturesPrice;
            optionList.Remove(vehicleFeatures.VehicleFeaturesId);
        }

        private void RadioButton_Unchecked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            VehicleFeatures vehicleFeatures = (VehicleFeatures)radioButton.DataContext;

            if (vehicleFeatures.VehicleFeaturesTypeId == (int)Helper.VehicleFeaturesTypeList.BodyList)
            {
                totalPrice -= vehicleFeatures.FeaturesPrice;
            }
            else if (vehicleFeatures.VehicleFeaturesTypeId == (int)Helper.VehicleFeaturesTypeList.EngineList)
            {
                totalPrice -= vehicleFeatures.FeaturesPrice;
            }
            else if (vehicleFeatures.VehicleFeaturesTypeId == (int)Helper.VehicleFeaturesTypeList.GearboxList)
            {
                totalPrice -= vehicleFeatures.FeaturesPrice;
            }
            else if (vehicleFeatures.VehicleFeaturesTypeId == (int)Helper.VehicleFeaturesTypeList.ColorList)
            {
                totalPrice -= vehicleFeatures.FeaturesPrice;
            }
            else if (vehicleFeatures.VehicleFeaturesTypeId == (int)Helper.VehicleFeaturesTypeList.FloorList)
            {
                totalPrice -= vehicleFeatures.FeaturesPrice;
            }

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            VehicleFeatures vehicleFeatures = (VehicleFeatures)radioButton.DataContext;

            if (vehicleFeatures.VehicleFeaturesTypeId == (int)Helper.VehicleFeaturesTypeList.BodyList)
            {
                bodyFeatureId = vehicleFeatures.VehicleFeaturesId;
                lblBody.Content = vehicleFeatures.FeaturesName + " Fiyat: " + vehicleFeatures.FeaturesPrice + "₺";
                totalPrice += vehicleFeatures.FeaturesPrice;
            }
            else if (vehicleFeatures.VehicleFeaturesTypeId == (int)Helper.VehicleFeaturesTypeList.EngineList)
            {
                engineFeatureId = vehicleFeatures.VehicleFeaturesId;
                lblEngine.Content = vehicleFeatures.FeaturesName + " Fiyat: " + vehicleFeatures.FeaturesPrice + "₺";
                totalPrice += vehicleFeatures.FeaturesPrice;
            }
            else if (vehicleFeatures.VehicleFeaturesTypeId == (int)Helper.VehicleFeaturesTypeList.GearboxList)
            {
                gearboxFeatureId = vehicleFeatures.VehicleFeaturesId;
                lblGearbox.Content = vehicleFeatures.FeaturesName + " Fiyat: " + vehicleFeatures.FeaturesPrice + "₺";
                totalPrice += vehicleFeatures.FeaturesPrice;
            }
            else if (vehicleFeatures.VehicleFeaturesTypeId == (int)Helper.VehicleFeaturesTypeList.ColorList)
            {
                colorFeatureId = vehicleFeatures.VehicleFeaturesId;
                lblColor.Content = vehicleFeatures.FeaturesName + " Fiyat: " + vehicleFeatures.FeaturesPrice + "₺";
                totalPrice += vehicleFeatures.FeaturesPrice;
            }
            else if (vehicleFeatures.VehicleFeaturesTypeId == (int)Helper.VehicleFeaturesTypeList.FloorList)
            {
                floorFeatureId = vehicleFeatures.VehicleFeaturesId;
                lblFloor.Content = vehicleFeatures.FeaturesName + " Fiyat: " + vehicleFeatures.FeaturesPrice + "₺";
                totalPrice += vehicleFeatures.FeaturesPrice;
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            VehicleFeatures vehicleFeatures = (VehicleFeatures)checkBox.DataContext;
            if (checkBox.IsChecked.Value)
            {
                optionList.Add(vehicleFeatures.VehicleFeaturesId);
                totalPrice += vehicleFeatures.FeaturesPrice;
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
                return;
            }
            else if (engineFeatureId == 0)
            {
                MessageBox.Show("Lütfen Motor Seçiniz");
                return;
            }
            else if (gearboxFeatureId == 0)
            {
                MessageBox.Show("Lütfen Vites Kutusu Seçiniz");
                return;
            }
            else if (colorFeatureId == 0)
            {
                MessageBox.Show("Lütfen Renk Seçiniz");
                return;
            }
            else if (floorFeatureId == 0)
            {
                MessageBox.Show("Lütfen Döşeme Seçiniz");
                return;
            }

            generalOperation = new GeneralOperation();

            gridSecond.Visibility = Visibility.Visible;
            gridSection.Visibility = Visibility.Collapsed;

            Cars car = generalOperation.GetCarById(StaticOrder.GetCarId());

            lblCarName.Content = car.CarName;
            lblYear.Content = car.CarModel;
            string startupPath = System.IO.Directory.GetCurrentDirectory();
            imgCar.Source = new BitmapImage(new Uri(startupPath + "/image/" + car.CarImagePath));
            lblTotalPrice.Content = (totalPrice += car.Price).ToString() + "₺";
            lblPackageType.Content = StaticOrder.GetPackageTypeId() == 1 ? "Special Paket" : "Standart Paket";

            List<VehicleFeatures> optionFeatureList = generalOperation.GetAllVehicleFeaturesByPackageTypeAndVehicleFeaturesType(StaticOrder.GetPackageTypeId(), Helper.VehicleFeaturesTypeList.OptionList);

            foreach (var item in optionFeatureList.Where(s => optionList.Contains(s.VehicleFeaturesId)))
            {
                Label lblOption = new Label()
                {
                    Content = item.FeaturesName + " Fiyat: " + item.FeaturesPrice + "₺"
                };
                stackOption.Children.Add(lblOption);
            }
        }

        private void btnPrintPdf_Click(object sender, RoutedEventArgs e)
        {
            btnPrintPdf.Visibility = Visibility.Collapsed;
            btnContinue.Visibility = Visibility.Collapsed;

            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(gridSecond, "Print");
            }

            btnPrintPdf.Visibility = Visibility.Visible;
            btnContinue.Visibility = Visibility.Visible;
        }
    }
}
