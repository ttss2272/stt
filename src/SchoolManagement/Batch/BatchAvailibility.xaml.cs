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

        int BatchID, UpdatedByUserID, Active, IsDeleted;
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

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSave_Copy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void chkAvailAllDay_Click(object sender, RoutedEventArgs e)
        {

        }
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

        private void chkMon_Click(object sender, RoutedEventArgs e)
        {

        }

        private void chkTue_Click(object sender, RoutedEventArgs e)
        {

        }

        private void chkWed_Click(object sender, RoutedEventArgs e)
        {

        }

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
            //BindTeacher();
            //BindHours();
            //BindMinutes();
            //BindGrid();
            //UncheckAllCheckBoxes();
            //EnableDropdown();
        }
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
    }
}
