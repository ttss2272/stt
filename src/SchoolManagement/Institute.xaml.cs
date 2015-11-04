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
    /// Interaction logic for Institute.xaml
    /// </summary>
    public partial class Institute : Window
    {
        public Institute()
        {
            InitializeComponent();
        }


        #region---------------------------Validate()-----------------------------------------
        public bool Validate()
        {
            if (string.IsNullOrEmpty(txtInstituteName.Text))
            {
                MessageBox.Show("Pleas Enter Institute Name...");
                txtInstituteName.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtTimeTableforCreatedMonth.Text))
            {
                MessageBox.Show("Pleas Enter Time of the month...");
                txtTimeTableforCreatedMonth.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region-----------------------------clearFields()------------------------------------------
        private void clearFields()
        {
            txtInstituteName.Text = "";
            txtTimeTableforCreatedMonth.Text = "";

        }
        #endregion
    }
}
