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

namespace SchoolManagement.Branch
{
    /// <summary>
    /// Interaction logic for Batch.xaml
    /// </summary>
    public partial class Batch : Window
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        BLBatch obj_Batch = new BLBatch();
        public Batch()
        {
            InitializeComponent();
        }

        #region----------------------------------------btnAdd_Click-------------------------------------------
        private void btnadd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Validate())
                {
                    if (btnadd.Content == "Add")
                    {
                        int id = 0;
                        int ClassID = Convert.ToInt32(cbClassName.SelectedValue.ToString());
                        string BatchName = txtBatchName.Text;
                        string BatchCode = txtBatchCode.Text;
                        //string IsActive;
                        //string IsDelete;                       
                        //if (cbActive.Checked == true)
                        //{
                        //    IsActive = "Yes";
                        //    IsDelete = "No";
                        //}
                        //else
                        //{
                        //    IsActive = "No";
                        //    IsDelete = "Yes";
                        //}
                        string result = obj_Batch.saveBatch(id, ClassID, BatchName, BatchCode);
                        if (result == "1")
                        {
                            MessageBox.Show("Batch Details Added Successfully...");
                            //Usp_BindDoctorGrid();
                            clearFields();
                        }
                        else
                        {
                            MessageBox.Show("This Batch Details Already Exist...");
                            clearFields();
                        }

                    }
                
                    else
                    {
                        int id = 0;
                        //int Id = Convert.ToInt32(lblid.Text);
                        int ClassID = Convert.ToInt32(cbClassName.SelectedValue.ToString());
                        string BatchName = txtBatchName.Text;
                        string BatchCode = txtBatchCode.Text;
                        //string IsActive;
                        //string IsDelete;                       
                        //if (cbActive.Checked == true)
                        //{
                        //    IsActive = "Yes";
                        //    IsDelete = "No";
                        //}
                        //else
                        //{
                        //    IsActive = "No";
                        //    IsDelete = "Yes";
                        //}
                        string result = obj_Batch.saveBatch(id, ClassID, BatchName, BatchCode);
                        if (result == "1")
                        {
                            MessageBox.Show("Batch Details Updated successfully...");
                            //Usp_BindDoctorGrid();
                            clearFields();
                            //lblid.Text = "";
                        }
                        //lbProductList.Enabled = true;
                        btnadd.Content = "Add";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion

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

        #region---------------------------Validate()-----------------------------------------
        public bool Validate()
        {

            if (string.IsNullOrEmpty(txtBatchName.Text))
            {
                MessageBox.Show("Please Enter Class Name..");
                txtBatchName.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtBatchCode.Text))
            {
                MessageBox.Show("Please Enter Short Name..");
                txtBatchCode.Focus();
                return false;
            }
           
            else if (cbClassName.SelectedIndex == 0)
            {
                MessageBox.Show("Pleas Select Board...");
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

    }
}

