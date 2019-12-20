using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using VehicleConfiguration.WPF.Model;
using VehicleConfiguration.WPF.Operations;

namespace VehicleConfiguration.WPF
{
    /// <summary>
    /// Interaction logic for DraftOrder.xaml
    /// </summary>
    public partial class OrderList : Window
    {
        GeneralOperation generalOperation;
        int orderId = 0;
        OrderStatus orderstatus = OrderStatus.All;
        public OrderList()
        {
            InitializeComponent();
            generalOperation = new GeneralOperation();


            List<CustomDictionaryModel> customDictionaryModel = new List<CustomDictionaryModel>()
            {
                new CustomDictionaryModel()
                {
                    Key=(int)OrderStatus.All,
                    Value="Tümü"
                },
                 new CustomDictionaryModel()
                {
                    Key=OrderStatus.Draft,
                    Value="Taslak"
                },
                new CustomDictionaryModel()
                {
                     Key=OrderStatus.Completed,
                    Value="Onaylanmış"
                },
                new CustomDictionaryModel()
                {
                     Key=OrderStatus.Canceled,
                    Value="İptal Edilmiş"
                }
            };

            cmbStatus.ItemsSource = customDictionaryModel;
            cmbStatus.DisplayMemberPath = "Value";
            cmbStatus.SelectedItem = customDictionaryModel.Where(s => s.Key == OrderStatus.All).FirstOrDefault();

            cmbStatus.SelectionChanged += CmbStatus_SelectionChanged;
            btnClose.Click += BtnClose_Click;
            btnRemove.Click += BtnRemove_Click;
            btnSuccess.Click += BtnSuccess_Click;
            dGrid.AutoGeneratingColumn += DGrid_AutoGeneratingColumn;
            dGrid.SelectionChanged += DGrid_SelectionChanged;
            dGrid.IsReadOnly = true;
            GridUpdate(OrderStatus.All);
        }

        private void CmbStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;

            CustomDictionaryModel selectedItem = (CustomDictionaryModel)comboBox.SelectedItem;

            orderstatus = selectedItem.Key;

            GridUpdate(selectedItem.Key);
        }

        private void BtnSuccess_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Kayıt Onaylanacak", orderId.ToString() + " Numaralı Kayıt Onaylanacak", MessageBoxButton.YesNo, MessageBoxImage.Warning) != MessageBoxResult.No)
            {
                generalOperation.ChangeOrderStatus(true, orderId);
                MessageBox.Show("İşlem Tamamlandı");
                GridUpdate(OrderStatus.All);
            }
        }

        private void BtnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Kayıt İptal Edilecek", orderId.ToString() + " Numaralı Kayıt İptal Edilecek", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {

            }
            else
            {
                generalOperation.ChangeOrderStatus(false, orderId);
                MessageBox.Show("İşlem Tamamlandı");
                GridUpdate(OrderStatus.All);
            }

        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Close();
        }

        private void DGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid datagrid = (DataGrid)sender;

            OrderGridModel gridModel = (OrderGridModel)datagrid.SelectedItem;

            if (gridModel != null)
            {
                orderId = gridModel.OrderId;


                if (gridModel.StatusType == (int)OrderStatus.Draft)
                {
                    btnRemove.Visibility = Visibility.Visible;

                    btnSuccess.Visibility = Visibility.Visible;
                }
                else
                {
                    btnRemove.Visibility = Visibility.Collapsed;

                    btnSuccess.Visibility = Visibility.Collapsed;
                }

            }


        }

        private void DGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            e.Column.Header = ((PropertyDescriptor)e.PropertyDescriptor).DisplayName;

            if (e.PropertyName == "StatusType")
            {
                e.Column = null;
            }
        }

        public void GridUpdate(OrderStatus status)
        {
            List<Orders> orderList = generalOperation.GetOrderListByStatus(status);

            List<OrderGridModel> orderGridModelList = new List<OrderGridModel>();

            foreach (Orders order in orderList)
            {
                orderGridModelList.Add(new OrderGridModel()
                {
                    CarName = order.Cars.CarName,
                    DeallerName = order.Dealer.DealerName,
                    OrderDate = order.CreateDate,
                    OrderId = order.OrdersId,
                    PackageTypeName = order.IsStandartPackage == true ? "StandartPaket" : "Special Paket",
                    UserName = order.AppUser.Username,
                    StatusType=order.StatusType

                });
            }
            dGrid.ItemsSource = orderGridModelList;
        }
    }
}
