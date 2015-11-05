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
            rbtnActive.IsChecked = true;
            
        }
        #region-----------------Declare Variables GlobalVariables()----------------
        BLAddBranch obj_AddBranch = new BLAddBranch();
        int BranchID, CreatedByUserID, UpdatedByUserID, IsActive;
        string BranchName, BranchCode, InstituteName, Logo, UpdatedDate, strName, imageName;
        #endregion
        private void btnBrowse_Click(object sender, RoutedEventArgs e)
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
                    //string imgsource = imageName;

                    //string _finalPath;
                    //string filepath=@"D:\SVN_SchoolTimeTable\src\SchoolManagement\ImgLogo\";

                    //var files = (System.IO.Directory.GetFiles(imageName, "*.jpg*")); 

                    //foreach (var file in files)
                    //{
                    //    var filename = file.Substring(file.LastIndexOf("\\") + 1);
                    //    _finalPath = filepath; 
                    //    if (System.IO.Directory.Exists(_finalPath))
                    //    {
                    //        _finalPath = System.IO.Path.Combine(_finalPath, filename);

                    //        System.IO.File.Copy(file, _finalPath, true);
                    //    }
                    //}
                }
                fldlg = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void txtBranchName_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

        private void txtInstituteName_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

        private void btnSave_Click_1(object sender, RoutedEventArgs e)
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

        private void SaveDetails()
        {
            string Result = obj_AddBranch.SaveBranch(BranchID, BranchName, BranchCode, InstituteName, Logo, CreatedByUserID, UpdatedByUserID, UpdatedDate, IsActive);
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

        private void ClearFields()
        {
            txtBranchName.Text = "";
            txtBranchCode.Text = "";
            txtInstituteName.Text = "";
            txtUploadPath.Text = "";
        }

        private void SetParameters()
        {
            BranchID = 0;
            BranchName = txtBranchName.Text.Trim();
            BranchCode = txtBranchCode.Text.Trim();
            InstituteName = txtInstituteName.Text.Trim();
            Logo = txtUploadPath.Text.Trim();
            CreatedByUserID = 1;
            UpdatedByUserID = 1;
            UpdatedDate = DateTime.Now.ToString();
            if (rbtnActive.IsChecked == true)
            {
                IsActive = 1;
            }
            else
                IsActive = 0;
        }

        private bool Validate()
        {
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
            else if (txtInstituteName.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Institute Name.", "Institute Name Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtInstituteName.Focus();
                return false;
            }
            else if (txtUploadPath.Text.Trim() == "")
            {
                MessageBox.Show("Please Select Institute logo.", "Institute Logo Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtUploadPath.Focus();
                return false;
            }
            else
            {
                return true;

            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do You Want to delete?", "Delete", MessageBoxButton.YesNoCancel);
            if (result.Equals(MessageBoxResult.Yes))
            {
                DeleteBranch();
                string Result = obj_AddBranch.DeleteBranch(BranchName);
                if (Result == "Branch Delete Sucessfully!!!")
                {
                    MessageBox.Show(Result, "Delete SucessFull", MessageBoxButton.OK, MessageBoxImage.Information);
                    ClearFields();
                    BindGridview();
                }
                else
                {
                    MessageBox.Show(Result, "Error To Delete", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please Select Branch Name from  list", "Selct Branch Name", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            BindGridview();
            ClearFields();
        }

        private void DeleteBranch()
        {
            string BranchName = grdvBranch.SelectedCells[0].Item.ToString();
        }

        private void BindGridview()
        {
            DataSet ds = obj_AddBranch.BindBranch(0);
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdvBranch.ItemsSource = ds.Tables[0].DefaultView;
               // grdvBranch.Columns[0].Visibility = Visibility.Collapsed;
            }
        }

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
                    //string imgsource = imageName;

                    //string _finalPath;
                    //string filepath=@"D:\SVN_SchoolTimeTable\src\SchoolManagement\ImgLogo\";

                    //var files = (System.IO.Directory.GetFiles(imageName, "*.jpg*")); 

                    //foreach (var file in files)
                    //{
                    //    var filename = file.Substring(file.LastIndexOf("\\") + 1);
                    //    _finalPath = filepath; 
                    //    if (System.IO.Directory.Exists(_finalPath))
                    //    {
                    //        _finalPath = System.IO.Path.Combine(_finalPath, filename);

                    //        System.IO.File.Copy(file, _finalPath, true);
                    //    }
                    //}
                }
                fldlg = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

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

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BindGridview();
        }
    }
}
