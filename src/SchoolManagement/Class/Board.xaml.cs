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
using System.Data.SqlClient;
using System.Configuration;
using BusinessLayer;

namespace SchoolManagement
{
    /// <summary>
    /// Interaction logic for Board.xaml
    /// </summary>
    public partial class Board : Window
    {
        /* Created By:- Pranjali Vidhate
       * Created Date :- 10 Dec 2015
       * Purpose:- Variables Decalration */

        #region------------------------------------VaribaleDecalration---------------------

        BLBoard ObjBoard = new BLBoard();

        int BoardID, UpID, UpDatedByUserID,IsActive,IsDeleted;
        string BoardName,UpDatedDate;

        #endregion--------------------------------------------------------------------------

        /* Created By:- Pranjali Vidhate
       * Created Date :- 10 Dec 2015
       * Purpose:- Main Fuction Defination */

        #region----------------------Main()------------------------------------------------------------
        public Board()
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
                MessageBox.Show(ex.Message.ToString(), "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion-------------------------------------------------------------------------------------

        /* Created By:- Pranjali Vidhate
       * Created Date :- 10 Dec 2015
       * Purpose:- Clearfield Function */

        #region---------------------ClearFields()----------------------------
        public void ClearFields()
        {
            UpID = 0;
            txtBoardName.Text = "";
            txtSearch.Text = "";
            rdbActive.IsChecked = true;
            rdbInactive.IsChecked = false;
            btnDelete.IsEnabled = false;
            btnAdd.Content = "Save";
            BindBoard();
        }
        #endregion------------------------------------------------------------------------

        /* Created By:- Pranjali Vidhate
       * Created Date :- 10 Dec 2015
       * Purpose:- Validate Function */

        #region--------------Validate()---------------------------------------------

        public bool Validate()
        {
          if( (string.IsNullOrEmpty(txtBoardName.Text) && string.IsNullOrWhiteSpace(txtBoardName.Text)))
          {
              MessageBox.Show("Please Enter Board Name","BoardName",MessageBoxButton.OK,MessageBoxImage.Information);
              txtBoardName.Focus();
              return false;
          }
          else if(rdbActive.IsChecked == false && rdbInactive.IsChecked == false)
          {
            MessageBox.Show("Please Select Status","Status",MessageBoxButton.OK,MessageBoxImage.Information);
            rdbActive.Focus();
            return false;
          }
          else
          {
            return true;
          }
        }

        #endregion-------------------------------------------------------------------------

        /* Created By:- Pranjali Vidhate
       * Created Date :- 10 Dec 2015
       * Purpose:- Setparameters*/

        #region---------------Setparameter()-------------------------------------------------------

        public void Setparameter()
        {
            BoardID = UpID;
            BoardName = txtBoardName.Text;
            UpDatedByUserID = 1;
            UpDatedDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
            if (rdbActive.IsChecked == true)
            {
                IsActive = 1;
                IsDeleted = 0;
            }
            else if (rdbInactive.IsChecked == true)
            {
                IsActive = 0;
                IsDeleted = 0;
            }
        }

        #endregion---------------------------------------------------------------------------------

        /* Created By:- Pranjali Vidhate
       * Created Date :- 10 Dec 2015
       * Purpose:- SaveBoard */

        #region---------------------SaveBoard()---------------------------------------------------
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Validate())
                {
                    Setparameter();
                    string Result = ObjBoard.SaveBoard(BoardID, BoardName, UpDatedByUserID, UpDatedDate, IsActive, IsDeleted);
                    if (Result == "Save Sucessfully...!!!" || Result == "Updated Sucessfully...!!!")
                    {
                        MessageBox.Show(Result, "Save Sucessfully", MessageBoxButton.OK, MessageBoxImage.Information);
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show(Result, "Error To Save", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion

        /* Created By:- Pranjali Vidhate
       * Created Date :- 10 Dec 2015
       * Purpose:- BindBoard Function */

        #region---------------------Bindboard()-----------------------------------------
        public void BindBoard()
        {
            try
            {
                 DataSet ds = ObjBoard.BindBoard(0,txtBoardName.Text);

                 if (ds.Tables[0].Rows.Count > 0)
                 {
                     //dgBoard.DataContext = null;
                     dgBoard.ItemsSource = ds.Tables[0].DefaultView;
                 }
                 dgBoard.Items.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion------------------------------------------------------------------------

        /* Created By:- Pranjali Vidhate
       * Created Date :- 10 Dec 2015
       * Purpose:- Search Button Coding */

        #region---------------------Search()------------------------------------------
        
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtSearch.Text.Trim()))
                {
                    DataSet ds = ObjBoard.BindBoard(0, txtSearch.Text);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dgBoard.ItemsSource = ds.Tables[0].DefaultView;
                    }
                    else
                    {
                        dgBoard.ItemsSource = null;
                        MessageBox.Show("No Data Fund");
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter Board Name", "Error to Search", MessageBoxButton.OK, MessageBoxImage.Information);
                    txtSearch.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        
        #endregion---------------------------------------------------------------------

        /* Created By:- Pranjali Vidhate
       * Created Date :- 10 Dec 2015
       * Purpose:- Window Load */

        #region-----------------WindowLoad()-------------------------------------------------
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            rdbActive.IsChecked = true;
            btnDelete.IsEnabled = false;
            BindBoard();
        }

        #endregion------------------------------------------------------------------------------

        /* Created By:- Pranjali Vidhate
       * Created Date :- 10 Dec 2015
       * Purpose:- Clear Button Coading */

        #region-----------------BtnClear()----------------------------------------------
        private void btnclear_Click(object sender, RoutedEventArgs e)
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
        #endregion--------------------------------------------------------------------------

        /* Created By:- Pranjali Vidhate
       * Created Date :- 10 Dec 2015
       * Purpose:- TextChangeValidation */

        #region-------------------TxtChangeValidation()--------------------------------------
        private void txtBoardName_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (txtBoardName.Text != "")
                {
                    if (txtBoardName.Text.Length > 0)
                    {
                        if (System.Text.RegularExpressions.Regex.IsMatch(txtBoardName.Text, "^[a-zA-Z ]+$"))
                        {

                        }
                        else
                        {
                            MessageBox.Show("Please Enter Only Alphabets", "BoardName", MessageBoxButton.OK, MessageBoxImage.Information);
                            txtBoardName.Text = "";
                            txtBoardName.Focus();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion---------------------------------------------------------------------------

        /* Created By:- Pranjali Vidhate
       * Created Date :- 10 Dec 2015
       * Purpose:- Row Double Click Coding */

        #region-----------------RowClick-------------------------------------------

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                object item = dgBoard.SelectedItem;
                UpID = Convert.ToInt32(((System.Data.DataRowView)(dgBoard.CurrentItem)).Row.ItemArray[0].ToString());
                txtBoardName.Text = Convert.ToString(((System.Data.DataRowView)(dgBoard.CurrentItem)).Row.ItemArray[1].ToString());
                string IsActive =Convert.ToString(((System.Data.DataRowView)(dgBoard.CurrentItem)).Row.ItemArray[2].ToString()); 
                string IsDeleted =Convert.ToString(((System.Data.DataRowView)(dgBoard.CurrentItem)).Row.ItemArray[3].ToString()); 
                
                if (IsActive == "True" && IsDeleted == "False")
                {
                    rdbActive.IsChecked = true;
                }
                else if (IsActive == "False" && IsDeleted == "False")
                {
                    rdbInactive.IsChecked = true;
                }
                       
                btnDelete.IsEnabled = true;
                btnAdd.Content = "Update";
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion------------------------------------------------------------------

        /* Created By:- Pranjali Vidhate
       * Created Date :- 10 Dec 2015
       * Purpose:- Delete Button Coding */

        #region--------------------------Delete()-------------------------------------
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Validate())
                {
                    MessageBoxResult Result = MessageBox.Show("Do You Want To Delete?", "Delete Record", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if(Result.Equals(MessageBoxResult.Yes))
                    {
                        Setparameter();
                        Delete();
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public void Delete()
        {
            if (UpID != 0)
            {
                BoardID = UpID;
               
                string Result = ObjBoard.DeleteBoard(BoardID,UpDatedByUserID,UpDatedDate);
                if (Result == "Deleted Sucessfully...!!")
                {
                    MessageBox.Show(Result, "Delete Sucessfully", MessageBoxButton.OK, MessageBoxImage.Information);
                    ClearFields();
                }
                else
                {
                    MessageBox.Show(Result, "Error To Save", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please Select Board", "Delete Error", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
        
        }
        #endregion--------------------------------------------------------------------

    }
}
