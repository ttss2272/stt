﻿using System;
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
        int ClassID, BranchID, UpdatedByUserID, IsActive, IsDeleted, UpID;
        string ClassName, ShortName, UpdatedDate, Color, Board;
        BLAddClass obj_AddClass = new BLAddClass();
        #endregion

        #region------------------- public Class()------------------------------
        public Class()
        {
            InitializeComponent();
            clearFields();
            BindGridview();
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
                SaveDetails();
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
            string Result = obj_AddClass.saveAddClass(ClassID, ClassName, ShortName, Board, Color,BranchID, UpdatedByUserID, UpdatedDate, IsActive,IsDeleted);
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
            Board = Convert.ToString(cbBoard.SelectedValue.ToString());
            Color = txtcolor.Text.Trim();
            BranchID = Convert.ToInt32(cbBranchName.SelectedValue);
            UpdatedByUserID = 1;
            UpdatedDate = DateTime.Now.ToString();           
            if (rdoActive.IsChecked==true)
            {
                IsActive = 1;
                IsDeleted = 0;
            }
            else
            {
                IsActive = 0;
                IsDeleted = 0;
            }

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

        #region-------------------------btndelete_Click-------------------------------
        private void btndelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               
                MessageBoxResult Result = MessageBox.Show("Do You Really Want To Delete?", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (Result.Equals(MessageBoxResult.Yes))
                {
                    SetParameters();
                    //DeleteSubject();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion

        #region----------------------------DeleteSubject()----------------------------------
        private void DeleteSubject()
        {
            if (UpID != 0)
            {
                ClassID = UpID;

                string Result = obj_AddClass.DeleteClass(ClassID, UpdatedByUserID, UpdatedDate);
                if (Result == "Deleted Sucessfully.")
                {
                    MessageBox.Show(Result, "Delete Sucessfully", MessageBoxButton.OK, MessageBoxImage.Information);
                    clearFields();
                }
                else
                {
                    MessageBox.Show(Result, "Error To Delete", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please Select Class From Class", "Delete Error", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
        }
        #endregion

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


        #region------------------------BindBranchName()---------------------------------------
        private void BindBranchName()
        {
            SqlConnection con = new SqlConnection();
            {
                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand("BindBranchName_SP", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    // DataTable dt = new DataTable();
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Branch");

                    if (ds.Tables["Branch"].Rows.Count > 0)
                    {
                        cbBranchName.DataContext = ds.Tables["Branch"].DefaultView;
                        cbBranchName.DisplayMemberPath = ds.Tables["Branch"].Columns["BranchName"].ToString();
                        cbBranchName.SelectedValuePath = ds.Tables["Branch"].Columns["BranchID"].ToString();
                    }
                }
                catch (Exception eo)
                {
                    MessageBox.Show(eo.Message.ToString());
                }
                finally
                {
                    //cmd.Dispose();
                    con.Close();
                    con.Dispose();
                }
            }
        }
        #endregion

        #region--------------------------------------gridview cell click()-------------------------------------
        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {               
                object item = dgvClass.SelectedItem;
                //string Id = (dgvClass.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                string ClassName = (dgvClass.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                string ShortName = (dgvClass.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                string Board =     (dgvClass.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                string Color = (dgvClass.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
                
                DataSet ds = obj_AddClass.GetClassDetail(ClassName, ShortName,Board,Color);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        UpID = Convert.ToInt32(ds.Tables[0].Rows[0]["ClassID"]);
                        txtClassName.Text = ds.Tables[0].Rows[0]["ClassName"].ToString();
                        txtShortName.Text = ds.Tables[0].Rows[0]["ShortName"].ToString();
                        int act = Convert.ToInt32(ds.Tables[0].Rows[0]["IsActive"]);
                        int del = Convert.ToInt32(ds.Tables[0].Rows[0]["IsDeleted"]);
                        if (act == 1 && del == 0)
                        {
                            rdoActive.IsChecked = true;
                        }
                        else if (act == 0 && del == 0)
                        {
                            rdoDeActive.IsChecked = true;
                        }
                        btnDelete.IsEnabled = true;
                    }
                }



            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion
       
    }
}
