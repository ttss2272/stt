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

        private void Close()
        {
            Window parent = Window.GetWindow(this);
            parent.Close();
        }
    }
}
