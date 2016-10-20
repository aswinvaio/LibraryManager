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
    /// Interaction logic for LibraryMembers.xaml
    /// </summary>
    public partial class LibraryMembers : Window
    {
        DataTable dt;

        public LibraryMembers()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (DBConnect.isConnected() == false)
                DBConnect.Connect(); //only when starting from this wndw
            string query = string.Format("SELECT [MemberId],[Name],[Phone],[Email],[Address] FROM Members;");
            dt = DBConnect.Select(query);
            dt.Columns[0].ColumnName = "Member Id";
            dt.Columns[1].ColumnName = "Name";
            dt.Columns[2].ColumnName = "Phone Number";
            dt.Columns[3].ColumnName = "Email";
            dt.Columns[4].ColumnName = "Address";

            dgMemberss.ItemsSource = dt.DefaultView;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnremove_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnedit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnadd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
