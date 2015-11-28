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
        BLTeacher obj_Teacher = new BLTeacher();
        BLRoom objRoom = new BLRoom();

        int TimeTableID,TeacherId,BranchId,UpID, UpdatedByUserID, IsActive, IsDeleted;
        String UpdatedDate;

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
                    string Result = objTimeTable.SaveTimeTable( UpdatedByUserID, UpdatedDate, IsActive, IsDeleted);
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
            BranchId = Convert.ToInt32(cbBranchName.SelectedValue.ToString());
        }
           #endregion

        #region-------------LoadDayNames-------------------------------
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
            EnableDropdown();
            //cbBranchName.SelectedIndex = 0;                  
            btnSave.Content = "Save";
            btnDelete.IsEnabled = false;            
        }
        #endregion

         #region----------------------------------------------------------------EnableDropdown()------------------------------------------------
        private void EnableDropdown()
        {
            //gbSame.Visibility = Visibility.Hidden;
            cbClassName.IsEnabled = true;
            cbSubjectName.IsEnabled = true;
            cbBatchName.IsEnabled = true;
            cbTeacherName.IsEnabled = true;
            cbRoomName.IsEnabled = true;
            
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
                DataSet ds = obj_Class.BindClassName();


                if (ds.Tables[0].Rows.Count > 0)
                {
                    cbClassName.DataContext = ds.Tables[0].DefaultView;
                    cbClassName.DisplayMemberPath = ds.Tables[0].Columns["ClassName"].ToString();
                    cbClassName.SelectedValuePath = ds.Tables[0].Columns["ClassID"].ToString();

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
                DataSet ds = obj_Subject.BindSubjectName();


                if (ds.Tables[0].Rows.Count > 0)
                {
                    cbSubjectName.DataContext = ds.Tables[0].DefaultView;
                    cbSubjectName.DisplayMemberPath = ds.Tables[0].Columns["SubjectName"].ToString();
                    cbSubjectName.SelectedValuePath = ds.Tables[0].Columns["SubjectID"].ToString();

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
                DataSet ds = obj_Batch.BindBatchName();


                if (ds.Tables[0].Rows.Count > 0)
                {
                    cbBatchName.DataContext = ds.Tables[0].DefaultView;
                    cbBatchName.DisplayMemberPath = ds.Tables[0].Columns["BatchName"].ToString();
                    cbBatchName.SelectedValuePath = ds.Tables[0].Columns["BatchID"].ToString();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
        #endregion

        #region--------------------BindTeacher()-----------------------------
        private void BindTeacher()
        {
            DataSet ds = obj_Teacher.BindTeacherDropDown(0);

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
            BranchId = Convert.ToInt32(cbBranchName.SelectedValue);
            DataSet ds = objRoom.BindRoomDropDown(BranchId);

            if (ds.Tables[0].Rows.Count > 0)
            {
                cbRoomName.DataContext = null;
                cbRoomName.DisplayMemberPath = ds.Tables[0].Columns["RoomName"].ToString();
                cbRoomName.SelectedValuePath = ds.Tables[0].Columns["RoomID"].ToString();
                cbRoomName.DataContext = ds.Tables[0].DefaultView;

                cbRoomName.SelectedValue = "0";
            }
        }
        #endregion

        #region-----------------Window_Loaded----------------------
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BindBranchName();
            BindClassName();
            BindSubjectName();
            BindBatchName();
            BindTeacher();
            BindRoom();
            cmbDayName_Items();
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
                if (cbBranchName.SelectedValue.ToString() == "0")
                {
                    MessageBox.Show("Please Select Branch.");
                }
                else
                {
                    gbTTDetails.IsEnabled = false;
                    Clears();
                    //GetTimeTableDetails(Convert.ToInt32(cbBranchName.SelectedValue));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
          #endregion

        #region---------------------------------------------------------Clears()-------------------------------------------------------
        private void Clears()
        {

            BindClassName();
            BindSubjectName();
            BindBatchName();
            BindTeacher();
            BindRoom();
            cmbDayName_Items();
            //BindGrid();
            //UncheckAllCheckBoxes();
           // gbSame.Visibility = Visibility.Hidden;
            //EnableDropdown();

        }
        #endregion
    }
}
