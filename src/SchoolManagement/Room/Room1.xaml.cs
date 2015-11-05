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

        public Room1()
        {
            InitializeComponent();
            BindFullGrid();
            BindBranchName();
            clearFields();
            
        }
        private void Room1_Loaded()
        {
            cmbCapacity_Items();
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
            else if (cmbBranchName.SelectedIndex == 0)
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
        }
        #endregion


        #region---------------AddRoom()--------------------------------------
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
           try
            {
                if (Validate())
                {
                        int RoomId= 0;
                        string RoomName = txtRoomName.Text;
                        string ShortName = txtShortName.Text;
                        int Capacity = Convert.ToInt32(cmbCapacity.SelectedValue.ToString());
                        string Color1 = txtColor.Text;
                        int UpdatedByUserID = 1;
                        string UpdatedDate = DateTime.Now.ToString();
                        int IsActive = 1;
                      //  string IsDelete = "No";
                        string Result = obj_Room.saveAddRoom(RoomId, RoomName, ShortName,Color1, Capacity, UpdatedByUserID,UpdatedDate, IsActive);
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
                       // int RoomId= 0;
                        string RoomName = txtRoomName.Text;
                        string ShortName = txtShortName.Text;
                        int Capacity = Convert.ToInt32(cmbCapacity.SelectedValue.ToString());
                        string Color1 = txtColor.Text;
                      //  int UpdatedByUserID = 1;
                        string UpdatedDate = DateTime.Now.ToString();
                        int IsActive = 1;
                      //  string IsDelete = "No";
                        string Result = obj_Room.UpdateRoom(RoomName, ShortName,Color1, Capacity,UpdatedDate,IsActive);
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
                BLRoom objBL = new BLRoom();
                ds = objBL.BindFullGrid(0);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dgRoom.ItemsSource = ds.Tables[0].DefaultView;
                }
                else 
                {
                    dgRoom.ItemsSource = null;
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
            SqlConnection con = new SqlConnection();
            {
                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand("BindBranchName_SP", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                   // DataTable dt = new DataTable();
                    DataSet ds= new DataSet();
                    da.Fill(ds,"Branch");

                    if (ds.Tables["Branch"].Rows.Count > 0)
                    {
                        cmbBranchName.DataContext= ds.Tables["Branch"].DefaultView;
                        cmbBranchName.DisplayMemberPath = ds.Tables["Branch"].Columns["BranchName"].ToString();
                        cmbBranchName.SelectedValuePath = ds.Tables["Branch"].Columns["BranchID"].ToString();
                       
                    }

                }
                catch (Exception eo)
                {
                    MessageBox.Show(eo.Message.ToString());
                }
                finally
                {
                    //cmd.Dispose();
                    con.Close();
                    con.Dispose();
                }
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
            ComboBox cmb = new ComboBox(); 
            int i;
            for (i = 1; i <= 60; i++)
            {
                cmb.Items.Add(i);
            }  

        }

        
     }
 
 }

