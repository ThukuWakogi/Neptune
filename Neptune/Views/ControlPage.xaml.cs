﻿using Neptune.Models;
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
    public sealed partial class ControlPage : Page
    {
        ObservableCollection<Modifier> Modifiers = new ObservableCollection<Modifier>();
        ObservableCollection<Position> Positions = new ObservableCollection<Position>();
        ObservableCollection<Worker> Workers = new ObservableCollection<Worker>();

        public ControlPage()
        {
            this.InitializeComponent();
        }

        private void ControlNavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {

        }

        private void NavigationViewItem_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private async void Page_LoadedAsync(object sender, RoutedEventArgs e)
        {
            Modifiers = await NeptuneDatabase.RetrieveModifiersAsync();
            Positions = await NeptuneDatabase.RetrievePositionsAsync(Modifiers);
            Workers = await NeptuneDatabase.RetreiveWorkersAsync(Modifiers, Positions);

            if (ContentFrame.Content == null) ContentFrame.Navigate(typeof(WorkersPage));
        }
    }
}
