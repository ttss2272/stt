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
