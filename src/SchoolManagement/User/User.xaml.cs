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
        
        int UserID, IsActive, IsDeleted, UserTypeID=1;
        string UserName, ContactNo, Address, MailId, LoginName, Password, UpdatedDate ;

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
            else if(txtEmailID.Text != "")
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
            SetParameters();
            SaveUpdateUser();
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
            UserID = 0;
            UserName = txtFullName.Text.Trim();
            ContactNo = txtContactNo.Text.Trim();
            Address = txtAddress.Text.Trim();
            MailId =txtEmailID.Text.Trim();
            LoginName =txtLoginID.Text.Trim();
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

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void gvUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
