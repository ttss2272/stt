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

        int RoomId, Capacity, BranchID, UpdatedByUserID, IsActive, IsDeleted, UpID;
        string RoomName, ShortName, Color1, UpdatedDate;


        public Room1()
        {
            InitializeComponent();
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
            else if (cmbBranchName.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select Branch Name...");
                cmbCapacity.Focus();
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
            cmbCapacity.Text = "";
            txtColor.Text = "";
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
                    string Result = obj_Room.saveAddRoom(RoomId, RoomName, ShortName, Color1, Capacity, BranchID, UpdatedByUserID, UpdatedDate, IsActive, IsDeleted);
                    if (Result == "Save Sucessfully...!!!")
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

        #region-------------Update()------------------------------------

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    if (Validate())
            //    {
            //        SetParameters();
            //        string Result = obj_Room.UpdateRoom(RoomId, RoomName, ShortName, Color1, Capacity, BranchID, UpdatedByUserID, UpdatedDate, IsActive, IsDeleted);
            //        if (Result == "Updated Sucessfully...!!!")
            //        {
            //            MessageBox.Show(Result, "Updated SucessFull", MessageBoxButton.OK, MessageBoxImage.Information);
            //            clearFields();
            //        }
            //        else
            //        {
            //            MessageBox.Show(Result, "Error To Update", MessageBoxButton.OK, MessageBoxImage.Warning);
            //        }
            //    }
            //}

            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message.ToString());
            //}


        }



        #endregion

        #region----------------------------bindgrid()-----------------------
        private void BindFullGrid()
        {
            try
            {
                DataSet ds = obj_Room.BindFullGrid(0,txtRoomName.Text);

               // ds = obj_Room.BindFullGrid(0);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dgRoom.ItemsSource = ds.Tables[0].DefaultView;

                }

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



        #region------------Delete()--------------------------
        
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult Result = MessageBox.Show("Do You Really Want To Delete?", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (Result.Equals(MessageBoxResult.Yes))
                {
                    SetParameters();
                    DeleteRoom();
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
                if (Result == "Deleted Sucessfully.")
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

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            //App.Current.Shutdown();
            
        }


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

        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BindFullGrid();
        }
        /* Created By:- Sameer Shinde
        * Created Date :- 5 Nov 2015
        * Purpose:- griddview cell click
       */
        #region--------------------------------------gridview cell click()-------------------------------------
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

                DataSet ds = obj_Room.BindFullGrid(0,txtRoomName.Text);
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

                        int act = Convert.ToInt32(ds.Tables[0].Rows[0]["IsActive"]);
                        int del = Convert.ToInt32(ds.Tables[0].Rows[0]["IsDeleted"]);
                        if (act == 1 && del == 0)
                        {
                            rdbActive.IsChecked = true;
                        }
                        else if (act == 0 && del == 0)
                        {
                            rdbInactive.IsChecked = true;
                        }
                        btnDelete.IsEnabled = true;
                    }
                }



            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion

        private void btnUpdate_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Validate())
                {
                    SetParameters();
                    string Result = obj_Room.UpdateRoom(RoomId, RoomName, ShortName, Color1, Capacity, BranchID, UpdatedByUserID, UpdatedDate, IsActive, IsDeleted);
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

    }
 
 }

