using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using BenutzerVerwaltung.Entities;
using System.Data.SqlClient;
using System.Configuration;



namespace BenutzerVerwaltung
{



    public partial class MainWindow : Window
    {
        private string _connectionString;
        private object user;

        // ObservableCollection to hold User objects
        public ObservableCollection<User> Users { get; set; }





        public MainWindow()
        {
            InitializeComponent();
            Users = new ObservableCollection<User>();
            DataContext = this;

            var connectionString = "your_connection_string_here";
            using (var dbConnection = new DatabaseConnection(connectionString))
            {
               // var connection = dbConnection.OpenConnection();
                // Perform database operations using 'connection'
            }
        }


        private void AddUserClick(object sender, RoutedEventArgs e)
        {
            


            // Create a new User object
            User newUser = new User
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Id = int.Parse(txtUserId.Text.ToString()),
                Email = txtUserEmail.Text,
                Address = txtUserAddress.Text,
                Password = txtUserPassword.Password
               
            };

            // Check if the required fields are filled
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtLastName.Text) || string.IsNullOrWhiteSpace(txtUserId.Text))
            {
                MessageBox.Show("Please fill in all the required fields.", "User Management", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }


            // Check if the ID already exists
            User existingUser = Users.FirstOrDefault(user => user.Id == newUser.Id);
            if (existingUser != null)
            {
                MessageBox.Show("User ID already exists. Please enter another ID.", "User Management", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }


            // Get the selected role from the ComboBox
            ComboBoxItem choosenIItem = (ComboBoxItem)cmbUserRole.SelectedItem;
            string roleName = choosenIItem.Content.ToString();


            // Create a new Role object
            Role newRole = new Role
            {
                RoleName = roleName };


            // Get the selected permissions from the CheckBoxes
            {
                //if (chkfullAccess.IsChecked == true)
                //{
                //    newRole.Permissions.Add(new Permission { Name = "\tFull Access" });
                //}

                //if (chkFullEdit.IsChecked == true)
                //{
                //    newRole.Permissions.Add(new Permission { Name = "\tFull Edit" });
                //}

                //if (chkLimitedAccess.IsChecked == true)
                //{
                //    newRole.Permissions.Add(new Permission { Name = "\tLimited Access" });
                //}

                //if (chkLimitedEdit.IsChecked == true)
                //{
                //    newRole.Permissions.Add(new Permission { Name = "\tLimited Edit" });
                //}

                //if (chkReadOnly.IsChecked == true)
                //{
                //    newRole.Permissions.Add(new Permission { Name = "\tRead Only" });
                //}

                //if (chkWriteOnly.IsChecked == true)
                //{
                //    newRole.Permissions.Add(new Permission { Name = "\tWrite Only" });
                //}
            }
            Dictionary<CheckBox, string> checkboxPermissionMap = new Dictionary<CheckBox, string>
            {
                    { chkfullAccess, "\tFull Access" },
                    { chkFullEdit, "\tFull Edit" },
                    { chkLimitedAccess, "\tLimited Access" },
                    { chkLimitedEdit, "\tLimited Edit" },
                    { chkReadOnly, "\tRead Only" },
                    { chkWriteOnly, "\tWrite Only" }
            };

            foreach (var entry in checkboxPermissionMap)
            {
                CheckBox checkbox = entry.Key;
                string permissionName = entry.Value;

                if (checkbox.IsChecked == true)
                {
                    newRole.Permissions.Add(new Permission { PermissionName = permissionName });
                }
            }

            // Add the new role to the user's roles list
            newUser.Roles.Add(newRole);


            // Get the selected groups from the CheckBoxes
            {
                //if (chkManagement.IsChecked == true)
                //{
                //    newUser.Groups.Add(new Group { GroupName = "\tManagement" });
                //}

                //if (chkProduction.IsChecked == true)
                //{
                //    newUser.Groups.Add(new Group { GroupName = "\tProduction" });
                //}

                //if (chkSupport.IsChecked == true)
                //{
                //    newUser.Groups.Add(new Group { GroupName = "\tSupport" });
                //}

                //if (chkVisit.IsChecked == true)
                //{
                //    newUser.Groups.Add(new Group { GroupName = "\tVisitation" });
                //}
            }
            Dictionary<CheckBox, string> checkboxGroupMap = new Dictionary<CheckBox, string>
            {
                          { chkManagement, "\tManagement" },
                          { chkProduction, "\tProduction" },
                          { chkSupport, "\tSupport" },
                          { chkVisit, "\tVisitation" }
            };

            foreach (var entry in checkboxGroupMap)
            {
                CheckBox checkbox = entry.Key;
                string groupName = entry.Value;

                if (checkbox.IsChecked == true)
                {
                    newUser.Groups.Add(new Group { GroupName = groupName });
                }
            }

            // Add the new user to the collection
            Users.Add(newUser);


            // Show a success message
            MessageBox.Show("User added successfully!", "User Management", MessageBoxButton.OK, MessageBoxImage.Information);


            // Clear the input fields
            ClearInputFields();
        }

          // Clear the input fields method
        private void ClearInputFields()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtUserId.Text = "";
            txtUserEmail.Text = "";
            txtUserAddress.Text = "";
            txtUserPassword.Password = "";
            cmbUserRole.SelectedIndex = -1;
            chkfullAccess.IsChecked = false;
            chkFullEdit.IsChecked = false;
            chkLimitedAccess.IsChecked = false;
            chkLimitedEdit.IsChecked = false;
            chkReadOnly.IsChecked = false;
            chkWriteOnly.IsChecked = false;
            chkManagement.IsChecked = false;
            chkProduction.IsChecked = false;
            chkSupport.IsChecked = false;
            chkVisit.IsChecked = false;
        }





    }

}






