using Neptune.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Neptune.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EditWorkerPage : Page
    {
        Worker workerToBeEdited;
        ObservableCollection<Position> Positions = AppShell.Positions;
        ObservableCollection<Modifier> Modifiers = AppShell.Modifiers;
        public delegate void OnClosePageEventHandler();
        public static event OnClosePageEventHandler OnCancelClicked;
        public delegate void SaveWorkerEventHandler(object sender, RoutedEventArgs e, Worker worker = null);
        public static event SaveWorkerEventHandler OnWorkerSaved;

        public EditWorkerPage()
        {
            this.InitializeComponent();
            workerToBeEdited = new Worker();
        }

        private void CancelWorkerButton_Click(object sender, RoutedEventArgs e) => OnCancelClicked?.Invoke();

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            workerToBeEdited = e.Parameter as Worker;
            base.OnNavigatedTo(e);
            workerNameTextBlock.Text = $"Edit {workerToBeEdited.FullName}";
            WorkerPositionComboBox.SelectedItem = Positions.FirstOrDefault(x => x.Id == workerToBeEdited.Position.Id);
        }

        private async void UpdateWorkerButton_ClickAsync(object sender, RoutedEventArgs e)
        {
            SavingWorkerProgressRing.IsActive = true;
            if (await NeptuneDatabase.UpdateWorkerRecordAsync(workerToBeEdited,
                AppShell.Workers.First(x => x.Id == AppShell._loggedInUserId),
                WorkerFirstNameTextBox.Text,
                WorkerLastNameTextBox.Text,
                WorkerPhoneNumberTextBox.Text,
                WorkerPositionComboBox.SelectedItem as Position))
            {
                await NeptuneDatabase.RetrieveWorkerAsync(workerToBeEdited, AppShell.Workers, AppShell.Modifiers, AppShell.Positions);
                //AppShell.Workers.First(x => x.Id == workerToBeEdited.Id).FirstName = workerToBeEdited.FirstName = WorkerFirstNameTextBox.Text;
                //AppShell.Workers.First(x => x.Id == workerToBeEdited.Id).LastName = workerToBeEdited.LastName = WorkerLastNameTextBox.Text;
                //AppShell.Workers.First(x => x.Id == workerToBeEdited.Id).PhoneNumber = workerToBeEdited.PhoneNumber =  WorkerFirstNameTextBox.Text;
                //AppShell.Workers.First(x => x.Id == workerToBeEdited.Id).Position = workerToBeEdited.Position = WorkerPositionComboBox.SelectedItem as Position;
                await new MessageDialog($"{workerToBeEdited.FullName} updated.").ShowAsync();
                OnWorkerSaved?.Invoke(sender, e, workerToBeEdited);
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e) => SaveButtonEnabler();

        private void SaveButtonEnabler() => UpdateWorkerButton.IsEnabled = !string.IsNullOrWhiteSpace(WorkerFirstNameTextBox.Text)
                && !string.IsNullOrWhiteSpace(WorkerLastNameTextBox.Text)
                && !string.IsNullOrWhiteSpace(WorkerPhoneNumberTextBox.Text)
                && !(WorkerPositionComboBox.SelectedItem == null);
    }
}
