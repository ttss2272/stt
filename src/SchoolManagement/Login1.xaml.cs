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
        public Login1()
        {
            InitializeComponent();
        }
        BLLogin obj_Login = new BLLogin();
        Home objHome = new Home();
        string Username, Password, Expirydate;

        /*
         * Name:-Sameer A. Shinde
         * Date:-03/12/2015
         * Purpose:-Login Button check user id and Password
         */
        #region----------------------------------btnLogin_Click()-----------------------------------------------
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Username = txtUserName.Text;
            Password = txtPassword.ToString();
            DateTime currentdate = DateTime.Now;
            DataSet ds = obj_Login.GetLoginDetails();
            if (ds.Tables[0].Rows.Count > 0)
            {
                Username = ds.Tables[0].Rows[0]["LoginUserName"].ToString();
                Password = ds.Tables[0].Rows[0]["Password"].ToString();
                Expirydate = ds.Tables[0].Rows[0]["ExpiryDate"].ToString();
            }
            DateTime expirydate = Convert.ToDateTime(Expirydate);
            if (currentdate == expirydate)
            {
                MessageBox.Show("Your Application Is Going to Expire Today..!!! Please Contact your Support");
                objHome.Show();
            }
            else if (currentdate > expirydate)
            {
                MessageBox.Show("Sorry...Your Application Is Expired....!!! Please Contact your Support");
                objHome.Close();
            }
            else
            {
                MessageBox.Show("Welcome.......!!!!");
                Home objHome = new Home();
                Login1 loginForm = new Login1();
                loginForm.Close();
                objHome.Show();


            }
           
        }
        #endregion

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
