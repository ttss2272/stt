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
using System.Data.SqlClient;
using System.Configuration;

namespace SchoolManagement
{
    /// <summary>
    /// Interaction logic for Open.xaml
    /// </summary>
    public partial class Open : Window
    {
       
        BLRoom obj_Room = new BLRoom();
        
        public Open()
        {
            InitializeComponent();
        }
        
        #region---------------------------Validate()-----------------------------------------
        public bool Validate()
        {

            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Please Enter Room Name..");
                txtName.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtShortName.Text))
            {
                MessageBox.Show("Please Enter Short Name..");
                txtShortName.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtColor.Text))
            {
                MessageBox.Show("Please Enter Color Detail..");
                txtColor.Focus();
                return false;
            }
            else if (cmbCapacity.SelectedIndex == 0)
            {
                MessageBox.Show("Pleas Select Room Capacity...");
                cmbCapacity.Focus();
                return false;
            }

            else
            {
                return true;
            }
        }
        #endregion

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (Validate())
                {
                    if (btnAdd.Text == "Add")
                    {
                        string RoomName = txtName.Text;
                        string ShortName = txtShortName.Text;
                        int Campacity = Convert.ToInt32(cmbCapacity.SelectedValue.ToString());
                        string IsActive = "Yes";
                        string IsDelete = "No";
                        string result = obj_Room.addRoom( RoomName, ShortName, Campacity, Col, IsActive, IsDelete);
                        if (result == "1")
                        {
                            MessageBox.Show("Room Details are added Successfully...");
                        }
                        else
                        {
                            MessageBox.Show("This Room is Already exist");
                        }
                        clearFields();
                    }
                    else
                    {
                        //write the update code here
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        }
    }
}
