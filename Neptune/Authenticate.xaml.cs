using Neptune.Models;
using Neptune.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Neptune
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AuthenticatePage : Page
    {
        public AuthenticatePage()
        {
            this.InitializeComponent();
            CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = true;
        }

        private async void AuthenticationSignInButton_ClickAsync(object sender, RoutedEventArgs e) => await AuthenticateAsync();

        private void ButtonEnabler() => 
            AuthenticationSignInButton.IsEnabled = !string.IsNullOrWhiteSpace(AuthenticationIdTextBox.Text) && !string.IsNullOrWhiteSpace(AuthenticationPasswordTextBox.Password);

        private void AuthenticationIdTextBox_TextChanged(object sender, TextChangedEventArgs e) => ButtonEnabler();

        private void AuthenticationPasswordTextBox_PasswordChanged(object sender, RoutedEventArgs e) => ButtonEnabler();

        private async Task AuthenticateAsync()
        {
            AuthenticationProgressRing.IsActive = true;
            bool authentic = await NeptuneDatabase.AuthenticatedAsync(Convert.ToInt32(AuthenticationIdTextBox.Text), AuthenticationPasswordTextBox.Password);

            if (authentic) Frame.Navigate(typeof(AppShell), Convert.ToInt32(AuthenticationIdTextBox.Text));
            else await new MessageDialog("You Not!").ShowAsync();

            AuthenticationProgressRing.IsActive = false;
        }

        private async void AuthenticationPasswordTextBox_KeyDownAsync(object sender, KeyRoutedEventArgs e)
        {
            if(e.Key == Windows.System.VirtualKey.Enter)
                if (!string.IsNullOrWhiteSpace(AuthenticationIdTextBox.Text) && !string.IsNullOrWhiteSpace(AuthenticationPasswordTextBox.Password)) await AuthenticateAsync();
        }
    }
}
