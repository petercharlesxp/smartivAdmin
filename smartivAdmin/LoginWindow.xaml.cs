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
using MySql.Data;


namespace smartivAdmin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
   
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {   
            try{
                    string query = "SELECT * FROM WIMTACH.user where Binary userName='" + tbUserName.Text + "'and password='" + tbPassword.Password + "';";
                    DatabaseHelper dbhelper = new DatabaseHelper();
                    Boolean a = dbhelper.ExecuteCommand(query, dbhelper.getConnection(), dbhelper.getCommand()).HasRows;
                    if (a)
                    {
                        Home win = new Home();
                        win.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Invalid User Credential");
                    }
            }
            catch (Exception E)
            {
                MessageBox.Show(this, "" + E.Data + "*****" + E.Message);
            }
        }

    }
}
