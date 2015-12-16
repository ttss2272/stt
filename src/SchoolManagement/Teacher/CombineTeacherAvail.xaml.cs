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
using BusinessLayer;
using System.Data;

namespace SchoolManagement.Teacher
{
    /// <summary>
    /// Interaction logic for CombineTeacherAvail.xaml
    /// </summary>
    public partial class CombineTeacherAvail : Window
    {
        #region------------------------Main()-------------------------------------
        public CombineTeacherAvail()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
            this.Width = System.Windows.SystemParameters.PrimaryScreenWidth;
            this.Height = System.Windows.SystemParameters.PrimaryScreenHeight;
            ClearFields();
        }
        #endregion

        #region---------------------------------Declare variables Globally-------------------------------------
        int TeacherID, Result1, UPID, MaxNoOfMovesInBranch, MaxLecturePerDay, MaxLectPerWeek, MaxNoOfLectInRow, Active, IsDeleted, IsMoreThanOneLecture, IsFirstLecture, IsLastLecture, UpdatedByUserID;
        string TeacherName, TeacherSurname, TeacherShortName, StartFreeTimeHrs, StartFreeTimeMin, EndFreeTimeHrs, EndFreeTimeMin, FreeTimeStart, FreeTimeEnd, UpdatedDate, n = "0";
        BLTeacher objTeacher = new BLTeacher();

        //Teacher Availability

        int daycheckcount = 0, cnn;
        string tmpStartTime, tmpEndTime;
        string[] StartTime;
        string[] EndTime;
        string[] s;

        int Glob ,MaxTeacherID;
        string Day, FinalStartTime, FinalEndTime;
        #endregion
        /*
         * CreatedBy:-Sameer Shinde
         * Created Date:- 12 Dec 2012
         * Purpose:-
         * StartTime:-
         * EndTime:-
         */
        /*
         * CreatedBy:-Sameer Shinde
         * Created Date:- 12 Dec 2015
         * Purpose:-
         * StartTime:-
         * EndTime:-
         */
        #region------------------------------------btnSaveClick()-----------------------------------------------------
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Validate())
                {
                    SetParameters();
                   // SaveDetails();
                     Result1 = objTeacher.SaveTeacher(TeacherID, TeacherName, TeacherSurname, TeacherShortName, MaxNoOfMovesInBranch, MaxLecturePerDay, MaxLectPerWeek, IsMoreThanOneLecture, MaxNoOfLectInRow, IsFirstLecture, IsLastLecture, FreeTimeStart, FreeTimeEnd, UpdatedByUserID, UpdatedDate, Active, IsDeleted);
                     if (Result1 == 0)
                     {
                         MessageBox.Show("Teacher Short Name Duplicate", "Error to Save Teacher", MessageBoxButton.OK, MessageBoxImage.Warning);
                     }
                     else
                     {
                         SetParametersForAvailability();
                     }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString(), "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion
        /*
        * CreatedBy:-Sameer Shinde
        * Created Date:- 12dec2015
        * Purpose:- Set Parameters and Save details
        * StartTime:-
        * EndTime:-
        */
        #region-------------------------------------------------------SetParametersForAvailability()-------------------------------------------------------
        private void SetParametersForAvailability()
        {
            int ResultCount = 0;

            if (chkMon.IsChecked == true)
            {
                TeacherID = Result1;
                Day = chkMon.Content.ToString();
                FinalStartTime = chkStartHrs1.Text + ":";
                FinalStartTime += chkStartMin1.Text;
                FinalEndTime = chkEndhrs1.Text + ":";
                FinalEndTime += EndMin1.Text;
                Active = 1;
                IsDeleted = 0;
                UpdatedDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
                UpdatedByUserID = 1;
                string Result = objTeacher.SaveTeacherAvailibility(TeacherID, Day, FinalStartTime, FinalEndTime, UpdatedByUserID, UpdatedDate, Active, IsDeleted);
                if ((Result == "Save Sucessfully...!!!") || (Result == "Updated Sucessfully...!!!"))
                {
                    ResultCount++;
                }
            }
            else if (chkMon.IsChecked == false)
            {
                TeacherID = Result1;
                Day = chkMon.Content.ToString();
                FinalStartTime = "00:00:00";
                FinalEndTime = "00:00:00";
                Active = 0;
                IsDeleted = 0;
                UpdatedDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
                UpdatedByUserID = 1;
                string Result = objTeacher.SaveTeacherAvailibility(TeacherID, Day, FinalStartTime, FinalEndTime, UpdatedByUserID, UpdatedDate, Active, IsDeleted);
                if ((Result == "Save Sucessfully...!!!") || (Result == "Updated Sucessfully...!!!"))
                {
                    ResultCount++;
                }

            }
            if (chkTue.IsChecked == true)
            {
                TeacherID = Result1;
                Day = chkTue.Content.ToString();
                FinalStartTime = chkStartHrs2.Text + ":";
                FinalStartTime += chkStartMin2.Text;
                FinalEndTime = chkEndhrs2.Text + ":";
                FinalEndTime += EndMin2.Text;
                Active = 1;
                IsDeleted = 0;
                UpdatedDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
                UpdatedByUserID = 1;
                string Result = objTeacher.SaveTeacherAvailibility(TeacherID, Day, FinalStartTime, FinalEndTime, UpdatedByUserID, UpdatedDate, Active, IsDeleted);
                if ((Result == "Save Sucessfully...!!!") || (Result == "Updated Sucessfully...!!!"))
                {
                    ResultCount++;
                }
            }
            else if (chkTue.IsChecked == false)
            {
                TeacherID = Result1;
                Day = chkTue.Content.ToString();
                FinalStartTime = "00:00:00";
                FinalEndTime = "00:00:00";
                Active = 0;
                IsDeleted = 0;
                UpdatedDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
                UpdatedByUserID = 1;
                string Result = objTeacher.SaveTeacherAvailibility(TeacherID, Day, FinalStartTime, FinalEndTime, UpdatedByUserID, UpdatedDate, Active, IsDeleted);
                if ((Result == "Save Sucessfully...!!!") || (Result == "Updated Sucessfully...!!!"))
                {
                    ResultCount++;
                }

            }
            if (chkWed.IsChecked == true)
            {
                TeacherID = Result1;
                Day = chkWed.Content.ToString();
                FinalStartTime = chkStartHrs3.Text + ":";
                FinalStartTime += chkStartMin3.Text;
                FinalEndTime = chkEndhrs3.Text + ":";
                FinalEndTime += EndMin3.Text;
                Active = 1;
                IsDeleted = 0;
                UpdatedDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
                UpdatedByUserID = 1;
                string Result = objTeacher.SaveTeacherAvailibility(TeacherID, Day, FinalStartTime, FinalEndTime, UpdatedByUserID, UpdatedDate, Active, IsDeleted);

                if ((Result == "Save Sucessfully...!!!") || (Result == "Updated Sucessfully...!!!"))
                {
                    ResultCount++;
                }
            }
            else if (chkWed.IsChecked == false)
            {
                TeacherID = Result1;
                Day = chkWed.Content.ToString();
                FinalStartTime = "00:00:00";
                FinalEndTime = "00:00:00";
                Active = 0;
                IsDeleted = 0;
                UpdatedDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
                UpdatedByUserID = 1;
                string Result = objTeacher.SaveTeacherAvailibility(TeacherID, Day, FinalStartTime, FinalEndTime, UpdatedByUserID, UpdatedDate, Active, IsDeleted);

                if ((Result == "Save Sucessfully...!!!") || (Result == "Updated Sucessfully...!!!"))
                {
                    ResultCount++;
                }

            }
            if (chkThru.IsChecked == true)
            {
                TeacherID = Result1;
                Day = chkThru.Content.ToString();
                FinalStartTime = chkStartHrs4.Text + ":";
                FinalStartTime += chkStartMin4.Text;
                FinalEndTime = chkEndhrs4.Text + ":";
                FinalEndTime += EndMin4.Text;
                Active = 1;
                IsDeleted = 0;
                UpdatedDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
                UpdatedByUserID = 1;
                string Result = objTeacher.SaveTeacherAvailibility(TeacherID, Day, FinalStartTime, FinalEndTime, UpdatedByUserID, UpdatedDate, Active, IsDeleted);

                if ((Result == "Save Sucessfully...!!!") || (Result == "Updated Sucessfully...!!!"))
                {
                    ResultCount++;
                }
            }
            else if (chkThru.IsChecked == false)
            {
                TeacherID = Result1;
                Day = chkThru.Content.ToString();
                FinalStartTime = "00:00:00";
                FinalEndTime = "00:00:00";
                Active = 0;
                IsDeleted = 0;
                UpdatedDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
                UpdatedByUserID = 1;
                string Result = objTeacher.SaveTeacherAvailibility(TeacherID, Day, FinalStartTime, FinalEndTime, UpdatedByUserID, UpdatedDate, Active, IsDeleted);

                if ((Result == "Save Sucessfully...!!!") || (Result == "Updated Sucessfully...!!!"))
                {
                    ResultCount++;
                }

            }
            if (chkFri.IsChecked == true)
            {
                TeacherID = Result1;
                Day = chkFri.Content.ToString();
                FinalStartTime = chkStartHrs5.Text + ":";
                FinalStartTime += chkStartMin5.Text;
                FinalEndTime = chkEndhrs5.Text + ":";
                FinalEndTime += EndMin5.Text;
                Active = 1;
                IsDeleted = 0;
                UpdatedDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
                UpdatedByUserID = 1;
                string Result = objTeacher.SaveTeacherAvailibility(TeacherID, Day, FinalStartTime, FinalEndTime, UpdatedByUserID, UpdatedDate, Active, IsDeleted);

                if ((Result == "Save Sucessfully...!!!") || (Result == "Updated Sucessfully...!!!"))
                {
                    ResultCount++;
                }
            }
            else if (chkFri.IsChecked == false)
            {
                TeacherID = Result1;
                Day = chkFri.Content.ToString();
                FinalStartTime = "00:00:00";
                FinalEndTime = "00:00:00";
                Active = 0;
                IsDeleted = 0;
                UpdatedDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
                UpdatedByUserID = 1;
                string Result = objTeacher.SaveTeacherAvailibility(TeacherID, Day, FinalStartTime, FinalEndTime, UpdatedByUserID, UpdatedDate, Active, IsDeleted);

                if ((Result == "Save Sucessfully...!!!") || (Result == "Updated Sucessfully...!!!"))
                {
                    ResultCount++;
                }

            }
            if (chkSat.IsChecked == true)
            {
                TeacherID = Result1;
                Day = chkSat.Content.ToString();
                FinalStartTime = chkStartHrs6.Text + ":";
                FinalStartTime += chkStartMin6.Text;
                FinalEndTime = chkEndhrs6.Text + ":";
                FinalEndTime += EndMin6.Text;
                Active = 1;
                IsDeleted = 0;
                UpdatedDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
                UpdatedByUserID = 1;
                string Result = objTeacher.SaveTeacherAvailibility(TeacherID, Day, FinalStartTime, FinalEndTime, UpdatedByUserID, UpdatedDate, Active, IsDeleted);

                if ((Result == "Save Sucessfully...!!!") || (Result == "Updated Sucessfully...!!!"))
                {
                    ResultCount++;
                }
            }
            else if (chkSat.IsChecked == false)
            {
                TeacherID = Result1;
                Day = chkSat.Content.ToString();
                FinalStartTime = "00:00:00";
                FinalEndTime = "00:00:00";
                Active = 0;
                IsDeleted = 0;
                UpdatedDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
                UpdatedByUserID = 1;
                string Result = objTeacher.SaveTeacherAvailibility(TeacherID, Day, FinalStartTime, FinalEndTime, UpdatedByUserID, UpdatedDate, Active, IsDeleted);

                if ((Result == "Save Sucessfully...!!!") || (Result == "Updated Sucessfully...!!!"))
                {
                    ResultCount++;
                }

            }
            if (chkSun.IsChecked == true)
            {
                TeacherID = Result1;
                Day = chkSun.Content.ToString();
                FinalStartTime = chkStartHrs7.Text + ":";
                FinalStartTime += chkStartMin7.Text;
                FinalEndTime = chkEndhrs7.Text + ":";
                FinalEndTime += EndMin7.Text;
                Active = 1;
                IsDeleted = 0;
                UpdatedDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
                UpdatedByUserID = 1;
                string Result = objTeacher.SaveTeacherAvailibility(TeacherID, Day, FinalStartTime, FinalEndTime, UpdatedByUserID, UpdatedDate, Active, IsDeleted);

                if ((Result == "Save Sucessfully...!!!") || (Result == "Updated Sucessfully...!!!"))
                {
                    ResultCount++;
                }
            }
            else if (chkSun.IsChecked == false)
            {
                TeacherID = Result1;
                Day = chkSun.Content.ToString();
                FinalStartTime = "00:00:00";
                FinalEndTime = "00:00:00";
                Active = 0;
                IsDeleted = 0;
                UpdatedDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
                UpdatedByUserID = 1;
                string Result = objTeacher.SaveTeacherAvailibility(TeacherID, Day, FinalStartTime, FinalEndTime, UpdatedByUserID, UpdatedDate, Active, IsDeleted);
                if ((Result == "Save Sucessfully...!!!") || (Result == "Updated Sucessfully...!!!"))
                {
                    ResultCount++;
                }
            }
            if (ResultCount == 7)
            {
                if (btnSave.Content.ToString() == "Save")
                {
                    MessageBox.Show("Teacher Details Save Sucessfully", "Save Sucessfull", MessageBoxButton.OK, MessageBoxImage.Information);
                    ClearFields();
                }
                else if (btnSave.Content.ToString() == "Update")
                {
                    MessageBox.Show("Teacher Details Updated Sucessfully", "Save Sucessfull", MessageBoxButton.OK, MessageBoxImage.Information);
                    ClearFields();
                }
            }

        }
        #endregion


        /*
         * CreatedBy:-Sameer Shinde
         * Created Date:- 12 Dec 2015
         * Purpose:-
         * StartTime:-
         * EndTime:-
         */
        #region-------------------------------------btnDeleteClick()--------------------------------------------------------------
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult Result = MessageBox.Show("Do You Really Want To Delete?", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (Result.Equals(MessageBoxResult.Yes))
                {
                    SetParameters();
                    DeleteTeacher();
                    BindGrid();
                    BindGridTeachAvail();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion
        /*
         * CreatedBy:-Sameer Shinde
         * Created Date:- 12 Dec 2015
         * Purpose:-
         * StartTime:-
         * EndTime:-
         */
        #region--------------------------------------btnClearClick()--------------------------------------------------------------
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
        #endregion
        /*
         * CreatedBy:-Sameer Shinde
         * Created Date:- 12 Dec 2015
         * Purpose:-
         * StartTime:-
         * EndTime:-
         */
        #region-------------------------------------------ClearFields()-----------------------------------------------------------
        private void ClearFields()
        {
            txtName.Text = "";
            txtSurname.Text = "";
            txtShortName.Text = "";
            TimingHrs();
            TimingMin();
            MaxNoOfMovesInBranches();
            MaxLectPerDay();
            MaxLectPerWeek1();
            BindYesNo();
            MaxLectInRow();
            UPID = 0;
            BindGrid();
            rdbActive.IsChecked = true;
            rdbInActive.IsChecked = false;
            btnDelete.IsEnabled = false;
            btnSave.Content = "Save";

            //Teacher Availability ClearFields
                      
            BindHours();
            BindMinutes();
            BindGridTeachAvail();
            UncheckAllCheckBoxes();
            EnableDropdown();
           // gbTeacherAvalDay.IsEnabled = false;
        }
        #endregion

        /*
         * CreatedBy:-Sameer Shinde
         * Created Date:- 12dec2015
         * Purpose:-Clear Fields
         * StartTime:-
         * EndTime:-
         */
        #region---------------------------------------------------------Clears()-------------------------------------------------------
        private void Clears()
        {

            BindHours();
            BindMinutes();
            BindGridTeachAvail();
            UncheckAllCheckBoxes();
            gbSameTime.Visibility = Visibility.Hidden;
            EnableDropdown();

        }
        #endregion

        /*
         * CreatedBy:-Sameer Shinde
         * Created Date:- 12dec2015
         * Purpose:-Click on Available for Same Time
         * StartTime:-
         * EndTime:-
         */
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

        /*
         * CreatedBy:-Sameer Shinde
         * Created Date:- 12dec2015
         * Purpose:-Disable Dropdown
         * StartTime:-
         * EndTime:-
         */
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

        #region----------------------------------------------------------------CheckBoxes()---------------------------------------------------
        /*
         * CreatedBy:-Sameer Shinde
         * Created Date:- 12dec2015
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
         * CreatedBy:-Sameer Shinde
         * Created Date:- 12dec2015
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
         * CreatedBy:-Sameer Shinde
         * Created Date:- 12dec2015
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


        /*
         * CreatedBy:-Sameer Shinde
         * Created Date:- 12dec2015
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
                else if (chkMon.IsChecked == false)
                {
                    --daycheckcount;
                    chkStartHrs1.SelectedIndex = 0;
                    chkStartMin1.SelectedIndex = 0;
                    chkEndhrs1.SelectedIndex = 0;
                    EndMin1.SelectedIndex = 0;
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
         * CreatedBy:-Sameer Shinde
         * Created Date:- 12dec2015
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
                    chkStartHrs2.SelectedIndex = 0;
                    chkStartMin2.SelectedIndex = 0;
                    chkEndhrs2.SelectedIndex = 0;
                    EndMin2.SelectedIndex = 0;
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
         * CreatedBy:-Sameer Shinde
         * Created Date:- 12dec2015
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
                    chkStartHrs3.SelectedIndex = 0;
                    chkStartMin3.SelectedIndex = 0;
                    chkEndhrs3.SelectedIndex = 0;
                    EndMin3.SelectedIndex = 0;
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
         * CreatedBy:-Sameer Shinde
         * Created Date:- 12dec2015
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
                    chkStartHrs4.SelectedIndex = 0;
                    chkStartMin4.SelectedIndex = 0;
                    chkEndhrs4.SelectedIndex = 0;
                    EndMin4.SelectedIndex = 0;
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
         * CreatedBy:-Sameer Shinde
         * Created Date:- 12dec2015
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
                    chkStartHrs5.SelectedIndex = 0;
                    chkStartMin5.SelectedIndex = 0;
                    chkEndhrs5.SelectedIndex = 0;
                    EndMin5.SelectedIndex = 0;
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
         * CreatedBy:-Sameer Shinde
         * Created Date:- 12dec2015
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
                    chkStartHrs6.SelectedIndex = 0;
                    chkStartMin6.SelectedIndex = 0;
                    chkEndhrs6.SelectedIndex = 0;
                    EndMin6.SelectedIndex = 0;
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
         * CreatedBy:-Sameer Shinde
         * Created Date:- 12dec2015
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
                    chkStartHrs7.SelectedIndex = 0;
                    chkStartMin7.SelectedIndex = 0;
                    chkEndhrs7.SelectedIndex = 0;
                    EndMin7.SelectedIndex = 0;
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

        #region---------------------------------------------------BindTiming------------------------------------------------------------------
        /*
         * CreatedBy:-Sameer Shinde
         * Created Date:- 12 dec 2015
         * Purpose:-
         * StartTime:-
         * EndTime:-
         */
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

        /*
         * CreatedBy:-Sameer Shinde
         * Created Date:- 12 Dec 2015
         * Purpose:-
         * StartTime:-
         * EndTime:-
         */
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
        #endregion

        /*
         * CreatedBy:-Sameer Shinde
         * Created Date:- 12dec2015
         * Purpose:-Bind data grid Teacher availability
         * StartTime:-
         * EndTime:-
         */
        #region---------------------------------------------------------------BindGridTeachAvail()-------------------------------------------------------
        private void BindGridTeachAvail()
        {
            DataSet ds = objTeacher.BindTeacherAvail();

            if (ds.Tables[0].Rows.Count > 0)
            {
                dgTeacherAvail.DataContext = null;
                dgTeacherAvail.DataContext = ds.Tables[0].DefaultView;
            }

        }
        #endregion
        /*
         * CreatedBy:-Sameer Shinde
         * Created Date:- 12dec2015
         * Purpose:- Uncheck all check Boxes
         * StartTime:-
         * EndTime:-
         */
        #region--------------------------------unchekcall ChekcBoxes-----------------------------------
        private void UncheckAllCheckBoxes()
        {
            chkAvailAllDay.IsChecked = false;
            chkAvailSameTime.IsChecked = false;

            chkMon.IsChecked = false;
            chkTue.IsChecked = false;
            chkWed.IsChecked = false;
            chkThru.IsChecked = false;
            chkFri.IsChecked = false;
            chkSat.IsChecked = false;
            chkSun.IsChecked = false;
        }
        #endregion
        /*
         * CreatedBy:-Sameer Shinde
         * Created Date:- 12dec2015
         * Purpose:- Enable Drop Down
         * StartTime:-
         * EndTime:-
         */
       

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

        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 07Nov2015
         * Purpose:- Get Teacher Available Details
         * StartTime:-
         * EndTime:-
         */
        #region---------------------------------------------------------GetTeacherAvailableDetails()-------------------------------------------
        private void GetTeacherAvailableDetails(int numId)
        {
            cnn = 0;
            DataSet ds = objTeacher.GetTeacherAvailableDetail(numId);
            if (ds.Tables[0].Rows.Count > 0)
            {
                int cnt = ds.Tables[0].Rows.Count;
                string s;
                if (cnt == 7)
                {
                    chkAvailAllDay.IsChecked = true;
                    CheckAllDays();
                    gbSameTime.Visibility = Visibility.Visible;
                }
                for (int i = 0; i < cnt; i++)
                {
                    s = ds.Tables[0].Rows[i]["Day"].ToString();

                    if ((ds.Tables[0].Rows[0]["StartTime"].ToString() == ds.Tables[0].Rows[i]["StartTime"].ToString()) && (ds.Tables[0].Rows[0]["EndTime"].ToString() == ds.Tables[0].Rows[i]["EndTime"].ToString()))
                    {
                        cnn++;

                    }
                    switch (s)
                    {
                        case ("Mon"):
                            {
                                tmpStartTime = ds.Tables[0].Rows[i]["StartTime"].ToString();
                                string[] StartTime = tmpStartTime.Split(':');
                                chkStartHrs1.Text = StartTime[0];
                                //if (StartTime[1] == "00")
                                //{ chkStartMin1.Text = "0"; }
                                //else
                                { chkStartMin1.Text = StartTime[1]; }

                                tmpEndTime = ds.Tables[0].Rows[i]["EndTime"].ToString();
                                string[] EndTime = tmpEndTime.Split(':');
                                chkEndhrs1.Text = EndTime[0];
                                //if (EndTime[1] == "00")
                                //{ EndMin1.Text = "0"; }
                                //else
                                { EndMin1.Text = EndTime[1]; }
                                chkMon.IsChecked = true;
                                break;
                            }
                        case ("Tue"):
                            {
                                tmpStartTime = ds.Tables[0].Rows[i]["StartTime"].ToString();
                                string[] StartTime = tmpStartTime.Split(':');
                                chkStartHrs2.Text = StartTime[0];
                                //if (StartTime[1] == "00")
                                //{ chkStartMin2.Text = "0"; }
                                //else
                                { chkStartMin2.Text = StartTime[1]; }

                                tmpEndTime = ds.Tables[0].Rows[i]["EndTime"].ToString();
                                string[] EndTime = tmpEndTime.Split(':');
                                chkEndhrs2.Text = EndTime[0];
                                //if (EndTime[1] == "00")
                                //{ EndMin2.Text = "0"; }
                                //else
                                { EndMin2.Text = EndTime[1]; }
                                chkTue.IsChecked = true;
                                break;
                            }
                        case ("Wed"):
                            {
                                tmpStartTime = ds.Tables[0].Rows[i]["StartTime"].ToString();
                                string[] StartTime = tmpStartTime.Split(':');
                                chkStartHrs3.Text = StartTime[0];
                                //if (StartTime[1] == "00")
                                //{ chkStartMin3.Text = "0"; }
                                //else
                                { chkStartMin3.Text = StartTime[1]; }

                                tmpEndTime = ds.Tables[0].Rows[i]["EndTime"].ToString();
                                string[] EndTime = tmpEndTime.Split(':');
                                chkEndhrs3.Text = EndTime[0];
                                //if (EndTime[1] == "00")
                                //{ EndMin3.Text = "0"; }
                                //else
                                { EndMin3.Text = EndTime[1]; }
                                chkWed.IsChecked = true;
                                break;
                            }
                        case ("Thru"):
                            {
                                tmpStartTime = ds.Tables[0].Rows[i]["StartTime"].ToString();
                                string[] StartTime = tmpStartTime.Split(':');
                                chkStartHrs4.Text = StartTime[0];
                                //if (StartTime[1] == "00")
                                //{ chkStartMin4.Text = "0"; }
                                //else
                                { chkStartMin4.Text = StartTime[1]; }

                                tmpEndTime = ds.Tables[0].Rows[i]["EndTime"].ToString();
                                string[] EndTime = tmpEndTime.Split(':');
                                chkEndhrs4.Text = EndTime[0];
                                //if (EndTime[1] == "00")
                                //{ EndMin4.Text = "0"; }
                                //else
                                { EndMin4.Text = EndTime[1]; }
                                chkThru.IsChecked = true;
                                break;
                            }

                        case ("Fri"):
                            {
                                tmpStartTime = ds.Tables[0].Rows[i]["StartTime"].ToString();
                                string[] StartTime = tmpStartTime.Split(':');
                                chkStartHrs5.Text = StartTime[0];
                                //if (StartTime[1] == "00")
                                //{ chkStartMin5.Text = "0"; }
                                //else
                                { chkStartMin5.Text = StartTime[1]; }

                                tmpEndTime = ds.Tables[0].Rows[i]["EndTime"].ToString();
                                string[] EndTime = tmpEndTime.Split(':');
                                chkEndhrs5.Text = EndTime[0];
                                //if (EndTime[1] == "00")
                                //{ EndMin5.Text = "0"; }
                                //else
                                { EndMin5.Text = EndTime[1]; }
                                chkFri.IsChecked = true;
                                break;
                            }
                        case ("Sat"):
                            {
                                tmpStartTime = ds.Tables[0].Rows[i]["StartTime"].ToString();
                                string[] StartTime = tmpStartTime.Split(':');
                                chkStartHrs6.Text = StartTime[0];
                                //if (StartTime[1] == "00")
                                //{ chkStartMin6.Text = "0"; }
                                //else
                                { chkStartMin6.Text = StartTime[1]; }

                                tmpEndTime = ds.Tables[0].Rows[i]["EndTime"].ToString();
                                string[] EndTime = tmpEndTime.Split(':');
                                chkEndhrs6.Text = EndTime[0];
                                //if (EndTime[1] == "00")
                                //{ EndMin6.Text = "0"; }
                                //else
                                { EndMin6.Text = EndTime[1]; }
                                chkSat.IsChecked = true;
                                break;
                            }
                        case ("Sun"):
                            {
                                tmpStartTime = ds.Tables[0].Rows[i]["StartTime"].ToString();
                                string[] StartTime = tmpStartTime.Split(':');
                                chkStartHrs7.Text = StartTime[0];
                                //if (StartTime[1] == "00")
                                //{ chkStartMin7.Text = "0"; }
                                //else
                                { chkStartMin7.Text = StartTime[1]; }

                                tmpEndTime = ds.Tables[0].Rows[i]["EndTime"].ToString();
                                string[] EndTime = tmpEndTime.Split(':');
                                chkEndhrs7.Text = EndTime[0];
                                //if (EndTime[1] == "00")
                                //{ EndMin7.Text = "0"; }
                                //else
                                { EndMin7.Text = EndTime[1]; }
                                chkSun.IsChecked = true;
                                break;
                            }
                    }
                    daycheckcount = cnt;
                    if (cnn == 7)
                    {
                        chkAvailSameTime.IsChecked = true;

                        tmpStartTime = ds.Tables[0].Rows[0]["StartTime"].ToString();
                        string[] StartTime = tmpStartTime.Split(':');
                        chkStartHrs.Text = StartTime[0];
                        //if (StartTime[1] == "00")
                        //{ chkStartMin.Text = "0"; }
                        //else
                        { chkStartMin.Text = StartTime[1]; }

                        tmpEndTime = ds.Tables[0].Rows[0]["EndTime"].ToString();
                        string[] EndTime = tmpEndTime.Split(':');
                        chkEndhrs.Text = EndTime[0];
                        //if (EndTime[1] == "00")
                        //{ EndMin.Text = "0"; }
                        //else
                        { EndMin.Text = EndTime[1]; }

                        DisableDropdown();

                    }

                }

                //if (num == Convert.ToInt32(cmbTeacher.SelectedValue))
                //{
                //    btnSave.Content = "Update";
                //}
                //else
                //{
                //    btnSave.Content = "Save";
                //}

            }
            else
            {
                MessageBox.Show("Details Are Not Availble This is First Entry For This Teacher", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }


        }
        #endregion

        /*
         * CreatedBy:-Sameer Shinde
         * Created Date:- 12dec2015
         * Purpose:- Same Start hours
         * StartTime:-
         * EndTime:-
         */

        #region---------------------------------------------------chkStartHrs_SelectionChanged()--------------------------------------------------
        private void chkStartHrs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {


                if (chkAvailSameTime.IsChecked == true && chkStartHrs.SelectedItem != null)
                {
                    chkStartHrs1.Text = chkStartHrs.SelectedItem.ToString();
                    chkStartHrs2.Text = chkStartHrs.SelectedItem.ToString();
                    chkStartHrs3.Text = chkStartHrs.SelectedItem.ToString();
                    chkStartHrs4.Text = chkStartHrs.SelectedItem.ToString();
                    chkStartHrs5.Text = chkStartHrs.SelectedItem.ToString();
                    chkStartHrs6.Text = chkStartHrs.SelectedItem.ToString();
                    chkStartHrs7.Text = chkStartHrs.SelectedItem.ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }
        }
        #endregion

        /*
         * CreatedBy:-Sameer Shinde
         * Created Date:- 12dec2015
         * Purpose:- Same Start Min
         * StartTime:-
         * EndTime:-
         */
        #region-----------------------------------------------chkStartMin_SelectionChanged()------------------------------------------------------
        private void chkStartMin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                if (chkAvailSameTime.IsChecked == true && chkStartMin.SelectedItem != null)
                {
                    chkStartMin1.Text = chkStartMin.SelectedItem.ToString();
                    chkStartMin2.Text = chkStartMin.SelectedItem.ToString();
                    chkStartMin3.Text = chkStartMin.SelectedItem.ToString();
                    chkStartMin4.Text = chkStartMin.SelectedItem.ToString();
                    chkStartMin5.Text = chkStartMin.SelectedItem.ToString();
                    chkStartMin6.Text = chkStartMin.SelectedItem.ToString();
                    chkStartMin7.Text = chkStartMin.SelectedItem.ToString();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());

            }
        }
        #endregion


        /*
         * CreatedBy:-Sameer Shinde
         * Created Date:- 12dec015
         * Purpose:- Same End Hrs
         * StartTime:-
         * EndTime:-
         */
        #region-------------------------------------------------------------chkEndhrs_SelectionChanged-----------------------------------
        private void chkEndhrs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (chkAvailSameTime.IsChecked == true && chkEndhrs.SelectedItem != null)
                {
                    chkEndhrs1.Text = chkEndhrs.SelectedItem.ToString();
                    chkEndhrs2.Text = chkEndhrs.SelectedItem.ToString();
                    chkEndhrs3.Text = chkEndhrs.SelectedItem.ToString();
                    chkEndhrs4.Text = chkEndhrs.SelectedItem.ToString();
                    chkEndhrs5.Text = chkEndhrs.SelectedItem.ToString();
                    chkEndhrs6.Text = chkEndhrs.SelectedItem.ToString();
                    chkEndhrs7.Text = chkEndhrs.SelectedItem.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion

        /*
         * CreatedBy:-Sameer Shinde
         * Created Date:- 12dec2015
         * Purpose:- Same End Min
         * StartTime:-
         * EndTime:-
         */
        #region---------------------------------------------------------EndMin_SelectionChanged-------------------------------------------
        private void EndMin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (chkAvailSameTime.IsChecked == true && EndMin.SelectedItem != null)
                {
                    EndMin1.Text = EndMin.SelectedItem.ToString();
                    EndMin2.Text = EndMin.SelectedItem.ToString();
                    EndMin3.Text = EndMin.SelectedItem.ToString();
                    EndMin4.Text = EndMin.SelectedItem.ToString();
                    EndMin5.Text = EndMin.SelectedItem.ToString();
                    EndMin6.Text = EndMin.SelectedItem.ToString();
                    EndMin7.Text = EndMin.SelectedItem.ToString();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }
        }
        #endregion

        /*
         * CreatedBy:-Sameer Shinde
         * Created Date:- 12dec2015
         * Purpose:- Clear Button
         * StartTime:-
         * EndTime:-
         */
        #region-----------------------------------clear button click-------------------------------------------------------------
        private void btnSave_Copy_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion

       

        /*
         * CreatedBy:-Sameer Shinde
         * Created Date:- 12 Dec 2015
         * Purpose:-
         * StartTime:-
         * EndTime:-
         */
        #region-------------------------------------------BindTimingHrs---------------------------------
        private void TimingHrs()
        {
            cmbFreeTimeStartHrs.Items.Clear();
            cmbFreeTimeEndHrs.Items.Clear();

            cmbFreeTimeStartHrs.Items.Add("Select");
            cmbFreeTimeEndHrs.Items.Add("Select");
            int i;
            for (i = 1; i <= 24; i++)
            {
                if (i < 10)
                {
                    cmbFreeTimeStartHrs.Items.Add(n + i.ToString());
                    cmbFreeTimeEndHrs.Items.Add(n + i.ToString());
                }
                else
                {
                    cmbFreeTimeStartHrs.Items.Add(i.ToString());
                    cmbFreeTimeEndHrs.Items.Add(i.ToString());
                }

            }

            cmbFreeTimeStartHrs.SelectedIndex = 0;
            cmbFreeTimeEndHrs.SelectedIndex = 0;

        }
        #endregion


        /*
         * CreatedBy:-Sameer Shinde
         * Created Date:- 12 Dec 2015
         * Purpose:-
         * StartTime:-
         * EndTime:-
         */
        #region-------------------------------------------BindTimingMins---------------------------------
        private void TimingMin()
        {
            cmbFreeTimeStartMin.Items.Add("Select");
            cmbFreeTimeEndMin.Items.Add("Select");
            int i;
            for (i = 0; i <= 59; i = i + 5)
            {
                if (i < 10)
                {
                    cmbFreeTimeStartMin.Items.Add(n + i.ToString());
                    cmbFreeTimeEndMin.Items.Add(n + i.ToString());
                }
                else
                {
                    cmbFreeTimeStartMin.Items.Add(i);
                    cmbFreeTimeEndMin.Items.Add(i);
                }

            }
            cmbFreeTimeStartMin.SelectedIndex = 0;
            cmbFreeTimeEndMin.SelectedIndex = 0;

        }
        #endregion

        /*
         * CreatedBy:-Sameer Shinde
         * Created Date:- 12 Dec 2015
         * Purpose:-
         * StartTime:-
         * EndTime:-
         */
        #region-------------------------------------------MaxNoOfMovesInBranch---------------------------------
        private void MaxNoOfMovesInBranches()
        {
            cmbMaxMoves.Items.Clear();
            cmbMaxMoves.Items.Add("Select");
            int i;
            for (i = 0; i <= 4; i++)
            {
                cmbMaxMoves.Items.Add(i);
            }
            cmbMaxMoves.SelectedIndex = 0;
        }
        #endregion

        /*
         * CreatedBy:-Sameer Shinde
         * Created Date:- 12 Dec 2015
         * Purpose:-
         * StartTime:-
         * EndTime:-
         */
        #region-------------------------------------------MaxLectPerDay---------------------------------
        private void MaxLectPerDay()
        {
            cmbMaxLectPerDay.Items.Clear();
            cmbMaxLectPerDay.Items.Add("Select");
            int i;
            for (i = 1; i <= 6; i++)
            {
                cmbMaxLectPerDay.Items.Add(i);
            }
            cmbMaxLectPerDay.SelectedIndex = 0;
        }
        #endregion

        /*
         * CreatedBy:-Sameer Shinde
         * Created Date:- 12 Dec 2015
         * Purpose:-
         * StartTime:-
         * EndTime:-
         */
        #region-------------------------------------------MaxLectInRow---------------------------------
        private void MaxLectInRow()
        {
            cmbMaxNoLectInRow.Items.Clear();
            cmbMaxNoLectInRow.Items.Add("Select");
            int i;
            for (i = 1; i <= 6; i++)
            {
                cmbMaxNoLectInRow.Items.Add(i);
            }
            cmbMaxNoLectInRow.SelectedIndex = 0;
        }
        #endregion

        /*
         * CreatedBy:-Sameer Shinde
         * Created Date:- 12 Dec 2015
         * Purpose:-
         * StartTime:-
         * EndTime:-
         */
        #region-------------------------------------------MaxLectPerWeek---------------------------------
        private void MaxLectPerWeek1()
        {
            cmbMaxLectPerWeek.Items.Clear();
            cmbMaxLectPerWeek.Items.Add("Select");
            int i;
            for (i = 1; i <= 30; i++)
            {
                cmbMaxLectPerWeek.Items.Add(i);
            }
            cmbMaxLectPerWeek.SelectedIndex = 0;
        }
        #endregion


        /*
         * CreatedBy:-Sameer Shinde
         * Created Date:- 12 Dec 2015
         * Purpose:-
         * StartTime:-
         * EndTime:-
         */
        #region-------------------------------------------BindYesNo---------------------------------
        private void BindYesNo()
        {
            cmbAllowMoreLect.Items.Clear();
            cmbAllowMoreLect.Items.Add("Select");
            cmbAllowMoreLect.Items.Add("Yes");
            cmbAllowMoreLect.Items.Add("No");
            cmbAllowMoreLect.SelectedIndex = 0;

            cmbFirstLect.Items.Clear();
            cmbFirstLect.Items.Add("Select");
            cmbFirstLect.Items.Add("Yes");
            cmbFirstLect.Items.Add("No");
            cmbFirstLect.SelectedIndex = 0;

            cmbLastLect.Items.Clear();
            cmbLastLect.Items.Add("Select");
            cmbLastLect.Items.Add("Yes");
            cmbLastLect.Items.Add("No");
            cmbLastLect.SelectedIndex = 0;
        }
        #endregion


        /*
         * CreatedBy:-Sameer Shinde
         * Created Date:- 12 Dec 2015
         * Purpose:-
         * StartTime:-
         * EndTime:-
         */

        #region----------------------------Validate()--------------------------------------------
        private bool Validate()
        {
            if (txtName.Text.Trim() == "" || string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Please Enter Name.", "Name Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtName.Focus();
                return false;
            }
            else if (txtSurname.Text.Trim() == "" || string.IsNullOrEmpty(txtSurname.Text))
            {
                MessageBox.Show("Please Enter Surame.", "Surname Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtSurname.Focus();
                return false;
            }
            else if (txtShortName.Text.Trim() == "" || string.IsNullOrEmpty(txtShortName.Text))
            {
                MessageBox.Show("Please Enter Short Name.", "Short Name Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtShortName.Focus();
                return false;
            }
            else if (rdbActive.IsChecked == false && rdbInActive.IsChecked == false)
            {
                MessageBox.Show("Please Select Staus.", "Status Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                rdbActive.Focus();
                return false;
            }
            else if (cmbMaxMoves.SelectedValue.ToString() == "Select")
            {
                MessageBox.Show("Please Select Max No Of Moves In Branch.", "Max No Of Moves", MessageBoxButton.OK, MessageBoxImage.Warning);
                cmbMaxMoves.Focus();
                return false;
            }
            else if (cmbMaxLectPerDay.SelectedValue.ToString() == "Select")
            {
                MessageBox.Show("Please Select Max No Of Lectuturs Per Day.", "Max No Of Lectures Per Day", MessageBoxButton.OK, MessageBoxImage.Warning);
                cmbMaxLectPerDay.Focus();
                return false;
            }
            else if (cmbMaxLectPerWeek.SelectedValue.ToString() == "Select")
            {
                MessageBox.Show("Please Select Max No Of Lectutures Per Week.", "Max No Of Lectures Per Week", MessageBoxButton.OK, MessageBoxImage.Warning);
                cmbMaxLectPerWeek.Focus();
                return false;
            }
            else if (Convert.ToInt32(cmbMaxLectPerWeek.SelectedValue) < Convert.ToInt32(cmbMaxLectPerDay.SelectedValue))
            {
                MessageBox.Show("Please Enter No of Lect/week Greater than Lect/Day", "Max No Of Lectures Per Week", MessageBoxButton.OK, MessageBoxImage.Warning);
                cmbMaxLectPerWeek.Focus();
                return false;
            }
            //else if (cmbMaxNoLectInRow.SelectedValue.ToString() == "Select")
            //{
            //    MessageBox.Show("Please Select Max No Of Lectutures In Row.", "Max No Of Lectures In Row", MessageBoxButton.OK, MessageBoxImage.Warning);
            //    cmbMaxNoLectInRow.Focus();
            //    return false;
            //}
            else if (cmbAllowMoreLect.SelectedValue.ToString() == "Select")
            {
                MessageBox.Show("Please Select Is Allow More lecture.", "More Lecture", MessageBoxButton.OK, MessageBoxImage.Warning);
                cmbAllowMoreLect.Focus();
                return false;
            }
            else if (cmbMaxNoLectInRow.SelectedValue.ToString() == "Select")
            {
                MessageBox.Show("Please Select Max No Of Lectutures In Row.", "Max No Of Lectures In Row", MessageBoxButton.OK, MessageBoxImage.Warning);
                cmbMaxNoLectInRow.Focus();
                return false;
            }
            else if (cmbFirstLect.SelectedValue.ToString() == "Select")
            {
                MessageBox.Show("Please Select First Lecture.", "First Lecture", MessageBoxButton.OK, MessageBoxImage.Warning);
                cmbFirstLect.Focus();
                return false;
            }
            else if (cmbLastLect.SelectedValue.ToString() == "Select")
            {
                MessageBox.Show("Please Select Last lecture.", "Last Lecture", MessageBoxButton.OK, MessageBoxImage.Warning);
                cmbLastLect.Focus();
                return false;
            }
            //else if (cmbFreeTimeStartHrs.SelectedValue.ToString() == "Select")
            //{
            //    MessageBox.Show("Please Select Free Time Hours", "Free Time Hours", MessageBoxButton.OK, MessageBoxImage.Warning);
            //    cmbFreeTimeStartHrs.Focus();
            //    return false;
            //}
            //else if (cmbFreeTimeStartMin.SelectedValue.ToString() == "Select")
            //{
            //    MessageBox.Show("Please Select Free Time Minutes", "Free Time Minutes", MessageBoxButton.OK, MessageBoxImage.Warning);
            //    cmbFreeTimeStartMin.Focus();
            //    return false;
            //}
            //else if (cmbFreeTimeEndHrs.SelectedValue.ToString() == "Select")
            //{
            //    MessageBox.Show("Please Select Free Time Hours", "Free Time Hours", MessageBoxButton.OK, MessageBoxImage.Warning);
            //    cmbFreeTimeEndHrs.Focus();
            //    return false;
            //}
            //else if (cmbFreeTimeEndMin.SelectedValue.ToString() == "Select")
            //{
            //    MessageBox.Show("Please Select Free Time Minutes", "Free Time Minutes", MessageBoxButton.OK, MessageBoxImage.Warning);
            //    cmbFreeTimeEndMin.Focus();
            //    return false;

            else if (cmbFreeTimeStartHrs.SelectedValue.ToString() != "Select")
            {
                if (cmbFreeTimeStartMin.SelectedValue.ToString() != "Select")
                {
                    if (cmbFreeTimeEndHrs.SelectedValue.ToString() != "Select")
                    {
                        if (cmbFreeTimeEndMin.SelectedValue.ToString() != "Select")
                        {
                            if (Convert.ToInt32(cmbFreeTimeStartHrs.SelectedValue) > Convert.ToInt32(cmbFreeTimeEndHrs.SelectedValue))
                            {
                                MessageBox.Show("Free Time Start Hour is less or equals to End hours", "Free Time", MessageBoxButton.OK, MessageBoxImage.Warning);
                                cmbFreeTimeStartHrs.Focus();
                                return false;
                            }
                        }
                    }
                  }
                }
                 if (cmbFreeTimeStartHrs.SelectedValue.ToString() != "Select")
                {
                    if (cmbFreeTimeStartMin.SelectedValue.ToString() != "Select")
                    {
                        if (cmbFreeTimeEndHrs.SelectedValue.ToString() != "Select")
                        {
                            if (cmbFreeTimeEndMin.SelectedValue.ToString() != "Select")
                            {

                                if ((Convert.ToInt32(cmbFreeTimeStartHrs.SelectedValue) == Convert.ToInt32(cmbFreeTimeEndHrs.SelectedValue)) && (Convert.ToInt32(cmbFreeTimeStartMin.SelectedValue) >= Convert.ToInt32(cmbFreeTimeEndMin.SelectedValue)))
                                {
                                    MessageBox.Show("Free Time End Minutes must be greater than Start time", "Free Time", MessageBoxButton.OK, MessageBoxImage.Warning);
                                    cmbFreeTimeEndMin.Focus();
                                    return false;
                                }
                            }
                        }
                    }
                }
            
                if (MondayValidate())
                {
                    if (TuesdayValidate())
                    {
                        if (WednesdayValidate())
                        {
                            if (ThrusdayValidate())
                            {
                                if (FridayValidate())
                                {
                                    if (SaturdayValidate())
                                    {
                                        if (SundayValidate())
                                        {
                                            if (daycheckcount > 0)
                                            { return true; }
                                            else
                                            {
                                                if (btnSave.Content.ToString() == "Save")
                                                {
                                                    MessageBox.Show("Select At Least One Day.", "Info", MessageBoxButton.OK, MessageBoxImage.Warning);
                                                    return false;
                                                }
                                                else { return true; }
                                            }
                                        }

                                        else
                                        { return false; }
                                    }
                                    else
                                    { return false; }
                                }
                                else
                                { return false; }
                            }
                            else
                            { return false; }
                        }
                        else
                        { return false; }
                    }
                    else
                    { return false; }
                }


                else
                {
                    return false;
                }
            
        }
        #endregion

        #region-------------------------------------------------------Monday Validate()---------------------------------------------------------
        private bool MondayValidate()
        {
            if (chkMon.IsChecked == true)
            {
                if (chkStartHrs1.SelectedItem.ToString() == "HRS")
                {
                    MessageBox.Show("Please Select Start Hours From Monday", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    chkStartHrs1.Focus();
                    return false;
                }
                else if (chkStartMin1.SelectedItem.ToString() == "Min")
                {
                    MessageBox.Show("Please Select Minutes From Monday", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    chkStartMin1.Focus();
                    return false;

                }
                else if (chkEndhrs1.SelectedItem.ToString() == "HRS")
                {
                    MessageBox.Show("Please Select End Hours From Monday", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    chkEndhrs1.Focus();
                    return false;
                }
                else if (EndMin1.SelectedItem.ToString() == "Min")
                {
                    MessageBox.Show("Please Select End Minutes From Monday", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    EndMin1.Focus();
                    return false;
                }
                else if (Convert.ToInt32(chkStartHrs1.SelectedItem.ToString()) > Convert.ToInt32(chkEndhrs1.SelectedItem.ToString()))
                {
                    MessageBox.Show("End Hour Time Is Must Be Greater Than End Time", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    chkEndhrs1.Focus();
                    return false;
                }
                else if ((Convert.ToInt32(chkStartHrs1.SelectedItem.ToString()) == Convert.ToInt32(chkEndhrs1.SelectedItem.ToString())) && (Convert.ToInt32(chkStartMin1.SelectedItem.ToString()) >= Convert.ToInt32(EndMin1.SelectedItem.ToString())))
                {
                    MessageBox.Show("End Minute Time Is Must Be Greater Than End Time", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    chkStartHrs1.Focus();
                    return false;

                }
                else
                { return true; }

            }

            else { return true; }
        }
        #endregion

        #region------------------------------------------------------Tuesday Validate()---------------------------------------------------------
        private bool TuesdayValidate()
        {
            if (chkTue.IsChecked == true)
            {
                if (chkStartHrs2.SelectedItem.ToString() == "HRS")
                {
                    MessageBox.Show("Please Select Start Hours From Tuesday", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    chkStartHrs2.Focus();
                    return false;
                }
                else if (chkStartMin2.SelectedItem.ToString() == "Min")
                {
                    MessageBox.Show("Please Select Minutes From Tuesday", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    chkStartMin2.Focus();
                    return false;

                }
                else if (chkEndhrs2.SelectedItem.ToString() == "HRS")
                {
                    MessageBox.Show("Please Select End Hours From Tuesday", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    chkEndhrs2.Focus();
                    return false;
                }
                else if (EndMin2.SelectedItem.ToString() == "Min")
                {
                    MessageBox.Show("Please Select End Minutes From Tuesday", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    EndMin2.Focus();
                    return false;
                }
                else if (Convert.ToInt32(chkStartHrs2.SelectedItem.ToString()) > Convert.ToInt32(chkEndhrs2.SelectedItem.ToString()))
                {
                    MessageBox.Show("End Hour Time Is Must Be Greater Than End Time", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    chkStartHrs2.Focus();
                    return false;
                }
                else if ((Convert.ToInt32(chkStartHrs2.SelectedItem.ToString()) == Convert.ToInt32(chkEndhrs2.SelectedItem.ToString())) && (Convert.ToInt32(chkStartMin2.SelectedItem.ToString()) >= Convert.ToInt32(EndMin2.SelectedItem.ToString())))
                {
                    MessageBox.Show("End Minute Time Is Must Be Greater Than End Time", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    EndMin2.Focus();
                    return false;

                }
                else
                { return true; }
            }

            else { return true; }
        }
        #endregion

        #region------------------------------------------------------Wednsday Validate()--------------------------------------------------------
        private bool WednesdayValidate()
        {
            if (chkWed.IsChecked == true)
            {
                if (chkStartHrs3.SelectedItem.ToString() == "HRS")
                {
                    MessageBox.Show("Please Select Start Hours From Wednesday", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    chkStartHrs3.Focus();
                    return false;
                }
                else if (chkStartMin3.SelectedItem.ToString() == "Min")
                {
                    MessageBox.Show("Please Select Minutes From Wednesday", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    chkStartMin3.Focus();
                    return false;

                }
                else if (chkEndhrs3.SelectedItem.ToString() == "HRS")
                {
                    MessageBox.Show("Please Select End Hours From Wednesday", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    chkEndhrs3.Focus();
                    return false;
                }
                else if (EndMin3.SelectedItem.ToString() == "Min")
                {
                    MessageBox.Show("Please Select End Minutes From Wednesday", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    EndMin3.Focus();
                    return false;
                }
                else if (Convert.ToInt32(chkStartHrs3.SelectedItem.ToString()) > Convert.ToInt32(chkEndhrs3.SelectedItem.ToString()))
                {
                    MessageBox.Show("End Hour Time Is Must Be Greater Than End Time", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    chkStartHrs3.Focus();
                    return false;
                }
                else if ((Convert.ToInt32(chkStartHrs3.SelectedItem.ToString()) == Convert.ToInt32(chkEndhrs3.SelectedItem.ToString())) && (Convert.ToInt32(chkStartMin3.SelectedItem.ToString()) >= Convert.ToInt32(EndMin3.SelectedItem.ToString())))
                {
                    MessageBox.Show("End Minute Time Is Must Be Greater Than End Time", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    EndMin3.Focus();
                    return false;

                }
                else
                { return true; }
            }

            else { return true; }

        }
        #endregion

        #region------------------------------------------------------Thrusday Validate()--------------------------------------------------------
        private bool ThrusdayValidate()
        {
            if (chkThru.IsChecked == true)
            {
                if (chkStartHrs4.SelectedItem.ToString() == "HRS")
                {
                    MessageBox.Show("Please Select Start Hours From Thrusday", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    chkStartHrs4.Focus();
                    return false;
                }
                else if (chkStartMin4.SelectedItem.ToString() == "Min")
                {
                    MessageBox.Show("Please Select Minutes From Thrusday", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    chkStartMin4.Focus();
                    return false;

                }
                else if (chkEndhrs4.SelectedItem.ToString() == "HRS")
                {
                    MessageBox.Show("Please Select End Hours From Thrusday", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    chkEndhrs4.Focus();
                    return false;
                }
                else if (EndMin4.SelectedItem.ToString() == "Min")
                {
                    MessageBox.Show("Please Select End Minutes From Thrusday", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    EndMin4.Focus();
                    return false;
                }
                else if (Convert.ToInt32(chkStartHrs4.SelectedItem.ToString()) > Convert.ToInt32(chkEndhrs4.SelectedItem.ToString()))
                {
                    MessageBox.Show("End Hour Time Is Must Be Greater Than End Time", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    chkEndhrs4.Focus();
                    return false;
                }
                else if ((Convert.ToInt32(chkStartHrs4.SelectedItem.ToString()) == Convert.ToInt32(chkEndhrs4.SelectedItem.ToString())) && (Convert.ToInt32(chkStartMin4.SelectedItem.ToString()) >= Convert.ToInt32(EndMin4.SelectedItem.ToString())))
                {
                    MessageBox.Show("End Minute Time Is Must Be Greater Than End Time", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    EndMin4.Focus();
                    return false;

                }
                else
                { return true; }
            }


            else { return true; }
        }
        #endregion

        #region-------------------------------------------------------Friday Validate()---------------------------------------------------------
        private bool FridayValidate()
        {
            if (chkFri.IsChecked == true)
            {
                if (chkStartHrs5.SelectedItem.ToString() == "HRS")
                {
                    MessageBox.Show("Please Select Start Hours From Friday", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    chkStartHrs5.Focus();
                    return false;
                }
                else if (chkStartMin5.SelectedItem.ToString() == "Min")
                {
                    MessageBox.Show("Please Select Minutes From Friday", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    chkStartMin5.Focus();
                    return false;

                }
                else if (chkEndhrs5.SelectedItem.ToString() == "HRS")
                {
                    MessageBox.Show("Please Select End Hours From Friday", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    chkEndhrs5.Focus();
                    return false;
                }
                else if (EndMin5.SelectedItem.ToString() == "Min")
                {
                    MessageBox.Show("Please Select End Minutes From Friday", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    EndMin5.Focus();
                    return false;
                }
                else if (Convert.ToInt32(chkStartHrs5.SelectedItem.ToString()) > Convert.ToInt32(chkEndhrs5.SelectedItem.ToString()))
                {
                    MessageBox.Show("End Hour Time Is Must Be Greater Than End Time", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    chkEndhrs5.Focus();
                    return false;
                }
                else if ((Convert.ToInt32(chkStartHrs5.SelectedItem.ToString()) == Convert.ToInt32(chkEndhrs5.SelectedItem.ToString())) && (Convert.ToInt32(chkStartMin5.SelectedItem.ToString()) >= Convert.ToInt32(EndMin5.SelectedItem.ToString())))
                {
                    MessageBox.Show("End Minute Time Is Must Be Greater Than End Time", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    EndMin5.Focus();
                    return false;

                }
                else
                { return true; }
            }

            else { return true; }
        }
        #endregion

        #region------------------------------------------------------Saturday Validate()--------------------------------------------------------
        private bool SaturdayValidate()
        {
            if (chkSat.IsChecked == true)
            {
                if (chkStartHrs6.SelectedItem.ToString() == "HRS")
                {
                    MessageBox.Show("Please Select Start Hours From Friday", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    chkStartHrs6.Focus();
                    return false;
                }
                else if (chkStartMin6.SelectedItem.ToString() == "Min")
                {
                    MessageBox.Show("Please Select Minutes From Friday", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    chkStartMin6.Focus();
                    return false;

                }
                else if (chkEndhrs6.SelectedItem.ToString() == "HRS")
                {
                    MessageBox.Show("Please Select End Hours From Friday", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    chkEndhrs6.Focus();
                    return false;
                }
                else if (EndMin6.SelectedItem.ToString() == "Min")
                {
                    MessageBox.Show("Please Select End Minutes From Friday", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    EndMin6.Focus();
                    return false;
                }
                else if (Convert.ToInt32(chkStartHrs6.SelectedItem.ToString()) > Convert.ToInt32(chkEndhrs6.SelectedItem.ToString()))
                {
                    MessageBox.Show("End Hour Time Is Must Be Greater Than End Time", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    chkEndhrs6.Focus();
                    return false;
                }
                else if ((Convert.ToInt32(chkStartHrs6.SelectedItem.ToString()) == Convert.ToInt32(chkEndhrs6.SelectedItem.ToString())) && (Convert.ToInt32(chkStartMin6.SelectedItem.ToString()) >= Convert.ToInt32(EndMin6.SelectedItem.ToString())))
                {
                    MessageBox.Show("End Minute Time Is Must Be Greater Than End Time", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    EndMin6.Focus();
                    return false;

                }
                else
                { return true; }
            }

            else { return true; }
        }
        #endregion

        #region-------------------------------------------------------Sunday Validate()---------------------------------------------------------
        private bool SundayValidate()
        {
            if (chkSun.IsChecked == true)
            {
                if (chkStartHrs7.SelectedItem.ToString() == "HRS")
                {
                    MessageBox.Show("Please Select Start Hours From Sunday", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    chkStartHrs7.Focus();
                    return false;
                }
                else if (chkStartMin7.SelectedItem.ToString() == "Min")
                {
                    MessageBox.Show("Please Select Minutes From Sunday", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    chkStartMin7.Focus();
                    return false;

                }
                else if (chkEndhrs7.SelectedItem.ToString() == "HRS")
                {
                    MessageBox.Show("Please Select End Hours From Sunday", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    chkEndhrs7.Focus();
                    return false;
                }
                else if (EndMin7.SelectedItem.ToString() == "Min")
                {
                    MessageBox.Show("Please Select End Minutes From Sunday", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    EndMin7.Focus();
                    return false;
                }
                else if (Convert.ToInt32(chkStartHrs7.SelectedItem.ToString()) > Convert.ToInt32(chkEndhrs7.SelectedItem.ToString()))
                {
                    MessageBox.Show("End Hour Time Is Must Be Greater Than End Time", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    chkEndhrs7.Focus();
                    return false;
                }
                else if ((Convert.ToInt32(chkStartHrs7.SelectedItem.ToString()) == Convert.ToInt32(chkEndhrs7.SelectedItem.ToString())) && (Convert.ToInt32(chkStartMin7.SelectedItem.ToString()) >= Convert.ToInt32(EndMin7.SelectedItem.ToString())))
                {
                    MessageBox.Show("End Minute Time Is Must Be Greater Than End Time", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    EndMin7.Focus();
                    return false;

                }
                else
                { return true; }
            }


            else { return true; }
        }
        #endregion
        /*
         * CreatedBy:-Sameer Shinde
         * Created Date:- 12 Dec 2015
         * Purpose:-
         * StartTime:-
         * EndTime:-
         */

        #region----------------------------SetParameters()--------------------------------------------
        private void SetParameters()
        {
            TeacherID = UPID;
            TeacherName = txtName.Text.Trim();
            TeacherSurname = txtSurname.Text.Trim();
            TeacherShortName = txtShortName.Text.Trim();
            if (rdbActive.IsChecked == true && rdbInActive.IsChecked == false)
            {
                Active = 1;
                IsDeleted = 0;

            }
            else if (rdbActive.IsChecked == false && rdbInActive.IsChecked == true)
            {
                Active = 0;
                IsDeleted = 0;
            }

            MaxNoOfMovesInBranch = Convert.ToInt32(cmbMaxMoves.SelectedValue);
            MaxLecturePerDay = Convert.ToInt32(cmbMaxLectPerDay.SelectedValue);
            MaxLectPerWeek = Convert.ToInt32(cmbMaxLectPerWeek.SelectedValue);
            //IsMoreThanOneLecture = Convert.ToString(cmbAllowMoreLect.SelectedValue);
            if (cmbAllowMoreLect.SelectedValue.ToString() == "Yes")
            {
                IsMoreThanOneLecture = 1;
            }
            else if (cmbAllowMoreLect.SelectedValue.ToString() == "No")
            {
                IsMoreThanOneLecture = 0;
            }

            MaxNoOfLectInRow = Convert.ToInt32(cmbMaxNoLectInRow.SelectedValue);
            //IsFirstLecture = Convert.ToString(cmbFirstLect.SelectedValue);
            if (Convert.ToString(cmbFirstLect.SelectedValue) == "Yes")
            {
                IsFirstLecture = 1;
            }
            else if (Convert.ToString(cmbFirstLect.SelectedValue) == "No")
            {
                IsFirstLecture = 0;
            }
            //IsLastLecture = Convert.ToString(cmbLastLect.SelectedValue);
            if (Convert.ToString(cmbLastLect.SelectedValue) == "Yes")
            {
                IsLastLecture = 1;
            }
            else if (Convert.ToString(cmbLastLect.SelectedValue) == "No")
            {
                IsLastLecture = 0;
            }
            if (cmbFreeTimeStartHrs.SelectedValue.ToString() == "Select" && cmbFreeTimeStartMin.SelectedValue.ToString() == "Select" && cmbFreeTimeEndHrs.SelectedValue.ToString() == "Select" && cmbFreeTimeEndMin.SelectedValue.ToString() == "Select")
            {
                FreeTimeStart = "00:00:00";
                FreeTimeEnd = "00:00:00";
            }
            else
            {
                FreeTimeStart = cmbFreeTimeStartHrs.SelectedValue.ToString();
                FreeTimeStart += ":" + cmbFreeTimeStartMin.SelectedValue.ToString();

                FreeTimeEnd = cmbFreeTimeEndHrs.SelectedValue.ToString();
                FreeTimeEnd += ":" + cmbFreeTimeEndMin.SelectedValue.ToString();
            }
            UpdatedByUserID = 1;
            UpdatedDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");

            //DateTime dt = DateTime.ParseExact(DateTime.Now.ToString(), "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
            //DateTime ti = DateTime.ParseExact(DateTime.Now.ToString,"yyyy/dd/MM hh:mm:ss tt")

        }
        #endregion

        /*
         * CreatedBy:-Sameer Shinde
         * Created Date:- 12 Dec 2015
         * Purpose:-
         * StartTime:-
         * EndTime:-
         */

        #region---------------------------------------------SaveDeltails()-------------------------------------------
        private void SaveDetails()
        {
            //string Result = objTeacher.SaveTeacher(TeacherID, TeacherName, TeacherSurname, TeacherShortName, MaxNoOfMovesInBranch, MaxLecturePerDay, MaxLectPerWeek, IsMoreThanOneLecture, MaxNoOfLectInRow, IsFirstLecture, IsLastLecture, FreeTimeStart, FreeTimeEnd, UpdatedByUserID, UpdatedDate, Active, IsDeleted);
            //if (Result == "Save Sucessfully...!!!" || Result == "Updated Sucessfully...!!!")
            //{
            //    //MessageBox.Show(Result, "Save SucessFull", MessageBoxButton.OK, MessageBoxImage.Information);
            //    //ClearFields();
            //    MaxTeacherID = objTeacher.GetMaxTeacherID();
            //}
            //else
            //{
            //    MessageBox.Show(Result, "Error To Save", MessageBoxButton.OK, MessageBoxImage.Warning);
            //}
        }
        #endregion


        /*
         * CreatedBy:-Sameer Shinde
         * Created Date:- 12 Dec 2015
         * Purpose:-
         * StartTime:-
         * EndTime:-
         */
        #region-------------------------------------BindGrid()-------------------------------------------------------------------
        private void BindGrid()
        {
            DataSet ds = objTeacher.GetTeacher(0);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dgvTeacher.ItemsSource = ds.Tables[0].DefaultView;
            }
            else
            {
                dgvTeacher.ItemsSource = null;
               // MessageBox.Show("Data Not Found", "Message");

            }
        }
        #endregion

        /*
         * CreatedBy:-Sameer Shinde
         * Created Date:- 12 Dec 2015
         * Purpose:-
         * StartTime:-
         * EndTime:-
         */
        #region----------------------------------------Row Double Click()-------------------------------------------------------------------
        private void Row_DoubleClick1(object sender, MouseButtonEventArgs e)
        {
            try
            {               
                object item = dgvTeacher.SelectedItem;
                UPID = Convert.ToInt32(((System.Data.DataRowView)(dgvTeacher.CurrentItem)).Row.ItemArray[0].ToString());
                txtName.Text = ((System.Data.DataRowView)(dgvTeacher.CurrentItem)).Row.ItemArray[1].ToString();
                txtSurname.Text = ((System.Data.DataRowView)(dgvTeacher.CurrentItem)).Row.ItemArray[2].ToString();
                txtShortName.Text = ((System.Data.DataRowView)(dgvTeacher.CurrentItem)).Row.ItemArray[3].ToString();
                Clears();
                GetTeacherAvailableDetails(UPID);
                string time = ((System.Data.DataRowView)(dgvTeacher.CurrentItem)).Row.ItemArray[4].ToString();
                string[] a = time.Split(':');
                cmbFreeTimeStartHrs.Text = a[0];
                if (a[0] == "00")
                { cmbFreeTimeStartHrs.SelectedIndex = 0; }
                else
                { cmbFreeTimeStartHrs.Text = a[0]; }

                cmbFreeTimeStartMin.Text = a[1];
                if (a[0]=="00"&&a[1] == "00")
                { cmbFreeTimeStartMin.SelectedIndex = 0; }
                else
                { cmbFreeTimeStartMin.Text = a[1]; }


                string ENDtime = ((System.Data.DataRowView)(dgvTeacher.CurrentItem)).Row.ItemArray[5].ToString();
                string[] b = ENDtime.Split(':');
                cmbFreeTimeEndHrs.Text = b[0];
                if (a[0] == "00")
                { cmbFreeTimeEndHrs.SelectedIndex = 0; }
                else
                { cmbFreeTimeEndHrs.Text = b[0]; }

                cmbFreeTimeEndMin.Text = b[1];
                if (b[0] == "00" && b[1] == "00")
                { cmbFreeTimeEndMin.SelectedIndex = 0; }
                else
                { cmbFreeTimeEndMin.Text = b[1]; }

                cmbMaxMoves.Text = ((System.Data.DataRowView)(dgvTeacher.CurrentItem)).Row.ItemArray[6].ToString();
                cmbMaxLectPerDay.Text = ((System.Data.DataRowView)(dgvTeacher.CurrentItem)).Row.ItemArray[7].ToString();
                cmbMaxLectPerWeek.Text = ((System.Data.DataRowView)(dgvTeacher.CurrentItem)).Row.ItemArray[8].ToString();
                cmbAllowMoreLect.Text = ((System.Data.DataRowView)(dgvTeacher.CurrentItem)).Row.ItemArray[9].ToString();
                if (cmbAllowMoreLect.Text == "True")
                {
                    cmbAllowMoreLect.Text = "Yes";
                }
                else if (cmbAllowMoreLect.Text == "False")
                {
                    cmbAllowMoreLect.Text = "No";
                }
                cmbMaxNoLectInRow.Text = ((System.Data.DataRowView)(dgvTeacher.CurrentItem)).Row.ItemArray[10].ToString();
                cmbFirstLect.Text = ((System.Data.DataRowView)(dgvTeacher.CurrentItem)).Row.ItemArray[11].ToString();
                if (cmbFirstLect.Text == "True")
                {
                    cmbFirstLect.Text = "Yes";
                }
                else if (cmbFirstLect.Text == "False")
                {
                    cmbFirstLect.Text = "No";
                }
                cmbLastLect.Text = ((System.Data.DataRowView)(dgvTeacher.CurrentItem)).Row.ItemArray[12].ToString();
                if (cmbLastLect.Text == "True")
                {
                    cmbLastLect.Text = "Yes";
                }
                else if (cmbLastLect.Text == "False")
                {
                    cmbLastLect.Text = "No";
                }

                bool act = Convert.ToBoolean(((System.Data.DataRowView)(dgvTeacher.CurrentItem)).Row.ItemArray[13].ToString());
                //bool del = Convert.ToBoolean(((System.Data.DataRowView)(dgvTeacher.CurrentItem)).Row.ItemArray[11].ToString());


                if (act == true)
                {
                    rdbActive.IsChecked = true;
                }
                else if (act == false)
                {
                    rdbInActive.IsChecked = true;
                }
                btnDelete.IsEnabled = true;
                btnSave.Content = "Update";
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception Error");
            }
        }
        #endregion

        /*
         * CreatedBy:-Sameer Shinde
         * Created Date:- 12 Dec 2015
         * Purpose:-
         * StartTime:-
         * EndTime:-
         */

        #region--------------------------------------------DeleteTeacher()--------------------------------------------------------------
        private void DeleteTeacher()
        {
            string Result = objTeacher.DeleteTeacher(TeacherID, UpdatedByUserID, UpdatedDate);
            if (Result == "Deleted Sucessfully...!!")
            {
                MessageBox.Show(Result, "Delete Sucessfully", MessageBoxButton.OK, MessageBoxImage.Information);
                ClearFields();
            }
            else
            {
                MessageBox.Show(Result, "Error To Delete", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        #region----------------------ValidationOfName_Teacher---------------------------------------
        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (txtName.Text != "")
                {
                    if (txtName.Text.Length > 0)
                    {
                        if (System.Text.RegularExpressions.Regex.IsMatch(txtName.Text, "^[a-zA-Z]+$"))
                        {
                        }
                        else
                        {
                            MessageBox.Show("Please Enter Only Alphabate", "Teacher Name", MessageBoxButton.OK, MessageBoxImage.Warning);
                            txtName.Text = "";
                            txtName.Focus();
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion


        #region--------------------------------txtSurname_TextChanged_Validation------------------------
        private void txtSurname_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (txtSurname.Text != "")
                {
                    if (txtSurname.Text.Length > 0)
                    {
                        if (System.Text.RegularExpressions.Regex.IsMatch(txtSurname.Text, "^[a-zA-Z]+$"))
                        {
                        }
                        else
                        {
                            MessageBox.Show("Please Enter Only Alphabate", "Surname", MessageBoxButton.OK, MessageBoxImage.Warning);
                            txtSurname.Text = "";
                            txtSurname.Focus();
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion

        #region------------------------txtShortName_TextChanged--------------------------------------
        private void txtShortName_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (txtShortName.Text != "")
                {
                    if (txtShortName.Text.Length > 0 && txtShortName.Text.Length == 1)
                    {
                        if (System.Text.RegularExpressions.Regex.IsMatch(txtShortName.Text, "^[a-zA-Z]"))
                        {
                        }
                        else
                        {
                            MessageBox.Show("Please Enter First Characerter Alphabate", "Teacger Short Name", MessageBoxButton.OK, MessageBoxImage.Warning);
                            txtShortName.Text = "";
                            txtShortName.Focus();
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion

        /*
         * CreatedBy:-Sameer Shinde
         * Created Date:- 12 Dec 2015
         * Purpose:- Teacher Availability row double click
         * StartTime:-
         * EndTime:-
         */
       


        #region---------------------------------------btnCopy_Click--------------------------------------
        private void btnCopy_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                if (dgTeacherAvail.SelectedItems.Count == 1)
                    {
                        for (int i = 0; i < dgTeacherAvail.SelectedItems.Count; i++)
                        {

                            System.Data.DataRowView selectedFile = (System.Data.DataRowView)dgTeacherAvail.SelectedItems[i];
                            int UPID = Convert.ToInt32(selectedFile.Row.ItemArray[0]);
                            Clears();
                            GetTeacherAvailableDetails(UPID);

                        }

                    }
                    else
                    {
                        MessageBox.Show("Please Select Row from Copy Grid", "Info", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception");
            }
        }

        #endregion

    }
}
