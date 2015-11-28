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
using System.Data;


namespace SchoolManagement.Batch
{
    /// <summary>
    /// Interaction logic for BatchSubject.xaml
    /// </summary>
    public partial class BatchSubject : Window
    {

        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 19 Nov2015
         * Purpose:- Declare Variables globally
         * StartTime:-
         * EndTime:-
         */

        #region-------------------------------------------------------DeclareVariablesGlobally()--------------------------------------------
        BLAddBranch objBranch = new BLAddBranch();
        BLAddClass objClass = new BLAddClass();
        BLBatch objBatch = new BLBatch();
        BLSubject objSubject = new BLSubject();

        int UPID, BranchID, BatchID, BatchSubjectID, SubjectID, NoLectPerDay, NoLectPerWeek, Active, IsDeleted,UpdatedByUserID;
        string UpdatedDate;
        #endregion

        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 19 Nov2015
         * Purpose:-
         * StartTime:-
         * EndTime:-
         */

        #region-------------------------------------------------------Main()----------------------------------------------------------------
        public BatchSubject()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
            this.Width = System.Windows.SystemParameters.PrimaryScreenWidth;
            this.Height = System.Windows.SystemParameters.PrimaryScreenHeight;
            ClearFields();
        }
        #endregion

        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 20 Nov 2015
         * Purpose:-  Clear Fields
         * StartTime:-
         * EndTime:-
         */

        #region-----------------------------------------------------ClearFields()------------------------------------------------------------
        private void ClearFields()
        {
            BindBranch();
            BindSubject();
            BindFreqPerDay();
            BindFreqPerWeek();
            EnableUpperPart();
            //GetBatchSubjectCount();
            
        }
        #endregion

        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 20 Nov 2015
         * Purpose:-  Clear Data
         * StartTime:-
         * EndTime:-
         */

        #region-----------------------------------------------------ClearData()---------------------------------------------------------------
        private void ClearData()
        {
            cmbSubject.SelectedValue = "0";
            cmbFreqPerDay.SelectedIndex = 0;
            cmbFreqPerWeek.SelectedIndex =0;
            GetBatchSubject();
            GetBatchSubjectCount();
            btnSave.Content = "Save";
            rdbActive.IsChecked = true;
            btnDelete.IsEnabled = false;
            
        }
        #endregion
        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 19 Nov2015
         * Purpose:- Bind Drop down Branch
         * StartTime:-
         * EndTime:-
         */

        #region---------------------------------------------------------BindBranch()---------------------------------------------------------
        private void BindBranch()
        {
            DataSet ds = objBranch.BindBranchName();


            if (ds.Tables[0].Rows.Count > 0)
            {
                cmbBranch.DataContext = null;
                
                cmbBranch.DisplayMemberPath = ds.Tables[0].Columns["BranchName"].ToString();
                cmbBranch.SelectedValuePath = ds.Tables[0].Columns["BranchID"].ToString();
                cmbBranch.DataContext = ds.Tables[0].DefaultView;
                cmbBranch.SelectedValue = "0";
                
            }
            else
            {
                //cmbBranch.Items.Add("Select");
                //cmbBranch.SelectedValue = "Select"; 
            }
            
            
            //cmbBatch.Items.Add("Select");
            //cmbBatch.SelectedValue = "Select";
        }
        #endregion

        

        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 19 Nov 2015
         * Purpose:- Bind Batch
         * StartTime:-
         * EndTime:-
         */

        #region---------------------------------------------------------BindBatch()------------------------------------------------------------
        private void BindBatch()
        {
            DataSet ds = objBatch.BindBranchBatch(Convert.ToInt32(cmbBranch.SelectedValue));

            if(ds.Tables[0].Rows.Count > 0)
            {
                int cnt = cmbBatch.Items.Count;
                //cmbBatch.Items.Clear();
                cmbBatch.DataContext = null;
                
                cmbBatch.DisplayMemberPath = ds.Tables[0].Columns["BatchName"].ToString();
                cmbBatch.SelectedValuePath = ds.Tables[0].Columns["BatchID"].ToString();
                cmbBatch.DataContext = ds.Tables[0].DefaultView;
                cmbBatch.SelectedValue = "0";
            }
            else
            {
                //cmbBatch.Items.Add("Select");
                //cmbBatch.SelectedValue = "Select";
            }
        }
        #endregion

        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 19 Nov 2015
         * Purpose:- Branch Selected Index Changed
         * StartTime:-
         * EndTime:-
         */
        #region---------------------------------------------------------Branch Selected Index Change------------------------------------------------------------
        private void cmbBranch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                                   
                if (cmbBranch.SelectedValue.ToString() != "0")
                {
                    BindBatch();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion

        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 20 Nov 2015
         * Purpose:- Button go Event
         * StartTime:-
         * EndTime:-
         */

        #region-------------------------------------------------BtnGoClick()--------------------------------------------------------------
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cmbBatch.SelectedValue.ToString() !="0"&& cmbBatch.SelectedItem.ToString()!="Select")
                {
                    if (btnGo.Content.ToString() == "Go")
                    {
                        GetBatchSubject();
                        DisableUpperPart();
                        GetBatchSubjectCount();
                        
                    }
                    else if(btnGo.Content.ToString()=="Change")
                    {
                        EnableUpperPart();
                        ClearData();
                        grvBatchSubjectcountDetail.DataContext = null;
                        gdvBatchSubjectcount.DataContext = null;
                        gdvSubject.DataContext = null;
                        
                    }
                }
                else
                {
                    MessageBox.Show("Please Select Batch.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion

        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 20 Nov 2015
         * Purpose:- Get Batch Subject List
         * StartTime:-
         * EndTime:-
         */
        #region------------------------------------------------------GetBatchSubject()------------------------------------------------------
        private void GetBatchSubject()

        {
            DataSet ds = objBatch.GetBatchSubject(Convert.ToInt32(cmbBatch.SelectedValue),0);

            if (ds.Tables[0].Rows.Count > 0)
            {
                gdvSubject.DataContext = null;
                gdvSubject.DataContext = ds.Tables[0].DefaultView;

            }
            else
            {
               // MessageBox.Show("There is No Subject Added Please Add Subject");
                gdvSubject.DataContext = null;
            }
 
        }
        #endregion

        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 20 Nov 2015
         * Purpose:- Bind Subject
         * StartTime:-
         * EndTime:-
         */
        #region-------------------------------------------------------BindSubject()----------------------------------------------------
        private void BindSubject()
        {
            DataSet ds = objSubject.BindSubjectName();
            if (ds.Tables[0].Rows.Count > 0)
            {
                cmbSubject.DataContext = null;
                cmbSubject.DisplayMemberPath = ds.Tables[0].Columns["SubjectName"].ToString();
                cmbSubject.SelectedValuePath = ds.Tables[0].Columns["SubjectId"].ToString();
                cmbSubject.DataContext = ds.Tables[0].DefaultView;
                cmbSubject.SelectedValue = "0";
            }
        }
        #endregion

        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 20 Nov 2015
         * Purpose:- Bind Frequency Per Day
         * StartTime:-
         * EndTime:-
         */

        #region-------------------------------------------BindFreqPerDay---------------------------------
        private void BindFreqPerDay()
        {
            cmbFreqPerDay.Items.Clear();
            cmbFreqPerDay.Items.Add("Select");
            int i;
            for (i = 1; i <= 6; i++)
            {
                cmbFreqPerDay.Items.Add(i);
            }
            cmbFreqPerDay.SelectedIndex = 0;
        }
        #endregion

        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 20 Nov 2015
         * Purpose:- Bind Frequency Per Week
         * StartTime:-
         * EndTime:-
         */
        #region-------------------------------------------BindFreqPerWeek---------------------------------
        private void BindFreqPerWeek()
        {
            cmbFreqPerWeek.Items.Clear();
            cmbFreqPerWeek.Items.Add("Select");
            int i;
            for (i = 1; i <= 30; i++)
            {
                cmbFreqPerWeek.Items.Add(i);
            }
            cmbFreqPerWeek.SelectedIndex = 0;
        }
        #endregion

        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 20 Nov 2015
         * Purpose:- Button Save Click
         * StartTime:-
         * EndTime:-
         */
        #region-----------------------------------------------------btnSave_Click-------------------------------------------
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(Validate())
                {
                    SetParameters();
                    SaveDetails();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion

        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 20 Nov 2015
         * Purpose:- Button Delete Click
         * StartTime:-
         * EndTime:-
         */
        #region-------------------------------------------------------btnDelete_Click----------------------------------------
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cmbSubject.SelectedValue.ToString()=="0")
                {
                    MessageBox.Show("Please Select Subject.");
                    cmbSubject.Focus();
                }
                else
                {
                    MessageBoxResult Result = MessageBox.Show("Do You Really Want To Delete?", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Information);
                    if (Result.Equals(MessageBoxResult.Yes))
                    {
                        DeleteDetails();
                    }
                    else
                    {

                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion

        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 20 Nov 2015
         * Purpose:- Button Clear Click
         * StartTime:-
         * EndTime:-
         */
        #region----------------------------------------------------btnClear_Click--------------------------------------------------
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClearData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion

        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 20 Nov 2015
         * Purpose:- SetParameters
         * StartTime:-
         * EndTime:-
         */
        #region----------------------------------------------------SetParameters()--------------------------------------------------
        private void SetParameters()
        {
            SubjectID = Convert.ToInt32(cmbSubject.SelectedValue);
            BatchID = Convert.ToInt32(cmbBatch.SelectedValue);
            NoLectPerDay = Convert.ToInt32(cmbFreqPerDay.SelectedValue);
            NoLectPerWeek = Convert.ToInt32(cmbFreqPerWeek.SelectedValue);
            UpdatedDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
            UpdatedByUserID = 1;
            if (rdbActive.IsChecked==true && rdbInActive.IsChecked==false)
            {
                Active = 1;
            }
            else if(rdbInActive.IsChecked==true && rdbActive.IsChecked==false)
            {
                Active = 0;
            }
            IsDeleted = 0;
        }
        #endregion

        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 20 Nov 2015
         * Purpose:- SetParameters
         * StartTime:-
         * EndTime:-
         */
        #region----------------------------------------------------Validate()--------------------------------------------------
        private bool Validate()
        {
            if (cmbBatch.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("Please Select Batch.", "Select Batch", MessageBoxButton.OK, MessageBoxImage.Warning);
                cmbBatch.Focus();
                return false;
            }
            else if (cmbSubject.SelectedValue.ToString()=="0")
            {
                MessageBox.Show("Please Select Subject", "Select Subject", MessageBoxButton.OK, MessageBoxImage.Warning);
                cmbSubject.Focus();
                return false;
            }
            else if (cmbFreqPerDay.SelectedValue.ToString()=="0"|| cmbFreqPerDay.SelectedItem.ToString()=="Select")
            {
                MessageBox.Show("Please Select Frequecy Of Lecture Per Day.", "Lecture Per Day", MessageBoxButton.OK, MessageBoxImage.Warning);
                cmbFreqPerDay.Focus();
                return false;
            }
            else if (cmbFreqPerWeek.SelectedValue.ToString() == "0" || cmbFreqPerWeek.SelectedItem.ToString() == "Select")
            {
                MessageBox.Show("Please Select Frequecy Of Lecture Per Week.", "Lecture Per Week", MessageBoxButton.OK, MessageBoxImage.Warning);
                cmbFreqPerWeek.Focus();
                return false;
            }
            else if (Convert .ToInt32(cmbFreqPerDay.SelectedItem.ToString())>Convert.ToInt32(cmbFreqPerWeek.SelectedItem.ToString()))
            {
                MessageBox.Show("Frequency Of Lecture Per Week Must Be Greater Or Equal to Frequency of Lecture PerDay ", "Lecture", MessageBoxButton.OK, MessageBoxImage.Warning);
                cmbFreqPerWeek.Focus();
                return false;
            }
            else
            {return true;}
        }
        #endregion

        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 20 Nov 2015
         * Purpose:- SaveDeails
         * StartTime:-
         * EndTime:-
         */
        #region----------------------------------------------------SaveDetails()--------------------------------------------------
        private void SaveDetails()
        {
            string Result = objBatch.SaveBatchSubject(SubjectID, BatchID, NoLectPerDay, NoLectPerWeek, UpdatedByUserID,UpdatedDate, Active, IsDeleted);
            if (Result=="Save Sucessfully...!!!"||Result=="Updated Sucessfully...!!!")
            {
                if (btnSave.Content.ToString() == "Save")
                {
                    MessageBox.Show("This Subject Details Are Save Sucessfully", "Save SucessFull", MessageBoxButton.OK, MessageBoxImage.Information);
                    ClearData();
                }
                else
                {
                    MessageBox.Show("This Subject Details Are Updated Sucessfully", "Update SucessFull", MessageBoxButton.OK, MessageBoxImage.Information);
                    ClearData();
                }
            }
            else
            {
                MessageBox.Show(Result, "Error To Save", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion

        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 20 Nov 2015
         * Purpose:- EnableUpper Part
         * StartTime:-
         * EndTime:-
         */
        #region--------------------------------------------------EnableUpperPart()---------------------------------------------------
        private void EnableUpperPart()
        {
            
            cmbBranch.IsEnabled = true;
            cmbBatch.IsEnabled = true;

            cmbSubject.IsEnabled = false;
            cmbFreqPerDay.IsEnabled = false;
            cmbFreqPerWeek.IsEnabled = false;

            btnSave.IsEnabled = false;
            btnClear.IsEnabled = false;

            
            btnGo.Content = "Go";
            
           
        }
        #endregion

        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 20 Nov 2015
         * Purpose:- Disable Upper Part
         * StartTime:-
         * EndTime:-
         */
        #region--------------------------------------------------DisableUpperPart()--------------------------------------------------
        private void DisableUpperPart()
        {
            cmbBranch.IsEnabled = false;
            cmbBatch.IsEnabled = false;

            cmbSubject.IsEnabled = true;
            cmbFreqPerDay.IsEnabled = true;
            cmbFreqPerWeek.IsEnabled = true;

            btnSave.IsEnabled = true;
            btnClear.IsEnabled = true;
            btnGo.Content = "Change";
        }
        #endregion
        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 20 Nov 2015
         * Purpose:- cmbSubject_SelectionChanged
         * StartTime:-
         * EndTime:-
         */
        #region--------------------------------------------------cmbSubject_SelectionChanged()--------------------------------------------------
        private void cmbSubject_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {

                if(cmbSubject.SelectedValue.ToString()!="0")
                {
                    GetSubjectDetail();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion
        
        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 20 Nov 2015
         * Purpose:- Get SubjectDetail
         * StartTime:-
         * EndTime:-
         */
        #region--------------------------------------------------GetSubjectDetails()--------------------------------------------------
        private void GetSubjectDetail()
        {
            DataSet ds = objBatch.GetBatchSubject(Convert.ToInt32(cmbBatch.SelectedValue), Convert.ToInt32( cmbSubject.SelectedValue));

            if (ds.Tables[0].Rows.Count > 0)
            {
                cmbFreqPerDay.Text = ds.Tables[0].Rows[0]["FrequencyPerDay"].ToString();
                cmbFreqPerWeek.Text = ds.Tables[0].Rows[0]["FrequencyPerWeek"].ToString();
                string act = ds.Tables[0].Rows[0]["IsActive"].ToString();
                if (act == "True")
                {
                    rdbActive.IsChecked = true;
                }
                else if (act == "False")
                {
                    rdbInActive.IsChecked = true;
                }
                btnSave.Content = "Update";
                btnDelete.IsEnabled = true;
            }
            else 
            {
                btnSave.Content = "Save";
                cmbFreqPerDay.SelectedIndex = 0;
                cmbFreqPerWeek.SelectedIndex = 0;
                rdbActive.IsChecked = true;
                btnDelete.IsEnabled = false;
            }
            
        }
        #endregion

        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 20 Nov 2015
         * Purpose:- Delete Details
         * StartTime:-
         * EndTime:-
         */
        #region----------------------------------------------------Deletedetail()------------------------------------------------------
        private void DeleteDetails()
        {
            SetParameters();
            string Result = objBatch.DeleteBatchSubject(BatchID, SubjectID, UpdatedByUserID, UpdatedDate);
            if (Result == "Deleted Sucessfully...!!")
            {
                MessageBox.Show(Result);
                ClearData();
            }
            else
            {
                MessageBox.Show(Result, "Error To Delete");
            }

        }
        #endregion

        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 20 Nov 2015
         * Purpose:- Get SubjectCount
         * StartTime:-
         * EndTime:-
         */
        #region-------------------------------------------------------getSubjectCount------------------------------------------------
        private void GetBatchSubjectCount()
        {
            DataSet ds = objBatch.GetBatchSubjectCount();
            if (ds.Tables[0].Rows.Count>0)
            {
                gdvBatchSubjectcount.DataContext = null;
                gdvBatchSubjectcount.DataContext = ds.Tables[0].DefaultView;
            }
        }
        #endregion

        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 20 Nov 2015
         * Purpose:- SubjectCountRow Click()
         * StartTime:-
         * EndTime:-
         */
        #region-------------------------------------------SubjectCountRow Click()--------------------------------------------------------
        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                object item = gdvBatchSubjectcount.SelectedItem;
                int TempID = Convert.ToInt32(((System.Data.DataRowView)(gdvBatchSubjectcount.CurrentItem)).Row.ItemArray[2].ToString());
                GetBatchSubject(TempID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion

        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 20 Nov 2015
         * Purpose:- Get Batch Subject List on Double Row Click
         * StartTime:-
         * EndTime:-
         */
        #region------------------------------------------------------GetBatchSubject()------------------------------------------------------
        private void GetBatchSubject(int BTID)
        {
            DataSet ds = objBatch.GetBatchSubject(BTID, 0);

            if (ds.Tables[0].Rows.Count > 0)
            {
                grvBatchSubjectcountDetail.DataContext = null;
                grvBatchSubjectcountDetail.DataContext = ds.Tables[0].DefaultView;

            }
            else
            {
                MessageBox.Show("There is No Subject Added Please Add Subject");
            }

        }
        #endregion

        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 20 Nov 2015
         * Purpose:- Copy Subject Details
         * StartTime:-
         * EndTime:-
         */
        #region----------------------------------------------Copy Subject To Batch()-----------------------------------------------------
        private void CopySubject()
        { 
        }
        #endregion

        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 20 Nov 2015
         * Purpose:- Click Button Copy All Subject
         * StartTime:-
         * EndTime:-
         */
        #region----------------------------------------------Click Button Subject To Batch()-----------------------------------------------------
        private void btnAddAll_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int tmp = 0, cnt = 0;
                int count =Convert.ToInt32(grvBatchSubjectcountDetail.Items.Count);
                if (cmbBatch.SelectedValue.ToString() != "0" && cmbBatch.SelectedItem.ToString() != "Select")
                {
                    if (grvBatchSubjectcountDetail.Items.Count > 0)
                    {
                        for (int i = 0; i < grvBatchSubjectcountDetail.Items.Count; i++)
                        {
                            cnt++;
                            System.Data.DataRowView selectedFile = (System.Data.DataRowView)grvBatchSubjectcountDetail.Items[i];
                            SubjectID = Convert.ToInt32(selectedFile.Row.ItemArray[1]);
                            BatchID = Convert.ToInt32(cmbBatch.SelectedValue);
                            NoLectPerDay = Convert.ToInt32(selectedFile.Row.ItemArray[3]);
                            NoLectPerWeek = Convert.ToInt32(selectedFile.Row.ItemArray[4]);
                            UpdatedByUserID = 1;
                            UpdatedDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
                            string act = Convert.ToString(selectedFile.Row.ItemArray[6]);
                            if (act == "True")
                            {
                                Active = 1;

                            }
                            else if (act == "False")
                            {
                                Active = 0;
                            }
                            IsDeleted = 0;
                            string Result = objBatch.SaveBatchSubject(SubjectID, BatchID, NoLectPerDay, NoLectPerWeek, UpdatedByUserID, UpdatedDate, Active, IsDeleted);
                            if (Result == "Save Sucessfully...!!!" || Result == "Updated Sucessfully...!!!")
                            {

                                tmp++;
                            }
                            else
                            {

                            }
                        }
                        if (tmp == cnt)
                        {
                            MessageBox.Show("Details Copy Sucessfully.", "Copy Sucessfull", MessageBoxButton.OK, MessageBoxImage.Information);
                            ClearData();
                        }
                        else
                        {
                            MessageBox.Show("Some Details Are Not Copied", "Error To Copy", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Select At Least One Subject", "Info", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Please Select Batch First", "Info", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception");
            }

        }
        #endregion

        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:- 20 Nov 2015
         * Purpose:- Click Button Copy One Subject
         * StartTime:-
         * EndTime:-
         */
        #region----------------------------------------------Click Button Copy One Subject To Batch()-----------------------------------------------------
        private void btnAddSingle_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int tmp = 0,cnt=0;
                if (cmbBatch.SelectedValue.ToString()!= "0" && cmbBatch.SelectedItem.ToString()!="Select")
                {
                    if (grvBatchSubjectcountDetail.SelectedItems.Count > 0)
                    {
                        for (int i = 0; i < grvBatchSubjectcountDetail.SelectedItems.Count; i++)
                        {
                            cnt++;
                            System.Data.DataRowView selectedFile = (System.Data.DataRowView)grvBatchSubjectcountDetail.SelectedItems[i];
                            SubjectID = Convert.ToInt32(selectedFile.Row.ItemArray[1]);
                            BatchID = Convert.ToInt32(cmbBatch.SelectedValue);
                            NoLectPerDay = Convert.ToInt32(selectedFile.Row.ItemArray[3]);
                            NoLectPerWeek = Convert.ToInt32(selectedFile.Row.ItemArray[4]);
                            UpdatedByUserID = 1;
                            UpdatedDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
                            string act = Convert.ToString(selectedFile.Row.ItemArray[6]);
                            if (act == "True")
                            {
                                Active = 1;

                            }
                            else if (act == "False")
                            {
                                Active = 0;
                            }
                            IsDeleted = 0;
                            string Result = objBatch.SaveBatchSubject(SubjectID, BatchID, NoLectPerDay, NoLectPerWeek, UpdatedByUserID, UpdatedDate, Active, IsDeleted);
                            if (Result == "Save Sucessfully...!!!" || Result == "Updated Sucessfully...!!!")
                            {

                                tmp++;
                            }
                            else
                            {

                            }
                        }
                        if (tmp == cnt)
                        {
                            MessageBox.Show("Details Copy Sucessfully.", "Copy Sucessfull", MessageBoxButton.OK, MessageBoxImage.Information);
                            ClearData();
                        }
                        else
                        {
                            MessageBox.Show("Some Details Are Not Copied", "Error To Copy", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Select At Least One Subject", "Info", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Please Select Batch First","Info",MessageBoxButton.OK,MessageBoxImage.Warning);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception");
            }
        }
        #endregion
    }
}
