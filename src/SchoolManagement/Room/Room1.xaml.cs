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
        string RoomName, ShortName, Color1, UpdatedDate,Sign=":",n="0",m="1";
        DateTime StartTime, EndTime;


        public Room1()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
            this.Width = System.Windows.SystemParameters.PrimaryScreenWidth;
            this.Height = System.Windows.SystemParameters.PrimaryScreenHeight;
            clearFields();

        }

        /* Created By:- Pranjali Vidhate
        * Created Date :- 4 Nov 2015
        * Purpose:- Validate All Fields*/

        #region---------------------------Validate()-----------------------------------------
        public bool Validate()
        {

            if (cmbBranchName.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select Branch Name...");
                cmbBranchName.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtRoomName.Text))
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
            else if (rdbActive.IsChecked == false && rdbInactive.IsChecked == false)
            {
                MessageBox.Show("Please Select Status...");
                return false;
            }
            else if (string.IsNullOrEmpty(txtLectDay.Text))
            {
                MessageBox.Show("Please Enter No. Of Lect/Day..");
                txtLectDay.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtLectWeek.Text))
            {
                MessageBox.Show("Please Enter No. Of Lect/Week..");
                txtLectWeek.Focus();
                return false;
            }
            else if (Convert.ToInt32(txtLectDay.Text) > Convert.ToInt32(txtLectWeek.Text))
            {
                MessageBox.Show("Please Enter Lect/Week Greater than Lect/Day");
                txtLectWeek.Text = "";
                txtLectWeek.Focus();
                return false;

            }
            else if (string.IsNullOrEmpty(txtLectRow.Text))
            {
                MessageBox.Show("Please Enter No. Of Lect In Row..");
                txtLectRow.Focus();
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
            else if ((Convert.ToInt32(cmbSHr.Text) == Convert.ToInt32(cmbEHr.Text))&&(Convert.ToInt32(cmbSMin.Text) >= Convert.ToInt32(cmbEMin.Text)))
            {
                    MessageBox.Show("Please Enter Proper Time  ...");
                    cmbSHr.Focus();
                    return false;
                
            }
            else if (cmbAllowLect.SelectedIndex== 0)
            {
                MessageBox.Show("Please Select Allow Lecture  ...");
                cmbSHr.Focus();
                return false;
            }
            
            else
            {
                return true;
            }
        }
        #endregion

        /* Created By:- Pranjali Vidhate
        * Created Date :- 4 Nov 2015
        * Purpose:- Clear All Fields */

        #region-----------------------Clearfield()------------------------------------
        private void clearFields()
        {
            UpID = 0;
            cmbBranchName.Text = "";
            txtRoomName.Text = "";
            txtShortName.Text = "";
            txtColor.Text = "";
            txtLectDay.Text = "";
            txtLectWeek.Text = "";
            txtLectRow.Text = "";
            rdbActive.IsChecked = true;
            rdbInactive.IsChecked = false;
            cmbAllowLect.Text = "";
            btnAdd.Content = "Save";
            cmbSHr.SelectedIndex = 0;
            cmbSMin.SelectedIndex = 0;
            cmbEHr.SelectedIndex = 0;
            cmbEMin.SelectedIndex = 0;
            cmbCapacity.SelectedIndex = 0;
            cmbAllowLect.SelectedIndex = 0;
            btnDelete.IsEnabled = false;
            BindFullGrid();
            BindBranchName();
        }
        #endregion

       /* Created By:- Pranjali Vidhate
        * Created Date :- 4 Nov 2015
        * Purpose:- Set Parameters*/

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
            if (cmbAllowLect.Text  == "Yes")
                IsAllow = 1;
            else
                IsAllow = 0;
        }
        #endregion

        /* Created By:- Pranjali Vidhate
        * Created Date :- 4 Nov 2015
        * Purpose:- Save/Update Room coding*/
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

        /* Created By:- Pranjali Vidhate
        * Created Date :- 5 Nov 2015
        * Purpose:- Binding Full Grid */

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

        /* Created By:- Pranjali Vidhate
        * Created Date :- 5 Nov 2015
        * Purpose:- Binding branch*/

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


        /* Created By:- Pranjali Vidhate
        * Created Date :- 5 Nov 2015
        * Purpose:- Binding Room capacity*/

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

        /* Created By:- Pranjali Vidhate
        * Created Date :- 7 Nov 2015
        * Purpose:- Binding StartTime & EndTime*/

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
            for (i = 1; i <= 9; i++)
            {
                cmbSHr.Items.Add(m + i.ToString());

            }
            cmbSHr.Items.Add("20");
            cmbSHr.Items.Add("21");
            cmbSHr.Items.Add("22");
            cmbSHr.Items.Add("23"); 
            cmbSHr.Items.Add("24");
            cmbSHr.SelectedIndex = 0;

        }
        private void cmbSMin_Items()
        {
            cmbSMin.Items.Add("select");
            int i;
            cmbSMin.Items.Add("00");
            cmbSMin.Items.Add("05");
            for (i = 10; i <= 60; i+=5)
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
            for (i = 1; i <= 9; i++)
            {
                cmbEHr.Items.Add(m + i.ToString());

            }
            cmbEHr.Items.Add("20");
            cmbEHr.Items.Add("21");
            cmbEHr.Items.Add("22");
            cmbEHr.Items.Add("23");
            cmbEHr.Items.Add("24");
            cmbEHr.SelectedIndex = 0;

        }
        private void cmbEMin_Items()
        {
            cmbEMin.Items.Add("select");
            int i;
            cmbEMin.Items.Add("00");
            cmbEMin.Items.Add("05");
            for (i = 10; i <= 60; i+=5)
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
            cmbCapacity_Items();
            cmbSHr_Items();
            cmbSMin_Items();
            cmbEHr_Items();
            cmbEMin_Items();
            cmbAllowLect.SelectedIndex = 0;
            btnDelete.IsEnabled = false;
        }

        /* Created By:- Sameer Shinde
        * Created Date :- 6 Nov 2015
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
                        cmbSMin.Text = a[1]; 

                        string ENDtime = ((System.Data.DataRowView)(dgRoom.CurrentItem)).Row.ItemArray[13].ToString();
                        string[] b = ENDtime.Split(':');
                        cmbEHr.Text = b[0];
                        cmbEMin.Text = b[1]; 

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
                            cmbAllowLect.Text= "Yes";
                        }
                        else 
                        { 
                            cmbAllowLect.Text  = "No"; 
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
        * Purpose:- To Delete Room */


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
                MessageBox.Show("Please Select Room", "Delete Error", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
        }

        #endregion

        /* Created By:- Pranjali Vidhate
        * Created Date :- 20 Nov 2015
        * Purpose:- Vaidation for text check */


        #region-----------------Validation for text------------------------------
        private void txtRoomName_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (txtRoomName.Text != "")
                {
                    if (txtRoomName.Text.Length > 0 && txtRoomName.Text.Length == 1)
                    {
                        if (System.Text.RegularExpressions.Regex.IsMatch(txtRoomName.Text, "^[a-zA-Z]"))
                        {
                        }
                        else
                        {
                            MessageBox.Show("Please Enter First Characerter Alphabate", "Room Name", MessageBoxButton.OK, MessageBoxImage.Warning);
                            txtRoomName.Text = "";
                            txtRoomName.Focus();
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

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
                            MessageBox.Show("Please Enter First Characerter Alphabate", "Room Short Name", MessageBoxButton.OK, MessageBoxImage.Warning);
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

        private void txtColor_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (txtColor.Text != "")
                {
                    if (txtColor.Text.Length > 0)
                    {
                        if (System.Text.RegularExpressions.Regex.IsMatch(txtColor.Text, "^[a-zA-Z]+$"))
                        {
                        }
                        else
                        {
                            MessageBox.Show("Please Enter Only Alphabets", "Color Name", MessageBoxButton.OK, MessageBoxImage.Warning);
                            txtColor.Text = "";
                            txtColor.Focus();
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void txtLectDay_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (txtLectDay.Text != "")
                {
                    if (txtLectDay.Text.Length > 0)
                    {
                        if (System.Text.RegularExpressions.Regex.IsMatch(txtLectDay.Text, "^[0-9]+$"))
                        {
                        }
                        else
                        {
                            MessageBox.Show("Please Enter Only Numbers", "Max no.of lecture per day", MessageBoxButton.OK, MessageBoxImage.Warning);
                            txtLectDay.Text = "";
                            txtLectDay.Focus();
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void txtLectWeek_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (txtLectWeek.Text != "")
                {
                    if (txtLectWeek.Text.Length > 0)
                    {
                            if (System.Text.RegularExpressions.Regex.IsMatch(txtLectWeek.Text, "^[0-9]+$"))
                            {
                            }
                            else
                            {
                                MessageBox.Show("Please Enter Only Numbers", "Max no.of lecture per week", MessageBoxButton.OK, MessageBoxImage.Warning);
                                txtLectWeek.Text = "";
                                txtLectWeek.Focus();
                            }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }


        private void txtLectRow_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (txtLectRow.Text != "")
                {
                    if (txtLectRow.Text.Length > 0)
                    {
                        if (System.Text.RegularExpressions.Regex.IsMatch(txtLectRow.Text, "^[0-9]+$"))
                        {
                        }
                        else
                        {
                            MessageBox.Show("Please Enter Only Numbers", "Max no.of lecture in row", MessageBoxButton.OK, MessageBoxImage.Warning);
                            txtLectRow.Text = "";
                            txtLectRow.Focus();
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

        private void btnclear_Click(object sender, RoutedEventArgs e)
        {
            clearFields();
        }

    }
 
 }

