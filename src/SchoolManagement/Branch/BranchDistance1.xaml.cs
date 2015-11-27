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
        BLAddBranch objBranch = new BLAddBranch();

        int BranchDistanceID, UpdatedByUserID, IsActive, IsDeleted, ToBranchID, FromBranchID, UpID, DistanceTime, BranchDistID;
        String UpdatedDate;

        public BranchDistance1()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
            this.Width = System.Windows.SystemParameters.PrimaryScreenWidth;
            this.Height = System.Windows.SystemParameters.PrimaryScreenHeight;
            ClearFields();
        }


        #region-------------------------------ClearFields()----------------------------------------
        public void ClearFields()
        {
            cmbToBranch.SelectedIndex = 0;
            cmbFromBranch.SelectedIndex = 0;
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


        #region---------------------------------Setparamerter()-------------------------------------------
        public void Setparameter()
        {
            UpID = 0;
            if (btnAdd.Content.ToString() == "Save")
            {
                BranchDistanceID = UpID;
            }
            else if (btnAdd.Content.ToString() == "Update")
            {
                BranchDistanceID = BranchDistID;
            }
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
                        BranchDistID = Convert.ToInt32(ds.Tables[0].Rows[0]["BranchDistanceID"]);
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


        #region----------------------CmbBranch_SelectionChnaged()-------------------------------------------
        private void cmbFromBranch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cmbToBranch.IsEnabled = true;
            BindToBranchName();
        }

        #endregion

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
                btnDelete.IsEnabled = true;
                btnAdd.Content = "Update";
                gbDist.IsEnabled = true;
                BranchDistID = BranchDistanceID;
              
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
            if (BranchDistID != 0)
            {
                //BranchDistanceID = BranchDistID;

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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BindDistance();
            rdbActive.IsChecked = true;
            btnDelete.IsEnabled = false;
            cmbToBranch.IsEnabled = false;
            gbDist.IsEnabled = false;
        }


        private void btnclear_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

    }
}
