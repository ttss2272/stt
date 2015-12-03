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
        * Created By:-
        * Updated By:- PriTesh D. Sortee
        * Created Date:-
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


        int TimeTableID, BatchID, RoomID, ClassID, TeacherID, TeacherSubjectID, SubjectID, BranchID, BatchAvailableID, UpID, UpdatedByUserID, IsActive, IsDeleted;
        String UpdatedDate, LectStartTime, LectEndTime, SlotTime, Day;
        DateTime TTStartDate;

        #endregion
        /*
        * Created By:-
        * Updated By:- 
        * Created Date:-
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
        * Created By:-
        * Updated By:- 
        * Created Date:-
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
                    string Result = objTimeTable.SaveTimeTable(TimeTableID, TTStartDate, BatchID, UpdatedByUserID, UpdatedDate, IsActive, IsDeleted);
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
        
        /*
        * Created By:-
        * Updated By:- 
        * Created Date:-
        * Updated Date:- 
        * Purpose:-
        */
        #region---------------------------------Setparamerter()-------------------------------------------
        public void Setparameter()
        {
            TimeTableID = UpID;
            BranchID = Convert.ToInt32(cbBranchName.SelectedValue.ToString());
            ClassID = Convert.ToInt32(cbClassName.SelectedValue.ToString());
            BatchID = Convert.ToInt32(cbBatchName.SelectedValue.ToString());
            TTStartDate = Convert.ToDateTime(dpTTStartDate.SelectedDate.Value.Date.ToString());
            TeacherSubjectID = Convert.ToInt32(cbSubjectName.SelectedValue.ToString());
            RoomID = Convert.ToInt32(cbRoomName.SelectedValue.ToString());
            TeacherID = Convert.ToInt32(cbTeacherName.SelectedValue.ToString());
            Day = cmbDayName.SelectedValue.ToString();
            SlotTime = cbTimeSlot.SelectedValue.ToString();
            string[] a = SlotTime.Split('-');
            LectStartTime = a[0];
            LectEndTime = a[1];
            UpdatedByUserID = 1;
            UpdatedDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
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
        #endregion


        /*     #region-------------cmbDayName_Items-------------------------------
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
        #endregion */


        /*
        * Created By:-
        * Updated By:- 
        * Created Date:-
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
        * Created By:-
        * Updated By:- 
        * Created Date:-
        * Updated Date:- 
        * Purpose:-
        */
        #region----------------------------EnableDropdown()---------------------------
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
        * Created By:-
        * Updated By:- 
        * Created Date:-
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

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion

        /*
        * Created By:-
        * Updated By:- 
        * Created Date:-
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
                        cbClassName.DataContext = null;
                        cbClassName.DisplayMemberPath = ds.Tables[0].Columns["ClassName"].ToString();
                        cbClassName.SelectedValuePath = ds.Tables[0].Columns["ClassID"].ToString();
                        cbClassName.DataContext = ds.Tables[0].DefaultView;
                        cbClassName.SelectedValue = "0";
                    }
                    if (rdoRoomWise.IsChecked == true)
                    {
                        cbClassName1.DataContext = null;
                        cbClassName1.DisplayMemberPath = ds.Tables[0].Columns["ClassName"].ToString();
                        cbClassName1.SelectedValuePath = ds.Tables[0].Columns["ClassID"].ToString();
                        cbClassName1.DataContext = ds.Tables[0].DefaultView;
                        cbClassName1.SelectedValue = "0";
                    }
                    if (rdoTeacherWise.IsChecked == true)
                    {
                        cbClassName2.DataContext = null;
                        cbClassName2.DisplayMemberPath = ds.Tables[0].Columns["ClassName"].ToString();
                        cbClassName2.SelectedValuePath = ds.Tables[0].Columns["ClassID"].ToString();
                        cbClassName2.DataContext = ds.Tables[0].DefaultView;
                        cbClassName2.SelectedValue = "0";
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
        * Created By:-
        * Updated By:- 
        * Created Date:-
        * Updated Date:- 
        * Purpose:-
        */
        #region------------------------BindSubjectName()---------------------------------
        private void BindSubjectName()
        {
            try
            {
                BatchID = Convert.ToInt32(cbBatchName.SelectedValue);
                DataSet ds = obj_Subject.loadSubjectName(BatchID);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (rdoClassWise.IsChecked == true)
                    {
                        cbSubjectName.DataContext = null;
                        cbSubjectName.DisplayMemberPath = ds.Tables[0].Columns["SubjectName"].ToString();
                        cbSubjectName.SelectedValuePath = ds.Tables[0].Columns["SubjectID"].ToString();
                        cbSubjectName.DataContext = ds.Tables[0].DefaultView;
                        cbSubjectName.SelectedValue = "0";
                    }
                    if (rdoRoomWise.IsChecked == true)
                    {
                        cbSubjectName1.DataContext = null;
                        cbSubjectName1.DisplayMemberPath = ds.Tables[0].Columns["SubjectName"].ToString();
                        cbSubjectName1.SelectedValuePath = ds.Tables[0].Columns["SubjectID"].ToString();
                        cbSubjectName1.DataContext = ds.Tables[0].DefaultView;
                        cbSubjectName1.SelectedValue = "0";
                    }
                    if (rdoTeacherWise.IsChecked == true)
                    {
                        cbSubjectName2.DataContext = null;
                        cbSubjectName2.DisplayMemberPath = ds.Tables[0].Columns["SubjectName"].ToString();
                        cbSubjectName2.SelectedValuePath = ds.Tables[0].Columns["SubjectID"].ToString();
                        cbSubjectName2.DataContext = ds.Tables[0].DefaultView;
                        cbSubjectName2.SelectedValue = "0";
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
        * Created By:-
        * Updated By:- 
        * Created Date:-
        * Updated Date:- 
        * Purpose:-
        */
        #region------------------------BindBatchName()---------------------------------
        private void BindBatchName()
        {
            try
            {
                ClassID = Convert.ToInt32(cbClassName.SelectedValue);
                DataSet ds = obj_Batch.loadBatchName(ClassID);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (rdoClassWise.IsChecked == true)
                    {
                        cbBatchName.DataContext = null;
                        cbBatchName.DisplayMemberPath = ds.Tables[0].Columns["BatchName"].ToString();
                        cbBatchName.SelectedValuePath = ds.Tables[0].Columns["BatchID"].ToString();
                        cbBatchName.DataContext = ds.Tables[0].DefaultView;
                        cbBatchName.SelectedValue = "0";
                    }
                    if (rdoRoomWise.IsChecked == true)
                    {
                        cbBatchName1.DataContext = null;
                        cbBatchName1.DisplayMemberPath = ds.Tables[0].Columns["BatchName"].ToString();
                        cbBatchName1.SelectedValuePath = ds.Tables[0].Columns["BatchID"].ToString();
                        cbBatchName1.DataContext = ds.Tables[0].DefaultView;
                        cbBatchName1.SelectedValue = "0";
                    }
                    if (rdoTeacherWise.IsChecked == true)
                    {
                        cbBatchName2.DataContext = null;
                        cbBatchName2.DisplayMemberPath = ds.Tables[0].Columns["BatchName"].ToString();
                        cbBatchName2.SelectedValuePath = ds.Tables[0].Columns["BatchID"].ToString();
                        cbBatchName2.DataContext = ds.Tables[0].DefaultView;
                        cbBatchName2.SelectedValue = "0";
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
        * Created By:-
        * Updated By:- 
        * Created Date:-
        * Updated Date:- 
        * Purpose:-
        */
        #region-----------------BindTeacher()----------------------------------
        private void BindTeacher()
        {
            TeacherSubjectID = Convert.ToInt32(cbTeacherName.SelectedValue);
            DataSet ds = objTeacher.BindTeacherOnTimeTable(TeacherSubjectID);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (rdoClassWise.IsChecked == true)
                {
                    cbTeacherName.DataContext = null;
                    cbTeacherName.DataContext = ds.Tables[0].DefaultView;
                    cbTeacherName.DisplayMemberPath = ds.Tables[0].Columns["TeacherName"].ToString();
                    cbTeacherName.SelectedValuePath = ds.Tables[0].Columns["TeacherSubjectID"].ToString();
                    cbTeacherName.SelectedValue = "0";
                }
                if (rdoRoomWise.IsChecked == true)
                {
                    cbTeacherName1.DataContext = null;
                    cbTeacherName1.DataContext = ds.Tables[0].DefaultView;
                    cbTeacherName1.DisplayMemberPath = ds.Tables[0].Columns["TeacherName"].ToString();
                    cbTeacherName1.SelectedValuePath = ds.Tables[0].Columns["TeacherSubjectID"].ToString();
                    cbTeacherName1.SelectedValue = "0";
                }
                if (rdoTeacherWise.IsChecked == true)
                {
                    cbTeacherName2.DataContext = null;
                    cbTeacherName2.DataContext = ds.Tables[0].DefaultView;
                    cbTeacherName2.DisplayMemberPath = ds.Tables[0].Columns["TeacherName"].ToString();
                    cbTeacherName2.SelectedValuePath = ds.Tables[0].Columns["TeacherSubjectID"].ToString();
                    cbTeacherName2.SelectedValue = "0";
                }
            }
        }
        #endregion

        /*
        * Created By:-
        * Updated By:- 
        * Created Date:-
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
                        cbRoomName.DataContext = null;
                        cbRoomName.DisplayMemberPath = ds.Tables[0].Columns["RoomName"].ToString();
                        cbRoomName.SelectedValuePath = ds.Tables[0].Columns["RoomID"].ToString();
                        cbRoomName.DataContext = ds.Tables[0].DefaultView;
                        cbRoomName.SelectedValue = "0";
                    }
                    if (rdoRoomWise.IsChecked == true)
                    {
                        cbRoomName1.DataContext = null;
                        cbRoomName1.DisplayMemberPath = ds.Tables[0].Columns["RoomName"].ToString();
                        cbRoomName1.SelectedValuePath = ds.Tables[0].Columns["RoomID"].ToString();
                        cbRoomName1.DataContext = ds.Tables[0].DefaultView;
                        cbRoomName1.SelectedValue = "0";
                    }
                    if (rdoTeacherWise.IsChecked == true)
                    {
                        cbRoomName2.DataContext = null;
                        cbRoomName2.DisplayMemberPath = ds.Tables[0].Columns["RoomName"].ToString();
                        cbRoomName2.SelectedValuePath = ds.Tables[0].Columns["RoomID"].ToString();
                        cbRoomName2.DataContext = ds.Tables[0].DefaultView;
                        cbRoomName2.SelectedValue = "0";
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
        * Created By:-
        * Updated By:- 
        * Created Date:-
        * Updated Date:- 
        * Purpose:-
        */
        #region------------BindTimeSlot---------------
        private void BindTimeSlot()
        {
            try
            {
                BatchAvailableID = Convert.ToInt32(cmbDayName.SelectedValue);
                BatchID = Convert.ToInt32(cbBatchName.SelectedValue);
                int Day = Convert.ToInt32(cmbDayName.SelectedValue);
                if (Day != null)
                {
                    DataSet ds = objTimeTable.BindTimeSlot(BatchAvailableID, BatchID, Day);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (rdoClassWise.IsChecked == true)
                        {
                            cbTimeSlot.DataContext = null;
                            cbTimeSlot.DisplayMemberPath = ds.Tables[0].Columns["TimeSlot"].ToString();
                            cbTimeSlot.SelectedValuePath = ds.Tables[0].Columns["BatchAvailableID"].ToString();
                            cbTimeSlot.DataContext = ds.Tables[0].DefaultView;
                            cbTimeSlot.SelectedValue = "0";
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
        * Created By:-
        * Updated By:- 
        * Created Date:-
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
                        cmbDayName.DataContext = null;
                        cmbDayName.DisplayMemberPath = ds.Tables[0].Columns["Day"].ToString();
                        cmbDayName.SelectedValuePath = ds.Tables[0].Columns["BatchAvailableID"].ToString();
                        cmbDayName.DataContext = ds.Tables[0].DefaultView;
                        cmbDayName.SelectedValue = "0";
                    }
                }
                if (rdoRoomWise.IsChecked == true)
                {
                    RoomID = Convert.ToInt32(cbRoomName1.SelectedValue);
                    DataSet ds = objTimeTable.BindDay(0, RoomID, 0);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        cbDay.DataContext = null;
                        cbDay.DisplayMemberPath = ds.Tables[0].Columns["Day"].ToString();
                        cbDay.SelectedValuePath = ds.Tables[0].Columns["RoomAvailableID"].ToString();
                        cbDay.DataContext = ds.Tables[0].DefaultView;
                        cbDay.SelectedValue = "0";

                    }
                }
                if (rdoTeacherWise.IsChecked == true)
                {
                    TeacherID = Convert.ToInt32(cbTeacherName2.SelectedValue);
                    DataSet ds = objTimeTable.BindDay(0, 0, TeacherID);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        cbDay2.DataContext = null;
                        cbDay2.DisplayMemberPath = ds.Tables[0].Columns["Day"].ToString();
                        cbDay2.SelectedValuePath = ds.Tables[0].Columns["TeacherAvailableID"].ToString();
                        cbDay2.DataContext = ds.Tables[0].DefaultView;
                        cbDay2.SelectedValue = "0";
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
        * Created By:-
        * Updated By:- 
        * Created Date:-
        * Updated Date:- 
        * Purpose:-
        */

        #region-----------------Window_Loaded----------------------
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            canvasTeacherWise.Visibility = Visibility.Hidden;
            canvasRoomWise.Visibility = Visibility.Hidden;
            BindBranchName();
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
        * Created By:-
        * Updated By:- 
        * Created Date:-
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
        /*
        * Created By:-
        * Updated By:- 
        * Created Date:-
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
        /*
        * Created By:-
        * Updated By:- 
        * Created Date:-
        * Updated Date:- 
        * Purpose:-
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
            
            //checked if class wise view checked
            if (rdoClassWise.IsChecked== true)
            {
                canvasTeacherWise.Visibility = Visibility.Hidden;
                canvasRoomWise.Visibility = Visibility.Hidden;
                gbSame.Visibility = Visibility.Visible;
            }
            //chekced if Room wise view checked
            if (rdoRoomWise.IsChecked==true)
            {
                canvasTeacherWise.Visibility = Visibility.Hidden;
                gbSame.Visibility = Visibility.Hidden;
                canvasRoomWise.Visibility = Visibility.Visible;
                canvasRoomWise.Margin = new Thickness(235, 160, 0, 0);
                BindClassName();
                BindTeacher();
                BindTimeSlot();
                BindBatchName();
                BindSubjectName();
                BindDay();
                BindRoom();
            }

            //checked if Teacher Wise view Checked
            if (rdoTeacherWise.IsChecked==true)
            {
                canvasRoomWise.Visibility = Visibility.Hidden;
                gbSame.Visibility = Visibility.Hidden;
                canvasTeacherWise.Visibility = Visibility.Visible;
                canvasTeacherWise.Margin = new Thickness(235, -140, 0, 0);
                BindClassName();
                BindTeacher();
                BindTimeSlot();
                BindBatchName();
                BindSubjectName();
                BindDay();
            }
        }
        #endregion
        /*
        * Created By:-
        * Updated By:- 
        * Created Date:-
        * Updated Date:- 
        * Purpose:-
        */
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
            BindTeacher();
            // cmbDayName_Items();
            //BindGrid();
            //UncheckAllCheckBoxes();
            // gbSame.Visibility = Visibility.Hidden;
            //EnableDropdown();
        }
        #endregion
        /*
        * Created By:-
        * Updated By:- 
        * Created Date:-
        * Updated Date:- 
        * Purpose:-
        */
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
        /*
        * Created By:-
        * Updated By:- PriTesh D. Sortee
        * Created Date:-
        * Updated Date:- 03 Dec 2015
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
        * Created By:-
        * Updated By:- 
        * Created Date:-
        * Updated Date:- 
        * Purpose:-
        */
        #region-----------cbClassName_SelectionChanged------------
        private void cbClassName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbClassName.SelectedValue != "0")
            {
                BindBatchName();
            }
        }
        #endregion
        /*
        * Created By:-
        * Updated By:- 
        * Created Date:-
        * Updated Date:- 
        * Purpose:-
        */
        #region--------------cbBatchName_SelectionChanged
        private void cbBatchName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbBatchName.SelectedValue != "0")
            {
                BindSubjectName();
                BindDay();
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
        * Created By:-
        * Updated By:- 
        * Created Date:-
        * Updated Date:- 
        * Purpose:-
        */
        #region--------------------------------------cbSubjectName_SelectionChanged---------------------------------
        private void cbSubjectName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BindTeacher();
        }
        #endregion

        /*
        * Created By:-
        * Updated By:- 
        * Created Date:-
        * Updated Date:- 
        * Purpose:-
        */
        #region-------------------------------------cmbDayName_SelectionChanged-----------------------------------------
        private void cmbDayName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BindTimeSlot();
        }
        #endregion

        /*
        * Created By:-
        * Updated By:- 
        * Created Date:-
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
        * Created By:-
        * Updated By:- 
        * Created Date:-
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
        * Created By:-
        * Updated By:- 
        * Created Date:-
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
        * Created By:-
        * Updated By:- 
        * Created Date:-
        * Updated Date:- 
        * Purpose:-
        */
        #region-------------------------------------------ClassName_SelectionChanged---------------------------------------
        private void cbClassName1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbClassName1.SelectedValue != "0")
            {
                BindBatchName();
            }
        }
        #endregion

        /*
        * Created By:-
        * Updated By:- 
        * Created Date:-
        * Updated Date:- 
        * Purpose:-
        */
        #region----------------------------------------------cbSubjectName1_SelectionChanged------------------------------------
        private void cbSubjectName1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbSubjectName1.SelectedValue != "0")
            {
                BindTeacher();
            }
        }
        #endregion
        /*
        * Created By:-
        * Updated By:- 
        * Created Date:-
        * Updated Date:- 
        * Purpose:-
        */
        #region--------------------------------------------cbTeacherName_SelectionChanged---------------------------------------------
        private void cbTeacherName1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbTeacherName1.SelectedValue != "0")
            {

            }
        }
        #endregion
    }
}
    

    



