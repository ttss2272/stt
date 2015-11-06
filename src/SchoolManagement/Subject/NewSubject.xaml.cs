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
using System.Data;


namespace SchoolManagement.Subject
{
    /// <summary>
    /// Interaction logic for NewSubject.xaml
    /// </summary>
    
    
    public partial class NewSubject : Window
    {
        /*
       * Created By:- PriTesh D. Sortee
       * Ctreated Date :- 4 Nov 2015
       * StartTime:-3:20PM
       * EndTime:-3:25PM
       * Purpose:- Declare Global Variables
       */
        #region-------------------------------------------Declare Variables Globally()---------------------------------------------------
        BLSubject objSubject = new BLSubject();
        int SubjectID, UpdatedByUserID, Active,IsDeleted,UpID;
        string SubjectName, SubjectShortName, UpdatedDate;

        #endregion

        /*
         * Created By:- PriTesh D. Sortee
         * Ctreated Date :- 4 Nov 2015
         * StartTime:-3:55PM
         * EndTime:-3:58PM
         * Purpose :- Subject()
         */
        #region-----------------------------------------------------------------Subject()-------------------------------------------
        public NewSubject()
        {
            try
            {
                InitializeComponent();
                ClearFields();


            }
            catch (Exception ex)
            {
                MessageBox.Show (ex.Message.ToString());
            }
        }
        #endregion

        /*
         * Created By:- PriTesh D. Sortee
         * Ctreated Date :- 4 Nov 2015
         * StartTime:-3:55PM
         * EndTime:-3:58PM
         * Purpose Clear All Fields
         */
        #region-------------------------------------------------ClearFields()-------------------------------------
        private void ClearFields()
        {
            txtSubjectName.Text="";
            txtSubjectShortName.Text="";
            bindSubjectGrid();
            cmbActive.IsChecked = true;
            UpID = 0;
            btnDelete.IsEnabled = false;
            txtSearchSubject.Text = "";
        }
        #endregion

        /*
         * Created By:- PriTesh D. Sortee
         * Ctreated Date :- 4 Nov 2015
         * StartTime:-PM
         * EndTime:-PM
         * Purpose:- Bind Grid
         */

        #region----------------------------------BindSubjectGrid()----------------------------------------------------
        private void bindSubjectGrid()
        {
             DataSet ds = objSubject.BindSubject(0);
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdvSubject.ItemsSource = ds.Tables[0].DefaultView;
                //grdvSubject.DataContext = ds.Tables[0].DefaultView;
                //grdvSubject.Columns[0].Visibility = Visibility.Collapsed;
            }
        }
        #endregion

         /*
         * Created By:- PriTesh D. Sortee
         * Ctreated Date :- 4 Nov 2015
         * StartTime:-PM
         * EndTime:-PM
         * Purpose Clear All Fields
         */
        #region----------------------------------------------btnSave_Click-----------------------------------------------------------
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            
                try
            {
                if (Validate())
                {
                    SetParameters();
                    SaveDetails();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            
            
        }
        #endregion


        /*
        * Created By:- PriTesh D. Sortee
        * Ctreated Date :- 4 Nov 2015
        * StartTime:-3:32PM
        * EndTime:-3:34PM
        * Purpose Clear All Fields
        */
        #region-----------------------------------btn Clear Click--------------------------------------------------
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion


        /*
         * Created By:- PriTesh D. Sortee
         * Ctreated Date :- 4 Nov 2015
         * StartTime:-4:00PM
         * EndTime:-4:32 PM
         * Purpose:- validate
         */
        #region-------------------------------------------------Validate()-------------------------------------
        private bool Validate()
        {
            if (txtSubjectName.Text.Trim() == "" || string.IsNullOrEmpty(txtSubjectName.Text))
            {
                MessageBox.Show("Please Enter Subject Name.", "Subject Name Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtSubjectName.Focus();
                return false;
            }
            else if (txtSubjectShortName.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Subject Short Name.", "Short Name Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtSubjectShortName.Focus();
                return false;
            }

            else
            {
                return true;

            }


        }
        #endregion

        /*
         * Created By:- PriTesh D. Sortee
         * Ctreated Date :- 4 Nov 2015
         * StartTime:-4:00PM
         * EndTime:-
         * Purpose:- SetParameters
         */
        #region-------------------------------------------------SetParameters()-------------------------------------
        private void SetParameters()
        {
            
            SubjectID = UpID;
            SubjectName = txtSubjectName.Text.Trim();
            SubjectShortName = txtSubjectShortName.Text.Trim();
            UpdatedByUserID = 1;
            UpdatedDate = DateTime.Now.ToString();
            if (cmbActive.IsChecked == true)
            {
                Active = 1;
                IsDeleted=0;
            }
            else
            {
                Active = 0;
                IsDeleted = 0;

            }


        }
        #endregion


        /*
         * Created By:- PriTesh D. Sortee
         * Ctreated Date :- 4 Nov 2015
         * StartTime:-4:25PM
         * EndTime:-4:27 PM
         * Purpose:- txtSubjectName S
         */
        #region-------------------------------------------------txtSubjectShortName()-------------------------------------
        private void txtSubjectShortName_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (txtSubjectName.Text != "")
                {
                    if (txtSubjectName.Text.Length > 0 && txtSubjectName.Text.Length == 1)
                    {
                        if (System.Text.RegularExpressions.Regex.IsMatch(txtSubjectShortName.Text, "^[a-zA-Z]"))
                        {
                        }
                        else
                        {
                            MessageBox.Show("Please Enter First Characerter Alphabate", "Subject Short Name", MessageBoxButton.OK, MessageBoxImage.Warning);
                            txtSubjectShortName.Text = "";
                            txtSubjectShortName.Focus();
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


        /*
         * Created By:- PriTesh D. Sortee
         * Ctreated Date :- 4 Nov 2015
         * StartTime:-4:20PM
         * EndTime:-4:24 PM
         * Purpose:- txtSubjectName Text Changed
         */
        #region-------------------------------------------------txtSubjectName()-------------------------------------
        private void txtSubjectName_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (txtSubjectName.Text != "")
                {
                    if (txtSubjectName.Text.Length > 0 && txtSubjectName.Text.Length == 1)
                    {
                        if (System.Text.RegularExpressions.Regex.IsMatch(txtSubjectName.Text, "^[a-zA-Z]"))
                        {
                        }
                        else
                        {
                            MessageBox.Show("Please Enter First Characerter Alphabate", "Subject Name", MessageBoxButton.OK, MessageBoxImage.Warning);
                            txtSubjectName.Text = "";
                            txtSubjectName.Focus();
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

        /*
         * Created By:- PriTesh D. Sortee
         * Ctreated Date :- 4 Nov 2015
         * StartTime:-PM
         * EndTime:-PM
         * Purpose:- SaveDetails
         */
        #region--------------------------------------SaveDetails()-------------------------------------
        private void SaveDetails()
        {
            string Result = objSubject.SaveSubject(SubjectID, SubjectName, SubjectShortName, UpdatedByUserID, UpdatedDate, Active,IsDeleted);
          
            if (Result == "Save Sucessfully...!!!" || Result == "Updated Sucessfully...!!!")
            {
                MessageBox.Show(Result, "Save SucessFull", MessageBoxButton.OK, MessageBoxImage.Information);
                ClearFields();
            }
            else
            {
                MessageBox.Show(Result, "Error To Save", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion

        /*
         * Created By:- PriTesh D. Sortee
         * Ctreated Date :- 5 Nov 2015
         * StartTime:-1:00PM
         * EndTime:-7:13PM
         * Purpose:- griddview cell click
         */
        #region--------------------------------------gridview cell click()-------------------------------------
        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                //txtSubjectName.Text = grdvSubject.SelectedItem.ToString();
                //grdvSubject.se
                object item = grdvSubject.SelectedItem;
                //string Id = (grdvSubject.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                string SubName = (grdvSubject.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                string ShortName = (grdvSubject.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;

                DataSet ds = objSubject.GetSubjectDetail(SubName, ShortName);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        UpID = Convert.ToInt32(ds.Tables[0].Rows[0]["SubjectID"]);
                        txtSubjectName.Text = ds.Tables[0].Rows[0]["SubjectName"].ToString();
                        txtSubjectShortName.Text = ds.Tables[0].Rows[0]["SubjectShortName"].ToString();
                        int act = Convert.ToInt32(ds.Tables[0].Rows[0]["IsActive"]);
                        int del = Convert.ToInt32(ds.Tables[0].Rows[0]["IsDeleted"]);
                        if (act == 1 && del == 0)
                        {
                            cmbActive.IsChecked = true;
                        }
                        else if (act == 0 && del == 0)
                        {
                            cmbDelete.IsChecked = true;
                        }
                        btnDelete.IsEnabled = true;
                    }
                }

                

            }
            catch (Exception ex)
            {
                
                MessageBox.Show (ex.Message.ToString());
            }
        }
        #endregion

        /*
         * Created By:- PriTesh D. Sortee
         * Ctreated Date :- 5 Nov 2015
         * StartTime:-1:00PM
         * EndTime:-7:13PM
         * Purpose:- Delete Button Click
         */
        #region--------------------------------------Delete button click()-------------------------------------
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //DialogResult Result = MessageBox.Show("Do You Really Want To Delete?", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Information);
                MessageBoxResult Result = MessageBox.Show("Do You Really Want To Delete?", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (Result.Equals(MessageBoxResult.Yes))
                {
                    SetParameters();
                    DeleteSubject();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString()); 
            }
        }
        #endregion
        /*
         * Created By:- PriTesh D. Sortee
         * Ctreated Date :- 5Nov 2015
         * StartTime:-1:00PM
         * EndTime:-7:13PM
         * Purpose:- griddview cell click
         */
        #region--------------------------------------gridview cell click()-------------------------------------
        private void DeleteSubject()
        {
            if (UpID != 0)
            {
                SubjectID = UpID;

                string Result = objSubject.DeleteSubject(SubjectID, UpdatedByUserID, UpdatedDate);
                if (Result == "Deleted Sucessfully.")
                {
                    MessageBox.Show(Result,"Delete Sucessfully",MessageBoxButton.OK,MessageBoxImage.Information);
                    ClearFields();
                }
                else
                {
                    MessageBox.Show(Result,"Error To Delete",MessageBoxButton.OK,MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please Select Subject From Subject","Delete Error",MessageBoxButton.OK,MessageBoxImage.Warning);
            
            }
        }
        #endregion

        /*
         * Created By:- PriTesh D. Sortee
         * Ctreated Date :- 5Nov 2015
         * StartTime:-1:00PM
         * EndTime:-7:13PM
         * Purpose:- griddview cell click
         */
        #region---------------------------------btn Search click-------------------------------------------------
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtSearchSubject.Text.Trim()))
                {
                    DataSet ds = objSubject.SearchSubject(txtSearchSubject.Text);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        grdvSubject.ItemsSource = ds.Tables[0].DefaultView;
                        //grdvSubject.DataContext = ds.Tables[0].DefaultView;
                        //grdvSubject.Columns[0].Visibility = Visibility.Collapsed;
                    }
                    else
                    {
                        grdvSubject.ItemsSource = null;
                        MessageBox.Show("No Data Available");
                    }

                }
                else
                {
                    MessageBox.Show("Please Enter Subject Name","Message",MessageBoxButton.OK,MessageBoxImage.Warning);
                    txtSearchSubject.Focus();

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
