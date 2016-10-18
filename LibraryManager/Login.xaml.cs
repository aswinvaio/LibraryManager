using System;
using System.Collections.Generic;
using System.Data;
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

namespace LibraryManager
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void login_mouseleftdwn(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        private void loginwindow_loadd(object sender, RoutedEventArgs e)
        {
            if (DBConnect.Connect())
            {

            }
            else
            {
                MessageBox.Show("unable to connect Database", "ERROR!", MessageBoxButton.OK, MessageBoxImage.Stop);
                this.Close();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            bool canForward = true;
            string username = txtUserName.Text;
            string paswd = pswdField.Password;

            if (txtUserName.Text == "")
            {
                txtUserName.BorderBrush = Brushes.Red;
                lblNotif.Content = "enter user name ";
                canForward = false;
            }
            else
            {
                txtUserName.BorderBrush = Brushes.Black;
            }
            if (pswdField.Password == "")
            {
                pswdField.BorderBrush = Brushes.Red;
                if (canForward) lblNotif.Content = "password not valid !";
                canForward = false;
            }
            else
            {
                pswdField.BorderBrush = Brushes.Black;
            }
            if (canForward)
            {
                bool success = false;
                bool foundUName = false;
                string type = "";
                lblNotif.Content = "";
                string query = string.Format("SELECT * FROM [dbo].[Users] WHERE UserName='" + username + "';");
                DataTable dt = DBConnect.Select(query);
                try
                {
                    if (dt.Rows[0][0].ToString() == username)
                    {
                        foundUName = true;
                        if (dt.Rows[0][1].ToString() == paswd)
                        {
                            success = true;
                            type = dt.Rows[0][2].ToString();
                        }
                    }
                }
                catch (Exception)
                {

                }
                if (foundUName)
                {
                    txtUserName.BorderBrush = Brushes.Black;
                    if (success)
                    {
                        pswdField.BorderBrush = Brushes.Black;
                        lblNotif.Content = "";
                        // navigate to home pages of (type)
                        if (type == "A")
                        {
                            //new AdminHomeWindow(username, name, type).Show();
                            new MainWindow().Show();
                            this.Close();
                        }
                    }
                    else
                    {
                        pswdField.BorderBrush = Brushes.Red;
                        lblNotif.Content = "incorrect password ";
                    }
                }
                else
                {
                    lblNotif.Content = "Invalid user name. ";
                }
            }
        }

    }
}
