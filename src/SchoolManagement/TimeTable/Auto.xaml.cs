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

namespace SchoolManagement.TimeTable
{
    /// <summary>
    /// Interaction logic for Auto.xaml
    /// </summary>
    public partial class Auto : Window
    {
        /*
         * Created By :- PriTesh D. Sortee
         * Created Date:- 11 Dec 2015
         * Purpose:-
         */
        #region--------------------------------------DeclareVariables---------------------------------------
        BLAddBranch objBranch = new BLAddBranch();
        BLAddClass objClass = new BLAddClass();
        BLBatch objBatch = new BLBatch();
        BLTimeTable objTimeTable = new BLTimeTable();
        #endregion

        /*
         * Created By :- PriTesh D. Sortee
         * Created Date:- 11 Dec 2015
         * Purpose:-
         */
        #region------------------------------------------------Main()------------------------------------
        public Auto()
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
         * Created By :- PriTesh D. Sortee
         * Created Date:- 11 Dec 2015
         * Purpose:-
         */
        #region-------------------------------------Window_Loaded----------------------------------------
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                BindBranch();
                dtDatePick.DisplayDateStart = DateTime.Today;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion

        /*
         * Created By :- PriTesh D. Sortee
         * Created Date:- 11 Dec 2015
         * Purpose:- Bind Branch
         */
        #region-------------------------------------BindBranch()----------------------------------------
        private void BindBranch()
        {
            DataSet ds = objBranch.BindBranchName();
            if (ds.Tables[0].Rows.Count>0)
            {
                
                cmbBranch.DisplayMemberPath = ds.Tables[0].Columns["BranchName"].ToString();
                cmbBranch.SelectedValuePath = ds.Tables[0].Columns["BranchID"].ToString();
                cmbBranch.SelectedValue = "0";
                cmbBranch.DataContext = ds.Tables[0].DefaultView;
            }
 
        }
        #endregion

        /*
         * Created By :- PriTesh D. Sortee
         * Created Date:- 11 Dec 2015
         * Purpose:- BindBranch
         */
        #region--------------------------------------Bind Class---------------------------------
        private void BindClass()
        {
            DataSet ds = objClass.BindClassName(Convert.ToInt32(cmbBranch.SelectedValue));
            if (ds.Tables[0].Rows.Count > 0)
            {
                cmbClass.DisplayMemberPath = ds.Tables[0].Columns["ClassName"].ToString();
                cmbClass.SelectedValuePath = ds.Tables[0].Columns["ClassID"].ToString();
                cmbClass.SelectedValue = "0";
                cmbClass.DataContext = ds.Tables[0].DefaultView;
            }
        
        }

        #endregion

        /*
         * Created By :- PriTesh D. Sortee
         * Created Date:- 11 Dec 2015
         * Purpose:- Bindbatch
         */
        #region----------------------------------BindBatch()---------------------------------------
        private void BindBatch()
        {
            DataSet ds = objBatch.loadBatchName(Convert.ToInt32(cmbClass.SelectedValue));
            if (ds.Tables[0].Rows.Count > 0)
            {
                cmbBatch.DisplayMemberPath = ds.Tables[0].Columns["BatchName"].ToString();
                cmbBatch.SelectedValuePath = ds.Tables[0].Columns["BatchID"].ToString();
                cmbBatch.SelectedValue = "0";
                cmbBatch.DataContext = ds.Tables[0].DefaultView;
            }
        }
        #endregion

        /*
         * Created By :- PriTesh D. Sortee
         * Created Date:- 11 Dec 2015
         * Purpose:- Branch Selection Changed
         */
        #region-----------------------------------------cmbBranch_SelectionChanged-------------------------------------------
        private void cmbBranch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cmbBranch.SelectedValue != "0" && cmbBranch.SelectedValue.ToString() != "0")
                {
                    BindClass();
                    cmbBranch.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion

        /*
         * Created By :- PriTesh D. Sortee
         * Created Date:- 11 Dec 2015
         * Purpose:- Class Selection Changed
         */
        #region-----------------------------------------------cmbCalss_SelectionChanged--------------------------------------
        private void cmbClass_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cmbClass.SelectedValue != "0" && cmbClass.SelectedValue.ToString() != "0")
                {
                    BindBatch();
                    cmbClass.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion

        private void btnGenrate_Click(object sender, RoutedEventArgs e)
        {
            DataSet ds = objTimeTable.Test();

            TextBlock tb1, tb2, tb3, tb4, tb5, tb6, tb7,tb8;
            RowDefinition NewRow;

            DataRow dr;

            for (int RowIndex=0; RowIndex<ds.Tables[0].Rows.Count;RowIndex++)
            {
                dr = ds.Tables[0].Rows[RowIndex];

                //add a new row to the grid
                NewRow = new RowDefinition();
                NewRow.Height = new GridLength(0, GridUnitType.Auto);
                
                gvTimeTable.RowDefinitions.Add(NewRow);


                //initialize textblock controls and populate them with product attributes
                tb1 = new TextBlock();
                tb1.Text = dr["TimeTableID"].ToString();
                tb1.Height = 50;
                
                tb1.Background = new SolidColorBrush(Colors.Plum);
                tb1.HorizontalAlignment = HorizontalAlignment.Stretch;
                tb1.TextAlignment = TextAlignment.Center;
                

                tb2 = new TextBlock();
                tb2.Text = dr["TimeTableStartDate"].ToString();
                tb2.Height = 50;
                tb2.HorizontalAlignment = HorizontalAlignment.Stretch;
                tb2.TextAlignment = TextAlignment.Center;
                tb2.Background = new SolidColorBrush(Colors.LightGray);
                
                tb3 = new TextBlock();
                tb3.Text = dr["BatchID"].ToString();
                tb3.Height = 50;
                tb3.HorizontalAlignment = HorizontalAlignment.Stretch;
                tb3.TextAlignment = TextAlignment.Center;
                tb3.Background = new SolidColorBrush(Colors.LightGray);
                
                tb4 = new TextBlock();
                tb4.Text = dr["CreatedByUserID"].ToString();
                tb4.Height = 50;
                tb4.HorizontalAlignment = HorizontalAlignment.Stretch;
                tb4.TextAlignment = TextAlignment.Center;
                tb4.Background = new SolidColorBrush(Colors.LightGray);

                tb5 = new TextBlock();
                tb5.Text = dr["UpdatedByUserID"].ToString();
                tb5.Height = 50;
                tb5.HorizontalAlignment = HorizontalAlignment.Stretch;
                tb5.TextAlignment = TextAlignment.Center;
                tb5.Background = new SolidColorBrush(Colors.LightGray);

                tb6 = new TextBlock();
                tb6.Text = dr["CreatedDate"].ToString();
                tb6.Height = 50;
                tb6.HorizontalAlignment = HorizontalAlignment.Stretch;
                tb6.TextAlignment = TextAlignment.Center;
                tb6.Background = new SolidColorBrush(Colors.LightGray);

                tb7 = new TextBlock();
                tb7.Text = dr["UpdatedDate"].ToString();
                tb7.Height = 50;
                tb7.HorizontalAlignment = HorizontalAlignment.Stretch;
                tb7.TextAlignment = TextAlignment.Center;
                tb7.Background = new SolidColorBrush(Colors.LightGray);

                tb8 = new TextBlock();
                tb8.Text = dr["IsActive"].ToString();
                tb8.Height = 50;
                tb8.HorizontalAlignment = HorizontalAlignment.Stretch;
                tb8.TextAlignment = TextAlignment.Center;
                tb8.Background = new SolidColorBrush(Colors.LightGray);

                //set the row and column positions for all the  controls
                Grid.SetRow(tb1, RowIndex);
                Grid.SetColumn(tb1, 0);
                

                Grid.SetRow(tb2, RowIndex);
                Grid.SetColumn(tb2, 1);

                Grid.SetRow(tb3, RowIndex);
                Grid.SetColumn(tb3, 2);

                Grid.SetRow(tb4, RowIndex);
                Grid.SetColumn(tb4, 3);

                Grid.SetRow(tb5, RowIndex);
                Grid.SetColumn(tb5, 4);

                Grid.SetRow(tb6, RowIndex);
                Grid.SetColumn(tb6, 5);

                Grid.SetRow(tb7, RowIndex);
                Grid.SetColumn(tb7, 6);

                Grid.SetRow(tb8, RowIndex);
                Grid.SetColumn(tb8, 7);
               
                //add the controls to the grid controls colelction
                gvTimeTable.Children.Add(tb1);

                gvTimeTable.Children.Add(tb2);
                gvTimeTable.Children.Add(tb3);
                gvTimeTable.Children.Add(tb4);
                gvTimeTable.Children.Add(tb5);
                gvTimeTable.Children.Add(tb6);
                gvTimeTable.Children.Add(tb7);
                gvTimeTable.Children.Add(tb8);
                
                
            }

            
        }


        private void SSC_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            var x = (int)e.HorizontalOffset;
            var y = (int)e.VerticalOffset;
            var coords = string.Format("{0},{1}", x, y);
            //ScrollDetails.Content = coords;
        }


    }
}
