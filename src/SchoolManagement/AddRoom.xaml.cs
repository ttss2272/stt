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
    /// Interaction logic for Open.xaml
    /// </summary>
    public partial class Open : Window
    {
        public Open()
        {
            InitializeComponent();
        }

        #region---------------------------Validate()-----------------------------------------
        public bool Validate()
        {

            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Please Enter Room Name..");
                txtName.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtShortName.Text))
            {
                MessageBox.Show("Please Enter Short Name..");
                txtShortName.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtColor.Text))
            {
                MessageBox.Show("Please Enter Color Detail..");
                txtColor.Focus();
                return false;
            }
            else if (cbCapacity.SelectedIndex == 0)
            {
                MessageBox.Show("Pleas Select Room Capacity...");
                cbCapacity.Focus();
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
