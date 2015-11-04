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
using System.Data;
using BusinessLayer;

namespace SchoolManagement.Subject
{
    /// <summary>
    /// Interaction logic for Subject.xaml
    /// </summary>
    public partial class Subject : Window
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
        int SubjectID, UpdatedByUserID,IsActive;
        string SubjectName, SubjectShortName,UpdatedDate;
        
        #endregion


        /*
         * Created By:- PriTesh D. Sortee
         * Ctreated Date :- 4 Nov 2015
         * StartTime:-3:55PM
         * EndTime:-3:58PM
         * Purpose :- Subject()
         */
        #region-----------------------------------------------------------------Subject()-------------------------------------------
        public Subject()
        {
            InitializeComponent();
            ClearFields();
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
         * StartTime:-3:55PM
         * EndTime:-3:58PM
         * Purpose Clear All Fields
         */
        #region-------------------------------------------------ClearFields()-------------------------------------
        private void ClearFields()
        {
            txtSubjectName.Text = "";
            txtSubjectShortName.Text = "";
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
            IsActive = 1;

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
            else if (txtSubjectShortName.Text.Trim()=="")
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
                            MessageBox.Show("Please Enter First Characerter Alphabate","Subject Short Name",MessageBoxButton.OK,MessageBoxImage.Warning);
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
            string Result = objSubject.SaveSubject(SubjectID, SubjectName, SubjectShortName, UpdatedByUserID, UpdatedDate, IsActive);
            if (Result == "Save Sucessfully...!!!" && Result == "Updated Sucessfully...!!!")
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

        private void grdvSubject_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {

            }
            catch ( Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
