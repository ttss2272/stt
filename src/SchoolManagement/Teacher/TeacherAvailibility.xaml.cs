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
         * Purpose:-
         * StartTime:-
         * EndTime:-
         */
        #region---------------------------------Declare variables Globally-------------------------------------
        BLTeacher objTeacher = new BLTeacher();
        int daycheckcount=0;

        #endregion

        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 07Nov2015
         * Purpose:-
         * StartTime:-
         * EndTime:-
         */
        #region---------------------------------Main()-------------------------------------
        public TeacherAvailibility()
        {
            InitializeComponent();
            ClearFields();
        }
        #endregion


        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 07Nov2015
         * Purpose:-
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
         * Purpose:-
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
         * Purpose:-
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
         * Purpose:-
         * StartTime:-
         * EndTime:-
         */
        #region---------------------------------Button Save click()-------------------------------------
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {

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
         * Purpose:-
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
            }

        }
        #endregion

        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 07Nov2015
         * Purpose:-
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
         * Purpose:-
         * StartTime:-
         * EndTime:-
         */
        #region----------------------------------------------------------------CheckBoxes--------------------------------------------
        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 07Nov2015
         * Purpose:-
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
         * Purpose:-
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
         * Purpose:-
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
         * Purpose:-
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
         * Purpose:-
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
         * Purpose:-
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
         * Purpose:-
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
         * Purpose:-
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
         * Purpose:-
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
         * Purpose:-
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
         * Purpose:-
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
         * Purpose:-
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
                        //s=ds.Tables[0]
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
         * Purpose:-
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
         * Purpose:-
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
