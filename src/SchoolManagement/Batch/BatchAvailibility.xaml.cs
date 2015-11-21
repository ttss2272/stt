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

namespace SchoolManagement.Batch
{
    /// <summary>
    /// Interaction logic for BatchAvailibility.xaml
    /// </summary>
    public partial class BatchAvailibility : Window
    {
        #region-----------------------------------------Main()-------------------------------------------------------------------------
        public BatchAvailibility()
        {
            try
            {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
            this.Width = System.Windows.SystemParameters.PrimaryScreenWidth;
            this.Height = System.Windows.SystemParameters.PrimaryScreenHeight;
            ClearFields();
             }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
        #endregion

        #region---------------------------------Declare variables Globally-------------------------------------
        BLBatch objBatch = new BLBatch();        
        int daycheckcount = 0, cnn, n = 0;
        string tmpStartTime, tmpEndTime;
        string[] StartTime;
        string[] EndTime;
        string[] s;

        int BatchID,BranchID, UpdatedByUserID, Active, IsDeleted;
        string Day, FinalStartTime, FinalEndTime, UpdatedDate;
        #endregion

        #region-----------btnGo-------------------------------
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cmbBatch.SelectedValue.ToString() == "0")
                {
                    MessageBox.Show("Please Select Batch.");
                }
                else
                {
                    cmbBatch.IsEnabled = false;
                    Clears();
                    GetBatchAvailableDetails(Convert.ToInt32(cmbBatch.SelectedValue));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion

        #region---------------------------------------------------BindHours------------------------------------------------
        private void BindHours()
        {
            chkStartHrs.Items.Clear();
            chkStartHrs1.Items.Clear();
            chkStartHrs2.Items.Clear();
            chkStartHrs3.Items.Clear();
            chkStartHrs4.Items.Clear();
            chkStartHrs5.Items.Clear();
            chkStartHrs6.Items.Clear();
            chkStartHrs7.Items.Clear();

            chkEndhrs.Items.Clear();
            chkEndhrs1.Items.Clear();
            chkEndhrs2.Items.Clear();
            chkEndhrs3.Items.Clear();
            chkEndhrs4.Items.Clear();
            chkEndhrs5.Items.Clear();
            chkEndhrs6.Items.Clear();
            chkEndhrs7.Items.Clear();

            chkStartHrs.Items.Add("HRS");
            chkStartHrs1.Items.Add("HRS");
            chkStartHrs2.Items.Add("HRS");
            chkStartHrs3.Items.Add("HRS");
            chkStartHrs4.Items.Add("HRS");
            chkStartHrs5.Items.Add("HRS");
            chkStartHrs6.Items.Add("HRS");
            chkStartHrs7.Items.Add("HRS");


            chkEndhrs.Items.Add("HRS");
            chkEndhrs1.Items.Add("HRS");
            chkEndhrs2.Items.Add("HRS");
            chkEndhrs3.Items.Add("HRS");
            chkEndhrs4.Items.Add("HRS");
            chkEndhrs5.Items.Add("HRS");
            chkEndhrs6.Items.Add("HRS");
            chkEndhrs7.Items.Add("HRS");
            int i;
            for (i = 1; i <= 24; i++)
            {
                if (i < 10)
                {
                    chkStartHrs.Items.Add(n + i.ToString());
                    chkStartHrs1.Items.Add(n + i.ToString());
                    chkStartHrs2.Items.Add(n + i.ToString());
                    chkStartHrs3.Items.Add(n + i.ToString());
                    chkStartHrs4.Items.Add(n + i.ToString());
                    chkStartHrs5.Items.Add(n + i.ToString());
                    chkStartHrs6.Items.Add(n + i.ToString());
                    chkStartHrs7.Items.Add(n + i.ToString());

                    chkEndhrs.Items.Add(n + i.ToString());
                    chkEndhrs1.Items.Add(n + i.ToString());
                    chkEndhrs2.Items.Add(n + i.ToString());
                    chkEndhrs3.Items.Add(n + i.ToString());
                    chkEndhrs4.Items.Add(n + i.ToString());
                    chkEndhrs5.Items.Add(n + i.ToString());
                    chkEndhrs6.Items.Add(n + i.ToString());
                    chkEndhrs7.Items.Add(n + i.ToString());
                }
                else
                {
                    chkStartHrs.Items.Add(i);
                    chkStartHrs1.Items.Add(i);
                    chkStartHrs2.Items.Add(i);
                    chkStartHrs3.Items.Add(i);
                    chkStartHrs4.Items.Add(i);
                    chkStartHrs5.Items.Add(i);
                    chkStartHrs6.Items.Add(i);
                    chkStartHrs7.Items.Add(i);

                    chkEndhrs.Items.Add(i);
                    chkEndhrs1.Items.Add(i);
                    chkEndhrs2.Items.Add(i);
                    chkEndhrs3.Items.Add(i);
                    chkEndhrs4.Items.Add(i);
                    chkEndhrs5.Items.Add(i);
                    chkEndhrs6.Items.Add(i);
                    chkEndhrs7.Items.Add(i);
                }
            }
            chkStartHrs.SelectedIndex = 0;
            chkStartHrs1.SelectedIndex = 0;
            chkStartHrs2.SelectedIndex = 0;
            chkStartHrs3.SelectedIndex = 0;
            chkStartHrs4.SelectedIndex = 0;
            chkStartHrs5.SelectedIndex = 0;
            chkStartHrs6.SelectedIndex = 0;
            chkStartHrs7.SelectedIndex = 0;

            chkEndhrs.SelectedIndex = 0;
            chkEndhrs1.SelectedIndex = 0;
            chkEndhrs2.SelectedIndex = 0;
            chkEndhrs3.SelectedIndex = 0;
            chkEndhrs4.SelectedIndex = 0;
            chkEndhrs5.SelectedIndex = 0;
            chkEndhrs6.SelectedIndex = 0;
            chkEndhrs7.SelectedIndex = 0;

        }
        #endregion

        #region---------------------------------------------------BindMinutes------------------------------------------------
        private void BindMinutes()
        {

            chkStartMin.Items.Clear();
            chkStartMin1.Items.Clear();
            chkStartMin2.Items.Clear();
            chkStartMin3.Items.Clear();
            chkStartMin4.Items.Clear();
            chkStartMin5.Items.Clear();
            chkStartMin6.Items.Clear();
            chkStartMin7.Items.Clear();

            EndMin.Items.Clear();
            EndMin1.Items.Clear();
            EndMin2.Items.Clear();
            EndMin3.Items.Clear();
            EndMin4.Items.Clear();
            EndMin5.Items.Clear();
            EndMin6.Items.Clear();
            EndMin7.Items.Clear();

            chkStartMin.Items.Add("Min");
            chkStartMin1.Items.Add("Min");
            chkStartMin2.Items.Add("Min");
            chkStartMin3.Items.Add("Min");
            chkStartMin4.Items.Add("Min");
            chkStartMin5.Items.Add("Min");
            chkStartMin6.Items.Add("Min");
            chkStartMin7.Items.Add("Min");

            EndMin.Items.Add("Min");
            EndMin1.Items.Add("Min");
            EndMin2.Items.Add("Min");
            EndMin3.Items.Add("Min");
            EndMin4.Items.Add("Min");
            EndMin5.Items.Add("Min");
            EndMin6.Items.Add("Min");
            EndMin7.Items.Add("Min");

            int i;
            for (i = 0; i <= 59; i = i + 5)
            {
                if (i < 10)
                {
                    chkStartMin.Items.Add(n + i.ToString());
                    chkStartMin1.Items.Add(n + i.ToString());
                    chkStartMin2.Items.Add(n + i.ToString());
                    chkStartMin3.Items.Add(n + i.ToString());
                    chkStartMin4.Items.Add(n + i.ToString());
                    chkStartMin5.Items.Add(n + i.ToString());
                    chkStartMin6.Items.Add(n + i.ToString());
                    chkStartMin7.Items.Add(n + i.ToString());

                    EndMin.Items.Add(n + i.ToString());
                    EndMin1.Items.Add(n + i.ToString());
                    EndMin2.Items.Add(n + i.ToString());
                    EndMin3.Items.Add(n + i.ToString());
                    EndMin4.Items.Add(n + i.ToString());
                    EndMin5.Items.Add(n + i.ToString());
                    EndMin6.Items.Add(n + i.ToString());
                    EndMin7.Items.Add(n + i.ToString());
                }
                else
                {
                    chkStartMin.Items.Add(i);
                    chkStartMin1.Items.Add(i);
                    chkStartMin2.Items.Add(i);
                    chkStartMin3.Items.Add(i);
                    chkStartMin4.Items.Add(i);
                    chkStartMin5.Items.Add(i);
                    chkStartMin6.Items.Add(i);
                    chkStartMin7.Items.Add(i);

                    EndMin.Items.Add(i);
                    EndMin1.Items.Add(i);
                    EndMin2.Items.Add(i);
                    EndMin3.Items.Add(i);
                    EndMin4.Items.Add(i);
                    EndMin5.Items.Add(i);
                    EndMin6.Items.Add(i);
                    EndMin7.Items.Add(i);
                }
            }

            chkStartMin.SelectedIndex = 0;
            chkStartMin1.SelectedIndex = 0;
            chkStartMin2.SelectedIndex = 0;
            chkStartMin3.SelectedIndex = 0;
            chkStartMin4.SelectedIndex = 0;
            chkStartMin5.SelectedIndex = 0;
            chkStartMin6.SelectedIndex = 0;
            chkStartMin7.SelectedIndex = 0;

            EndMin.SelectedIndex = 0;
            EndMin1.SelectedIndex = 0;
            EndMin2.SelectedIndex = 0;
            EndMin3.SelectedIndex = 0;
            EndMin4.SelectedIndex = 0;
            EndMin5.SelectedIndex = 0;
            EndMin6.SelectedIndex = 0;
            EndMin7.SelectedIndex = 0;


        }

        #endregion

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (validate())
                {
                    SetParameters();
                    BindGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnSave_Copy_Click(object sender, RoutedEventArgs e)
        {

        }

        #region-------------------------------------------------------Setparameters()-------------------------------------------------------
        private void SetParameters()
        {
            int ResultCount = 0;

            if (chkMon.IsChecked == true)
            {
                BatchID = Convert.ToInt32(cmbBatch.SelectedValue);
                Day = chkMon.Content.ToString();
                FinalStartTime = chkStartHrs1.Text + ":";
                FinalStartTime += chkStartMin1.Text;
                FinalEndTime = chkEndhrs1.Text + ":";
                FinalEndTime += EndMin1.Text;
                Active = 1;
                IsDeleted = 0;
                UpdatedDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
                UpdatedByUserID = 1;
                string Result = objBatch.SaveTeacherAvailibility(BatchID, Day, FinalStartTime, FinalEndTime, UpdatedByUserID, UpdatedDate, Active, IsDeleted);
                if ((Result == "Save Sucessfully...!!!") || (Result == "Updated Sucessfully...!!!"))
                {
                    ResultCount++;
                }
            }
            else if (chkMon.IsChecked == false)
            {
                BatchID = Convert.ToInt32(cmbBatch.SelectedValue);
                Day = chkMon.Content.ToString();
                FinalStartTime = "00:00:00";
                FinalEndTime = "00:00:00";
                Active = 0;
                IsDeleted = 0;
                UpdatedDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
                UpdatedByUserID = 1;
                string Result = objBatch.SaveTeacherAvailibility(BatchID, Day, FinalStartTime, FinalEndTime, UpdatedByUserID, UpdatedDate, Active, IsDeleted);
                if ((Result == "Save Sucessfully...!!!") || (Result == "Updated Sucessfully...!!!"))
                {
                    ResultCount++;
                }

            }
            if (chkTue.IsChecked == true)
            {
                BatchID = Convert.ToInt32(cmbBatch.SelectedValue);
                Day = chkTue.Content.ToString();
                FinalStartTime = chkStartHrs2.Text + ":";
                FinalStartTime += chkStartMin2.Text;
                FinalEndTime = chkEndhrs2.Text + ":";
                FinalEndTime += EndMin2.Text;
                Active = 1;
                IsDeleted = 0;
                UpdatedDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
                UpdatedByUserID = 1;
                string Result = objBatch.SaveTeacherAvailibility(BatchID, Day, FinalStartTime, FinalEndTime, UpdatedByUserID, UpdatedDate, Active, IsDeleted);
                if ((Result == "Save Sucessfully...!!!") || (Result == "Updated Sucessfully...!!!"))
                {
                    ResultCount++;
                }
            }
            else if (chkTue.IsChecked == false)
            {
                BatchID = Convert.ToInt32(cmbBatch.SelectedValue);
                Day = chkTue.Content.ToString();
                FinalStartTime = "00:00:00";
                FinalEndTime = "00:00:00";
                Active = 0;
                IsDeleted = 0;
                UpdatedDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
                UpdatedByUserID = 1;
                string Result = objBatch.SaveTeacherAvailibility(BatchID, Day, FinalStartTime, FinalEndTime, UpdatedByUserID, UpdatedDate, Active, IsDeleted);
                if ((Result == "Save Sucessfully...!!!") || (Result == "Updated Sucessfully...!!!"))
                {
                    ResultCount++;
                }

            }
            if (chkWed.IsChecked == true)
            {
                TeacherID = Convert.ToInt32(cmbTeacher.SelectedValue);
                Day = chkWed.Content.ToString();
                FinalStartTime = chkStartHrs3.Text + ":";
                FinalStartTime += chkStartMin3.Text;
                FinalEndTime = chkEndhrs3.Text + ":";
                FinalEndTime += EndMin3.Text;
                Active = 1;
                IsDeleted = 0;
                UpdatedDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
                UpdatedByUserID = 1;
                string Result = objTeacher.SaveTeacherAvailibility(TeacherID, Day, FinalStartTime, FinalEndTime, UpdatedByUserID, UpdatedDate, Active, IsDeleted);

                if ((Result == "Save Sucessfully...!!!") || (Result == "Updated Sucessfully...!!!"))
                {
                    ResultCount++;
                }
            }
            else if (chkWed.IsChecked == false)
            {
                TeacherID = Convert.ToInt32(cmbTeacher.SelectedValue);
                Day = chkWed.Content.ToString();
                FinalStartTime = "00:00:00";
                FinalEndTime = "00:00:00";
                Active = 0;
                IsDeleted = 0;
                UpdatedDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
                UpdatedByUserID = 1;
                string Result = objTeacher.SaveTeacherAvailibility(TeacherID, Day, FinalStartTime, FinalEndTime, UpdatedByUserID, UpdatedDate, Active, IsDeleted);

                if ((Result == "Save Sucessfully...!!!") || (Result == "Updated Sucessfully...!!!"))
                {
                    ResultCount++;
                }

            }
            if (chkThru.IsChecked == true)
            {
                TeacherID = Convert.ToInt32(cmbTeacher.SelectedValue);
                Day = chkThru.Content.ToString();
                FinalStartTime = chkStartHrs4.Text + ":";
                FinalStartTime += chkStartMin4.Text;
                FinalEndTime = chkEndhrs4.Text + ":";
                FinalEndTime += EndMin4.Text;
                Active = 1;
                IsDeleted = 0;
                UpdatedDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
                UpdatedByUserID = 1;
                string Result = objTeacher.SaveTeacherAvailibility(TeacherID, Day, FinalStartTime, FinalEndTime, UpdatedByUserID, UpdatedDate, Active, IsDeleted);

                if ((Result == "Save Sucessfully...!!!") || (Result == "Updated Sucessfully...!!!"))
                {
                    ResultCount++;
                }
            }
            else if (chkThru.IsChecked == false)
            {
                TeacherID = Convert.ToInt32(cmbTeacher.SelectedValue);
                Day = chkThru.Content.ToString();
                FinalStartTime = "00:00:00";
                FinalEndTime = "00:00:00";
                Active = 0;
                IsDeleted = 0;
                UpdatedDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
                UpdatedByUserID = 1;
                string Result = objTeacher.SaveTeacherAvailibility(TeacherID, Day, FinalStartTime, FinalEndTime, UpdatedByUserID, UpdatedDate, Active, IsDeleted);

                if ((Result == "Save Sucessfully...!!!") || (Result == "Updated Sucessfully...!!!"))
                {
                    ResultCount++;
                }

            }
            if (chkFri.IsChecked == true)
            {
                TeacherID = Convert.ToInt32(cmbTeacher.SelectedValue);
                Day = chkFri.Content.ToString();
                FinalStartTime = chkStartHrs5.Text + ":";
                FinalStartTime += chkStartMin5.Text;
                FinalEndTime = chkEndhrs5.Text + ":";
                FinalEndTime += EndMin5.Text;
                Active = 1;
                IsDeleted = 0;
                UpdatedDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
                UpdatedByUserID = 1;
                string Result = objTeacher.SaveTeacherAvailibility(TeacherID, Day, FinalStartTime, FinalEndTime, UpdatedByUserID, UpdatedDate, Active, IsDeleted);

                if ((Result == "Save Sucessfully...!!!") || (Result == "Updated Sucessfully...!!!"))
                {
                    ResultCount++;
                }
            }
            else if (chkFri.IsChecked == false)
            {
                TeacherID = Convert.ToInt32(cmbTeacher.SelectedValue);
                Day = chkFri.Content.ToString();
                FinalStartTime = "00:00:00";
                FinalEndTime = "00:00:00";
                Active = 0;
                IsDeleted = 0;
                UpdatedDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
                UpdatedByUserID = 1;
                string Result = objTeacher.SaveTeacherAvailibility(TeacherID, Day, FinalStartTime, FinalEndTime, UpdatedByUserID, UpdatedDate, Active, IsDeleted);

                if ((Result == "Save Sucessfully...!!!") || (Result == "Updated Sucessfully...!!!"))
                {
                    ResultCount++;
                }

            }
            if (chkSat.IsChecked == true)
            {
                TeacherID = Convert.ToInt32(cmbTeacher.SelectedValue);
                Day = chkSat.Content.ToString();
                FinalStartTime = chkStartHrs6.Text + ":";
                FinalStartTime += chkStartMin6.Text;
                FinalEndTime = chkEndhrs6.Text + ":";
                FinalEndTime += EndMin6.Text;
                Active = 1;
                IsDeleted = 0;
                UpdatedDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
                UpdatedByUserID = 1;
                string Result = objTeacher.SaveTeacherAvailibility(TeacherID, Day, FinalStartTime, FinalEndTime, UpdatedByUserID, UpdatedDate, Active, IsDeleted);

                if ((Result == "Save Sucessfully...!!!") || (Result == "Updated Sucessfully...!!!"))
                {
                    ResultCount++;
                }
            }
            else if (chkSat.IsChecked == false)
            {
                TeacherID = Convert.ToInt32(cmbTeacher.SelectedValue);
                Day = chkSat.Content.ToString();
                FinalStartTime = "00:00:00";
                FinalEndTime = "00:00:00";
                Active = 0;
                IsDeleted = 0;
                UpdatedDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
                UpdatedByUserID = 1;
                string Result = objTeacher.SaveTeacherAvailibility(TeacherID, Day, FinalStartTime, FinalEndTime, UpdatedByUserID, UpdatedDate, Active, IsDeleted);

                if ((Result == "Save Sucessfully...!!!") || (Result == "Updated Sucessfully...!!!"))
                {
                    ResultCount++;
                }

            }
            if (chkSun.IsChecked == true)
            {
                TeacherID = Convert.ToInt32(cmbTeacher.SelectedValue);
                Day = chkSun.Content.ToString();
                FinalStartTime = chkStartHrs7.Text + ":";
                FinalStartTime += chkStartMin7.Text;
                FinalEndTime = chkEndhrs7.Text + ":";
                FinalEndTime += EndMin7.Text;
                Active = 1;
                IsDeleted = 0;
                UpdatedDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
                UpdatedByUserID = 1;
                string Result = objTeacher.SaveTeacherAvailibility(TeacherID, Day, FinalStartTime, FinalEndTime, UpdatedByUserID, UpdatedDate, Active, IsDeleted);

                if ((Result == "Save Sucessfully...!!!") || (Result == "Updated Sucessfully...!!!"))
                {
                    ResultCount++;
                }
            }
            else if (chkSun.IsChecked == false)
            {
                TeacherID = Convert.ToInt32(cmbTeacher.SelectedValue);
                Day = chkSun.Content.ToString();
                FinalStartTime = "00:00:00";
                FinalEndTime = "00:00:00";
                Active = 0;
                IsDeleted = 0;
                UpdatedDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
                UpdatedByUserID = 1;
                string Result = objTeacher.SaveTeacherAvailibility(TeacherID, Day, FinalStartTime, FinalEndTime, UpdatedByUserID, UpdatedDate, Active, IsDeleted);
                if ((Result == "Save Sucessfully...!!!") || (Result == "Updated Sucessfully...!!!"))
                {
                    ResultCount++;
                }
            }
            if (ResultCount == 7)
            {
                MessageBox.Show("Teacher Details Save Sucessfully", "Save Sucessfull", MessageBoxButton.OK, MessageBoxImage.Information);
                ClearFields();
            }

        }
        #endregion

        #region--------------------------------------------------------validate()---------------------------------------------------------------
        private bool validate()
        {

            if (MondayValidate())
            {
                if (TuesdayValidate())
                {
                    if (WednesdayValidate())
                    {
                        if (ThrusdayValidate())
                        {
                            if (FridayValidate())
                            {
                                if (SaturdayValidate())
                                {
                                    if (SundayValidate())
                                    {
                                        if (daycheckcount > 0)
                                        { return true; }
                                        else
                                        {
                                            MessageBox.Show("Select At Least One Day.");

                                            return false;
                                        }
                                    }

                                    else
                                    { return false; }
                                }
                                else
                                { return false; }
                            }
                            else
                            { return false; }
                        }
                        else
                        { return false; }
                    }
                    else
                    { return false; }
                }
                else
                { return false; }
            }
            else
            {
                return false;

            }

        }
        #endregion

        #region-------------------------------------------------------Monday Validate()---------------------------------------------------------
        private bool MondayValidate()
        {
            if (chkMon.IsChecked == true)
            {
                if (chkStartHrs1.SelectedItem.ToString() == "HRS")
                {
                    MessageBox.Show("Please Select Start Hours From Monday", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    chkStartHrs1.Focus();
                    return false;
                }
                else if (chkStartMin1.SelectedItem.ToString() == "Min")
                {
                    MessageBox.Show("Please Select Minutes From Monday", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    chkStartMin1.Focus();
                    return false;

                }
                else if (chkEndhrs1.SelectedItem.ToString() == "HRS")
                {
                    MessageBox.Show("Please Select End Hours From Monday", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    chkEndhrs1.Focus();
                    return false;
                }
                else if (EndMin1.SelectedItem.ToString() == "Min")
                {
                    MessageBox.Show("Please Select End Minutes From Monday", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    EndMin1.Focus();
                    return false;
                }
                else if (Convert.ToInt32(chkStartHrs1.SelectedItem.ToString()) > Convert.ToInt32(chkEndhrs1.SelectedItem.ToString()))
                {
                    MessageBox.Show("End Hour Time Is Must Be Greater Than End Time", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    chkEndhrs1.Focus();
                    return false;
                }
                else if ((Convert.ToInt32(chkStartHrs1.SelectedItem.ToString()) == Convert.ToInt32(chkEndhrs1.SelectedItem.ToString())) && (Convert.ToInt32(chkStartMin1.SelectedItem.ToString()) >= Convert.ToInt32(EndMin1.SelectedItem.ToString())))
                {
                    MessageBox.Show("End Minute Time Is Must Be Greater Than End Time", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    chkStartHrs1.Focus();
                    return false;

                }
                else
                { return true; }



            }
            else
            { return true; }
        }
        #endregion

        #region------------------------------------------------------Tuesday Validate()---------------------------------------------------------
        private bool TuesdayValidate()
        {
            if (chkTue.IsChecked == true)
            {
                if (chkStartHrs2.SelectedItem.ToString() == "HRS")
                {
                    MessageBox.Show("Please Select Start Hours From Tuesday", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    chkStartHrs2.Focus();
                    return false;
                }
                else if (chkStartMin2.SelectedItem.ToString() == "Min")
                {
                    MessageBox.Show("Please Select Minutes From Tuesday", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    chkStartMin2.Focus();
                    return false;

                }
                else if (chkEndhrs2.SelectedItem.ToString() == "HRS")
                {
                    MessageBox.Show("Please Select End Hours From Tuesday", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    chkEndhrs2.Focus();
                    return false;
                }
                else if (EndMin2.SelectedItem.ToString() == "Min")
                {
                    MessageBox.Show("Please Select End Minutes From Tuesday", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    EndMin2.Focus();
                    return false;
                }
                else if (Convert.ToInt32(chkStartHrs2.SelectedItem.ToString()) > Convert.ToInt32(chkEndhrs2.SelectedItem.ToString()))
                {
                    MessageBox.Show("End Hour Time Is Must Be Greater Than End Time", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    chkStartHrs2.Focus();
                    return false;
                }
                else if ((Convert.ToInt32(chkStartHrs2.SelectedItem.ToString()) == Convert.ToInt32(chkEndhrs2.SelectedItem.ToString())) && (Convert.ToInt32(chkStartMin2.SelectedItem.ToString()) >= Convert.ToInt32(EndMin2.SelectedItem.ToString())))
                {
                    MessageBox.Show("End Minute Time Is Must Be Greater Than End Time", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    EndMin2.Focus();
                    return false;

                }
                else
                { return true; }
            }


            else
            { return true; }

        }
        #endregion

        #region------------------------------------------------------Wednsday Validate()--------------------------------------------------------
        private bool WednesdayValidate()
        {
            if (chkWed.IsChecked == true)
            {
                if (chkStartHrs3.SelectedItem.ToString() == "HRS")
                {
                    MessageBox.Show("Please Select Start Hours From Wednesday", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    chkStartHrs3.Focus();
                    return false;
                }
                else if (chkStartMin3.SelectedItem.ToString() == "Min")
                {
                    MessageBox.Show("Please Select Minutes From Wednesday", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    chkStartMin3.Focus();
                    return false;

                }
                else if (chkEndhrs3.SelectedItem.ToString() == "HRS")
                {
                    MessageBox.Show("Please Select End Hours From Wednesday", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    chkEndhrs3.Focus();
                    return false;
                }
                else if (EndMin3.SelectedItem.ToString() == "Min")
                {
                    MessageBox.Show("Please Select End Minutes From Wednesday", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    EndMin3.Focus();
                    return false;
                }
                else if (Convert.ToInt32(chkStartHrs3.SelectedItem.ToString()) > Convert.ToInt32(chkEndhrs3.SelectedItem.ToString()))
                {
                    MessageBox.Show("End Hour Time Is Must Be Greater Than End Time", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    chkStartHrs3.Focus();
                    return false;
                }
                else if ((Convert.ToInt32(chkStartHrs3.SelectedItem.ToString()) == Convert.ToInt32(chkEndhrs3.SelectedItem.ToString())) && (Convert.ToInt32(chkStartMin3.SelectedItem.ToString()) >= Convert.ToInt32(EndMin3.SelectedItem.ToString())))
                {
                    MessageBox.Show("End Minute Time Is Must Be Greater Than End Time", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    EndMin3.Focus();
                    return false;

                }
                else
                { return true; }
            }


            else
            { return true; }

        }
        #endregion

        #region------------------------------------------------------Thrusday Validate()--------------------------------------------------------
        private bool ThrusdayValidate()
        {
            if (chkThru.IsChecked == true)
            {
                if (chkStartHrs4.SelectedItem.ToString() == "HRS")
                {
                    MessageBox.Show("Please Select Start Hours From Thrusday", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    chkStartHrs4.Focus();
                    return false;
                }
                else if (chkStartMin4.SelectedItem.ToString() == "Min")
                {
                    MessageBox.Show("Please Select Minutes From Thrusday", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    chkStartMin4.Focus();
                    return false;

                }
                else if (chkEndhrs4.SelectedItem.ToString() == "HRS")
                {
                    MessageBox.Show("Please Select End Hours From Thrusday", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    chkEndhrs4.Focus();
                    return false;
                }
                else if (EndMin4.SelectedItem.ToString() == "Min")
                {
                    MessageBox.Show("Please Select End Minutes From Thrusday", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    EndMin4.Focus();
                    return false;
                }
                else if (Convert.ToInt32(chkStartHrs4.SelectedItem.ToString()) > Convert.ToInt32(chkEndhrs4.SelectedItem.ToString()))
                {
                    MessageBox.Show("End Hour Time Is Must Be Greater Than End Time", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    chkEndhrs4.Focus();
                    return false;
                }
                else if ((Convert.ToInt32(chkStartHrs4.SelectedItem.ToString()) == Convert.ToInt32(chkEndhrs4.SelectedItem.ToString())) && (Convert.ToInt32(chkStartMin4.SelectedItem.ToString()) >= Convert.ToInt32(EndMin4.SelectedItem.ToString())))
                {
                    MessageBox.Show("End Minute Time Is Must Be Greater Than End Time", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    EndMin4.Focus();
                    return false;

                }
                else
                { return true; }
            }


            else
            { return true; }

        }
        #endregion

        #region-------------------------------------------------------Friday Validate()---------------------------------------------------------
        private bool FridayValidate()
        {
            if (chkFri.IsChecked == true)
            {
                if (chkStartHrs5.SelectedItem.ToString() == "HRS")
                {
                    MessageBox.Show("Please Select Start Hours From Friday", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    chkStartHrs5.Focus();
                    return false;
                }
                else if (chkStartMin5.SelectedItem.ToString() == "Min")
                {
                    MessageBox.Show("Please Select Minutes From Friday", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    chkStartMin5.Focus();
                    return false;

                }
                else if (chkEndhrs5.SelectedItem.ToString() == "HRS")
                {
                    MessageBox.Show("Please Select End Hours From Friday", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    chkEndhrs5.Focus();
                    return false;
                }
                else if (EndMin5.SelectedItem.ToString() == "Min")
                {
                    MessageBox.Show("Please Select End Minutes From Friday", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    EndMin5.Focus();
                    return false;
                }
                else if (Convert.ToInt32(chkStartHrs5.SelectedItem.ToString()) > Convert.ToInt32(chkEndhrs5.SelectedItem.ToString()))
                {
                    MessageBox.Show("End Hour Time Is Must Be Greater Than End Time", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    chkEndhrs5.Focus();
                    return false;
                }
                else if ((Convert.ToInt32(chkStartHrs5.SelectedItem.ToString()) == Convert.ToInt32(chkEndhrs5.SelectedItem.ToString())) && (Convert.ToInt32(chkStartMin5.SelectedItem.ToString()) >= Convert.ToInt32(EndMin5.SelectedItem.ToString())))
                {
                    MessageBox.Show("End Minute Time Is Must Be Greater Than End Time", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    EndMin5.Focus();
                    return false;

                }
                else
                { return true; }
            }


            else
            { return true; }

        }
        #endregion

        #region------------------------------------------------------Saturday Validate()--------------------------------------------------------
        private bool SaturdayValidate()
        {
            if (chkSat.IsChecked == true)
            {
                if (chkStartHrs6.SelectedItem.ToString() == "HRS")
                {
                    MessageBox.Show("Please Select Start Hours From Friday", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    chkStartHrs6.Focus();
                    return false;
                }
                else if (chkStartMin6.SelectedItem.ToString() == "Min")
                {
                    MessageBox.Show("Please Select Minutes From Friday", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    chkStartMin6.Focus();
                    return false;

                }
                else if (chkEndhrs6.SelectedItem.ToString() == "HRS")
                {
                    MessageBox.Show("Please Select End Hours From Friday", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    chkEndhrs6.Focus();
                    return false;
                }
                else if (EndMin6.SelectedItem.ToString() == "Min")
                {
                    MessageBox.Show("Please Select End Minutes From Friday", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    EndMin6.Focus();
                    return false;
                }
                else if (Convert.ToInt32(chkStartHrs6.SelectedItem.ToString()) > Convert.ToInt32(chkEndhrs6.SelectedItem.ToString()))
                {
                    MessageBox.Show("End Hour Time Is Must Be Greater Than End Time", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    chkEndhrs6.Focus();
                    return false;
                }
                else if ((Convert.ToInt32(chkStartHrs6.SelectedItem.ToString()) == Convert.ToInt32(chkEndhrs6.SelectedItem.ToString())) && (Convert.ToInt32(chkStartMin6.SelectedItem.ToString()) >= Convert.ToInt32(EndMin6.SelectedItem.ToString())))
                {
                    MessageBox.Show("End Minute Time Is Must Be Greater Than End Time", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    EndMin6.Focus();
                    return false;

                }
                else
                { return true; }
            }


            else
            { return true; }

        }
        #endregion

        #region-------------------------------------------------------Sunday Validate()---------------------------------------------------------
        private bool SundayValidate()
        {
            if (chkSun.IsChecked == true)
            {
                if (chkStartHrs7.SelectedItem.ToString() == "HRS")
                {
                    MessageBox.Show("Please Select Start Hours From Sunday", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    chkStartHrs7.Focus();
                    return false;
                }
                else if (chkStartMin7.SelectedItem.ToString() == "Min")
                {
                    MessageBox.Show("Please Select Minutes From Sunday", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    chkStartMin7.Focus();
                    return false;

                }
                else if (chkEndhrs7.SelectedItem.ToString() == "HRS")
                {
                    MessageBox.Show("Please Select End Hours From Sunday", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    chkEndhrs7.Focus();
                    return false;
                }
                else if (EndMin7.SelectedItem.ToString() == "Min")
                {
                    MessageBox.Show("Please Select End Minutes From Sunday", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    EndMin7.Focus();
                    return false;
                }
                else if (Convert.ToInt32(chkStartHrs7.SelectedItem.ToString()) > Convert.ToInt32(chkEndhrs7.SelectedItem.ToString()))
                {
                    MessageBox.Show("End Hour Time Is Must Be Greater Than End Time", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    chkEndhrs7.Focus();
                    return false;
                }
                else if ((Convert.ToInt32(chkStartHrs7.SelectedItem.ToString()) == Convert.ToInt32(chkEndhrs7.SelectedItem.ToString())) && (Convert.ToInt32(chkStartMin7.SelectedItem.ToString()) >= Convert.ToInt32(EndMin7.SelectedItem.ToString())))
                {
                    MessageBox.Show("End Minute Time Is Must Be Greater Than End Time", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    EndMin7.Focus();
                    return false;

                }
                else
                { return true; }
            }


            else
            { return true; }

        }
        #endregion

        #region----------------------chkAvailAllDay_Click------------------
        private void chkAvailAllDay_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (chkAvailAllDay.IsChecked == true)
                {
                    CheckAllDays();
                }
                else
                {
                    UnchekAllDays();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion

        #region---------------------------------------------------------CheckAllDays()-----------------------------------------------------------
        private void CheckAllDays()
        {
            chkMon.IsChecked = true;
            chkTue.IsChecked = true;
            chkWed.IsChecked = true;
            chkThru.IsChecked = true;
            chkFri.IsChecked = true;
            chkSat.IsChecked = true;
            chkSun.IsChecked = true;
            daycheckcount = 7;
        }
        #endregion

        #region-------------------------------------------------------UncheckAllDays()------------------------------------------------------------
        private void UnchekAllDays()
        {
            chkMon.IsChecked = false;
            chkTue.IsChecked = false;
            chkWed.IsChecked = false;
            chkThru.IsChecked = false;
            chkFri.IsChecked = false;
            chkSat.IsChecked = false;
            chkSun.IsChecked = false;
            daycheckcount = 0;
        }
        #endregion

        #region-------------------------------------------chkAvailableSameTime()---------------------------------------------------------
        private void chkAvailSameTime_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (chkAvailSameTime.IsChecked == true)
                {
                    DisableDropdown();
                }
                else
                {
                    EnableDropdown();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion

        #region--------------------------chkMon_Click------------------------------------------------
        private void chkMon_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (chkMon.IsChecked == true)
                {
                    ++daycheckcount;
                }
                else if (chkMon.IsChecked == false)
                {
                    --daycheckcount;
                }
                if (daycheckcount == 7)
                {
                    chkAvailAllDay.IsChecked = true;
                }
                else
                {
                    chkAvailAllDay.IsChecked = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion

        #region---------------------chkTue_Click-----------------------------
        private void chkTue_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (chkTue.IsChecked == true)
                {
                    ++daycheckcount;
                }
                else if (chkTue.IsChecked == false)
                {
                    --daycheckcount;
                }
                if (daycheckcount == 7)
                {
                    chkAvailAllDay.IsChecked = true;
                }
                else
                {
                    chkAvailAllDay.IsChecked = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion

        #region---------------------chkWed_Click------------------
        private void chkWed_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (chkWed.IsChecked == true)
                {
                    ++daycheckcount;
                }
                else if (chkWed.IsChecked == false)
                {
                    --daycheckcount;
                }
                if (daycheckcount == 7)
                {
                    chkAvailAllDay.IsChecked = true;
                }
                else
                {
                    chkAvailAllDay.IsChecked = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion

        #region-----------------chkThru_Click--------------------
        private void chkThru_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (chkThru.IsChecked == true)
                {
                    ++daycheckcount;
                }
                else if (chkThru.IsChecked == false)
                {
                    --daycheckcount;
                }
                if (daycheckcount == 7)
                {
                    chkAvailAllDay.IsChecked = true;
                }
                else
                {
                    chkAvailAllDay.IsChecked = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion

        #region------------------chkFri_Click----------------------------
        private void chkFri_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (chkFri.IsChecked == true)
                {
                    ++daycheckcount;
                }
                else if (chkFri.IsChecked == false)
                {
                    --daycheckcount;
                }
                if (daycheckcount == 7)
                {
                    chkAvailAllDay.IsChecked = true;
                }
                else
                {
                    chkAvailAllDay.IsChecked = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion

        #region---------------chkSat_Click-----------------------
        private void chkSat_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (chkSat.IsChecked == true)
                {
                    ++daycheckcount;
                }
                else if (chkSat.IsChecked == false)
                {
                    --daycheckcount;
                }
                if (daycheckcount == 7)
                {
                    chkAvailAllDay.IsChecked = true;
                }
                else
                {
                    chkAvailAllDay.IsChecked = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion

        #region------------chkSun_Click----------------------
        private void chkSun_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (chkSun.IsChecked == true)
                {
                    ++daycheckcount;
                }
                else if (chkSun.IsChecked == false)
                {
                    --daycheckcount;
                }
                if (daycheckcount == 7)
                {
                    chkAvailAllDay.IsChecked = true;
                }
                else
                {
                    chkAvailAllDay.IsChecked = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion

        #region-----------------chkStartHrs_SelectionChanged-------------------------
        private void chkStartHrs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {


                if (chkAvailSameTime.IsChecked == true && chkStartHrs.SelectedItem != null)
                {
                    chkStartHrs1.Text = chkStartHrs.SelectedItem.ToString();
                    chkStartHrs2.Text = chkStartHrs.SelectedItem.ToString();
                    chkStartHrs3.Text = chkStartHrs.SelectedItem.ToString();
                    chkStartHrs4.Text = chkStartHrs.SelectedItem.ToString();
                    chkStartHrs5.Text = chkStartHrs.SelectedItem.ToString();
                    chkStartHrs6.Text = chkStartHrs.SelectedItem.ToString();
                    chkStartHrs7.Text = chkStartHrs.SelectedItem.ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }
        }
        #endregion

        #region------------------chkStartMin_SelectionChanged--------------------
        private void chkStartMin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (chkAvailSameTime.IsChecked == true && chkStartMin.SelectedItem != null)
                {
                    chkStartMin1.Text = chkStartMin.SelectedItem.ToString();
                    chkStartMin2.Text = chkStartMin.SelectedItem.ToString();
                    chkStartMin3.Text = chkStartMin.SelectedItem.ToString();
                    chkStartMin4.Text = chkStartMin.SelectedItem.ToString();
                    chkStartMin5.Text = chkStartMin.SelectedItem.ToString();
                    chkStartMin6.Text = chkStartMin.SelectedItem.ToString();
                    chkStartMin7.Text = chkStartMin.SelectedItem.ToString();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());

            }
        }
        #endregion

        #region------------------chkEndhrs_SelectionChanged-----------------
        private void chkEndhrs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (chkAvailSameTime.IsChecked == true && chkEndhrs.SelectedItem != null)
                {
                    chkEndhrs1.Text = chkEndhrs.SelectedItem.ToString();
                    chkEndhrs2.Text = chkEndhrs.SelectedItem.ToString();
                    chkEndhrs3.Text = chkEndhrs.SelectedItem.ToString();
                    chkEndhrs4.Text = chkEndhrs.SelectedItem.ToString();
                    chkEndhrs5.Text = chkEndhrs.SelectedItem.ToString();
                    chkEndhrs6.Text = chkEndhrs.SelectedItem.ToString();
                    chkEndhrs7.Text = chkEndhrs.SelectedItem.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion

        #region--------------EndMin_SelectionChanged--------------
        private void EndMin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (chkAvailSameTime.IsChecked == true && EndMin.SelectedItem != null)
                {
                    EndMin1.Text = EndMin.SelectedItem.ToString();
                    EndMin2.Text = EndMin.SelectedItem.ToString();
                    EndMin3.Text = EndMin.SelectedItem.ToString();
                    EndMin4.Text = EndMin.SelectedItem.ToString();
                    EndMin5.Text = EndMin.SelectedItem.ToString();
                    EndMin6.Text = EndMin.SelectedItem.ToString();
                    EndMin7.Text = EndMin.SelectedItem.ToString();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }
        }
        #endregion

        #region---------------------------------------------------------Clears()-------------------------------------------------------
        private void Clears()
        {

            BindHours();
            BindMinutes();
            BindGrid();
            UncheckAllCheckBoxes();
            gbSameTime.Visibility = Visibility.Hidden;
            EnableDropdown();

        }
        #endregion

        #region---------------------------------------------------------------BindGrid()-------------------------------------------------------
        private void BindGrid()
        {
            DataSet ds = objBatch.BindBatchAvail();

            if (ds.Tables[0].Rows.Count > 0)
            {
                dgBatchAvail.DataContext = null;
                dgBatchAvail.DataContext = ds.Tables[0].DefaultView;
            }

        }
        #endregion

        #region--------------------------------unchekcall ChekcBoxes-----------------------------------
        private void UncheckAllCheckBoxes()
        {
            chkAvailAllDay.IsChecked = false;
            chkAvailSameTime.IsChecked = false;

            chkMon.IsChecked = false;
            chkTue.IsChecked = false;
            chkWed.IsChecked = false;
            chkThru.IsChecked = false;
            chkFri.IsChecked = false;
            chkSat.IsChecked = false;
            chkSun.IsChecked = false;
        }
        #endregion

          #region---------------------------------------------------------GetTeacherAvailableDetails()-------------------------------------------
        private void GetBatchAvailableDetails(int numId)
        {
        }
          #endregion

        #region-----------------------------------------------ClearFields()-----------------------------------------------------------
        private void ClearFields()
        {
            //cmbTeacher.IsEnabled = true;
            //BindBatchName();
            //BindBatch();
            //BindHours();
            //BindMinutes();
            //BindGrid();
            //UncheckAllCheckBoxes();
            //EnableDropdown();
        }
        #region-----------bindBatch()-----------------
        private void BindBatch()
        {
            BranchID =Convert.ToInt32(cmbBranch.SelectedValue.ToString());
            DataSet ds = objBatch.BindBranchBatch(BranchID);

            if (ds.Tables[0].Rows.Count > 0)
            {
                cmbBatch.DataContext = null;

                cmbBatch.DataContext = ds.Tables[0].DefaultView;
                cmbBatch.DisplayMemberPath = ds.Tables[0].Columns["BatchName"].ToString();
                cmbBatch.SelectedValuePath = ds.Tables[0].Columns["BatchID"].ToString();


                cmbBatch.SelectedValue = "0";
            }
        }
        #region
        //#region------------------BindBatchName()----------------------------
        //private void BindBatchName()
        //{
        //    DataSet ds = objClass.BindBatchDropDown();

        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        cmbBranch.DataContext = null;

        //        cmbBranch.DataContext = ds.Tables[0].DefaultView;
        //        cmbBranch.DisplayMemberPath = ds.Tables[0].Columns["BatchName"].ToString();
        //        cmbBranch.SelectedValuePath = ds.Tables[0].Columns["BatchID"].ToString();


        //        cmbBranch.SelectedValue = "0";
        //    }
        //}
        //#endregion
        #endregion
        #endregion

        #region----------------------------------------------------------------DisebleDropdown()-----------------------------------------------
        private void DisableDropdown()
        {
            gbSameTime.Visibility = Visibility.Visible;
            chkStartHrs1.IsEnabled = false;
            chkStartHrs2.IsEnabled = false;
            chkStartHrs3.IsEnabled = false;
            chkStartHrs4.IsEnabled = false;
            chkStartHrs5.IsEnabled = false;
            chkStartHrs6.IsEnabled = false;
            chkStartHrs7.IsEnabled = false;

            chkEndhrs1.IsEnabled = false;
            chkEndhrs2.IsEnabled = false;
            chkEndhrs3.IsEnabled = false;
            chkEndhrs4.IsEnabled = false;
            chkEndhrs5.IsEnabled = false;
            chkEndhrs6.IsEnabled = false;
            chkEndhrs7.IsEnabled = false;
            chkEndhrs1.IsEnabled = false;
            chkEndhrs1.IsEnabled = false;

            chkStartMin1.IsEnabled = false;
            chkStartMin2.IsEnabled = false;
            chkStartMin3.IsEnabled = false;
            chkStartMin4.IsEnabled = false;
            chkStartMin5.IsEnabled = false;
            chkStartMin6.IsEnabled = false;
            chkStartMin7.IsEnabled = false;

            EndMin1.IsEnabled = false;
            EndMin2.IsEnabled = false;
            EndMin3.IsEnabled = false;
            EndMin4.IsEnabled = false;
            EndMin5.IsEnabled = false;
            EndMin6.IsEnabled = false;
            EndMin7.IsEnabled = false;

        }
        #endregion

        #region----------------------------------------------------------------EnableDropdown()------------------------------------------------
        private void EnableDropdown()
        {
            gbSameTime.Visibility = Visibility.Hidden;

            chkStartHrs1.IsEnabled = true;
            chkStartHrs2.IsEnabled = true;
            chkStartHrs3.IsEnabled = true;
            chkStartHrs4.IsEnabled = true;
            chkStartHrs5.IsEnabled = true;
            chkStartHrs6.IsEnabled = true;
            chkStartHrs7.IsEnabled = true;

            chkEndhrs1.IsEnabled = true;
            chkEndhrs2.IsEnabled = true;
            chkEndhrs3.IsEnabled = true;
            chkEndhrs4.IsEnabled = true;
            chkEndhrs5.IsEnabled = true;
            chkEndhrs6.IsEnabled = true;
            chkEndhrs7.IsEnabled = true;
            chkEndhrs1.IsEnabled = true;
            chkEndhrs1.IsEnabled = true;

            chkStartMin1.IsEnabled = true;
            chkStartMin2.IsEnabled = true;
            chkStartMin3.IsEnabled = true;
            chkStartMin4.IsEnabled = true;
            chkStartMin5.IsEnabled = true;
            chkStartMin6.IsEnabled = true;
            chkStartMin7.IsEnabled = true;

            EndMin1.IsEnabled = true;
            EndMin2.IsEnabled = true;
            EndMin3.IsEnabled = true;
            EndMin4.IsEnabled = true;
            EndMin5.IsEnabled = true;
            EndMin6.IsEnabled = true;
            EndMin7.IsEnabled = true;
        }
        #endregion

        private void cmbBranch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BindBatch();
        }
    }
}
        #endregion
