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

namespace SchoolManagement.Batch
{
    /// <summary>
    /// Interaction logic for BatchAvailibility.xaml
    /// </summary>
    public partial class BatchAvailibility : Window
    {
        #region-----------------------------------------Main()-------------------------------------------------------------------------
        public BatchAvailibility()
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

        #region---------------------------------Declare variables Globally-------------------------------------
        BLBatch objTeacher = new BLBatch();
        int daycheckcount = 0, cnn, n = 0;
        string tmpStartTime, tmpEndTime;
        string[] StartTime;
        string[] EndTime;
        string[] s;

        int BatchID,BranchID, UpdatedByUserID, Active, IsDeleted;
        string Day, FinalStartTime, FinalEndTime, UpdatedDate;
        #endregion

        #region-----------btnGo-------------------------------
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cmbBatch.SelectedValue.ToString() == "0")
                {
                    MessageBox.Show("Please Select Batch.");
                }
                else
                {
                    cmbBatch.IsEnabled = false;
                    Clears();
                    GetBatchAvailableDetails(Convert.ToInt32(cmbBatch.SelectedValue));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion

        #region---------------------------------------------------BindHours------------------------------------------------
        private void BindHours()
        {
            chkStartHrs.Items.Clear();
            chkStartHrs1.Items.Clear();
            chkStartHrs2.Items.Clear();
            chkStartHrs3.Items.Clear();
            chkStartHrs4.Items.Clear();
            chkStartHrs5.Items.Clear();
            chkStartHrs6.Items.Clear();
            chkStartHrs7.Items.Clear();

            chkEndhrs.Items.Clear();
            chkEndhrs1.Items.Clear();
            chkEndhrs2.Items.Clear();
            chkEndhrs3.Items.Clear();
            chkEndhrs4.Items.Clear();
            chkEndhrs5.Items.Clear();
            chkEndhrs6.Items.Clear();
            chkEndhrs7.Items.Clear();

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
                if (i < 10)
                {
                    chkStartHrs.Items.Add(n + i.ToString());
                    chkStartHrs1.Items.Add(n + i.ToString());
                    chkStartHrs2.Items.Add(n + i.ToString());
                    chkStartHrs3.Items.Add(n + i.ToString());
                    chkStartHrs4.Items.Add(n + i.ToString());
                    chkStartHrs5.Items.Add(n + i.ToString());
                    chkStartHrs6.Items.Add(n + i.ToString());
                    chkStartHrs7.Items.Add(n + i.ToString());

                    chkEndhrs.Items.Add(n + i.ToString());
                    chkEndhrs1.Items.Add(n + i.ToString());
                    chkEndhrs2.Items.Add(n + i.ToString());
                    chkEndhrs3.Items.Add(n + i.ToString());
                    chkEndhrs4.Items.Add(n + i.ToString());
                    chkEndhrs5.Items.Add(n + i.ToString());
                    chkEndhrs6.Items.Add(n + i.ToString());
                    chkEndhrs7.Items.Add(n + i.ToString());
                }
                else
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

        #region---------------------------------------------------BindMinutes------------------------------------------------
        private void BindMinutes()
        {

            chkStartMin.Items.Clear();
            chkStartMin1.Items.Clear();
            chkStartMin2.Items.Clear();
            chkStartMin3.Items.Clear();
            chkStartMin4.Items.Clear();
            chkStartMin5.Items.Clear();
            chkStartMin6.Items.Clear();
            chkStartMin7.Items.Clear();

            EndMin.Items.Clear();
            EndMin1.Items.Clear();
            EndMin2.Items.Clear();
            EndMin3.Items.Clear();
            EndMin4.Items.Clear();
            EndMin5.Items.Clear();
            EndMin6.Items.Clear();
            EndMin7.Items.Clear();

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
            for (i = 0; i <= 59; i = i + 5)
            {
                if (i < 10)
                {
                    chkStartMin.Items.Add(n + i.ToString());
                    chkStartMin1.Items.Add(n + i.ToString());
                    chkStartMin2.Items.Add(n + i.ToString());
                    chkStartMin3.Items.Add(n + i.ToString());
                    chkStartMin4.Items.Add(n + i.ToString());
                    chkStartMin5.Items.Add(n + i.ToString());
                    chkStartMin6.Items.Add(n + i.ToString());
                    chkStartMin7.Items.Add(n + i.ToString());

                    EndMin.Items.Add(n + i.ToString());
                    EndMin1.Items.Add(n + i.ToString());
                    EndMin2.Items.Add(n + i.ToString());
                    EndMin3.Items.Add(n + i.ToString());
                    EndMin4.Items.Add(n + i.ToString());
                    EndMin5.Items.Add(n + i.ToString());
                    EndMin6.Items.Add(n + i.ToString());
                    EndMin7.Items.Add(n + i.ToString());
                }
                else
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

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSave_Copy_Click(object sender, RoutedEventArgs e)
        {

        }
        #region----------------------
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

        #region-------------------------------------------chkAvailableSameTime()---------------------------------------------------------
        private void chkAvailSameTime_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (chkAvailSameTime.IsChecked == true)
                {
                    DisableDropdown();
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

        #region--------------------------chkMon_Click------------------------------------------------
        private void chkMon_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (chkMon.IsChecked == true)
                {
                    ++daycheckcount;
                }
                else if (chkMon.IsChecked == false)
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

        #region---------------------chkTue_Click-----------------------------
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

        #region---------------------chkWed_Click------------------
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

        private void chkThru_Click(object sender, RoutedEventArgs e)
        {

        }

        private void chkFri_Click(object sender, RoutedEventArgs e)
        {

        }

        private void chkSat_Click(object sender, RoutedEventArgs e)
        {

        }

        private void chkSun_Click(object sender, RoutedEventArgs e)
        {

        }

        private void chkStartHrs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void chkStartMin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void chkEndhrs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void EndMin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        #region---------------------------------------------------------Clears()-------------------------------------------------------
        private void Clears()
        {

            //BindHours();
            //BindMinutes();
            //BindGrid();
            //UncheckAllCheckBoxes();
            //gbSameTime.Visibility = Visibility.Hidden;
            //EnableDropdown();

        }
        #endregion

          #region---------------------------------------------------------GetTeacherAvailableDetails()-------------------------------------------
        private void GetBatchAvailableDetails(int numId)
        {
        }
          #endregion

        #region-----------------------------------------------ClearFields()-----------------------------------------------------------
        private void ClearFields()
        {
            //cmbTeacher.IsEnabled = true;
            BindBatchName();
            //BindBatch();
            //BindHours();
            //BindMinutes();
            //BindGrid();
            //UncheckAllCheckBoxes();
            //EnableDropdown();
        }
        #region-----------bindBatch()-----------------
        private void BindBatch()
        {
            BranchID =Convert.ToInt32(cmbBranch.SelectedValue.ToString());
            DataSet ds = objTeacher.BindBranchBatch(BranchID);

            if (ds.Tables[0].Rows.Count > 0)
            {
                cmbBatch.DataContext = null;

                cmbBatch.DataContext = ds.Tables[0].DefaultView;
                cmbBatch.DisplayMemberPath = ds.Tables[0].Columns["BatchName"].ToString();
                cmbBatch.SelectedValuePath = ds.Tables[0].Columns["BatchID"].ToString();


                cmbBatch.SelectedValue = "0";
            }
        }
        #region
        #region------------------BindBatchName()----------------------------
        private void BindBatchName()
        {
            DataSet ds = objTeacher.BindBatchDropDown();

            if (ds.Tables[0].Rows.Count > 0)
            {
                cmbBranch.DataContext = null;

                cmbBranch.DataContext = ds.Tables[0].DefaultView;
                cmbBranch.DisplayMemberPath = ds.Tables[0].Columns["BatchName"].ToString();
                cmbBranch.SelectedValuePath = ds.Tables[0].Columns["BatchID"].ToString();


                cmbBranch.SelectedValue = "0";
            }
        }
        #endregion
        #endregion
        #endregion

        #region----------------------------------------------------------------DisebleDropdown()-----------------------------------------------
        private void DisableDropdown()
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

        #region----------------------------------------------------------------EnableDropdown()------------------------------------------------
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

        private void cmbBranch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BindBatch();
        }
    }
}
        #endregion