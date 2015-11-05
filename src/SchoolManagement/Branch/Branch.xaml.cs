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

namespace SchoolManagement.Branch
{
    /// <summary>
    /// Interaction logic for Branch.xaml
    /// </summary>
    public partial class Branch : Window
    {
        public Branch()
        {
            InitializeComponent();
            ClearFields();
            BindGridview();
        }
        /*
       * Created By:- Sameer Shinde
       * Ctreated Date :- 5 Nov 2015
       * Purpose:- Declare Global Variables
       */
        #region-----------------Declare Variables GlobalVariables()----------------
        BLAddBranch obj_AddBranch = new BLAddBranch();
        int BranchID, UpdatedByUserID, IsActive;
        string BranchName, BranchCode,InstituteName,Logo,UpdatedDate;
        #endregion
        /*
       * Created By:- Sameer Shinde
       * Ctreated Date :- 5 Nov 2015
       * Purpose:- Save click Code
       */
        #region---------BtnSaveClick()---------------------------------
        private void btnSave_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Validate();
                SetParameters();
                SaveDetails();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        /*
      * Created By:- Sameer Shinde
      * Ctreated Date :- 5 Nov 2015
      * Purpose:- Create Save Details function for save cade
      */
        #region-------------SaveDetails()-----------------
        private void SaveDetails()
        {
            string Result = obj_AddBranch.SaveBranch(BranchID, BranchName, BranchCode, InstituteName, Logo, UpdatedByUserID, UpdatedDate, IsActive);
            if (Result == "Save Sucessfully...!!!" || Result == "Updated Sucessfully...!!!")
            {
                MessageBox.Show(Result, "Save SucessFull", MessageBoxButton.OK, MessageBoxImage.Information);
                ClearFields();
            }
            else
            {
                MessageBox.Show(Result, "Error To Save", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        /*
      * Created By:- Sameer Shinde
      * Ctreated Date :- 5 Nov 2015
      * Purpose:- Clear all fields
      */
        #region---------------------ClearFeilds()------------------
        private void ClearFields()
        {
            txtBranchName.Text = "";
            txtBranchCode.Text = "";
            txtInstituteName.Text = "";
            txtUploadPath.Text = "";
            //image1.ClearValue();
        }
        #endregion
       
        #endregion
               
        #endregion
        #region------------------btnEdit------------------------------
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion
        /*
       * Created By:- Sameer Shinde
       * Ctreated Date :- 5 Nov 2015
       * Purpose:- For Exit
       */
        #region---------------------------------------------------
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion
        /*
       * Created By:- Sameer Shinde
       * Ctreated Date :- 5 Nov 2015
       * Purpose:- Apply validation
       */
        #region-------Validate()-------------------
        private bool Validate()
        {
            if (txtBranchName.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Branch Name.", "Branch Name Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtBranchName.Focus();
                return false;
            }
            else if (txtBranchCode.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Branch Code.", "Branch Code Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtBranchCode.Focus();
                return false;
            }
            else if (txtInstituteName.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Institute Name.", "Institute Name Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtInstituteName.Focus();
                return false;
            }
            else if (txtUploadPath.Text.Trim() == "")
            {
                MessageBox.Show("Please Select Institute logo.", "Institute Logo Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtUploadPath.Focus();
                return false;
            }
            else
            {
                return true;

            }
        }
        #endregion
        /*
       * Created By:- Sameer Shinde
       * Ctreated Date :- 5 Nov 2015
       * Purpose:- Set Parameters for Save 
       */
        #region---------------SetParameters()-------------------------
        private void SetParameters()
        {
            BranchID = 0;
            BranchName = txtBranchName.Text.Trim();
            BranchCode =txtBranchCode.Text.Trim();
            InstituteName = txtInstituteName.Text.Trim();
            Logo = txtUploadPath.Text.Trim();
            UpdatedByUserID = 1;
            UpdatedDate = DateTime.Now.ToString();
            IsActive = 1;
        }
        #endregion
        /*
       * Created By:- Sameer Shinde
       * Ctreated Date :- 5 Nov 2015
       * Purpose:- Accept only characters in Branch Name
       */
        #region----------BranchNameTextchange-----------------------------
        private void txtBranchName_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (txtBranchName.Text != "")
                {
                    if (txtBranchName.Text.Length > 0 && txtBranchName.Text.Length == 1)
                    {
                        if (System.Text.RegularExpressions.Regex.IsMatch(txtBranchName.Text, "^[a-zA-Z]"))
                        {
                        }
                        else
                        {
                            MessageBox.Show("Please Enter First Characerter Alphabate", "Branch Name", MessageBoxButton.OK, MessageBoxImage.Warning);
                            txtBranchName.Text = "";
                            txtBranchName.Focus();
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
       * Created By:- Sameer Shinde
       * Ctreated Date :- 5 Nov 2015
       * Purpose:- Accept only characters in Institute Name
       */
        #region------------InstituteTextChange------------------------------------------
        private void txtInstituteName_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (txtInstituteName.Text != "")
                {
                    if (txtInstituteName.Text.Length > 0 && txtInstituteName.Text.Length == 1)
                    {
                        if (System.Text.RegularExpressions.Regex.IsMatch(txtInstituteName.Text, "^[a-zA-Z]"))
                        {
                        }
                        else
                        {
                            MessageBox.Show("Please Enter First Characerter Alphabate", "Institute Name", MessageBoxButton.OK, MessageBoxImage.Warning);
                            txtInstituteName.Text = "";
                            txtInstituteName.Focus();
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

        #region----------------------------------grvSubjectBind----------------------------------------------------
        private void BindGridview()
        {
            DataSet ds = obj_AddBranch.BindBranch(0);
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdvBranch.ItemsSource = ds.Tables[0].DefaultView;
                grdvBranch.Columns[0].Visibility = Visibility.Collapsed;
            }
        }
        #endregion
        
    }
}
