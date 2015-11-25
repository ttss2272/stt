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

        int BranchDistanceID, UpdatedByUserID, IsActive, IsDeleted, ToBranchID, FromBranchID, UpID, DistanceTime;
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
            BindToBranchName();
            BindFromBranchName();
            BindDistance();
        }

        #endregion


        #region-----------------------------------Validation------------------------------------------
        public bool Validate()
        {
            if (cmbToBranch.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select ToBranch Name");
                cmbToBranch.Focus();
                return false;
            }
            else if (cmbFromBranch.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select FromBranch Name");
                cmbFromBranch.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtDistTime.Text))
            {
                MessageBox.Show("Please Select Distance In Time");
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


        #region-------------------------BindDistance()-------------------------------------------------

        public void BindDistance()
        {
            try
            {
                DataSet ds = objBranch.BindDistance(0, Convert.ToInt32(cmbToBranch.SelectedValue), Convert.ToInt32(cmbFromBranch.SelectedValue));

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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BindDistance();
            rdbActive.IsChecked = true;
            btnDelete.IsEnabled = false;
        }


        private void btnclear_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }
    }
}
