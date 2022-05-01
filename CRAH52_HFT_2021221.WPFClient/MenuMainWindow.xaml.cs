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
using System.Windows.Shapes;

namespace CRAH52_HFT_2021221.WPFClient
{
    /// <summary>
    /// Interaction logic for MenuMainWindow.xaml
    /// </summary>
    public partial class MenuMainWindow : Window
    {
        public MenuMainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ClubMainWindow clubMainWindow = new ClubMainWindow();
            clubMainWindow.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            EventMainWindow eventMainWindow = new EventMainWindow();
            eventMainWindow.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            GuestMainWindow guestMainWindow = new GuestMainWindow();
            guestMainWindow.Show();
        }
    }
}
