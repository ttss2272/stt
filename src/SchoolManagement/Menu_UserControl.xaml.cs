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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SchoolManagement
{
    /// <summary>
    /// Interaction logic for Menu_UserControl.xaml
    /// </summary>
    public partial class Menu_UserControl : UserControl
    {
        public Menu_UserControl()
        {
            InitializeComponent();
            Menu.Width = System.Windows.SystemParameters.PrimaryScreenWidth;
            
        }

        private void menuHome_Click(object sender, RoutedEventArgs e)
        {
            Home objHome = new Home();
            Close();
            objHome.Show();
        }

        private void menuInstitute_Click(object sender, RoutedEventArgs e)
        {
            Branch.NewBranch objInstitute = new Branch.NewBranch();
            Close();
            objInstitute.Show();
        }

        private void menuClass_Click(object sender, RoutedEventArgs e)
        {
            Class.Class objClass = new Class.Class();
            Close();
            objClass.Show();
        }

        private void menuTeachers_Click(object sender, RoutedEventArgs e)
        {
            Teacher.Teacher1 objTeacher = new Teacher.Teacher1();
            Close();
            objTeacher.Show();
        }

        private void menuRoom_Click(object sender, RoutedEventArgs e)
        {
            Room.Room1 objRoom = new Room.Room1();
            Close();
            objRoom.Show();
        }

        private void menuBatch_Click(object sender, RoutedEventArgs e)
        {
            Batch.Batch objBatch = new Batch.Batch();
            Close();
            objBatch.Show();
        }

        private void menuUser_Click(object sender, RoutedEventArgs e)
        {
            User.User objUser = new User.User();
            Close();
            objUser.Show();
        }

        private void menuSubject_Click(object sender, RoutedEventArgs e)
        {
            Subject.NewSubject objSubject = new Subject.NewSubject();
            Close();
            objSubject.Show();
        }

        //private void menuTimeSlot_Click(object sender, RoutedEventArgs e)
        //{
        //    Timeslot.TmeSlot  objTimeSlot = new Timeslot.TmeSlot ();
        //    Close();
        //    objTimeSlot.Show();
        //}

        private void menuTeacherAvailability_Click(object sender, RoutedEventArgs e)
        {
            Teacher.TeacherAvailibility objTeacher = new Teacher.TeacherAvailibility();
            Close();
            objTeacher.Show();
        }
        private void menuRoomAvailability_Click(object sender, RoutedEventArgs e)
        {
            Room.RoomAvailibility ObjRoom = new Room.RoomAvailibility();
            Close();
            ObjRoom.Show();
        }
        private void menuBatchAvailability_Click(object sender, RoutedEventArgs e)
        {
            Batch.BatchAvailibility ObjBatch = new Batch.BatchAvailibility();
            Close();
            ObjBatch.Show();
        }       

        private void menuBranchDistance_Click_1(object sender, RoutedEventArgs e)
        {
            Branch.BranchDistance1 objBranch_Dist = new Branch.BranchDistance1();
            Close();
            objBranch_Dist.Show();
        }
        private void menuExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Close()
        {
            Window parent = Window.GetWindow(this);
            parent.Close();
        }      

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            TimeTable.Time_Table ObjTimeTable = new TimeTable.Time_Table();
            Close();
            ObjTimeTable.Show();
        }

        private void menuBatchSubject_Click(object sender, RoutedEventArgs e)
        {
            Batch.BatchSubject ObjBatchSubject_Sub = new Batch.BatchSubject();
            Close();
            ObjBatchSubject_Sub.Show();
        }

        /*
         * Created By:- PriTesh D. Sortee
         * Created Date:- 02 Dec 2015
         * Purpose:- To Give Link to Teacher batch Subject
         */
        #region------------------------------------------------TeacherBatch Subject-----------------------------------
        private void menuTeacherSubject_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Teacher.TeacherBatchSubject objTeacherBatchSubject = new Teacher.TeacherBatchSubject();
                Close();
                objTeacherBatchSubject.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
        }
        #endregion



    }
}
