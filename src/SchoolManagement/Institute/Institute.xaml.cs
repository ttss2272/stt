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
using System.Data;
using System.Data.SqlClient;
using SchoolManagement.Institute;

namespace SchoolManagement.Institute
{
    /// <summary>
    /// Interaction logic for Institute.xaml
    /// </summary>
    public partial class Institute : Window
    {
        
        string ConnectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
       
        
        public Institute()
        {
            InitializeComponent();
        }
       
        #region-----Declare Variables-------------
        string InstituteName, LogoPath;
        #endregion
       
        /*
         * Created By Sameer Shinde
         * Date:04/11/2015
         * Purpose:Save Institute details 
         */
        #region------------BtnSave_Click----------------------------
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                InitializeData();
                if(btnSave.Content=="Save")
                {

                }
            }
            catch (Exception ex) 
            {

                MessageBox.Show(ex.Message.ToString());
            }
          
        }
        #region-------------InitializeData------------------
        private void InitializeData()
        {
         InstituteName= txtInstituteName.Text;
         LogoPath = txtUploadPath.Text;
        }
        #endregion
       
        #endregion
    }
}
