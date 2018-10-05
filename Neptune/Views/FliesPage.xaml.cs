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
        public delegate void FliesPageEventHandler(object sender, RoutedEventArgs e);
        public static event FliesPageEventHandler OnNavigatedParentReady;

        public FliesPage()
        {
            this.InitializeComponent();
        }

        private void FlyPatternsGridView_ItemClick(object sender, ItemClickEventArgs e) => OnNavigatedParentReady?.Invoke(sender, e);

        private void AllFliesViewButton_Click(object sender, RoutedEventArgs e) => OnNavigatedParentReady?.Invoke(sender, e);
    }
}
