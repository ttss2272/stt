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
        BLAddBranch obj_Branch=new BLAddBranch();

        int RoomId,Capacity,BranchID,UpdatedByUserID,IsActive,IsDeleted;
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
            BindFullGrid();
            BindBranchName();
        }
        #endregion


        #region---------------AddRoom()--------------------------------------
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
           try
            {
                if (Validate())
                {
                        RoomId= 0;
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
                        string Result = obj_Room.saveAddRoom(RoomId, RoomName, ShortName,Color1, Capacity,BranchID,UpdatedByUserID,UpdatedDate, IsActive,IsDeleted);
                        if (Result == "Save Sucessfully...!!!" )
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
            try
            {
                if (Validate())
                {
                        RoomId= 0;
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
                        
                        string Result = obj_Room.UpdateRoom(RoomId, RoomName, ShortName, Color1, Capacity,BranchID,UpdatedByUserID,UpdatedDate, IsActive, IsDeleted);
                        if (Result == "Updated Sucessfully...!!!" )
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

        #region----------------------------bindgrid()-----------------------
        private void BindFullGrid()
        {
            try
            {
                DataSet ds = new DataSet();

                ds = obj_Room.BindFullGrid(0);
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
                    DataSet ds=obj_Branch.BindBranchName();
                   

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        cmbBranchName.DataContext= ds.Tables[0].DefaultView;
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

 
             
  /*   private void btnDelete_Click(object sender, EventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do You Want to delete?", "Delete", MessageBoxButtons.OKCancel);
            if (result.Equals(MessageBoxResult.OK))
            {
                deleteRoom();
             //   Usp_BindRoomGrid();
                MessageBox.Show("Record Deleted Succesfully");
                clearFields(); 
            }
            else
            {
            }
        }*/

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cmbCapacity_Items();
        }
        
        
     }
 
 }

