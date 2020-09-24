using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InformePOO
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text!="")
            {
                MainWindow w = (MainWindow)Window.GetWindow(this);
                w.mainFrame.NavigationService.Navigate(new Game());
                Player.name = txtName.Text;
            }
            else
            {
                MessageBox.Show("Se te ha olvidado ingresar tu nombre, por favor hazlo");
            }
        }
    }
}
