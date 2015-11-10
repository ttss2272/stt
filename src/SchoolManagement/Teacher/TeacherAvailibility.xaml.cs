using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using BusinessLayer;


namespace SchoolManagement.Teacher
{
    /// <summary>
    /// Interaction logic for TeacherAvailibility.xaml
    /// </summary>
    public partial class TeacherAvailibility : Window
    {
        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 07Nov2015
         * Purpose:- Decalre Variables
         * StartTime:-
         * EndTime:-
         */
        #region---------------------------------Declare variables Globally-------------------------------------
        BLTeacher objTeacher = new BLTeacher();
        int daycheckcount=0,cnn;
        string tmpStartTime, tmpEndTime;
        string [] StartTime;
        string [] EndTime;
        string[] s;
        #endregion

        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 07Nov2015
         * Purpose:-main
         * StartTime:-
         * EndTime:-
         */
        #region---------------------------------Main()-------------------------------------
        public TeacherAvailibility()
        {
            try
            {
                InitializeComponent();
                this.WindowState = WindowState.Maximized;
                this.Width = System.Windows.SystemParameters.PrimaryScreenWidth;
                this.Height = System.Windows.SystemParameters.PrimaryScreenHeight;
                ClearFields();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            
        }
        #endregion


        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 07Nov2015
         * Purpose:- Clear All Fiealds
         * StartTime:-
         * EndTime:-
         */
        #region---------------------------------ClearFields()-------------------------------------
        private void ClearFields()
        {
            BindTeacher();
            BindHours();
            BindMinutes();
            BindGrid();
        }
        #endregion
        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 07Nov2015
         * Purpose:-Click on Available for Same Time
         * StartTime:-
         * EndTime:-
         */
        #region---------------------------------chkAvailableSameTime()-------------------------------------
        private void chkAvailSameTime_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (chkAvailSameTime.IsChecked == true)
                {
                    DisableCheckBox();
                }
                else 
                {
                    EnableDropdown();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion
        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 07Nov2015
         * Purpose:- Click On Go Button
         * StartTime:-
         * EndTime:-
         */
        #region---------------------------------Button Go click()-------------------------------------
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GetTeacherAvailableDetails();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion

        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 07Nov2015
         * Purpose:- Click On Save Button
         * StartTime:-
         * EndTime:-
         */
        #region---------------------------------Button Save click()-------------------------------------
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SetParameters();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /*
         * CreatedBy:-Sameer Shinde
         * Created Date:- 09 Nov2015
         * Purpose:- Set Parameter for Save
         * StartTime:-
         * EndTime:-
         */
        private void SetParameters()
        {
            
            if (daycheckcount > 0)
            {
                int cnt = daycheckcount;
                string TempDay;
                if (cnt == 7)
                    {
                        CheckAllDays();
                    }
                for (int i = 0; i <= cnt; i++)
                {
                   if (chkMon.IsChecked == true)
                   {
                       s[i] = "Mon";
                   }
                   else if (chkTue.IsChecked == true)
                   {
                       s[i] = "Tue";
                   }
                   else if (chkWed.IsChecked == true)
                   {
                       s[i] = "Wed";
                   }
                   else if (chkThru.IsChecked == true)
                   {
                       s[i] = "Thru";
                   }
                   else if (chkFri.IsChecked == true)
                   {
                       s[i] = "Fri";
                   }
                   else if (chkSat.IsChecked == true)
                   {
                       s[i] = "Sat";
                   }
                   else if (chkSun.IsChecked == true)
                   {
                       s[i] = "Sun";
                   }
                   else
                   {
                       s[i] = "All Days Available";
                   }
                   TempDay = s[i];
                    //count start time to end time for all days
                    //if()
                    //{

                    //}
                   switch (s[i])
                   {
                       case ("Mon"):
                           {
                               tmpStartTime = chkStartHrs1.SelectedValue.ToString();
                               tmpStartTime += ":" + chkStartMin1.SelectedValue.ToString();

                               tmpEndTime = chkEndhrs1.SelectedValue.ToString();
                               tmpEndTime += ":" + EndMin1.SelectedValue.ToString();


                               break;
                           }
                   }
                }
            }

        }
        /*
        * CreatedBy:-Sameer Shinde
        * Created Date:- 09 Nov2015
        * Purpose:-Get Day for save
        * StartTime:-
        * EndTime:-
        */
        #region-----------------------------GetDay()----------------------------
        //private void GetDay()
        //{
   
        //    if (chkMon.IsChecked == true)
        //    {
        //        Day = "Mon";
        //    }
        //    else if (chkTue.IsChecked == true)
        //    {
        //        Day = "Tue";
        //    }
        //    else if (chkWed.IsChecked == true)
        //    {
        //        Day = "Wed";
        //    }
        //    else if (chkThru.IsChecked == true)
        //    {
        //        Day = "Thru";
        //    }
        //    else if (chkFri.IsChecked == true)
        //    {
        //        Day = "Fri";
        //    }
        //    else if (chkSat.IsChecked == true)
        //    {
        //        Day = "Sat";
        //    }
        //    else if (chkSun.IsChecked == true)
        //    {
        //        Day = "Sun";
        //    }
        //    else
        //    {
        //        Day = "All Days Available";
        //    }
           
        //}
        #endregion
        #endregion

        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 07Nov2015
         * Purpose:- Bind  Teacher To Drop Down
         * StartTime:-
         * EndTime:-
         */
        #region---------------------------------BindTeacher()-------------------------------------
        private void BindTeacher()
        {
            DataSet ds = objTeacher.BindTeacher(0);

            if (ds.Tables[0].Rows.Count > 0)
            {
                cmbTeacher.DataContext = null;
                cmbTeacher.DataContext = ds.Tables[0].DefaultView;
                cmbTeacher.DisplayMemberPath = ds.Tables[0].Columns["TeacherName"].ToString();
                cmbTeacher.SelectedValuePath = ds.Tables[0].Columns["TeacherID"].ToString();
                cmbTeacher.SelectedValue = "0";

                //ComboBoxItem item = new ComboBoxItem();
                //item.N = "Select";
                //item.v = 0;
               // cmbTeacher
            }

        }
        #endregion

        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 07Nov2015
         * Purpose:- Bind Timing
         * StartTime:-
         * EndTime:-
         */
        #region-----------------------------------------------------BindTiming---------------------------------------------------------------------
        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 07Nov2015
         * Purpose:-
         * StartTime:-
         * EndTime:-
         */
        #region---------------------------------------------------BindHours------------------------------------------------
        private void BindHours()
        {
            chkStartHrs.Items.Add("HRS");
            chkStartHrs1.Items.Add("HRS");
            chkStartHrs2.Items.Add("HRS");
            chkStartHrs3.Items.Add("HRS");
            chkStartHrs4.Items.Add("HRS");
            chkStartHrs5.Items.Add("HRS");
            chkStartHrs6.Items.Add("HRS");
            chkStartHrs7.Items.Add("HRS");

            chkEndhrs.Items.Add("HRS");
            chkEndhrs1.Items.Add("HRS");
            chkEndhrs2.Items.Add("HRS");
            chkEndhrs3.Items.Add("HRS");
            chkEndhrs4.Items.Add("HRS");
            chkEndhrs5.Items.Add("HRS");
            chkEndhrs6.Items.Add("HRS");
            chkEndhrs7.Items.Add("HRS");
            int i;
            for (i = 1; i <= 24; i++)
            {
                chkStartHrs.Items.Add(i);
                chkStartHrs1.Items.Add(i);
                chkStartHrs2.Items.Add(i);
                chkStartHrs3.Items.Add(i);
                chkStartHrs4.Items.Add(i);
                chkStartHrs5.Items.Add(i);
                chkStartHrs6.Items.Add(i);
                chkStartHrs7.Items.Add(i);

                chkEndhrs.Items.Add(i);
                chkEndhrs1.Items.Add(i);
                chkEndhrs2.Items.Add(i);
                chkEndhrs3.Items.Add(i);
                chkEndhrs4.Items.Add(i);
                chkEndhrs5.Items.Add(i);
                chkEndhrs6.Items.Add(i);
                chkEndhrs7.Items.Add(i);
            }
            chkStartHrs.SelectedIndex = 0;
            chkStartHrs1.SelectedIndex = 0;
            chkStartHrs2.SelectedIndex = 0;
            chkStartHrs3.SelectedIndex = 0;
            chkStartHrs4.SelectedIndex = 0;
            chkStartHrs5.SelectedIndex = 0;
            chkStartHrs6.SelectedIndex = 0;
            chkStartHrs7.SelectedIndex = 0;

            chkEndhrs.SelectedIndex = 0;
            chkEndhrs1.SelectedIndex = 0;
            chkEndhrs2.SelectedIndex = 0;
            chkEndhrs3.SelectedIndex = 0;
            chkEndhrs4.SelectedIndex = 0;
            chkEndhrs5.SelectedIndex = 0;
            chkEndhrs6.SelectedIndex = 0;
            chkEndhrs7.SelectedIndex = 0;

        }
        #endregion

        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 07Nov2015
         * Purpose:-
         * StartTime:-
         * EndTime:-
         */
        #region---------------------------------------------------BindMinutes------------------------------------------------
        private void BindMinutes()
        {
            chkStartMin.Items.Add("Min");
            chkStartMin1.Items.Add("Min");
            chkStartMin2.Items.Add("Min");
            chkStartMin3.Items.Add("Min");
            chkStartMin4.Items.Add("Min");
            chkStartMin5.Items.Add("Min");
            chkStartMin6.Items.Add("Min");
            chkStartMin7.Items.Add("Min");

            EndMin.Items.Add("Min");
            EndMin1.Items.Add("Min");
            EndMin2.Items.Add("Min");
            EndMin3.Items.Add("Min");
            EndMin4.Items.Add("Min");
            EndMin5.Items.Add("Min");
            EndMin6.Items.Add("Min");
            EndMin7.Items.Add("Min");

                        int i;
                        for (i = 0; i <= 59; i++)
                        {
                            chkStartMin.Items.Add(i);
                            chkStartMin1.Items.Add(i);
                            chkStartMin2.Items.Add(i);
                            chkStartMin3.Items.Add(i);
                            chkStartMin4.Items.Add(i);
                            chkStartMin5.Items.Add(i);
                            chkStartMin6.Items.Add(i);
                            chkStartMin7.Items.Add(i);

                            EndMin.Items.Add(i);
                            EndMin1.Items.Add(i);
                            EndMin2.Items.Add(i);
                            EndMin3.Items.Add(i);
                            EndMin4.Items.Add(i);
                            EndMin5.Items.Add(i);
                            EndMin6.Items.Add(i);
                            EndMin7.Items.Add(i);
                        }

                        chkStartMin.SelectedIndex = 0;
                        chkStartMin1.SelectedIndex = 0;
                        chkStartMin2.SelectedIndex = 0;
                        chkStartMin3.SelectedIndex = 0;
                        chkStartMin4.SelectedIndex = 0;
                        chkStartMin5.SelectedIndex = 0;
                        chkStartMin6.SelectedIndex = 0;
                        chkStartMin7.SelectedIndex = 0;

                        EndMin.SelectedIndex = 0;
                        EndMin1.SelectedIndex = 0;
                        EndMin2.SelectedIndex = 0;
                        EndMin3.SelectedIndex = 0;
                        EndMin4.SelectedIndex = 0;
                        EndMin5.SelectedIndex = 0;
                        EndMin6.SelectedIndex = 0;
                        EndMin7.SelectedIndex = 0;


        }

        #endregion
        #endregion
        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 07Nov2015
         * Purpose:- Check Boxes Checked
         * StartTime:-
         * EndTime:-
         */
        #region----------------------------------------------------------------CheckBoxes--------------------------------------------
        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 07Nov2015
         * Purpose:- Click on Available All Days
         * StartTime:-
         * EndTime:-
         */
        #region---------------------------------------------------Chkallday------------------------------------------------
        private void chkAvailAllDay_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (chkAvailAllDay.IsChecked == true)
                {
                    CheckAllDays();
                }
                else
                {
                    UnchekAllDays();
                    
 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion

        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 07Nov2015
         * Purpose:-Click on  Available on Monday
         * StartTime:-
         * EndTime:-
         */
        #region---------------------------------------------------ChkMon------------------------------------------------
        private void chkMon_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (chkMon.IsChecked == true)
                {
                    ++daycheckcount;
                }
                else if(chkMon.IsChecked==false)
                {
                    --daycheckcount;
                }
                if (daycheckcount == 7)
                {
                    chkAvailAllDay.IsChecked = true;
                }
                else
                {
                    chkAvailAllDay.IsChecked = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion
        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 07Nov2015
         * Purpose:-Click on  Available on Tuesday
         * StartTime:-
         * EndTime:-
         */
        #region---------------------------------------------------ChkTue------------------------------------------------
        private void chkTue_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (chkTue.IsChecked == true)
                {
                    ++daycheckcount;
                }
                else if (chkTue.IsChecked == false)
                {
                    --daycheckcount;
                }
                if (daycheckcount == 7)
                {
                    chkAvailAllDay.IsChecked = true;
                }
                else
                {
                    chkAvailAllDay.IsChecked = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion

        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 07Nov2015
         * Purpose:-Click on  Available on Wednsday
         * StartTime:-
         * EndTime:-
         */
        #region---------------------------------------------------ChkWed------------------------------------------------
        private void chkWed_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (chkWed.IsChecked == true)
                {
                    ++daycheckcount;
                }
                else if (chkWed.IsChecked == false)
                {
                    --daycheckcount;
                }
                if (daycheckcount == 7)
                {
                    chkAvailAllDay.IsChecked = true;
                }
                else
                {
                    chkAvailAllDay.IsChecked = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion
        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 07Nov2015
         * Purpose:-Click on  Available on Trusday
         * StartTime:-
         * EndTime:-
         */
        #region---------------------------------------------------ChkThru------------------------------------------------
        private void chkThru_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (chkThru.IsChecked == true)
                {
                    ++daycheckcount;
                }
                else if (chkThru.IsChecked == false)
                {
                    --daycheckcount;
                }
                if (daycheckcount == 7)
                {
                    chkAvailAllDay.IsChecked = true;
                }
                else
                {
                    chkAvailAllDay.IsChecked = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion
        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 07Nov2015
         * Purpose:-Click on  Available on Friday
         * StartTime:-
         * EndTime:-
         */
        #region---------------------------------------------------ChkFri------------------------------------------------
        private void chkFri_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (chkFri.IsChecked == true)
                {
                    ++daycheckcount;
                }
                else if (chkFri.IsChecked == false)
                {
                    --daycheckcount;
                }
                if (daycheckcount == 7)
                {
                    chkAvailAllDay.IsChecked = true;
                }
                else
                {
                    chkAvailAllDay.IsChecked = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion
        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 07Nov2015
         * Purpose:-Click on  Available on Saturday
         * StartTime:-
         * EndTime:-
         */
        #region---------------------------------------------------ChkSat------------------------------------------------
        private void chkSat_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (chkSat.IsChecked == true)
                {
                    ++daycheckcount;
                }
                else if (chkSat.IsChecked == false)
                {
                    --daycheckcount;
                }
                if (daycheckcount == 7)
                {
                    chkAvailAllDay.IsChecked = true;
                }
                else
                {
                    chkAvailAllDay.IsChecked = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion
        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 07Nov2015
         * Purpose:- Click on  Available Sunday
         * StartTime:-
         * EndTime:-
         */
        #region---------------------------------------------------ChkSun------------------------------------------------
        private void chkSun_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (chkSun.IsChecked == true)
                {
                    ++daycheckcount;
                }
                else if (chkSun.IsChecked == false)
                {
                    --daycheckcount;
                }
                if (daycheckcount == 7)
                {
                    chkAvailAllDay.IsChecked = true;
                }
                else
                {
                    chkAvailAllDay.IsChecked = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion
        #endregion

        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 07Nov2015
         * Purpose:- Enable Drop Down
         * StartTime:-
         * EndTime:-
         */
        #region----------------------------------------------------------------EnableDropdown--------------------------------------------
        private void EnableDropdown()
        {
            gbSameTime.Visibility = Visibility.Hidden;

            chkStartHrs1.IsEnabled = true;
            chkStartHrs2.IsEnabled = true;
            chkStartHrs3.IsEnabled = true;
            chkStartHrs4.IsEnabled = true;
            chkStartHrs5.IsEnabled = true;
            chkStartHrs6.IsEnabled = true;
            chkStartHrs7.IsEnabled = true;

            chkEndhrs1.IsEnabled = true;
            chkEndhrs2.IsEnabled = true;
            chkEndhrs3.IsEnabled = true;
            chkEndhrs4.IsEnabled = true;
            chkEndhrs5.IsEnabled = true;
            chkEndhrs6.IsEnabled = true;
            chkEndhrs7.IsEnabled = true;
            chkEndhrs1.IsEnabled = true;
            chkEndhrs1.IsEnabled = true;

            chkStartMin1.IsEnabled = true;
            chkStartMin2.IsEnabled = true;
            chkStartMin3.IsEnabled = true;
            chkStartMin4.IsEnabled = true;
            chkStartMin5.IsEnabled = true;
            chkStartMin6.IsEnabled = true;
            chkStartMin7.IsEnabled = true;

            EndMin1.IsEnabled = true;
            EndMin2.IsEnabled = true;
            EndMin3.IsEnabled = true;
            EndMin4.IsEnabled = true;
            EndMin5.IsEnabled = true;
            EndMin6.IsEnabled = true;
            EndMin7.IsEnabled = true;
        }
        #endregion

        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 07Nov2015
         * Purpose:-Disable Dropdown
         * StartTime:-
         * EndTime:-
         */
        #region----------------------------------------------------------------DisebleDropdown--------------------------------------------
        private void DisableCheckBox()
        {
            gbSameTime.Visibility = Visibility.Visible;
            chkStartHrs1.IsEnabled = false;
            chkStartHrs2.IsEnabled = false;
            chkStartHrs3.IsEnabled = false;
            chkStartHrs4.IsEnabled = false;
            chkStartHrs5.IsEnabled = false;
            chkStartHrs6.IsEnabled = false;
            chkStartHrs7.IsEnabled = false;

            chkEndhrs1.IsEnabled = false;
            chkEndhrs2.IsEnabled = false;
            chkEndhrs3.IsEnabled = false;
            chkEndhrs4.IsEnabled = false;
            chkEndhrs5.IsEnabled = false;
            chkEndhrs6.IsEnabled = false;
            chkEndhrs7.IsEnabled = false;
            chkEndhrs1.IsEnabled = false;
            chkEndhrs1.IsEnabled = false;

            chkStartMin1.IsEnabled = false;
            chkStartMin2.IsEnabled = false;
            chkStartMin3.IsEnabled = false;
            chkStartMin4.IsEnabled = false;
            chkStartMin5.IsEnabled = false;
            chkStartMin6.IsEnabled = false;
            chkStartMin7.IsEnabled = false;

            EndMin1.IsEnabled = false;
            EndMin2.IsEnabled = false;
            EndMin3.IsEnabled = false;
            EndMin4.IsEnabled = false;
            EndMin5.IsEnabled = false;
            EndMin6.IsEnabled = false;
            EndMin7.IsEnabled = false;
 
        }
        #endregion

        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 07Nov2015
         * Purpose:-Bind data grid
         * StartTime:-
         * EndTime:-
         */
        #region-------------------------------------------------------------------BindGrid()----------------------------------------
        private void BindGrid()
        {
            DataSet ds = objTeacher.BindTeacherAvail();

            if (ds.Tables[0].Rows.Count > 0)
            {
                dgTeacherAvail.DataContext = null;
                dgTeacherAvail.DataContext = ds;
            }
        }
        #endregion

        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 07Nov2015
         * Purpose:- Get Teacher Available Details
         * StartTime:-
         * EndTime:-
         */
        #region---------------------------------------------------------GetTeacherAvailableDetails()--------------------------------
        private void GetTeacherAvailableDetails()
        {
            if (cmbTeacher.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("Please Select Teacher.");
            }
            else
            {
                DataSet ds = objTeacher.GetTeacherAvailableDetail(Convert.ToInt32(cmbTeacher.SelectedValue));
                if (ds.Tables[0].Rows.Count > 0)
                {
                    int cnt = ds.Tables[0].Rows.Count;
                    string s;
                    if (cnt == 7)
                    {
                        CheckAllDays();
                    }
                    for (int i = 0; i <= cnt; i++)
                    {
                        s = ds.Tables[0].Rows[i]["Day"].ToString();

                        if ((ds.Tables[0].Rows[0]["StartTime"].ToString() == ds.Tables[0].Rows[0]["StartTime"]) && (ds.Tables[0].Rows[0]["EndTime"] == ds.Tables[0].Rows[0]["EndTime"]))
                        {
                            cnn++;

                        }
                        switch (s)
                        {
                            case ("Mon"):
                                {
                                    tmpStartTime =  ds.Tables[0].Rows[i]["StartTime"].ToString();
                                    string [] StartTime = tmpStartTime.Split(':');
                                    chkStartHrs1.Text = StartTime[0];
                                    if (StartTime[1] == "00")
                                    { chkStartMin1.Text = "0"; }
                                    else
                                    { chkStartMin1.Text = StartTime[1]; }
                                    
                                    tmpEndTime = ds.Tables[0].Rows[i]["EndTime"].ToString();
                                    string[] EndTime = tmpEndTime.Split(':');
                                    chkEndhrs1.Text = EndTime[0];
                                    if (EndTime[1] == "00")
                                    { EndMin1.Text = "0"; }
                                    else
                                    {EndMin1.Text=EndTime[1];}
                                    break;
                                }
                            case ("Tue"):
                                {
                                    tmpStartTime = ds.Tables[0].Rows[i]["StartTime"].ToString();
                                    string[] StartTime = tmpStartTime.Split(':');
                                    chkStartHrs2.Text = StartTime[0];
                                    if (StartTime[1] == "00")
                                    { chkStartMin2.Text = "0"; }
                                    else
                                    { chkStartMin2.Text = StartTime[1]; }

                                    tmpEndTime = ds.Tables[0].Rows[i]["EndTime"].ToString();
                                    string[] EndTime = tmpEndTime.Split(':');
                                    chkEndhrs2.Text = EndTime[0];
                                    if (EndTime[1] == "00")
                                    { EndMin2.Text = "0"; }
                                    else
                                    { EndMin2.Text = EndTime[1]; }
                                    break;
                                }
                            case ("Wed"):
                                {
                                    tmpStartTime = ds.Tables[0].Rows[i]["StartTime"].ToString();
                                    string[] StartTime = tmpStartTime.Split(':');
                                    chkStartHrs3.Text = StartTime[0];
                                    if (StartTime[1] == "00")
                                    { chkStartMin3.Text = "0"; }
                                    else
                                    { chkStartMin3.Text = StartTime[1]; }

                                    tmpEndTime = ds.Tables[0].Rows[i]["EndTime"].ToString();
                                    string[] EndTime = tmpEndTime.Split(':');
                                    chkEndhrs3.Text = EndTime[0];
                                    if (EndTime[1] == "00")
                                    { EndMin3.Text = "0"; }
                                    else
                                    { EndMin3.Text = EndTime[1]; }
                                    break;
                                }
                            case ("Thru"):
                                {
                                    tmpStartTime = ds.Tables[0].Rows[i]["StartTime"].ToString();
                                    string[] StartTime = tmpStartTime.Split(':');
                                    chkStartHrs4.Text = StartTime[0];
                                    if (StartTime[1] == "00")
                                    { chkStartMin4.Text = "0"; }
                                    else
                                    { chkStartMin4.Text = StartTime[1]; }

                                    tmpEndTime = ds.Tables[0].Rows[i]["EndTime"].ToString();
                                    string[] EndTime = tmpEndTime.Split(':');
                                    chkEndhrs4.Text = EndTime[0];
                                    if (EndTime[1] == "00")
                                    { EndMin4.Text = "0"; }
                                    else
                                    { EndMin4.Text = EndTime[1]; }
                                    break;
                                }

                            case ("Fri"):
                                {
                                    tmpStartTime = ds.Tables[0].Rows[i]["StartTime"].ToString();
                                    string[] StartTime = tmpStartTime.Split(':');
                                    chkStartHrs5.Text = StartTime[0];
                                    if (StartTime[1] == "00")
                                    { chkStartMin5.Text = "0"; }
                                    else
                                    { chkStartMin5.Text = StartTime[1]; }

                                    tmpEndTime = ds.Tables[0].Rows[i]["EndTime"].ToString();
                                    string[] EndTime = tmpEndTime.Split(':');
                                    chkEndhrs5.Text = EndTime[0];
                                    if (EndTime[1] == "00")
                                    { EndMin5.Text = "0"; }
                                    else
                                    { EndMin5.Text = EndTime[1]; }
                                    break;
                                }
                            case ("Sat"):
                                {
                                    tmpStartTime = ds.Tables[0].Rows[i]["StartTime"].ToString();
                                    string[] StartTime = tmpStartTime.Split(':');
                                    chkStartHrs6.Text = StartTime[0];
                                    if (StartTime[1] == "00")
                                    { chkStartMin6.Text = "0"; }
                                    else
                                    { chkStartMin6.Text = StartTime[1]; }

                                    tmpEndTime = ds.Tables[0].Rows[i]["EndTime"].ToString();
                                    string[] EndTime = tmpEndTime.Split(':');
                                    chkEndhrs6.Text = EndTime[0];
                                    if (EndTime[1] == "00")
                                    { EndMin6.Text = "0"; }
                                    else
                                    { EndMin6.Text = EndTime[1]; }
                                    break;
                                }
                            case ("Sun"):
                                {
                                    tmpStartTime = ds.Tables[0].Rows[i]["StartTime"].ToString();
                                    string[] StartTime = tmpStartTime.Split(':');
                                    chkStartHrs7.Text = StartTime[0];
                                    if (StartTime[1] == "00")
                                    { chkStartMin7.Text = "0"; }
                                    else
                                    { chkStartMin7.Text = StartTime[1]; }

                                    tmpEndTime = ds.Tables[0].Rows[i]["EndTime"].ToString();
                                    string[] EndTime = tmpEndTime.Split(':');
                                    chkEndhrs7.Text = EndTime[0];
                                    if (EndTime[1] == "00")
                                    { EndMin7.Text = "0"; }
                                    else
                                    { EndMin7.Text = EndTime[1]; }
                                    break;
                                }
                        }

                        if (cnn == 7)
                        {
                            chkAvailSameTime.IsChecked = true;

                            tmpStartTime = ds.Tables[0].Rows[0]["StartTime"].ToString();
                            string[] StartTime = tmpStartTime.Split(':');
                            chkStartHrs.Text = StartTime[0];
                            if (StartTime[1] == "00")
                            { chkStartMin.Text = "0"; }
                            else
                            { chkStartMin7.Text = StartTime[1]; }

                            tmpEndTime = ds.Tables[0].Rows[0]["EndTime"].ToString();
                            string[] EndTime = tmpEndTime.Split(':');
                            chkEndhrs.Text = EndTime[0];
                            if (EndTime[1] == "00")
                            { EndMin.Text = "0"; }
                            else
                            { EndMin.Text = EndTime[1]; }
                            
                        }

                        
                    }

                }
                else
                {
                    MessageBox.Show("Details Are Not Availble This is First Entry For This Teacher", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }

        }
        #endregion

        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 07Nov2015
         * Purpose:- Chaeck All Days
         * StartTime:-
         * EndTime:-
         */

        #region---------------------------------------------------------CheckAllDays()-----------------------------------------------------------
        private void CheckAllDays()
        {
            chkMon.IsChecked = true;
            chkTue.IsChecked = true;
            chkWed.IsChecked = true;
            chkThru.IsChecked = true;
            chkFri.IsChecked = true;
            chkSat.IsChecked = true;
            chkSun.IsChecked = true;
            daycheckcount = 7;
        }
        #endregion

        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 07Nov2015
         * Purpose:- Un Check All Days
         * StartTime:-
         * EndTime:-
         */

        #region-------------------------------------------------------UncheckAllDays()------------------------------------------------------------
        private void UnchekAllDays()
        {
            chkMon.IsChecked = false;
            chkTue.IsChecked = false;
            chkWed.IsChecked = false;
            chkThru.IsChecked = false;
            chkFri.IsChecked = false;
            chkSat.IsChecked = false;
            chkSun.IsChecked = false;
            daycheckcount = 0;
        }
        #endregion

    }
}
