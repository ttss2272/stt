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
    /// Interaction logic for Class.xaml
    /// </summary>
    public partial class Class : Window
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        BLAddClass obj_AddClass = new BLAddClass();
        public Class()
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
                        string ClassName = txtClassName.Text;
                        string ShortName = txtShortName.Text;
                        int Board = Convert.ToInt32(cbBoard.SelectedValue.ToString());
                        string Color = txtcolor.Text;
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
                        string result = obj_AddClass.saveAddClass(id, ClassName, ShortName, Board, Color);
                        if (result == "1")
                        {
                            MessageBox.Show("Class Details Added Successfully...");
                            //Usp_BindDoctorGrid();
                            clearFields();
                        }
                        else
                        {
                            MessageBox.Show("This Class Details Already Exist...");
                            clearFields();
                        }

                    }
                    else
                    {
                        int id = 0;
                        //int Id = Convert.ToInt32(lblid.Text);
                        string ClassName = txtClassName.Text;
                        string ShortName = txtShortName.Text;
                        int Board = Convert.ToInt32(cbBoard.SelectedValue.ToString());
                        string Color = txtcolor.Text;
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
                        string result = obj_AddClass.saveAddClass(id, ClassName, ShortName, Board, Color);
                        if (result == "1")
                        {
                            MessageBox.Show("Class Details Updated successfully...");
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

        #region-----------------------------clearFields()------------------------------------------
        private void clearFields()
        {
            txtClassName.Text = "";
            txtShortName.Text = "";
            cbBoard.Text = "";
            txtcolor.Text = "";
        }
        #endregion
    }
}
