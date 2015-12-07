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
using System.Data.SqlClient;
using System.Configuration;
using BusinessLayer;

namespace SchoolManagement.Branch
{
    /// <summary>
    /// Interaction logic for BranchDistance1.xaml
    /// </summary>
    public partial class BranchDistance1 : Window
    {
        /* Created By:- 
        * Created Date :-
        * Purpose:- 
        */
        #region------------------------------------------------------Declare Variables------------------------------------------------
        BLAddBranch objBranch = new BLAddBranch();

        int BranchDistanceID, UpdatedByUserID, IsActive, IsDeleted, ToBranchID, FromBranchID, UpID, DistanceTime, BranchDistID;
        String UpdatedDate;
        #endregion

        /* Created By:- 
        * Created Date :-
        * Purpose:- 
        */
        #region----------------------------------------------------------main()-------------------------------------------------
        public BranchDistance1()
        {
            try
            {
                InitializeComponent();
                this.WindowState = WindowState.Maximized;
                this.Width = System.Windows.SystemParameters.PrimaryScreenWidth;
                this.Height = System.Windows.SystemParameters.PrimaryScreenHeight;
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
        }
        #endregion
        /* Created By:- Pranjali Vidhate
        * Created Date :- 23  Nov 2015
        * Purpose:- clear Fields*/

        #region-------------------------------ClearFields()----------------------------------------
        public void ClearFields()
        {
            UpID = 0;
            cmbFromBranch.SelectedIndex = 0;
            cmbToBranch.SelectedIndex = 0;
            txtDistTime.Text = "";
            btnAdd.Content = "Save";
            btnDelete.IsEnabled = false;
            cmbToBranch.IsEnabled = false;
            gbDist.IsEnabled = false;
            rdbActive.IsChecked = true;
            BindFromBranchName();
            BindToBranchName();
            BindDistance();
        }

        #endregion

        /* Created By:- Pranjali Vidhate
        * Created Date :- 23  Nov 2015
        * Purpose:- Validate All Fields*/

        #region-----------------------------------Validation------------------------------------------
        public bool Validate()
        {
            if (cmbFromBranch.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select FromBranch Name");
                cmbFromBranch.Focus();
                return false;
            }
            else if (cmbToBranch.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select ToBranch Name");
                cmbToBranch.Focus();
                return false;
            }
            else if (gbDist.IsEnabled == true && string.IsNullOrEmpty(txtDistTime.Text))
            {
                MessageBox.Show("Please Enter Distance In Time");
                txtDistTime.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion

        /* Created By:- Pranjali Vidhate
        * Created Date :- 23  Nov 2015
        * Purpose:- SetParameters*/

        #region---------------------------------Setparamerter()-------------------------------------------
        public void Setparameter()
        {
            BranchDistanceID = UpID;
            ToBranchID = Convert.ToInt32(cmbToBranch.SelectedValue.ToString());
            FromBranchID = Convert.ToInt32(cmbFromBranch.SelectedValue.ToString());
            DistanceTime = Convert.ToInt32(txtDistTime.Text.ToString());
            UpdatedByUserID = 1;
            UpdatedDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
            if (rdbActive.IsChecked == true)
            {
                IsActive = 1;
                IsDeleted = 0;
            }
            else if (rdbInactive.IsChecked == true)
            {
                IsActive = 0;
                IsDeleted = 0;
            }
        }
        #endregion

        /* Created By:- Pranjali Vidhate
        * Created Date :- 23  Nov 2015
        * Purpose:- Validate All Fields*/

        #region-------------------------------------Save()---------------------------------------------------
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Validate())
                {
                    Setparameter();
                    string Result = objBranch.SaveDisatnce(BranchDistanceID, ToBranchID, FromBranchID, DistanceTime, UpdatedByUserID, UpdatedDate, IsActive, IsDeleted);
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

        /* Created By:- Pranjali Vidhate
        * Created Date :- 23  Nov 2015
        * Purpose:- Go Button Coding*/

        #region-------------------------------Go()--------------------------------------------------

        private void btnGo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Validate())
                {
                    DataSet ds = objBranch.BindDistance(0, Convert.ToInt32(cmbFromBranch.SelectedValue), Convert.ToInt32(cmbToBranch.SelectedValue));

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        UpID = Convert.ToInt32(ds.Tables[0].Rows[0]["BranchDistanceID"]);
                        txtDistTime.Text = ds.Tables[0].Rows[0]["DistanceTime"].ToString();
                        IsActive = Convert.ToInt32(ds.Tables[0].Rows[0]["IsActive"]);
                        IsDeleted = Convert.ToInt32(ds.Tables[0].Rows[0]["IsDeleted"]);

                        if (IsActive == 1 && IsDeleted == 0)
                        {
                            rdbActive.IsChecked = true;
                        }
                        else if (IsActive == 0 && IsDeleted == 0)
                        {
                            rdbInactive.IsChecked = true;
                        }
                        btnDelete.IsEnabled = true;
                        btnAdd.Content = "Update";
                        gbDist.IsEnabled = true;
                    }
                    else
                    {
                        MessageBox.Show("This Is The First Entry For Selected Branch", "Branch", MessageBoxButton.OK, MessageBoxImage.Information);
                        gbDist.IsEnabled = true;
                        txtDistTime.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion

        /* Created By:- Pranjali Vidhate
        * Created Date :- 23  Nov 2015
        * Purpose:- Bind Distance Grid */

        #region-------------------------BindDistance()-------------------------------------------------

        public void BindDistance()
        {
            try
            {
                DataSet ds = objBranch.BindDistance(0, Convert.ToInt32(cmbFromBranch.SelectedValue),Convert.ToInt32(cmbToBranch.SelectedValue));

                if (ds.Tables[0].Rows.Count > 0)
                {
                    dgDistanceTime.ItemsSource = ds.Tables[0].DefaultView;
                }

                dgDistanceTime.Items.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion

        /* Created By:- Pranjali Vidhate
        * Created Date :- 23  Nov 2015
        * Purpose:- Bind Branch*/

        #region---------------------------BindBranch()-------------------------------------------------

        private void BindToBranchName()
        {
            try
            {
                DataSet ds = objBranch.BindToBranchName(Convert.ToInt32(cmbFromBranch.SelectedValue));

                if (ds.Tables[0].Rows.Count > 0)
                {

                    cmbToBranch.DisplayMemberPath = ds.Tables[0].Columns["BranchName"].ToString();
                    cmbToBranch.SelectedValuePath = ds.Tables[0].Columns["BranchID"].ToString();
                    cmbToBranch.DataContext = ds.Tables[0].DefaultView;
                    cmbToBranch.SelectedValue = "0";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }


        public void BindFromBranchName()
        {
            try
            {
                DataSet ds = objBranch.BindBranchName();

                if (ds.Tables[0].Rows.Count > 0)
                {

                    cmbFromBranch.DisplayMemberPath = ds.Tables[0].Columns["BranchName"].ToString();
                    cmbFromBranch.SelectedValuePath = ds.Tables[0].Columns["BranchID"].ToString();
                    cmbFromBranch.DataContext = ds.Tables[0].DefaultView;
                    cmbFromBranch.SelectedValue = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        #endregion

        /* Created By:- Pranjali Vidhate
        * Created Date :- 23  Nov 2015
        * Purpose:- Branch Selection Change*/

        #region----------------------CmbBranch_SelectionChnaged()-------------------------------------------
        private void cmbFromBranch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cmbToBranch.IsEnabled = true;
            BindToBranchName();
            //if (btnAdd.Content.ToString() == "Update")
            //{
            //    if (cmbToBranch.SelectedValue.ToString() == "0")
            //    {
            //        cmbToBranch.IsEnabled = false;
            //    }
            //    else { cmbToBranch.IsEnabled = true; }
            //}
            //else if (btnAdd.Content.ToString() == "Save")
            //{
            //    if (cmbFromBranch.SelectedValue.ToString() == "0")
            //    {
            //        cmbToBranch.IsEnabled = false;
            //    }
            //    else { cmbToBranch.IsEnabled = true; }
            //}
        }

        #endregion

        /* Created By:- Pranjali Vidhate
        * Created Date :- 24  Nov 2015
        * Purpose:- GridView Click coding*/

        #region------------------------------GridViewClick()---------------------------------------------
        private void RowDouble_click(object sender, MouseButtonEventArgs e)
        {
            try
            {
                object item = dgDistanceTime.SelectedItem;
                BranchDistanceID = Convert.ToInt32(((System.Data.DataRowView)(dgDistanceTime.CurrentItem)).Row.ItemArray[0].ToString());
                cmbFromBranch.SelectedValue = Convert.ToInt32(((System.Data.DataRowView)(dgDistanceTime.CurrentItem)).Row.ItemArray[4].ToString());
                BindToBranchName();
                cmbToBranch.SelectedValue = Convert.ToInt32(((System.Data.DataRowView)(dgDistanceTime.CurrentItem)).Row.ItemArray[5].ToString());
                //string FromBranch =(dgDistanceTime.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                //string ToBranch = (dgDistanceTime.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                txtDistTime.Text = (((System.Data.DataRowView)(dgDistanceTime.CurrentItem)).Row.ItemArray[3].ToString());
                string Act = (((System.Data.DataRowView)(dgDistanceTime.CurrentItem)).Row.ItemArray[7].ToString());
                string Del = (((System.Data.DataRowView)(dgDistanceTime.CurrentItem)).Row.ItemArray[8].ToString());

                if (Act == "True" && Del == "False")
                {
                    rdbActive.IsChecked = true;
                }
                else if (Act == "False" && Del == "False")
                {
                    rdbInactive.IsChecked = true;
                }
                else if (Act == "False" && Del == "True")
                {
                    rdbInactive.IsChecked = true;
                }
                btnDelete.IsEnabled = true;
                btnAdd.Content = "Update";
                gbDist.IsEnabled = true;
                UpID = BranchDistanceID;
                cmbToBranch.IsEnabled = true;
              
                //DataSet ds = objBranch.BindDistance(0, Convert.ToInt32(cmbFromBranch.SelectedValue), Convert.ToInt32(cmbToBranch.SelectedValue));

                //if (ds.Tables.Count > 0)
                //{
                //    if (ds.Tables[0].Rows.Count > 0)
                //    {
                //        UpID = Convert.ToInt32(ds.Tables[0].Rows[0]["BranchDistanceID"]);
                //        cmbFromBranch.Text = ds.Tables[0].Rows[0]["From_BranchID"].ToString();
                //        cmbToBranch.Text = ds.Tables[0].Rows[0]["To_BranchID"].ToString();
                //        txtDistTime.Text = ds.Tables[0].Rows[0]["DistanceTime"].ToString();
                        
                //        IsActive= Convert.ToInt32(ds.Tables[0].Rows[0]["IsActive"]);
                //        IsDeleted = Convert.ToInt32(ds.Tables[0].Rows[0]["IsDeleted"]);
                //        if (IsActive == 1 && IsDeleted == 0)
                //        {
                //            rdbActive.IsChecked = true;
                //        }
                //        else if (IsActive == 0 && IsDeleted == 0)
                //        {
                //            rdbInactive.IsChecked = true;
                //        }
                //        btnDelete.IsEnabled = true;
                //        btnAdd.Content = "Update";
                //    }
                //}
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion

        /* Created By:- Pranjali Vidhate
        * Created Date :- 24  Nov 2015
        * Purpose:- Delete Distance*/

        #region------------------------------Delete()-------------------------------------------------
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Validate())
                {
                    MessageBoxResult Result = MessageBox.Show("Do You Really Want To Delete?", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Information);
                    Setparameter();
                    DeleteDistance();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void DeleteDistance()
        {
            if (UpID != 0)
            {
                string Result = objBranch.DeleteDistance(BranchDistanceID, UpdatedByUserID, UpdatedDate);
                if (Result == "Deleted Sucessfully...!!")
                {
                    MessageBox.Show(Result, "Delete Sucessfully", MessageBoxButton.OK, MessageBoxImage.Information);
                    ClearFields();
                }
                else
                {
                    MessageBox.Show(Result, "Error To Delete", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please Select Distance in Branches", "Delete Error", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
        }
        #endregion

        /*
         * Updated BY:- 
         * Updated Date :-
         * Update Purpose:-
         */
        #region-----------------------------------------Window_Loaded-------------------------------------
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                BindDistance();
                rdbActive.IsChecked = true;
                btnDelete.IsEnabled = false;
                cmbToBranch.IsEnabled = false;
                gbDist.IsEnabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
        }
        #endregion

        /*
         * Updated BY:- PriTesh D. Sortee
         * Updated Date :-07 Dec 2015
         * Update Purpose:-Add Try CatchBlock
         */
        #region-------------------------------------------btnClear_Click--------------------------------
        private void btnclear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
        #endregion
        /*
         * Created By:- Pranjali Vidhate
         * Created date:- 07 Dec 2015
         * Purpose:- Time accepet only numbers
         */
        #region-----------------------------------------------txtDistTIme_TextChanged-------------------------------------
        private void txtDistTime_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (txtDistTime.Text != "")
                {
                    if (txtDistTime.Text.Length > 0)
                    {
                        if (System.Text.RegularExpressions.Regex.IsMatch(txtDistTime.Text, "^[0-9]+$"))
                        {

                        }
                        else
                        {
                            MessageBox.Show("Please Enter Only Numbers", "Distance", MessageBoxButton.OK, MessageBoxImage.Information);
                            txtDistTime.Text = "";
                            txtDistTime.Focus();
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

    }
}
