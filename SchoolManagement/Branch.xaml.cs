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

namespace SchoolManagement.Master
{
    /// <summary>
    /// Interaction logic for Branch.xaml
    /// </summary>
    public partial class Branch : Window
    {
        public Branch()
        {
            InitializeComponent();
        }



        #region---------------------------Validate()-----------------------------------------
        public bool Validate()
        {
           
             if (cbBranchCode.SelectedIndex == 0)
            {
                MessageBox.Show("Pleas Select Branch Code...");
                cbBranchCode.Focus();
                return false;
            }
            else if (cbBranchName.SelectedIndex == 0)
            {
                MessageBox.Show("Pleas Select Branch Name...");
                cbBranchName.Focus();
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
