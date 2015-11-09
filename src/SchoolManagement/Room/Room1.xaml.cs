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
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
//using System.Windows.Forms;


namespace SchoolManagement.Room
{
    /// <summary>
    /// Interaction logic for Room1.xaml
    /// </summary>
    public partial class Room1 : Window
    {
        BLRoom obj_Room = new BLRoom();
        BLAddBranch obj_Branch = new BLAddBranch();

        int RoomId,Capacity,BranchID,UpdatedByUserID,IsActive,IsDeleted,UpID;
        int IsAllow,MaxLectDay,MaxLectWeek,MaxLectRow,SHr,SMin,EHr,EMin;
        string RoomName, ShortName, Color1, UpdatedDate,Sign=":",n="0";
        DateTime StartTime, EndTime;


        public Room1()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
            this.Width = System.Windows.SystemParameters.PrimaryScreenWidth;
            this.Height = System.Windows.SystemParameters.PrimaryScreenHeight;
            clearFields();

        }

        #region---------------------------Validate()-----------------------------------------
        public bool Validate()
        {

            if (string.IsNullOrEmpty(txtRoomName.Text))
            {
                MessageBox.Show("Please Enter Room Name..");
                txtRoomName.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtShortName.Text))
            {
                MessageBox.Show("Please Enter Short Name..");
                txtShortName.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtColor.Text))
            {
                MessageBox.Show("Please Enter Color Detail..");
                txtColor.Focus();
                return false;
            }
            else if (cmbCapacity.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Room Capacity...");
                cmbCapacity.Focus();
                return false;
            }
            else if (cmbSHr.SelectedIndex == 0 || cmbSMin.SelectedIndex == 0 )
            {
                MessageBox.Show("Please Select start Time...");
                cmbSHr.Focus();
                return false;
            }
            
            else if (cmbEHr.SelectedIndex == 0 || cmbEMin.SelectedIndex == 0 )
            {
                MessageBox.Show("Please Select End Time...");
                cmbEHr.Focus();
                return false;
            }
            else if (cmbBranchName.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select Branch Name...");
                cmbBranchName.Focus();
                return false;
            }
            else if (rdbActive.IsChecked == false && rdbInactive.IsChecked == false)
            {
                MessageBox.Show("Please Select Status...");
                return false;
            }
            else if (chkAllowLect.IsChecked == false )
            {
                MessageBox.Show("Please Select Allow Lectures...");
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region-----------------------Clearfield()------------------------------------
        private void clearFields()
        {
            cmbBranchName.Text = "";
            txtRoomName.Text = "";
            txtShortName.Text = "";
            txtColor.Text = "";
            txtLectDay.Text = "";
            txtLectWeek.Text = "";
            txtLectRow.Text = "";
            rdbActive.IsChecked = false;
            rdbInactive.IsChecked = false;
            chkAllowLect.IsChecked = false;
            btnAdd.Content = "Save";
            cmbCapacity_Items();
            BindFullGrid();
            BindBranchName();
        }
        #endregion

        #region------------------SetParameters---------------------------------------

        private void SetParameters()
        {
            RoomId = UpID;
            RoomName = txtRoomName.Text;
            ShortName = txtShortName.Text;
            Capacity = Convert.ToInt32(cmbCapacity.SelectedValue.ToString());
            Color1 = txtColor.Text;
            BranchID = Convert.ToInt32(cmbBranchName.SelectedValue.ToString());
            UpdatedByUserID = 1;
            UpdatedDate = DateTime.Now.ToString();
            MaxLectDay = Convert.ToInt32(txtLectDay.Text.ToString());
            MaxLectWeek = Convert.ToInt32(txtLectWeek.Text.ToString());
            MaxLectRow = Convert.ToInt32(txtLectRow.Text.ToString());
            SHr = Convert.ToInt32(cmbSHr.SelectedValue.ToString());
            SMin = Convert.ToInt32(cmbSMin.SelectedValue.ToString());
            EHr = Convert.ToInt32(cmbEHr.SelectedValue.ToString());
            EMin = Convert.ToInt32(cmbEMin.SelectedValue.ToString());
            StartTime =Convert.ToDateTime( SHr + Sign + SMin);
            EndTime = Convert.ToDateTime(EHr + Sign + EMin);

            if (rdbActive.IsChecked == true)
            {
                IsActive = 1;
                IsDeleted = 0;

            }
            else if (rdbInactive.IsChecked == true)
            {
                IsActive = 0;
                IsDeleted = 0;

            }
            if (chkAllowLect.IsChecked == true)
                IsAllow = 1;
            else
                IsAllow = 0;
        }
        #endregion


        #region---------------AddRoom()--------------------------------------
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Validate())
                {
                    SetParameters();
                    string Result = obj_Room.saveAddRoom(RoomId, RoomName, ShortName, Color1, Capacity, BranchID, UpdatedByUserID, UpdatedDate, IsActive, IsDeleted,MaxLectDay,MaxLectWeek,MaxLectRow,StartTime,EndTime,IsAllow);
                    if (Result == "Save Sucessfully...!!!" || Result == "Updated Sucessfully...!!!")
                    {
                        MessageBox.Show(Result, "Save SucessFull", MessageBoxButton.OK, MessageBoxImage.Information);
                        clearFields();
                    }
                    else
                    {
                        MessageBox.Show(Result, "Error To Save", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion


        #region----------------------------bindgrid()-----------------------
        private void BindFullGrid()
        {
            try
            {
                DataSet ds = obj_Room.BindFullGrid(0,cmbBranchName.Text,txtRoomName.Text);

               // ds = obj_Room.BindFullGrid(0);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dgRoom.ItemsSource = ds.Tables[0].DefaultView;

                }
                dgRoom.Items.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion


        #region-------------bindbranch()--------------------------------------

        private void BindBranchName()
        {

            try
            {
                DataSet ds = obj_Branch.BindBranchName();


                if (ds.Tables[0].Rows.Count > 0)
                {
                    cmbBranchName.DataContext = ds.Tables[0].DefaultView;
                    cmbBranchName.DisplayMemberPath = ds.Tables[0].Columns["BranchName"].ToString();
                    cmbBranchName.SelectedValuePath = ds.Tables[0].Columns["BranchID"].ToString();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion


        #region-------------LoadCapacity-------------------------------
        private void cmbCapacity_Items()
        {
            cmbCapacity.Items.Add("select");
            int i;
            for (i = 1; i <= 60; i++)
            {
                cmbCapacity.Items.Add(i);

            }
            cmbCapacity.SelectedIndex = 0;

        }
        #endregion

        #region--------------LoadHrMin()-----------------------------------
        private void cmbSHr_Items()
        {
            cmbSHr.Items.Add("select");
            int i;
            for (i = 1; i <= 9; i++)
            {
                cmbSHr.Items.Add(n + i.ToString());

            }
            cmbSHr.Items.Add("10");
            cmbSHr.Items.Add("11");
            cmbSHr.Items.Add("12");
            cmbSHr.SelectedIndex = 0;

        }
        private void cmbSMin_Items()
        {
            cmbSMin.Items.Add("select");
            int i;
            for (i = 0; i <= 60; i+=5)
            {
                cmbSMin.Items.Add(i);

            }
            cmbSMin.SelectedIndex = 0;

        }
        private void cmbEHr_Items()
        {
            cmbEHr.Items.Add("select");
            int i;
            for (i = 1; i <= 9; i++)
            {
                cmbEHr.Items.Add(n + i.ToString());

            }
            cmbEHr.Items.Add("10");
            cmbEHr.Items.Add("11");
            cmbEHr.Items.Add("12");
            cmbEHr.SelectedIndex = 0;

        }
        private void cmbEMin_Items()
        {
            cmbEMin.Items.Add("select");
            int i;
            for (i = 0; i <= 60; i+=5)
            {
                cmbEMin.Items.Add(i);

            }
            cmbEMin.SelectedIndex = 0;

        }
      #endregion
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BindFullGrid();
            rdbActive.IsChecked = true;
            cmbSHr_Items();
            cmbSMin_Items();
            cmbEHr_Items();
            cmbEMin_Items();
        }

        /* Created By:- Sameer Shinde
        * Created Date :- 5 Nov 2015
        * Purpose:- griddview cell click */
       

        #region----------------------gridview cell click()-------------------------
        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {

                object item = dgRoom.SelectedItem;
                string BranchName = (dgRoom.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                string RoomName = (dgRoom.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                string ShortName = (dgRoom.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                string Color = (dgRoom.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
                string Capacity = (dgRoom.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text;

                DataSet ds = obj_Room.BindFullGrid(0,BranchName,RoomName);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        UpID = Convert.ToInt32(ds.Tables[0].Rows[0]["RoomID"]);
                        cmbBranchName.Text = ds.Tables[0].Rows[0]["BranchName"].ToString();
                        txtRoomName.Text = ds.Tables[0].Rows[0]["RoomName"].ToString();
                        txtShortName.Text = ds.Tables[0].Rows[0]["RoomShortName"].ToString();
                        txtColor.Text = ds.Tables[0].Rows[0]["RoomColor"].ToString();
                        cmbCapacity.Text = ds.Tables[0].Rows[0]["Capacity"].ToString();
                        txtLectDay.Text=ds.Tables[0].Rows[0]["MaxNoLecturesDay"].ToString();
                        txtLectWeek.Text = ds.Tables[0].Rows[0]["MaxNoLecturesWeek"].ToString();
                        txtLectRow.Text=ds.Tables[0].Rows[0]["MaxNoOfLectureInRow"].ToString();
                        string time = ((System.Data.DataRowView)(dgRoom.CurrentItem)).Row.ItemArray[12].ToString();
                        string[] a = time.Split(':');
                        cmbSHr.Text = a[0];
                        if (a[1] == "00")
                        { cmbSMin.Text = "0"; }
                        else if (a[1] == "05")
                        { cmbSMin.Text = "5"; }
                        else
                        { cmbSMin.Text = a[1]; }

                        string ENDtime = ((System.Data.DataRowView)(dgRoom.CurrentItem)).Row.ItemArray[13].ToString();
                        string[] b = ENDtime.Split(':');
                        cmbEHr.Text = b[0];
                        if (b[1] == "00")
                        { cmbEMin.Text = "0"; }
                        else if (b[1] == "05")
                        { cmbEMin.Text = "5"; }
                        else
                        { cmbEMin.Text = b[1]; }

                        IsActive  = Convert.ToInt32(ds.Tables[0].Rows[0]["IsActive"]);
                        IsDeleted  = Convert.ToInt32(ds.Tables[0].Rows[0]["IsDeleted"]);
                        IsAllow = Convert.ToInt32(ds.Tables[0].Rows[0]["IsAllowMoreThanOneLectInBatch"]);
                        if (IsActive == 1 && IsDeleted == 0)
                        {
                            rdbActive.IsChecked = true;
                        }
                        else if (IsActive  == 0 && IsDeleted == 0)
                        {
                            rdbInactive.IsChecked = true;
                        }
                        if (IsAllow == 1)
                        {
                            chkAllowLect.IsChecked = true;
                        }
                        else 
                        { 
                            chkAllowLect.IsChecked = false; 
                        }
                        btnDelete.IsEnabled = true;
                        btnAdd.Content = "Update";
                    }
                }



            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion
       
        /* Created By:- Pranjali Vidhate
        * Created Date :- 6 Nov 2015
        * Purpose:- Update  cell click*/
       

        #region-----------------UpdateRoom()--------------------------------
        private void btnUpdate_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Validate())
                {
                    SetParameters();
                    string Result = obj_Room.UpdateRoom(RoomId, RoomName, ShortName, Color1, Capacity, BranchID, UpdatedByUserID, UpdatedDate, IsActive, IsDeleted, MaxLectDay, MaxLectWeek, MaxLectRow, StartTime, EndTime, IsAllow);
                    if (Result == "Updated Sucessfully...!!!")
                    {
                        MessageBox.Show(Result, "Updated SucessFull", MessageBoxButton.OK, MessageBoxImage.Information);
                        clearFields();
                    }
                    else
                    {
                        MessageBox.Show(Result, "Error To Update", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion


        #region---------------DeleteRoom()------------------------------
        private void btnDelete_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Validate())
                {
                    MessageBoxResult Result = MessageBox.Show("Do You Really Want To Delete?", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Information);
                    if (Result.Equals(MessageBoxResult.Yes))
                    {
                        SetParameters();
                        DeleteRoom();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void DeleteRoom()
        {
            if (UpID != 0)
            {
                RoomId = UpID;

                string Result = obj_Room.DeleteRoom(RoomId, UpdatedByUserID, UpdatedDate);
                if (Result == "Deleted Sucessfully...!!")
                {
                    MessageBox.Show(Result, "Delete Sucessfully", MessageBoxButton.OK, MessageBoxImage.Information);
                    clearFields();
                }
                else
                {
                    MessageBox.Show(Result, "Error To Delete", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please Select Subject From Subject", "Delete Error", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
        }

        #endregion


        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnclear_Click(object sender, RoutedEventArgs e)
        {
            clearFields();
        }

    }
 
 }

