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
        string DayName,UpdatedDate, Sign = ":", n = "0";
        DateTime StartTime, EndTime, SlotStartTime, SlotEndTime;

        public TmeSlot()
        {
            InitializeComponent();
            clearFields();
           
        }

        /* Created By:- Pranjali Vidhate
      * Created Date :- 17 Nov 2015
      * Purpose:- Validation*/

        #region---------------------------Validate()-----------------------------------------
        public bool Validate()
        {

             if (cmbDayName.SelectedIndex == 0)
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
            cmbBranchName.Text = "";
            cmbDayName.Text = "";
            rdbActive.IsChecked = true;
            rdbInactive.IsChecked = false;
            btnAdd.Content = "Save";
            cmbSHr.SelectedIndex = 0;
            cmbSMin.SelectedIndex = 0;
            cmbEHr.SelectedIndex = 0;
            cmbEMin.SelectedIndex = 0;
            cmbSSHr.SelectedIndex = 0;
            cmbSSMin.SelectedIndex = 0;
            cmbSEHr.SelectedIndex = 0;
            cmbSEMin.SelectedIndex = 0;
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
            UpdatedDate = DateTime.Now.ToString();
            SHr = Convert.ToInt32(cmbSHr.SelectedValue.ToString());
            SMin = Convert.ToInt32(cmbSMin.SelectedValue.ToString());
            EHr = Convert.ToInt32(cmbEHr.SelectedValue.ToString());
            EMin = Convert.ToInt32(cmbEMin.SelectedValue.ToString());
            SSHr = Convert.ToInt32(cmbSHr.SelectedValue.ToString());
            SSMin = Convert.ToInt32(cmbSMin.SelectedValue.ToString());
            SEHr = Convert.ToInt32(cmbEHr.SelectedValue.ToString());
            SEMin = Convert.ToInt32(cmbEMin.SelectedValue.ToString());
            StartTime =Convert.ToDateTime( SHr + Sign + SMin);
            EndTime = Convert.ToDateTime(EHr + Sign + EMin);
            SlotStartTime = Convert.ToDateTime(SHr + Sign + SMin);
            SlotEndTime = Convert.ToDateTime(EHr + Sign + EMin);


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
                DataSet ds = obj_TSlot.BindFullGrid(0, cmbBranchName.Text, cmbDayName.Text);

                // ds = obj_Room.BindFullGrid(0);
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
            cmbSHr.Items.Add("11");
            cmbSHr.Items.Add("12");
            cmbSHr.SelectedIndex = 0;

        }
        private void cmbSMin_Items()
        {
            cmbSMin.Items.Add("select");
            int i;
            for (i = 0; i <= 60; i += 5)
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
            for (i = 0; i <= 60; i += 5)
            {
                cmbEMin.Items.Add(i);

            }
            cmbEMin.SelectedIndex = 0;

        }
        #endregion

        /* Created By:- Pranjali Vidhate
        * Created Date :- 7 Nov 2015
        * Purpose:- Binding Slot StartTime & EndTime*/

        #region--------------LoadslotHrMin()-----------------------------------
        private void cmbSSHr_Items()
        {
            cmbSSHr.Items.Add("select");
            int i;
            for (i = 1; i <= 9; i++)
            {
                cmbSSHr.Items.Add(n + i.ToString());

            }
            cmbSSHr.Items.Add("10");
            cmbSSHr.Items.Add("11");
            cmbSSHr.Items.Add("12");
            cmbSSHr.SelectedIndex = 0;

        }
        private void cmbSSMin_Items()
        {
            cmbSSMin.Items.Add("select");
            int i;
            for (i = 0; i <= 60; i += 5)
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
            cmbSEHr.Items.Add("11");
            cmbSEHr.Items.Add("12");
            cmbSEHr.SelectedIndex = 0;

        }
        private void cmbSEMin_Items()
        {
            cmbSEMin.Items.Add("select");
            int i;
            for (i = 0; i <= 60; i += 5)
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

        


    }
}
