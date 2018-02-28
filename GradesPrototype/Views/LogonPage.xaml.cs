using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GradesPrototype.Data;
using GradesPrototype.Services;

namespace GradesPrototype.Views
{
    /// <summary>
    /// Interaction logic for LogonPage.xaml
    /// </summary>
    public partial class LogonPage : UserControl
    {
        public LogonPage()
        {
            InitializeComponent();
        }

        #region Event Members

        // TODO: Exercise 1: Task 2a: Define the LogonSuccess event handler
        public event EventHandler LogonSuccess;

        #endregion

        #region Logon Validation

        // TODO: Exercise 1: Task 2b: Implement the Logon_Click event handler for the Logon button
        private void Logon_Click(object sender, RoutedEventArgs e)
        {
            //Save the username and role that the user specified on the form in the relevant properties of the SessionContext object.

            SessionContext.UserName = username.Text; // saves the username filled into the username textbox of the logon page.
            SessionContext.UserRole = (bool)userrole.IsChecked ? Role.Teacher : Role.Student;

            //If the user is a student, set the CurrentStudent property of the SessionContext object to the string 'Eric Gruber'
            if (SessionContext.UserRole == Role.Student)
                SessionContext.CurrentStudent = "Eric Gruber";

            // Raise the logonSuccess event
            if (LogonSuccess != null) // Checks if there are any methods subscribed to the event.
            {
                LogonSuccess(this, null); // Raises the event, this = the current user, null = no additional information is sent.
            }
        }

        // Simulate logging on (no validation or authentication performed yet)

        #endregion
    }
}
