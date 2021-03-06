﻿using Neptune.Models;
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
        public delegate void EditWorkerEventHandler(Worker worker);
        public static event EditWorkerEventHandler OnEditWorkerReady;

        public WorkerDetailsPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            loggedInWorker = AppShell.Workers.FirstOrDefault(p => p.Id == AppShell._loggedInUserId);
            WorkerDisplayPicture.DisplayName = WorkerFullNameTextBox.Text = workerInView.FullName;
            WorkerPositionTextBox.Text = workerInView.Position.PositionName;
            WorkerPhoneNumberTextBox.Text = workerInView.PhoneNumber;
            AddingWorkerNameHyperLinkButton.Content = (workerInView.AddedBy.Id == loggedInWorker.Id) ? $"You" : $"{workerInView.AddedBy.FullName}";
            AddingDateTextBox.Text = $"on {workerInView.DateAdded}";

            if (workerInView.DateAdded == workerInView.DateLastUpdated)
            {
                UpdatingWorkerNameHyperLinkButton.Visibility = Visibility.Collapsed;
                UpdatingDateTextBox.Visibility = Visibility.Collapsed;
                UpdateStatusTextBox.Text = "Not yet updated";
            }
            else
            {
                UpdatingWorkerNameHyperLinkButton.Content = (workerInView.LastUpdatedBy.Id == loggedInWorker.Id) ? $"You" : $"{workerInView.LastUpdatedBy.FullName}";
                UpdatingDateTextBox.Text = $"on {workerInView.DateLastUpdated}";
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Workers = AppShell.Workers;

            if (e.Parameter is string && !string.IsNullOrWhiteSpace((string)e.Parameter))
            {
                if (e.Parameter as string == "ControlPage")
                {
                    loggedInWorker = workerInView = AppShell.Workers.FirstOrDefault(p => p.Id == AppShell._loggedInUserId);
                    WorkerDetailDeleteButton.Visibility = Visibility.Collapsed;
                }
            }
            else if (e.Parameter is Worker)
            {
                workerInView = AppShell.Workers.First(x => x.Id == (e.Parameter as Worker).Id);
                WorkerDetailLogOutButton.Visibility = Visibility.Collapsed;
            }

            base.OnNavigatedTo(e);
        }

        private void WorkerDetailEditButton_Click(object sender, RoutedEventArgs e) => OnEditWorkerReady?.Invoke(workerInView);
    }
}
