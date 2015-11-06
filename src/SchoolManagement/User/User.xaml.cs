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

namespace SchoolManagement.User
{
    /// <summary>
    /// Interaction logic for User.xaml
    /// </summary>
    public partial class User : Window
    {
        public User()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
            this.Width = System.Windows.SystemParameters.PrimaryScreenWidth;
            this.Height = System.Windows.SystemParameters.PrimaryScreenHeight;
        }

        BLUser obj_User = new BLUser();

        int UserID, IsActive, IsDeleted, UserTypeID = 1, UpID;
        string UserName, ContactNo, Address, MailId, LoginName, Password, UpdatedDate;

        #region---------------------------Validate()-----------------------------------------
        public bool Validate()
        {

            if (string.IsNullOrEmpty(txtFullName.Text))
            {
                MessageBox.Show("Please Enter Full Name..");
                txtFullName.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtAddress.Text))
            {
                MessageBox.Show("Please Enter Address..");
                txtAddress.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtEmailID.Text))
            {
                MessageBox.Show("Please Enter EmailID..");
                txtEmailID.Focus();
                return false;
            }
            else if (txtEmailID.Text != "")
            {
                //         string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                //@"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                //   @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                //         Regex re = new Regex(strRegex);
                //         if (re.IsMatch(txtEmailID.Text))
                //             return (true);
                //         else
                //             MessageBox.Show("Please Enter Poper Email ID");
                //         txtEmailID.Focus();
                //         return (false);
            }
            else if (string.IsNullOrEmpty(txtContactNo.Text))
            {
                MessageBox.Show("Please Enter contact Number..");
                txtContactNo.Focus();
                return false;
            }
            else if (txtContactNo.Text.Length > 10)
            {
                MessageBox.Show("Invalid Contact Number..");
                txtLoginID.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtLoginID.Text))
            {
                MessageBox.Show("Please Enter LoginID..");
                txtLoginID.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Please Enter Password..");
                txtPassword.Focus();
                return false;
            }

            else
            {
                return true;
            }
        }
        #endregion

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SetParameters();
                SaveUpdateUser();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception Error");
            }
        }

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

        private void SetParameters()
        {
            UserID = UpID;
            UserName = txtFullName.Text.Trim();
            ContactNo = txtContactNo.Text.Trim();
            Address = txtAddress.Text.Trim();
            MailId = txtEmailID.Text.Trim();
            LoginName = txtLoginID.Text.Trim();
            Password = txtPassword.Text.Trim();
            UserTypeID = 1;
            UpdatedDate = DateTime.Now.ToString();
            if (cmbActive.IsChecked == true)
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

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult Result = MessageBox.Show("Do You Really Want To Delete?", "Delete User", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (Result.Equals(MessageBoxResult.Yes))
                {
                    SetParameters();
                    DeleteUser();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception Error");
            }
        }

        private void DeleteUser()
        {
            if (UpID != 0)
            {
                UserID = UpID;
                UpdatedDate = DateTime.Now.ToString();
                string Result = obj_User.DeleteUser(UserID, UpdatedDate);
                if (Result == "Deleted Sucessfully.")
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
                MessageBox.Show("Please Select Subject From Subject", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception Error");
            }
        }

        private void ClearFields()
        {
            txtFullName.Text = "";
            txtAddress.Text = "";
            txtContactNo.Text = "";
            txtEmailID.Text = "";
            txtLoginID.Text = "";
            txtPassword.Text = "";
            cmbActive.IsChecked = true;
            bindUserGrid();
            UpID = 0;
            btnDelete.IsEnabled = false;
            txtSearchUser.Text = "";
            btnSave.Content = "Save";
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bindUserGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception Error");
            }
        }

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
                MessageBox.Show("Data Not Found", "Message");
                txtSearchUser.Text = "";
            }
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                object item = gvUser.SelectedItem;
                UpID = Convert.ToInt32(((System.Data.DataRowView)(gvUser.CurrentItem)).Row.ItemArray[0].ToString());
                txtFullName.Text = ((System.Data.DataRowView)(gvUser.CurrentItem)).Row.ItemArray[1].ToString();
                txtAddress.Text = ((System.Data.DataRowView)(gvUser.CurrentItem)).Row.ItemArray[2].ToString();
                txtContactNo.Text = ((System.Data.DataRowView)(gvUser.CurrentItem)).Row.ItemArray[3].ToString();
                txtEmailID.Text = ((System.Data.DataRowView)(gvUser.CurrentItem)).Row.ItemArray[4].ToString();
                txtLoginID.Text = ((System.Data.DataRowView)(gvUser.CurrentItem)).Row.ItemArray[5].ToString();
                txtPassword.Text = ((System.Data.DataRowView)(gvUser.CurrentItem)).Row.ItemArray[6].ToString();
                bool act = Convert.ToBoolean(((System.Data.DataRowView)(gvUser.CurrentItem)).Row.ItemArray[10].ToString());
                bool del = Convert.ToBoolean(((System.Data.DataRowView)(gvUser.CurrentItem)).Row.ItemArray[11].ToString());

                if (act == true && del == false)
                {
                    cmbActive.IsChecked = true;
                }
                else if (act == false && del == true)
                {
                    cmbActive.IsChecked = false;
                }
                btnDelete.IsEnabled = true;
                btnSave.Content = "Update";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception Error");
            }
        }
    }
}
