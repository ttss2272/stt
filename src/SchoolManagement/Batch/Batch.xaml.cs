﻿using System;
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
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace SchoolManagement.Batch
{
    /// <summary>
    /// Interaction logic for Batch.xaml
    /// </summary>
    public partial class Batch : Window
    {

        /*
     * Created By:- Pravin
     * Ctreated Date :- 4 Nov 2015
     * StartTime:-3:20PM
     * EndTime:-
     * Purpose:- Declare Global Variables
     */
        #region------------------------Declare Variables Globally()--------------------
        int BatchID, UpdatedByUserID, IsActive, IsDeleted, ClassID, UpID, LectureDuration, IsLunchBreak, MaxNoLecturesDay, MaxNoLecturesWeek, IsAllowMoreThanOneLectInBatch, MaxNoOfLecureInRow;
        string BatchName, BatchCode, UpdatedDate, LunchBreakStartTime, LunchBreakEndTime ,n="0",m="1";

        BLBatch obj_Batch = new BLBatch();
        BLAddClass obj_Class = new BLAddClass();

        #endregion
        /*
     * Created By:- 
     * Ctreated Date :- 
     * StartTime:-
     * EndTime:-
     * Purpose:- 
     */
        #region---------------------------------main()--------------------------------------------
        public Batch()
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
        /*
     * Created By:- Pravin
     * Ctreated Date :- 5 Nov 2015
     * StartTime:-3:32PM
     * EndTime:-3:34PM
     * Purpose Save button code
     */
        #region----------------------------------------btnAdd_Click-------------------------------------------
        private void btnadd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Validate())
                {
                    SetParameters();
                    SaveDetails();
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion

        /*
         * Created By:- Pravin
         * Ctreated Date :- 4 Nov 2015
         * StartTime:-PM
         * EndTime:-PM
         * Purpose:- SaveDetails
         */
        #region--------------------------------------SaveDetails()-------------------------------------
        private void SaveDetails()
        {
            string result = obj_Batch.saveBatch(BatchID, ClassID, BatchName, BatchCode, LectureDuration, IsLunchBreak, LunchBreakStartTime, LunchBreakEndTime, MaxNoLecturesDay, MaxNoLecturesWeek, IsAllowMoreThanOneLectInBatch, MaxNoOfLecureInRow,UpdatedByUserID, UpdatedDate, IsActive, IsDeleted);
            if (result == "Save Sucessfully...!!!" || result == "Updated Sucessfully...!!!")
            {
                MessageBox.Show(result, "Save SucessFull", MessageBoxButton.OK, MessageBoxImage.Information);
                clearFields();
            }
            else
            {
                MessageBox.Show(result, "Error To Save", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion                                         

        /*
         * Created By:- Pravin
         * Ctreated Date :- 4 Nov 2015
         * StartTime:-PM
         * EndTime:-PM
         * Purpose:- Close button code
         */
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

        /*
         * Created By:- 
         * Ctreated Date :- 
         * StartTime:-PM
         * EndTime:-PM
         * Purpose:- 
         */
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

        /*
         * CreatedBy:-Pravin
         * Created Date:- 07Nov2015
         * Purpose:-
         * StartTime:-
         * EndTime:-
         */
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

        /*
         * CreatedBy:-Pravin
         * Created Date:- 07Nov2015
         * Purpose:-
         * StartTime:-
         * EndTime:-
         */
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

        /*
         * Created By:- 
         * Ctreated Date :- 
         * StartTime:-PM
         * EndTime:-PM
         * Purpose:- 
         */
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
            if (rdoActive.IsChecked == true && rdoDeActive.IsChecked== false)
            {
                IsActive = 1;
                IsDeleted = 0;
            }
            else if (rdoActive.IsChecked==false && rdoDeActive.IsChecked==true)
            {
                IsActive = 0;
                IsDeleted = 0;
            }
        }
        #endregion

        /*
         * Created By:- Pravin
         * Ctreated Date :- 4 Nov 2015
         * StartTime:-4:00PM
         * EndTime:-4:32 PM
         * Purpose:- validations
         */
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
              else
              {
                  return true;
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

        /*
         * Created By:- 
         * Ctreated Date :- 
         * StartTime:-PM
         * EndTime:-PM
         * Purpose:- 
         */
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

        /*
         * Created By:- 
         * Ctreated Date :- 
         * StartTime:-PM
         * EndTime:-PM
         * Purpose:- 
         */
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

        /*
         * Created By:- 
         * Ctreated Date :- 
         * StartTime:-PM
         * EndTime:-PM
         * Purpose:- 
         */
        #region-----------------------------clearFields()------------------------------------------

        private void clearFields()
        {
            cbClassName.SelectedIndex = 0;
            txtBatchName.Text = "";
            txtBatchCode.Text = "";           
            txtlecDuration.Text = "";
            txtSearchBatch.Text = "";
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
            rdoActive.IsChecked = true ;
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
          


           
        }
        #endregion

        /*
         * Created By:- 
         * Ctreated Date :- 
         * StartTime:-PM
         * EndTime:-PM
         * Purpose:- 
         */
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

        /*
         * Created By:- 
         * Ctreated Date :- 
         * StartTime:-PM
         * EndTime:-PM
         * Purpose:- 
         */
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
                MessageBox.Show("Data Not Found", "Message");
            }
            dgvBatch.Items.Refresh();
        }
        #endregion

        /*
         * Created By:- 
         * Ctreated Date :- 
         * StartTime:-PM
         * EndTime:-PM
         * Purpose:- 
         */

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

        /*
         * Created By:- 
         * Ctreated Date :- 
         * StartTime:-PM
         * EndTime:-PM
         * Purpose:- 
         */
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

        /*
         * Created By:- 
         * Ctreated Date :- 
         * StartTime:-PM
         * EndTime:-PM
         * Purpose:- 
         */
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

        /*
         * Created By:- 
         * Ctreated Date :- 
         * StartTime:-PM
         * EndTime:-PM
         * Purpose:- 
         */
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

        /*
         * Created By:- 
         * Ctreated Date :- 
         * StartTime:-PM
         * EndTime:-PM
         * Purpose:- 
         */
        #region------------------------btnSearch_Click----------------------
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(!string.IsNullOrEmpty(txtSearchBatch.Text.Trim()))
                {
                    DataSet ds = obj_Batch.SearchBatch(txtSearchBatch.Text);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                       dgvBatch.ItemsSource = ds.Tables[0].DefaultView;
                    }
                    else
                    {
                        dgvBatch.ItemsSource = null;
                        MessageBox.Show("No Data Available");
                        clearFields();
                    }

                }
                else
                {
                    MessageBox.Show("Please Enter Batch Name", "Message", MessageBoxButton.OK, MessageBoxImage.Warning);
                    txtSearchBatch.Focus();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
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
        #region---------------------------------Window_Loaded-------------------------------------------
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
        /*
         * Created By:- 
         * Ctreated Date :- 
         * StartTime:-PM
         * EndTime:-PM
         * Purpose:- 
         */
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

        /*
         * Created By:- 
         * Ctreated Date :- 
         * StartTime:-PM
         * EndTime:-PM
         * Purpose:- 
         */
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

        /*
         * Created By:- 
         * Ctreated Date :- 
         * StartTime:-PM
         * EndTime:-PM
         * Purpose:- 
         */
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

        /*
         * Created By:- 
         * Ctreated Date :- 
         * StartTime:-PM
         * EndTime:-PM
         * Purpose:- 
         */
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

    }
}

