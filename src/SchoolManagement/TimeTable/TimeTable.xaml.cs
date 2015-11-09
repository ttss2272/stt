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
    /// Interaction logic for TimeTable.xaml
    /// </summary>
    public partial class TimeTable : Window
    {
        BLTimeTable obj_TimeTable = new BLTimeTable();
        BLAddClass obj_Class = new BLAddClass();
        BLAddBranch obj_Branch = new BLAddBranch();
        BLAddBranch obj_AddBranch = new BLAddBranch();
        BLSubject obj_Subject = new BLSubject();
        BLBatch obj_Batch = new BLBatch();
        BLRoom obj_Room = new BLRoom();
        BLTeacher obj_Teacher = new BLTeacher();
       
        public TimeTable()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
            this.Width = System.Windows.SystemParameters.PrimaryScreenWidth;
            this.Height = System.Windows.SystemParameters.PrimaryScreenHeight;
        }

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

        #region------------------------BindBranchName()---------------------------------------
        private void BindBranchName()
        {
            try
            {
                DataSet ds = obj_Branch.BindBranchName();


                if (ds.Tables[0].Rows.Count > 0)
                {
                    cbBranchName.DataContext = ds.Tables[0].DefaultView;
                    cbBranchName.DisplayMemberPath = ds.Tables[0].Columns["BranchName"].ToString();
                    cbBranchName.SelectedValuePath = ds.Tables[0].Columns["BranchID"].ToString();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
        #endregion

        #region--------------------bindInstituteName()---------------
        private void bindInstituteName()
        {
            try
            {
                DataSet ds = obj_AddBranch.BindInstituteName();


                if (ds.Tables[0].Rows.Count > 0)
                {
                    cbInstituteName.DataContext = ds.Tables[0].DefaultView;
                    cbInstituteName.DisplayMemberPath = ds.Tables[0].Columns["InstituteName"].ToString();
                    cbInstituteName.SelectedValuePath = ds.Tables[0].Columns["InstituteName"].ToString();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BindClassName();
            bindInstituteName();
            BindBranchName();                                
            BindBatchName();
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

        #region------------------------BindRoomName()---------------------------------
        private void BindRoomName()
        {
            if (cbBatchName.Text != "")
            {

                try
                {
                    DataSet ds = obj_Room.BindRoomName();


                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        cbRoomName.DataContext = ds.Tables[0].DefaultView;
                        cbRoomName.DisplayMemberPath = ds.Tables[0].Columns["RoomName"].ToString();
                        cbRoomName.SelectedValuePath = ds.Tables[0].Columns["RoomID"].ToString();

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }

        }
        #endregion

        #region------------------------BindTeacherName()---------------------------------
        private void BindTeacherName()
        {
            try
            {
                DataSet ds = obj_Teacher.BindTeacherName();


                if (ds.Tables[0].Rows.Count > 0)
                {
                    cbTeacherName.DataContext = ds.Tables[0].DefaultView;
                    cbTeacherName.DisplayMemberPath = ds.Tables[0].Columns["TeacherName"].ToString();
                    cbTeacherName.SelectedValuePath = ds.Tables[0].Columns["TeacherID"].ToString();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
        #endregion

        private void cbBatchName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BindRoomName();
        }

        private void cbRoomName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BindSubjectName();
        }

        private void cbSubjectName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BindTeacherName();
        }
    }
}
