using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using VehicleConfiguration.WPF.Model;
using VehicleConfiguration.WPF.Operations;

namespace VehicleConfiguration.WPF
{
    /// <summary>
    /// Interaction logic for DraftOrder.xaml
    /// </summary>
    public partial class DraftOrder : Window
    {
        GeneralOperation generalOperation;
        int orderId = 0;
        public DraftOrder()
        {
            InitializeComponent();
            generalOperation = new GeneralOperation();
            btnClose.Click += BtnClose_Click;
            btnRemove.Click += BtnRemove_Click;
            btnSuccess.Click += BtnSuccess_Click;
            dGrid.AutoGeneratingColumn += DGrid_AutoGeneratingColumn;
            dGrid.SelectionChanged += DGrid_SelectionChanged;
            dGrid.IsReadOnly = true;
            GridUpdate();
        }

        private void BtnSuccess_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Kayıt Onaylanacak", orderId.ToString()+" Numaralı Kayıt Onaylanacak", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
             
            }
            else
            {
                generalOperation.ChangeOrderStatus(true, orderId);
                MessageBox.Show("İşlem Tamamlandı");
                GridUpdate();
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
                GridUpdate();
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

                btnRemove.Visibility = Visibility.Visible;

                btnSuccess.Visibility = Visibility.Visible;
            }
          
             
        }

        private void DGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            e.Column.Header = ((PropertyDescriptor)e.PropertyDescriptor).DisplayName;
        }

        public void GridUpdate()
        {
            List<Orders> orderList = generalOperation.GetAllDraftOrdersList();

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
                    UserName = order.AppUser.Username

                });
            }
            dGrid.ItemsSource = orderGridModelList;
        }
    }
}
