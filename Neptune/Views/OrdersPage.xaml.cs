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
    public sealed partial class OrdersPage : Page
    {
        private ObservableCollection<Customer> Customers = new ObservableCollection<Customer>();

        public OrdersPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Customers = AppShell.Customers;
            base.OnNavigatedTo(e);
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            if(sender as AppBarToggleButton != null)
            {
                if (CustomersListView.SelectionMode == ListViewSelectionMode.Single)
                {
                    CustomersListView.SelectionMode = ListViewSelectionMode.Multiple;
                    DeleteCustomerAppBarButton.Visibility = Visibility.Visible;
                    AddCustomerAppBarButton.Visibility = Visibility.Collapsed;
                }
                else if (CustomersListView.SelectionMode == ListViewSelectionMode.Multiple)
                {
                    CustomersListView.SelectionMode = ListViewSelectionMode.Single;
                    DeleteCustomerAppBarButton.Visibility = Visibility.Collapsed;
                    AddCustomerAppBarButton.Visibility = Visibility.Visible;
                }
                else CustomersListView.SelectionMode = ListViewSelectionMode.Single;
            }
        }
    }
}
