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
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace SchoolManagement.TimeTable
{
    /// <summary>
    /// Interaction logic for Time_Table.xaml
    /// </summary>
    #region-------------------Varible Declartion--------------
    public partial class Time_Table : Window
    {
        BLTimeTable objTimeTable = new BLTimeTable();
        BLAddBranch obj_Branch = new BLAddBranch();
        BLAddClass obj_Class = new BLAddClass();
        BLSubject obj_Subject = new BLSubject();
        BLBatch obj_Batch = new BLBatch();
        BLTeacher objTeacher = new BLTeacher();
        BLRoom objRoom = new BLRoom();

        int TimeTableID, BatchID, RoomID, ClassID, TeacherID, TeacherSubjectID, BranchID, UpID, UpdatedByUserID, IsActive, IsDeleted;
        String UpdatedDate, Day, LectStartTime, LectEndTime, CRM;

    #endregion

        #region--------------Time_Table------------------
        public Time_Table()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
            this.Width = System.Windows.SystemParameters.PrimaryScreenWidth;
            this.Height = System.Windows.SystemParameters.PrimaryScreenHeight;
            ClearFields();
        }
        #endregion

        #region-----------------btnSave_Click------------
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Validate())
                {
                    Setparameter();
                    string Result = objTimeTable.SaveTimeTable(TimeTableID, BatchID, RoomID, TeacherSubjectID, Day, LectStartTime, LectEndTime, UpdatedByUserID, UpdatedDate, IsActive, IsDeleted);
                    if (Result == "Save Sucessfully...!!!" || Result == "Updated Sucessfully...!!!")
                    {
                        MessageBox.Show(Result, "Save Sucessfull", MessageBoxButton.OK, MessageBoxImage.Information);
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show(Result, "Error To Save", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion

        #region---------------------------------Setparamerter()-------------------------------------------
        public void Setparameter()
        {
            UpID = 0;
            if (btnSave.Content.ToString() == "Save")
            {
                TimeTableID = UpID;
            }
            else if (btnSave.Content.ToString() == "Update")
            {
                TimeTableID = TimeTableID;
            }
            BranchID = Convert.ToInt32(cbBranchName.SelectedValue.ToString());
        }
        #endregion

        #region-------------cmbDayName_Items-------------------------------
        private void cmbDayName_Items()
        {
            cmbDayName.Items.Add("Select");
            cmbDayName.Items.Add("Monday");
            cmbDayName.Items.Add("Tuesday");
            cmbDayName.Items.Add("Wednesday");
            cmbDayName.Items.Add("Thursday");
            cmbDayName.Items.Add("Friday");
            cmbDayName.Items.Add("Saturday");
            cmbDayName.SelectedIndex = 0;

        }
        #endregion

        #region-------------------------------ClearFields()----------------------------------------
        public void ClearFields()
        {
            cbBranchName.IsEnabled = true;
            EnableUpperPart();
            cbBranchName.SelectedIndex = 0;
            cbClassName.SelectedIndex = 0;
            cbBatchName.SelectedIndex = 0;
            cbTimeSlot.SelectedIndex = 0;
            cbRoomName.SelectedIndex = 0;
            cmbDayName.SelectedIndex = 0;
            cbSubjectName.SelectedIndex = 0;
            cbTeacherName.SelectedIndex = 0;
            btnSave.Content = "Save";
            btnDelete.IsEnabled = false;
        }
        #endregion

        #region----------------------------------------------------------------EnableDropdown()------------------------------------------------
        private void EnableUpperPart()
        {
            cbBranchName.IsEnabled = true;
            //gbSame.Visibility = Visibility.Hidden;
            cbClassName.IsEnabled = false;
            cbSubjectName.IsEnabled = false;
            cbBatchName.IsEnabled = false;
            cbTeacherName.IsEnabled = false;
            cbRoomName.IsEnabled = false;
            cmbDayName.IsEnabled = false;
            cbTimeSlot.IsEnabled = false;
            btnSave.IsEnabled = false;
            btnClear.IsEnabled = false;
            btnGo.Content = "Go";

        }
        #endregion

        #region-------------bindbranch()-----------
        private void BindBranchName()
        {
            try
            {
                DataSet ds = obj_Branch.BindBranchName();


                if (ds.Tables[0].Rows.Count > 0)
                {

                    cbBranchName.DisplayMemberPath = ds.Tables[0].Columns["BranchName"].ToString();
                    cbBranchName.SelectedValuePath = ds.Tables[0].Columns["BranchID"].ToString();
                    cbBranchName.DataContext = ds.Tables[0].DefaultView;
                    cbBranchName.SelectedValue = "0";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion

        #region------------------------BindClassName()---------------------------------------
        private void BindClassName()
        {
            try
            {
                BranchID = Convert.ToInt32(cbBranchName.SelectedValue);
                DataSet ds = obj_Class.BindClassName(BranchID);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    cbClassName.DataContext = null;
                    cbClassName.DisplayMemberPath = ds.Tables[0].Columns["ClassName"].ToString();
                    cbClassName.SelectedValuePath = ds.Tables[0].Columns["ClassID"].ToString();
                    cbClassName.DataContext = ds.Tables[0].DefaultView;
                    cbClassName.SelectedValue = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion

        #region------------------------BindSubjectName()---------------------------------
        private void BindSubjectName()
        {
            try
            {
                BatchID = Convert.ToInt32(cbClassName.SelectedValue);
                DataSet ds = obj_Subject.loadSubjectName(BatchID);


                if (ds.Tables[0].Rows.Count > 0)
                {
                    cbSubjectName.DataContext = null;
                    cbSubjectName.DisplayMemberPath = ds.Tables[0].Columns["SubjectName"].ToString();
                    cbSubjectName.SelectedValuePath = ds.Tables[0].Columns["SubjectID"].ToString();
                    cbSubjectName.DataContext = ds.Tables[0].DefaultView;
                    cbSubjectName.SelectedValue = "0";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
        #endregion

        #region------------------------BindBatchName()---------------------------------
        private void BindBatchName()
        {
            try
            {
                ClassID = Convert.ToInt32(cbClassName.SelectedValue);
                DataSet ds = obj_Batch.loadBatchName(ClassID);
                if (ds.Tables[0].Rows.Count > 0)
                {

                    cbBatchName.DataContext = null;
                    cbBatchName.DisplayMemberPath = ds.Tables[0].Columns["BatchName"].ToString();
                    cbBatchName.SelectedValuePath = ds.Tables[0].Columns["BatchID"].ToString();
                    cbBatchName.DataContext = ds.Tables[0].DefaultView;
                    cbBatchName.SelectedValue = "0";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
        #endregion

        #region-----------------BindTeacher()----------------------------------
        private void BindTeacher()
        {
            DataSet ds = objTeacher.BindTeacherDropDown(0);

            if (ds.Tables[0].Rows.Count > 0)
            {
                cbTeacherName.DataContext = null;

                cbTeacherName.DataContext = ds.Tables[0].DefaultView;
                cbTeacherName.DisplayMemberPath = ds.Tables[0].Columns["TeacherName"].ToString();
                cbTeacherName.SelectedValuePath = ds.Tables[0].Columns["TeacherID"].ToString();


                cbTeacherName.SelectedValue = "0";
            }
        }
        #endregion

        #region----------------BindRoom()----------------------------
        private void BindRoom()
        {
            try
            {
                BranchID = Convert.ToInt32(cbBranchName.SelectedValue);
                DataSet ds = objRoom.BindRoomDropDown(BranchID);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    cbRoomName.DataContext = null;
                    cbRoomName.DisplayMemberPath = ds.Tables[0].Columns["RoomName"].ToString();
                    cbRoomName.SelectedValuePath = ds.Tables[0].Columns["RoomID"].ToString();
                    cbRoomName.DataContext = ds.Tables[0].DefaultView;

                    cbRoomName.SelectedValue = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion

        #region------------BindTimeSlot---------------
        private void BindTimeSlot()
        {
            try
            {
                //Day = Convert.ToString(cmbDayName.SelectedValue);
                //DataSet ds = objTimeSlot.BindTimeSlot(Day);
                //if (ds.Tables[0].Rows.Count > 0)
                //{
                //    cbTimeSlot.DataContext = null;
                //    cbTimeSlot.DisplayMemberPath = ds.Tables[0].Columns["Day"].ToString();
                //    cbTimeSlot.DataContext = ds.Tables[0].DefaultView;
                //    cbTimeSlot.SelectedValue = "0";
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion

        #region------------BindDay----------------------
        private void BindDay()
        {
            try
            {
                BatchID = Convert.ToInt32(cbBranchName.SelectedValue);
                RoomID = Convert.ToInt32(cbRoomName.SelectedValue);
                TeacherID = Convert.ToInt32(cbTeacherName.SelectedValue);
                DataSet ds = objTimeTable.BindDay(BatchID,RoomID,TeacherID);                
                if (ds.Tables[0].Rows.Count > 0)
                {
                    cmbDayName.DataContext = null;
                    cmbDayName.DisplayMemberPath = ds.Tables[0].Columns["Day"].ToString();
                    cmbDayName.DataContext = ds.Tables[0].DefaultView;
                    cmbDayName.SelectedValue = "0";
                }               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion

        #region-----------------Window_Loaded----------------------
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BindBranchName();
            //cmbDayName_Items();
            BindSubjectName();
            BindBatchName();
            BindTeacher();
            BindRoom();
        }
        #endregion

        #region-----------------------------------Validation------------------------------------------
        public bool Validate()
        {
            if (cbBranchName.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Branch Name");
                cbBranchName.Focus();
                return false;
            }
            else if (cbClassName.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Class Name");
                cbClassName.Focus();
                return false;
            }
            else if (cbSubjectName.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Subject Name");
                cbSubjectName.Focus();
                return false;
            }
            else if (cbBatchName.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Batch Name");
                cbBatchName.Focus();
                return false;
            }
            else if (cbTeacherName.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Teacher Name");
                cbTeacherName.Focus();
                return false;
            }
            else if (cbRoomName.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Room Name");
                cbRoomName.Focus();
                return false;
            }
            else if (cmbDayName.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Day");
                cmbDayName.Focus();
                return false;
            }
            else if (cbTimeSlot.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Time from TimeSlot");
                cbTimeSlot.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region-------------------------------Go()--------------------------------------------------
        private void btnGo_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cbBranchName.SelectedValue.ToString() != "0" && cbBranchName.SelectedItem.ToString() != "Select")
                {
                    if (btnGo.Content.ToString() == "Go")
                    {
                        DisableUpperPart();
                    }
                    else if (btnGo.Content.ToString() == "Change")
                    {
                        EnableUpperPart();
                        ClearData();
                    }
                }
                else
                {
                    MessageBox.Show("Please Select Branch Name");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion

        #region--------------------------------------------------DisableUpperPart()--------------------------------------------------
        private void DisableUpperPart()
        {
            cbBranchName.IsEnabled = false;

            cbClassName.IsEnabled = true;
            cbBatchName.IsEnabled = true;
            cbSubjectName.IsEnabled = true;
            cbRoomName.IsEnabled = true;
            cmbDayName.IsEnabled = true;
            cbTeacherName.IsEnabled = true;
            cbTimeSlot.IsEnabled = true;
            btnSave.IsEnabled = true;
            btnClear.IsEnabled = true;
            btnGo.Content = "Change";
        }
        #endregion

        #region---------------------------------------------------------Clears()-------------------------------------------------------
        private void ClearData()
        {
            cbClassName.SelectedValue = "0";
            cbBatchName.SelectedValue = "0";
            cbSubjectName.SelectedValue = "0";
            cbRoomName.SelectedValue = "0";
            cmbDayName.SelectedValue = "0";
            cbTeacherName.SelectedValue = "0";
            cbTimeSlot.SelectedValue = "0";
            btnSave.Content = "Save";
            rdoActive.IsChecked = true;
            btnDelete.IsEnabled = false;
            BindTeacher();
            cmbDayName_Items();
            //BindGrid();
            //UncheckAllCheckBoxes();
            // gbSame.Visibility = Visibility.Hidden;
            //EnableDropdown();
        }
        #endregion

        #region-------------------btnClear_Click-----------------
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

        #region---------cbBranchName_SelectionChanged------------
        private void cbBranchName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BindClassName();
            BindRoom();
        }
        #endregion

        #region-----------cbClassName_SelectionChanged------------
        private void cbClassName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BindBatchName();
        }
        #endregion

        #region--------------cbBatchName_SelectionChanged
        private void cbBatchName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (rdoClassWise.IsChecked == true)
            {
                //BindDay();
            }
            else
            {
                BindSubjectName();
            }
        }

        #endregion

        private void cbRoomName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (rdoRoomWise.IsChecked == true)
            {
                //BindDay();
            }
            else
            {

            }
        }
    }
}
    



