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
using System.Data.Sql;
using System.Data.SqlClient;
using BusinessLayer;

namespace SchoolManagement.Room
{
    /// <summary>
    /// Interaction logic for CombineRoomAvail.xaml
    /// </summary>
    public partial class CombineRoomAvail : Window
    {
        #region--------------------------------------Decalre Vatriables---------------------------------
        BLRoom obj_Room = new BLRoom();
        BLAddBranch obj_Branch = new BLAddBranch();

        int RoomId, Capacity, BranchID, UpdatedByUserID, IsActive, IsDeleted, UpID;
        int IsAllow, MaxLectDay, MaxLectWeek, MaxLectRow, SHr, SMin, EHr, EMin;
        string RoomName, ShortName, Color1, UpdatedDate, Sign = ":", n1 = "0", m = "1";
        DateTime StartTime1, EndTime1;

        int daycheckcount = 0, cnn, n = 0;
        string tmpStartTime, tmpEndTime, Result;
        string[] StartTime;
        string[] EndTime;
        string[] s;

        int Active;
        string Day, FinalStartTime, FinalEndTime;

        #endregion


        public CombineRoomAvail()
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
        /* Created By:- Pranjali Vidhate
        * Created Date :- 4 Nov 2015
        * Purpose:- Validate All Fields*/

        #region---------------------------Validate()-----------------------------------------
        public bool Validate()
        {

            if (cmbBranchName.SelectedIndex == 0)
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
            //else if (string.IsNullOrEmpty(txtColor.Text))
            //{
            //    MessageBox.Show("Please Enter Color Detail..");
            //    txtColor.Focus();
            //    return false;
            //}
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
            else if (cmbSHr.SelectedIndex == 0 || cmbSMin.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select start Time...");
                cmbSHr.Focus();
                return false;
            }

            else if (cmbEHr.SelectedIndex == 0 || cmbEMin.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select End Time...");
                cmbEHr.Focus();
                return false;
            }
            else if (Convert.ToInt32(cmbSHr.SelectedItem.ToString()) > Convert.ToInt32(cmbEHr.SelectedItem.ToString()))
            {
                MessageBox.Show("End Hour Time Is Must Be Greater Than End Time", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                cmbEHr.Focus();
                return false;
            }
            else if ((Convert.ToInt32(cmbSHr.Text) == Convert.ToInt32(cmbEHr.Text)) && (Convert.ToInt32(cmbSMin.Text) >= Convert.ToInt32(cmbEMin.Text)))
            {
                MessageBox.Show("End Minute Time Is Must Be Greater Than End Time...");
                cmbEMin.Focus();
                return false;

            }
            else if (cmbAllowLect.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Allow Lecture  ...");
                cmbAllowLect.Focus();
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
           // txtColor.Text = "";
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
            Color1 = "Red";
            BranchID = Convert.ToInt32(cmbBranchName.SelectedValue.ToString());
            UpdatedByUserID = 1;
            UpdatedDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
            MaxLectDay = Convert.ToInt32(txtLectDay.Text.ToString());
            MaxLectWeek = Convert.ToInt32(txtLectWeek.Text.ToString());
            MaxLectRow = Convert.ToInt32(txtLectRow.Text.ToString());
            SHr = Convert.ToInt32(cmbSHr.SelectedValue.ToString());
            SMin = Convert.ToInt32(cmbSMin.SelectedValue.ToString());
            EHr = Convert.ToInt32(cmbEHr.SelectedValue.ToString());
            EMin = Convert.ToInt32(cmbEMin.SelectedValue.ToString());
            StartTime1 = Convert.ToDateTime(SHr + Sign + SMin);
            EndTime1 = Convert.ToDateTime(EHr + Sign + EMin);

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
            if (cmbAllowLect.Text == "Yes")
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
                    string Result = obj_Room.saveAddRoom(RoomId, RoomName, ShortName, Color1, Capacity, BranchID, UpdatedByUserID, UpdatedDate, IsActive, IsDeleted, MaxLectDay, MaxLectWeek, MaxLectRow, StartTime1, EndTime1, IsAllow);
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
                DataSet ds = obj_Room.BindFullGrid(0, cmbBranchName.Text, txtRoomName.Text);

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
                    cmbBranchName.SelectedValue = "0";
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
            for (i = 10; i <= 59; i += 5)
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
            for (i = 10; i <= 59; i += 5)
            {
                cmbEMin.Items.Add(i);

            }
            cmbEMin.SelectedIndex = 0;

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

        //private void txtColor_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    try
        //    {
        //        if (txtColor.Text != "")
        //        {
        //            if (txtColor.Text.Length > 0)
        //            {
        //                if (System.Text.RegularExpressions.Regex.IsMatch(txtColor.Text, "^[a-zA-Z]+$"))
        //                {
        //                }
        //                else
        //                {
        //                    MessageBox.Show("Please Enter Only Alphabets", "Color Name", MessageBoxButton.OK, MessageBoxImage.Warning);
        //                    txtColor.Text = "";
        //                    txtColor.Focus();
        //                }

        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message.ToString());
        //    }
        //}

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

        /*
         * Created By :- Pranjali Vidhate
         * Created Date:- 20 Nov 2015
         * Purpose:- To Clear all fields         */
        #region-------------------------------------------btnClear_Click------------------------------------
        private void btnclear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                clearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
        #endregion


        /* Created By:- Pranjali Vidhate
        * Created Date :- 19 Nov 2015
        * Purpose:- To Check Same Time Button Coding*/

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

        /* Created By:- Pranjali Vidhate
        * Created Date :- 19 Nov 2015
        * Purpose:- To  Check Day CheckBox Coding*/

        #region----------------------------------------------------------------CheckBoxes()---------------------------------------------------

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

        #region---------------------------------------------------Chkwed------------------------------------------------
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

        /* Created By:- Pranjali Vidhate
        * Created Date :- 19 Nov 2015
        * Purpose:- To Enable All DropDown*/

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

        /* Created By:- Pranjali Vidhate
        * Created Date :- 19 Nov 2015
        * Purpose:- To Diseble All DropDown*/

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

        /* Created By:- Pranjali Vidhate
        * Created Date :- 19 Nov 2015
        * Purpose:- To Check All Days*/

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

        /* Created By:- Pranjali Vidhate
        * Created Date :- 19 Nov 2015
        * Purpose:- To Uncheck All Days*/

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

        /* Created By:- Pranjali Vidhate
        * Created Date :- 19 Nov 2015
        * Purpose:- Coding For StartHr_Selectionchange*/

        #region-------------------------------------------------ChkStartHrs_SelectionChanged()-----------------------------------------------
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

        /* Created By:- Pranjali Vidhate
        * Created Date :- 19 Nov 2015
        * Purpose:- Coding For StartMin_Selectionchange*/

        #region-------------------------------------------------ChkStartMin_SelectionChanged()-----------------------------------------------
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

        /* Created By:- Pranjali Vidhate
        * Created Date :- 19 Nov 2015
        * Purpose:- Coding For EndHr_Selectionchange*/

        #region-------------------------------------------------ChkEndHrs_SelectionChanged()-----------------------------------------------
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

        /* Created By:- Pranjali Vidhate
        * Created Date :- 19 Nov 2015
        * Purpose:- Coding For EndMin_Selectionchange*/

        #region-------------------------------------------------ChkEndMin_SelectionChanged()-----------------------------------------------
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

        /* Created By:- Pranjali Vidhate
        * Created Date :- 19 Nov 2015
        * Purpose:- To Uncheck All CheckBoxes*/

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


    }
}
