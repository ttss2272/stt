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

namespace SchoolManagement.Batch
{
    /// <summary>
    /// Interaction logic for CombineBatchAvil.xaml
    /// </summary>
    public partial class CombineBatchAvil : Window
    {
        /*
        * Created By:- Sameer
        * Ctreated Date :- 10 Dec 2015
        * StartTime:-
        * EndTime:-
        * Purpose:- Declare Global Variables
        */
        #region------------------------Declare Variables Globally()--------------------
        int BatchID, result1,ResultCount, MaxBatchID, UpdatedByUserID, IsActive, IsDeleted, ClassID, UpID, LectureDuration, IsLunchBreak, MaxNoLecturesDay, MaxNoLecturesWeek, IsAllowMoreThanOneLectInBatch, MaxNoOfLecureInRow;
        string BatchName, BatchCode, UpdatedDate, LunchBreakStartTime, LunchBreakEndTime, n = "0", m = "1";
        int daycheckcount = 0,cnn,NoOfAvailDays;
        BLBatch obj_Batch = new BLBatch();
        BLAddClass obj_Class = new BLAddClass();

        BLBatch objBatch = new BLBatch();
        BLAddBranch obj_Branch = new BLAddBranch();
        string Day, FinalStartTime, FinalEndTime;

        string tmpStartTime, tmpEndTime, Result;
        string[] StartTime;
        string[] EndTime;
        string[] s;

        #endregion
        #region---------------------------------main()--------------------------------------------
        public CombineBatchAvil()
        {
            try
            {
            InitializeComponent();
             this.WindowState = WindowState.Maximized;
                this.Width = System.Windows.SystemParameters.PrimaryScreenWidth;
                this.Height = System.Windows.SystemParameters.PrimaryScreenHeight;
                
                clearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion
        #region-----------------------------clearFields()------------------------------------------

        private void clearFields()
        {
            cbClassName.SelectedIndex = 0;
            txtBatchName.Text = "";
            txtBatchCode.Text = "";
            txtlecDuration.Text = "";
            cmbTimeStartMin.Items.Clear();
            cmbTimeEndMin.Items.Clear();
            TimingHrs();
            TimingMin();
            cbmaxlecperday.Items.Clear();
            MaxLectPerDay();
            cbmaxlectperrow.Items.Clear();
            MaxLectInRow();
            cbmaxlecperweek.Items.Clear();
            MaxLectPerWeek1();
            BindYesNo();
            UpID = 0;
            BindGridview();
            rdoActive.IsChecked = true;
            rdoDeActive.IsChecked = false;
            btnDelete.IsEnabled = false;
            btnadd.Content = "Save";
            select();
            if (cbLunchBreak.Text == "Select")
            {
                cmbTimeStartHrs.IsEnabled = false;
                cmbTimeStartMin.IsEnabled = false;
                cmbTimeEndHrs.IsEnabled = false;
                cmbTimeEndMin.IsEnabled = false;


            }

            /* Batch Avialibilty ClearFields*/
            BindHours();
            BindMinutes();
            BindBatchAvailGrid();
            UncheckAllCheckBoxes();
            EnableDropdown();
            if (chkAvailSameTime.IsChecked == true)
            {
                gbSameTime.Visibility = Visibility.Visible;
            }
            else
            {
                gbSameTime.Visibility = Visibility.Hidden;
            }
           // gbbtavaday.IsEnabled = false;


        }
        #endregion

        #region---------------------------------------------------------Clears()-------------------------------------------------------
        private void Clears()
        {

            BindHours();
            BindMinutes();
            BindBatchAvailGrid();
            UncheckAllCheckBoxes();
            gbSameTime.Visibility = Visibility.Hidden;
            EnableDropdown();

        }
        #endregion

        #region---------------------------------------------------------------BindBatchAvailGrid()-------------------------------------------------------
        private void BindBatchAvailGrid()
        {
            DataSet ds = objBatch.BindBatchAvail();

            if (ds.Tables[0].Rows.Count > 0)
            {
                dgBatchAvail.DataContext = null;
                dgBatchAvail.DataContext = ds.Tables[0].DefaultView;
            }

        }
        #endregion


        #region-------------------------------------------------SetParameters()-------------------------------------
        private void SetParameters()
        {
            BatchID = UpID;
            BatchName = txtBatchName.Text.Trim();
            BatchCode = txtBatchCode.Text.Trim();
            ClassID = Convert.ToInt32(cbClassName.SelectedValue);
            LectureDuration = Convert.ToInt32(txtlecDuration.Text.ToString());
            if (cbLunchBreak.SelectedValue.ToString() == "Yes")
            {
                IsLunchBreak = 1;
            }
            else if (cbLunchBreak.SelectedValue.ToString() == "No")
            {
                IsLunchBreak = 0;
            }

            MaxNoLecturesDay = Convert.ToInt32(cbmaxlecperday.SelectedValue);
            MaxNoLecturesWeek = Convert.ToInt32(cbmaxlecperweek.SelectedValue);
            if (cballowlect.SelectedValue.ToString() == "Yes")
            {
                IsAllowMoreThanOneLectInBatch = 1;
            }
            else if (cballowlect.SelectedValue.ToString() == "No")
            {
                IsAllowMoreThanOneLectInBatch = 0;
            }
            LunchBreakStartTime = cmbTimeStartHrs.SelectedValue.ToString();
            LunchBreakStartTime += ":" + cmbTimeStartMin.SelectedValue.ToString();

            LunchBreakEndTime = cmbTimeEndHrs.SelectedValue.ToString();
            LunchBreakEndTime += ":" + cmbTimeEndMin.SelectedValue.ToString();
            MaxNoOfLecureInRow = Convert.ToInt32(cbmaxlectperrow.SelectedValue);
            UpdatedByUserID = 1;
            UpdatedDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
            if (rdoActive.IsChecked == true && rdoDeActive.IsChecked == false)
            {
                IsActive = 1;
                IsDeleted = 0;
            }
            else if (rdoActive.IsChecked == false && rdoDeActive.IsChecked == true)
            {
                IsActive = 0;
                IsDeleted = 0;
            }
        }
        #endregion

        #region---------------------------Validate()-----------------------------------------
        public bool Validate()
        {
            if (cbClassName.Text == "Select")
            {
                MessageBox.Show("Please Select Class Name.", "Class Name Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                cbClassName.Focus();
                return false;
            }
            else if (txtBatchName.Text.Trim() == "" || string.IsNullOrEmpty(txtBatchName.Text))
            {
                MessageBox.Show("Please Enter Batch Name.", "Batch Name Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtBatchName.Focus();
                return false;
            }
            else if (txtBatchCode.Text.Trim() == "" || string.IsNullOrEmpty(txtBatchCode.Text))
            {
                MessageBox.Show("Please Enter Batch Code.", "Batch Code Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtBatchCode.Focus();
                return false;
            }

            else if (txtlecDuration.Text.Trim() == "" || string.IsNullOrEmpty(txtlecDuration.Text))
            {
                MessageBox.Show("Please Enter Lecture Duration Time", "Lecture Duration Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtlecDuration.Focus();
                return false;
            }
            else if (cbLunchBreak.Text == "Select")
            {
                MessageBox.Show("Please Select Is There Lunch Break", "Lunch Break", MessageBoxButton.OK, MessageBoxImage.Warning);
                cbLunchBreak.Focus();
                return false;
            }
            else if ((cbLunchBreak.Text == "Yes") && cmbTimeStartHrs.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Lunch Start Time Hours", "Lunch Time Starts Hours", MessageBoxButton.OK, MessageBoxImage.Warning);
                cmbTimeStartHrs.Focus();
                return false;
            }
            else if ((cbLunchBreak.Text == "Yes") && cmbTimeStartMin.Text == "Min")
            {
                MessageBox.Show("Please Select Lunch Start Time Minutes", "Lunch Time Starts Minutes", MessageBoxButton.OK, MessageBoxImage.Warning);
                cmbTimeStartMin.Focus();
                return false;
            }
            else if ((cbLunchBreak.Text == "Yes") && cmbTimeEndHrs.Text == "Hours")
            {
                MessageBox.Show("Please Select Lunch End Time Hours", "Lunch Time End Hours", MessageBoxButton.OK, MessageBoxImage.Warning);
                cmbTimeEndHrs.Focus();
                return false;
            }
            else if ((cbLunchBreak.Text == "Yes") && cmbTimeEndMin.Text == "Min")
            {
                MessageBox.Show("Please Select Lunch End Time Minutes", "Lunch Time End Minutes", MessageBoxButton.OK, MessageBoxImage.Warning);
                cmbTimeEndMin.Focus();
                return false;
            }
            else if ((cbLunchBreak.Text == "Yes") && (Convert.ToInt32(cmbTimeStartHrs.SelectedValue) > Convert.ToInt32(cmbTimeEndHrs.SelectedValue)))
            {
                MessageBox.Show("Free Time Start Hour is less or equals to End hours", "Free Time", MessageBoxButton.OK, MessageBoxImage.Warning);
                cmbTimeStartHrs.Focus();
                return false;
            }
            else if ((cbLunchBreak.Text == "Yes") && (Convert.ToInt32(cmbTimeStartHrs.SelectedValue) == Convert.ToInt32(cmbTimeEndHrs.SelectedValue)) && (Convert.ToInt32(cmbTimeStartMin.SelectedValue) >= Convert.ToInt32(cmbTimeEndMin.SelectedValue)))
            {
                MessageBox.Show("Free Time End Minutes must be greater than Start time", "Free Time", MessageBoxButton.OK, MessageBoxImage.Warning);
                cmbTimeEndMin.Focus();
                return false;
            }

            else if (cbmaxlecperday.SelectedValue.ToString() == "Select")
            {
                MessageBox.Show("Please Select Max Lecture in Day", "Max Lecuture in a Day", MessageBoxButton.OK, MessageBoxImage.Warning);
                cbmaxlecperday.Focus();
                return false;
            }
            else if (cbmaxlecperweek.SelectedValue.ToString() == "Select")
            {
                MessageBox.Show("Please Select Max Lecture in Week", "Max Lecuture in a Week", MessageBoxButton.OK, MessageBoxImage.Warning);
                cbmaxlecperweek.Focus();
                return false;
            }
            else if (Convert.ToInt32(cbmaxlecperweek.SelectedValue) < Convert.ToInt32(cbmaxlecperday.SelectedValue))
            {
                MessageBox.Show("Please Enter Max Lect/Week Greater than Lect/Day", "Max Lecuture in a Week", MessageBoxButton.OK, MessageBoxImage.Warning);
                cbmaxlecperweek.Focus();
                return false;
            }
            else if (cbmaxlectperrow.SelectedValue.ToString() == "Select")
            {
                MessageBox.Show("Please Select Max Lecture in Row", "Max Lecuture in a Row", MessageBoxButton.OK, MessageBoxImage.Warning);
                cbmaxlectperrow.Focus();
                return false;
            }
            else if (cballowlect.SelectedValue.ToString() == "Select")
            {
                MessageBox.Show("Please Select Is allow more than 1 Lect", "Is Allow Lect", MessageBoxButton.OK, MessageBoxImage.Warning);
                cballowlect.Focus();
                return false;
            }
            
            //Batch Availabity validate
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
                                        if (daycheckcount < 0)
                                        {
                                            return true;
                                        }
                                        if (daycheckcount > 0)
                                        { return true; }
                                        else
                                        {
                                            if (btnadd.Content.ToString() == "Save")
                                            {
                                                MessageBox.Show("Select At Least One Day.");
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


        #region-------------------------------------------BindTimingHrs---------------------------------
        private void TimingHrs()
        {
            cmbTimeStartHrs.Items.Clear();
            cmbTimeEndHrs.Items.Clear();

            cmbTimeStartHrs.Items.Add("Hours");
            cmbTimeEndHrs.Items.Add("Hours");
            int i;
            for (i = 1; i <= 24; i++)
            {
                if (i < 10)
                {
                    cmbTimeStartHrs.Items.Add(n + i.ToString());
                    cmbTimeEndHrs.Items.Add(n + i.ToString());
                }
                else
                {
                    cmbTimeStartHrs.Items.Add(i.ToString());
                    cmbTimeEndHrs.Items.Add(i.ToString());
                }

            }

            cmbTimeStartHrs.SelectedIndex = 0;
            cmbTimeEndHrs.SelectedIndex = 0;

        }
        #endregion

        #region-------------------------------------------BindTimingMins---------------------------------
        private void TimingMin()
        {
            cmbTimeStartMin.Items.Add("Min");
            cmbTimeEndMin.Items.Add("Min");
            int i;
            for (i = 0; i <= 59; i = i + 5)
            {
                if (i < 10)
                {
                    cmbTimeStartMin.Items.Add(n + i.ToString());
                    cmbTimeEndMin.Items.Add(n + i.ToString());
                }
                else
                {
                    cmbTimeStartMin.Items.Add(i);
                    cmbTimeEndMin.Items.Add(i);
                }

            }
            cmbTimeStartMin.SelectedIndex = 0;
            cmbTimeEndMin.SelectedIndex = 0;

        }
        #endregion

        #region-------------------------------------------MaxLectPerDay---------------------------------
        private void MaxLectPerDay()
        {
            cbmaxlecperday.Items.Add("Select");
            int i;
            for (i = 1; i <= 6; i++)
            {
                cbmaxlecperday.Items.Add(i);
            }
            cbmaxlecperday.SelectedIndex = 0;
        }
        #endregion

        #region-------------------------------------------MaxLectInRow---------------------------------
        private void MaxLectInRow()
        {
            cbmaxlectperrow.Items.Add("Select");
            int i;
            for (i = 1; i <= 6; i++)
            {
                cbmaxlectperrow.Items.Add(i);
            }
            cbmaxlectperrow.SelectedIndex = 0;
        }
        #endregion

        #region-------------------------------------------MaxLectPerWeek---------------------------------
        private void MaxLectPerWeek1()
        {
            cbmaxlecperweek.Items.Add("Select");
            int i;
            for (i = 1; i <= 30; i++)
            {
                cbmaxlecperweek.Items.Add(i);
            }
            cbmaxlecperweek.SelectedIndex = 0;
        }
        #endregion

        #region-------------------------------------------BindYesNo---------------------------------
        private void BindYesNo()
        {
            cbLunchBreak.Items.Clear();
            cbLunchBreak.Items.Add("Select");
            cbLunchBreak.Items.Add("Yes");
            cbLunchBreak.Items.Add("No");
            cbLunchBreak.SelectedIndex = 0;

            cballowlect.Items.Clear();
            cballowlect.Items.Add("Select");
            cballowlect.Items.Add("Yes");
            cballowlect.Items.Add("No");
            cballowlect.SelectedIndex = 0;
        }
        #endregion

        #region--------------------select()-------------------
        private void select()
        {
            cmbTimeStartHrs.SelectedIndex = 0;
            cmbTimeStartMin.SelectedIndex = 0;
            cmbTimeEndHrs.SelectedIndex = 0;
            cmbTimeEndMin.SelectedIndex = 0;
            cbmaxlecperday.SelectedIndex = 0;
            cbmaxlecperweek.SelectedIndex = 0;
            cbmaxlectperrow.SelectedIndex = 0;
            cbClassName.SelectedIndex = 0;
        }
        #endregion

        #region----------------------txtBatchName_TextChanged----------------------------
        private void txtBatchName_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (txtBatchName.Text != "")
                {
                    if (txtBatchName.Text.Length > 0 && txtBatchName.Text.Length == 1)
                    {
                        if (System.Text.RegularExpressions.Regex.IsMatch(txtBatchName.Text, "^[a-zA-Z]+$"))
                        {
                        }
                        else
                        {
                            MessageBox.Show("Please Enter First Characerter Alphabate", "Batch Name", MessageBoxButton.OK, MessageBoxImage.Warning);
                            txtBatchName.Text = "";
                            txtBatchName.Focus();
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

        #region----------------------------------grvBatchBind------------------------------
        private void BindGridview()
        {
            DataSet ds = obj_Batch.BindBatch(0, txtBatchName.Text);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dgvBatch.ItemsSource = ds.Tables[0].DefaultView;
            }
            else
            {
                dgvBatch.ItemsSource = null;
                //MessageBox.Show("Data Not Found", "Message");
            }
            dgvBatch.Items.Refresh();
        }
        #endregion

        #region--------------------------------------Delete button click()-------------------------------------
        private void btndelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult Result = MessageBox.Show("Do You Really Want To Delete?", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (Result.Equals(MessageBoxResult.Yes))
                {
                    SetParameters();
                    DeleteBatch();

                    BindGridview();

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion

        #region----------------------------DeleteBatch()----------------------------------
        private void DeleteBatch()
        {
            if (UpID != 0)
            {
                ClassID = UpID;

                string Result = obj_Batch.DeleteBatch(BatchID, UpdatedByUserID, UpdatedDate);
                if (Result == "Deleted Sucessfully...!!")
                {
                    MessageBox.Show(Result, "Delete Sucessfully", MessageBoxButton.OK, MessageBoxImage.Information);

                    clearFields();
                    BindGridview();
                }
                else
                {
                    MessageBox.Show(Result, "Error To Delete", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please Select Batch From Batch", "Delete Error", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
        }
        #endregion

        #region------------------------btnSearch_Click----------------------
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    if (!string.IsNullOrEmpty(txtSearchBatch.Text.Trim()))
            //    {
            //        DataSet ds = obj_Batch.SearchBatch(txtSearchBatch.Text);
            //        if (ds.Tables[0].Rows.Count > 0)
            //        {
            //            dgvBatch.ItemsSource = ds.Tables[0].DefaultView;
            //        }
            //        else
            //        {
            //            dgvBatch.ItemsSource = null;
            //            MessageBox.Show("No Data Available");
            //            clearFields();
            //        }

            //    }
            //    else
            //    {
            //        MessageBox.Show("Please Enter Batch Name", "Message", MessageBoxButton.OK, MessageBoxImage.Warning);
            //        txtSearchBatch.Focus();

            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message.ToString());
            //}
        }

        #endregion
        #region-----------------------Window_Loaded()-------------------------------------------------------
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            try
            {
                
                clearFields();
                BindClassName();
                btnDelete.IsEnabled = false;
                BindYesNo();
                if (cmbTimeStartHrs.SelectedValue.ToString() == "Select")
                {
                    cmbTimeStartHrs.IsEnabled = false;
                    cmbTimeStartMin.IsEnabled = false;
                    cmbTimeEndHrs.IsEnabled = false;
                    cmbTimeEndMin.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion

        #region------------------------BindClassName()---------------------------------------
        private void BindClassName()
        {


            try
            {
                DataSet ds = obj_Class.loadClassName();


                if (ds.Tables[0].Rows.Count > 0)
                {
                    cbClassName.DataContext = ds.Tables[0].DefaultView;
                    cbClassName.DisplayMemberPath = ds.Tables[0].Columns["ClassName"].ToString();
                    cbClassName.SelectedValuePath = ds.Tables[0].Columns["ClassID"].ToString();

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
        #endregion

        #region--------------------------------------gridview cell click()-------------------------------------
        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                object item = dgvBatch.SelectedItem;
                // UpID = Convert.ToInt32(((System.Data.DataRowView)(dgvBatch.CurrentItem)).Row.ItemArray[0].ToString());                  
                string ClassName = (dgvBatch.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                string BatchName = (dgvBatch.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                string BatchCode = (dgvBatch.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                UpID = Convert.ToInt32(((System.Data.DataRowView)(dgvBatch.CurrentItem)).Row.ItemArray[1].ToString());
                Clears();
                GetBatchAvailableDetails(UpID);
               

                DataSet ds = obj_Batch.GetBatchDetail(BatchName, BatchCode);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        UpID = Convert.ToInt32(ds.Tables[0].Rows[0]["BatchID"]);
                        cbClassName.Text = ds.Tables[0].Rows[0]["ClassName"].ToString();
                        txtBatchName.Text = ds.Tables[0].Rows[0]["BatchName"].ToString();
                        txtBatchCode.Text = ds.Tables[0].Rows[0]["BatchCode"].ToString();

                        txtlecDuration.Text = ds.Tables[0].Rows[0]["LectureDuration"].ToString();
                        string StartTime = ds.Tables[0].Rows[0]["LunchBreakStartTime"].ToString();
                        string[] a = StartTime.Split(':');
                        cmbTimeStartHrs.Text = a[0];
                        {
                            cmbTimeStartMin.Text = a[1];
                        }
                        string EndTime = ds.Tables[0].Rows[0]["LunchBreakEndTime"].ToString();
                        string[] b = EndTime.Split(':');
                        cmbTimeEndHrs.Text = b[0];
                        {
                            cmbTimeEndMin.Text = b[1];
                        }
                        cbmaxlecperday.Text = ds.Tables[0].Rows[0]["MaxNoLecturesDay"].ToString();
                        cbLunchBreak.Text = ds.Tables[0].Rows[0]["IsLunchBreak"].ToString();
                        if (cbLunchBreak.Text == "True")
                        {
                            cbLunchBreak.Text = "Yes";
                        }
                        else if (cbLunchBreak.Text == "False")
                        {
                            cbLunchBreak.Text = "No";
                        }
                        cbmaxlecperweek.Text = ds.Tables[0].Rows[0]["MaxNoLecturesWeek"].ToString();

                        //chkallow.Unchecked = ds.Tables[0].Rows[0]["IsAllowMoreThanOneLectInBatch"].ToString();
                        cbmaxlectperrow.Text = ds.Tables[0].Rows[0]["MaxNoOfLecureInRow"].ToString();
                        cballowlect.Text = ds.Tables[0].Rows[0]["IsAllowMoreThanOneLectInBatch"].ToString();
                        if (cballowlect.Text == "True")
                        {
                            cballowlect.Text = "Yes";
                        }
                        else if (cballowlect.Text == "False")
                        {
                            cballowlect.Text = "No";
                        }

                        //cbClassName.Text = ds.Tables[0].Rows[0]["ClassID"].ToString();
                        int act = Convert.ToInt32(ds.Tables[0].Rows[0]["IsActive"]);
                        int del = Convert.ToInt32(ds.Tables[0].Rows[0]["IsDeleted"]);
                        int lunchbreak = Convert.ToInt32(ds.Tables[0].Rows[0]["IsLunchBreak"]);
                        int Isallow = Convert.ToInt32(ds.Tables[0].Rows[0]["IsAllowMoreThanOneLectInBatch"]);
                        if (act == 1 && del == 0)
                        {
                            rdoActive.IsChecked = true;
                        }
                        else if (act == 0 && del == 0)
                        {
                            rdoDeActive.IsChecked = true;
                        }
                        if (cbLunchBreak.Text == "Yes")
                        {
                            cmbTimeStartHrs.IsEnabled = true;
                            cmbTimeStartMin.IsEnabled = true;
                            cmbTimeEndHrs.IsEnabled = true;
                            cmbTimeEndMin.IsEnabled = true;
                        }
                        else if (cbLunchBreak.Text == "No")
                        {
                            cmbTimeStartHrs.IsEnabled = false;
                            cmbTimeStartMin.IsEnabled = false;
                            cmbTimeEndHrs.IsEnabled = false;
                            cmbTimeEndMin.IsEnabled = false;
                        }

                        //BatchAvail
                        btnDelete.IsEnabled = true;
                        btnadd.Content = "Update";
                       
                       
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion

        #region-------------------------------------------txtBatchCode_textChanged-----------------------------
        private void txtBatchCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (txtBatchCode.Text != "")
                {
                    if (txtBatchCode.Text.Length > 0 && txtBatchCode.Text.Length == 1)
                    {
                        if (System.Text.RegularExpressions.Regex.IsMatch(txtBatchCode.Text, "^[a-zA-Z]"))
                        {
                        }
                        else
                        {
                            MessageBox.Show("Please Enter First Characerter Alphabate", "Batch Code", MessageBoxButton.OK, MessageBoxImage.Warning);
                            txtBatchCode.Text = "";
                            txtBatchCode.Focus();
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

        #region---------------------------txtlecDuration_TextChanged-----------------------
        private void txtlecDuration_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (txtlecDuration.Text != "")
                {
                    if (txtlecDuration.Text.Length > 0)
                    {
                        if (System.Text.RegularExpressions.Regex.IsMatch(txtlecDuration.Text, "^[0-9]+$"))
                        {
                        }
                        else
                        {
                            MessageBox.Show("Please Enter Only Numbers", "Lect. Duration", MessageBoxButton.OK, MessageBoxImage.Warning);
                            txtlecDuration.Text = "";
                            txtlecDuration.Focus();
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

        #region---------------------------------------cbLunchBreak_SelectionChanged----------------------------
        private void cbLunchBreak_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                if (cbLunchBreak.SelectedIndex == 2)
                {
                    cmbTimeStartHrs.IsEnabled = false;
                    cmbTimeStartMin.IsEnabled = false;
                    cmbTimeEndHrs.IsEnabled = false;
                    cmbTimeEndMin.IsEnabled = false;
                    cmbTimeStartHrs.SelectedIndex = 0;
                    cmbTimeStartMin.SelectedIndex = 0;
                    cmbTimeEndHrs.SelectedIndex = 0;
                    cmbTimeEndMin.SelectedIndex = 0;
                }
                else if (cbLunchBreak.SelectedIndex == 1)
                {
                    cmbTimeStartHrs.IsEnabled = true;
                    cmbTimeStartMin.IsEnabled = true;
                    cmbTimeEndHrs.IsEnabled = true;
                    cmbTimeEndMin.IsEnabled = true;
                }

                else if (cbLunchBreak.SelectedIndex == 0)
                {
                    cmbTimeStartHrs.IsEnabled = false;
                    cmbTimeStartMin.IsEnabled = false;
                    cmbTimeEndHrs.IsEnabled = false;
                    cmbTimeEndMin.IsEnabled = false;
                    cmbTimeStartHrs.SelectedIndex = 0;
                    cmbTimeStartMin.SelectedIndex = 0;
                    cmbTimeEndHrs.SelectedIndex = 0;
                    cmbTimeEndMin.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString(), "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
        #endregion
        /*
         * Created By:- 
         * Ctreated Date :- 
         * StartTime:-PM
         * EndTime:-PM
         * Purpose:- 
         */
        #region-------------------------txtlecDuration_KeyDown---------------------------------------------------------
        private void txtlecDuration_KeyDown(object sender, KeyEventArgs e)
        {
            //if (!Char.IsDigit((char)KeyInterop.VirtualKeyFromKey(e.Key)) & e.Key != Key.Back | e.Key == Key.Space)
            //{
            //    e.Handled = true;
            //    MessageBox.Show("Please Enter Only Numbers", "Lecture Duration", MessageBoxButton.OK, MessageBoxImage.Warning);
            //}
        }
        #endregion

       
        #region--------------------------btncancel_Click-----------------------------
        private void btncancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                clearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion

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

        #region-----------------------CheckSameTime--------------------------------------------------------------
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

            chkMon.IsEnabled = true;
            chkTue.IsEnabled = true;
            chkWed.IsEnabled = true;
            chkThru.IsEnabled = true;
            chkFri.IsEnabled = true;
            chkSat.IsEnabled = true;
            chkSun.IsEnabled = true;

            chkMon.IsChecked = false;
            chkTue.IsChecked = false;
            chkWed.IsChecked = false;
            chkThru.IsChecked = false;
            chkFri.IsChecked = false;
            chkSat.IsChecked = false;
            chkSun.IsChecked = false;
        }
        #endregion

        #region----------------------------------------------------------------EnableDropdown()------------------------------------------------
        private void EnableFalseDropdown()
        {
            gbSameTime.Visibility = Visibility.Hidden;

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
            
            chkMon.IsEnabled = false;
            chkTue.IsEnabled = false;
            chkWed.IsEnabled = false;
            chkThru.IsEnabled = false;
            chkFri.IsEnabled = false;
            chkSat.IsEnabled = false;
            chkSun.IsEnabled = false;

            chkMon.IsChecked= true;
            chkTue.IsChecked = true;
            chkWed.IsChecked = true;
            chkThru.IsChecked = true;
            chkFri.IsChecked = true;
            chkSat.IsChecked = true;
            chkSun.IsChecked = true;
        }
        #endregion
        #region------------------chkEndhrs_SelectionChanged-----------------
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

                 
        #region-----------------chkStartHrs_SelectionChanged-------------------------
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

        #region------------------chkStartMin_SelectionChanged--------------------
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

        
                       
        #region--------------EndMin_SelectionChanged--------------
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
        #region-------------------------------------------------cbLunchBreak_SelectionChanged_1-------------------------
        private void cbLunchBreak_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cbLunchBreak.SelectedIndex == 2)
                {
                    cmbTimeStartHrs.IsEnabled = false;
                    cmbTimeStartMin.IsEnabled = false;
                    cmbTimeEndHrs.IsEnabled = false;
                    cmbTimeEndMin.IsEnabled = false;
                    cmbTimeStartHrs.SelectedIndex = 0;
                    cmbTimeStartMin.SelectedIndex = 0;
                    cmbTimeEndHrs.SelectedIndex = 0;
                    cmbTimeEndMin.SelectedIndex = 0;
                }
                else if (cbLunchBreak.SelectedIndex == 1)
                {
                    cmbTimeStartHrs.IsEnabled = true;
                    cmbTimeStartMin.IsEnabled = true;
                    cmbTimeEndHrs.IsEnabled = true;
                    cmbTimeEndMin.IsEnabled = true;
                }

                else if (cbLunchBreak.SelectedIndex == 0)
                {
                    cmbTimeStartHrs.IsEnabled = false;
                    cmbTimeStartMin.IsEnabled = false;
                    cmbTimeEndHrs.IsEnabled = false;
                    cmbTimeEndMin.IsEnabled = false;
                    cmbTimeStartHrs.SelectedIndex = 0;
                    cmbTimeStartMin.SelectedIndex = 0;
                    cmbTimeEndHrs.SelectedIndex = 0;
                    cmbTimeEndMin.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString(), "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
        #endregion

        #region----------------------------------------btnadd_Click----------------------------------------------
        private void btnadd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Validate())
                {
                    SetParameters();
                    //SaveDetails();
                   result1 = obj_Batch.saveBatch(BatchID, ClassID, BatchName, BatchCode, LectureDuration, IsLunchBreak, LunchBreakStartTime, LunchBreakEndTime, MaxNoLecturesDay, MaxNoLecturesWeek, IsAllowMoreThanOneLectInBatch, MaxNoOfLecureInRow, UpdatedByUserID, UpdatedDate, IsActive, IsDeleted);
                    SetParametersForAvailability();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion
        #region--------------------------------------SaveDetails()-------------------------------------
        private void SaveDetails()
        {
            //string result = obj_Batch.saveBatch(BatchID, ClassID, BatchName, BatchCode, LectureDuration, IsLunchBreak, LunchBreakStartTime, LunchBreakEndTime, MaxNoLecturesDay, MaxNoLecturesWeek, IsAllowMoreThanOneLectInBatch, MaxNoOfLecureInRow, UpdatedByUserID, UpdatedDate, IsActive, IsDeleted);
            //if (result == "Save Sucessfully...!!!" || result == "Updated Sucessfully...!!!")
            //{
            //    //MessageBox.Show(result, "Save SucessFull", MessageBoxButton.OK, MessageBoxImage.Information);
            //    //clearFields();
            //    ResultCount = 0;
            //    if (result == "Save Sucessfully...!!!")
            //    {
            //        MaxBatchID = objBatch.GetMaxBatchID();
            //    }
            //}
            //else
            //{
            //    MessageBox.Show(result, "Error To Save", MessageBoxButton.OK, MessageBoxImage.Warning);
            //}
        }
        #endregion       


        #region-------------------------------------------------------SetParametersForAvailability()-------------------------------------------------------
        private void SetParametersForAvailability()
        {
            ResultCount = 0;
            if (chkMon.IsChecked == true)
            {
                
                BatchID = result1;
                Day = chkMon.Content.ToString();
                FinalStartTime = chkStartHrs1.Text + ":";
                FinalStartTime += chkStartMin1.Text;
                FinalEndTime = chkEndhrs1.Text + ":";
                FinalEndTime += EndMin1.Text;
                IsActive = 1;
                IsDeleted = 0;
                UpdatedDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
                UpdatedByUserID = 1;
                Result = objBatch.SaveBatchAvailibility(BatchID, Day, FinalStartTime, FinalEndTime, UpdatedByUserID, UpdatedDate, IsActive, IsDeleted);
                if ((Result == "Save Sucessfully...!!!") || (Result == "Updated Sucessfully...!!!"))
                {
                    ResultCount++;
                }
            }
            else if (chkMon.IsChecked == false)
            {
                BatchID = result1;
                Day = chkMon.Content.ToString();
                FinalStartTime = "00:00:00";
                FinalEndTime = "00:00:00";
                IsActive = 0;
                IsDeleted = 0;
                UpdatedDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
                UpdatedByUserID = 1;
                Result = objBatch.SaveBatchAvailibility(BatchID, Day, FinalStartTime, FinalEndTime, UpdatedByUserID, UpdatedDate, IsActive, IsDeleted);
                if ((Result == "Save Sucessfully...!!!") || (Result == "Updated Sucessfully...!!!"))
                {
                    ResultCount++;
                }

            }
            if (chkTue.IsChecked == true)
            {
                BatchID = result1;
                Day = chkTue.Content.ToString();
                FinalStartTime = chkStartHrs2.Text + ":";
                FinalStartTime += chkStartMin2.Text;
                FinalEndTime = chkEndhrs2.Text + ":";
                FinalEndTime += EndMin2.Text;
                IsActive = 1;
                IsDeleted = 0;
                UpdatedDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
                UpdatedByUserID = 1;
                Result = objBatch.SaveBatchAvailibility(BatchID, Day, FinalStartTime, FinalEndTime, UpdatedByUserID, UpdatedDate, IsActive, IsDeleted);
                if ((Result == "Save Sucessfully...!!!") || (Result == "Updated Sucessfully...!!!"))
                {
                    ResultCount++;
                }
            }
            else if (chkTue.IsChecked == false)
            {
                BatchID = result1;
                Day = chkTue.Content.ToString();
                FinalStartTime = "00:00:00";
                FinalEndTime = "00:00:00";
                IsActive = 0;
                IsDeleted = 0;
                UpdatedDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
                UpdatedByUserID = 1;
                Result = objBatch.SaveBatchAvailibility(BatchID, Day, FinalStartTime, FinalEndTime, UpdatedByUserID, UpdatedDate, IsActive, IsDeleted);
                if ((Result == "Save Sucessfully...!!!") || (Result == "Updated Sucessfully...!!!"))
                {
                    ResultCount++;
                }

            }
            if (chkWed.IsChecked == true)
            {
                BatchID = result1;
                Day = chkWed.Content.ToString();
                FinalStartTime = chkStartHrs3.Text + ":";
                FinalStartTime += chkStartMin3.Text;
                FinalEndTime = chkEndhrs3.Text + ":";
                FinalEndTime += EndMin3.Text;
                IsActive = 1;
                IsDeleted = 0;
                UpdatedDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
                UpdatedByUserID = 1;
                Result = objBatch.SaveBatchAvailibility(BatchID, Day, FinalStartTime, FinalEndTime, UpdatedByUserID, UpdatedDate, IsActive, IsDeleted);

                if ((Result == "Save Sucessfully...!!!") || (Result == "Updated Sucessfully...!!!"))
                {
                    ResultCount++;
                }
            }
            else if (chkWed.IsChecked == false)
            {
                BatchID = result1;
                Day = chkWed.Content.ToString();
                FinalStartTime = "00:00:00";
                FinalEndTime = "00:00:00";
                IsActive = 0;
                IsDeleted = 0;
                UpdatedDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
                UpdatedByUserID = 1;
                Result = objBatch.SaveBatchAvailibility(BatchID, Day, FinalStartTime, FinalEndTime, UpdatedByUserID, UpdatedDate, IsActive, IsDeleted);

                if ((Result == "Save Sucessfully...!!!") || (Result == "Updated Sucessfully...!!!"))
                {
                    ResultCount++;
                }

            }
            if (chkThru.IsChecked == true)
            {
                BatchID = result1;
                Day = chkThru.Content.ToString();
                FinalStartTime = chkStartHrs4.Text + ":";
                FinalStartTime += chkStartMin4.Text;
                FinalEndTime = chkEndhrs4.Text + ":";
                FinalEndTime += EndMin4.Text;
                IsActive = 1;
                IsDeleted = 0;
                UpdatedDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
                UpdatedByUserID = 1;
                Result = objBatch.SaveBatchAvailibility(BatchID, Day, FinalStartTime, FinalEndTime, UpdatedByUserID, UpdatedDate, IsActive, IsDeleted);

                if ((Result == "Save Sucessfully...!!!") || (Result == "Updated Sucessfully...!!!"))
                {
                    ResultCount++;
                }
            }
            else if (chkThru.IsChecked == false)
            {
                BatchID = result1;
                Day = chkThru.Content.ToString();
                FinalStartTime = "00:00:00";
                FinalEndTime = "00:00:00";
                IsActive = 0;
                IsDeleted = 0;
                UpdatedDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
                UpdatedByUserID = 1;
                Result = objBatch.SaveBatchAvailibility(BatchID, Day, FinalStartTime, FinalEndTime, UpdatedByUserID, UpdatedDate, IsActive, IsDeleted);

                if ((Result == "Save Sucessfully...!!!") || (Result == "Updated Sucessfully...!!!"))
                {
                    ResultCount++;
                }

            }
            if (chkFri.IsChecked == true)
            {
                BatchID = result1;
                Day = chkFri.Content.ToString();
                FinalStartTime = chkStartHrs5.Text + ":";
                FinalStartTime += chkStartMin5.Text;
                FinalEndTime = chkEndhrs5.Text + ":";
                FinalEndTime += EndMin5.Text;
                IsActive = 1;
                IsDeleted = 0;
                UpdatedDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
                UpdatedByUserID = 1;
                Result = objBatch.SaveBatchAvailibility(BatchID, Day, FinalStartTime, FinalEndTime, UpdatedByUserID, UpdatedDate, IsActive, IsDeleted);

                if ((Result == "Save Sucessfully...!!!") || (Result == "Updated Sucessfully...!!!"))
                {
                    ResultCount++;
                }
            }
            else if (chkFri.IsChecked == false)
            {
                BatchID = result1;
                Day = chkFri.Content.ToString();
                FinalStartTime = "00:00:00";
                FinalEndTime = "00:00:00";
                IsActive = 0;
                IsDeleted = 0;
                UpdatedDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
                UpdatedByUserID = 1;
                Result = objBatch.SaveBatchAvailibility(BatchID, Day, FinalStartTime, FinalEndTime, UpdatedByUserID, UpdatedDate, IsActive, IsDeleted);

                if ((Result == "Save Sucessfully...!!!") || (Result == "Updated Sucessfully...!!!"))
                {
                    ResultCount++;
                }

            }
            if (chkSat.IsChecked == true)
            {
                BatchID = result1;
                Day = chkSat.Content.ToString();
                FinalStartTime = chkStartHrs6.Text + ":";
                FinalStartTime += chkStartMin6.Text;
                FinalEndTime = chkEndhrs6.Text + ":";
                FinalEndTime += EndMin6.Text;
                IsActive = 1;
                IsDeleted = 0;
                UpdatedDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
                UpdatedByUserID = 1;
                Result = objBatch.SaveBatchAvailibility(BatchID, Day, FinalStartTime, FinalEndTime, UpdatedByUserID, UpdatedDate, IsActive, IsDeleted);

                if ((Result == "Save Sucessfully...!!!") || (Result == "Updated Sucessfully...!!!"))
                {
                    ResultCount++;
                }
            }
            else if (chkSat.IsChecked == false)
            {
                BatchID = result1;
                Day = chkSat.Content.ToString();
                FinalStartTime = "00:00:00";
                FinalEndTime = "00:00:00";
                IsActive = 0;
                IsDeleted = 0;
                UpdatedDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
                UpdatedByUserID = 1;
                Result = objBatch.SaveBatchAvailibility(BatchID, Day, FinalStartTime, FinalEndTime, UpdatedByUserID, UpdatedDate, IsActive, IsDeleted);

                if ((Result == "Save Sucessfully...!!!") || (Result == "Updated Sucessfully...!!!"))
                {
                    ResultCount++;
                }

            }
            if (chkSun.IsChecked == true)
            {
                BatchID = result1;
                Day = chkSun.Content.ToString();
                FinalStartTime = chkStartHrs7.Text + ":";
                FinalStartTime += chkStartMin7.Text;
                FinalEndTime = chkEndhrs7.Text + ":";
                FinalEndTime += EndMin7.Text;
                IsActive = 1;
                IsDeleted = 0;
                UpdatedDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
                UpdatedByUserID = 1;
                Result = objBatch.SaveBatchAvailibility(BatchID, Day, FinalStartTime, FinalEndTime, UpdatedByUserID, UpdatedDate, IsActive, IsDeleted);

                if ((Result == "Save Sucessfully...!!!") || (Result == "Updated Sucessfully...!!!"))
                {
                    ResultCount++;
                }
            }
            else if (chkSun.IsChecked == false)
            {
                BatchID = result1;
                Day = chkSun.Content.ToString();
                FinalStartTime = "00:00:00";
                FinalEndTime = "00:00:00";
                IsActive = 0;
                IsDeleted = 0;
                UpdatedDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
                UpdatedByUserID = 1;
                Result = objBatch.SaveBatchAvailibility(BatchID, Day, FinalStartTime, FinalEndTime, UpdatedByUserID, UpdatedDate, IsActive, IsDeleted);
                if ((Result == "Save Sucessfully...!!!") || (Result == "Updated Sucessfully...!!!"))
                {
                    ResultCount++;
                }
            }
            if (ResultCount == 7)
            {
                if (btnadd.Content.ToString() == "Save")
                {
                    MessageBox.Show("Batch Details Save Sucessfully", "Save Sucessfull", MessageBoxButton.OK, MessageBoxImage.Information);
                    clearFields();
                }
                else if (btnadd.Content.ToString() == "Update")
                {
                    MessageBox.Show("Batch Details Update Sucessfully", "Update Sucessfull", MessageBoxButton.OK, MessageBoxImage.Information);
                    clearFields();
                }
            }

        }
        #endregion

        #region-----------------------------------------chkAvailSameTime_Click----------------------------------------------------
        private void chkAvailSameTime_Click_1(object sender, RoutedEventArgs e)
        {
            if (chkAvailSameTime.IsChecked == true)
            {
                EnableFalseDropdown();
                gbSameTime.Visibility = Visibility.Visible;
                
            }
            else
            {
                EnableDropdown();
                gbSameTime.Visibility = Visibility.Hidden;
                
            }
        }
        #endregion
        #region---------------------------------------------------Chkallday------------------------------------------------
        private void chkAvailAllDay_Click_1(object sender, RoutedEventArgs e)
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

        #region---------------------------------------------------ChkMon------------------------------------------------
        private void chkMon_Click_1(object sender, RoutedEventArgs e)
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

        #region---------------------------------------------------ChkTue------------------------------------------------
        private void chkTue_Click_1(object sender, RoutedEventArgs e)
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

        #region---------------------------------------------------Chkwed------------------------------------------------
        private void chkWed_Click_1(object sender, RoutedEventArgs e)
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

        #region---------------------------------------------------ChkThru------------------------------------------------
        private void chkThru_Click_1(object sender, RoutedEventArgs e)
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

        #region---------------------------------------------------ChkFri------------------------------------------------
        private void chkFri_Click_1(object sender, RoutedEventArgs e)
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

        #region---------------------------------------------------ChkSat------------------------------------------------
        private void chkSat_Click_1(object sender, RoutedEventArgs e)
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

        #region---------------------------------------------------ChkSun------------------------------------------------
        private void chkSun_Click_1(object sender, RoutedEventArgs e)
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

        /* Created By:- Sameer Shinde
       * Created Date :- 11 Dec 2015
       * Purpose:- GetBatchAvailable Details*/

        #region---------------------------------------------------------GetBatchAvailableDetails()-------------------------------------------
        private void GetBatchAvailableDetails(int numId)
        {
            cnn = 0;
                DataSet ds = objBatch.GetBatchAvailableDetail(numId);
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
                            chkStartHrs.Text = StartTime[0].ToString();
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
                    //if (numId == Convert.ToInt32(cmbBatch.SelectedValue))
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
                    MessageBox.Show("Details Are Not Availble This is First Entry For This Batch", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            

        }
        #endregion

        #region--------------------------------------btnCopy_Click--------------------------------------------
        private void btnCopy_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                if (cbClassName.SelectedValue.ToString() != "0" && cbClassName.SelectedItem.ToString() != "Select")
                {
                    if (dgBatchAvail.SelectedItems.Count ==1)
                    {
                        for (int i = 0; i < dgBatchAvail.SelectedItems.Count; i++)
                        {
                            
                            System.Data.DataRowView selectedFile = (System.Data.DataRowView)dgBatchAvail.SelectedItems[i];
                            BatchID = Convert.ToInt32(selectedFile.Row.ItemArray[0]);
                            Clears();
                            GetBatchAvailableDetails(BatchID);                       
                                                      
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("Please Select Row From Grid", "Info", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Please Select Class Name First", "Info", MessageBoxButton.OK, MessageBoxImage.Warning);
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
