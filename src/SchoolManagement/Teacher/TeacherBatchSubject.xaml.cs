﻿using System;
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
using System.Windows.Controls.Primitives;
using System.Data;
using BusinessLayer;

namespace SchoolManagement.Teacher
{
    /// <summary>
    /// Interaction logic for TeacherBatchSubject.xaml
    /// </summary>
    public partial class TeacherBatchSubject : Window
    {
        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:-21 Nov2015
         * Purpose:-
         * StartTime:-
         * EndTime:-
         */
        #region--------------------------------------------------Declare Variables and Objects----------------------------------
        BLTeacher objTeacher = new BLTeacher();
        BLSubject objSubject =new BLSubject();
        BLAddBranch objBranch=new BLAddBranch();
        BLTeacherSubject objTeacherSubject = new BLTeacherSubject();

        static int k = 0;
        int TeacherID, BatchsubjectID, UpdatedByUserID,  IsDeleted;
        string UpdatedDate,Active;
        int [] ID=new int[100];
        #endregion
        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:-21 Nov2015
         * Purpose:-
         * StartTime:-
         * EndTime:-
         */
        #region----------------------------------------------------------Main()----------------------------------------------------
        public TeacherBatchSubject()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion

        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:-21 Nov 2015
         * Purpose:-Bton go Click
         * StartTime:-
         * EndTime:-
         */
        #region----------------------------------------------------------btnGo_Click----------------------------------------------------
        private void btnGo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cmbTeacher.SelectedValue.ToString() != "0")
                {
                    if (btnGo.Content.ToString() == "Go")
                    {
                        EnableLowerPart();
                        BindTeacherSubject();
                    }
                    else if (btnGo.Content.ToString() == "Change")
                    {
                        DisableLowerPart();
                    }
                }
                else
                {
                    MessageBox.Show("Please Select Teacher", "Info", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(),"Exception",MessageBoxButton.OK,MessageBoxImage.Warning);
            }
        }
        #endregion

        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:-21 Nov 2015
         * Purpose:- btn Save Click
         * StartTime:-
         * EndTime:-
         */
        #region----------------------------------------------------------btnSave_Click----------------------------------------------------
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Validate())
                {
                    SetParameters();
                    BindTeacherSubject();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion

        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:-21 Nov 2015
         * Purpose:- btn Clear Click
         * StartTime:-
         * EndTime:-
         */
        #region----------------------------------------------------------btnClear_Click----------------------------------------------------
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClearLowerPart();
                BindTeacherSubject();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion

        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:-21 Nov 2015
         * Purpose:- Window_Loaded
         * StartTime:-
         * EndTime:-
         */

        #region--------------------------------------------------Window_Loaded()----------------------------------------------------------------
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                this.WindowState = WindowState.Maximized;
                this.Width = System.Windows.SystemParameters.PrimaryScreenWidth;
                this.Height = System.Windows.SystemParameters.PrimaryScreenHeight;
                DisableLowerPart();
                BindTeacher();
                BindBranch();
                BindTeacherSubject();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion

        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:-21 Nov 2015
         * Purpose:- ClearData
         * StartTime:-
         * EndTime:-
         */
        #region-------------------------------------------------ClearData()---------------------------------------------------------------------
        private void ClearData()
        {
            cmbBranch.SelectedValue = "0";
            cmbSubject.SelectedValue = "0";
            dgBatch.DataContext = null;
        }
        #endregion

        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:-21 Nov 2015
         * Purpose:- BindTeacher()
         * StartTime:-
         * EndTime:-
         */
        #region-------------------------------------------------BindTeacher()---------------------------------------------------------------------
        private void BindTeacher()
        {
            DataSet ds = objTeacher.BindTeacherDropDown(0);

            if (ds.Tables[0].Rows.Count > 0)
            {
                cmbTeacher.DataContext = null;

                cmbTeacher.DataContext = ds.Tables[0].DefaultView;
                cmbTeacher.DisplayMemberPath = ds.Tables[0].Columns["TeacherName"].ToString();
                cmbTeacher.SelectedValuePath = ds.Tables[0].Columns["TeacherID"].ToString();


                cmbTeacher.SelectedValue = "0";
            }
        }
        
        #endregion

        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:-21 Nov 2015
         * Purpose:- BindBranch()
         * StartTime:-
         * EndTime:-
         */
        #region-------------------------------------------------BindBranch()---------------------------------------------------------------------
        private void BindBranch()
        {
               DataSet ds = objBranch.BindBranchName();


                if (ds.Tables[0].Rows.Count > 0)
                {
                    cmbBranch.DataContext = null;
                    cmbBranch.DisplayMemberPath = ds.Tables[0].Columns["BranchName"].ToString();
                    cmbBranch.SelectedValuePath = ds.Tables[0].Columns["BranchID"].ToString();
                    cmbBranch.DataContext = ds.Tables[0].DefaultView;
                    cmbBranch.SelectedValue = "0";
                }

           
            
        }
        #endregion
        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:-21 Nov 2015
         * Purpose:- BindSubject()
         * StartTime:-
         * EndTime:-
         */
        #region-------------------------------------------------BindSubject()---------------------------------------------------------------------
         private void BindSubject()
         {
             DataSet ds = objTeacherSubject.GetBranchSubject(Convert.ToInt32(cmbBranch.SelectedValue));
            if (ds.Tables[0].Rows.Count > 0)
            {
                cmbSubject.DataContext = null;
                cmbSubject.DisplayMemberPath = ds.Tables[0].Columns["SubjectName"].ToString();
                cmbSubject.SelectedValuePath = ds.Tables[0].Columns["SubjectID"].ToString();
                cmbSubject.DataContext = ds.Tables[0].DefaultView;
                cmbSubject.SelectedValue = "0";
            }
        }

        #endregion

         /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:-21 Nov 2015
         * Purpose:- DisableLowerPart()
         * StartTime:-
         * EndTime:-
         */
        #region----------------------------------------------------DisableLowerPart()------------------------------------------------------------
         private void DisableLowerPart()
         {
             cmbBranch.IsEnabled = false;
             cmbSubject.IsEnabled = false;
             dgBatch.DataContext = null;

             cmbTeacher.IsEnabled = true;
             btnGo.Content = "Go";
         }
        #endregion

         /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:-21 Nov 2015
         * Purpose:- EnableLowerPart()
         * StartTime:-
         * EndTime:-
         */
        #region----------------------------------------------------EnableLower Part()------------------------------------------------------------
         private void EnableLowerPart()
         {
             cmbBranch.IsEnabled = true;
             cmbSubject.IsEnabled = true;
             dgBatch.DataContext = null;

             cmbTeacher.IsEnabled = false;
             btnGo.Content = "Change";
         }
        #endregion

         /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:-21 Nov 2015
         * Purpose:- cmbSubject_SelectionChaged
         * StartTime:-
         * EndTime:-
         */
         #region------------------------------------------------cmbSubject_SelectionChanged--------------------------------------------------
         private void cmbSubject_SelectionChanged(object sender, SelectionChangedEventArgs e)
         {
             try
             {
                 if (cmbBranch.SelectedValue.ToString() != "0")
                 { 
                     if(cmbSubject.SelectedValue!="0" && cmbSubject.SelectedValue!=null)
                     {
                         BindBatch();
                         
                     }
                     else
                     {
                         dgBatch.DataContext=null;
                     }
                 }
                 
                 else
                 {
                     dgBatch.DataContext = null;
                     //MessageBox.Show("Please Select Branch First", "Info", MessageBoxButton.OK, MessageBoxImage.Warning);
                 }

             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message.ToString(), "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);               
             }
         }
        #endregion

         /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:-21 Nov 2015
         * Purpose:- Bind Batches To grid view
         * StartTime:-
         * EndTime:-
         */
        #region------------------------------------------------------BindBatch()-----------------------------------------------------------
         private void BindBatch()
         {
             DataSet ds = objTeacherSubject.GetBatchBySubject(Convert.ToInt32(cmbBranch.SelectedValue), Convert.ToInt32(cmbSubject.SelectedValue),Convert.ToInt32(cmbTeacher.SelectedValue));
             if (ds.Tables[0].Rows.Count > 0)
             {
                 dgBatch.DataContext = null;
                 dgBatch.DataContext = ds.Tables[0].DefaultView;

                 for (int i = 0; i < ds.Tables[0].Rows.Count;i++ )
                 {
                     if (ds.Tables[0].Rows[i][3].ToString()=="True")
                     {
                         ID[k] = i;
                         k++;
                     }

                     
                 }


                 
             }
             else
             {
                 dgBatch.DataContext = null;
                 MessageBox.Show("There Is No Batch For This Subject ","Info",MessageBoxButton.OK,MessageBoxImage.Warning);
             }
         }
        #endregion

        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:-21 Nov 2015
         * Purpose:- Validate
         * StartTime:-
         * EndTime:-
         */
        #region---------------------------------------------------Validate()---------------------------------------------------------------
        private bool Validate()
         {
            if (cmbBranch.SelectedValue.ToString()=="0" )
            {
                MessageBox.Show("Please Select Branch.","Info",MessageBoxButton.OK,MessageBoxImage.Warning);
                cmbBranch.Focus();
                return false;
            }
            else if ( cmbSubject.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("Please Select Subject", "Info", MessageBoxButton.OK, MessageBoxImage.Warning);
                cmbSubject.Focus();
                return false;
            }
            
            else
            {
                return true;
            }

         }
        #endregion

        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:-21 Nov 2015
         * Purpose:- SetParametres()
         * StartTime:-
         * EndTime:-
         */
        #region---------------------------------------------------SetParameters()---------------------------------------------------------------
        private void SetParameters()
        {
            int cnt=0;
            TeacherID = Convert.ToInt32(cmbTeacher.SelectedValue);
            
            UpdatedByUserID = 1;
            UpdatedDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            //Active = 1;
            IsDeleted = 0;
            
            for (int j=0;j<dgBatch.Items.Count;j++)
            {
                dgBatch.CurrentItem = dgBatch.Items[j];
                Active = Convert.ToString(((System.Data.DataRowView)(dgBatch.CurrentItem)).Row.ItemArray[3].ToString());
                //int s= Convert.ToInt32(((System.Data.DataRowView)(dgBatch.CurrentItem)).Row.ItemArray[2].ToString());
               // if (ID[j]!=0)
               // {
                BatchsubjectID = Convert.ToInt32(((System.Data.DataRowView)(dgBatch.CurrentItem)).Row.ItemArray[0].ToString());
                    string Result = objTeacherSubject.SaveTeacherSubject(TeacherID, BatchsubjectID, UpdatedByUserID, UpdatedDate, Active, IsDeleted);
                    if (Result == "Save Sucessfully...!!!" || Result == "Updated Sucessfully...!!!")
                    {
                        cnt++;
                    }
                    else
                    {

                    }
                //}
                //else
                //{
                //    cnt++;
                //}
            }
            if (cnt == dgBatch.Items.Count)
            {
                MessageBox.Show("Save Sucessfully...!!!", "Save SucessFull", MessageBoxButton.OK, MessageBoxImage.Information);
                ClearLowerPart();
            }
            else
            {
                MessageBox.Show("Error To Save Some Information", "Error To Save", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion

        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:-23 Nov 2015
         * Purpose:- Check Box Cheked
         * StartTime:-
         * EndTime:-
         */

        #region---------------------------------------------------chkDiscountinue_Checked--------------------------------------------------------
        private void chkDiscontinue_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                //CheckedDetails();
                    
                //object item = dgBatch.SelectedItem;
                //if (item!=null)
                //{ 
                //    int i = Convert.ToInt32(((System.Data.DataRowView)(dgBatch.CurrentItem)).Row.ItemArray[0].ToString());
                //    {
                //        ID[k] = i;
                //        k++;

                //    }
                //}
            
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString(), "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion

        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:-23 Nov 2015
         * Purpose:- Check Box Clicked
         * StartTime:-
         * EndTime:-
         */
        #region----------------------------------------------------chkDiscountinue_Click----------------------------------------------------------
        private void chkDiscontinue_Click(object sender, RoutedEventArgs e)
        {
            

        }
        #endregion

        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:-23 Nov 2015
         * Purpose:- Check Box UnCheked
         * StartTime:-
         * EndTime:-
         */
        #region---------------------------------------------------chkDiscountinue_Checked--------------------------------------------------------
        private void chkDiscontinue_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                //object item = dgBatch.SelectedItem;

                //int i = Convert.ToInt32(((System.Data.DataRowView)(dgBatch.CurrentItem)).Row.ItemArray[0].ToString());
                
                //    for (int j = 0; j <= k; j++)
                //    {
                //        if (ID[j] == i)
                //        {
                //            ID[j] = 0;
                //        }

                //    }


                

            }
            catch (Exception ex)
            {
                 MessageBox.Show(ex.Message.ToString(), "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            

        }
        #endregion

        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:-02 Dec 2015
         * Purpose:- clear lower part after save or click on clear button
         * StartTime:-
         * EndTime:-
         */
        #region--------------------------------------------------------ClearLowerPart()-------------------------------------------
        private void ClearLowerPart()
        {
            k = 0;
            cmbBranch.SelectedValue = "0";
            dgBatch.DataContext = null;
            //cmbSubject.SelectedValue = "0";

        }
        #endregion

        /*
         * CreatedBy:-PriTesh D. Sortee
         * Created Date:-02 Dec 2015
         * Purpose:- Bind Subject On Brach Selection change
         * StartTime:-
         * EndTime:-
         */
        #region---------------------------------------cmbBranch_SelectionChanged----------------------------------------------
        private void cmbBranch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cmbBranch.SelectedValue != "0")
                {
                    BindSubject();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(),"Exception",MessageBoxButton.OK,MessageBoxImage.Warning);
            }
        }
        #endregion

        /*
         * CreatedBy:-Pranjali Vidhate
         * Created Date:-10 Dec 2015
         * Purpose:- Bind TeacherSubject
         * StartTime:-
         * EndTime:-
         */
        #region------------------------------BindTeacherSubject---------------------------------------------------------
        public void BindTeacherSubject()
        {
            try
            {
                if (cmbTeacher.SelectedValue.ToString() != "0")
                {
                    DataSet ds = objTeacherSubject.BindTeacherSubject(Convert.ToInt32(cmbTeacher.SelectedValue.ToString()));
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DgTeacherSubject.ItemsSource = ds.Tables[0].DefaultView;
                    }
                    else
                    {
                        DgTeacherSubject.ItemsSource = null;
                        //MessageBox.Show("No Data Present for This Teacher");
                    }
                    DgTeacherSubject.Items.Refresh();
                }
                else
                {
                    DataSet ds = objTeacherSubject.BindTeacherSubject(0);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DgTeacherSubject.ItemsSource = ds.Tables[0].DefaultView;
                    }
                }
                
                DgTeacherSubject.Items.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(),"Exception",MessageBoxButton.OK,MessageBoxImage.Warning);
            }
        }
        #endregion


    }
}

