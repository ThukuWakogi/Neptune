using Neptune.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
    public sealed partial class AppShell : Page
    {
        public static int Id;
        public static ObservableCollection<Modifier> Modifiers = new ObservableCollection<Modifier>();
        public static ObservableCollection<Position> Positions = new ObservableCollection<Position>();
        public static ObservableCollection<Worker> Workers = new ObservableCollection<Worker>();
        public static ObservableCollection<Customer> Customers = new ObservableCollection<Customer>();

        public AppShell()
        {
            this.InitializeComponent();
        }

        private void ControlNavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            ControlNavigationView.AlwaysShowHeader = true;

            switch (((NavigationViewItem)args.SelectedItem).Tag.ToString())
            {
                case "Workers":
                    ContentFrame.Navigate(typeof(WorkersPage));
                    ControlNavigationView.Header = ((NavigationViewItem)args.SelectedItem).Tag.ToString();
                    break;
                case "Materials":
                    ContentFrame.Navigate(typeof(UnderConstructionPage), ((NavigationViewItem)args.SelectedItem).Tag.ToString());
                    ControlNavigationView.Header = ((NavigationViewItem)args.SelectedItem).Tag.ToString();
                    break;
                case "Flies":
                    ContentFrame.Navigate(typeof(UnderConstructionPage), ((NavigationViewItem)args.SelectedItem).Tag.ToString());
                    ControlNavigationView.Header = ((NavigationViewItem)args.SelectedItem).Tag.ToString();
                    break;
                case "Orders":
                    ContentFrame.Navigate(typeof(OrdersPage));
                    ControlNavigationView.Header = ((NavigationViewItem)args.SelectedItem).Tag.ToString();
                    break;
                case "Job Cards":
                    ContentFrame.Navigate(typeof(UnderConstructionPage), ((NavigationViewItem)args.SelectedItem).Tag.ToString());
                    ControlNavigationView.Header = ((NavigationViewItem)args.SelectedItem).Tag.ToString();
                    break;
            }
        }

        private void NavigationViewItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(WorkerDetailsPage), "ControlPage");
            ControlNavigationView.AlwaysShowHeader = false;
        }

        private async void Page_LoadedAsync(object sender, RoutedEventArgs e)
        {
            Modifiers = await NeptuneDatabase.RetrieveModifiersAsync();
            Positions = await NeptuneDatabase.RetrievePositionsAsync(Modifiers);
            Workers = await NeptuneDatabase.RetreiveWorkersAsync(Modifiers, Positions);
            Customers = await NeptuneDatabase.RetrieveCustomersAsync(Modifiers);
            LoggedInUserNavigationViewItem.Content = NeptuneDatabase.WorkerSelector(Id, Workers).FullName;

            if (ContentFrame.Content == null) ContentFrame.Navigate(typeof(WorkersPage));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Id = (int)e.Parameter;
            base.OnNavigatedTo(e);
        }

        private void ControlNavigationView_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            if (ContentFrame.CanGoBack) ContentFrame.GoBack();
        }
    }
}
