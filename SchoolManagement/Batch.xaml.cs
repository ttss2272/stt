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
    /// Interaction logic for Batch.xaml
    /// </summary>
    public partial class Batch : Window
    {
        public Batch()
        {
            InitializeComponent();
        }

        #region---------------------------Validate()-----------------------------------------
        public bool Validate()
        {
            if (string.IsNullOrEmpty(txtBatchName.Text))
            {
                MessageBox.Show("Pleas Enter Batch Name...");
                txtBatchName.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtBatchCode.Text))
            {
                MessageBox.Show("Pleas Enter Batch Code...");
                txtBatchCode.Focus();
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
            txtBatchName.Text = "";
            txtBatchCode.Text = "";                  
           
        }
        #endregion

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
