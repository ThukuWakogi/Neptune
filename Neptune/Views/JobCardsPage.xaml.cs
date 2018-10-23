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
    public sealed partial class JobCardsPage : Page
    {
        private ObservableCollection<JobCard> jobCards = new ObservableCollection<JobCard>();
        private JobCard clickedJobCard = new JobCard();
        public delegate void JobCardsPageEventHandler(object sender, RoutedEventArgs e, Worker workerToBeViewed);
        public static event JobCardsPageEventHandler OnNavigatedParentReady;

        public JobCardsPage()
        {
            this.InitializeComponent();
        }

        private void JobCardsListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            clickedJobCard = (e.ClickedItem as JobCard);
            JobCardDetailsGrid.Visibility = Visibility.Visible;
            JobCardTitle.Text = (e.ClickedItem as JobCard).DisplayJobCardId;
            JobCardTierNameHyperLinkButton.Content = (e.ClickedItem as JobCard).Tier.FullName;
            JobCardPackerNameHyperLinkButton.Content = (e.ClickedItem as JobCard).Packer.FullName;
            JobCardOrderItemFlyNameHyperLink.Content = (e.ClickedItem as JobCard).OrderItem.Fly.DisplayFlyNumberAndName;
            JobCardOrderItemFlySizeTextBox.Text = (e.ClickedItem as JobCard).OrderItem.DisplayFlySizeWithHash;
            JobCardOrderItemDozensTextBox.Text = $"{(e.ClickedItem as JobCard).OrderItem.Dozens}";
            JobCardTieCompleteTextBox.Text = (e.ClickedItem as JobCard).TieDateCompleted == default(DateTime) ? $"Tying not yet complete" : $"Tying completed on {(e.ClickedItem as JobCard).TieDateCompleted}";
            JobCardPackCompleteTextBox.Text = (e.ClickedItem as JobCard).PackDateComplete == default(DateTime) ? $"Packing not yet complete" : $"Packing completed on {(e.ClickedItem as JobCard).PackDateComplete}";
            JobCardAddingWorkerHyperLinkButton.Content = (e.ClickedItem as JobCard).AddedBy.FullName;
            JobCardAddingDateTextBlock.Text = $"on {(e.ClickedItem as JobCard).DateAdded}";

            if ((e.ClickedItem as JobCard).DateAdded == (e.ClickedItem as JobCard).DateLastUpdated)
            {
                JobCardUpdateTextBox.Text = "Not yet updated";
                JobCardUpdatingWorkerHyperLinkButton.Visibility = Visibility.Collapsed;
                JobCardUpdatingDate.Visibility = Visibility.Collapsed;
            }
            else
            {
                JobCardUpdateTextBox.Text = "Updated by ";
                JobCardUpdatingWorkerHyperLinkButton.Visibility = Visibility.Visible;
                JobCardUpdatingWorkerHyperLinkButton.Content = (e.ClickedItem as JobCard).LastUpdatedBy.FullName;
                JobCardUpdatingDate.Visibility = Visibility.Visible;
                JobCardUpdatingDate.Text = $"on {(e.ClickedItem as JobCard).DateLastUpdated}";
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            jobCards = AppShell.JobCards;
            base.OnNavigatedTo(e);
        }

        private void JobCardTierNameHyperLinkButton_Click(object sender, RoutedEventArgs e) => OnNavigatedParentReady?.Invoke(sender, e, clickedJobCard.Tier);

        private void JobCardPackerNameHyperLinkButton_Click(object sender, RoutedEventArgs e) => OnNavigatedParentReady?.Invoke(sender, e, clickedJobCard.Packer);

        private void JobCardAddingWorkerHyperLinkButton_Click(object sender, RoutedEventArgs e) 
            => OnNavigatedParentReady?.Invoke(sender, e, AppShell.Workers.FirstOrDefault(x => x.Id == clickedJobCard.AddedBy.Id));

        private void JobCardUpdatingWorkerHyperLinkButton_Click(object sender, RoutedEventArgs e) 
            => OnNavigatedParentReady?.Invoke(sender, e, AppShell.Workers.FirstOrDefault(x => x.Id == clickedJobCard.LastUpdatedBy.Id));
    }
}
