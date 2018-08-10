using Neptune.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class WorkerDetailsPage : Page
    {
        ObservableCollection<Worker> Workers = new ObservableCollection<Worker>();
        Worker workerInView = new Worker();
        Worker loggedInWorker = new Worker();

        public WorkerDetailsPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            WorkerDisplayPicture.DisplayName = WorkerFullNameTextBox.Text = workerInView.FullName;
            WorkerPositionTextBox.Text = workerInView.Position.PositionName;
            WorkerPhoneNumberTextBox.Text = workerInView.PhoneNumber;

            if (workerInView.AddedBy.Id == loggedInWorker.Id) WorkerAddedInformationTextBox.Text = $"Added by you on {workerInView.DateAdded}";
            else WorkerAddedInformationTextBox.Text = $"Added by {workerInView.AddedBy.FullName} on {workerInView.AddedBy}";

            if (workerInView.LastUpdatedBy.Id == loggedInWorker.Id) WorkerLastUpdatedInformationTextBox.Text = $"Last Updated by you on {workerInView.DateLastUpdated}";
            else WorkerLastUpdatedInformationTextBox.Text = $"Last Updated By {workerInView.LastUpdatedBy.FullName} on {workerInView.DateLastUpdated}";
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Workers = ControlPage.Workers;

            if (e.Parameter is string && !string.IsNullOrWhiteSpace((string)e.Parameter))
            {
                if (e.Parameter as string == "ControlPage")
                {
                    loggedInWorker = workerInView = NeptuneDatabase.WorkerSelector(ControlPage.Id, Workers);
                    WorkerDetailDeleteButton.Visibility = Visibility.Collapsed;
                }
            }

            //if (e.ToString() == "ControlPage")
            //{
            //    loggedInWorker = workerInView = NeptuneDatabase.WorkerSelector(ControlPage.Id, Workers);
            //}

            base.OnNavigatedTo(e);
        }
    }
}
