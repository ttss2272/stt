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

namespace SchoolManagement.Class
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
        int ClassID, BranchID, UpdatedByUserID, IsActive, IsDeleted, UpID,TempID;
        string ClassName, ShortName, UpdatedDate, Color, Board;
        BLAddClass obj_AddClass = new BLAddClass();
        BLAddBranch obj_Branch = new BLAddBranch();
        #endregion

        #region------------------- public Class()------------------------------
        public Class()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
            this.Width = System.Windows.SystemParameters.PrimaryScreenWidth;
            this.Height = System.Windows.SystemParameters.PrimaryScreenHeight;
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
                if (Validate())
                {
                    SetParameters();
                    SaveDetails();
                   // BindGridview();
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
         * Purpose:- SaveDetails
         */
         #region--------------------------------------SaveDetails()-------------------------------------
        private void SaveDetails()
        {
            string Result = obj_AddClass.saveAddClass(ClassID, ClassName, ShortName, Board, Color,BranchID, UpdatedByUserID, UpdatedDate, IsActive,IsDeleted);
            if (Result == "Save Sucessfully...!!!" || Result == "Updated Sucessfully...!!!")
            {
                 MessageBox.Show(Result, "Save SucessFull", MessageBoxButton.OK, MessageBoxImage.Information);
                 clearFields();
                 ClearData();
                 //BindBranchName();
                 //cbBranchName.IsEnabled = true;
                 //btnGo.Content = "Go";
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
        #region--------------------------btnclose_Click-----------------------------
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                clearFields();
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
            if (cbBranchName.Text=="Select")
            {
                MessageBox.Show("Please Select Branch Name.", "Branch Name Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                cbBranchName.Focus();
                return false;
            }

            else if (gbInfo.IsEnabled == false)
            {
                MessageBox.Show("First Click on Go");
               // MessageBox.Show("You Are Coping The features Of Other Branch");
                return false;
            } 

            else if (txtClassName.Text.Trim() == "" || string.IsNullOrEmpty(txtClassName.Text))
            {
                MessageBox.Show("Please Enter Class Name.", "Class Name Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtClassName.Focus();
                return false;
            }
            else if (txtShortName.Text.Trim() == "" || string.IsNullOrEmpty(txtShortName.Text))
            {
                MessageBox.Show("Please Enter Class Short Name.", "Short Name Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtShortName.Focus();
                return false;
            }
            else if (cbBoard.Text == "Select")
            {
                MessageBox.Show("Please Select Board.", "Board Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                cbBoard.Focus();
                return false;
            }
            else if (txtcolor.Text.Trim() == "" || string.IsNullOrEmpty(txtcolor.Text))
            {
                MessageBox.Show("Please Enter Color.", "Color Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtcolor.Focus();
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
            ClassID = UpID;
            ClassName = txtClassName.Text.Trim();
            ShortName = txtShortName.Text.Trim();
            Board = cbBoard.Text.Trim();
            Color = txtcolor.Text.Trim();
            BranchID = Convert.ToInt32(cbBranchName.SelectedValue);
            UpdatedByUserID = 1;
            UpdatedDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
            if (rdoActive.IsChecked == true && rdoDeActive.IsChecked == false)
            {
                IsActive = 1;
                IsDeleted = 0;
            }
            else if (rdoActive.IsChecked == false && rdoDeActive.IsChecked == true)
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
            UpID = 0;
           // cbBranchName.SelectedIndex = 0;
            txtClassName.Text = "";
            txtShortName.Text = "";            
            txtcolor.Text = "";
            txtSearchClass.Text = "";
            cbBoard.SelectedIndex = 0;
            rdoActive.IsChecked = true;
            rdoDeActive.IsChecked = false;
            btndelete.IsEnabled = false;
           // gbInfo.IsEnabled = false;
            btnGo.IsEnabled = true;
          //  cbBranchName.IsEnabled = true;
            btnadd.Content = "Save";
           // btnGo.Content = "Go";
           // GetBranchClassCount();
           // dgCopy.DataContext = null;
            dgvClass.ItemsSource = null;
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
                    DeleteClass();
                    //BindBranchName();
                    //cbBranchName.IsEnabled = true;
                    //btnGo.Content = "Go";
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion

        #region----------------------------DeleteClass()----------------------------------
        private void DeleteClass()
        {
            if (UpID != 0)
            {
                ClassID = UpID;
                BranchID = Convert.ToInt32(cbBranchName.SelectedValue);

                string Result = obj_AddClass.DeleteClass(ClassID, UpdatedByUserID, UpdatedDate);
                if (Result == "Deleted Sucessfully...!!")
                {
                    MessageBox.Show(Result, "Delete Sucessfully", MessageBoxButton.OK, MessageBoxImage.Information);
                    clearFields();
                    ClearData();
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
        private void BindGridview(int BranchId)
        {
            DataSet ds = obj_AddClass.BindClass(BranchId);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dgvClass.ItemsSource = ds.Tables[0].DefaultView;
            }
            dgvClass.Items.Refresh();
        }
        #endregion


        #region------------------------BindBranchName()---------------------------------------
        private void BindBranchName()
        {
            try
            {
                DataSet ds = obj_Branch.BindBranchName();


                if (ds.Tables[0].Rows.Count > 0)
                {
                    cbBranchName.DataContext = ds.Tables[0].DefaultView;
                    cbBranchName.DisplayMemberPath = ds.Tables[0].Columns["BranchName"].ToString();
                    cbBranchName.SelectedValuePath = ds.Tables[0].Columns["BranchID"].ToString();
                    cbBranchName.SelectedValue = "0";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            
        }
        #endregion

        #region--------------------------------------gridview cell click()-------------------------------------
        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                 object item =  dgCopy.SelectedItem;
                  string BranchName = Convert.ToString(((System.Data.DataRowView)(dgCopy.CurrentItem)).Row.ItemArray[0].ToString());
                 string ClassName = Convert.ToString(((System.Data.DataRowView)(dgCopy.CurrentItem)).Row.ItemArray[1].ToString());
                 string ShortName = Convert.ToString(((System.Data.DataRowView)(dgCopy.CurrentItem)).Row.ItemArray[2].ToString());
                 string Board = Convert.ToString(((System.Data.DataRowView)(dgCopy.CurrentItem)).Row.ItemArray[3].ToString());
                 string Color = Convert.ToString(((System.Data.DataRowView)(dgCopy.CurrentItem)).Row.ItemArray[4].ToString());
                 int BranchID = Convert.ToInt32(((System.Data.DataRowView)(dgCopy.CurrentItem)).Row.ItemArray[5].ToString());
                // string act = Convert.ToString(((System.Data.DataRowView)(dgCopy.CurrentItem)).Row.ItemArray[6].ToString());

                DataSet ds = obj_AddClass.GetClassDetail(ClassName, ShortName,Board,Color,BranchID);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        UpID = Convert.ToInt32(ds.Tables[0].Rows[0]["ClassID"]);
                        cbBranchName.Text = ds.Tables[0].Rows[0]["BranchName"].ToString();
                        txtClassName.Text = ds.Tables[0].Rows[0]["ClassName"].ToString();
                        txtShortName.Text = ds.Tables[0].Rows[0]["ClassShortName"].ToString();
                        cbBoard.Text = ds.Tables[0].Rows[0]["Board"].ToString();
                        txtcolor.Text = ds.Tables[0].Rows[0]["Color"].ToString();

                        int act = Convert.ToInt32(ds.Tables[0].Rows[0]["IsActive"]);
                        int del = Convert.ToInt32(ds.Tables[0].Rows[0]["IsDeleted"]);
                        if (act == 1 && del== 0)
                        {
                            rdoActive.IsChecked = true;
                        }
                        else if(act ==0 && del ==1)
                        {
                            rdoDeActive.IsChecked = true;
                        }
                        btndelete.IsEnabled = true;
                        btnadd.Content = "Update";
                        gbInfo.IsEnabled = true;
                     }
               }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString(),"Exception Error");
            }
        }
        #endregion

        #region-------------------------btnSearch_Click--------------------------
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtSearchClass.Text.Trim()))
                {
                    DataSet ds = obj_AddClass.SearchClass(txtSearchClass.Text);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dgCopy.DataContext = ds.Tables[0].DefaultView;
                    }
                    else
                    {
                        dgCopy.DataContext = null;
                        MessageBox.Show("No Data Available");
                        clearFields();
                    }

                }
                else
                {
                    MessageBox.Show("Please Enter Class Name", "Message", MessageBoxButton.OK, MessageBoxImage.Warning);
                    txtSearchClass.Focus();

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
           // clearFields();
            BindBranchName();
            cbBranchName.SelectedIndex = 0;
           // BindGridview();
            btndelete.IsEnabled = false;
            
        }

        #region-----------------------------------TextValidation()--------------------------------------------------
        private void txtcolor_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (txtcolor.Text != "")
                {
                    if (txtcolor.Text.Length > 0)
                    {
                        if (System.Text.RegularExpressions.Regex.IsMatch(txtcolor.Text, "^[a-zA-Z]+$"))
                        {
                        }
                        else
                        {
                            MessageBox.Show("Please Enter Only Alphabate", "Color", MessageBoxButton.OK, MessageBoxImage.Warning);
                            txtcolor.Text = "";
                            txtcolor.Focus();
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

        /* Created By:- pranjali Vidhate
        * Created Date :- 28 Nov 2015
        * Purpose:- Go Button Coding */

        #region-----------------------------------------Go()--------------------------------------------------------------------
        private void btnGo_Click(object sender, RoutedEventArgs e)
        {
         try
            {
                if (cbBranchName.SelectedValue.ToString() != "0" && cbBranchName.SelectedValue.ToString() != "Select")
                {
                    if (btnGo.Content.ToString() == "Go")
                    {
                        GetBranchClassCount();
                        GetCopyClass(Convert.ToInt32(cbBranchName.SelectedValue));
                        //MessageBoxResult Result = MessageBox.Show("Do You Want To Copy", "Copy", MessageBoxButton.YesNo, MessageBoxImage.Information);
                        //if (Result.Equals(MessageBoxResult.Yes))
                        //{
                        //    MessageBox.Show("Please Select Branch whoes Features You Want To Copy From Grid");
                        //    gbInfo.IsEnabled = false;
                        //}
                        //else if (Result.Equals(MessageBoxResult.No))
                        //{
                        //    MessageBox.Show("Please Fill All Details");
                        //    gbInfo.IsEnabled = true;
                        //    txtClassName.Focus();
                        //}
                        
                        btnGo.Content = "Change";
                        cbBranchName.IsEnabled = false;
                    }
                    else if (btnGo.Content.ToString() == "Change")
                    {
                        cbBranchName.IsEnabled = true;
                        clearFields();
                        BindBranchName();
                        btnGo.Content = "Go";
                        
                        
                        dgvClass.DataContext = null;
                        dgBranchCls.DataContext = null;
                        dgCopy.DataContext = null;
                        
                    }
                }
                else
                {
                    MessageBox.Show("Please Select Branch");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion


        /* Created By:- Pranjali Vidhate
        * Created Date :- 28 Nov 2015
        * Purpose:- GetBranchClass Count*/

        #region---------------------------------------GetBranchClassCount()-----------------------------------------------
        public void GetBranchClassCount()
        {
            DataSet ds = obj_AddClass.GetBranchClassCount();

            if (ds.Tables[0].Rows.Count > 0)
            {
                dgBranchCls.DataContext = null;
                dgBranchCls.DataContext = ds.Tables[0].DefaultView;
            }
            dgBranchCls.Items.Refresh();
          
        }
        #endregion

        /* Created By:- Pranjali Vidhate
        * Created Date :- 28 Nov 2015
        * Purpose:- griddview cell click of BranchClass */

        #region----------------------------------------ClickofBranchGrid()---------------------------------------------
        private void Row_DoubleClick1(object sender, MouseButtonEventArgs e)
        {
            try
            {
                object item = dgBranchCls.SelectedItem;
                TempID = Convert.ToInt32(((System.Data.DataRowView)(dgBranchCls.CurrentItem)).Row.ItemArray[2].ToString());
                if (btnGo.Content.ToString() == "Go")
                {
                    btnGo.IsEnabled = false;
                    cbBranchName.IsEnabled = false;
                }
                if(TempID == Convert.ToInt32(cbBranchName.SelectedValue))
                {
                    MessageBox.Show("This Branch & Select Branch is Same, Please Select Another", "Info", MessageBoxButton.OK, MessageBoxImage.Warning);
                    dgBranchCls.Focus();
                }
                else
                {
                    BindGridview(TempID);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion


        /* Created By:- pranjali Vidhate
        * Created Date :- 28 Nov 2015
        * Purpose:- Copy Button Coding */

        #region---------------------------------Copy()--------------------------------------------------------------
        private void btnCopy_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int temp = 0, cnt = 0;
                int count = Convert.ToInt32(dgvClass.Items.Count);
                if (cbBranchName.SelectedValue.ToString() != "0" && cbBranchName.SelectedValue.ToString() != "Select")
                {
                    if (dgvClass.Items.Count > 0)
                    {
                        for (int i = 0; i < dgvClass.Items.Count; i++)
                        {
                            cnt++;
                            System.Data.DataRowView SelectedFile = (System.Data.DataRowView)dgvClass.Items[i];
                            ClassID = 0;
                            ClassName = Convert.ToString(SelectedFile.Row.ItemArray[1]);
                            ShortName = Convert.ToString(SelectedFile.Row.ItemArray[2]);
                            Board = Convert.ToString(SelectedFile.Row.ItemArray[3]);
                            Color = Convert.ToString(SelectedFile.Row.ItemArray[4]);
                            UpdatedByUserID = 1;
                            UpdatedDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
                            BranchID = Convert.ToInt32(cbBranchName.SelectedValue);
                            IsActive = Convert.ToInt32(SelectedFile.Row.ItemArray[6]);
                            IsDeleted = 0;
                            string Result = obj_AddClass.saveAddClass(ClassID,ClassName, ShortName, Board, Color, BranchID, UpdatedByUserID, UpdatedDate, IsActive, IsDeleted);
                            if (Result == "Save Sucessfully...!!!" || Result == "Updated Sucessfully...!!!")
                            {
                                temp++;
                            }
                            else 
                            {  
                           
                            }
                        }
                        if (temp == cnt)
                        {
                            MessageBox.Show("Details Copy Sucessfully.", "Copy Sucessfull", MessageBoxButton.OK, MessageBoxImage.Information);
                            clearFields();
                            ClearData();
                          //  GetCopyClass(BranchID);
                        }
                        else
                        {
                            MessageBox.Show("Some Details Are Not Copied", "Error To Copy", MessageBoxButton.OK, MessageBoxImage.Warning);
                            clearFields();
                            ClearData();
                        }
                    }
                    else
                    {
                        MessageBox.Show("No Data To Copy", "Info", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Please Select Branch First", "Info", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        #endregion


        /* Created By:- pranjali Vidhate
        * Created Date :- 28 Nov 2015
        * Purpose:- Display content in CopyGrid when Click on Copy*/

        #region----------------------------------dgCopy()----------------------------------------------------
        private void GetCopyClass(int BranchID)
        {
            DataSet ds = obj_AddClass.BindClass(Convert.ToInt32(cbBranchName.SelectedValue));
            if (ds.Tables[0].Rows.Count > 0)
            {
                dgCopy.DataContext = null;
                dgCopy.DataContext = ds.Tables[0].DefaultView;
            }
            else
            {
                dgCopy.DataContext = null;
            }
            //dgCopy.Items.Refresh();
        }
        #endregion

        public void ClearData()
        {
            GetBranchClassCount();
            GetCopyClass(Convert.ToInt32(cbBranchName.SelectedValue));
        }

        
    }
}
