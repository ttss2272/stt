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
using BusinessLayer;
namespace SchoolManagement.Teacher
{
    /// <summary>
    /// Interaction logic for Teacher1.xaml
    /// </summary>
    public partial class Teacher1 : Window
    {
        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 07Nov2015
         * Purpose:-
         * StartTime:-
         * EndTime:-
         */
        #region---------------------------------Declare variables Globally-------------------------------------
        int TeacherID, UPID, MaxNoOfMovesInBranch, MaxLecturePerDay, MaxLectPerWeek, MaxNoOfLectInRow, Active, IsDeleted, IsMoreThanOneLecture, IsFirstLecture, IsLastLecture,UpdatedByUserID;
        string TeacherName, TeacherSurname, TeacherShortName,StartFreeTimeHrs, StartFreeTimeMin, EndFreeTimeHrs, EndFreeTimeMin,FreeTimeStart,FreeTimeEnd,UpdatedDate;
        BLTeacher objTeacher = new BLTeacher();
        #endregion

        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 07Nov2015
         * Purpose:-
         * StartTime:-
         * EndTime:-
         */
        #region-------------------------------Main()--------------------------------------------
        public Teacher1()
        {
            InitializeComponent();
            
            ClearFields();
        }
        #endregion

        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 07Nov2015
         * Purpose:-
         * StartTime:-
         * EndTime:-
         */
        #region------------------------------------btnSaveClick()-----------------------------------------------------
        private void btnSave_Click(object sender, RoutedEventArgs e)
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
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 07Nov2015
         * Purpose:-
         * StartTime:-
         * EndTime:-
         */
        #region-------------------------------------btnDeleteClick()--------------------------------------------------------------
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion
        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 07Nov2015
         * Purpose:-
         * StartTime:-
         * EndTime:-
         */
        #region--------------------------------------btnClearClick()--------------------------------------------------------------
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
        #endregion
        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 07Nov2015
         * Purpose:-
         * StartTime:-
         * EndTime:-
         */
        #region-------------------------------------------ClearFields()-----------------------------------------------------------
        private void ClearFields()
        {
            txtName.Text = "";
            txtSurname.Text = "";
            txtShortName.Text = "";
            TimingHrs();
            TimingMin();
            MaxNoOfMovesInBranches();
            MaxLectPerDay();
            MaxLectPerWeek1();
            BindYesNo();
            MaxLectInRow();
            UPID = 0;
            BindGrid();
            btnDelete.IsEnabled = false;
            btnSave.Content="Save"
        }
        #endregion

        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 07Nov2015
         * Purpose:-
         * StartTime:-
         * EndTime:-
         */
        #region-------------------------------------------BindTimingHrs---------------------------------
        private void TimingHrs()
        {
            cmbFreeTimeStartHrs.Items.Add("Select");
            cmbFreeTimeEndHrs.Items.Add("Select");
            int i;
            for (i = 1; i <= 24; i++)
            {
                cmbFreeTimeStartHrs.Items.Add(i);
                cmbFreeTimeEndHrs.Items.Add(i);

            }
            cmbFreeTimeStartHrs.SelectedIndex = 0;
            cmbFreeTimeEndHrs.SelectedIndex = 0;
 
        }
        #endregion


        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 07Nov2015
         * Purpose:-
         * StartTime:-
         * EndTime:-
         */
        #region-------------------------------------------BindTimingMins---------------------------------
        private void TimingMin()
        {
            cmbFreeTimeStartMin.Items.Add("Select");
            cmbFreeTimeEndMin.Items.Add("Select");
            int i;
            for (i = 0; i <= 59; i++)
            {
                cmbFreeTimeStartMin.Items.Add(i);
                cmbFreeTimeEndMin.Items.Add(i);

            }
            cmbFreeTimeStartMin.SelectedIndex = 0;
            cmbFreeTimeEndMin.SelectedIndex = 0;

        }
        #endregion

        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 07Nov2015
         * Purpose:-
         * StartTime:-
         * EndTime:-
         */
        #region-------------------------------------------MaxNoOfMovesInBranch---------------------------------
        private void MaxNoOfMovesInBranches()
        {
            cmbMaxMoves.Items.Add("Select");
            int i;
            for (i = 0; i <= 4; i++)
            {
                cmbMaxMoves.Items.Add(i);
            }
            cmbMaxMoves.SelectedIndex = 0;
        }
        #endregion

        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 07Nov2015
         * Purpose:-
         * StartTime:-
         * EndTime:-
         */
        #region-------------------------------------------MaxLectPerDay---------------------------------
        private void MaxLectPerDay()
        {
            cmbMaxLectPerDay.Items.Add("Select");
            int i;
            for (i = 1; i <= 6; i++)
            {
                cmbMaxLectPerDay.Items.Add(i);
            }
            cmbMaxLectPerDay.SelectedIndex = 0;
        }
        #endregion

        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 07Nov2015
         * Purpose:-
         * StartTime:-
         * EndTime:-
         */
        #region-------------------------------------------MaxLectInRow---------------------------------
        private void MaxLectInRow()
        {
            cmbMaxNoLectInRow.Items.Add("Select");
            int i;
            for (i = 1; i <= 6; i++)
            {
                cmbMaxNoLectInRow.Items.Add(i);
            }
            cmbMaxNoLectInRow.SelectedIndex = 0;
        }
        #endregion

        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 07Nov2015
         * Purpose:-
         * StartTime:-
         * EndTime:-
         */
        #region-------------------------------------------MaxLectPerWeek---------------------------------
        private void MaxLectPerWeek1()
        {
            cmbMaxLectPerWeek.Items.Add("Select");
            int i;
            for (i = 1; i <= 30; i++)
            {
                cmbMaxLectPerWeek.Items.Add(i);
            }
            cmbMaxLectPerWeek.SelectedIndex = 0;
        }
        #endregion


        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 07Nov2015
         * Purpose:-
         * StartTime:-
         * EndTime:-
         */
        #region-------------------------------------------BindYesNo---------------------------------
        private void BindYesNo()
        {
            cmbAllowMoreLect.Items.Add("Select");
            cmbAllowMoreLect.Items.Add("Yes");
            cmbAllowMoreLect.Items.Add("No");
            cmbAllowMoreLect.SelectedIndex=0;

            cmbFirstLect.Items.Add("Select");
            cmbFirstLect.Items.Add("Yes");
            cmbFirstLect.Items.Add("No");
            cmbFirstLect.SelectedIndex = 0;

            cmbLastLect.Items.Add("Select");
            cmbLastLect.Items.Add("Yes");
            cmbLastLect.Items.Add("No");
            cmbLastLect.SelectedIndex = 0;
        }
        #endregion


        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 07Nov2015
         * Purpose:-
         * StartTime:-
         * EndTime:-
         */

        #region----------------------------Validate()--------------------------------------------
        private bool Validate()
        {
            if (txtName.Text.Trim() == "" || string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Please Enter Name.", "Name Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtName.Focus();
                return false;
            }
            else if (txtSurname.Text.Trim()==""|| string.IsNullOrEmpty(txtSurname.Text))
            {
                MessageBox.Show("Please Enter Surame.", "Surname Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtSurname.Focus();
                return false;
            }
            else if (txtShortName.Text.Trim() == "" || string.IsNullOrEmpty(txtShortName.Text))
            {
                MessageBox.Show("Please Enter Short Name.", "Short Name Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtShortName.Focus();
                return false;
            }
            else if (rdbActive.IsChecked == false && rdbInActive.IsChecked == false)
            {
                MessageBox.Show("Please Select Staus.", "Status Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                rdbActive.Focus();
                return false;
            }
            else if (cmbMaxMoves.SelectedValue.ToString() == "Select")
            {
                MessageBox.Show("Please Select Max No Of Moves In Branch.", "Max No Of Moves", MessageBoxButton.OK, MessageBoxImage.Warning);
                cmbMaxMoves.Focus();
                return false; 
            }
            else if (cmbMaxLectPerDay.SelectedValue.ToString() == "Select")
            {
                MessageBox.Show("Please Select Max No Of Lectuturs Per Day.", "Max No Of Lectures Per Day", MessageBoxButton.OK, MessageBoxImage.Warning);
                cmbMaxLectPerDay.Focus();
                return false; 
            }
            else if (cmbMaxLectPerWeek.SelectedValue.ToString() == "Select")
            {
                MessageBox.Show("Please Select Max No Of Lectutures Per Week.", "Max No Of Lectures Per Week", MessageBoxButton.OK, MessageBoxImage.Warning);
                cmbMaxLectPerWeek.Focus();
                return false;
            }
            else if (cmbMaxNoLectInRow.SelectedValue.ToString() == "Select")
            {
                MessageBox.Show("Please Select Max No Of Lectutures In Row.", "Max No Of Lectures In Row", MessageBoxButton.OK, MessageBoxImage.Warning);
                cmbMaxNoLectInRow.Focus();
                return false;
            }
            else if (cmbFirstLect.SelectedValue.ToString() == "Select")
            {
                MessageBox.Show("Please Select First lecture.", "First Lecture", MessageBoxButton.OK, MessageBoxImage.Warning);
                cmbFirstLect.Focus();
                return false;
            }
            else if (cmbLastLect.SelectedValue.ToString() == "Select")
            {
                MessageBox.Show("Please Select Last lecture.", "Last Lecture", MessageBoxButton.OK, MessageBoxImage.Warning);
                cmbLastLect.Focus();
                return false;
            }
            else if (cmbFreeTimeStartHrs.SelectedValue.ToString() == "Select")
            {
                MessageBox.Show("Please Select Free Time Hours", "Free Time Hours", MessageBoxButton.OK, MessageBoxImage.Warning);
                cmbFreeTimeStartHrs.Focus();
                return false;
            }
            else if (cmbFreeTimeStartMin.SelectedValue.ToString() == "Select")
            {
                MessageBox.Show("Please Select Free Time Minutes", "Free Time Minutes", MessageBoxButton.OK, MessageBoxImage.Warning);
                cmbFreeTimeStartMin.Focus();
                return false;
            }
            else if (cmbFreeTimeEndHrs.SelectedValue.ToString() == "Select")
            {
                MessageBox.Show("Please Select Free Time Hours", "Free Time Hours", MessageBoxButton.OK, MessageBoxImage.Warning);
                cmbFreeTimeEndHrs.Focus();
                return false;
            }
            else if (cmbFreeTimeEndMin.SelectedValue.ToString() == "Select")
            {
                MessageBox.Show("Please Select Free Time Minutes", "Free Time Minutes", MessageBoxButton.OK, MessageBoxImage.Warning);
                cmbFreeTimeEndMin.Focus();
                return false;
            }

            else
            {
                return true;
            }
 
        }
        #endregion

        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 07Nov2015
         * Purpose:-
         * StartTime:-
         * EndTime:-
         */

        #region----------------------------SetParameters()--------------------------------------------
        private void SetParameters()
        
        {
            TeacherID = UPID;
            TeacherName = txtName.Text.Trim();
            TeacherSurname = txtSurname.Text.Trim();
            TeacherShortName = txtShortName.Text.Trim();
            if (rdbActive.IsChecked == true && rdbInActive.IsChecked == false)
            {
                Active = 1;
                IsDeleted = 0;
             
            }
            else if (rdbActive.IsChecked == false && rdbInActive.IsChecked == true)
            {
                Active = 0;
                IsDeleted = 0;
            }

            MaxNoOfMovesInBranch = Convert.ToInt32( cmbMaxMoves.SelectedValue);
            MaxLecturePerDay = Convert.ToInt32(cmbMaxLectPerDay.SelectedValue);
            MaxLectPerWeek = Convert.ToInt32(cmbMaxLectPerWeek.SelectedValue);
            //IsMoreThanOneLecture = Convert.ToString(cmbAllowMoreLect.SelectedValue);
            if (cmbAllowMoreLect.SelectedValue.ToString() == "Yes")
            { 
                IsMoreThanOneLecture=1;
            }
            else if (cmbAllowMoreLect.SelectedValue.ToString() == "No")
            {
                IsMoreThanOneLecture = 0;
            }
                       
            MaxNoOfLectInRow = Convert.ToInt32(cmbMaxNoLectInRow.SelectedValue);
            //IsFirstLecture = Convert.ToString(cmbFirstLect.SelectedValue);
            if (Convert.ToString(cmbFirstLect.SelectedValue) == "Yes")
            {
                IsFirstLecture = 1;
            }
            else if (Convert.ToString(cmbFirstLect.SelectedValue) == "No")
            {
                IsFirstLecture = 0;
            }
            //IsLastLecture = Convert.ToString(cmbLastLect.SelectedValue);
            if (Convert.ToString(cmbLastLect.SelectedValue) == "Yes")
            {
                IsLastLecture = 1;
            }
            else if (Convert.ToString(cmbLastLect.SelectedValue) == "No")
            { 
                IsLastLecture=0;
            }
            
            FreeTimeStart = cmbFreeTimeStartHrs.SelectedValue.ToString();
            FreeTimeStart +=":"+ cmbFreeTimeStartMin.SelectedValue.ToString();

            FreeTimeEnd = cmbFreeTimeEndHrs.SelectedValue.ToString();
            FreeTimeEnd += ":" + cmbFreeTimeEndMin.SelectedValue.ToString();
            UpdatedByUserID = 1;
            UpdatedDate = DateTime.Now.ToString();
            
        }
        #endregion

        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 07Nov2015
         * Purpose:-
         * StartTime:-
         * EndTime:-
         */

        #region---------------------------------------------SaveDeltails()-------------------------------------------
        private void SaveDetails()
        {
            string Result = objTeacher.SaveTeacher(TeacherID, TeacherName, TeacherSurname, TeacherShortName, MaxNoOfMovesInBranch, MaxLecturePerDay, MaxLectPerWeek, IsMoreThanOneLecture, MaxNoOfLectInRow, IsFirstLecture, IsLastLecture, FreeTimeStart, FreeTimeEnd, UpdatedByUserID, UpdatedDate, Active, IsDeleted);
                if (Result == "Save Sucessfully...!!!" || Result == "Updated Sucessfully...!!!")
                {
                     MessageBox.Show(Result, "Save SucessFull", MessageBoxButton.OK, MessageBoxImage.Information);
                     ClearFields();
                }
                else
                {
                    MessageBox.Show(Result, "Error To Save", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
        }
        #endregion


        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 07Nov2015
         * Purpose:-
         * StartTime:-
         * EndTime:-
         */
        #region-------------------------------------BindGrid()-------------------------------------------------------------------
        private void BindGrid()
        {
            DataSet ds = objTeacher.GetTeacher(0);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dgvTeacher.ItemsSource = ds.Tables[0].DefaultView;
            }
            else
            {
                dgvTeacher.ItemsSource = null;
                MessageBox.Show("Data Not Found", "Message");
                
            }
        }
        #endregion

        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 07Nov2015
         * Purpose:-
         * StartTime:-
         * EndTime:-
         */
        #region----------------------------------------Row Double Click()-------------------------------------------------------------------
        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                object item = dgvTeacher.SelectedItem;
                UPID = Convert.ToInt32(((System.Data.DataRowView)(dgvTeacher.CurrentItem)).Row.ItemArray[0].ToString());
                txtName.Text = ((System.Data.DataRowView)(dgvTeacher.CurrentItem)).Row.ItemArray[1].ToString();
                txtSurname.Text = ((System.Data.DataRowView)(dgvTeacher.CurrentItem)).Row.ItemArray[2].ToString();
                txtShortName.Text = ((System.Data.DataRowView)(dgvTeacher.CurrentItem)).Row.ItemArray[3].ToString();
                
                cmbMaxMoves.Text =  ((System.Data.DataRowView)(dgvTeacher.CurrentItem)).Row.ItemArray[4].ToString();
                cmbMaxLectPerDay.Text = ((System.Data.DataRowView)(dgvTeacher.CurrentItem)).Row.ItemArray[5].ToString();
                cmbMaxLectPerWeek.Text = ((System.Data.DataRowView)(dgvTeacher.CurrentItem)).Row.ItemArray[6].ToString();
                cmbMaxNoLectInRow.Text = ((System.Data.DataRowView)(dgvTeacher.CurrentItem)).Row.ItemArray[7].ToString();
                cmbFirstLect.Text = ((System.Data.DataRowView)(dgvTeacher.CurrentItem)).Row.ItemArray[8].ToString();
                cmbLastLect.Text = ((System.Data.DataRowView)(dgvTeacher.CurrentItem)).Row.ItemArray[9].ToString();
                cmbAllowMoreLect.Text = ((System.Data.DataRowView)(dgvTeacher.CurrentItem)).Row.ItemArray[14].ToString();
               
                 bool act = Convert.ToBoolean(((System.Data.DataRowView)(dgvTeacher.CurrentItem)).Row.ItemArray[13].ToString());
                //bool del = Convert.ToBoolean(((System.Data.DataRowView)(dgvTeacher.CurrentItem)).Row.ItemArray[11].ToString());
                 string time = ((System.Data.DataRowView)(dgvTeacher.CurrentItem)).Row.ItemArray[10].ToString();
                 string [] a= time.Split(':');
                 cmbFreeTimeStartHrs.Text = a[0];
                 if (a[1] == "00")
                 { cmbFreeTimeStartMin.Text = "0"; }
                 else
                 {cmbFreeTimeStartMin.Text = a[1];}
                 
                 string ENDtime = ((System.Data.DataRowView)(dgvTeacher.CurrentItem)).Row.ItemArray[11].ToString();
                 string[] b = ENDtime.Split(':');
                 cmbFreeTimeEndHrs.Text = b[0];
                if (b[1]=="00")
                {cmbFreeTimeEndMin.Text="0";}
                else
                {cmbFreeTimeEndMin.Text = b[1];}
                 
                if (act == true )
                {
                    rdbActive.IsChecked = true;
                }
                else if (act == false)
                {
                    rdbInActive.IsChecked = false;
                }
                btnDelete.IsEnabled = true;
                btnSave.Content = "Update";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception Error");
            }
        }
        #endregion
    }
}
