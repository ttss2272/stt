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
using System.IO;
using Microsoft.Win32;

namespace SchoolManagement.Branch
{
    /// <summary>
    /// Interaction logic for NewBranch.xaml
    /// </summary>
    public partial class NewBranch : Window
    {
        public NewBranch()
        {
            InitializeComponent();
        }
        /*
      * Created By:- Sameer Shinde
      * Ctreated Date :- 5 Nov 2015
      * Purpose:- Declare Global Variables
      */
        #region-----------------Declare Variables GlobalVariables()----------------
        BLAddBranch obj_AddBranch = new BLAddBranch();
        int BranchID, CreatedByUserID, UpdatedByUserID, IsActive,IsDelete,UpID;
        string BranchName, BranchCode, InstituteName, Logo, UpdatedDate, strName, imageName, targetPath;
        #endregion
        /*
       * Created By:- Sameer Shinde
       * Ctreated Date :- 5 Nov 2015
       * Purpose:- Save click Code
       */
        #region------------BtnSaveClick-------------------------------
        private void btnSave_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Validate())
                {
                    Validate();
                    SetParameters();
                    SaveDetails();
                    BindGridview();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion
        /*
       * Created By:- Sameer Shinde
       * Ctreated Date :- 5 Nov 2015
       * Purpose:- Save Detail Function
       */
        #region-----------------SaveDetails()-----------------
        private void SaveDetails()
        {
            string Result = obj_AddBranch.SaveBranch(BranchID, BranchName, BranchCode, InstituteName, Logo, CreatedByUserID, UpdatedByUserID, UpdatedDate, IsActive,IsDelete);
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
       * Created By:- Sameer Shinde
       * Ctreated Date :- 5 Nov 2015
       * Purpose:- Clear All fields
       */
        #region-----------ClearFields()-----------------
        private void ClearFields()
        {
            UpID = 0;
            txtBranchName.Text = "";
            txtBranchCode.Text = "";
            txtInstituteName.Text = "";
            txtUploadPath.Text = "";
            image1.Source = null;
            cmbBindInstitute.Text = "";
            rbtnInactive.IsEnabled = false;
            rbtnActive.IsEnabled = true;
        }
        #endregion
        /*
       * Created By:- Sameer Shinde
       * Ctreated Date :- 5 Nov 2015
       * Purpose:- Set Paramaters for save
       */
        #region---------------SetParameters()-----------------
        private void SetParameters()
        {
            BranchID = UpID;
            BranchName = txtBranchName.Text.Trim();
            BranchCode = txtBranchCode.Text.Trim();
           
                if (cmbSelectType.SelectedValue.ToString() == "System.Windows.Controls.ComboBoxItem: Branch")
                {
                    InstituteName = cmbBindInstitute.SelectedValue.ToString();
                }
                else
                {
                    InstituteName = txtInstituteName.Text.Trim();
                }
            
            Logo = txtUploadPath.Text.Trim();
            CreatedByUserID = 1;
            UpdatedByUserID = 1;
            UpdatedDate = DateTime.Now.ToString();
            if (rbtnActive.IsChecked == true)
            {
                IsActive = 1;
                IsDelete = 0;
            }
            else
                IsActive = 0;
            IsDelete = 0;
        }
        #endregion
        /*
       * Created By:- Sameer Shinde
       * Ctreated Date :- 5 Nov 2015
       * Purpose:- Validation for fields
       */
        #region------------------Validate()-----------------
        private bool Validate()
        {
            if ((txtInstituteName.Text.Trim() == "") && (cmbBindInstitute.Text==""))
            {
                MessageBox.Show("Please Enter Institute Name.", "Institute Name Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                if (txtInstituteName.IsVisible == true)
                {
                    txtInstituteName.Focus();
                }
                else
                {
                    cmbBindInstitute.Focus();
                }
                return false;
            }
            if (txtBranchName.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Branch Name.", "Branch Name Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtBranchName.Focus();
                return false;
            }
            else if (txtBranchCode.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Branch Code.", "Branch Code Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtBranchCode.Focus();
                return false;
            }
           
            else if (txtUploadPath.Text.Trim() == "")
            {
                MessageBox.Show("Please Select Institute logo.", "Institute Logo Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                btnBrowse.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion
        /*
       * Created By:- Sameer Shinde
       * Ctreated Date :- 5 Nov 2015
       * Purpose:- Delete Record
       */
        #region------------------DeleteClick()---------------------------
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Do You Want to delete?", "Delete", MessageBoxButton.YesNoCancel);
                if (result.Equals(MessageBoxResult.Yes))
                {
                    SetParameters();
                    DeleteBranch();
                    BindGridview();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion
        /*
       * Created By:- Sameer Shinde
       * Ctreated Date :- 5 Nov 2015
       * Purpose:- Delete Function Call
       */
        #region--------------------DeleteBranch()---------------------
        private void DeleteBranch()
        {
            if (UpID != 0)
            {
                BranchID = UpID;

                string Result = obj_AddBranch.DeleteBranch(BranchID,UpdatedByUserID,UpdatedDate);
                if (Result == "Branch Deleted Sucessfully!!!")
                {
                    MessageBox.Show(Result, "Branch Delete Sucessfully", MessageBoxButton.OK, MessageBoxImage.Information);
                    ClearFields();
                }
                else
                {
                    MessageBox.Show(Result, "Error To Delete", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please Select Branch Name ", "Delete Error", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
        }
        #endregion
        /*
       * Created By:- Sameer Shinde
       * Ctreated Date :- 5 Nov 2015
       * Purpose:- Display data on grid view
       */
        #region------------------BindGridview()-------------------
        private void BindGridview()
        {
            DataSet ds = obj_AddBranch.BindBranch(0,txtBranchName.Text,txtBranchCode.Text);
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdvBranch.ItemsSource = ds.Tables[0].DefaultView;
            }
        }
        #endregion
        /*
       * Created By:- Sameer Shinde
       * Ctreated Date :- 5 Nov 2015
       * Purpose:- Browse Image
       */
        #region-------------------BtnBrowseClick()-------------------------
        private void btnBrowse_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                FileDialog fldlg = new OpenFileDialog();
                fldlg.InitialDirectory = Environment.SpecialFolder.MyPictures.ToString();
                fldlg.Filter = "Image File (*.jpg;*.bmp;*.gif)|*.jpg;*.bmp;*.gif";
                fldlg.ShowDialog();
                {
                    strName = fldlg.SafeFileName;
                    imageName = fldlg.FileName;
                    ImageSourceConverter isc = new ImageSourceConverter();
                    image1.SetValue(Image.SourceProperty, isc.ConvertFromString(imageName));
                    txtUploadPath.Text = strName;

                    string fileName = "ImgLogo";
                    
                    string sourcePath = imageName;
                    
                   string targetPath = @"C:\Users\TTS\Desktop\ImgLogo\";
                   
                    string sourceFile = System.IO.Path.Combine(sourcePath);
                    string destFile = System.IO.Path.Combine(targetPath,fileName);
                    if (!System.IO.Directory.Exists(targetPath))
                    {
                        System.IO.Directory.CreateDirectory(targetPath);
                    }
                    System.IO.File.Copy(sourceFile, destFile, true);
                    if (System.IO.Directory.Exists(sourcePath))
                    {
                        string[] files = System.IO.Directory.GetFiles(sourcePath);

                        // Copy the files and overwrite destination files if they already exist.
                        foreach (string s in files)
                        {
                            // Use static Path methods to extract only the file name from the path.
                            fileName = System.IO.Path.GetFileName(s);
                            destFile = System.IO.Path.Combine(targetPath, fileName);
                            System.IO.File.Copy(s, destFile, true);
                        }
                    }
                }
                fldlg = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion
        /*
       * Created By:- Sameer Shinde
       * Ctreated Date :- 5 Nov 2015
       * Purpose:- Check validation on entering text of Branch Name
       */
        #region-------------------------BtanchNameTectChange()-------------------------
        private void txtBranchName_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (txtBranchName.Text != "")
                {
                    if (txtBranchName.Text.Length > 0 && txtBranchName.Text.Length == 1)
                    {
                        if (System.Text.RegularExpressions.Regex.IsMatch(txtBranchName.Text, "^[a-zA-Z]"))
                        {
                        }
                        else
                        {
                            MessageBox.Show("Please Enter First Characerter Alphabate", "Branch Name", MessageBoxButton.OK, MessageBoxImage.Warning);
                            txtBranchName.Text = "";
                            txtBranchName.Focus();
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
       * Created By:- Sameer Shinde
       * Ctreated Date :- 5 Nov 2015
       * Purpose:- Check validation on entering text of Institute  name
       */
        #region----------------InstituteNameTextChange----------------------------------
        private void txtInstituteName_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (txtInstituteName.Text != "")
                {
                    if (txtInstituteName.Text.Length > 0 && txtInstituteName.Text.Length == 1)
                    {
                        if (System.Text.RegularExpressions.Regex.IsMatch(txtInstituteName.Text, "^[a-zA-Z]"))
                        {
                        }
                        else
                        {
                            MessageBox.Show("Please Enter First Characerter Alphabate", "Institute Name", MessageBoxButton.OK, MessageBoxImage.Warning);
                            txtInstituteName.Text = "";
                            txtInstituteName.Focus();
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
       * Created By:- Sameer Shinde
       * Ctreated Date :- 5 Nov 2015
       * Purpose:- To Exit from current form
       */
        #region----------------BtnCancelClick()------------------------------------
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion
      
   /* Created By:- Sameer Shinde
   * Created Date :- 5 Nov 2015
   * Purpose:- griddview cell click
   */
        #region--------------------------------------gridview cell click()-------------------------------------
        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                object item = grdvBranch.SelectedItem;
                string InstituteName = (grdvBranch.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                string BranchName = (grdvBranch.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                string BranchCode = (grdvBranch.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
               

                DataSet ds = obj_AddBranch.BindBranch(0,BranchName,BranchCode);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        UpID = Convert.ToInt32(ds.Tables[0].Rows[0]["BranchID"]);
                        txtBranchName.Text = ds.Tables[0].Rows[0]["BranchName"].ToString();
                        txtBranchCode.Text= ds.Tables[0].Rows[0]["BranchCode"].ToString();
                        //txtInstituteName.Text = ds.Tables[0].Rows[0]["InstituteName"].ToString();
                        txtInstituteName.Visibility = Visibility.Hidden;
                        cmbBindInstitute.Visibility = Visibility.Visible;
                        cmbBindInstitute.Margin = new Thickness(172, 50, 311, 0);
                       
                        cmbBindInstitute.Text = ds.Tables[0].Rows[0]["InstituteName"].ToString();
                        cmbSelectType.Text = "Branch";
                        txtUploadPath.Text = ds.Tables[0].Rows[0]["Logo"].ToString();
                                        
                        int act = Convert.ToInt32(ds.Tables[0].Rows[0]["IsActive"]);
                        int del = Convert.ToInt32(ds.Tables[0].Rows[0]["IsDeleted"]);
                        if (act == 1 && del == 0)
                        {
                            rbtnActive.IsChecked = true;
                        }
                        else if (act == 0 && del == 0)
                        {
                            rbtnInactive.IsChecked = true;
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
          /*
       * Created By:- Sameer Shinde
       * Created Date :- 5 Nov 2015
       * Purpose:- Window Load event
       */
      
        #region-------------WindowLoaded------------------------------------
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           BindGridview();
           cmbBindInstitute.Visibility = Visibility.Hidden;
           CountBranch();
           btnDelete.IsEnabled = false;
           txtUploadPath.IsReadOnly = true;
        }

        private void CountBranch()
        {
            try
            {
                DataSet ds = obj_AddBranch.GetBranchCount();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    cmbSelectType.Text = "Branch";
                    cmbSelectType.IsEnabled = false;
                }
                else
                {
                    cmbSelectType.Text = "Institute";
                }

            }
            catch (Exception ex)
            {
                
                 MessageBox.Show(ex.Message.ToString());
            }
        }

        private void DisplayInstituteNameField()
        {
           // cmbBindInstitute.Items.Add("Select");
            string value = cmbSelectType.SelectedValue.ToString();
            if (value == "System.Windows.Controls.ComboBoxItem: Branch")
            {
                txtInstituteName.Visibility = Visibility.Hidden;
                cmbBindInstitute.Visibility = Visibility.Visible;
                cmbBindInstitute.Margin = new Thickness(172, 50, 311, 0);
               
                bindInstituteName();
            }
            else
            {
                cmbBindInstitute.Visibility = Visibility.Hidden;
                txtInstituteName.Visibility = Visibility.Visible;
                
            }
           // cmbBindInstitute.SelectedIndex = 0;
        }

        private void bindInstituteName()
        {
           try
            {
                DataSet ds = obj_AddBranch.BindInstituteName();


                if (ds.Tables[0].Rows.Count > 0)
                {
                    cmbBindInstitute.DataContext = ds.Tables[0].DefaultView;
                    cmbBindInstitute.DisplayMemberPath = ds.Tables[0].Columns["InstituteName"].ToString();
                    cmbBindInstitute.SelectedValuePath = ds.Tables[0].Columns["InstituteName"].ToString();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        
        #endregion
          /*
       * Created By:- Sameer Shinde
       * Created Date :- 6 Nov 2015
       * Purpose:- Search Branch name
       */
       
        #region-----------------------btnSearchClick()
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtSearchBranch.Text.Trim()))
                {
                    DataSet ds =obj_AddBranch.SearchBranch(txtSearchBranch.Text);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        grdvBranch.ItemsSource = ds.Tables[0].DefaultView;
                        //grdvSubject.DataContext = ds.Tables[0].DefaultView;
                        //grdvSubject.Columns[0].Visibility = Visibility.Collapsed;
                    }
                    else
                    {
                        grdvBranch.ItemsSource = null;
                        MessageBox.Show("No Data Available");
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter Branch Name", "Message", MessageBoxButton.OK, MessageBoxImage.Warning);
                    txtSearchBranch.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion

        private void cmbSelectType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DisplayInstituteNameField();
        }
    }
}
