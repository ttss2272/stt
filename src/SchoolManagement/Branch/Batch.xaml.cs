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
using System.Data.SqlClient;
using System.Data;

namespace SchoolManagement.Branch
{
    /// <summary>
    /// Interaction logic for Batch.xaml
    /// </summary>
    public partial class Batch : Window
    {

        /*
     * Created By:- Pravin
     * Ctreated Date :- 4 Nov 2015
     * StartTime:-3:20PM
     * EndTime:-
     * Purpose:- Declare Global Variables
     */
        #region------------------------Declare Variables Globally()--------------------
        int BatchID, UpdatedByUserID, IsActive, ClassID;
        string BatchName, BatchCode, UpdatedDate;
        BLBatch obj_Batch = new BLBatch();
        #endregion
       
        public Batch()
        {
            InitializeComponent();
            clearFields();
        }

        /*
     * Created By:- Pravin
     * Ctreated Date :- 5 Nov 2015
     * StartTime:-3:32PM
     * EndTime:-3:34PM
     * Purpose Save button code
     */
        #region----------------------------------------btnAdd_Click-------------------------------------------
        private void btnadd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Validate();
                SetParameters();
                SaveDetails();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion

        /*
         * Created By:- Pravin
         * Ctreated Date :- 4 Nov 2015
         * StartTime:-PM
         * EndTime:-PM
         * Purpose:- SaveDetails
         */
        #region--------------------------------------SaveDetails()-------------------------------------
        private void SaveDetails()
        {            
            string result = obj_Batch.saveBatch(BatchID,ClassID, BatchName, BatchCode,UpdatedByUserID, UpdatedDate, IsActive);
            if (result == "Save Sucessfully...!!!" && result == "Updated Sucessfully...!!!")
            {
                MessageBox.Show(result, "Save SucessFull", MessageBoxButton.OK, MessageBoxImage.Information);
                clearFields();
            }
            else
            {
                MessageBox.Show(result, "Error To Save", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion                                         

        /*
         * Created By:- Pravin
         * Ctreated Date :- 4 Nov 2015
         * StartTime:-PM
         * EndTime:-PM
         * Purpose:- Close button code
         */
        #region--------------------------btncancel_Click-----------------------------
        private void btncancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion

        #region-------------------------------------------------SetParameters()-------------------------------------
        private void SetParameters()
        {
            BatchName = txtBatchName.Text.Trim();
            BatchCode = txtBatchCode.Text.Trim();
            ClassID = Convert.ToInt32(cbClassName.SelectedValue.ToString());
            UpdatedByUserID = 1;
            UpdatedDate = DateTime.Now.ToString();
            IsActive = 1;
        }
        #endregion

        /*
         * Created By:- Pravin
         * Ctreated Date :- 4 Nov 2015
         * StartTime:-4:00PM
         * EndTime:-4:32 PM
         * Purpose:- validations
         */
        #region---------------------------Validate()-----------------------------------------
        public bool Validate()
        {

            if (txtBatchName.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Batch Name.", "Batch Name Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtBatchName.Focus();
                return false;
            }
            else if (txtBatchCode.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Batch Code.", "Batch Code Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtBatchCode.Focus();
                return false;
            }           
            else if (cbClassName.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Class Name.", "Class Name Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                cbClassName.Focus();
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
            cbClassName.Text = "";
           
        }
        #endregion

        #region----------------------txtBatchName_TextChanged----------------------------
        private void txtBatchName_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (txtBatchName.Text != "")
                {
                    if (txtBatchName.Text.Length > 0 && txtBatchName.Text.Length == 1)
                    {
                        if (System.Text.RegularExpressions.Regex.IsMatch(txtBatchName.Text, "^[a-zA-Z]"))
                        {
                        }
                        else
                        {
                            MessageBox.Show("Please Enter First Characerter Alphabate", "Batch Name", MessageBoxButton.OK, MessageBoxImage.Warning);
                            txtBatchName.Text = "";
                            txtBatchName.Focus();
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion

        #region----------------------------------grvBatchBind------------------------------
        private void BindGridview()
        {
            DataSet ds = obj_Batch.BindBatch(0);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dgvBatch.ItemsSource = ds.Tables[0].DefaultView;
                dgvBatch.Columns[0].Visibility = Visibility.Collapsed;
            }
        }
        #endregion

    }
}

