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
using BusinessLayer;

namespace SchoolManagement
{
    /// <summary>
    /// Interaction logic for Login1.xaml
    /// </summary>
    public partial class Login1 : Window
    {
        /*
         * Created By:- 
         * Created Date:-
         * Purpose:- Declare Variables Globally
         */
        #region----------------------------------------------Variables------------------------------
        BLLogin obj_Login = new BLLogin();
        Home objHome = new Home();
        string Username, Password, Expirydate;
        #endregion

        /*
         * Created By:-
         * Created Date:-
         * Purpose:-
         * 
         */
        #region----------------------------------------main()-----------------------------------------
        public Login1()
        {
            try
            {
                InitializeComponent();
                txtUserName.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion
        

        /*
         * Name:-Sameer A. Shinde
         * Date:-03/12/2015
         * Purpose:-Login Button check user id and Password
         * Updated By : PriTesh D. Sortee
         * Updated Date : 07 Dec 2015
         * Purpose : Get Login Data properly
         */
        #region----------------------------------btnLogin_Click()-----------------------------------------------
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtUserName.Text != "")
                {
                    if (txtPassword.Password != "")
                    {
                        Username = txtUserName.Text;
                        Password = txtPassword.Password;
                        string CurrentDate = DateTime.Now.ToString("yyyy-MM-dd");
                        DataSet ds = obj_Login.GetLoginDetails(Username, Password, CurrentDate);
                        txtUserName.Text = "";
                        txtPassword.Password = "";
                        if (ds.Tables[0].Rows.Count > 0)
                        {

                            if ("Welcome" == ds.Tables[0].Rows[0][0].ToString())
                            {
                                if (Convert.ToInt32(ds.Tables[0].Rows[0][1]) >= 0)
                                {

                                    if (Convert.ToInt32(ds.Tables[0].Rows[0][1]) == 0)
                                    {

                                        MessageBox.Show("Your Application is Going to Expired Today", "Expired Info", MessageBoxButton.OK, MessageBoxImage.Information);
                                    }
                                    else if (Convert.ToInt32(ds.Tables[0].Rows[0][1]) <= 7)
                                    {
                                        MessageBox.Show("Your Application is Going to Expired In " + ds.Tables[0].Rows[0][1].ToString() + " Days", "Expired Info", MessageBoxButton.OK, MessageBoxImage.Information);
                                    }
                                    objHome.Show();
                                    this.Close();

                                }
                                else
                                {
                                    MessageBox.Show("Your Application is Expired", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Warning);
                                    Application.Current.Shutdown();

                                }

                            }
                            else
                            {
                                MessageBox.Show(ds.Tables[0].Rows[0][0].ToString(), "Login Faild", MessageBoxButton.OK, MessageBoxImage.Warning);
                                txtUserName.Focus();

                            }
                        }
                        else
                        {
                            MessageBox.Show("Login Name Or Password Is Wrong", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Warning);
                            txtUserName.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Enter Password", "Password", MessageBoxButton.OK, MessageBoxImage.Warning);
                        txtPassword.Focus();
                    }
               }
                
                else
                {
                    MessageBox.Show("Please Enter User Name", "User Name", MessageBoxButton.OK, MessageBoxImage.Warning);
                    txtUserName.Focus();

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(),"Exception",MessageBoxButton.OK,MessageBoxImage.Warning);
            }
            
            
           
        }
        #endregion

        /*
         * Updated By: PriTesh D. Sortee
         * Updated Date :07 Dec 2015
         * Updated Purpose: Add Try catch Block
         */
        #region----------------------------------btnCancel_Click----------------------------------------------
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Application.Current.Shutdown();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
        }
        #endregion
    }
}
