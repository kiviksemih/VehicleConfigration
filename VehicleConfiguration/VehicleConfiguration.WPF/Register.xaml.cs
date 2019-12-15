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
using VehicleConfiguration.WPF.Operations;

namespace VehicleConfiguration.WPF
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        GeneralOperation generalOperation;
        public Register()
        {
            InitializeComponent();
            btnCreateUser.Click += BtnCreateUser_Click;
            btnClose.Click += BtnClose_Click;
            generalOperation=new GeneralOperation();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Close();
        }

        private void BtnCreateUser_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrEmpty(tbxUserName.Text)||string.IsNullOrEmpty(tbxPassword.Password))
            {
                MessageBox.Show("Lütfen boş alanları doldurunuz");
            }
            else
            {
                AppUser appUser = new AppUser()
                {
                    CreateDate = DateTime.Now,
                    Username = tbxUserName.Text,
                    IsActive = true,
                    IsDeleted = false,
                    IsAdmin = cbxIsAdmin.IsChecked.Value,
                    Password=tbxPassword.Password
                };
                generalOperation.InsertAppUser(appUser);
                MessageBox.Show("Yeni Kullanıcı  Oluşturuldu");

                Home home = new Home();
                home.Show();

                this.Close();
            }
        }
    }
}
