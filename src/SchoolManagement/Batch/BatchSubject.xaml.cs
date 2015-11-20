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
                if (cmbBatch.SelectedValue != "0")
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
                gdvSubject.DataContext = ds;

            }
            else
            {
                MessageBox.Show("There is No Subject Added Please Add Subject");
            }
 
        }
        #endregion

    }
}
