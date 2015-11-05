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

namespace SchoolManagement.Branch
{
    /// <summary>
    /// Interaction logic for Class.xaml
    /// </summary>
    public partial class Class : Window
    {
            /*
          * Created By:- Pravin
          * Ctreated Date :- 4 Nov 2015
          * StartTime:-3:20PM
          * EndTime:-
          * Purpose:- Declare Global Variables
          */
        #region------------------------Declare Variables Globally()--------------------
        int ClassID,BranchID, UpdatedByUserID, IsActive,Board;
        string ClassName, ShortName, UpdatedDate ,Color;
        BLAddClass obj_AddClass = new BLAddClass();
        #endregion

        #region------------------- public Class()------------------------------
        public Class()
        {
            InitializeComponent();
            clearFields();
        }

        #endregion

        /*
       * Created By:- Pravin
       * Ctreated Date :- 4 Nov 2015
       * StartTime:-3:32PM
       * EndTime:-3:34PM
       * Purpose Save button code
       */
         #region----------------------------------------btnAdd_Click-------------------------------------------
        private void btnadd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Validate();
                SetParameters();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }            
        }
        #endregion

        /*
         * Created By:- Pravin
         * Ctreated Date :- 4 Nov 2015
         * StartTime:-PM
         * EndTime:-PM
         * Purpose:- SaveDetails
         */
         #region--------------------------------------SaveDetails()-------------------------------------
        private void SaveDetails()
        {
            string Result = obj_AddClass.saveAddClass(ClassID, ClassName, ShortName, Board, Color, UpdatedByUserID, UpdatedDate, IsActive);
            if (Result == "Save Sucessfully...!!!" && Result == "Updated Sucessfully...!!!")
            {
         MessageBox.Show(Result, "Save SucessFull", MessageBoxButton.OK, MessageBoxImage.Information);
         clearFields();
            }
            else
            {
                MessageBox.Show(Result, "Error To Save", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion                                                                   

        /*
         * Created By:- Pravin
         * Ctreated Date :- 4 Nov 2015
         * StartTime:-PM
         * EndTime:-PM
         * Purpose:- Close button code
         */
        #region--------------------------btncancel_Click-----------------------------
        private void btncancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion

        /*
         * Created By:- Pravin
         * Ctreated Date :- 4 Nov 2015
         * StartTime:-4:00PM
         * EndTime:-4:32 PM
         * Purpose:- validations
         */
        #region---------------------------Validate()-----------------------------------------
        public bool Validate()
        {

            if (txtClassName.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Class Name.", "Class Name Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtClassName.Focus();
                return false;
            }
            else if (txtShortName.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Class Short Name.", "Short Name Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtShortName.Focus();
                return false;
            }
            else if (txtcolor.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Color.", "Color Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtcolor.Focus();
                return false;
            }
            else if (cbBoard.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Board.", "Board Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                cbBoard.Focus();
                return false;
            }

            else
            {
                return true;

            }
        }
        #endregion

        /*
         * Created By:- Pravin
         * Ctreated Date :- 4 Nov 2015
         * StartTime:-4:00PM
         * EndTime:-
         * Purpose:- SetParameters
         */
        #region-------------------------------------------------SetParameters()-------------------------------------
        private void SetParameters()
        {
            //BranchID = Convert.ToInt32(cbBranchName.SelectedValue.ToString());
            ClassName = txtClassName.Text.Trim();
            ShortName = txtShortName.Text.Trim();
            Board = Convert.ToInt32(cbBoard.SelectedValue.ToString());
            Color = txtcolor.Text.Trim();
            UpdatedByUserID = 1;
            UpdatedDate = DateTime.Now.ToString();
            IsActive = 1;

        }
        #endregion

        /*
         * Created By:- Pravin
         * Ctreated Date :- 4 Nov 2015
         * StartTime:-PM
         * EndTime:-PM
         * Purpose Clear All Fields
         */
        #region-----------------------------clearFields()------------------------------------------
        private void clearFields()
        {
            txtClassName.Text = "";
            txtShortName.Text = "";
            cbBoard.Text = "";
            txtcolor.Text = "";
        }
        #endregion                    

        private void btndelete_Click(object sender, RoutedEventArgs e)
        {

        }

        /*
        * Created By:- Pravin
        * Ctreated Date :- 4 Nov 2015
        * StartTime:-4:25PM
        * EndTime:-4:27 PM
        * Purpose:- txtClassName Text changed validations
        */
         #region-------------------------------------------------txtClassName()-------------------------------------
        private void txtClassName_TextChanged(object sender, TextChangedEventArgs e)
        {                      
            try
            {
                if (txtClassName.Text != "")
                {
                    if (txtClassName.Text.Length > 0 && txtClassName.Text.Length == 1)
                    {
                        if (System.Text.RegularExpressions.Regex.IsMatch(txtClassName.Text, "^[a-zA-Z]"))
                        {
                        }
                        else
                        {
                            MessageBox.Show("Please Enter First Characerter Alphabate","Class Name",MessageBoxButton.OK,MessageBoxImage.Warning);
                            txtClassName.Text = "";
                            txtClassName.Focus();
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
        * Ctreated Date :- 4 Nov 2015
        * StartTime:-4:25PM
        * EndTime:-4:27 PM
        * Purpose:- txtShortName Text changed validations
        */
        #region----------------------------------txtShortName_TextChanged---------------------
        private void txtShortName_TextChanged(object sender, TextChangedEventArgs e)
        {
             try
            {
                if (txtShortName.Text != "")
                {
                    if (txtShortName.Text.Length > 0 && txtShortName.Text.Length == 1)
                    {
                        if (System.Text.RegularExpressions.Regex.IsMatch(txtShortName.Text, "^[a-zA-Z]"))
                        {
                        }
                        else
                        {
                            MessageBox.Show("Please Enter First Characerter Alphabate","Class Short Name",MessageBoxButton.OK,MessageBoxImage.Warning);
                            txtShortName.Text = "";
                            txtShortName.Focus();
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
         * Ctreated Date :- 4 Nov 2015
         * StartTime:-PM
         * EndTime:-PM
         * Purpose:- Bind Grid
         */
        #region----------------------------------grvClassBind----------------------------------------------------
        private void BindGridview()
        {
            DataSet ds = obj_AddClass.BindClass(0);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dgvClass.ItemsSource = ds.Tables[0].DefaultView;
                dgvClass.Columns[0].Visibility = Visibility.Collapsed;
            }
        }
        #endregion
       
    }
}
