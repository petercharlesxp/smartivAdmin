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
using MySql.Data;
using MySql.Data.Entity;
using MySql.Data.MySqlClient;

namespace smartivAdmin
{
    /// <summary>
    /// Interaction logic for PatientDetail.xaml
    /// </summary>
    public partial class PatientDetail : Window
    {

        public PatientDetail(Patient PD)
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            lockEditables();

            hiddenFieldPatientID_PatientDetails.Content = PD.ID;
            TextBox_EditFirstNamePatientDetailWindow.Text = PD.FirstName;
            TextBox_EditLastNamePatientDetailWindow.Text = PD.LastName;
            TextBox_EditMiddleNamePatientDetailWindow.Text = PD.MiddleName;
            if (PD.Sex == "MALE") { ComboBox_EditSexPatientDetailWindow.SelectedIndex = 0; } else { ComboBox_EditSexPatientDetailWindow.SelectedIndex = 1; }

            if (PD.DeviceCurrentWeight != "")
            {
                showImage((long)Convert.ToDouble(PD.DeviceCurrentWeight));

            }

            TextWeightLeft_PatientDetailWindow.Text = PD.DeviceCurrentWeight;
            if (PD.DeviceBattery != "")
            {
                ProgressDeviceHealth_PatientDetailWindow.Value = float.Parse(PD.DeviceBattery);
            }
        }

        public PatientDetail()
        {
           
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            

            InitializeComponent();
        }

        public void showImage(long caseSwitch)
        {
            Uri uriSource;
            int a=1;    
             if(caseSwitch>900.0){a=1;}else if(caseSwitch>800.0){a=2;}else if(caseSwitch>700.0){a=3;}else if(caseSwitch>600.0){a=4;}else if(caseSwitch>500.0){a=5;}
             else if (caseSwitch > 400.0) {a=6;} else if (caseSwitch > 300.0) {a=7;} else if (caseSwitch > 200.0) {a=8;} else if (caseSwitch > 100.0) {a=9 ;}
             else if (caseSwitch < 100.0) {a = 10;}  

            switch (a)
            {
                case 1:
                    Console.WriteLine("Case 1");
                    uriSource = new Uri(@"/Resources/Smart_IV_Meter_Bag_1.png", UriKind.RelativeOrAbsolute);
                    ImageDeviceWeight_PatientDetailWindow.Source = new BitmapImage(uriSource);

                    break;
                case 2:
                    Console.WriteLine("Case 2");
                    uriSource = new Uri(@"/Resources/Smart_IV_Meter_Bag_2.png", UriKind.RelativeOrAbsolute);
                    ImageDeviceWeight_PatientDetailWindow.Source = new BitmapImage(uriSource);
                    break;
                case 3:
                    Console.WriteLine("Case 3");
                    uriSource = new Uri(@"/Resources/Smart_IV_Meter_Bag_3.png", UriKind.RelativeOrAbsolute);
                    ImageDeviceWeight_PatientDetailWindow.Source = new BitmapImage(uriSource);
                    break;
                case 4:
                    Console.WriteLine("Case 4");
                    uriSource = new Uri(@"/Resources/Smart_IV_Meter_Bag_4.png", UriKind.RelativeOrAbsolute);
                    ImageDeviceWeight_PatientDetailWindow.Source = new BitmapImage(uriSource);
                    break;
                case 5:
                    Console.WriteLine("Case 5");
                    uriSource = new Uri(@"/Resources/Smart_IV_Meter_Bag_5.png", UriKind.RelativeOrAbsolute);
                    ImageDeviceWeight_PatientDetailWindow.Source = new BitmapImage(uriSource);
                    break;
                case 6:
                    Console.WriteLine("Case 6");
                    uriSource = new Uri(@"/Resources/Smart_IV_Meter_Bag_6.png", UriKind.RelativeOrAbsolute);
                    ImageDeviceWeight_PatientDetailWindow.Source = new BitmapImage(uriSource);
                    break;
                case 7:
                    Console.WriteLine("Case 7");
                    uriSource = new Uri(@"/Resources/Smart_IV_Meter_Bag_7.png", UriKind.RelativeOrAbsolute);
                    ImageDeviceWeight_PatientDetailWindow.Source = new BitmapImage(uriSource);
                    break;
                case 8:
                    Console.WriteLine("Case 8");
                    uriSource = new Uri(@"/Resources/Smart_IV_Meter_Bag_8.png", UriKind.RelativeOrAbsolute);
                    ImageDeviceWeight_PatientDetailWindow.Source = new BitmapImage(uriSource);
                    break;
                case 9:
                    Console.WriteLine("Case 9");
                    uriSource = new Uri(@"/Resources/Smart_IV_Meter_Bag_9.png", UriKind.RelativeOrAbsolute);
                    ImageDeviceWeight_PatientDetailWindow.Source = new BitmapImage(uriSource);
                    break;
                case 10:
                    Console.WriteLine("Case 9");
                    uriSource = new Uri(@"/Resources/Smart_IV_Meter_Bag_9E.png", UriKind.RelativeOrAbsolute);
                    ImageDeviceWeight_PatientDetailWindow.Source = new BitmapImage(uriSource);
                    break;
                default:
                    Console.WriteLine("Default case");
                    uriSource = new Uri(@"/Resources/Smart_IV_Meter_Bag_1.png", UriKind.RelativeOrAbsolute);
                    ImageDeviceWeight_PatientDetailWindow.Source = new BitmapImage(uriSource);
                    break;
            }
        }

        private void SaveButtonClick_PatientDetail(object sender, RoutedEventArgs e)
        {

            if ((string)Save_PatientDetails.Content == "Edit")
            {
                unlockEditables();
                Save_PatientDetails.Content = "Save";
                Discharge_Patient.Content = "Cancel";
            }
            else if ((string)Save_PatientDetails.Content == "Save") {


                            if (TextBox_EditFirstNamePatientDetailWindow.Text != null && TextBox_EditLastNamePatientDetailWindow.Text != null)
                            {
                                string query = "UPDATE wimtach.patientbasicinfo SET firstName ='" + TextBox_EditFirstNamePatientDetailWindow.Text + "',lastName ='" + TextBox_EditLastNamePatientDetailWindow.Text + "',middleName='" + TextBox_EditMiddleNamePatientDetailWindow.Text + "',sex ='" + ComboBox_EditSexPatientDetailWindow.Text + "'WHERE patientID =" + hiddenFieldPatientID_PatientDetails.Content + ";";
                                MessageBox.Show(this, query);

                                if (!(query == null))
                                {
                                    DatabaseHelper dbhelper = new DatabaseHelper();
                                    MySqlCommand cmd = dbhelper.getCommand();
                                    MySqlConnection con = dbhelper.getConnection();
                                    if (cmd == null && con == null) { MessageBox.Show(this, "Null command or connection object"); }
                                    int a = dbhelper.ExecuteNonQuery(query, con, cmd);
                                    if (!(a == 0))
                                    {
                                        MessageBox.Show(this, " Number of Updated Record " + a);

                                    }
                                    else
                                    {
                                        MessageBox.Show(this, " No Record Updated ");

                                    }
                                }
                            }



                            lockEditables();
                            Save_PatientDetails.Content = "Edit";
                            Discharge_Patient.Content = "Discharge";
            
            
            }









        }
        private void DischargeButtonClick_PatientDetail(object sender, RoutedEventArgs e)
        {
           
            MessageBoxResult MessageResult = MessageBox.Show("Are You Sure You want To Completly remove this patient from system", "Warning", MessageBoxButton.YesNo);

            if (MessageResult == MessageBoxResult.Yes)
            {
                var query = new List<string>();
                query.Add("UPDATE wimtach.device SET deviceStatus = 'ONLINE' WHERE deviceID =(SELECT deviceMacID FROM wimtach.patientbasicinfo where patientID = '" + hiddenFieldPatientID_PatientDetails.Content + "');");
                query.Add("delete from patientadmissioninfo where patientID=" + hiddenFieldPatientID_PatientDetails.Content + "");
                query.Add("delete from patientbasicinfo where patientID=" + hiddenFieldPatientID_PatientDetails.Content +";");
                DatabaseHelper dbhelper = new DatabaseHelper();
                MySqlCommand cmd = dbhelper.getCommand();
                MySqlConnection con = dbhelper.getConnection();
                if (cmd == null && con == null) { MessageBox.Show(this, "Null command or connection object"); }
                int a = dbhelper.ExecuteNonQueryBatch(query, con, cmd);
                Console.WriteLine("Discharge button number of query executed" + a);
                this.Close();
                


            }
            else if (MessageResult == MessageBoxResult.No)
            {
                //do something else
            }
        }

        public void unlockEditables()
        {
            TextBox_EditFirstNamePatientDetailWindow.IsEnabled = true;
            TextBox_EditLastNamePatientDetailWindow.IsEnabled = true;
            TextBox_EditMiddleNamePatientDetailWindow.IsEnabled = true;
            ComboBox_EditSexPatientDetailWindow.IsEnabled = true;
        }
        public void lockEditables()
        {
            TextBox_EditFirstNamePatientDetailWindow.IsEnabled = false;
            TextBox_EditLastNamePatientDetailWindow.IsEnabled = false;
            TextBox_EditMiddleNamePatientDetailWindow.IsEnabled = false;
            ComboBox_EditSexPatientDetailWindow.IsEnabled = false;

        }


    }
}
