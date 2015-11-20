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
                cmbBranch.Items.Add("Select");
                cmbBranch.SelectedValue = "Select"; 
            }
            
            
            cmbBatch.Items.Add("Select");
            cmbBatch.SelectedValue = "Select";
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
                cmbBatch.Items.Clear();
                cmbBatch.DataContext = null;
                
                cmbBatch.DisplayMemberPath = ds.Tables[0].Columns["BatchName"].ToString();
                cmbBatch.SelectedValuePath = ds.Tables[0].Columns["BatchID"].ToString();
                cmbBatch.DataContext = ds.Tables[0].DefaultView;
                cmbBatch.SelectedValue = "0";
            }
            else
            {
                cmbBatch.Items.Add("Select");
                cmbBatch.SelectedValue = "Select";
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
                if (cmbBatch.SelectedValue.ToString() != "0")
                {
                    GetBatchSubject();
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
            DataSet ds = objBatch.GetBatchSubject(Convert.ToInt32(cmbBatch.SelectedValue));

            if (ds.Tables[0].Rows.Count > 0)
            {
                gdvSubject.DataContext = null;
                gdvSubject.DataContext = ds.Tables[0].DefaultView;

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
            else if (cmbFreqPerDay.SelectedValue.ToString()=="0")
            {
                MessageBox.Show("Please Select Frequecy Of Lecture Per Day.", "Lecture Per Day", MessageBoxButton.OK, MessageBoxImage.Warning);
                cmbFreqPerDay.Focus();
                return false;
            }
            else if (cmbFreqPerWeek.SelectedValue.ToString() == "0")
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

    }
}
