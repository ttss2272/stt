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

namespace SchoolManagement
{
    /// <summary>
    /// Interaction logic for Manage.xaml
    /// </summary>
    public partial class Manage : Window
    {
        public Manage()
        {
            InitializeComponent();
        }


        #region---------------------------Validate()-----------------------------------------
        public bool Validate()
        {

            if (string.IsNullOrEmpty(txtClassName.Text))
            {
                MessageBox.Show("Please Enter Class Name..");
                txtClassName.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtShortName.Text))
            {
                MessageBox.Show("Please Enter Short Name..");
                txtShortName.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtcolor.Text))
            {
                MessageBox.Show("Please Enter Color Detail..");
                txtcolor.Focus();
                return false;
            }
            else if (cbBoard.SelectedIndex == 0)
            {
                MessageBox.Show("Pleas Select Board...");
                cbBoard.Focus();
                return false;
            }

            else
            {
                return true;
            }
        }
        #endregion
    }
}
