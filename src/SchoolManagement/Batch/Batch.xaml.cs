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

namespace SchoolManagement.Batch
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
        int BatchID, UpdatedByUserID, IsActive, IsDeleted, ClassID, UpID, LectureDuration, IsLunchBreak, MaxNoLecturesDay, MaxNoLecturesWeek, IsAllowMoreThanOneLectInBatch, MaxNoOfLecureInRow;
        string BatchName, BatchCode, UpdatedDate, LunchBreakStartTime, LunchBreakEndTime;
        BLBatch obj_Batch = new BLBatch();
        BLAddClass obj_Class = new BLAddClass();
        #endregion
       
        public Batch()
        {
            InitializeComponent();
            clearFields();
            BindClassName();
            BindGridview();
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
                BindGridview();

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
            string result = obj_Batch.saveBatch(BatchID, ClassID, BatchName, BatchCode, LectureDuration, IsLunchBreak, LunchBreakStartTime, LunchBreakEndTime, MaxNoLecturesDay, MaxNoLecturesWeek, IsAllowMoreThanOneLectInBatch, MaxNoOfLecureInRow,UpdatedByUserID, UpdatedDate, IsActive, IsDeleted);
            if (result == "Save Sucessfully...!!!" || result == "Updated Sucessfully...!!!")
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
                clearFields();
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
            BatchID = UpID;
            BatchName = txtBatchName.Text.Trim();
            BatchCode = txtBatchCode.Text.Trim();
            ClassID = Convert.ToInt32(cbClassName.SelectedValue);
            LectureDuration = Convert.ToInt32(txtlecDuration.Text.ToString());
            if (chkLunchBreak.IsChecked == true)
            {
                IsLunchBreak = 1;
            }
            else
            {
                IsLunchBreak = 0;
            }
            LunchBreakStartTime = comboBox1.SelectedValue.ToString();
            LunchBreakStartTime += ":" + comboBox2.SelectedValue.ToString();

            LunchBreakEndTime = comboBox3.SelectedValue.ToString();
            LunchBreakEndTime += ":" + comboBox4.SelectedValue.ToString();           
            MaxNoLecturesDay = Convert.ToInt32(txtMaxnoLecDay.Text.ToString());
            MaxNoLecturesWeek = Convert.ToInt32(txtMaxnoLecWeek.Text.ToString());
            if (chkallow.IsChecked == true)
            {
                IsAllowMoreThanOneLectInBatch = 1;
            }
            else
            {
                IsAllowMoreThanOneLectInBatch = 0;
            }
            MaxNoOfLecureInRow = Convert.ToInt32(txtMaxLecRow.Text.ToString());
            UpdatedByUserID = 1;
            UpdatedDate = DateTime.Now.ToString();           
            if (rdoActive.IsChecked == true && rdoDeActive.IsChecked== false)
            {
                IsActive = 1;
                IsDeleted = 0;
            }
            else if (rdoActive.IsChecked==false && rdoDeActive.IsChecked==true)
            {
                IsActive = 0;
                IsDeleted = 0;
            }
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

            if (txtBatchName.Text.Trim() == "" || string.IsNullOrEmpty(txtBatchName.Text))
            {
                MessageBox.Show("Please Enter Batch Name.", "Batch Name Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtBatchName.Focus();
                return false;
            }
            else if (txtBatchCode.Text.Trim() == "" || string.IsNullOrEmpty(txtBatchCode.Text))
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
            else if (txtlecDuration.Text.Trim() == "" || string.IsNullOrEmpty(txtlecDuration.Text))
            {
                MessageBox.Show("Please Enter Lecture Duration Time", "Lecture Duration Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtlecDuration.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region--------------bind Lunch Break Time------------------------------
        private void comboBox1_Items()
        {
            comboBox1.Items.Add("select");
            int i;
            for (i = 1; i <= 12; i++)
            {
                comboBox1.Items.Add(i);
            }
            comboBox1.SelectedIndex = 0;
        }
        #endregion

        #region--------------bind Lunch Break Time------------------------------
        private void comboBox2_Items()
        {
            comboBox2.Items.Add("select");
            int i;
            for (i = 1; i <= 60; i++)
            {
                comboBox2.Items.Add(i);
            }
            comboBox2.SelectedIndex = 0;
        }
        #endregion

        #region--------------bind Lunch Break Time------------------------------
        private void comboBox3_Items()
        {
            comboBox3.Items.Add("select");
            int i;
            for (i = 1; i <= 12; i++)
            {
                comboBox3.Items.Add(i);
            }
            comboBox3.SelectedIndex = 0;
        }
        #endregion

        #region--------------bind Lunch Break Time------------------------------
        private void comboBox4_Items()
        {
            comboBox4.Items.Add("select");
            int i;
            for (i = 1; i <= 60; i++)
            {
                comboBox4.Items.Add(i);
            }
            comboBox4.SelectedIndex = 0;
        }
        #endregion


        #region-----------------------------clearFields()------------------------------------------

        private void clearFields()
        {
            txtBatchName.Text = "";
            txtBatchCode.Text = "";
            cbClassName.Text = "";
            txtlecDuration.Text = "";
            txtMaxnoLecDay.Text = "";
            txtMaxnoLecWeek.Text = "";
            txtMaxLecRow.Text = "";
            chkLunchBreak.IsChecked = false;
            chkallow.IsChecked = false;
            rdoActive.IsChecked = false;
            rdoDeActive.IsChecked = false;
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";

           
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
            DataSet ds = obj_Batch.BindBatch(0, txtBatchName.Text);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dgvBatch.ItemsSource = ds.Tables[0].DefaultView;
                //dgvBatch.Columns[0].Visibility = Visibility.Collapsed;
            }
            dgvBatch.Items.Refresh();
        }
        #endregion



        #region------------------------BindClassName()---------------------------------------
        private void BindClassName()
        {
            try
            {
                DataSet ds = obj_Class.BindClassName();


                if (ds.Tables[0].Rows.Count > 0)
                {
                    cbClassName.DataContext = ds.Tables[0].DefaultView;
                    cbClassName.DisplayMemberPath = ds.Tables[0].Columns["ClassName"].ToString();
                    cbClassName.SelectedValuePath = ds.Tables[0].Columns["ClassID"].ToString();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
        #endregion

         #region--------------------------------------Delete button click()-------------------------------------
        private void btndelete_Click(object sender, RoutedEventArgs e)
        {                    
            try
            {              
                MessageBoxResult Result = MessageBox.Show("Do You Really Want To Delete?", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (Result.Equals(MessageBoxResult.Yes))
                {
                    SetParameters();
                    DeleteBatch();
                    dgvBatch.Items.Refresh();
                    BindGridview();
                    clearFields();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString()); 
            }
        }
        #endregion

        #region----------------------------DeleteBatch()----------------------------------
        private void DeleteBatch()
        {
            if (UpID != 0)
            {
                ClassID = UpID;

                string Result = obj_Batch.DeleteBatch(BatchID, UpdatedByUserID, UpdatedDate);
                if (Result == "Deleted Sucessfully...!!")
                {
                    MessageBox.Show(Result, "Delete Sucessfully", MessageBoxButton.OK, MessageBoxImage.Information);
                  
                    clearFields();
                    BindGridview();
                }
                else
                {
                    MessageBox.Show(Result, "Error To Delete", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please Select Batch From Batch", "Delete Error", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
        }
        #endregion

        #region--------------------------------------gridview cell click()-------------------------------------
        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                object item = dgvBatch.SelectedItem;
                //string Id = (dgvClass.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;                
                string ClassName = (dgvBatch.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                string BatchName = (dgvBatch.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                string BatchCode = (dgvBatch.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;

                string LectureDuration = (dgvBatch.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
                string IsLunchBreak = (dgvBatch.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text;
                string LunchBreakStartTime = (dgvBatch.SelectedCells[6].Column.GetCellContent(item) as TextBlock).Text;

                string LunchBreakEndTime = (dgvBatch.SelectedCells[7].Column.GetCellContent(item) as TextBlock).Text;
                string MaxNoLecturesDay = (dgvBatch.SelectedCells[8].Column.GetCellContent(item) as TextBlock).Text;
                string MaxNoLecturesWeek = (dgvBatch.SelectedCells[9].Column.GetCellContent(item) as TextBlock).Text;

                //string IsAllowMoreThanOneLectInBatch = (dgvBatch.SelectedCells[10].Column.GetCellContent(item) as TextBlock).Text;
                string MaxNoOfLecureInRow = (dgvBatch.SelectedCells[10].Column.GetCellContent(item) as TextBlock).Text;

                DataSet ds = obj_Batch.GetBatchDetail(BatchName, BatchCode);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        UpID = Convert.ToInt32(ds.Tables[0].Rows[0]["BatchID"]);
                        cbClassName.Text = ds.Tables[0].Rows[0]["ClassName"].ToString();
                        txtBatchName.Text = ds.Tables[0].Rows[0]["BatchName"].ToString();
                        txtBatchCode.Text = ds.Tables[0].Rows[0]["BatchCode"].ToString();

                        txtlecDuration.Text = ds.Tables[0].Rows[0]["LectureDuration"].ToString();
                        //int chk = Convert.ToString(ds.Tables[0].Rows[0]["IsLunchBreak"]);
                        //if(chk == 'true')
                        //{
                        //    chkLunchBreak.IsChecked=true;
                        //}                        
                        comboBox1.Text = ds.Tables[0].Rows[0]["LunchBreakStartTime"].ToString();
                        comboBox2.Text = ds.Tables[0].Rows[0]["LunchBreakStartTime"].ToString();
                        comboBox3.Text = ds.Tables[0].Rows[0]["LunchBreakEndTime"].ToString();
                        comboBox3.Text = ds.Tables[0].Rows[0]["LunchBreakEndTime"].ToString();
                        txtMaxnoLecDay.Text = ds.Tables[0].Rows[0]["MaxNoLecturesDay"].ToString();
                        txtMaxnoLecWeek.Text = ds.Tables[0].Rows[0]["MaxNoLecturesWeek"].ToString();

                        //chkallow.Unchecked = ds.Tables[0].Rows[0]["IsAllowMoreThanOneLectInBatch"].ToString();
                        txtMaxLecRow.Text = ds.Tables[0].Rows[0]["MaxNoOfLecureInRow"].ToString();
                       
                        //cbClassName.Text = ds.Tables[0].Rows[0]["ClassID"].ToString();
                        int act = Convert.ToInt32(ds.Tables[0].Rows[0]["IsActive"]);
                        int del = Convert.ToInt32(ds.Tables[0].Rows[0]["IsDeleted"]);
                        int lunchbreak = Convert.ToInt32(ds.Tables[0].Rows[0]["IsLunchBreak"]);
                        int Isallow = Convert.ToInt32(ds.Tables[0].Rows[0]["IsAllowMoreThanOneLectInBatch"]);
                        if (act == 1 && del == 0)
                        {
                            rdoActive.IsChecked = true;
                        }
                        else if (act == 0 && del == 0)
                        {
                            rdoDeActive.IsChecked = true;
                        }
                        if (lunchbreak == 1)
                        {
                            chkLunchBreak.IsChecked = true;
                        }
                        else
                        {
                            chkLunchBreak.IsChecked = false;
                        }
                        if (Isallow == 1)
                        {
                            chkallow.IsChecked = true;
                        }
                        else
                        {
                            chkallow.IsChecked = false;
                        }
                        btnDelete.IsEnabled = true;
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion

        #region------------------------btnSearch_Click----------------------
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(!string.IsNullOrEmpty(txtSearchBatch.Text.Trim()))
                {
                    DataSet ds = obj_Batch.SearchBatch(txtSearchBatch.Text);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                       dgvBatch.ItemsSource = ds.Tables[0].DefaultView;
                        //dgvClass.DataContext = ds.Tables[0].DefaultView;
                        //dgvClass.Columns[0].Visibility = Visibility.Collapsed;
                    }
                    else
                    {
                        dgvBatch.ItemsSource = null;
                        MessageBox.Show("No Data Available");
                    }

                }
                else
                {
                    MessageBox.Show("Please Enter Class Name", "Message", MessageBoxButton.OK, MessageBoxImage.Warning);
                    txtSearchBatch.Focus();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
                    
        #endregion

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            comboBox1_Items();
            comboBox2_Items();
            comboBox3_Items();
            comboBox4_Items();
            BindGridview();
            btnDelete.IsEnabled = false;

        }

        private void txtBatchCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (txtBatchCode.Text != "")
                {
                    if (txtBatchCode.Text.Length > 0 && txtBatchCode.Text.Length == 1)
                    {
                        if (System.Text.RegularExpressions.Regex.IsMatch(txtBatchCode.Text, "^[a-zA-Z]"))
                        {
                        }
                        else
                        {
                            MessageBox.Show("Please Enter First Characerter Alphabate", "Batch Code", MessageBoxButton.OK, MessageBoxImage.Warning);
                            txtBatchCode.Text = "";
                            txtBatchCode.Focus();
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #region---------------------------txtlecDuration_TextChanged-----------------------
        private void txtlecDuration_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (txtBatchCode.Text != "")
                {
                    if (txtBatchCode.Text.Length > 0 && txtBatchCode.Text.Length == 1)
                    {
                        if (System.Text.RegularExpressions.Regex.IsMatch(txtBatchCode.Text, "^[0-9]"))
                        {
                        }
                        else
                        {
                            MessageBox.Show("Please Enter Only Numbers", "Batch Code", MessageBoxButton.OK, MessageBoxImage.Warning);
                            txtBatchCode.Text = "";
                            txtBatchCode.Focus();
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

        #region-----------------txtMaxnoLecDay_TextChanged-----------------------------------
        private void txtMaxnoLecDay_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (txtMaxnoLecDay.Text != "")
                {
                    if (txtMaxnoLecDay.Text.Length > 0 && txtMaxnoLecDay.Text.Length == 1)
                    {
                        if (System.Text.RegularExpressions.Regex.IsMatch(txtMaxnoLecDay.Text, "^[0-9]"))
                        {
                        }
                        else
                        {
                            MessageBox.Show("Please Enter Only Numbers", "Max no.of lecture Code", MessageBoxButton.OK, MessageBoxImage.Warning);
                            txtMaxnoLecDay.Text = "";
                            txtMaxnoLecDay.Focus();
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

    }
}

