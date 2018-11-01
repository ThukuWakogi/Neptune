using Neptune.ContentDialogs;
using Neptune.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
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
    public sealed partial class WorkersPage : Page
    {
        private ObservableCollection<Worker> Workers = new ObservableCollection<Worker>();
        private ObservableCollection<Position> Positions = new ObservableCollection<Position>();
        public delegate void WorkersPageEventHandler(object sender, RoutedEventArgs e, Worker worker = null);
        public static event WorkersPageEventHandler OnNavigatedParentReady;
        
        public WorkersPage()
        {
            this.InitializeComponent();
            EditPositionContentDialog.OnPositionUpdated += RefreshPositions;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Workers = AppShell.Workers;
            Positions = AppShell.Positions;
            base.OnNavigatedTo(e);
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AppBarButton_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void WorkersListView_ItemClick(object sender, ItemClickEventArgs e) => OnNavigatedParentReady?.Invoke(sender, e);

        private async void PositionsGridView_ItemClickAsync(object sender, ItemClickEventArgs e)
        {
            EditPositionContentDialog editPositionContentDialog = new EditPositionContentDialog(e.ClickedItem as Position);
            await editPositionContentDialog.ShowAsync();
            Positions = AppShell.Positions;
            PositionsGridView.ItemsSource = Positions; 
        }

        private void RefreshPositions(Worker updatingWorker, Position positionToUpdate, decimal salary)
        {
            Positions.First(x => x.Id == positionToUpdate.Id).Salary = positionToUpdate.Salary = salary;
            PositionsGridView.ItemsSource = Positions;
        }
    }
}
