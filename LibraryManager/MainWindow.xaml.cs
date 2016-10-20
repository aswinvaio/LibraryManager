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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LibraryManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void picMembers_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            LibraryMembers lm = new LibraryMembers();
            lm.ShowDialog();
        }

        private void picMembers_MouseEnter(object sender, MouseEventArgs e)
        {
            picMembers.Opacity = .5;
        }

        private void picMembers_MouseLeave(object sender, MouseEventArgs e)
        {
            picMembers.Opacity = 1;
        }

        private void AdminHome_loaded(object sender, RoutedEventArgs e)
        {

        }

        private void lblLogout_mld(object sender, MouseButtonEventArgs e)
        {
            new Login().Show();
            this.Close();
        }

        private void lblLogout_me(object sender, MouseEventArgs e)
        {
            lblLogout.Opacity = .5;
        }

        private void lblLogout_mlv(object sender, MouseEventArgs e)
        {
            lblLogout.Opacity = 1;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
