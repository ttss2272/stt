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
        /*
         * Created By:-pravin
         * Updated By:- PriTesh D. Sortee
         * Created Date:-03 Dec 2015
         * Updated Date:- 03 Dec 2015
         * Purpose:
         * 
         */
        #region-------------------------------------------------------Declare Variables---------------------------------------------
        BLTimeTable objTimeTable = new BLTimeTable();
        BLAddBranch obj_Branch = new BLAddBranch();
        BLAddClass obj_Class = new BLAddClass();
        BLSubject obj_Subject = new BLSubject();
        BLBatch obj_Batch = new BLBatch();
        BLTeacher objTeacher = new BLTeacher();
        BLRoom objRoom = new BLRoom();


        int TimeTableID, BatchID, RoomID, ClassID, TeacherID, TeacherSubjectID, SubjectID, BranchID, BatchAvailableID, UpID,UPID, TimeTableDetailID, UpdatedByUserID, IsActive, IsDeleted;
        String UpdatedDate, LectStartTime, LectEndTime, SlotTime, Day,Date,ViewType;
       // DateTime TTStartDate;

        #endregion
        /*
        * Created By:-pravin
        * Updated By:- 
        * Created Date:-03 Dec 2015
        * Updated Date:- 
        * Purpose:
        * 
        */

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
        /*
        * Created By:-Pravin
        * Updated By:- 
        * Created Date:-04 Dec 2015
        * Updated Date:- 
        * Purpose:-
        * 
        */
        #region-----------------btnSave_Click------------
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Validate())
                {
                    Setparameter();
                    string Result = objTimeTable.SaveTimeTable(TimeTableID, TimeTableDetailID,Date, BatchID, RoomID, Day, LectStartTime, LectEndTime, TeacherSubjectID, UpdatedByUserID, UpdatedDate, IsActive, IsDeleted,ViewType);
                    if ((Result == "Save Sucessfully...!!!") || (Result == "Updated Sucessfully...!!!"))
                    {
                        MessageBox.Show(Result, "Save Sucessfull", MessageBoxButton.OK, MessageBoxImage.Information);
                        Time_Table tt = new Time_Table();
                        Close();
                        tt.Show();
                        //ClearFields();
                        //BindGridviewTimeTable();
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

        /*
        * Created By:-Pravin
        * Updated By:- 
        * Created Date:-04 Dec 2015
        * Updated Date:- 
        * Purpose:-
        */
        #region---------------------------------Setparamerter()-------------------------------------------
        public void Setparameter()
        {
            if (rdoClassWise.IsChecked == true)
            {
                TimeTableID = UpID;
                TimeTableDetailID = UPID;
                //BranchID = Convert.ToInt32(cbBranchName.SelectedValue.ToString());
                //ClassID = Convert.ToInt32(cbClassName.SelectedValue.ToString());
                BatchID = Convert.ToInt32(cbBatchName.SelectedValue.ToString());
                Date = dpTTStartDate.SelectedDate.Value.ToString("yyyy-MM-dd");
                TeacherSubjectID = Convert.ToInt32(cbTeacherName.SelectedValue.ToString());
                RoomID = Convert.ToInt32(cbRoomName.SelectedValue.ToString());
                //TeacherID = Convert.ToInt32(cbTeacherName.SelectedValue.ToString());
                Day = cmbDayName.Text;
                SlotTime = cbTimeSlot.Text;
                string[] a = SlotTime.Split('-');
                LectStartTime = a[0];
                LectEndTime = a[1];
                UpdatedByUserID = 1;
                UpdatedDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
                ViewType = "ClassWise";
                if (rdoActive.IsChecked == true)
                {
                    IsActive = 1;
                    IsDeleted = 0;
                }
                else if (rdoInActive.IsChecked == true)
                {
                    IsActive = 0;
                    IsDeleted = 0;
                }

            }
            if (rdoRoomWise.IsChecked == true)
            {
                TimeTableID = UpID;
                TimeTableDetailID = UPID;
                //BranchID = Convert.ToInt32(cbBranchName.SelectedValue.ToString());
                //ClassID = Convert.ToInt32(cbClassName.SelectedValue.ToString());
                BatchID = Convert.ToInt32(cbBatchName1.SelectedValue.ToString());
                Date = dpTTStartDate.SelectedDate.Value.ToString("yyyy-MM-dd");
                TeacherSubjectID = Convert.ToInt32(cbTeacherName1.SelectedValue.ToString());
                RoomID = Convert.ToInt32(cbRoomName1.SelectedValue.ToString());
               // TeacherID = Convert.ToInt32(cbTeacherName1.SelectedValue.ToString());
                Day = cbDay.Text;
                SlotTime = cbTimeSlot1.Text;
                string[] a = SlotTime.Split('-');
                LectStartTime = a[0];
                LectEndTime = a[1];
                UpdatedByUserID = 1;
                UpdatedDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
                ViewType = "RoomWise";
                if (rdoActive1.IsChecked == true)
                {
                    IsActive = 1;
                    IsDeleted = 0;
                }
                else if (rdoInActive1.IsChecked == false)
                {
                    IsActive = 0;
                    IsDeleted = 0;
                }
            }
            if (rdoTeacherWise.IsChecked == true)
            {
                TimeTableID = UpID;
                TimeTableDetailID = UPID;
                //BranchID = Convert.ToInt32(cbBranchName.SelectedValue.ToString());
                //ClassID = Convert.ToInt32(cbClassName.SelectedValue.ToString());
                BatchID = Convert.ToInt32(cbBatchName2.SelectedValue.ToString());
                Date = dpTTStartDate.SelectedDate.Value.ToString("yyyy-MM-dd");
                TeacherSubjectID = Convert.ToInt32(cbSubjectName2.SelectedValue.ToString());
                RoomID = Convert.ToInt32(cbRoomName2.SelectedValue.ToString());
               // TeacherID = Convert.ToInt32(cbTeacherName2.SelectedValue.ToString());
                Day = cbDay2.Text;
                SlotTime = cbTimeSlot2.Text;
                string[] a = SlotTime.Split('-');
                LectStartTime = a[0];
                LectEndTime = a[1];
                UpdatedByUserID = 1;
                UpdatedDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
                ViewType = "TeacherWise";
                if (rdoActive2.IsChecked == true)
                {
                    IsActive = 1;
                    IsDeleted = 0;
                }
                else if (rdoInActive2.IsChecked == false)
                {
                    IsActive = 0;
                    IsDeleted = 0;
                }
            }
        }        
        
        #endregion       

        /*
        * Created By:-Pravin
        * Updated By:- 
        * Created Date:-03 Dec 2015
        * Updated Date:- 
        * Purpose:-
        */
        #region-------------------------------ClearFields()----------------------------------------
        public void ClearFields()
        {
            UpID = 0;
            cbBranchName.IsEnabled = true;
            EnableUpperPart();
            cbBranchName.SelectedIndex = 0;
            dpTTStartDate.Text = "";
            cbClassName.SelectedIndex = 0;
            cbBatchName.SelectedIndex = 0;
            cbTimeSlot.SelectedIndex = 0;
            cbRoomName.SelectedIndex = 0;
            cmbDayName.SelectedIndex = 0;
            cbSubjectName.SelectedIndex = 0;
            cbTeacherName.SelectedIndex = 0;

            cbClassName1.SelectedIndex = 0;
            cbBatchName1.SelectedIndex = 0;
            cbTimeSlot1.SelectedIndex = 0;
            cbRoomName1.SelectedIndex = 0;
            cbDay.SelectedIndex = 0;
            cbSubjectName1.SelectedIndex = 0;
            cbTeacherName1.SelectedIndex = 0;

            cbClassName2.SelectedIndex = 0;
            cbBatchName2.SelectedIndex = 0;
            cbTimeSlot2.SelectedIndex = 0;
            cbRoomName2.SelectedIndex = 0;
            cbDay2.SelectedIndex = 0;
            cbSubjectName2.SelectedIndex = 0;
            cbTeacherName2.SelectedIndex = 0;

            btnSave.Content = "Save";
            rdoActive.IsChecked = true;
            rdoClassWise.IsChecked = true;
            rdoActive1.IsChecked = true;
            rdoActive2.IsChecked = true;
        }
        #endregion

        /*
        * Created By:-Pravin
        * Updated By:- PriTesh D. Sortee
        * Created Date:-
        * Updated Date:- 03 Dec 2015
        * Purpose:-
         * Updated:- Enabled Radio Button AND Calender on go button
        */
        #region----------------------------EnableUpperPart()---------------------------
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
            //Enable Radio Button
            rdoClassWise.IsEnabled = true;
            rdoRoomWise.IsEnabled = true;
            rdoTeacherWise.IsEnabled = true;
            //Enable Calender
            dpTTStartDate.IsEnabled = true;
            btnGo.Content = "Go";
            cbClassName1.IsEnabled = false;
            cbClassName2.IsEnabled = false;
            cbBatchName1.IsEnabled = false;
            cbBatchName2.IsEnabled = false;
            cbSubjectName1.IsEnabled = false;
            cbSubjectName2.IsEnabled = false;
            cbTeacherName1.IsEnabled = false;
            cbTeacherName2.IsEnabled = false;
            cbRoomName1.IsEnabled = false;
            cbRoomName2.IsEnabled = false;
            cbDay.IsEnabled = false;
            cbDay2.IsEnabled = false;
            cbTimeSlot1.IsEnabled = false;
            cbTimeSlot2.IsEnabled = false;
        }
        #endregion

        /*
        * Created By:-Pravin
        * Updated By:- 
        * Created Date:-03 Dec 2015
        * Updated Date:- 
        * Purpose:-
        */
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
                else
                {
                    MessageBox.Show("Please ");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion

        /*
        * Created By:-Pravin
        * Updated By:- 
        * Created Date:-03 Dec 2015
        * Updated Date:- 
        * Purpose:-
        */
        #region------------------------BindClassName()---------------------------------------
        private void BindClassName()
        {
            try
            {
                BranchID = Convert.ToInt32(cbBranchName.SelectedValue);
                DataSet ds = obj_Class.BindClassName(BranchID);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (rdoClassWise.IsChecked == true)
                    {
                        //cbClassName.DataContext = null;
                        cbClassName.DisplayMemberPath = ds.Tables[0].Columns["ClassName"].ToString();
                        cbClassName.SelectedValuePath = ds.Tables[0].Columns["ClassID"].ToString();
                        cbClassName.SelectedValue = "0";
                        cbClassName.DataContext = ds.Tables[0].DefaultView;
                        
                    }
                    if (rdoRoomWise.IsChecked == true)
                    {
                        //cbClassName1.DataContext = null;
                        cbClassName1.DisplayMemberPath = ds.Tables[0].Columns["ClassName"].ToString();
                        cbClassName1.SelectedValuePath = ds.Tables[0].Columns["ClassID"].ToString();
                        cbClassName1.SelectedValue = "0";
                        cbClassName1.DataContext = ds.Tables[0].DefaultView;
                        
                    }
                    if (rdoTeacherWise.IsChecked == true)
                    {
                        //cbClassName2.DataContext = null;
                        cbClassName2.DisplayMemberPath = ds.Tables[0].Columns["ClassName"].ToString();
                        cbClassName2.SelectedValuePath = ds.Tables[0].Columns["ClassID"].ToString();
                        cbClassName2.SelectedValue = "0";
                        cbClassName2.DataContext = ds.Tables[0].DefaultView;
                        
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
        * Created By:-Pravin
        * Updated By:- 
        * Created Date:-03 Dec 2015
        * Updated Date:- 
        * Purpose:-
        */
        #region------------------------BindSubjectName()---------------------------------
        private void BindSubjectName()
        {
            try
            {
                   if (rdoClassWise.IsChecked == true)
                    {
                        BatchID = Convert.ToInt32(cbBatchName.SelectedValue);
                        DataSet ds = obj_Subject.loadSubjectName(BatchID);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            //cbSubjectName.DataContext = null;
                            cbSubjectName.DisplayMemberPath = ds.Tables[0].Columns["SubjectName"].ToString();
                            cbSubjectName.SelectedValuePath = ds.Tables[0].Columns["SubjectID"].ToString();
                            
                            cbSubjectName.SelectedValue = "0";
                            cbSubjectName.DataContext = ds.Tables[0].DefaultView;
                       }
                   }
                    if (rdoRoomWise.IsChecked == true)
                    {
                        BatchID = Convert.ToInt32(cbBatchName1.SelectedValue);
                        DataSet ds = obj_Subject.loadSubjectName(BatchID);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                           // cbSubjectName1.DataContext = null;
                            cbSubjectName1.DisplayMemberPath = ds.Tables[0].Columns["SubjectName"].ToString();
                            cbSubjectName1.SelectedValuePath = ds.Tables[0].Columns["SubjectID"].ToString();
                            cbSubjectName1.DataContext = ds.Tables[0].DefaultView;
                            cbSubjectName1.SelectedValue = "0";
                       }
                    }
                   // if (rdoTeacherWise.IsChecked == true)
                   // {
                   //      BatchID = Convert.ToInt32(cbBatchName2.SelectedValue);
                   //      DataSet ds = obj_Subject.loadSubjectName(BatchID);
                   //      if (ds.Tables[0].Rows.Count > 0)
                   //     {
                   //         //cbSubjectName2.DataContext = null;
                   //         cbSubjectName2.DisplayMemberPath = ds.Tables[0].Columns["SubjectName"].ToString();
                   //         cbSubjectName2.SelectedValuePath = ds.Tables[0].Columns["SubjectID"].ToString();
                   //         cbSubjectName2.DataContext = ds.Tables[0].DefaultView;
                   //         cbSubjectName2.SelectedValue = "0";
                   //    }
                   //}
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
        #endregion

        #region---------------------------------------------------BindTeacher()-------------------------------------------------------------
        private void BindSubjectName1()
        {
            BatchID = Convert.ToInt32(cbBatchName2.SelectedValue);
            TeacherID = Convert.ToInt32(cbTeacherName2.SelectedValue);
            DataSet ds = obj_Subject.BindSubjectName1(BatchID,TeacherID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                //cbSubjectName2.DataContext = null;
                cbSubjectName2.DisplayMemberPath = ds.Tables[0].Columns["SubjectName"].ToString();
                cbSubjectName2.SelectedValuePath = ds.Tables[0].Columns["TeacherSubjectID"].ToString();
                cbSubjectName2.DataContext = ds.Tables[0].DefaultView;
                cbSubjectName2.SelectedValue = "0";
            }
        }
        #endregion


        /*
        * Created By:-Pravin
        * Updated By:- 
        * Created Date:-03 Dec 2015
        * Updated Date:- 
        * Purpose:-
        */
        #region------------------------BindBatchName()---------------------------------
        private void BindBatchName()
        {
            try
            {
                //ClassID = Convert.ToInt32(cbClassName.SelectedValue);
                //DataSet ds = obj_Batch.loadBatchName(ClassID);
                //if (ds.Tables[0].Rows.Count > 0)
                //{
                    if (rdoClassWise.IsChecked == true)
                    {
                         ClassID = Convert.ToInt32(cbClassName.SelectedValue);
                         DataSet ds = obj_Batch.loadBatchName(ClassID);
                         if (ds.Tables[0].Rows.Count > 0)
                         {
                            //cbBatchName.DataContext = null;
                            cbBatchName.DisplayMemberPath = ds.Tables[0].Columns["BatchName"].ToString();
                            cbBatchName.SelectedValuePath = ds.Tables[0].Columns["BatchID"].ToString();
                            cbBatchName.SelectedValue = "0";
                            cbBatchName.DataContext = ds.Tables[0].DefaultView;
                        
                       }
                    }
                    if (rdoRoomWise.IsChecked == true)
                    {
                        ClassID = Convert.ToInt32(cbClassName1.SelectedValue);
                         DataSet ds = obj_Batch.loadBatchName(ClassID);
                         if (ds.Tables[0].Rows.Count > 0)
                         {
                            //cbBatchName1.DataContext = null;
                            cbBatchName1.DisplayMemberPath = ds.Tables[0].Columns["BatchName"].ToString();
                            cbBatchName1.SelectedValuePath = ds.Tables[0].Columns["BatchID"].ToString();
                            cbBatchName1.SelectedValue = "0";
                            cbBatchName1.DataContext = ds.Tables[0].DefaultView;
                        
                       }
                        
                    }
                    if (rdoTeacherWise.IsChecked == true)
                    {
                       ClassID = Convert.ToInt32(cbClassName2.SelectedValue);
                         DataSet ds = obj_Batch.loadBatchName(ClassID);
                         if (ds.Tables[0].Rows.Count > 0)
                         {
                            //cbBatchName2.DataContext = null;
                            cbBatchName2.DisplayMemberPath = ds.Tables[0].Columns["BatchName"].ToString();
                            cbBatchName2.SelectedValuePath = ds.Tables[0].Columns["BatchID"].ToString();
                            cbBatchName2.SelectedValue = "0";
                            cbBatchName2.DataContext = ds.Tables[0].DefaultView;
                        
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
        * Created By:- Pravin
        * Updated By:- 
        * Created Date:-03 Dec 2015
        * Updated Date:- 
        * Purpose:-
        */
        #region-----------------BindTeacher()----------------------------------
        private void BindTeacher()
        {
            if (rdoClassWise.IsChecked == true)
            {
                int SubID = Convert.ToInt32(cbSubjectName.SelectedValue);
                int BatID = Convert.ToInt32(cbBatchName.SelectedValue);
                DataSet ds = objTeacher.BindTeacherOnTimeTable(SubID, BatID);

                if (ds.Tables[0].Rows.Count > 0)
                {

                    //cbTeacherName.DataContext = null;

                    cbTeacherName.DisplayMemberPath = ds.Tables[0].Columns["TeacherName"].ToString();
                    cbTeacherName.SelectedValuePath = ds.Tables[0].Columns["TeacherSubjectID"].ToString();
                    cbTeacherName.SelectedValue = "0";
                    cbTeacherName.DataContext = ds.Tables[0].DefaultView;
                }

            }
            if (rdoRoomWise.IsChecked == true)
            {
                int SubID = Convert.ToInt32(cbSubjectName1.SelectedValue);
                int BatID = Convert.ToInt32(cbBatchName1.SelectedValue);
                DataSet ds = objTeacher.BindTeacherOnTimeTable(SubID, BatID);

                if (ds.Tables[0].Rows.Count > 0)
                {

                    //cbTeacherName.DataContext = null;

                    cbTeacherName1.DisplayMemberPath = ds.Tables[0].Columns["TeacherName"].ToString();
                    cbTeacherName1.SelectedValuePath = ds.Tables[0].Columns["TeacherSubjectID"].ToString();
                    cbTeacherName1.SelectedValue = "0";
                    cbTeacherName1.DataContext = ds.Tables[0].DefaultView;
                }

            }
            //if (rdoTeacherWise.IsChecked == true)
            //{
            //    int SubID = Convert.ToInt32(cbSubjectName2.SelectedValue);
            //    int BatID = Convert.ToInt32(cbBatchName2.SelectedValue);
            //    DataSet ds = objTeacher.BindTeacherOnTimeTable(SubID, BatID);

            //    if (ds.Tables[0].Rows.Count > 0)
            //    {

            //        //cbTeacherName.DataContext = null;

            //        cbTeacherName2.DisplayMemberPath = ds.Tables[0].Columns["TeacherName"].ToString();
            //        cbTeacherName2.SelectedValuePath = ds.Tables[0].Columns["TeacherSubjectID"].ToString();
            //        cbTeacherName2.SelectedValue = "0";
            //        cbTeacherName2.DataContext = ds.Tables[0].DefaultView;
            //    }
            //}

        }
        #endregion

        #region---------------------------------------------------BindTeacher()-------------------------------------------------------------
        private void BindTeacher1()
        {
            DataSet ds = objTeacher.BindTeacherDropDown(0);

            if (ds.Tables[0].Rows.Count > 0)
            {
                cbTeacherName2.DataContext = null;

                
                cbTeacherName2.DisplayMemberPath = ds.Tables[0].Columns["TeacherName"].ToString();
                cbTeacherName2.SelectedValuePath = ds.Tables[0].Columns["TeacherID"].ToString();
                cbTeacherName2.SelectedValue = "0";
                cbTeacherName2.DataContext = ds.Tables[0].DefaultView; 
            }
        }
        #endregion

        /*
        * Created By:- Pravin
        * Updated By:- 
        * Created Date:-03 Dec 2015
        * Updated Date:- 
        * Purpose:-
        */
        #region----------------BindRoom()----------------------------
        private void BindRoom()
        {
            try
            {
                
                BranchID = Convert.ToInt32(cbBranchName.SelectedValue);
                DataSet ds = objRoom.BindRoomDropDown(BranchID);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (rdoClassWise.IsChecked == true)
                    {
                        //cbRoomName.DataContext = null;
                        cbRoomName.DisplayMemberPath = ds.Tables[0].Columns["RoomName"].ToString();
                        cbRoomName.SelectedValuePath = ds.Tables[0].Columns["RoomID"].ToString();
                        cbRoomName.SelectedValue = "0";
                        cbRoomName.DataContext = ds.Tables[0].DefaultView;
                        
                    }
                    if (rdoRoomWise.IsChecked == true)
                    {
                        //cbRoomName1.DataContext = null;
                        cbRoomName1.DisplayMemberPath = ds.Tables[0].Columns["RoomName"].ToString();
                        cbRoomName1.SelectedValuePath = ds.Tables[0].Columns["RoomID"].ToString();
                        cbRoomName1.SelectedValue = "0";
                        cbRoomName1.DataContext = ds.Tables[0].DefaultView;
                        
                    }
                    if (rdoTeacherWise.IsChecked == true)
                    {
                        //cbRoomName2.DataContext = null;
                        cbRoomName2.DisplayMemberPath = ds.Tables[0].Columns["RoomName"].ToString();
                        cbRoomName2.SelectedValuePath = ds.Tables[0].Columns["RoomID"].ToString();
                        cbRoomName2.SelectedValue = "0";
                        cbRoomName2.DataContext = ds.Tables[0].DefaultView;
                        
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
        * Created By:- Pravin
        * Updated By:- 
        * Created Date:-04 Dec 2015
        * Updated Date:- 
        * Purpose:-
        */
        #region------------BindTimeSlot---------------
        private void BindTimeSlot()
        {
            try
            {
                if (rdoClassWise.IsChecked == true)
                {
                    BatchAvailableID = Convert.ToInt32(cmbDayName.SelectedValue);
                    BatchID = Convert.ToInt32(cbBatchName.SelectedValue);
                    int Day = Convert.ToInt32(cmbDayName.SelectedValue);
                    if (Day != null)
                    {
                        DataSet ds = objTimeTable.BindTimeSlot(BatchAvailableID, BatchID, Day,0,0,0,0,0,0);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            //cbTimeSlot.DataContext = null;
                            cbTimeSlot.DisplayMemberPath = ds.Tables[0].Columns["TimeSlot"].ToString();
                            cbTimeSlot.SelectedValuePath = ds.Tables[0].Columns["BatchAvailableID"].ToString();
                            cbTimeSlot.DataContext = ds.Tables[0].DefaultView;
                            cbTimeSlot.SelectedValue = "0";
                        }

                    }
                }
                if (rdoRoomWise.IsChecked == true)
                {
                    int RoomAvailableID = Convert.ToInt32(cbDay.SelectedValue);
                    RoomID = Convert.ToInt32(cbRoomName1.SelectedValue);
                    int Day = Convert.ToInt32(cbDay.SelectedValue);
                    if (Day != null)
                    {
                        DataSet ds = objTimeTable.BindTimeSlot(0,0,0,RoomAvailableID, RoomID, Day,0,0,0);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            //cbTimeSlot1.DataContext = null;
                            cbTimeSlot1.DisplayMemberPath = ds.Tables[0].Columns["TimeSlot"].ToString();
                            cbTimeSlot1.SelectedValuePath = ds.Tables[0].Columns["RoomAvailableID"].ToString();
                            cbTimeSlot1.DataContext = ds.Tables[0].DefaultView;
                            cbTimeSlot1.SelectedValue = "0";
                        }

                    }
                }
                if (rdoTeacherWise.IsChecked == true)
                {
                    int TeacherAvailableID = Convert.ToInt32(cbDay2.SelectedValue);
                    TeacherID = Convert.ToInt32(cbTeacherName2.SelectedValue);
                    int Day = Convert.ToInt32(cbDay2.SelectedValue);
                    if (Day != null)
                    {
                        DataSet ds = objTimeTable.BindTimeSlot(0,0,0,0,0,0,TeacherAvailableID, TeacherID, Day);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            //cbTimeSlot2.DataContext = null;
                            cbTimeSlot2.DisplayMemberPath = ds.Tables[0].Columns["TimeSlot"].ToString();
                            cbTimeSlot2.SelectedValuePath = ds.Tables[0].Columns["TeacherAvailableID"].ToString();
                            cbTimeSlot2.DataContext = ds.Tables[0].DefaultView;
                            cbTimeSlot2.SelectedValue = "0";
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
        * Created By:- Pravin
        * Updated By:- 
        * Created Date:-04 Dec 2015
        * Updated Date:- 
        * Purpose:-
        */

        #region------------BindDay----------------------
        private void BindDay()
        {
            try
            {
                if (rdoClassWise.IsChecked == true)
                {
                    BatchID = Convert.ToInt32(cbBatchName.SelectedValue);
                    DataSet ds = objTimeTable.BindDay(BatchID, 0, 0);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        //cmbDayName.DataContext = null;
                        cmbDayName.DisplayMemberPath = ds.Tables[0].Columns["Day"].ToString();
                        cmbDayName.SelectedValuePath = ds.Tables[0].Columns["BatchAvailableID"].ToString();
                        cmbDayName.SelectedValue = "0";
                        cmbDayName.DataContext = ds.Tables[0].DefaultView;
                        
                    }
                }
                if (rdoRoomWise.IsChecked == true)
                {
                    RoomID = Convert.ToInt32(cbRoomName1.SelectedValue);
                    DataSet ds = objTimeTable.BindDay(0, RoomID, 0);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        //cbDay.DataContext = null;
                        cbDay.DisplayMemberPath = ds.Tables[0].Columns["Day"].ToString();
                        cbDay.SelectedValuePath = ds.Tables[0].Columns["RoomAvailableID"].ToString();
                        cbDay.SelectedValue = "0";
                        cbDay.DataContext = ds.Tables[0].DefaultView;
                        

                    }
                }
                if (rdoTeacherWise.IsChecked == true)
                {
                    TeacherID = Convert.ToInt32(cbTeacherName2.SelectedValue);
                    DataSet ds = objTimeTable.BindDay(0, 0, TeacherID);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        //cbDay2.DataContext = null;
                        cbDay2.DisplayMemberPath = ds.Tables[0].Columns["Day"].ToString();
                        cbDay2.SelectedValuePath = ds.Tables[0].Columns["TeacherAvailableID"].ToString();
                        cbDay2.SelectedValue = "0";
                        cbDay2.DataContext = ds.Tables[0].DefaultView;
                        
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
        * Created By:- Pravin
        * Updated By:- 
        * Created Date:-03 Dec 2015
        * Updated Date:- 
        * Purpose:-
        */

        #region-----------------Window_Loaded----------------------
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            canvasTeacherWise.Visibility = Visibility.Hidden;
            canvasRoomWise.Visibility = Visibility.Hidden;
            BindBranchName();
            BindGridviewTimeTable();
            dpTTStartDate.DisplayDateStart = DateTime.Today;
            //cmbDayName.SelectedIndex = 0;
            //BindSubjectName();
            //BindBatchName();
            //BindTeacher();
            //BindRoom();
            //BindDay();
            //BindTimeSlot();
        }
        #endregion
        /*
        * Created By:- Pravin
        * Updated By:- 
        * Created Date:-03 Dec 2015
        * Updated Date:- 
        * Purpose:-
        */
        #region-----------------------------------Validation------------------------------------------
        public bool Validate()
        {
            if (cbBranchName.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Branch Name");
                cbBranchName.Focus();
                return false;
            }
            else if (dpTTStartDate.Text == "")
            {
                MessageBox.Show("Please Select TimeTable StartDate");
                dpTTStartDate.Focus();
                return false;
            }
            if (rdoClassWise.IsChecked == true)
            {
                if (cbClassName.SelectedIndex == 0)
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
            else if (rdoRoomWise.IsChecked == true)
            {
                if (cbClassName1.SelectedIndex == 0)
                {
                    MessageBox.Show("Please Select Class Name");
                    cbClassName1.Focus();
                    return false;
                }
                else if (cbSubjectName1.SelectedIndex == 0)
                {
                    MessageBox.Show("Please Select Subject Name");
                    cbSubjectName1.Focus();
                    return false;
                }
                else if (cbBatchName1.SelectedIndex == 0)
                {
                    MessageBox.Show("Please Select Batch Name");
                    cbBatchName1.Focus();
                    return false;
                }
                else if (cbTeacherName1.SelectedIndex == 0)
                {
                    MessageBox.Show("Please Select Teacher Name");
                    cbTeacherName1.Focus();
                    return false;
                }
                else if (cbRoomName1.SelectedIndex == 0)
                {
                    MessageBox.Show("Please Select Room Name");
                    cbRoomName1.Focus();
                    return false;
                }
                else if (cbDay.SelectedIndex == 0)
                {
                    MessageBox.Show("Please Select Day");
                    cbDay.Focus();
                    return false;
                }
                else if (cbTimeSlot1.SelectedIndex == 0)
                {
                    MessageBox.Show("Please Select Time from TimeSlot");
                    cbTimeSlot1.Focus();
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if (rdoTeacherWise.IsChecked == true)
            {
                if (cbClassName2.SelectedIndex == 0)
                {
                    MessageBox.Show("Please Select Class Name");
                    cbClassName2.Focus();
                    return false;
                }
                else if (cbSubjectName2.SelectedIndex == 0)
                {
                    MessageBox.Show("Please Select Subject Name");
                    cbSubjectName2.Focus();
                    return false;
                }
                else if (cbBatchName2.SelectedIndex == 0)
                {
                    MessageBox.Show("Please Select Batch Name");
                    cbBatchName2.Focus();
                    return false;
                }
                else if (cbTeacherName2.SelectedIndex == 0)
                {
                    MessageBox.Show("Please Select Teacher Name");
                    cbTeacherName2.Focus();
                    return false;
                }
                else if (cbRoomName2.SelectedIndex == 0)
                {
                    MessageBox.Show("Please Select Room Name");
                    cbRoomName2.Focus();
                    return false;
                }
                else if (cbDay2.SelectedIndex == 0)
                {
                    MessageBox.Show("Please Select Day");
                    cbDay2.Focus();
                    return false;
                }
                else if (cbTimeSlot2.SelectedIndex == 0)
                {
                    MessageBox.Show("Please Select Time from TimeSlot");
                    cbTimeSlot2.Focus();
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }
        #endregion

        /*
        * Created By:- Pravin
        * Updated By:- 
        * Created Date:-04 Dec 2015
        * Updated Date:- 
        * Purpose:-
        */
        #region-------------------------------Go()--------------------------------------------------
        private void btnGo_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cbBranchName.SelectedValue.ToString() != "0" && cbBranchName.SelectedItem.ToString() != "Select")
                {
                    if (dpTTStartDate.Text != "")
                    //dpTTStartDate.Focus();
                    {
                        if (btnGo.Content.ToString() == "Go")
                        {
                            DisableUpperPart();
                            GetDetails();

                        }
                        else if (btnGo.Content.ToString() == "Change")
                        {
                            EnableUpperPart();
                            ClearData();
                        }
                    }
                    else
                    {
                        dpTTStartDate.Focus();
                        MessageBox.Show("Please Select Time Table Start Date");
                    }
                }
                else
                {
                    MessageBox.Show("Please select Branch Name");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion
        /*
        * Created By:- Pravin
        * Updated By:-PriTesh D. Sortee 
        * Created Date:-
        * Updated Date:- 03 Dec 2015
        * Purpose:-
        * Updated :- Disable Radio buttons and Calender 
        */
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
            //Disable radio button
            rdoTeacherWise.IsEnabled = false;
            rdoRoomWise.IsEnabled = false;
            rdoClassWise.IsEnabled = false;
            //Disable Calender
            dpTTStartDate.IsEnabled = false;

            btnGo.Content = "Change";
            cbClassName1.IsEnabled = true;
            cbBatchName1.IsEnabled = true;
            cbSubjectName1.IsEnabled = true;
            cbRoomName1.IsEnabled = true;
            cbDay.IsEnabled = true;
            cbTeacherName1.IsEnabled = true;
            cbTimeSlot1.IsEnabled = true;
            cbClassName2.IsEnabled = true;
            cbBatchName2.IsEnabled = true;
            cbSubjectName2.IsEnabled = true;
            cbRoomName2.IsEnabled = true;
            cbDay2.IsEnabled = true;
            cbTeacherName2.IsEnabled = true;
            cbTimeSlot2.IsEnabled = true;
            
            
        }
        #endregion
        /*
        * Created By:- Pravin
        * Updated By:- 
        * Created Date:-04 Dec 2015
        * Updated Date:- 
        * Purpose:-
        */
        #region-----------------------------------------------Clears()-------------------------------------------------------
        private void ClearData()
        {
            cbClassName.DataContext = null;

            cbBatchName.DataContext = null;
            cbSubjectName.DataContext = null;
            cbRoomName.DataContext = null;
            cmbDayName.DataContext = null;
            cbTeacherName.DataContext = null;
            cbTimeSlot.DataContext = null;
            btnSave.Content = "Save";
            rdoActive.IsChecked = true;
            //BindTeacher();
            // cmbDayName_Items();
            //BindGrid();
            //UncheckAllCheckBoxes();
            // gbSame.Visibility = Visibility.Hidden;
            //EnableDropdown();
        }
        #endregion
        /*
        * Created By:- Pravin
        * Updated By:- 
        * Created Date:-04 Dec 2015
        * Updated Date:- 
        * Purpose:-
        */
        #region-------------------btnClear_Click-----------------
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Time_Table tt = new Time_Table();
                Close();
                tt.Show();
                //ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion
        /*
        * Created By:- Pravin
        * Updated By:- PriTesh D. Sortee
        * Created Date:-
        * Updated Date:- 05 Dec 2015
        * Purpose:-
         * Update Purpose:- Change Branch selection changed
        */
        #region---------cbBranchName_SelectionChanged------------
        private void cbBranchName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (cbBranchName.SelectedValue != "0")
            //{
            //    BindClassName();
            //    BindRoom();
            //}
        }
        #endregion
        /*
        * Created By:- Pravin
        * Updated By:- 
        * Created Date:-05 Dec 2015
        * Updated Date:- 
        * Purpose:-
        */
        #region-----------cbClassName_SelectionChanged------------
        private void cbClassName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cbClassName.SelectedValue.ToString() != "0" && cbClassName.SelectedItem.ToString() != "Select" && cbClassName.SelectedValue != null)
                //if(cbClassName.SelectedItem.ToString()!="Select")
                {
                    //cbTimeSlot.DataContext = null;
                    //cmbDayName.SelectedValue = "0";
                    //cbTeacherName.SelectedValue = "0";
                    //cbRoomName.SelectedValue = "0";
                    //cbSubjectName.SelectedValue ="0";
                    //cbBatchName = null;
                    BindBatchName();
                    cbClassName.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
        }
        #endregion
        /*
        * Created By:- Pravin
        * Updated By:- 
        * Created Date:-05 Dec 2015
        * Updated Date:- 
        * Purpose:-
        */
        #region--------------------------------------cbBatchName_SelectionChanged--------------------------------------
        private void cbBatchName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cbBatchName.SelectedValue.ToString() != "0" && cbBatchName.SelectedItem.ToString() != "Select" && cbBatchName.SelectedValue != null)
                {
                    //cbTimeSlot.DataContext = null;
                    //cmbDayName.SelectedValue = "0";
                    //cbTeacherName.SelectedValue = "0";
                    //cbRoomName.SelectedValue = "0";

                    BindSubjectName();
                    cbBatchName.IsEnabled = false;
                    //BindDay();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
        }

        #endregion

        //private void cbRoomName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (rdoRoomWise .IsChecked == true)
        //    {
        //        //BindDay();
        //    }
        //    else
        //    {

        //    }
        // }

        /*
        * Created By:- Pravin
        * Updated By:- 
        * Created Date:-05 Dec 2015
        * Updated Date:- 
        * Purpose:-
        */
        #region--------------------------------------cbSubjectName_SelectionChanged---------------------------------
        private void cbSubjectName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cbSubjectName.SelectedValue != "0" && cbSubjectName.SelectedValue.ToString() != "0")
                {
                    //cbTimeSlot.DataContext = null;
                    //cmbDayName.SelectedValue = "0";
                    //cbTeacherName.SelectedValue = "0";
                    //cbRoomName.SelectedValue = "0";

                    BindRoom();
                    BindTeacher();
                    BindDay();
                    cbSubjectName.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
        }
        #endregion

        /*
        * Created By:-Pravin    
        * Updated By:- 
        * Created Date:-05 Dec 2015
        * Updated Date:- 
        * Purpose:-
        */
        #region-------------------------------------cmbDayName_SelectionChanged-----------------------------------------
        private void cmbDayName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cmbDayName.SelectedValue != "0" && cmbDayName.SelectedValue.ToString() != "0" && cmbDayName.SelectedValue != null)
                {
                    BindTimeSlot();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
        }
        #endregion

        /*
        * Created By:- Pravin
        * Updated By:- 
        * Created Date:-05 Dec 2015
        * Updated Date:- 
        * Purpose:-
        */
        #region-------------------------------------rdoclasswise_Checked----------------------------------------------------
        private void rdoClassWise_Checked(object sender, RoutedEventArgs e)
        {           
            //canvasTeacherWise.Visibility = Visibility.Hidden;
            //canvasRoomWise.Visibility = Visibility.Hidden;
            //gbSame.Visibility = Visibility.Visible;
        }
        #endregion
        /*
        * Created By:-Pravin
        * Updated By:- 
        * Created Date:-05 Dec 2015
        * Updated Date:- 
        * Purpose:-
        */
        #region--------------------------------------rdoRoomWise_Checked-----------------------------------------------
        private void rdoRoomWise_Checked_1(object sender, RoutedEventArgs e)
        {
            //canvasTeacherWise.Visibility = Visibility.Hidden;
            //gbSame.Visibility = Visibility.Hidden;
            //canvasRoomWise.Visibility = Visibility.Visible;
            //canvasRoomWise.Margin = new Thickness(235, 160, 0, 0);
            //BindClassName();
            //BindTeacher();
            //BindTimeSlot();
            //BindBatchName();
            //BindSubjectName();
            //BindDay();
            //BindRoom();

        }
        #endregion

        /*
        * Created By:-Pravin
        * Updated By:- 
        * Created Date:-05 Dec 2015
        * Updated Date:- 
        * Purpose:-
        */
        #region------------------------------------------rdoTeacherWise_Chekced------------------------------------------
        private void rdoTeacherWise_Checked(object sender, RoutedEventArgs e)
        {
            //canvasRoomWise.Visibility = Visibility.Hidden;
            //gbSame.Visibility = Visibility.Hidden;
            //canvasTeacherWise.Visibility = Visibility.Visible;
            //canvasTeacherWise.Margin = new Thickness(235, -140, 0, 0);
            //BindClassName();
            //BindTeacher();
            //BindTimeSlot();
            //BindBatchName();
            //BindSubjectName();
            //BindDay();
        }
        #endregion

        /*
        * Created By:-Pravin    
        * Updated By:- 
        * Created Date:-05 Dec 2015
        * Updated Date:- 
        * Purpose:-
        */
        #region-------------------------------------------ClassName1_SelectionChanged---------------------------------------
        private void cbClassName1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cbClassName1.SelectedValue.ToString() != "0" && cbClassName1.SelectedIndex != 0)
                {
                    BindBatchName();
                    cbClassName1.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
        }
        #endregion

        /*
        * Created By:-Pravin    
        * Updated By:- 
        * Created Date:-05 Dec 2015
        * Updated Date:- 
        * Purpose:-
        */
        #region----------------------------------------------cbSubjectName1_SelectionChanged------------------------------------
        private void cbSubjectName1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cbSubjectName1.SelectedValue.ToString() != "0" && cbSubjectName1.SelectedIndex != 0)
                {
                    BindTeacher();
                    BindDay();
                    cbSubjectName1.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
        }
        #endregion
        /*
        * Created By:-Pravin    
        * Updated By:- 
        * Created Date:-05 Dec 2015
        * Updated Date:- 
        * Purpose:-
        */
        #region--------------------------------------------cbTeacherName1_SelectionChanged---------------------------------------------
        private void cbTeacherName1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cbTeacherName1.SelectedValue != "0")
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
        }
        #endregion
        
        /*
        * Created By:-Pravin
        * Updated By:- 
        * Created Date:- 05 Dec 2015
        * Updated Date:- 
        * Purpose:- bind grid view of Timetable form
        */
      
        #region-----------BindGridviewTimeTable-------------------------
        private void BindGridviewTimeTable()
        {
            DataSet ds = objTimeTable.BindGridTimeTable();
            if (ds.Tables[0].Rows.Count > 0)
            {
                dgTimeTable.DataContext = null;
                dgTimeTable.ItemsSource = ds.Tables[0].DefaultView;
            }
            dgTimeTable.Items.Refresh();
        }
        #endregion

        /*
        * Created By:-PriTesh D. Sortee
        * Updated By:- 
        * Created Date:- 03 Dec 2015
        * Updated Date:- 
        * Purpose:-Get All details According To branch And Type Of View
        */

        #region----------------------------------------------GetDetails()-------------------------------------------------------
        private void GetDetails()
        {
            if (rdoClassWise.IsChecked==true)
            {
                canvasTeacherWise.Visibility = Visibility.Hidden;
                canvasRoomWise.Visibility = Visibility.Hidden;
                gbSame.Visibility = Visibility.Visible;
                BindClassName();
            }
            else if (rdoRoomWise.IsChecked==true)
            {
                canvasTeacherWise.Visibility = Visibility.Hidden;
                gbSame.Visibility = Visibility.Hidden;
                canvasRoomWise.Visibility = Visibility.Visible;
                canvasRoomWise.Margin = new Thickness(235, 160, 0, 0);
                BindRoom();
                //BindTeacher();
                //BindTimeSlot();
                //BindBatchName();
                //BindSubjectName();
                //BindDay();
                //BindRoom();
            }
            else if (rdoTeacherWise.IsChecked == true)
            {
                canvasRoomWise.Visibility = Visibility.Collapsed;
                gbSame.Visibility = Visibility.Hidden;
                canvasTeacherWise.Visibility = Visibility.Visible;
                canvasTeacherWise.Margin = new Thickness(235,160,0,0);
                BindTeacher1();
                BindClassName();
                BindRoom();
                //BindClassName();
                
                //BindTimeSlot();
                //BindBatchName();
                //BindSubjectName();
                //BindDay();
            }
            else
            {
                MessageBox.Show("Please Select Type", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion

        /*
        * Created By:-Pravin & pranjali
        * Updated By:- 
        * Created Date:- 05 Dec 2015
        * Updated Date:- 
        * Purpose:- Combobox room selection change
        */

        #region---------------cbRoomName1_SelectionChanged--------------
        private void cbRoomName1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cbRoomName1.SelectedValue.ToString() != "0" && cbRoomName1.SelectedIndex != 0)
                {
                    BindClassName();
                    cbRoomName1.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
        }
        #endregion

        #region-----------cbBatchName1_SelectionChanged-------------
        private void cbBatchName1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cbBatchName1.SelectedValue.ToString() != "0" && cbBatchName1.SelectedIndex != 0)
                {
                    BindSubjectName();
                    cbBatchName1.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
        }
        #endregion

        #region-----------cbDay_SelectionChanged---------------
        private void cbDay_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cbDay.SelectedValue.ToString() != "0" && cbDay.SelectedIndex != 0)
                {
                    BindTimeSlot();
                }
            }
            catch (Exception ex )
            {
                MessageBox.Show(ex.Message.ToString(), "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
        }
        #endregion

        #region-------------cbClassName2_SelectionChanged-------------
        private void cbClassName2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cbClassName2.SelectedValue.ToString() != "0" && cbClassName2.SelectedIndex != 0)
                {
                    BindBatchName();
                    cbClassName2.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
        }
        #endregion

        #region----------cbBatchName2_SelectionChanged-----------
        private void cbBatchName2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cbBatchName2.SelectedValue.ToString() != "0" && cbBatchName2.SelectedIndex != 0)
                {
                    BindSubjectName1();
                    cbBatchName2.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
        }
        #endregion

        #region-----------cbTeacherName2_SelectionChanged-----------
        private void cbTeacherName2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cbTeacherName2.SelectedValue.ToString() != "0" && cbTeacherName2.SelectedIndex != 0)
                {
                    BindDay();
                    cbTeacherName2.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
        }
        #endregion

        #region-----------cbDay2_SelectionChanged-------------
        private void cbDay2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cbDay2.SelectedValue.ToString() != "0" && cbDay2.SelectedIndex != 0)
                {
                    BindTimeSlot();
                }
            }
            catch (Exception ex)
            {
                 MessageBox.Show(ex.Message.ToString(), "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
        }
        #endregion

        /*
        * Created By:-Pravin
        * Updated By:- Pranjali
        * Created Date:- 05 Dec 2015
        * Updated Date:- 08 Dec 2015
        * Purpose:- Grid view Cell Click Event for update data
        */
        #region--------------------------------------gridview cell click()-------------------------------------
        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
               // gbSame.IsEnabled = true;
               // DisableUpperPart();
                object item = dgTimeTable.SelectedItem;
                UpID = Convert.ToInt32(((System.Data.DataRowView)(dgTimeTable.CurrentItem)).Row.ItemArray[0].ToString());
                UPID = Convert.ToInt32(((System.Data.DataRowView)(dgTimeTable.CurrentItem)).Row.ItemArray[17].ToString());
                cbBranchName.Text = Convert.ToString(((System.Data.DataRowView)(dgTimeTable.CurrentItem)).Row.ItemArray[1].ToString());
                dpTTStartDate.Text = Convert.ToString(((System.Data.DataRowView)(dgTimeTable.CurrentItem)).Row.ItemArray[2].ToString());

                string view = Convert.ToString(((System.Data.DataRowView)(dgTimeTable.CurrentItem)).Row.ItemArray[15].ToString());
                if (view == "ClassWise")
                {
                    rdoClassWise.IsChecked = true;
                }
                else if (view == "RoomWise")
                {
                    rdoRoomWise.IsChecked = true;
                }
                else if (view == "TeacherWise")
                {
                    rdoTeacherWise.IsChecked = true;
                }
                GetDetails();
                if (rdoClassWise.IsChecked == true)
                {
                    BindClassName();
                    cbClassName.Text = Convert.ToString(((System.Data.DataRowView)(dgTimeTable.CurrentItem)).Row.ItemArray[3].ToString());
                    cbBatchName.Text = Convert.ToString(((System.Data.DataRowView)(dgTimeTable.CurrentItem)).Row.ItemArray[4].ToString());
                    cbSubjectName.Text = Convert.ToString(((System.Data.DataRowView)(dgTimeTable.CurrentItem)).Row.ItemArray[6].ToString());
                    cbRoomName.Text = Convert.ToString(((System.Data.DataRowView)(dgTimeTable.CurrentItem)).Row.ItemArray[5].ToString());
                    TeacherSubjectID = Convert.ToInt32(((System.Data.DataRowView)(dgTimeTable.CurrentItem)).Row.ItemArray[20].ToString());
                    cbTeacherName.SelectedValue = TeacherSubjectID;
                    cmbDayName.Text = Convert.ToString(((System.Data.DataRowView)(dgTimeTable.CurrentItem)).Row.ItemArray[11].ToString());
                    cbTimeSlot.Text = Convert.ToString(((System.Data.DataRowView)(dgTimeTable.CurrentItem)).Row.ItemArray[12].ToString());
                }

                if (rdoRoomWise.IsChecked == true)
                {
                    BindRoom();
                    cbRoomName1.Text = Convert.ToString(((System.Data.DataRowView)(dgTimeTable.CurrentItem)).Row.ItemArray[5].ToString());
                    cbClassName1.Text = Convert.ToString(((System.Data.DataRowView)(dgTimeTable.CurrentItem)).Row.ItemArray[3].ToString());
                    cbBatchName1.Text = Convert.ToString(((System.Data.DataRowView)(dgTimeTable.CurrentItem)).Row.ItemArray[4].ToString());
                    
                    cbSubjectName1.Text = Convert.ToString(((System.Data.DataRowView)(dgTimeTable.CurrentItem)).Row.ItemArray[6].ToString());
                    TeacherSubjectID = Convert.ToInt32(((System.Data.DataRowView)(dgTimeTable.CurrentItem)).Row.ItemArray[20].ToString());
                    cbTeacherName1.SelectedValue = TeacherSubjectID;
                    cbDay.Text = Convert.ToString(((System.Data.DataRowView)(dgTimeTable.CurrentItem)).Row.ItemArray[11].ToString());
                    cbTimeSlot1.Text = Convert.ToString(((System.Data.DataRowView)(dgTimeTable.CurrentItem)).Row.ItemArray[12].ToString());
                }

                if (rdoTeacherWise.IsChecked == true)
                {
                    BindTeacher1();
                   // cbTeacherName2.Text = Convert.ToString(((System.Data.DataRowView)(dgTimeTable.CurrentItem)).Row.ItemArray[7].ToString());
                    cbClassName2.Text = Convert.ToString(((System.Data.DataRowView)(dgTimeTable.CurrentItem)).Row.ItemArray[3].ToString());
                    cbBatchName2.Text = Convert.ToString(((System.Data.DataRowView)(dgTimeTable.CurrentItem)).Row.ItemArray[4].ToString());
                    cbRoomName2.Text = Convert.ToString(((System.Data.DataRowView)(dgTimeTable.CurrentItem)).Row.ItemArray[5].ToString());
                    cbSubjectName2.Text = Convert.ToString(((System.Data.DataRowView)(dgTimeTable.CurrentItem)).Row.ItemArray[6].ToString());
                    cbDay2.Text = Convert.ToString(((System.Data.DataRowView)(dgTimeTable.CurrentItem)).Row.ItemArray[11].ToString());
                    cbTimeSlot2.Text = Convert.ToString(((System.Data.DataRowView)(dgTimeTable.CurrentItem)).Row.ItemArray[12].ToString());
                }

                int act = Convert.ToInt32(((System.Data.DataRowView)(dgTimeTable.CurrentItem)).Row.ItemArray[9].ToString());

                if (act == 1)
                {
                    rdoActive.IsChecked = true;
                }
                else if (act == 0)
                {
                    rdoInActive.IsChecked = true;
                }
                    
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
    

    



