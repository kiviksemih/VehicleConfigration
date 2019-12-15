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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        GeneralOperation generalOperation;
        public Login()
        {
            InitializeComponent();

            generalOperation = new GeneralOperation();
            imgLogo.Source = new BitmapImage(new Uri("pack://application:,,,/image/logo.jpeg"));
        }


        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            AppUser appUser = generalOperation.GetLoginUser(tbxUserName.Text, tbxPasswordName.Password);

            if (appUser == null)
            {
                MessageBox.Show("Kullanıcı Adı Veya Şifre Hatalı");
            }
            else
            {
                StaticUser.SetUser(appUser);
                Home home = new Home();
                home.Show();
                this.Close();

            }
            CleanProperty();
        }


        public void CleanProperty()
        {
            tbxPasswordName.Password = string.Empty;
            tbxUserName.Text = string.Empty;
        }
    }
}
