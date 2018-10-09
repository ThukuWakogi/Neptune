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
    public sealed partial class FliesPage : Page
    {
        private ObservableCollection<FlyPattern> FlyPatterns = AppShell.FlyPatterns;

        public FliesPage()
        {
            this.InitializeComponent();
        }

        private void AllFliesViewButton_Click(object sender, RoutedEventArgs e)
        {
            FlyPatternItemsListView.ItemsSource = AppShell.Flies;
            FlyPatternsListView.SelectionMode = ListViewSelectionMode.None;
            FlyPatternsListView.SelectionMode = ListViewSelectionMode.Single;
        }

        private void FlyPatternsListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            FlyPatternItemsListView.ItemsSource = AppShell.Flies.Where(x => x.FlyPattern.Id == (e.ClickedItem as FlyPattern).Id);
        }

        private void FlyPatternItemsListView_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }
}
