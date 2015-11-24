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

namespace SchoolManagement.Timeslot
{
    /// <summary>
    /// Interaction logic for TmeSlot.xaml
    /// </summary>
    public partial class TmeSlot : Window
    {

        BLTimeSlot obj_TSlot = new BLTimeSlot();
        BLAddBranch obj_Branch = new BLAddBranch();

        int BranchLectureDetailID, BranchID, UpdatedByUserID, IsActive, IsDeleted, UpID;
        int SHr, SMin, EHr, EMin, SSHr, SSMin, SEHr,SEMin;
        string DayName,UpdatedDate, Sign = ":", n = "0",m="1";
        DateTime StartTime, EndTime, SlotStartTime, SlotEndTime;

        public TmeSlot()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
            this.Width = System.Windows.SystemParameters.PrimaryScreenWidth;
            this.Height = System.Windows.SystemParameters.PrimaryScreenHeight;
            clearFields();
           
        }

        /* Created By:- Pranjali Vidhate
      * Created Date :- 17 Nov 2015
      * Purpose:- Validation*/

        #region---------------------------Validate()-----------------------------------------
        public bool Validate()
        {
            if (cmbBranchName.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select Branch Name...");
                cmbBranchName.Focus();
                return false;
            }
             else if (cmbDayName.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Day Name...");
                cmbDayName.Focus();
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
             else if (cmbSSHr.SelectedIndex == 0 || cmbSSMin.SelectedIndex == 0)
             {
                 MessageBox.Show("Please Select Slot start Time...");
                 cmbSHr.Focus();
                 return false;
             }

             else if (cmbSEHr.SelectedIndex == 0 || cmbSEMin.SelectedIndex == 0)
             {
                 MessageBox.Show("Please Select Slot End Time...");
                 cmbEHr.Focus();
                 return false;
             }
            else if (Convert.ToInt32(cmbSHr.SelectedItem.ToString()) > Convert.ToInt32(cmbEHr.SelectedItem.ToString()))
            {
                MessageBox.Show("End Hour Time of Open Time Is Must Be Greater Than End Time", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                cmbEHr.Focus();
                return false;
            }
            else if ((Convert.ToInt32(cmbSHr.Text) == Convert.ToInt32(cmbEHr.Text)) && (Convert.ToInt32(cmbSMin.Text) >= Convert.ToInt32(cmbEMin.Text)))
            {
                MessageBox.Show("End Minute Time of Open Time Is Must Be Greater Than End Time...");
                cmbEMin.Focus();
                return false;

            }
            else if (Convert.ToInt32(cmbSSHr.SelectedItem.ToString()) > Convert.ToInt32(cmbSEHr.SelectedItem.ToString()))
            {
                MessageBox.Show("End Hour Time of Slot Time Is Must Be Greater Than End Time", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                cmbEHr.Focus();
                return false;
            }
             else if ((Convert.ToInt32(cmbSSHr.Text) == Convert.ToInt32(cmbSEHr.Text)) && (Convert.ToInt32(cmbSSMin.Text) >= Convert.ToInt32(cmbSEMin.Text)))
             {
                 MessageBox.Show("End Minute Time of Slot Time Is Must Be Greater Than End Time...");
                 cmbSSHr.Focus();
                 return false;
             }
            else if (Convert.ToInt32(cmbSHr.SelectedItem.ToString()) > Convert.ToInt32(cmbSSHr.SelectedItem.ToString())) 
            {
                MessageBox.Show("Please Enter Slot Start Time With in Open Time...");
                cmbSSHr.Focus();
                return false;
            }
            else if (Convert.ToInt32(cmbEHr.SelectedItem.ToString()) < Convert.ToInt32(cmbSEHr.SelectedItem.ToString()))
            {
                MessageBox.Show("Please Enter Slot End Time With in Open Time...");
                cmbSEHr.Focus();
                return false;

            }
            else if (rdbActive.IsChecked == false && rdbInactive.IsChecked == false)
            {
                MessageBox.Show("Please Select Status...");
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        /* Created By:- Pranjali Vidhate
        * Created Date :- 17 Nov 2015
        * Purpose:- Clear All Fields */

        #region-----------------------Clearfield()------------------------------------
        private void clearFields()
        {
            UpID = 0;
            rdbActive.IsChecked = true;
            rdbInactive.IsChecked = false;
            btnDelete.IsEnabled = false;
            btnAdd.Content = "Save";
            cmbSHr.SelectedIndex = 0;
            cmbSMin.SelectedIndex = 0;
            cmbEHr.SelectedIndex = 0;
            cmbEMin.SelectedIndex = 0;
            cmbSSHr.SelectedIndex = 0;
            cmbSSMin.SelectedIndex = 0;
            cmbSEHr.SelectedIndex = 0;
            cmbSEMin.SelectedIndex = 0;
            cmbBranchName.SelectedIndex = 0;
            cmbDayName.SelectedIndex = 0;
            BindFullGrid();
            BindBranchName();
        }
        #endregion

       /* Created By:- Pranjali Vidhate
        * Created Date :- 17 Nov 2015
        * Purpose:- Set Parameters*/

        #region------------------SetParameters---------------------------------------

        private void SetParameters()
        {
            BranchLectureDetailID = UpID;
            DayName = cmbDayName.Text;
            BranchID = Convert.ToInt32(cmbBranchName.SelectedValue.ToString());
            UpdatedByUserID = 1;
            UpdatedDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
            SHr = Convert.ToInt32(cmbSHr.SelectedValue.ToString());
            SMin = Convert.ToInt32(cmbSMin.SelectedValue.ToString());
            EHr = Convert.ToInt32(cmbEHr.SelectedValue.ToString());
            EMin = Convert.ToInt32(cmbEMin.SelectedValue.ToString());
            SSHr = Convert.ToInt32(cmbSSHr.SelectedValue.ToString());
            SSMin = Convert.ToInt32(cmbSSMin.SelectedValue.ToString());
            SEHr = Convert.ToInt32(cmbSEHr.SelectedValue.ToString());
            SEMin = Convert.ToInt32(cmbSEMin.SelectedValue.ToString());
            StartTime =Convert.ToDateTime( SHr + Sign + SMin);
            EndTime = Convert.ToDateTime(EHr + Sign + EMin);
            SlotStartTime = Convert.ToDateTime(SSHr + Sign + SSMin);
            SlotEndTime = Convert.ToDateTime(SEHr + Sign + SEMin);


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

        /* Created By:- Pranjali Vidhate
       * Created Date :- 17 Nov 2015
       * Purpose:- Binding branch*/

        #region-------------bindbranch()--------------------------------------

        private void BindBranchName()
        {

            try
            {
                DataSet ds = obj_Branch.BindBranchName();


                if (ds.Tables[0].Rows.Count > 0)
                {
                    
                    cmbBranchName.DisplayMemberPath = ds.Tables[0].Columns["BranchName"].ToString();
                    cmbBranchName.SelectedValuePath = ds.Tables[0].Columns["BranchID"].ToString();
                    cmbBranchName.DataContext = ds.Tables[0].DefaultView;
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
        * Created Date :- 17 Nov 2015
        * Purpose:- Binding Room capacity*/

        #region-------------LoadDayNames-------------------------------
        private void cmbDayName_Items()
        {
            cmbDayName.Items.Add("select");
            cmbDayName.Items.Add("Monday");
            cmbDayName.Items.Add("Tuesday");
            cmbDayName.Items.Add("Wednesday");
            cmbDayName.Items.Add("Thursday");
            cmbDayName.Items.Add("Friday");
            cmbDayName.Items.Add("Saturday");
            cmbDayName.SelectedIndex = 0;

        }
        #endregion


        /* Created By:- Pranjali Vidhate
        * Created Date :- 17 Nov 2015
        * Purpose:- Binding Full Grid */

        #region----------------------------bindgrid()-----------------------
        private void BindFullGrid()
        {
            try
            {
                DataSet ds;
                if (cmbBranchName.Text == "Select")
                {
                    ds = obj_TSlot.BindFullGrid(0, "", "");

                }
                else
                {
                    ds = obj_TSlot.BindFullGrid(0, cmbBranchName.Text, "");
                }
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dgTimeSlot.ItemsSource = ds.Tables[0].DefaultView;

                }
                dgTimeSlot.Items.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion


        /* Created By:- Pranjali Vidhate
        * Created Date :- 17 Nov 2015
        * Purpose:- Save Inforamtion */

        #region----------------------AddTimeSolt()---------------------------------
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Validate())
                {
                    SetParameters();
                    string Result = obj_TSlot.SaveUpdateSlot(BranchLectureDetailID, BranchID, DayName, StartTime, EndTime, SlotStartTime, SlotEndTime, IsActive, IsDeleted, UpdatedDate, UpdatedByUserID);
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
        * Created Date :- 17 Nov 2015
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
            for (i = 10; i <= 60; i += 5)
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
            for (i = 10; i <= 60; i += 5)
            {
                cmbEMin.Items.Add(i);

            }
            cmbEMin.SelectedIndex = 0;

        }
        #endregion
      
        /* Created By:- Pranjali Vidhate
        * Created Date :- 17 Nov 2015
        * Purpose:- Binding Slot StartTime & EndTime*/

        #region--------------LoadSlotHrMin()-----------------------------------
        private void cmbSSHr_Items()
        {
            cmbSSHr.Items.Add("select");
            int i;
            for (i = 1; i <= 9; i++)
            {
                cmbSSHr.Items.Add(n + i.ToString());

            }
            cmbSSHr.Items.Add("10");
            for (i = 1; i <= 9; i++)
            {
                cmbSSHr.Items.Add(m + i.ToString());

            }
            cmbSSHr.Items.Add("20");
            cmbSSHr.Items.Add("21");
            cmbSSHr.Items.Add("22");
            cmbSSHr.Items.Add("23");
            cmbSSHr.Items.Add("24");
            cmbSSHr.SelectedIndex = 0;

        }
        private void cmbSSMin_Items()
        {
            cmbSSMin.Items.Add("select");
            int i;
            cmbSSMin.Items.Add("00");
            cmbSSMin.Items.Add("05");
            for (i = 10; i <= 60; i += 5)
            {
                cmbSSMin.Items.Add(i);

            }
            cmbSSMin.SelectedIndex = 0;

        }
        private void cmbSEHr_Items()
        {
            cmbSEHr.Items.Add("select");
            int i;
            for (i = 1; i <= 9; i++)
            {
                cmbSEHr.Items.Add(n + i.ToString());

            }
            cmbSEHr.Items.Add("10");
            for (i = 1; i <= 9; i++)
            {
                cmbSEHr.Items.Add(m + i.ToString());

            }
            cmbSEHr.Items.Add("20");
            cmbSEHr.Items.Add("21");
            cmbSEHr.Items.Add("22");
            cmbSEHr.Items.Add("23");
            cmbSEHr.Items.Add("24");
            cmbSEHr.SelectedIndex = 0;

        }
        private void cmbSEMin_Items()
        {
            cmbSEMin.Items.Add("select");
            int i;
            cmbSEMin.Items.Add("00");
            cmbSEMin.Items.Add("05");
            for (i = 10; i <= 60; i += 5)
            {
                cmbSEMin.Items.Add(i);

            }
            cmbSEMin.SelectedIndex = 0;

        }
        #endregion


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            BindFullGrid();
            rdbActive.IsChecked = true;
            btnDelete.IsEnabled = false;
            cmbDayName_Items();
            cmbSHr_Items();
            cmbSMin_Items();
            cmbEHr_Items();
            cmbEMin_Items();
            cmbSSHr_Items();
            cmbSSMin_Items();
            cmbSEHr_Items();
            cmbSEMin_Items();
        }

        /* Created By:- pranjali vidhate
       * Created Date :- 18 Nov 2015
       * Purpose:- griddview cell click */


        #region----------------------gridview cell click()-------------------------
        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {

                object item = dgTimeSlot.SelectedItem;
                string BranchName = (dgTimeSlot.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                string DayName = (dgTimeSlot.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;

                DataSet ds = obj_TSlot.BindFullGrid(0, BranchName, DayName);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        UpID = Convert.ToInt32(ds.Tables[0].Rows[0]["BranchLectureDetailID"]);
                        cmbDayName.Text = ds.Tables[0].Rows[0]["DayName"].ToString();
                        cmbBranchName.Text = ds.Tables[0].Rows[0]["BranchName"].ToString();
                        string StartTime = ((System.Data.DataRowView)(dgTimeSlot.CurrentItem)).Row.ItemArray[4].ToString();
                        string[] a = StartTime.Split(':');
                        cmbSHr.Text = a[0];
                        cmbSMin.Text = a[1];

                        string EndTime = ((System.Data.DataRowView)(dgTimeSlot.CurrentItem)).Row.ItemArray[5].ToString();
                        string[] b = EndTime.Split(':');
                        cmbEHr.Text = b[0];
                        cmbEMin.Text = b[1];

                        string SlotStartTime = ((System.Data.DataRowView)(dgTimeSlot.CurrentItem)).Row.ItemArray[8].ToString();
                        string[] c = SlotStartTime.Split(':');
                        cmbSSHr.Text = c[0];
                        cmbSSMin.Text = c[1];

                        string SlotEndTime = ((System.Data.DataRowView)(dgTimeSlot.CurrentItem)).Row.ItemArray[9].ToString();
                        string[] d = SlotEndTime.Split(':');
                        cmbSEHr.Text = d[0];
                        cmbSEMin.Text = d[1];

                        IsActive = Convert.ToInt32(ds.Tables[0].Rows[0]["IsActive"]);
                        IsDeleted = Convert.ToInt32(ds.Tables[0].Rows[0]["IsDelete"]);
                        if (IsActive == 1 && IsDeleted == 0)
                        {
                            rdbActive.IsChecked = true;
                        }
                        else if (IsActive == 0 && IsDeleted == 0)
                        {
                            rdbInactive.IsChecked = true;
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

        private void btnclear_Click(object sender, RoutedEventArgs e)
        {
            clearFields();
        }

        /* Created By:- pranjali vidhate
       * Created Date :- 18 Nov 2015
       * Purpose:- griddview cell click */

        #region-----------------------DeleteTimeSlot-------------------------------
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Validate())
                {
                    MessageBoxResult Result = MessageBox.Show("Do You Really Want To Delete?", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Information);
                    if (Result.Equals(MessageBoxResult.Yes))
                    {
                        SetParameters();
                        DeleteTimeSlot();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void DeleteTimeSlot()
        {
            if (UpID != 0)
            {
                BranchLectureDetailID = UpID;

                string Result = obj_TSlot.DeleteTimeSlot(BranchLectureDetailID, UpdatedByUserID, UpdatedDate);
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
                MessageBox.Show("Please Select Time Slot", "Delete Error", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
        }


        #endregion


        #region------------------------------DaySelectionChanged----------------------------
        private void cmbDayName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cmbBranchName.SelectedValue != "0")
                {

                    if (cmbDayName.SelectedItem.ToString() != "select")
                    {
                        DataSet ds = obj_TSlot.BindFullGrid(0, cmbBranchName.Text, cmbDayName.SelectedItem.ToString());
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            string StartTime = ds.Tables[0].Rows[0]["StartTime"].ToString();
                            string[] a = StartTime.Split(':');
                            cmbSHr.Text = a[0];
                            cmbSMin.Text = a[1];

                            string EndTime = ds.Tables[0].Rows[0]["EndTime"].ToString();
                            string[] b = EndTime.Split(':');
                            cmbEHr.Text = b[0];
                            cmbEMin.Text = b[1];

                            string SlotStartTime = ds.Tables[0].Rows[0]["LectureStartTime"].ToString();
                            string[] c = SlotStartTime.Split(':');
                            cmbSSHr.Text = c[0];
                            cmbSSMin.Text = c[1];


                            string SlotEndTime = ds.Tables[0].Rows[0]["LectureEndTime"].ToString();
                            string[] d = SlotEndTime.Split(':');
                            cmbSEHr.Text = d[0];
                            cmbSEMin.Text = d[1];

                            IsActive = Convert.ToInt32(ds.Tables[0].Rows[0]["IsActive"]);
                            IsDeleted = Convert.ToInt32(ds.Tables[0].Rows[0]["IsDelete"]);
                            if (IsActive == 1 && IsDeleted == 0)
                            {
                                rdbActive.IsChecked = true;
                            }
                            else if (IsActive == 0 && IsDeleted == 0)
                            {
                                rdbInactive.IsChecked = true;
                            }
                            btnDelete.IsEnabled = true;
                            // btnAdd.Content = "Update";
                            BindFullGrid();
                        }
                    }
                   // else { BindFullGrid(); }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion
    }
}
