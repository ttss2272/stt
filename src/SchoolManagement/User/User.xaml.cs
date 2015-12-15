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
using System.Text.RegularExpressions;

namespace SchoolManagement.User
{
    /// <summary>
    /// Interaction logic for User.xaml
    /// </summary>
    public partial class User : Window
    {
        /*
         * Created by:- 
         * Created Date:-
         * Purpose
         */
        #region------------------------------------------------main()----------------------------------------------------------
        public User()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
            this.Width = System.Windows.SystemParameters.PrimaryScreenWidth;
            this.Height = System.Windows.SystemParameters.PrimaryScreenHeight;
            ClearFields();
        }
        #endregion
        
        /*
         * Created by:- 
         * Created Date:-
         * Purpose
         */
        #region----------------------------------------------Variables Declaration---------------------------------------------
        BLUser obj_User = new BLUser();

        int UserID, IsActive, IsDeleted, UserTypeID = 0, UpID;
        string UserName, ContactNo, Address, MailId, LoginName, Password, UpdatedDate;
        #endregion
        /*
         * Created by:- 
         * Created Date:-
         * Purpose
         */
        #region---------------------------Validate()-----------------------------------------
        public bool Validate()
        {
            
            if (string.IsNullOrEmpty(txtFullName.Text) || string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Please Enter Full Name..");
                txtFullName.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtAddress.Text) || string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Please Enter Address..");
                txtAddress.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtEmailID.Text)|| string.IsNullOrWhiteSpace(txtEmailID.Text))
            {
                MessageBox.Show("Please Enter EmailID..");
                txtEmailID.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtContactNo.Text) || string.IsNullOrWhiteSpace(txtContactNo.Text))
            {
                MessageBox.Show("Please Enter contact Number..");
                txtContactNo.Focus();
                return false;
            }
            else if (txtContactNo.Text.Length != 0 && txtContactNo.Text.Length < 10)
            {
                MessageBox.Show("Contact Number Must Be 10 Digits..");
                txtContactNo.Focus();
                return false;
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(txtContactNo.Text, "[^0-9]"))
            {
                MessageBox.Show("Please Enter Only Number in Contact No.");
                txtContactNo.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtLoginID.Text) || string.IsNullOrWhiteSpace(txtLoginID.Text))
            {
                MessageBox.Show("Please Enter LoginID..");
                txtLoginID.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtPassword.Password)|| string.IsNullOrWhiteSpace(txtLoginID.Text))
            {
                MessageBox.Show("Please Enter Password..");
                txtPassword.Focus();
                return false;
            }
            
            else if (cmbUserType.SelectedValue.ToString()=="0"|| cmbUserType.SelectedItem.ToString()==""|| cmbUserType.SelectedItem.ToString()=="Select")
            {
                MessageBox.Show("Please Select User Type", "User Type", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            else if (txtEmailID.Text != "")
            {
                string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                Regex re = new Regex(strRegex);
                if (re.IsMatch(txtEmailID.Text))
                    return (true);
                else
                {
                    MessageBox.Show("Please Enter Poper Email ID");
                    txtEmailID.Focus();
                    return (false);
                }
            }
            else
            {
                return true;
            }
        }
        #endregion

        /*
         * Created by:- 
         * Created Date:-
         * Purpose
         */
        #region------------------------------------------------btnSave_Click----------------------------------------------------
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
                try
                {
                    if (Validate())
                    {
                       SetParameters();
                       SaveUpdateUser();
                       ClearFields();
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            
        }
        #endregion

        /*
         * Created by:- 
         * Created Date:-
         * Purpose
         */
        #region--------------------------------------------------SaveUpdateUser()-----------------------------------------------
        private void SaveUpdateUser()
        {
            string Result = obj_User.SaveUser(UserID, UserName, ContactNo, Address, MailId, LoginName, Password, UpdatedDate, UserTypeID, IsActive, IsDeleted);

            if (Result == "Save Sucessfully...!!!" || Result == "Updated Sucessfully...!!!")
            {
                MessageBox.Show(Result, "Save SucessFull", MessageBoxButton.OK, MessageBoxImage.Information);
                //ClearFields();
            }
            else
            {
                MessageBox.Show(Result, "Error To Save", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion

        /*
         * Created by:- 
         * Created Date:-
         * Purpose
         */
        #region---------------------------------------------------SetParameters()-----------------------------------------------
        private void SetParameters()
        {
            UserID = UpID;
            UserName = txtFullName.Text.Trim();
            ContactNo = txtContactNo.Text.Trim();
            Address = txtAddress.Text.Trim();
            MailId = txtEmailID.Text.Trim();
            LoginName = txtLoginID.Text.Trim();
            Password = txtPassword.Password.Trim();
            UserTypeID = Convert.ToInt32(cmbUserType.SelectedValue.ToString());
            UpdatedDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
            if (cmbActive.IsChecked == true)
            {
                IsActive = 1;
                IsDeleted = 0;
            }
            else if(cmbDelete.IsChecked == true)
            {
                IsActive = 0;
                IsDeleted = 0;
            }
        }
        #endregion

        /*
         * Created by:- 
         * Created Date:-
         * Purpose
         */
        #region---------------------------------------------------BindUserType()-------------------------------------------------
        private void BindUserType()
        {
            try
            {
                DataSet ds = obj_User.GetUserType(0);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    cmbUserType.DataContext = ds.Tables[0].DefaultView;
                    cmbUserType.DisplayMemberPath = ds.Tables[0].Columns["UserTypeName"].ToString();
                    cmbUserType.SelectedValuePath = ds.Tables[0].Columns["UserTypeID"].ToString();
                    cmbUserType.SelectedValue = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion

        /*
         * Created by:- 
         * Created Date:-
         * Purpose
         */
        #region---------------------------------------------------btnDelete_Click------------------------------------------------
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Validate())
                {
                    MessageBoxResult Result = MessageBox.Show("Do You Really Want To Delete?", "Delete User", MessageBoxButton.YesNo, MessageBoxImage.Information);
                    if (Result.Equals(MessageBoxResult.Yes))
                    {
                        SetParameters();
                        DeleteUser();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ,"Exception",MessageBoxButton.OK,MessageBoxImage.Warning);
            }
        }
        #endregion

        /*
         * Created by:- 
         * Created Date:-
         * Purpose
         */
        #region--------------------------------------------------DeleteUser()----------------------------------------------------
        private void DeleteUser()
        {
            if (UpID != 0)
            {
                UserID = UpID;
                UpdatedDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
                string Result = obj_User.DeleteUser(UserID, UpdatedDate);
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
                MessageBox.Show("Please Select User", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
        }
        #endregion

        /*
         * Created by:- 
         * Created Date:-
         * Purpose
         */
        #region-------------------------------------------------btnClear_Click()-------------------------------------------------
        private void btnClear_Click(object sender, RoutedEventArgs e)
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
         * Created by:- 
         * Created Date:-
         * Purpose
         */
        #region-------------------------------------------------ClearFields()----------------------------------------------------
        private void ClearFields()
        {
            UpID = 0;
            txtFullName.Text = "";
            txtAddress.Text = "";
            txtContactNo.Text = "";
            txtEmailID.Text = "";
            txtLoginID.Text = "";
            txtPassword.Password = "";
            txtSearchUser.Text = "";
            cmbActive.IsChecked = true;
            bindUserGrid();
            btnDelete.IsEnabled = false;
            btnSave.Content = "Save";
            BindUserType();
        }
        #endregion

        /*
         * Created by:- 
         * Created Date:-
         * Purpose
         */
        #region---------------------------------------------------btnSearch_Click------------------------------------------------
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bindUserGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion

        /*
         * Created by:- 
         * Created Date:-
         * Purpose
         */
        #region---------------------------------------------------BindUserGrid()-------------------------------------------------
        private void bindUserGrid()
        {
            DataSet ds = obj_User.GetUser(0, txtSearchUser.Text);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvUser.ItemsSource = ds.Tables[0].DefaultView;
            }
            else
            {
                gvUser.ItemsSource = null;
                //MessageBox.Show("Data Not Found", "Message");
                //ClearFields();
            }
        }
        #endregion

        /*
         * Created by:- 
         * Created Date:-
         * Purpose
         */
        #region------------------------------------------------RowDouble_Click---------------------------------------------------
        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                object item = gvUser.SelectedItem;
                UpID = Convert.ToInt32(((System.Data.DataRowView)(gvUser.CurrentItem)).Row.ItemArray[0].ToString());
                txtFullName.Text = ((System.Data.DataRowView)(gvUser.CurrentItem)).Row.ItemArray[1].ToString();
                txtAddress.Text = ((System.Data.DataRowView)(gvUser.CurrentItem)).Row.ItemArray[3].ToString();
                txtContactNo.Text = ((System.Data.DataRowView)(gvUser.CurrentItem)).Row.ItemArray[2].ToString();
                txtEmailID.Text = ((System.Data.DataRowView)(gvUser.CurrentItem)).Row.ItemArray[4].ToString();
                txtLoginID.Text = ((System.Data.DataRowView)(gvUser.CurrentItem)).Row.ItemArray[5].ToString();
                txtPassword.Password = ((System.Data.DataRowView)(gvUser.CurrentItem)).Row.ItemArray[6].ToString();
                cmbUserType.SelectedValue = ((System.Data.DataRowView)(gvUser.CurrentItem)).Row.ItemArray[9].ToString();
                bool act = Convert.ToBoolean(((System.Data.DataRowView)(gvUser.CurrentItem)).Row.ItemArray[11].ToString());
                bool del = Convert.ToBoolean(((System.Data.DataRowView)(gvUser.CurrentItem)).Row.ItemArray[12].ToString());

                if (act == true && del == false)
                {
                    cmbActive.IsChecked = true;
                }
                else if (act == false && del == false)
                {
                    cmbDelete.IsChecked = true; 
                }
                btnDelete.IsEnabled = true;
                btnSave.Content = "Update";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion
        /* Created By:- Pranjali Vidhate
    * Created Date :- 20 Nov 2015
    * Purpose:- Vaidation for text check */

        #region---------------------------ValidationforName-----------------------------------------
        private void txtFullName_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (txtFullName.Text != "")
                {
                    if (txtFullName.Text.Length > 0)
                    {
                        if(System.Text.RegularExpressions.Regex.IsMatch(txtFullName.Text,"^[a-zA-Z ]+$"))
                        {

                        }
                        else
                        {
                            MessageBox.Show("Please Enter Only Alphabets", "Full Name", MessageBoxButton.OK, MessageBoxImage.Information);
                            txtFullName.Text="";
                            txtFullName.Focus();
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(),"Exception",MessageBoxButton.OK,MessageBoxImage.Warning);
            }
        }

        private void txtContactNo_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (txtContactNo.Text != "")
                {
                    if (txtContactNo.Text.Length > 0)
                    {
                        if(System.Text.RegularExpressions.Regex.IsMatch(txtContactNo.Text,"[0-9]+$"))
                        {
                        
                        }
                        else
                        {
                            MessageBox.Show("Please Enter Only Numbers","Contact Number",MessageBoxButton.OK,MessageBoxImage.Information);
                            txtContactNo.Text="";
                            txtContactNo.Focus();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        #endregion

       
    }
}
