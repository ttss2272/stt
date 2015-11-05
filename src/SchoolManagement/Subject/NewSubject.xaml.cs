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
        int SubjectID, UpdatedByUserID, Active;
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
            if (txtSubjectName.Text.Trim() == "")
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
            SubjectID = 0;
            SubjectName = txtSubjectName.Text.Trim();
            SubjectShortName = txtSubjectShortName.Text.Trim();
            UpdatedByUserID = 1;
            UpdatedDate = DateTime.Now.ToString();
            Active = 1;

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
            string Result = objSubject.SaveSubject(SubjectID, SubjectName, SubjectShortName, UpdatedByUserID, UpdatedDate, Active);
          
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

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                //txtSubjectName.Text = grdvSubject.sel
                

            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

    }
}
