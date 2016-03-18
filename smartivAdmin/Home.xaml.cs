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
using System.Data;
using MySql.Data;
using MySql.Data.Entity;
using MySql.Data.MySqlClient;
using smartivAdmin.ViewModels;

namespace smartivAdmin
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Home : Window
    {   

       

        public Home()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            DataContext = new HomeViewModel();
        }


        // QuickTAskPannel

        private void QuickTaskPannel_Addpatient_Click(object sender, RoutedEventArgs e)
        {
            TabIteam_ManagePatient.IsSelected = true;
            TabIteam_ManagePatient_AddPatient.IsSelected = true;
        }
        private void QuickTaskPannel_Addnurse_Click(object sender, RoutedEventArgs e)
        {
            TabIteam_ManageNurse.IsSelected = true;
            TabIteam_ManageNurse_AddNurse.IsSelected = true;
        }


        // Tab Wise Events 
        
        //-------------->>>>>Search Patient Tab in manage patient tab
        
        // Serch Button On click event
        private void  tabSearchPatientbtnSearch_Click(object sender, RoutedEventArgs e)
        {
            string query=null;
            if ((bool)ChechBoxSearchPatientbyFN.IsChecked)
            {
                query = "SELECT * FROM WIMTACH.patientbasicinfo where  firstName like'%" + tabsearchpatient_texboxPatientserch.Text + "%';";

            }else if ((bool)ChechBoxSearchPatientbyLN.IsChecked){

                query = "SELECT * FROM WIMTACH.patientbasicinfo where  lastName like '%" + tabsearchpatient_texboxPatientserch.Text + "%';";
            }
            else if ((bool)ChechBoxSearchPatientbyID.IsChecked)
            {
                query = "SELECT * FROM WIMTACH.patientbasicinfo where  patientID like'%" + tabsearchpatient_texboxPatientserch.Text + "%';";
            }
            else
            {
                MessageBox.Show(this, "Please Select Search-By Filter Box");
            }

            if (!(query == null))
            {
                DatabaseHelper dbhelper = new DatabaseHelper();
                MySqlCommand cmd = dbhelper.getCommand();
                MySqlConnection con= dbhelper.getConnection();
                if (cmd == null && con == null) { MessageBox.Show(this, "Null command or connection object"); }
                MySql.Data.MySqlClient.MySqlDataAdapter a = dbhelper.ExecuteCommandForAdapter(query, con, cmd);
                if (!(a == null))
                {   
                    DataTable table = new DataTable();
                    a.Fill(table);
                    DataGridSerchPatient.DataContext = table.DefaultView;

                    DataGridSerchPatient.Columns[0].Header = "ID";
                    DataGridSerchPatient.Columns[1].Header = "First Name";
                    DataGridSerchPatient.Columns[2].Header = "Last Name";
                    DataGridSerchPatient.Columns[3].Header = "Middle Name";
                    DataGridSerchPatient.Columns[4].Header = "Sex";
                    DataGridSerchPatient.Columns[5].Header = "Device";
                    DataGridSerchPatient.Columns[6].Header = "Weight of Bag";
                    DataGridSerchPatient.Columns[7].Header = "Time of Reading";
                    DataGridSerchPatient.Columns[8].Header = "Battery Status";



                }
                else
                {
                    MessageBox.Show(this, "null adapter");
                }

            }




           
            

        }


        // Save Button on click Event
        private void serchPatientSaveButton_Click(object sender, RoutedEventArgs e)
        {

            if (TextBox_EditFirstNamePatientSearch.Text != null && TextBox_EditLastNamePatientSearch.Text != null)
            {
                string query = "UPDATE wimtach.patientbasicinfo SET firstName ='" + TextBox_EditFirstNamePatientSearch.Text + "',lastName ='" + TextBox_EditLastNamePatientSearch.Text + "',middleName='" + TextBox_EditMiddleNamePatientSearch.Text + "',sex ='" + ComboBox_EditSexPatientSearch.Text + "'WHERE patientID =" + hiddenFieldPatientID_PatientSearch.Content + ";";
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
                        MessageBox.Show(this, " No of Updated Record " + a);
                        
                        ClearEditable();
                    }
                    else
                    {
                        MessageBox.Show(this, " No Record Updated ");

                    }
                }
            }
        }

        private void ClearEditable()
        {
            hiddenFieldPatientID_PatientSearch.Content =null;
            TextBox_EditFirstNamePatientSearch.Text = null;
            TextBox_EditLastNamePatientSearch.Text = null;
            TextBox_EditMiddleNamePatientSearch.Text = null;
            ComboBox_EditSexPatientSearch.SelectedIndex =-1;
        } 


        // For selecting current index of DataGrid 
        private void DataGridSerchPatient_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if ((DataRowView)DataGridSerchPatient.SelectedItem != null)
            {
                DataRowView row = (DataRowView)DataGridSerchPatient.SelectedItem;
                DataRow datarow = row.Row;
                hiddenFieldPatientID_PatientSearch.Content = (string)datarow[0].ToString();
                TextBox_EditFirstNamePatientSearch.Text = (string)datarow[1].ToString();
                TextBox_EditLastNamePatientSearch.Text = (string)datarow[2].ToString();
                TextBox_EditMiddleNamePatientSearch.Text = (string)datarow[3].ToString();
                if ((string)datarow[4].ToString()=="MALE"){ComboBox_EditSexPatientSearch.SelectedIndex = 0;}else { ComboBox_EditSexPatientSearch.SelectedIndex = 1; }

                Patient p = new Patient();
                p.FirstName = (string)datarow[1].ToString();
                p.LastName = (string)datarow[2].ToString();
                p.MiddleName = (string)datarow[3].ToString();
                p.Sex = (string)datarow[4].ToString();
                p.DeviceCurrentWeight = (string)datarow[6].ToString();
                p.DeviceBattery = (string)datarow[8].ToString();
                p.ID = (string)datarow[0].ToString();
                var win2 = new PatientDetail(p);
                win2.Show();
            
            }


           
               

        }

        // For Dynamic Search 
        private void textBoxPatientSearch_OnChange(object sender, RoutedEventArgs e)
        {

            if ((bool)CheckBoxTypeoSerchON.IsChecked) { 

                                string query = null;
                                if ((bool)ChechBoxSearchPatientbyFN.IsChecked)
                                {
                                    query = "SELECT * FROM WIMTACH.patientbasicinfo where  firstName like'%" + tabsearchpatient_texboxPatientserch.Text + "%';";

                                }
                                else if ((bool)ChechBoxSearchPatientbyLN.IsChecked)
                                {

                                    query = "SELECT * FROM WIMTACH.patientbasicinfo where  lastName like '%" + tabsearchpatient_texboxPatientserch.Text + "%';";
                                }
                                else if ((bool)ChechBoxSearchPatientbyID.IsChecked)
                                {
                                    query = "SELECT * FROM WIMTACH.patientbasicinfo where  patientID like'%" + tabsearchpatient_texboxPatientserch.Text + "%';";
                                }
                                else
                                {
                                    MessageBox.Show(this, "Please Select Search-By Filter Box");
                                }

                                if (!(query == null))
                                {
                                    DatabaseHelper dbhelper = new DatabaseHelper();
                                    MySqlCommand cmd = dbhelper.getCommand();
                                    MySqlConnection con = dbhelper.getConnection();
                                    if (cmd == null && con == null) { MessageBox.Show(this, "Null command or connection object"); }
                                    MySql.Data.MySqlClient.MySqlDataAdapter a = dbhelper.ExecuteCommandForAdapter(query, con, cmd);
                                    if (!(a == null))
                                    {
                                        DataTable table = new DataTable();
                                        a.Fill(table);
                                        DataGridSerchPatient.DataContext = table.DefaultView;

                                    }
                                    else
                                    {
                                        MessageBox.Show(this, "null adapter");
                                    }

                                }

            }
        }

        // Grouping Check Buttons at Patient Search Control Pannel EVENT_TRIGGERING 
        private void checkBoxTypeoSerchPatientSearch_OnCheck(object sender, RoutedEventArgs e)
        {
            if ((bool)CheckBoxTypeoSerchON.IsChecked)
            {
                SerchButton_SerchPatientTab.IsEnabled = false;
            }
            else
            {
                SerchButton_SerchPatientTab.IsEnabled = true;
            }
        }
        private void  checkBoxFNPatientSearch_OnCheck(object sender, RoutedEventArgs e)
        {
            ChechBoxSearchPatientbyID.IsChecked = false;
            ChechBoxSearchPatientbyLN.IsChecked = false;
        }
        private void checkBoxLNPatientSearch_OnCheck(object sender, RoutedEventArgs e)
        {
            ChechBoxSearchPatientbyID.IsChecked = false;
            ChechBoxSearchPatientbyFN.IsChecked = false;
        }
        private void checkBoxIDPatientSearch_OnCheck(object sender, RoutedEventArgs e)
        {
            ChechBoxSearchPatientbyFN.IsChecked = false;
            ChechBoxSearchPatientbyLN.IsChecked = false;
        }
      
      



        // --------------->>>>>>>>>>ADD Patient tab in manage patient tab 

        private void AddNewPatientOnClick_TabAddPatient(object sender, RoutedEventArgs e)
        {

            if (FirstName_AddPatientTab.Text != "" && LastName_AddPatientTab.Text != "")
                {

                    List<string> query = null;
                    
                    if (LableDeviceMac_AddPatientTab.Content != "" && lableNurse_AddPatientTab.Content != "" && LableBed_AddPatientTab.Content != "" ) {
                        query = new List<string>();
                        query.Add("INSERT INTO wimtach.patientbasicinfo(firstName,lastName,middleName,sex,deviceMacID)VALUES('" + FirstName_AddPatientTab.Text + "','" + LastName_AddPatientTab.Text + "','" + MiddleName_AddPatientTab.Text + "','" + SexCombobox_AddPatient.Text + "','" + LableDeviceMac_AddPatientTab.Content + "');");
                        query.Add("UPDATE wimtach.device SET deviceStatus = 'ACTIVE' WHERE deviceID = '" +LableDeviceMac_AddPatientTab.Content+ "';");
                        query.Add("INSERT INTO wimtach.patientadmissioninfo (patientID,nurseID,bedID) VALUES((select patientID from patientbasicinfo where firstName='"+FirstName_AddPatientTab.Text+"' and lastName='"+LastName_AddPatientTab.Text+"'),"+lableNurse_AddPatientTab.Content+","+LableBed_AddPatientTab.Content+");");

                        MessageBox.Show(this, "Requested Transaction For"+ query[0] + query[1] + query[2]);
                    
                    }
                    else
                    {
                        MessageBox.Show(this, "You need to assign BED,NURSE And DEVICE in order To add new Patient");
                    }
  
                    if (!(query == null ))
                    {
                        try
                        {   
                            int a = 0;
                            DatabaseHelper dbhelper = new DatabaseHelper();
                            MySqlCommand cmd = dbhelper.getCommand();
                            MySqlConnection con = dbhelper.getConnection();
                            if (cmd == null && con == null)
                            { MessageBox.Show(this, "Null command or connection object"); }
                            else {
                                    a = dbhelper.ExecuteNonQueryBatch(query, con, cmd); }
                            
                            if (!(a == 0))
                            {
                                MessageBox.Show(this, " New Patient Added Succesfully " + a);

                                
                            }
                            else
                            {
                                MessageBox.Show(this, " No Record Updated ");

                            }

                        }
                        catch (Exception E)
                        {

                            MessageBox.Show(this, "" + E.Data + "*****" + E.Message);

                        }
                    }
                }




        }
        private void OnRefreshDeviceClick_TabAddPatient(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "SELECT deviceID FROM wimtach.device where deviceStatus='ONLINE';";
                DatabaseHelper dbhelper = new DatabaseHelper();
                MySqlCommand cmd = dbhelper.getCommand();
                MySqlConnection con = dbhelper.getConnection();
                if (cmd == null && con == null) { MessageBox.Show(this, "Null command or connection object"); }
                MySql.Data.MySqlClient.MySqlDataAdapter a= dbhelper.ExecuteCommandForAdapter(query, con, cmd);

                if (!(a == null))
                {
                    DataTable table = new DataTable();
                    a.Fill(table);
                    ComboBox_AddPatientDevice.DisplayMemberPath = "deviceID";
                    ComboBox_AddPatientDevice.ItemsSource = table.DefaultView;
                    
                }
                else
                {
                    MessageBox.Show(this, "No Device Avalable");
                }


            }
            catch (Exception E)
            {

            }
        }
        private void OnRefreshBedClick_TabAddPatient(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "SELECT bedId FROM wimtach.bed Where bedId Not IN (SELECT bedID FROM  patientadmissioninfo);";
                DatabaseHelper dbhelper = new DatabaseHelper();
                MySqlCommand cmd = dbhelper.getCommand();
                MySqlConnection con = dbhelper.getConnection();
                if (cmd == null && con == null) { MessageBox.Show(this, "Null command or connection object"); }
                MySql.Data.MySqlClient.MySqlDataAdapter a = dbhelper.ExecuteCommandForAdapter(query, con, cmd);

                if (!(a == null))
                {
                    DataTable table = new DataTable();
                    a.Fill(table);
                    ComboBox_AddPatientBed.DisplayMemberPath = "bedId";
                    ComboBox_AddPatientBed.ItemsSource = table.DefaultView;

                }
                else
                {
                    MessageBox.Show(this, "No Device Avalable");
                }


            }
            catch (Exception E)
            {

            }

        }
        private void ButtonAssignBed_OnClick(object sender, RoutedEventArgs e)
        {
            DataRowView A = (DataRowView)ComboBox_AddPatientBed.SelectedItem;
            if (A != null) { LableBed_AddPatientTab.Content = A.Row.Field<int>("bedId"); }
        }
        private void ButtonAssignDevice_OnClick(object sender, RoutedEventArgs e)
        {
            DataRowView A = (DataRowView)ComboBox_AddPatientDevice.SelectedItem;
            if (A != null) { LableDeviceMac_AddPatientTab.Content = A.Row.Field<string>("deviceID"); }
        }
        private void ButtonAssignNurse_OnClick(object sender, RoutedEventArgs e)
        {
            DataRowView A = (DataRowView)ComboBox_AddPatientNurse.SelectedItem;

            if (A != null) { lableNurse_AddPatientTab.Content = A.Row.Field<int>("nurseId"); }
        }
        private void OnRefreshNurseClick_TabAddPatient(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "SELECT nurseId, concat(firstName,\" \",lastName) As Nurse FROM wimtach.nurse;";
                DatabaseHelper dbhelper = new DatabaseHelper();
                MySqlCommand cmd = dbhelper.getCommand();
                MySqlConnection con = dbhelper.getConnection();
                if (cmd == null && con == null) { MessageBox.Show(this, "Null command or connection object"); }
                MySql.Data.MySqlClient.MySqlDataAdapter a = dbhelper.ExecuteCommandForAdapter(query, con, cmd);

                if (!(a == null))
                {
                    DataTable table = new DataTable();
                    a.Fill(table);
                    ComboBox_AddPatientNurse.DisplayMemberPath = "Nurse";
                    ComboBox_AddPatientNurse.SelectedValuePath = "nurseId";
                    ComboBox_AddPatientNurse.ItemsSource = table.DefaultView;
                }
                else
                {
                    MessageBox.Show(this, "No Device Avalable");
                }
            }
            catch (Exception E)
            {

            }
        }
        



        // ----------------->>>>>>>>> Search Nurse In Manage Nurse Tab


        private void tabSearchNursebtnSearch_Click(object sender , RoutedEventArgs e)
        {
            string query = null;
            if ((bool)ChechBoxSearchNursebyFN.IsChecked)
            {
                query = "SELECT * FROM WIMTACH.nurse where  firstName like'%" + tabsearchnurse_texboxnurseserch.Text + "%';";

            }
            else if ((bool)ChechBoxSearchNursebyLN.IsChecked)
            {

                query = "SELECT * FROM WIMTACH.patientbasicinfo where  lastName like '%" + tabsearchnurse_texboxnurseserch.Text + "%';";
            }
            else if ((bool)ChechBoxSearchNursebyID.IsChecked)
            {
                query = "SELECT * FROM WIMTACH.patientbasicinfo where  nurseId like'%" + tabsearchnurse_texboxnurseserch.Text + "%';";
            }
            else
            {
                MessageBox.Show(this, "Please Select Search-By Filter Box");
            }

            if (!(query == null))
            {
                DatabaseHelper dbhelper = new DatabaseHelper();
                MySqlCommand cmd = dbhelper.getCommand();
                MySqlConnection con = dbhelper.getConnection();
                if (cmd == null && con == null) { MessageBox.Show(this, "Null command or connection object"); }
                MySql.Data.MySqlClient.MySqlDataAdapter a = dbhelper.ExecuteCommandForAdapter(query, con, cmd);
                if (!(a == null))
                {
                    DataTable table = new DataTable();
                    a.Fill(table);
                    DataGridSearchNurse.DataContext = table.DefaultView;


                    DataGridSearchNurse.Columns[0].Header = "ID";
                    DataGridSearchNurse.Columns[1].Header = "First Name";
                    DataGridSearchNurse.Columns[2].Header = "Last Name";
                    DataGridSearchNurse.Columns[3].Header = "CurrentShift";
                    DataGridSearchNurse.Columns[4].Header = "User";
                   

                }
                else
                {
                    MessageBox.Show(this, "null adapter");
                }

            }

        }
        private void textBoxNurseSerch_OnChange(object sender, RoutedEventArgs e)
        {
            
        }
        private void DataGridSerchNurse_SelectedcellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {

        }
        private void checkBoxTypeoSerchNurseSearch_OnCheck(object sender, RoutedEventArgs e)
        {
            if ((bool)CheckBoxTypeoSerchON.IsChecked)
            {
                SerchButton_SerchNurseTab.IsEnabled = false;
            }
            else
            {
                SerchButton_SerchNurseTab.IsEnabled = true;
            }
        }
        private void checkBoxFNNurseSearch_OnCheck(object sender, RoutedEventArgs e)
        {
            ChechBoxSearchNursebyID.IsChecked = false;
            ChechBoxSearchNursebyLN.IsChecked = false;
        }
        private void checkBoxLNNurseSearch_OnCheck(object sender, RoutedEventArgs e)
        {
            ChechBoxSearchNursebyFN.IsChecked = false;
            ChechBoxSearchNursebyID.IsChecked = false;
        }
        private void checkBoxIDNurseSearch_OnCheck(object sender, RoutedEventArgs e)
        {
            ChechBoxSearchNursebyFN.IsChecked = false;
            ChechBoxSearchNursebyLN.IsChecked = false;
        }
        private void ComboBox_AddPatientDevice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }




        // ----------------->>>>>>>>>> Add Nurse In Manage Nurse TAb

        private void AddNurseButton_OnClick(object sender, RoutedEventArgs e)
        {

            List<string> query = null;
            if (TextBoxFirstName_TabAddNurse.Text != "" && TextBoxLastName_TabAddNurse.Text != "" && TextBoxUserName_TabAddNurse.Text != "" && TextBoxPassword_TabAddNurse.Text != "")
            {

                    query = new List<string>();

                    query.Add("INSERT INTO wimtach.user(userName,userType,password) VALUES('" + TextBoxUserName_TabAddNurse.Text + "','Nurse','" + TextBoxPassword_TabAddNurse.Text + "');");
                    query.Add("INSERT INTO wimtach.nurse(firstName,lastName,currentShift,userId)VALUES('" + TextBoxFirstName_TabAddNurse.Text + "','" + TextBoxLastName_TabAddNurse.Text + "','False',(select userId from user where userName='" + TextBoxUserName_TabAddNurse.Text+ "'));");
                    MessageBox.Show(this, "Requested Transaction For" + query[0] + query[1] );

                }
                else
                {
                    MessageBox.Show(this, "All The Fields Are mandatory ");
                }

                if (!(query == null))
                {
                    try
                    {
                        int a = 0;
                        DatabaseHelper dbhelper = new DatabaseHelper();
                        MySqlCommand cmd = dbhelper.getCommand();
                        MySqlConnection con = dbhelper.getConnection();
                        if (cmd == null && con == null)
                        { MessageBox.Show(this, "Null command or connection object"); }
                        else
                        {
                            a = dbhelper.ExecuteNonQueryBatch(query, con, cmd);
                        }

                        if (!(a == 0))
                        {
                            MessageBox.Show(this, " New Nurse Added Succesfully " + a);


                        }
                        else
                        {
                            MessageBox.Show(this, " No Record Updated ");

                        }

                    }
                    catch (Exception E)
                    {

                        MessageBox.Show(this, "" + E.Data + "*****" + E.Message);

                    }
                }




        }


        // ----------------->>>>>>>>>>>   AssignPatient In Manage Nurse TAb 

        private void assignPatient_OnClick(object sender , RoutedEventArgs e)
        {


        }










    }
}
