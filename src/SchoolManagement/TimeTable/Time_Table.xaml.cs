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
    public partial class Time_Table : Window
    {
        BLAddBranch obj_Branch = new BLAddBranch();
        BLAddClass obj_Class = new BLAddClass();
        BLSubject obj_Subject = new BLSubject();
        BLBatch obj_Batch = new BLBatch();
        BLTeacher obj_Teacher = new BLTeacher();
        BLRoom objRoom = new BLRoom();
        int TeacherId;
        public Time_Table()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
            this.Width = System.Windows.SystemParameters.PrimaryScreenWidth;
            this.Height = System.Windows.SystemParameters.PrimaryScreenHeight;
        }

        #region-----------------btnSave_Click------------
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

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
            DataSet ds = objRoom.BindRoomDropDown(0);

            if (ds.Tables[0].Rows.Count > 0)
            {
                cbRoomName.DataContext = null;

                cbRoomName.DataContext = ds.Tables[0].DefaultView;
                cbRoomName.DisplayMemberPath = ds.Tables[0].Columns["RoomName"].ToString();
                cbRoomName.SelectedValuePath = ds.Tables[0].Columns["RoomID"].ToString();
              

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
        }
        #endregion
    }
}
